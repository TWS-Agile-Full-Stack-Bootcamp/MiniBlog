namespace MiniBlog.DTO
{
    public class Article
    {
        public Article()
        {
        }

        public Article(string userName, string title, string content)
        {
            UserName = userName;
            Title = title;
            Content = content;
        }

        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}