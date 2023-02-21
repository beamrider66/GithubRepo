﻿using Octokit;

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
                var result = commits.Select(c => c.Author.Login).Distinct().AsEnumerable();
                return new GetContributorsResponse(result);
            }
            catch (Octokit.NotFoundException)
            {
                return null;
            }
        }
    }
}