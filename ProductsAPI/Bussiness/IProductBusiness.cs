using ProductsAPI.Model;

namespace ProductsAPI.Bussiness
{
    public interface IProductBusiness
    {
        BusinessResponse<bool> AddProduct(ProductDetails product);
        BusinessResponse<List<ProductListItem>> GetAllProducts();
        BusinessResponse<ProductDetails> GetProductDetails(int Id);
        BusinessResponse<bool> DeleteProduct(int Id);
    }
}
