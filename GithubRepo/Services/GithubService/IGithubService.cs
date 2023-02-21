namespace GithubRepoAPI.Services.GithubService
{
    public enum GithubErrorCode
    {
        NotFound,
        RateLimitExceeded,
        UnknownError
    }

    public interface IGithubService
    {
        public Task<GetContributorsResponse> GetContributors(GetContributorsRequest request);
        
    }
}
