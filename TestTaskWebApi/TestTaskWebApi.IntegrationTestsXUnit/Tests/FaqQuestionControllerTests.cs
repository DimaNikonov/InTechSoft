using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTaskWebApi.API;
using TestTaskWebApi.API.Entities;
using Xunit;

namespace TestTaskWebApi.IntegrationTestsXUnit.Tests
{
    public class FaqQuestionControllerTests : BaseTest
    {
        const string path = "/api/faqquestion";

        private readonly DataProvider<FaqQuestionViewModel> provider;

        public FaqQuestionControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
            this.factory = factory;
            this.provider = new DataProvider<FaqQuestionViewModel>();
        }

        [Fact]
        protected override async Task DeleteTest()
        {
            var client = this.factory.CreateClient();

            var faqQuestionList = await this.provider.GetListAsync(client, path);

            var pathApi = string.Concat(path, "/", faqQuestionList.LastOrDefault().Id);

            var response = await client.DeleteAsync(pathApi);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected async Task GetAllTest()
        {
            await base.GetAll(path);
        }

        [Fact]
        protected override async Task GetTest()
        {
            var client = this.factory.CreateClient();

            var faqQuestions = await this.provider.GetListAsync(client, path);

            var id = faqQuestions.LastOrDefault().Id;

            var pathApi = string.Concat(path, "/", id);

            var response = await client.GetAsync(pathApi);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected override async Task PostTest()
        {
            var client = this.factory.CreateClient();

            var faqQuestionTest = new
            {
                Question = "TestQuestion",
                Answer = "TestAnswer",
                FaqGroupId = (await new DataProvider<FaqGroupViewModel>()
                                    .GetListAsync(client, FaqGroupControllerTests.path))
                                    .LastOrDefault().Id
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(faqQuestionTest), Encoding.UTF8, mediaType);

            var response = await client.PostAsync(path, stringContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected override async Task PutTest()
        {
            var client = this.factory.CreateClient();

            var faqQuestionList = await this.provider.GetListAsync(client, path);

            var faqQuestionTest = new
            {
                Question = "TestQuestionUpdate",
                Answer = "TestAnswerUpdate",
                FaqGroupId = (await new DataProvider<FaqGroupViewModel>()
                                    .GetListAsync(client, FaqGroupControllerTests.path))
                                    .LastOrDefault().Id
            };
            var pathApi = string.Concat(path, "/", faqQuestionList.LastOrDefault().Id);

            var stringContent = new StringContent(JsonConvert.SerializeObject(faqQuestionTest), Encoding.UTF8, mediaType);

            var response = await client.PutAsync(pathApi, stringContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
