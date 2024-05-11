using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;
using static System.Reflection.Metadata.BlobBuilder;

namespace TAL_PremiumCalculatorAPI.Services.Implementations
{
    public class CalculatePremium : ICalculatePremium
    {
        private readonly ILogger<CalculatePremium> _logger;
        private readonly IOccupationsInfo _occupations;
        public CalculatePremium(IOccupationsInfo occupations, ILogger<CalculatePremium> logger)
        {
            this._occupations = occupations;
            this._logger = logger;
        }
        public async Task<Result<PremiumCalculatorResponse>> CalculateMyPremium(PremiumCalculatorRequest request)
        {
            var validationResult = PremiumCalculatorRequest.Validate(request);
            if (validationResult.IsFailure)
            {
                var msg = $"Please provide a valid data {validationResult.Error} ";
                _logger.LogError(msg);
                return Result.Failure<PremiumCalculatorResponse>(msg, StatusCodes.Status404NotFound);
            } 

            var occupations = await this._occupations.GetOccupations();
            var myOccupation = occupations.Data?.Where(x => x.Name == request.Occupation).FirstOrDefault();
            if (myOccupation == null)
            {
                var msg = $"Occupation not found {request.Occupation} ";
                _logger.LogError(msg);
                return Result.Failure<PremiumCalculatorResponse>(msg, StatusCodes.Status404NotFound);
            }

            var deathPremium = (request.DeathSumInsured * myOccupation.Rating.Factor * request.Age) / 1000 * 12;
            if(deathPremium == null || deathPremium <= 0)
            {
                var msg = $"Invalid premium calculation {deathPremium} ";
                _logger.LogError(msg);
                return Result.Failure<PremiumCalculatorResponse>(msg, StatusCodes.Status500InternalServerError);
            }

            var result = new PremiumCalculatorResponse()
            {
                Name = request.Name,
                Occupation = request.Occupation,
                Age = request.Age,
                DOB = request.DOB,
                DeathSumInsured = request.DeathSumInsured,
                DeathPremium = deathPremium
            };
            return Result.Success(result);
        }
    }
}
