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
    public class AuthorsController : Controller
    {
        private readonly AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult AddAuthors([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response =  _authorService.getAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
