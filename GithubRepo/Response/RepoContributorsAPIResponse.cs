namespace GithubRepoAPI.Response
{
    public enum ErrorCode
    {
        NotFound,
        RateLimitExceeded,
        UnknownError
    }

    public class RepoContributorsAPIResponse
    {
        public ErrorCode? ErrorCode { get; set; }

        public  IEnumerable<string> Contributors { get; set; }
    }
}
