using Octokit;

namespace GithubRepoAPI.Services.GithubService
{
    public class GithubService : IGithubService
    {

        public async Task<GetContributorsResponse> GetContributors(GetContributorsRequest request)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("GithubService"));
                var commits = await client.Repository.Commit.GetAll(request.Owner, request.Repo);
                var commitAuthors = commits.Select(c => c.Commit)
                    .OrderByDescending(i => i.Author.Date)
                    .Take(30)
                    .ToList();
                var authorDetails = commitAuthors.Select(ca => AuthorFromCommit(ca))
                    .Where(c => !String.IsNullOrEmpty(c))
                    .Where(c => c != "GitHub")
                    .Distinct();
                return new GetContributorsResponse(authorDetails);
            }
            catch (Octokit.NotFoundException)
            {
                return new GetContributorsResponse(null) { ErrorCode = GithubErrorCode.NotFound };
            }
            catch (Octokit.RateLimitExceededException)
            {
                return new GetContributorsResponse(null) { ErrorCode = GithubErrorCode.RateLimitExceeded};
            }
            catch (Exception e)
            {
                return new GetContributorsResponse(null) { ErrorCode = GithubErrorCode.UnknownError };
            }
        }

        private string AuthorFromCommit(Commit commit)
        {
            return commit?.Committer?.Name;
        }
    }
}