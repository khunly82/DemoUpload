using DemoUpload.DTO;
using DemoUpload.Form;
using Microsoft.AspNetCore.Mvc;

namespace DemoUpload.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController(IWebHostEnvironment environment, MyContext context) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                ImageUrl = p.ImageUrl,
            }));
        }


        [HttpPost]
        public IActionResult Post([FromForm]AddProductForm form)
        {
            string filename = $"{Guid.NewGuid()}{form.ImageFile.FileName}";
            using Stream stream = new FileStream(
                Path.Combine(environment.WebRootPath, "Images", filename),
                FileMode.Create
            );
            form.ImageFile.CopyTo(stream);

            Product product = new Product
            {
                Nom = form.Nom,
                ImageUrl = "/Images/" + filename,
            };

            context.Add(product);
            context.SaveChanges();

            return NoContent();
        }
    }
}
