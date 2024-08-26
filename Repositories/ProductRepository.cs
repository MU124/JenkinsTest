using CURD.Models;
using System.Collections.Generic;
using System.Linq;

namespace CURD.Repositories
{
    public class ProductRepository
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0M },
            new Product { Id = 2, Name = "Product 2", Price = 20.0M },
            new Product { Id = 3, Name = "Product 3", Price = 30.0M },
            new Product { Id = 4, Name = "Product 4", Price = 30.0M },
            new Product { Id = 5, Name = "Product 5", Price = 30.0M }
        };


        public static IEnumerable<Product> GetAll() => Products;

        public static Product Get(int id) => Products.FirstOrDefault(p => p.Id == id);

        public static void Add(Product product) => Products.Add(product);

        public static void Update(Product product)
        {
            var index = Products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                Products[index] = product;
            }
        }

        public static void Delete(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }

    }
}
