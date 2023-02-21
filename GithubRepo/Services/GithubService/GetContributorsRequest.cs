namespace GithubRepoAPI.Services.GithubService
{
    public class GetContributorsRequest
    {
        public string Owner { get; set; }
        public string Repo { get; set; }
    }
}
