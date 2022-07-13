using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _context;
        public BuggyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            // Try to get an item that does not exist
            var thing = _context.Products.Find(42);

            // This should always be triggered when running the action.
            if (thing == null) return NotFound(new ApiResponse(404));

            // App should not get to this point, but is required to keep controller happy =).
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            // Try to get an item that does not exist
            var thing = _context.Products.Find(42);

            // This will generate an exception AKA server error, since we know thing does not exist.
            var thingToReturn = thing.ToString();

            // App should not get to this point, but is required to keep controller happy =).
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
