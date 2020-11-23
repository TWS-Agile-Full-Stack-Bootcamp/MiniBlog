using System;
using System.Collections.Generic;
using MiniBlog.DTO;

namespace MiniBlog
{
    public class ArticleStoreWhichWillReplaceInFuture
    {
        public ArticleStoreWhichWillReplaceInFuture()
        {
            Articles = new List<Article>();
            Articles.Add(new Article(null, "Happy new year", "Happy 2021 new year"));
            Articles.Add(new Article(null, "Happy Halloween", "Halloween is coming"));
        }

        public List<Article> Articles { get; private set; }
    }
}