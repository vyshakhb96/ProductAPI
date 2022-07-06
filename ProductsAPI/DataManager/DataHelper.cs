using ProductsAPI.Model;

namespace ProductsAPI.DataManager
{
    public class DataHelper
    {
        public static List<ProductDetails> products = new List<ProductDetails>();

        public static bool Add(ProductDetails productDetails)
        {
            products.Add(productDetails);
            return true;
        }

        public static ProductDetails GetProduct(string Id)
        {
            ProductDetails product = products.FirstOrDefault(x => x.ID == Id);

            if (product != null)
            {
                return product;
            }
            else
                return null;
        }
        public static List<ProductListItem> GetAll()
        {
            List<ProductListItem> list = products.Select(x => new ProductListItem { Id = x.ID, Name = x.Name }).ToList();
            return list;
        }
        public static bool Delete(string Id)
        {
            products.Remove(GetProduct(Id));
            return true;
        }

    }
}
