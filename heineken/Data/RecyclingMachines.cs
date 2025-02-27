using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heineken.Data
{
    [Table("RecyclingMachines")]
    public class RecyclingMachine
    {
        [Key]
        public int MachineID { get; set; }

        [Required]
        public string? MachineName { get; set; }

        public Status MachineStatus { get; set; }

        [Required]
        public string? ActivityLocation { get; set; }

        public DateTime DateAdded { get; set; }

        public int AccessCount { get; set; }

        public FillStatus BinStatus { get; set; }

        public DateTime LastConnectionTime { get; set; }



        public enum Status
        {
            Online,
            Offline
        }


        public enum FillStatus
        {
            Empty,
            AlmostFull
        }
    }
}
