using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class LocationModel
    {
        [Required]
        public string? Address { get; set; }

        public int TotalPoints { get; set; }

        public string? Area { get; set; }

        public DateTime DateAdded { get; set; }
        public int RobotCount { get; set; }
    }
}
