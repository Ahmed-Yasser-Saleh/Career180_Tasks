using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_17_WepApi2.Models;

namespace Task_17_WepApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        LearnitTaskContext db = new LearnitTaskContext();
        [HttpGet]
        public IActionResult Getall()
        {
            var mynews = db.News.Include(n => n.Author).Select(n => new
            {
                n.Id,
                n.Title,
                n.Description,
                n.Brief,
                datetime = n.Dt,
                Categoryid = n.CtgId,
                n.AuthorId,
                AuthorName = n.Author.Name
            }).ToList();
            if (mynews.Count > 0)
                return Ok(mynews);
            else
                return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id) {
            var mynew = db.News.Include(n => n.Author).Select(n => new
            {
                n.Id,
                n.Title,
                n.Description,
                n.Brief,
                datetime = n.Dt,
                Categoryid = n.CtgId,
                n.AuthorId,
                AuthorName = n.Author.Name
            }).Where(n => n.Id == id).FirstOrDefault();
            if (mynew == null) return NotFound();
            return Ok(mynew);
        }
        [HttpGet("/news/{title}")]
        public IActionResult Getbytitle(string title)
        {
            var mynew = db.News.Include(n => n.Author).Select(n => new
            {
                n.Id,
                n.Title,
                n.Description,
                n.Brief,
                datetime = n.Dt,
                Categoryid = n.CtgId,
                n.AuthorId,
                AuthorName = n.Author.Name
            }).Where(n => n.Title == title).FirstOrDefault();
            if (mynew == null) return NotFound();
            return Ok(mynew);
        }
        [HttpGet("/news/Authors/{author}")]
        public IActionResult GetbyAuthor(string Author)
        {
            var mynew = db.News.Include(n => n.Author).Select(n => new
            {
                n.Id,
                n.Title,
                n.Description,
                n.Brief,
                datetime = n.Dt,
                Categoryid = n.CtgId,
                n.AuthorId,
                AuthorName = n.Author.Name
            }).Where(n => n.AuthorName == Author).FirstOrDefault();
            if (mynew == null) return NotFound();
            return Ok(mynew);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mynew = db.News.Where(n => n.Id == id).FirstOrDefault();
            if (mynew == null) return NotFound();
            db.News.Remove(mynew);
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult add(News n)
        {
            var authorExists = db.Authors.Any(a => a.Id == n.AuthorId);
            if (!authorExists)
            {
                return BadRequest("Author not found.");
            }
            var categoryExists = db.Categories.Any(c => c.Id == n.CtgId);
            if (!categoryExists)
            {
                return BadRequest("Category not found.");
            }
            db.News.Add(n);
            db.SaveChanges();
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, News n) {
            var mynew = db.News.Where(n => n.Id  == id).FirstOrDefault();
            if (mynew == null) return NotFound();
            mynew.Title = n.Title;
            mynew.Description = n.Description;
            mynew.Brief = n.Brief;
            mynew.Dt = n.Dt;
            mynew.Ctg = n.Ctg;
            mynew.AuthorId = n.AuthorId;
            db.News.Update(mynew);
            db.SaveChanges();
            return NoContent();
        }
       
    }
}
