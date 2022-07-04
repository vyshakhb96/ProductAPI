using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Bussiness;
using ProductsAPI.Model;


namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness productbusiness;
        public ProductController(IProductBusiness productbusiness)
        {
            this.productbusiness = productbusiness;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult AddProduct(ProductDetails product)
        {
            var response = productbusiness.AddProduct(product);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            return StatusCode((int)response.StatusCode, response.Message);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = productbusiness.GetAllProducts();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result.Response);
            }
            else
                return StatusCode((int)result.StatusCode, result.Message);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var singleResult = productbusiness.GetProductDetails(id);
            if (singleResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(singleResult.Response);
            }
            else
                return StatusCode((int)singleResult.StatusCode, singleResult.Message);
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var response = productbusiness.DeleteProduct(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            return StatusCode((int)response.StatusCode, response.Message);
        }
    }
}
