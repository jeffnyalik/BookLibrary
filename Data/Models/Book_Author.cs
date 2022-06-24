using BookLibrary.Models;

namespace BookLibrary.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public Book Book { get; set; }
        public int authorId { get; set; }
        public Author Author { get; set; }

    }
}
