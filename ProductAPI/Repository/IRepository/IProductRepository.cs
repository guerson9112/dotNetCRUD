using ProductAPI.Models;
using System;
using System.Collections.Generic;

namespace ProductAPI.Repository.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProduct(int id);

        bool ProductExists(string name);

        bool ProductExists(int id);

        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);

        bool Save();

    }
}
