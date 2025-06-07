using Microsoft.AspNetCore.Mvc;
using quickhireup_api.Application.Services;
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
        
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateJobDescription([FromBody] JobDescriptionRequest jobDescriptionRequest)
        {
            var description = await _jobDescriptionService.GenerateJobDescriptionAsync(jobDescriptionRequest);
            
            return Ok(new { Description = description });
        }
    }
}