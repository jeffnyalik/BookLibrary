namespace BookLibrary.Data.ViewModels
{
    public class BookVM
    {
        public string bookTitle { get; set; }
        public string? description { get; set; }
        public DateTime publishedYear { get; set; }
        public int rate { get; set; }
        public string? coverUrl { get; set; }
        public string genre { get; set; }
        public bool isRead { get; set; }
        public DateTime dateRead { get; set; }
        public int publisherId { get; set; }
        public List<int> AuthorIds { get; set; }

    }

    public class BookWithAuthorsVM
    {
        public string bookTitle { get; set; }
        public string? description { get; set; }
        public DateTime publishedYear { get; set; }
        public int rate { get; set; }
        public string? coverUrl { get; set; }
        public string genre { get; set; }
        public bool isRead { get; set; }
        public DateTime dateRead { get; set; }
        public string publisherName { get; set; }
        public List<string> AuthorNames { get; set; }

    }
}
