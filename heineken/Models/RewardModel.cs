using heineken.Data;
using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class RewardModel
    {
        [Required]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PointsRequired { get; set; }

        //public List<Gift> AvailableGifts { get; set; }

        
    }
}
