using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Task_16_WebApi.Model;

namespace Task_16_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        List<Course> courses = new List<Course>
        {
            new Course(1, "Mathematics", 40, "Active"),
            new Course(2, "Physics", 35, "Inactive"),
            new Course(3, "Chemistry", 30, "Active")
        };
        /* [
           {
               "id": 1,
               "name": "Mathematics",
               "duration": 40,
               "status": "Active"
           },
           {
               "id": 2,
               "name": "Physics",
               "duration": 35,
               "status": "Inactive"
           },
           {
               "id": 3,
               "name": "Chemistry",
               "duration": 30,
               "status": "Active"
           }
          ]
         */
        [HttpGet]
        public List<Course> GetAll() {
        return courses;
        }
        [HttpGet("{id}")]
        public Course Getbyid(int id) {
        var cs = courses.Where(cs => cs.Id == id).FirstOrDefault();
            if (cs != null)
                return cs;
            return new Course(0, "null", 0, "inactive");
        }
    }
}
