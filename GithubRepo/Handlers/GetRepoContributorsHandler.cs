using GithubRepoAPI.Requests;
using GithubRepoAPI.Response;
using GithubRepoAPI.Services.GithubService;
using MediatR;

namespace GithubRepoAPI.Handlers
{
    public class GetRepoContributorsHandler : IRequestHandler<GetRepoContributorsAPIRequest, RepoContributorsAPIResponse>
    {
        private readonly IGithubService _githubService;
        public GetRepoContributorsHandler(IGithubService githubService)
        {
            _githubService = githubService;
        }

        public async Task<RepoContributorsAPIResponse> Handle(GetRepoContributorsAPIRequest request, CancellationToken cancellationToken)
        {
            var response =  await _githubService.GetContributors(new GetContributorsRequest { Owner = request.Owner, Repo = request.Repo });
            return new RepoContributorsAPIResponse { Contributors = response.Contributors, ErrorCode = (ErrorCode?)response.ErrorCode };
        }
    }
}
