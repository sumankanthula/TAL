using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TAL.Database;

namespace TAL.Services.Contracts
{
    public interface IOccupationRatingService
    {
        Task<ICollection<Occupation>> GetOccupations();
        Task<Occupation> AddOccupation(Occupation occupation);
        Task<ICollection<Rating>> GetRatings();
        Task<Rating> AddRating(Rating rating);
        Task<ICollection<OccupationRating>> GetOccupationRatings();
        Task<OccupationRating> AddOccupationRating(OccupationRating occupationRating);
    }
}
