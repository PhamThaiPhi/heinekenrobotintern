using heineken.Data;
using System.ComponentModel.DataAnnotations;

namespace heineken.Models
{
    public class CampaignModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<RecyclingMachine> AssignedMachines { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public CampaignModel()
        {
            AssignedMachines = new List<RecyclingMachine>();
        }
    }
}
