﻿using ProductsAPI.Model;

namespace ProductsAPI.Bussiness
{
    public interface IProductBusiness
    {
        BusinessResponse<bool> AddProduct(ProductDetails product);
        BusinessResponse<List<ProductListItem>> GetAllProducts();
        BusinessResponse<ProductDetails> GetProductDetails(string Id);
        BusinessResponse<bool> DeleteProduct(string Id);
    }
}
