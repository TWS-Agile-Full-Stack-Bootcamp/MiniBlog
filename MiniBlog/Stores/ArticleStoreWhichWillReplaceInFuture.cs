using System;
using System.Collections.Generic;
using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class ArticleStoreWhichWillReplaceInFuture
    {
        public ArticleStoreWhichWillReplaceInFuture()
        {
            Init();
        }

        public List<Article> Articles { get; private set; }

        /// <summary>
        /// This is for test only, please help resolve!
        /// </summary>
        public void Init()
        {
            Articles = new List<Article>();
            Articles.Add(new Article(null, "Happy new year", "Happy 2021 new year"));
            Articles.Add(new Article(null, "Happy Halloween", "Halloween is coming"));
        }
    }
}