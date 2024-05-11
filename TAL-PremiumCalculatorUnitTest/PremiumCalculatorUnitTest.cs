using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;
using TAL_PremiumCalculatorAPI.Services.Implementations;

namespace TAL_PremiumCalculatorUnitTest
{
 
    public class PremiumCalculatorUnitTest
    {
        private Mock<IOccupationsInfo> _mockOccupationsInfo = new Mock<IOccupationsInfo>();
        private Mock<ILogger<CalculatePremium>> _mockLogger = new Mock<ILogger<CalculatePremium>>();


        [Fact]
        public async Task When_InvalidPremium_Age_Calculate_Request_Then_Calculate_Fails()
        {
            var request = new PremiumCalculatorRequest()
            {
                Name = "Michael",
                Age = 0,
                DOB = DateTime.Now.AddYears(-20),
                Occupation = Occupations.FARMER,
                DeathSumInsured = -15000
            };

            var service = new CalculatePremium(_mockOccupationsInfo.Object, _mockLogger.Object);
            var result = await service.CalculateMyPremium(request);

            Assert.True(result.IsFailure);  
        }

        [Fact]
        public async Task When_InvalidPremium_Request_Calculate_Request_IsNUll_Then_Calculate_Fails()
        { 
            var service = new CalculatePremium(_mockOccupationsInfo.Object, _mockLogger.Object);
            var result = await service.CalculateMyPremium(null);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task When_InvalidPremium_When_Occupation_NotFound_Then_Calculate_Fails()
        {

            var occupations = new List<Occupation>()
            {
            new Occupation {Name = Occupations.CLEANER, Rating=  new OccupationRating {Rating = Ratings.LIGHT_MANUAL, Factor= Factors.LIGHT_MANUAL}},
            new Occupation {Name = Occupations.DOCTOR, Rating=  new OccupationRating {Rating = Ratings.PROFESSIONAL, Factor= Factors.PROFESSIONAL}}
            };

            _mockOccupationsInfo.Setup(x => x.GetOccupations()).ReturnsAsync(Result.Success<List<Occupation>>(occupations));

            var premiumCalculator = new CalculatePremium(_mockOccupationsInfo.Object, _mockLogger.Object);
            var request = new PremiumCalculatorRequest
            {
                Name = "Michael",
                Occupation = Occupations.AUTHOR,
                Age = 20,
                DOB = DateTime.Now.AddYears(-20),
                DeathSumInsured = 125484
            };

            // Act
            var result = await premiumCalculator.CalculateMyPremium(request);

            // Assert
            Assert.True(result.IsFailure);            
        }


        [Fact]
        public async Task CalculateMyPremium_ValidRequest_ReturnsSuccessResult()
        {
 
            var occupations = new List<Occupation>()
            {
            new Occupation {Name = Occupations.CLEANER, Rating=  new OccupationRating {Rating = Ratings.LIGHT_MANUAL, Factor= Factors.LIGHT_MANUAL}},
            new Occupation {Name = Occupations.DOCTOR, Rating=  new OccupationRating {Rating = Ratings.PROFESSIONAL, Factor= Factors.PROFESSIONAL}}
            };

            _mockOccupationsInfo.Setup(x => x.GetOccupations()).ReturnsAsync(Result.Success<List<Occupation>>(occupations));

            var premiumCalculator = new CalculatePremium(_mockOccupationsInfo.Object, _mockLogger.Object);
            var request = new PremiumCalculatorRequest
            {
                Name = "Michael",
                Occupation = Occupations.DOCTOR,
                Age = 20,
                DOB = DateTime.Now.AddYears(-20),
                DeathSumInsured = 125484
            };

            // Act
            var result = await premiumCalculator.CalculateMyPremium(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }


    }
}