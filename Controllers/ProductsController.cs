using CURD.Models;
using CURD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CURD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return ProductRepository.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = ProductRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }



        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            ProductRepository.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = ProductRepository.Get(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            ProductRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = ProductRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductRepository.Delete(id);
            return NoContent();
        }

    }
}
