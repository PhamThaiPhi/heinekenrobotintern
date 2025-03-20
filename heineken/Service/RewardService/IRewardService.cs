using heineken.Data;
using heineken.Models;

namespace heineken.Service.RewardService
{
    public interface IRewardService
    {
        List<RewardRule> GetAllReward();
        RewardRule GetRewardById(int id);
        RewardRule CreateReward(RewardModel model);
        RewardRule UpdateReward(int id, RewardModel robots);
        bool DeleteReward(int id);
    }
}
