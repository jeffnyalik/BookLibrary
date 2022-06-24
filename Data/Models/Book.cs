using BookLibrary.Data.Models;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string bookTitle { get; set; }
        public string? description { get; set; }
        public DateTime publishedYear { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int rate { get; set; }
        public string? coverUrl { get; set; }
        public string genre { get; set; }   
        public bool isRead { get; set; }
        public DateTime dateRead { get; set; }

        //Navigation properties
        public int? publisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }

        public override string ToString()
        {
            return $"{bookTitle} {publishedYear}";
        }
    }
}
