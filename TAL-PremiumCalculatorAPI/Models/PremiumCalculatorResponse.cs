namespace TAL_PremiumCalculatorAPI.Models
{
    public class PremiumCalculatorResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? DOB { get; set; }
        public string Occupation { get; set; }
        public Double DeathSumInsured { get; set; }
        public Double DeathPremium { get; set; }

    }
}
