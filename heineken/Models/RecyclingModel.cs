using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class RecyclingModel
    {
        [Required]
        public string? MachineName { get; set; }

        //public Status MachineStatus { get; set; }

        [Required]
        public string? ActivityLocation { get; set; }

        public DateTime DateAdded { get; set; }

        public int AccessCount { get; set; }

        //public FillStatus BinStatus { get; set; }

        public DateTime LastConnectionTime { get; set; }



        //public enum Status
        //{
        //    Online,
        //    Offline
        //}


        //public enum FillStatus
        //{
        //    Empty,
        //    AlmostFull
        //}
    }
}
