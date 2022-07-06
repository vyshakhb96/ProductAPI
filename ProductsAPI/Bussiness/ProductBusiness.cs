using ProductsAPI.DataManager;
using ProductsAPI.Model;

namespace ProductsAPI.Bussiness
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly  IProductStorageManager productstorage;
        public ProductBusiness(IProductStorageManager productStorageManager )
        {
            this.productstorage = productStorageManager;
        }
       
        public BusinessResponse<bool> AddProduct(ProductDetails product)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            int count = DataHelper.GetAll().Count;          
            if (product == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            else
            {
                product.ID = Convert.ToString(count + 1);
                response.Response = productstorage.Add(product);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }

        }

        public BusinessResponse<List<ProductListItem>> GetAllProducts()
        {
            BusinessResponse<List<ProductListItem>> response = new BusinessResponse<List<ProductListItem>>();
            //List<ProductListItem> products = new List<ProductListItem>();
           var products = productstorage.GetAll();
            if (products.Count > 0)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Response = products;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Message = "No Product Exists";
                return response;
            }              
        }

        public BusinessResponse<ProductDetails> GetProductDetails(string Id)
        {
            BusinessResponse<ProductDetails> details = new BusinessResponse<ProductDetails>();
            if (string.IsNullOrEmpty(Id))
            {
                
                details.StatusCode = System.Net.HttpStatusCode.BadRequest;
                details.Message = "Id cannot be null";
                return details;
            }
                       
                details.Response = productstorage.GetProduct(Id);
                if (details.Response != null)
                {
                    details.StatusCode = System.Net.HttpStatusCode.OK;
                    details.Message = "Success!";
                    return details;
                }
                else
                {
                    details.StatusCode = System.Net.HttpStatusCode.NotFound;
                    details.Message = "No product exists!";
                    return details;
                }                  
            
        }

        public BusinessResponse<bool> DeleteProduct(string Id)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            if (Id == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Id cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(Id);
            if (existingProduct.Response == null)
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
