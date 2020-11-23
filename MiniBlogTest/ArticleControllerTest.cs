using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MiniBlog;
using MiniBlog.DTO;
using Newtonsoft.Json;
using Xunit;

namespace MiniBlogTest
{
    [Collection("IntegrationTest")]
    public class ArticleControllerTest
    {
        [Fact]
        public async void Should_get_all_Article()
        {
            UserStore.Init();
            ArticleStore.Init();
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = testServer.CreateClient();
            var response = await client.GetAsync("/article");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<Article>>(body);
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public async void Should_create_post_and_register_user_correct()
        {
            UserStore.Init();
            ArticleStore.Init();
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = testServer.CreateClient();

            Article article = new Article()
            {
                UserName = "User",
                Content = "Content",
                Title = "Title"
            };

            var articleContent = JsonConvert.SerializeObject(article);
            StringContent content = new StringContent(articleContent, Encoding.UTF8, MediaTypeNames.Application.Json);
            var postResponse = await client.PostAsync("/article", content);
            postResponse.EnsureSuccessStatusCode();
            var articleResponse = await client.GetAsync("/article");

            var body = await articleResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<Article>>(body);
            Assert.Equal(3, users.Count);
        }
    }
}