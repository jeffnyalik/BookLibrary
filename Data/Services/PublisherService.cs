using BookLibrary.AppContexts;
using BookLibrary.Data.Models;
using BookLibrary.Data.ViewModels;

namespace BookLibrary.Data.Services
{
    public class PublisherService
    {
        private readonly ApplicationDbContext _context;
        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        bookName = n.bookTitle,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.Name).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }
        public void DeletePublisherById(int publisherId)
        {
            var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

       /* public void DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }*/
    }
}
