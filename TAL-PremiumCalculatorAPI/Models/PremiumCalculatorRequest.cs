namespace TAL_PremiumCalculatorAPI.Models
{
    public class PremiumCalculatorRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public Double DeathSumInsured { get; set; }

        public static Result Validate(PremiumCalculatorRequest request)
        {
            if (request == null)
                return Result.Failure($"{nameof(PremiumCalculatorRequest)} model is required.");

            if (string.IsNullOrEmpty(request.Name))
                return Result.Failure($"{nameof(request.Name)} is required.");

            if (request.Age == null || request.Age <= 0)
                return Result.Failure($"{nameof(request.Age)} is required.");
            
            if (request.DOB == null)
                return Result.Failure($"{nameof(request.DOB)} is required.");

            if (string.IsNullOrEmpty(request.Occupation))
                return Result.Failure($"{nameof(request.Occupation)} is required.");

            if (request.DeathSumInsured == null || request.DeathSumInsured <= 0)
                return Result.Failure($"{nameof(request.DeathSumInsured)} is required.");


            return Result.Success();
        }

    }
}
