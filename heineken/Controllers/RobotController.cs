using heineken.Data;
using heineken.Models;
using heineken.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;

        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        // Lấy danh sách Robot
        [HttpGet]
        public IActionResult GetAll() 
        {
            var robot = _robotService.GetAllRobots();
            return Ok(robot);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var robot = _robotService.GetRobotsById(id);
            if (robot != null)
            {
                return Ok(robot);
            }
            return NotFound(new { Message = $"Flight with ID {id} not found." });
        }
        [HttpPost]
        public IActionResult Create([FromBody] RobotModel robots)
        {
            if (robots == null)
            {
                return BadRequest(new { Message = "Invalid flight data." });
            }

            try
            {
                var createdFlight = _robotService.CreateRobots(robots);
                return CreatedAtAction(nameof(GetById), new { id = createdFlight.RobotID                           }, createdFlight);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }




        [HttpPut("{id}")]
        public IActionResult UpdateRobots(int id, [FromBody] RobotModel robots)
        {
            if (robots == null)
                return BadRequest(new { Message = "Dữ liệu robot không hợp lệ." });

            try
            {
                var updatedRobot = _robotService.UpdateRobots(id, robots);
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
                var isDeleted = _robotService.DeleteRobots(id);
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
