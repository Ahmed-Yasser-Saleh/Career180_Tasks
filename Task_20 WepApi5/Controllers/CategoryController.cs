using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_20_WebApi5.DTO;
using Task_20_WepApi5.Models;

namespace Task_20_WebApi5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ProductContext db;
        public CategoryController(ProductContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var ctg = db.Category.ToList();
            List<CategoryDTO> ctgdto = new List<CategoryDTO>();
            foreach (var p in ctg)
            {
                var cg = new CategoryDTO();
                cg.id = p.id;
                cg.name = p.Name;
                cg.description = p.Description;
                foreach(var item in p.Products)
                {
                    cg.productsName.Add(item.Name);
                }
                ctgdto.Add(cg);
            }
            if (ctgdto.Count == 0)
                return NotFound();
            return Ok(ctgdto);
        }
    }
}

