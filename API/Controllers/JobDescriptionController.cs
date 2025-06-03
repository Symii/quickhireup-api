using Microsoft.AspNetCore.Mvc;
using quickhireup_api.Application.Interfaces;
using quickhireup_api.Models.Request;

namespace quickhireup_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobDescriptionController : ControllerBase
    {
        private readonly IJobDescriptionService _jobDescriptionService;

        public JobDescriptionController(IJobDescriptionService jobDescriptionService)
        {
            _jobDescriptionService = jobDescriptionService;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var position = "Frontend Developer";
            var location = "Warszawa";

            var description = await _jobDescriptionService.GenerateJobDescriptionAsync(position, location);
            
            return Ok(new { Description = description });
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateJobDescription([FromBody] JobDescriptionRequest request)
        {
            var description = await _jobDescriptionService.GenerateJobDescriptionAsync(request.Position, request.Location);
            
            return Ok(new { Description = description });
        }
    }
}