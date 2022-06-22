using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDemoDay64.Models
{
    [Table("Bollywood")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }   

        public string? ReleaseYear { get; set; }

        public long? Budget { get; set; }


    }
}
