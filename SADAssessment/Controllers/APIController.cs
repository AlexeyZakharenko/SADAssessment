using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SADAssessment.Library;


namespace SADAssessment.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // Get library instance to work
        // There is only one point to select library type
        ILibrary _library = VirtualLibrary.Get();


        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(_library.List());
        }

        [HttpGet("claims")]
        [Authorize]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }

        [HttpGet("add")]
        [Authorize("add:book")]
        public IActionResult Add([FromQuery] string author, [FromQuery] string title)
        {
            if (!string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
            {
                _library.Add(new Book(author, title));
                return Ok(new
                {
                    Message = $"Book {author} / {title} has been added"
                });
            }
            else
                return BadRequest(new
                {
                    Message = "Invalid parameters"
                });
        }


        [HttpGet("deleteByAuthor")]
        [Authorize("delete:book")]
        public IActionResult DeleteByAuthor([FromQuery] string author)
        {
            if (!string.IsNullOrWhiteSpace(author))
            {
                foreach (var book in _library.List().Where(b => author.Equals(b.Author)))
                    _library.Remove(book);

                return Ok(new
                {
                    Message = $"Remove all books of {author}"
                });
            }
            else
                return BadRequest(new
                {
                    Message = "Invalid parameters"
                });
        }

    }
}
