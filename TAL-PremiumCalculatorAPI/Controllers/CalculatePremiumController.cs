using Microsoft.AspNetCore.Mvc;
using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;

namespace TAL_PremiumCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatePremiumController : BaseController
    {
        private readonly ILogger<CalculatePremiumController> _logger;
        private readonly ICalculatePremium _premiumCalculator;
        private readonly IOccupationsInfo _occupations;

        public CalculatePremiumController(ILogger<CalculatePremiumController> logger, ICalculatePremium premiumCalculator, IOccupationsInfo occupations)
        {
            _logger = logger;
            _premiumCalculator = premiumCalculator;
            _occupations = occupations;
        }

        [HttpPost] 
        [Route("CalculatePremium")]
        public async Task<ActionResult<ApiResponse<PremiumCalculatorResponse>>> Get(PremiumCalculatorRequest request)
        {
            var result = await this._premiumCalculator.CalculateMyPremium(request);
            return base.HandleResult(result);            
        }


        [HttpGet]
        [Route("GetOccupationRatings")]
        public async Task<ActionResult<ApiResponse<List<OccupationRating>>>> GetOcRatings()
        {
            var result = await this._occupations.GetOccupationRatings();
            return base.HandleResult(result);
        }
         
        [HttpGet]
        [Route("GetOccupations")]
        public async Task<ActionResult<ApiResponse<List<Occupation>>>> GetOccupations()
        {
            var result = await this._occupations.GetOccupations();
            return base.HandleResult(result);
        }
    }
}
