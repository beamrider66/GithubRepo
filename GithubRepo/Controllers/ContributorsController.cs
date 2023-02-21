using GithubRepoAPI.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GithubRepoAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class ContributorsController : ControllerBase
    {
        private readonly ILogger<ContributorsController> _logger;
        private readonly IMediator _mediator;

        public ContributorsController(ILogger<ContributorsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{owner?}/{repo?}/[controller]")]
        public async Task<IActionResult> Get(string owner, string repo)
        {
            var request = new GetRepoContributorsAPIRequest
            {
                Owner = owner,
                Repo = repo
            };

            var response = await _mediator.Send(request);
            if (response == null)
            {
                // Return a 404 if the supplied owner/repo is not valid
                return NotFound("The requested owner or repository could not be found.");
            }

            // Acceptance criteria specifies only first 30 are required.
            var results = response.Contributors.Take(30);

            return Ok(results);
        }
    }
}