using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniBlog.DTO;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly UserService service;
        private readonly ArticleService articleService;

        public ArticleController(UserService service, ArticleService articleService)
        {
            this.service = service;
            this.articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return this.articleService.GetAll();
        }

        [HttpPost]
        public void Create(Article article)
        {
            this.service.Register(article.UserName);

            this.articleService.AddArticle(article);
        }
    }
}