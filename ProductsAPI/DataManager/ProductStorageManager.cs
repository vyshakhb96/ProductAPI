using ProductsAPI.Model;

namespace ProductsAPI.DataManager
{
    public class ProductStorageManager : IProductStorageManager
    {
        public bool Add(ProductDetails product)
        {
            return DataHelper.Add(product);
        }

        public List<ProductListItem> GetAll()
        {
            return DataHelper.GetAll();
        }

        public ProductDetails GetProduct(string Id)
        {
            return DataHelper.GetProduct(Id);
        }
        public bool Delete(string Id)
        {
            return DataHelper.Delete(Id);
        }

    }
}
