using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharpDemo.Caller.Models;
using RestSharpDemo.WebApi.FakeData;

namespace RestSharpDemo.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _repository;

        public ProductsController()
        {
            _repository = new InMemoryProductRepository();
        }

        // GET api/products
        public IEnumerable<Product> Get()
        {
            return _repository.GetAll();
        }

        // GET api/products/5
        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/products
        public void Post([FromBody]Product value)
        {
            _repository.Create(value);
        }

        // PUT api/products/5
        public void Put(int id, [FromBody]Product value)
        {
            _repository.Update(id, value);
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
