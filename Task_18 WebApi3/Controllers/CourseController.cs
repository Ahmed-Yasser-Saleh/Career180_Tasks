using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_18_WebApi3.Models.Course;
namespace Task_18_WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseContext db;
        public CourseController(CourseContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var cs = db.Courses.ToList();
            if (cs.Count == 0)
                return NotFound();
            return Ok(cs);
        }
        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
            var cs = db.Courses.Where(cs => cs.ID == id).FirstOrDefault();
            if (cs == null) return NotFound();
            return Ok(cs);
        }
        [HttpGet("/Course/{name}")]
        public IActionResult Getbyname(string name)
        {
            var cs = db.Courses.Where(cs => cs.Name == name).FirstOrDefault();
            if (cs == null) return NotFound();
            return Ok(cs);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Course course)
        {
            if (course == null) return NotFound();
            if(id != course.ID) return BadRequest();
            db.Update(course);
            db.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (course == null) return BadRequest();
            if(ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return CreatedAtAction("Getbyid",new {id = course.ID }, course);   // ("Getbyid",,course);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cs = db.Courses.Where(cs => cs.ID == id).FirstOrDefault();
            if (cs == null) return NotFound();
            db.Remove(cs);
            db.SaveChanges();
            return Ok(cs);
        }
    }
}
