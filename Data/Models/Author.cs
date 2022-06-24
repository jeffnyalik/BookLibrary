using BookLibrary.Data.Models;

namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<Book>? Books { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        //Navigation properties
        public List<Book_Author> Book_Authors { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
