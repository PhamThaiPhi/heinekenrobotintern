using heineken.Data;
using heineken.Models;

namespace heineken.Service.CampaignsService
{
    public class CampaignService : ICampaignService
    {
        private readonly MyDbHei _context;

        public CampaignService(MyDbHei context)
        {
            _context = context;
        }
        public List<Campaign> GetAllCamp()
        {
            return _context.Campaigns.ToList();
        }
        public Campaign GetCampById(int id)
        {
            return _context.Campaigns.Find(id);
        }
        public Campaign CreateCamp(CampaignModel model)
        {
            var newGift = new Campaign
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                //AssignedMachines = model.AssignedMachines,
            };
            _context.Campaigns.Add(newGift);
            _context.SaveChanges();
            return newGift;
        }
        public Campaign UpdateCamp(int id, CampaignModel model)
        {
            var existingRobot = _context.Campaigns.SingleOrDefault(f => f.CampaignID == id);
            if (existingRobot == null)
                throw new KeyNotFoundException("Gift không tồn tại!");

            existingRobot.Name = model.Name;
            existingRobot.Description = model.Description;
            existingRobot.EndDate = model.EndDate;
            existingRobot.StartDate = model.StartDate;
            //existingRobot.AssignedMachines = model.AssignedMachines;

            _context.SaveChanges();
            return existingRobot;
        }
        public bool DeleteCamp(int id)
        {
            var gift = _context.Campaigns.Find(id);
            if (gift == null) return false;

            _context.Campaigns.Remove(gift);
            _context.SaveChanges();
            return true;
        }
    }
}
