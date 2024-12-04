using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
