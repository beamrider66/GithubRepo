using GithubRepoAPI.Response;
using MediatR;

namespace GithubRepoAPI.Requests
{
    public class GetRepoContributorsAPIRequest : IRequest<RepoContributorsAPIResponse>
    {
        public string Owner{ get; set; }
        public string Repo { get; set; }
    }
}
