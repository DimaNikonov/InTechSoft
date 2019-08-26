using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using TestTaskWebApi.API;
using Xunit;

namespace TestTaskWebApi.IntegrationTestsXUnit.Tests
{
    public abstract class BaseTest :
        IClassFixture<WebApplicationFactory<Startup>> 
    {
        protected string mediaType = "application/json";

        protected WebApplicationFactory<Startup> factory;

        public BaseTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        protected async Task GetAll(string path)
        {
            var client = this.factory.CreateClient();

            var response = await client.GetAsync(path);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        protected abstract Task GetTest();

        protected abstract Task PostTest();

        protected abstract Task PutTest();

        protected abstract Task DeleteTest();



    }
}
