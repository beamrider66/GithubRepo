using Microsoft.AspNetCore.Mvc;

namespace GithubRepo.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class ContributorsController : ControllerBase
    {
        private readonly ILogger<ContributorsController> _logger;

        public ContributorsController(ILogger<ContributorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{owner?}/{repo?}/contributors")]
        public IEnumerable<string> Get(string owner, string repo)
        {
            return new List <string>(); 
        }
    }
}