using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.Database
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
    }
}
