using TAL_PremiumCalculatorAPI.Models;

namespace TAL_PremiumCalculatorAPI.Services.Abstractions
{
    public interface ICalculatePremium
    {
       Task<decimal> CalculatMyPremium(PremiumCalculatorRequest request);
    }
}
