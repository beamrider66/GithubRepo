namespace GithubRepoAPI.Services.GithubService
{
    public class GetContributorsResponse
    {
        public GithubErrorCode? ErrorCode { get; set; }

        public GetContributorsResponse(IEnumerable<string> contributors)
        {
            Contributors = contributors;
        }
        
        public IEnumerable<string> Contributors { get; }
    }
}
