using BookLibrary.Data.Services;
using BookLibrary.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService publisherService;
        public PublisherController(PublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            publisherService.AddPublisher(publisher);
            return Ok(publisher);
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var response = publisherService.GetPublisherData(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            publisherService.DeletePublisherById(id);
            return Ok();
        }
    }
}
