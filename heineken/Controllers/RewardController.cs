using heineken.Data;
using heineken.Models;
using heineken.Service.RewardService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpGet]
        public ActionResult<List<RewardRule>> GetAllRewards()
        {
            return Ok(_rewardService.GetAllReward());
        }

        [HttpGet("{id}")]
        public ActionResult<RewardRule> GetRewardById(int id)
        {
            var reward = _rewardService.GetRewardById(id);
            if (reward == null) return NotFound("Reward not found");
            return Ok(reward);
        }

        [HttpPost]
        public ActionResult<RewardRule> CreateReward([FromBody] RewardModel model)
        {
            var reward = _rewardService.CreateReward(model);
            return CreatedAtAction(nameof(GetRewardById), new { id = reward.RuleID }, reward);
        }

        [HttpPut("{id}")]
        public ActionResult<RewardRule> UpdateReward(int id, [FromBody] RewardModel model)
        {
            try
            {
                var updatedReward = _rewardService.UpdateReward(id, model);
                return Ok(updatedReward);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteReward(int id)
        {
            var result = _rewardService.DeleteReward(id);
            if (!result) return NotFound("Reward not found");
            return Ok(true);
        }
    }
}
