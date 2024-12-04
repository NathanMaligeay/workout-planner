using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.DTO.Account;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Services.Token;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Ok(
                        new ConnectedDTO
                        {
                            Email = user.Email,
                            Token = _tokenService.CreateToken(user),
                        }
                        );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var exists = await _userManager.FindByEmailAsync(registerDTO.Email);

                if (exists != null)
                {
                    return Unauthorized("Email already taken");
                }

                var appUser = new AppUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    return Ok(
                        new ConnectedDTO
                        {
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser),
                        }
                        );
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
