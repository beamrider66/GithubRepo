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
            if (response.ErrorCode == GithubRepoAPI.Response.ErrorCode.NotFound)
            {
                // Return a 404 if the supplied owner/repo is not valid
                return NotFound("The requested owner or repository could not be found.");
            }

            if (response.ErrorCode == GithubRepoAPI.Response.ErrorCode.RateLimitExceeded)
            {
                // Return a 400 if the request limit exceeded.
                return BadRequest("Request rate limit exceeded.");
            }

            if (response.ErrorCode == GithubRepoAPI.Response.ErrorCode.UnknownError)
            {
                // Return a 500 for other gitghub errors we don't expect.
                return Problem("Git hub returned an unexpected error.");
            }

            // Acceptance criteria specifies only first 30 are required.
            var results = response.Contributors;

            return Ok(results);
        }
    }
}