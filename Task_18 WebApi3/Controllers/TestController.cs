using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_18_WebApi3.testdb.Models;

namespace Task_18_WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        TestContext db;
        public TestController(TestContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var ts = db.News.ToList();
            return Ok(ts);
        }
    }
}
