using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heineken.Data
{
    [Table("Locations")]
    public class Locations
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        public string? Address { get; set; }

        public int TotalPoints { get; set; }

        public string? Area { get; set; }

        public DateTime DateAdded { get; set; }
        public int RobotCount { get; set; }
    }
}
