using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heineken.Data
{
    [Table("RewardRules")]
    public class RewardRule
    {
        [Key]
        public int RuleID { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PointsRequired { get; set; }

        public List<Gift> AvailableGifts { get; set; }

        public RewardRule()
        {
            AvailableGifts = new List<Gift>();
        }
    }
}
