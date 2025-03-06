using heineken.Models;
using heineken.Service;
using heineken.Service.LocationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService robotService)
        {
            _locationService = robotService;
        }

        // Lấy danh sách Robot
        [HttpGet]
        public IActionResult GetAll()
        {
            var robot = _locationService.GetAll();
            return Ok(robot);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var robot = _locationService.GetById(id);
            if (robot != null)
            {
                return Ok(robot);
            }
            return NotFound(new { Message = $"Flight with ID {id} not found." });
        }
        [HttpPost]
        public IActionResult Create([FromBody] LocationModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid flight data." });
            }

            try
            {
                var createdFlight = _locationService.Create(model);
                return CreatedAtAction(nameof(GetById), new { id = createdFlight.LocationID }, createdFlight);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateRobots(int id, [FromBody] LocationModel robots)
        {
            if (robots == null)
                return BadRequest(new { Message = "Dữ liệu robot không hợp lệ." });

            try
            {
                var updatedRobot = _locationService.Update(id, robots);
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
                var isDeleted = _locationService.Delete(id);
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
