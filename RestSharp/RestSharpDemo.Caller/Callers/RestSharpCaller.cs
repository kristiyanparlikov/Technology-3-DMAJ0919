using System.Collections.Generic;
using System.Net;
using RestSharp;
using RestSharpDemo.Caller.Models;

namespace RestSharpDemo.Caller.Callers
{
    public class RestSharpCaller : ICaller
    {
        private RestClient client;
        public RestSharpCaller(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public List<Product> GetProducts()
        {
            var request = new RestRequest("Products", Method.GET);
            var response = client.Execute<List<Product>>(request);
            return response.Data;
        }

        public void Create(Product product)
        {
            var request = new RestRequest("Products", Method.POST);
            request.AddJsonBody(product);
            client.Execute(request);
        }

        public void Update(int id, Product product)
        {
            var request = new RestRequest("Products/" + id, Method.PUT);
            request.AddJsonBody(product);
            client.Execute(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest("Products/" + id, Method.DELETE);
            client.Execute(request);
        }
    }
}