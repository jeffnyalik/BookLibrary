using BookLibrary.AppContexts;
using BookLibrary.Data.Services;
using BookLibrary.Data.ViewModels;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        //POST api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

        //GET books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        // GET  Single a Book
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.getBookById(id);
            return Ok(book);
        }

        // UPDATE a book
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BookVM book)
        {
            var updatedBook = _bookService.UpdateBookbyId(id, book);
            return Ok(updatedBook);
        }

        // DELETE A BOOK
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }

    }
}
