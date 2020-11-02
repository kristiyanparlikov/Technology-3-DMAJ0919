using System.Collections.Generic;
using System.Linq;
using RestSharpDemo.Caller.Models;

namespace RestSharpDemo.WebApi.FakeData
{
    public class InMemoryProductRepository : IProductRepository
    {
        public static List<Product> Products = RecreateList();

        private static List<Product> RecreateList()
        {
            return new List<Product>()
            {
                new Product() {Id = 1, Description = "Soup", Price = 0.99m},
                new Product() {Id = 2, Description = "Book", Price = 17.95m},
                new Product() {Id = 3, Description = "Stuffed Animal", Price = 5.00m}
            };
        }

        public InMemoryProductRepository()
        {
            if (!Products.Any())
            {
                Products = RecreateList();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        public void Create(Product product)
        {
            product.Id = Products.Max(x => x.Id + 1);
            Products.Add(product);
        }

        public void Update(int id, Product product)
        {
            var p = Get(id);
            Delete(id);
            product.Id = id;
            Products.Add(product);
        }

        public void Delete(int id)
        {
            var p = Get(id);
            Products.Remove(p);
        }
    }
}