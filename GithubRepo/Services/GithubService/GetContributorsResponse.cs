namespace GithubRepoAPI.Services.GithubService
{
    public class GetContributorsResponse
    {
        public GetContributorsResponse(IEnumerable<string> contributors)
        {
            Contributors = contributors;
        }
        
        public IEnumerable<string> Contributors { get; }
    }
}
