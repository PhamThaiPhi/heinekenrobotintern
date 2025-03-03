using heineken.Data;
using heineken.Models;

namespace heineken.Service.GiftService
{
    public class GiftService : IGiftService
    {
        private readonly MyDbHei _context;

        public GiftService(MyDbHei context)
        {
            _context = context;
        }
        public List<Gift> GetAllGift()
        {
            return _context.Gifts.ToList();
        }
        public Gift GetGiftById(int id)
        {
            return _context.Gifts.Find(id);
        }
        public Gift CreateGift(GiftModel model)
        {
            var newGift = new Gift
            {
                Name = model.Name,
                Description = model.Description,
                LastUpdated = model.LastUpdated,
                RemainingCount = model.RemainingCount,
                TotalCount = model.TotalCount,
            };
            _context.Gifts.Add(newGift);
            _context.SaveChanges();
            return newGift;
        }
        public Gift UpdateGift(int id, GiftModel model)
        {
            var existingRobot = _context.Gifts.SingleOrDefault(f => f.GiftID == id);
            if (existingRobot == null)
                throw new KeyNotFoundException("Gift không tồn tại!");

            existingRobot.Name = model.Name;
            existingRobot.Description = model.Description;
            existingRobot.LastUpdated = model.LastUpdated;
            existingRobot.RemainingCount = model.RemainingCount;
            existingRobot.TotalCount =model.TotalCount;
            
            _context.SaveChanges();
            return existingRobot;
        }
        public bool DeleteGift(int id)
        {
            var gift = _context.Gifts.Find(id);
            if (gift == null) return false;

            _context.Gifts.Remove(gift);
            _context.SaveChanges();
            return true;
        }
    }
}
