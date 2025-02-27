using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heineken.Data
{
    [Table("Robots")]
    public class Robots
    {
        [Key]
        public int RobotID { get; set; }

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
