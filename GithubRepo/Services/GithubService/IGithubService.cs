namespace GithubRepoAPI.Services.GithubService
{
    public interface IGithubService
    {
        public Task<GetContributorsResponse> GetContributors(GetContributorsRequest request);
        
    }
}
