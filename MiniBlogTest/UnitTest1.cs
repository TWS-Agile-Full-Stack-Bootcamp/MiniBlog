using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MiniBlog;
using MiniBlog.DTO;
using Newtonsoft.Json;
using Xunit;

namespace MiniBlogTest
{
    public class UnitTest1
    {
        private TestServer testServer;

        [Fact]
        public async Task Should_get_all_users()
        {
            this.testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = this.testServer.CreateClient();
            var response = await client.GetAsync("/user");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(body);
            Assert.Equal(2, users.Count);
        }
    }
}