using System;
using System.Collections.Generic;
using System.Linq;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service
{
    public class ArticleService
    {
        private readonly ArticleStoreWhichWillReplaceInFuture articleStore;

        public ArticleService(ArticleStoreWhichWillReplaceInFuture articleStore)
        {
            this.articleStore = articleStore;
        }

        public virtual void AddArticle(Article article)
        {
            articleStore.Articles.Add(article);
        }

        public List<Article> GetAll()
        {
            return articleStore.Articles.ToList();
        }

        public void RemoveByUserName(string userName)
        {
            this.articleStore.Articles.RemoveAll(article => article.UserName == userName);
        }

        public Article GetById(Guid id)
        {
            return this.articleStore.Articles.FirstOrDefault(article => article.Id == id);
        }
    }
}