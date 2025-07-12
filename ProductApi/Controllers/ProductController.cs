using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")] //make route as api/Product(controllername)
    [ApiController]

    //Controller base- base class for all controller handels http requests ,Used when you don’t return views, just JSON
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new()
        {
            new Product {P_ID=1,P_Name="Mobile",Price=20000,Quantity=20},
            new Product {P_ID=2,P_Name="Laptop",Price=90000,Quantity=10}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);//It’s the correct way in ASP.NET Web API to return successful results
        }

        [HttpGet("{id}")]

        public IActionResult GetId(int id)
        {
            var product = products.FirstOrDefault(P => P.P_ID == id);
            if (product== null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.P_ID = products.Max(p => p.P_ID) + 1;
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public IActionResult Update(int id,Product Uproduct)
        {
            var product = products.FirstOrDefault(P => P.P_ID == id);
            if (product == null)
            {
                return NotFound();
            }
            product.P_Name = Uproduct.P_Name;
            product.Quantity = Uproduct.Quantity;
            product.Price = Uproduct.Price;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(P => P.P_ID == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return Ok("Product deleted successfully");
        }
    }
}
