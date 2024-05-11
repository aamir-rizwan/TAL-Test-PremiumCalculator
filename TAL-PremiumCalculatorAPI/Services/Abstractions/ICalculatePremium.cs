using TAL_PremiumCalculatorAPI.Models;

namespace TAL_PremiumCalculatorAPI.Services.Abstractions
{
    public interface ICalculatePremium
    {
       Task<Result<PremiumCalculatorResponse>> CalculateMyPremium(PremiumCalculatorRequest request);
    }
}
