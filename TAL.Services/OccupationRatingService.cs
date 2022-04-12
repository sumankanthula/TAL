using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAL.Database;
using TAL.Services.Contracts;
using TALDbContext;

namespace TAL.Services
{
    public class OccupationRatingService : IOccupationRatingService
    {

        private readonly TALContext _talContext;
        public OccupationRatingService(TALContext talContext)
        {
            _talContext = talContext;
        }
        public async Task<Occupation> AddOccupation(Occupation occupation)
        {
            var exists = _talContext.Occupations.FirstOrDefault(x => x.Name.Equals(occupation.Name));
            if (exists != null) return exists;
            _talContext.Occupations.Add(occupation);
            await _talContext.SaveChangesAsync();
            return occupation;
        }

        public async Task<OccupationRating> AddOccupationRating(OccupationRating occupationRating)
        {
            var exists = _talContext.OccupationRatings.FirstOrDefault(x => x.OccupationId == occupationRating.OccupationId && x.RatingId == occupationRating.RatingId);
            if (exists != null) return exists;

            _talContext.OccupationRatings.Add(occupationRating);
            await _talContext.SaveChangesAsync();
            return occupationRating;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            var exists = _talContext.Ratings.FirstOrDefault(x => x.Name.Equals(rating.Name));
            if (exists != null) return exists;

            _talContext.Ratings.Add(rating);
            await _talContext.SaveChangesAsync();
            return rating;
        }

        public async Task<ICollection<OccupationRating>> GetOccupationRatings()
        {
            return _talContext.OccupationRatings.ToList();
        }

        public async Task<ICollection<Occupation>> GetOccupations()
        {
            return _talContext.Occupations.ToList();
        }

        public async Task<ICollection<Rating>> GetRatings()
        {
            return _talContext.Ratings.ToList();
        }
    }
}
