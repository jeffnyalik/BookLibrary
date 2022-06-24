using BookLibrary.AppContexts;
using BookLibrary.Data.Models;
using BookLibrary.Data.ViewModels;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Services
{
    public class BookService
    {
        private ApplicationDbContext _context;
        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                bookTitle = book.bookTitle,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.dateRead,
                rate = book.rate,
                genre = book.genre,
                coverUrl = book.coverUrl,
                publishedYear = book.publishedYear,
                publisherId  = book.publisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    bookId = _book.Id,
                    authorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book>GetAllBooks()
        {
            return _context.Books.ToList();
       
        }
        public BookWithAuthorsVM getBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n =>n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                bookTitle = book.bookTitle,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.dateRead,
                rate = book.rate,
                genre = book.genre,
                coverUrl = book.coverUrl,
                publishedYear = book.publishedYear,
                publisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.Name).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        public Book UpdateBookbyId(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.bookTitle = book.bookTitle;
                _book.description = book.description;
                _book.isRead = book.isRead;
                _book.dateRead = book.dateRead;
                _book.rate = book.rate;
                _book.genre = book.genre;
                _book.coverUrl = book.coverUrl;
            }

            _context.SaveChanges();
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
