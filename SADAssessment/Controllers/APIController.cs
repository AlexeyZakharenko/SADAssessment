using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using SADAssessment.Library;


namespace SADAssessment.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        ILibrary _library = VirtualLibrary.Get();


        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(_library.List());
        }

        [HttpGet("add")]
        [Authorize]
        public IActionResult Add([FromQuery] string author, [FromQuery] string title)
        {
            _library.Add(new Book(author, title));
            return Ok(new
            {
                Message = $"Book {author} / {title} has been added"
            });
        }


        // This is a helper action. It allows you to easily view all the claims of the token.
        [HttpGet("whoami")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}
