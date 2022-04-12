using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.Database
{
    public class Occupation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
