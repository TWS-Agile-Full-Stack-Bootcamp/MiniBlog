using System;
using System.Collections.Generic;
using MiniBlog.DTO;

namespace MiniBlog
{
    public abstract class ArticleStore
    {
        static ArticleStore()
        {
            Init();
        }

        public static List<Article> Articles { get; private set; }

        public static void Init()
        {
            Articles = new List<Article>();
            Articles.Add(new Article(null, "Happy new year", "Happy 2021 new year"));
            Articles.Add(new Article(null, "Happy Halloween", "Halloween is coming"));
        }
    }
}