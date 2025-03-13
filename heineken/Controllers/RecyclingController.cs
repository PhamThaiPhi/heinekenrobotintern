using heineken.Models;
using heineken.Service.RecyclingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace heineken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclingController : ControllerBase
    {
        private readonly IRecyclingService _recyclingService;

        public RecyclingController(IRecyclingService recyclingService)
        {
            _recyclingService = recyclingService;
        }

        [HttpGet]
        public IActionResult GetAllRecy()
        {
            var machines = _recyclingService.GetAllRecy();
            return Ok(machines);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecyById(int id)
        {
            var machine = _recyclingService.GetRecyById(id);
            if (machine != null)
            {
                return Ok(machine);
            }
            return NotFound(new { Message = $"Recycling machine with ID {id} not found." });
        }

        //[HttpPost]
        //public IActionResult CreateRecy([FromBody] RecyclingModel model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest(new { Message = "Invalid recycling machine data." });
        //    }

        //    try
        //    {
        //        var createdMachine = _recyclingService.CreateRecy(model);
        //        return CreatedAtAction(nameof(GetRecyById), new { id = createdMachine.MachineID }, createdMachine);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateRecy(int id, [FromBody] RecyclingModel model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest(new { Message = "Invalid recycling machine data." });
        //    }

        //    try
        //    {
        //        var updatedMachine = _recyclingService.UpdateRecy(id, model);
        //        return Ok(updatedMachine);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(new { Message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
        //    }
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteRecy(int id)
        {
            try
            {
                var isDeleted = _recyclingService.DeleteRecy(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                return NotFound(new { Message = $"Recycling machine with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}