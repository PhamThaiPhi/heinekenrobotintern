using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class GiftModel
    {
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalCount { get; set; }

        [Range(0, int.MaxValue)]
        public int RemainingCount { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
