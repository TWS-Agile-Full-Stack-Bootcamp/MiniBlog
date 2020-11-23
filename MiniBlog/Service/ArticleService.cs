using System.Collections.Generic;
using System.Linq;
using MiniBlog.DTO;

namespace MiniBlog.Service
{
    public class ArticleService
    {
        private readonly ArticleStore articleStore;

        public ArticleService(ArticleStore articleStore)
        {
            this.articleStore = articleStore;
        }

        public void AddArticle(Article article)
        {
            articleStore.Articles.Add(article);
        }

        public List<Article> GetAll()
        {
            return articleStore.Articles.ToList();
        }
    }
}