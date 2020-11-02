using System.Collections.Generic;
using RestSharpDemo.Caller.Models;

namespace RestSharpDemo.WebApi.FakeData
{
public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product Get(int id);
    void Create(Product product);
    void Update(int id, Product product);
    void Delete(int id);
}
}