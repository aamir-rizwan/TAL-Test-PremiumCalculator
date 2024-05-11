using TAL_PremiumCalculatorAPI.Models;

namespace TAL_PremiumCalculatorAPI.Services.Abstractions
{
    public interface IOccupationsInfo
    {
        Task<Result<List<OccupationRating>>> GetOccupationRatings();
        Task<Result<List<Occupation>>> GetOccupations();
    }
}
