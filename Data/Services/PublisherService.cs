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
    }
}
