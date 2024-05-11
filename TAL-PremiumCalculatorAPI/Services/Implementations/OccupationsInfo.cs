using TAL_PremiumCalculatorAPI.Models;
using TAL_PremiumCalculatorAPI.Services.Abstractions;

namespace TAL_PremiumCalculatorAPI.Services.Implementations
{
    public class OccupationsInfo : IOccupationsInfo
    {
        public OccupationsInfo()
        {
        }

        public async Task<Result<List<OccupationRating>>> GetOccupationRatings()
        {
            List<OccupationRating> occupationRatings = new List<OccupationRating> {
                new OccupationRating {Rating = Ratings.PROFESSIONAL, Factor= Factors.PROFESSIONAL},
                new OccupationRating {Rating = Ratings.WHITE_COLLAR, Factor= Factors.WHITE_COLLAR},
                new OccupationRating {Rating = Ratings.LIGHT_MANUAL, Factor= Factors.LIGHT_MANUAL},
                new OccupationRating {Rating = Ratings.HEAVY_MANUAL, Factor= Factors.HEAVY_MANUAL}
            };
            return Result.Success(occupationRatings);             
        }

        public async Task<Result<List<Occupation>>> GetOccupations()
        {
            List<Occupation> occupations = new List<Occupation> {
                new Occupation {Name = Occupations.CLEANER, Rating=  new OccupationRating {Rating = Ratings.LIGHT_MANUAL, Factor= Factors.LIGHT_MANUAL}},
                new Occupation {Name = Occupations.DOCTOR, Rating=  new OccupationRating {Rating = Ratings.PROFESSIONAL, Factor= Factors.PROFESSIONAL}},
                new Occupation {Name = Occupations.AUTHOR, Rating=  new OccupationRating {Rating = Ratings.WHITE_COLLAR, Factor= Factors.WHITE_COLLAR}},
                new Occupation {Name = Occupations.FARMER, Rating=  new OccupationRating {Rating = Ratings.HEAVY_MANUAL, Factor= Factors.HEAVY_MANUAL}},
                new Occupation {Name = Occupations.MECHANIC, Rating=  new OccupationRating {Rating = Ratings.HEAVY_MANUAL, Factor= Factors.HEAVY_MANUAL}},
                new Occupation {Name = Occupations.FLORIST, Rating=  new OccupationRating {Rating = Ratings.LIGHT_MANUAL, Factor= Factors.LIGHT_MANUAL}} 
            };
            return Result.Success(occupations); 
        }

    }
}
