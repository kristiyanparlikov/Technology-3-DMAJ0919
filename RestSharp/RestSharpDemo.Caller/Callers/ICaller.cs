using System.Collections.Generic;
using RestSharpDemo.Caller.Models;

namespace RestSharpDemo.Caller.Callers
{
    public interface ICaller
    {
        List<Product> GetProducts();
        void Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);
    }
}