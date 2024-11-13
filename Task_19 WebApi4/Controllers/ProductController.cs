using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_19_WebApi4.Context;
using Task_19_WebApi4.DTO;
using Task_19_WebApi4.Model;

namespace Task_19_WebApi4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductContext db;
        public ProductController(ProductContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var pds = db.Product.ToList();
            List<ProductDTO> pddto = new List<ProductDTO>();
            foreach (var p in pds)
            {
                var pd = new ProductDTO();
                pd.Id = p.Id;
                pd.Name = p.Name;
                pd.Price = p.Price;
                pd.Description = p.Description;
                pd.CategoryId = p.CategoryId;
                pd.CategoryName = p.category.name;
                //if (!string.IsNullOrEmpty(p.image) && System.IO.File.Exists(p.image))
                //{
                //    byte[] imageBytes = System.IO.File.ReadAllBytes(p.image);
                //    pd.image = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
                //}
                pd.image = p.image;
                pddto.Add(pd);
            }
            if (pddto.Count == 0)
                return NotFound();
            return Ok(pddto);
        }
        [HttpGet("{id:int}")]
        public ActionResult Getbyid(int id)
        {
            var pd = db.Product.Where(pd => pd.Id == id).FirstOrDefault();
            if(pd == null)
                return NotFound();
            var pdDto = new ProductDTO
            {
                Id = pd.Id,
                Name = pd.Name,
                Price = pd.Price,
                Description = pd.Description,
                CategoryId = pd.CategoryId,
                CategoryName = pd.category.name
            };
            return Ok(pdDto);
        }
        [HttpGet("price/{price}")]
        public ActionResult Getbyprice(decimal price)
        {
            var pd = db.Product.Where(pd => pd.Price == price).FirstOrDefault();
            if (pd == null)
                return NotFound();
            var pdDto = new ProductDTO
            {
                Id = pd.Id,
                Name = pd.Name,
                Price = pd.Price,
                Description = pd.Description,
                CategoryId = pd.CategoryId,
                CategoryName = pd.category.name
            };
            return Ok(pdDto);
        }
        [HttpPost("/Add")]
        public ActionResult Add(Product pd)
        {
            if (pd == null)
                return BadRequest();
            var CategoryExists = db.Category.Any(a => a.id == pd.CategoryId);
            if (!CategoryExists)
            {
                return BadRequest("Category not found.");
            }
            if (ModelState.IsValid)
            {
                db.Product.Add(pd);
                db.SaveChanges();
                var pdDto = new ProductDTO
                {
                    Id = pd.Id,
                    Name = pd.Name,
                    Price = pd.Price,
                    Description = pd.Description,
                    image = pd.image,
                    CategoryId = pd.CategoryId,
                    CategoryName = db.Category.Where(a => a.id == pd.CategoryId).Select(a => a.name).SingleOrDefault()
                };

            return CreatedAtAction("Getbyid", new { id = pd.Id }, pdDto);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPost("/AddbyDto")]
        public ActionResult Add(AddProductDTO pdto)
        {
            if (pdto == null)
                return BadRequest();
            var CategoryExists = db.Category.Any(a => a.id == pdto.CategoryId);
            if (!CategoryExists)
            {
                return BadRequest("Category not found.");
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", pdto.image.FileName);
            FileStream str = new FileStream(path, FileMode.Create);
            pdto.image.CopyTo(str); //upload photo to folder
            if (ModelState.IsValid)
            {
                var pd = new Product() {
                    Name = pdto.Name,
                    Description = pdto.Description,
                    Price = pdto.Price,
                    image = path,
                    Amount = pdto.Amount,
                    CategoryId = pdto.CategoryId
                };
               db.Product.Add(pd);
               db.SaveChanges();
               return CreatedAtAction("Getbyid", new { id = pdto.Id }, pdto);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pd = db.Product.Where(pd => pd.Id == id).FirstOrDefault();
            if(pd == null)
                return NotFound();
            db.Product.Remove(pd);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id, Product pd)
        {
            if (pd == null)
                return NotFound();
            if(id != pd.Id)
                return BadRequest();
            db.Product.Update(pd);
            db.SaveChanges();
            return Ok();
        }
        [HttpPost("/addimage")]
        public IActionResult addimage(int id, IFormFile photo)
        {
            var pd = db.Product.Where(p => p.Id  == id).FirstOrDefault();
            if(pd == null)
                return NotFound();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", photo.FileName);
            pd.image = path;
            db.SaveChanges();
            return Ok();      
        }
        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var pd = db.Product.Where(p => p.Id == id).FirstOrDefault();
            var filePath = pd.image;
            if (System.IO.File.Exists(filePath))
            {
                var image = System.IO.File.ReadAllBytes(filePath);
                return File(image, "image/png");
            }
            return NotFound();
        }
    }
}
