using BookLibrary.AppContexts;
using BookLibrary.Data.ViewModels;
using BookLibrary.Models;

namespace BookLibrary.Data.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;
        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name,
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM getAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                Name = n.Name,
                BookTitles = n.Book_Authors.Select(n => n.Book.bookTitle).ToList()
            }).FirstOrDefault();
            return _author;
        }

    }
}
