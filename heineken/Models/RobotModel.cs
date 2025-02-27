using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class RobotModel
    {
        [Required]
        public string? RobotName { get; set; }

        public Status RobotStatus { get; set; }

        [Required]
        public string? ActivityLocation { get; set; }

        public DateTime LastConnectionTime { get; set; }
        [Range(0, 100)]
        public int BatteryLevel { get; set; }

        public DateTime LastUpdate { get; set; }
        public enum Status
        {
            Online,
            Offline
        }
    }
}
