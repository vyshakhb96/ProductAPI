using ProductsAPI.Model;

namespace ProductsAPI.DataManager
{
    public interface IProductStorageManager
    {
        bool Add(ProductDetails product);
        ProductDetails GetProduct(int Id);
        List<ProductListItem> GetAll();
        bool Delete(int Id);

    }
}
