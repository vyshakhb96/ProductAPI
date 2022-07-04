using ProductsAPI.DataManager;
using ProductsAPI.Model;

namespace ProductsAPI.Bussiness
{
    public class ProductBusiness : IProductBusiness
    {
        ProductStorageManager productstorage = new ProductStorageManager();
        public BusinessResponse<bool> AddProduct(ProductDetails product)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            int count = DataHelper.GetAll().Count;
            product.ID = count + 1;
            if (product == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(product.ID);
            if (existingProduct.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product Exists";
                return response;
            }
            response.Response = productstorage.Add(product);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public BusinessResponse<List<ProductListItem>> GetAllProducts()
        {
            BusinessResponse<List<ProductListItem>> response = new BusinessResponse<List<ProductListItem>>();
            List<ProductListItem> products = new List<ProductListItem>();          
            if (DataHelper.GetAll().Count > 0)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Response = productstorage.GetAll();
                return response;
                //return productstorage.GetAll();
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Message = "No Product Exists";
                return response;
            }              
        }

        public BusinessResponse<ProductDetails> GetProductDetails(int Id)
        {
            BusinessResponse<ProductDetails> details = new BusinessResponse<ProductDetails>();
            if (Id == null)
            {
                details.StatusCode = System.Net.HttpStatusCode.BadRequest;
                details.Message = "Id cannot be null";
                return details;
            }
            if (Id != null)
            {
                details.Response = productstorage.GetProduct(Id);
                if (details.Response != null)
                {
                    details.StatusCode = System.Net.HttpStatusCode.OK;
                    details.Message = "Success!";
                    return details;
                }
                else
                {
                    details.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    details.Message = "No product exists!";
                    return details;
                }                  
            }
            else
                return null;
        }

        public BusinessResponse<bool> DeleteProduct(int Id)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            if (Id == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(Id);
            if (existingProduct.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "No Product Exists";
                return response;
            }
            response.Response = productstorage.Delete(Id);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}
