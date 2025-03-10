using heineken.Models;
using heineken.Service.CampaignsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public IActionResult GetAllCampaigns()
        {
            var campaigns = _campaignService.GetAllCamp();
            return Ok(campaigns);
        }

        [HttpGet("{id}")]
        public IActionResult GetCampaignById(int id)
        {
            var campaign = _campaignService.GetCampById(id);
            if (campaign != null)
            {
                return Ok(campaign);
            }
            return NotFound(new { Message = $"Campaign with ID {id} not found." });
        }

        [HttpPost]
        public IActionResult CreateCampaign([FromBody] CampaignModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid campaign data." });
            }

            try
            {
                var createdCampaign = _campaignService.CreateCamp(model);
                return CreatedAtAction(nameof(GetCampaignById), new { id = createdCampaign.CampaignID }, createdCampaign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(int id, [FromBody] CampaignModel model)
        {
            if (model == null)
                return BadRequest(new { Message = "Invalid campaign data." });

            try
            {
                var updatedCampaign = _campaignService.UpdateCamp(id, model);
                return Ok(updatedCampaign);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"System error: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCampaign(int id)
        {
            try
            {
                var isDeleted = _campaignService.DeleteCamp(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                return NotFound(new { Message = $"Campaign with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}