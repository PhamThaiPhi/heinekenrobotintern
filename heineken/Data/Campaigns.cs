using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heineken.Data
{
    [Table("Campaigns")]
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<RecyclingMachine> AssignedMachines { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Campaign()
        {
            AssignedMachines = new List<RecyclingMachine>();
        }
    }
}
