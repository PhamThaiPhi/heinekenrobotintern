using heineken.Data;
using heineken.Models;

namespace heineken.Service.RewardService
{
    public class RewardService : IRewardService
    {
        private readonly MyDbHei _context;

        public RewardService(MyDbHei context)
        {
            _context = context;
        }

 
        public List<RewardRule> GetAllReward()
        {
            return _context.RewardRules.ToList();
        }

        public RewardRule GetRewardById(int id)
        {
            return _context.RewardRules.Find(id);
        }

     
        public RewardRule CreateReward(RewardModel model)
        {
            var newRobot = new RewardRule
            {
                Description = model.Description,
                PointsRequired = model.PointsRequired,
                AvailableGifts = model.AvailableGifts,
            };

            _context.RewardRules.Add(newRobot);
            _context.SaveChanges();
            return newRobot;
        }

   
        public RewardRule UpdateReward(int id, RewardModel robots)
        {
            var existingRobot = _context.RewardRules.SingleOrDefault(f => f.RuleID == id);
            if (existingRobot == null)
                throw new KeyNotFoundException("Rules không tồn tại!");

            existingRobot.Description = robots.Description;
            existingRobot.PointsRequired = robots.PointsRequired;
            existingRobot.AvailableGifts = robots.AvailableGifts;
            _context.SaveChanges();
            return existingRobot;
        }


        public bool DeleteReward(int id)
        {
            var robot = _context.RewardRules.Find(id);
            if (robot == null) return false;

            _context.RewardRules.Remove(robot);
            _context.SaveChanges();
            return true;
        }
    }
}

