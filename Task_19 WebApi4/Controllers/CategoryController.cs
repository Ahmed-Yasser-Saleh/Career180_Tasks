using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_19_WebApi4.Context;
using Task_19_WebApi4.DTO;

namespace Task_19_WebApi4.Controllers
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
                cg.name = p.name;
                cg.description = p.description;
                foreach(var item in p.products)
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

