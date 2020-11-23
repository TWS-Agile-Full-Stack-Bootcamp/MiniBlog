using System;
using System.Collections.Generic;
using MiniBlog.DTO;

namespace MiniBlog
{
    public abstract class ArticleStore
    {
        static ArticleStore()
        {
            Articles = new List<Article>();
            Articles.Add(new Article()
            {
                Content = "新年快来了",
                Title = "新年到",
            });
            Articles.Add(new Article()
            {
                Content = "万圣节快来了",
                Title = "开心",
            });
        }

        public static List<Article> Articles { get; private set; }
    }
}