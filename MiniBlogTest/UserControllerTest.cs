using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MiniBlog;
using MiniBlog.DTO;
using Newtonsoft.Json;
using Xunit;

namespace MiniBlogTest
{
    [Collection("IntegrationTest")]
    public class UserControllerTest
    {
        private TestServer testServer;

        [Fact]
        public async Task Should_get_all_users()
        {
            UserStore.Init();
            ArticleStore.Init();
            this.testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = this.testServer.CreateClient();
            var response = await client.GetAsync("/user");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(body);
            Assert.Equal(0, users.Count);
        }

        [Fact]
        public async Task Should_register_user_success()
        {
            UserStore.Init();
            ArticleStore.Init();
            this.testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = this.testServer.CreateClient();

            var user = new User("Test");
            var userJson = JsonConvert.SerializeObject(user);

            StringContent content = new StringContent(userJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            var registerResponse = await client.PostAsync("/user", content);
            registerResponse.EnsureSuccessStatusCode();

            var response = await client.GetAsync("/user");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(body);
            Assert.Equal(1, users.Count);
        }
    }
}