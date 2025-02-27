using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace heineken.Data
{
    [Table("Gifts")]
    public class Gift
    {
        [Key]
        public int GiftID { get; set; }

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
