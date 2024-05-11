using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;

namespace TAL_PremiumCalculatorAPI.Services.Implementations
{
    public class CalculatePremium : ICalculatePremium
    {
        public async Task<decimal> CalculatMyPremium(PremiumCalculatorRequest request)
        {
            return 0;
        }
    }
}
