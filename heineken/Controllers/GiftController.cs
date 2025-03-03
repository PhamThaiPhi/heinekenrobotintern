using heineken.Models;
using heineken.Service;
using heineken.Service.GiftService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;

        public GiftController(IGiftService robotService)
        {
            _giftService = robotService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var gift = _giftService.GetAllGift();
            return Ok(gift);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gift = _giftService.GetGiftById(id);
            if (gift != null)
            {
                return Ok(gift);
            }
            return NotFound(new { Message = $"Flight with ID {id} not found." });
        }
        [HttpPost]
        public IActionResult Create([FromBody] GiftModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid flight data." });
            }

            try
            {
                var createdFlight = _giftService.CreateGift(model);
                return CreatedAtAction(nameof(GetById), new { id = createdFlight.GiftID }, createdFlight);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }




        [HttpPut("{id}")]
        public IActionResult UpdateGift(int id, [FromBody] GiftModel model)
        {
            if (model == null)
                return BadRequest(new { Message = "Dữ liệu robot không hợp lệ." });

            try
            {
                var updatedRobot = _giftService.UpdateGift(id, model);
                return Ok(updatedRobot);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Lỗi hệ thống: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _giftService.DeleteGift(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                return NotFound(new { Message = $"Flight with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
