using GithubRepoAPI.Handlers;
using GithubRepoAPI.Services.GithubService;
using NSubstitute;
using FluentAssertions;
using GithubRepoAPI.Requests;

namespace GethubRepoAPITests
{
    public class HandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
           // arrange
            var githubService = Substitute.For<IGithubService>();
            var response  = new GetContributorsResponse (new List<string> { "TestResponse"});
            githubService.GetContributors(Arg.Any<GetContributorsRequest>()).Returns(response);
            var handler = new GetRepoContributorsHandler(githubService);
            var handlerRequest = new GetRepoContributorsAPIRequest
            {
                Owner = "TestOwner",
                Repo = "TestRepo"
            };


            // Act
            var result = await handler.Handle(handlerRequest, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Contributors.Should().NotBeNull();
            result.Contributors.Count().Should().Be(1);
            result.Contributors.Single().Should().Be(response.Contributors.Single());

        }
    }
}