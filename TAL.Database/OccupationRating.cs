using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.Database
{
    public class OccupationRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OccupationId { get; set; }
        public int RatingId { get; set; }
    }
}
