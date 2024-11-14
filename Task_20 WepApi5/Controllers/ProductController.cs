using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_20_WebApi5.DTO;
using Task_20_WepApi5.Models;
using Task_20_WepApi5.Repository;

namespace Task_20_WebApi5.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        UnitOfwork db;
        public ProductController(UnitOfwork db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var pds = db.pdrproductrepositoryepos.Selectall();
            //var pds = db.Product.ToList(); //select all
            List<ProductDTO> pddto = new List<ProductDTO>();
            foreach (var p in pds)
            {
                var pd = new ProductDTO();
                pd.Id = p.Id;
                pd.Name = p.Name;
                pd.Price = p.Price;
                pd.Description = p.Description;
                pd.CategoryId = p.CategoryId;
                pd.CategoryName = p.category.Name;
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
            var pd = db.pdrproductrepositoryepos.GetById(id);
           // var pd = db.Product.Where(pd => pd.Id == id).FirstOrDefault(); //Getbyid
            if (pd == null)
                return NotFound();
            var pdDto = new ProductDTO
            {
                Id = pd.Id,
                Name = pd.Name,
                Price = pd.Price,
                Description = pd.Description,
                CategoryId = pd.CategoryId,
                CategoryName = pd.category.Name
            };
            return Ok(pdDto);
        }
        [HttpGet("price/{price}")]
        public ActionResult Getbyprice(decimal price)
        {
            var pd = db.pdrproductrepositoryepos.GetByPrice(price);
            //var pd = db.Product.Where(pd => pd.Price == price).FirstOrDefault(); //Getbyprice
            if (pd == null)
                return NotFound();
            var pdDto = new ProductDTO
            {
                Id = pd.Id,
                Name = pd.Name,
                Price = pd.Price,
                Description = pd.Description,
                CategoryId = pd.CategoryId,
                CategoryName = pd.category.Name
            };
            return Ok(pdDto);
        }
        [HttpPost("/Add")]
        public ActionResult Add(Product pd)
        {
            if (pd == null)
                return BadRequest();
            var CategoryExists = db.categoryRepository.CheckId(pd.CategoryId);
            if (!CategoryExists)
            {
                return BadRequest("Category not Found.");
            }
            if (ModelState.IsValid)
            {
                db.pdrproductrepositoryepos.Add(pd);
                db.Save();
                var catg = db.ctgrepos.GetById(pd.CategoryId);
                var pdDto = new ProductDTO
                {
                    Id = pd.Id,
                    Name = pd.Name,
                    Price = pd.Price,
                    Description = pd.Description,
                    image = pd.image,
                    CategoryId = pd.CategoryId,
                    //CategoryName = db.Category.Where(a => a.id == pd.CategoryId).Select(a => a.Name).SingleOrDefault()
                    CategoryName = catg.Name
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
            var CategoryExists = db.categoryRepository.CheckId(pdto.CategoryId);
            if (!CategoryExists)
            {
                return BadRequest("Category not fodbd.");
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", pdto.image.FileName);
            if (!System.IO.File.Exists(path))
            {
                FileStream str = new FileStream(path, FileMode.Append);
                pdto.image.CopyTo(str); //upload photo to folder
            }
            if (ModelState.IsValid)
            {
                var pd = new Product()
                {
                    Id = pdto.Id,
                    Name = pdto.Name,
                    Description = pdto.Description,
                    Price = pdto.Price,
                    image = path,
                    Amount = pdto.Amount,
                    CategoryId = pdto.CategoryId
                };
                db.pdrproductrepositoryepos.Add(pd);
                db.Save();
                return CreatedAtAction("Getbyid", new { id = pdto.Id }, pdto);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pd = db.pdrproductrepositoryepos.GetById(id);
            if (pd == null)
                return NotFound();
            db.pdrproductrepositoryepos.Delete(pd);
            db.Save();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id, Product pd)
        {
            if (pd == null)
                return NotFound();
            if (id != pd.Id)
                return BadRequest();
            db.pdrproductrepositoryepos.Edit(pd);
            db.Save();
            return Ok();
        }
        [HttpPost("/addimage")]
        public IActionResult addimage(int id, IFormFile photo)
        {
            var pd = db.pdrproductrepositoryepos.GetById(id);
            if (pd == null)
                return NotFound();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", photo.FileName);
            pd.image = path;
            db.Save();
            return Ok();
        }
        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var pd = db.pdrproductrepositoryepos.GetById(id);
            if(pd == null)
                return BadRequest($"There is no product with id: {id}");
            var filePath = pd.image;
            if (System.IO.File.Exists(filePath))
            {
                var image = System.IO.File.ReadAllBytes(filePath);
                return File(image, "image/png");
            }
            return BadRequest($"There is no Image for Product with id: {id}");
        }
    }
}
