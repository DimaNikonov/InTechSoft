using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTaskWebApi.API;

namespace TestTaskWebApi.IntegrationTestsXUnit
{
    public class DataProvider<TModel> where TModel : class                                               
    {
        public async Task<IEnumerable<TModel>> GetListAsync(HttpClient client, string path)
        {
            var response = await client.GetAsync(path);
            return await this.DeserializeListAsync(response.Content);
        }

        private async Task<IEnumerable<TModel>> DeserializeListAsync(HttpContent content)
        {
            var str = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(str);
        }
 
    }
}
