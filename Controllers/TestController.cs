using Microsoft.AspNetCore.Mvc;

namespace asp_net_course_udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult TestFunction(){
            return Ok("Test msg");
        }
    }
}