using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MiniBlog;
using MiniBlog.DTO;
using Newtonsoft.Json;
using Xunit;

namespace MiniBlogTest
{
    [Collection("IntegrationTest")]
    public class UserControllerTest
    {
        [Fact]
        public async Task Should_get_all_users()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var userStore = testServer.Services.GetService<UserStore>();
            userStore.Init();
            var articleStore = testServer.Services.GetService<ArticleStore>();
            articleStore.Init();

            var client = testServer.CreateClient();
            var response = await client.GetAsync("/user");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(body);
            Assert.Equal(0, users.Count);
        }

        [Fact]
        public async Task Should_register_user_success()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var userStore = testServer.Services.GetService<UserStore>();
            userStore.Init();
            var articleStore = testServer.Services.GetService<ArticleStore>();
            articleStore.Init();
            var client = testServer.CreateClient();

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