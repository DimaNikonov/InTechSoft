using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
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
    public class FaqGroupControllerTests : BaseTest<Startup>
    {
        public const string path = "/api/faqgroup";

        private readonly DataProvider<FaqGroupViewModel> provider;

        public FaqGroupControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
            this.factory = factory;
            this.provider = new DataProvider<FaqGroupViewModel>();
        }

        [Fact]
        protected  async Task GetAllTest()
        {
            await base.GetAll(path);
        }

        [Fact]
        protected override async Task GetTest()
        {
            var client = this.factory.CreateClient();

            var faqGroups = await this.provider.GetListAsync(client, path);

            var id = faqGroups.LastOrDefault().Id;

            var pathApi = string.Concat(path, "/", id);

            var response = await client.GetAsync(pathApi);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected override async Task PostTest()
        {
            var client = this.factory.CreateClient();

            var faqGroupTest = new
            {
                Title = "TestTitle"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(faqGroupTest), Encoding.UTF8, mediaType);

            var response = await client.PostAsync(path, stringContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected override async Task PutTest()
        {
            var client = this.factory.CreateClient();

            var faqGroupList = await this.provider.GetListAsync(client, path);

            var faqGroupTest = new
            {
                Title = "TestUpdate"
            };
            var pathApi = string.Concat(path, "/", faqGroupList.LastOrDefault().Id);

            var stringContent = new StringContent(JsonConvert.SerializeObject(faqGroupTest), Encoding.UTF8, mediaType);

            var response = await client.PutAsync(pathApi, stringContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        protected override async Task DeleteTest()
        {
            var client = this.factory.CreateClient();

            var faqGroupList = await this.provider.GetListAsync(client, path);

            var pathApi = string.Concat(path, "/", faqGroupList.LastOrDefault().Id);

            var response = await client.DeleteAsync(pathApi);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
