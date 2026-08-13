using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkClass02.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // GET: https://localhost:[port]/api/user
    public class UserController : ControllerBase
    {

        [HttpGet("users")]
        public ActionResult GetUsers()
        {
            return Ok(StaticDb.userNames);
        }

        [HttpGet("{userId:int}")]
        public ActionResult <string> GetById(int userId)
        {
            if (userId < 0 || userId >= StaticDb.userNames.Count)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"The user with id {userId} is not found"
                });
            }
            return Ok(new { User = StaticDb.userNames[userId] });
        }
    }
}
