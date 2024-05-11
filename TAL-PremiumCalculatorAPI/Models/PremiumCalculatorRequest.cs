namespace TAL_PremiumCalculatorAPI.Models
{
    public class PremiumCalculatorRequest
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }

    }
}
