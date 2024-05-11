using Microsoft.AspNetCore.Mvc;
using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;

namespace TAL_PremiumCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatPremiumController : Controller
    {
        private readonly ILogger<CalculatPremiumController> _logger;
        private readonly ICalculatePremium _premiumCalculator;

        public CalculatPremiumController(ILogger<CalculatPremiumController> logger, ICalculatePremium premiumCalculator)
        {
            _logger = logger;
            _premiumCalculator = premiumCalculator;
        }

        [HttpGet(Name = "CalculatePremium")]
        public async Task<ActionResult> Get(PremiumCalculatorRequest request)
        {
            var result = await this._premiumCalculator.CalculatMyPremium(request);
            return Ok(result);
        }
         
    }
}
