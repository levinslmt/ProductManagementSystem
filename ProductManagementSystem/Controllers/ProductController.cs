using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "New Era Cap",
                Description = "Snapback Cap",
                Quantity = 10,
                Price = 2500
            },
            new Product
            {
                Id = 2,
                Name = "Razer V3 PRO",
                Description = "Gaming Mouse",
                Quantity = 3,
                Price = 4200
            }

        };

        // Get All Products
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return products;
        }

        // Get Single Product
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // Create a Product
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            var newId = products.Max(p => p.Id) + 1;

            product.Id = newId;

            products.Add(product);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product
                );
        }

        // Update a Product
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;

            return product;
        }

        // Delete a Product
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return NoContent();
        }


    }
}
