using ProductsAPI.Model;

namespace ProductsAPI.DataManager
{
    public interface IProductStorageManager
    {
        bool Add(ProductDetails product);
        ProductDetails GetProduct(string Id);
        List<ProductListItem> GetAll();
        bool Delete(string Id);

    }
}
