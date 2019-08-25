using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestTaskWebApi.IntegrationTestsXUnit.Tests
{
    public abstract class BaseTest<TFixture> :
        IClassFixture<WebApplicationFactory<TFixture>> where TFixture : class
    {
        protected string mediaType = "application/json";
        protected WebApplicationFactory<TFixture> factory;

        public BaseTest(WebApplicationFactory<TFixture> factory)
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
