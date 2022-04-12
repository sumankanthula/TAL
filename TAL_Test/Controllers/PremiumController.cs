using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAL.Services.Contracts;

namespace TAL_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IOccupationRatingService _occupationRatingService;
        public PremiumController(IOccupationRatingService occupationRatingService)
        {
            _occupationRatingService = occupationRatingService;
        }

        [HttpGet]
        [Route("GetPremiumData")]
        public async Task<IActionResult> GetPremiumData()
        {
            var occupations = await _occupationRatingService.GetOccupations();
            var ratings = await _occupationRatingService.GetRatings();
            var occupationRatings = await _occupationRatingService.GetOccupationRatings();
            return Ok(new { occupations = occupations, ratings = ratings, occupationRatings = occupationRatings });
        }

        //[HttpGet]
        //[Route("GetRatings")]
        //public IActionResult GetRatings()
        //{
        //    return Ok(_occupationRatingService.GetRatings());
        //}

        //[HttpGet]
        //[Route("GetOccupationRatings")]
        //public IActionResult GetOccupationRatings()
        //{
        //    return Ok(_occupationRatingService.GetOccupationRatings());
        //}

        [HttpGet]
        [Route("InitialSetup")]
        public async Task<IActionResult> InitialSetup()
        {
            var cleaner = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Cleaner" });
            var doctor = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Doctor" });
            var author = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Author" });
            var farmer = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Farmer" });
            var mechanic = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Mechanic" });
            var florist = await _occupationRatingService.AddOccupation(new TAL.Database.Occupation { Name = "Florist" });

            var professional = await _occupationRatingService.AddRating(new TAL.Database.Rating { Name = "Professional", Rate = 1.0f });
            var whiteCollar = await _occupationRatingService.AddRating(new TAL.Database.Rating { Name = "White Collar", Rate = 1.25f });
            var lightManual = await _occupationRatingService.AddRating(new TAL.Database.Rating { Name = "Light Manual", Rate = 1.50f });
            var heavyManual = await _occupationRatingService.AddRating(new TAL.Database.Rating { Name = "Heavy Manual", Rate = 1.75f });

            var cleanerLightManual = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = cleaner.Id,
                RatingId = lightManual.Id
            });

            var drProf = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = doctor.Id,
                RatingId = professional.Id
            });

            var authorWhiteColor = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = author.Id,
                RatingId = whiteCollar.Id
            });

            var farmerHeavyManual = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = farmer.Id,
                RatingId = heavyManual.Id
            });


            var mechanicHeavyManual = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = mechanic.Id,
                RatingId = heavyManual.Id
            });


            var floristLightManual = await _occupationRatingService.AddOccupationRating(new TAL.Database.OccupationRating
            {
                OccupationId = florist.Id,
                RatingId = lightManual.Id
            });

            return Ok(new { msg = "Setup_Done" });
        }

    }
}
