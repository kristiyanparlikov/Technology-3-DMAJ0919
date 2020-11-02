using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharpDemo.Caller.Callers;
using RestSharpDemo.Caller.Models;

namespace RestSharpDemo.Caller
{
    class Program
    {
        static void Main(string[] args)
        {

            var caller = new RestSharpCaller("http://localhost:9075/api/");

            var products = caller.GetProducts();

            Console.WriteLine("Start: " + caller.GetType().Name);
            Console.WriteLine("Found {0} products: ", products.Count);
            foreach (var product in products)
            {
                Console.WriteLine("\t{0} (ID:{1}) costs {2:c}", product.Description, product.Id, product.Price);
            }

            Console.WriteLine();
            Console.WriteLine("Adding a product");
            caller.Create(new Product() { Description = "Pancake", Price = 1.25m });

            products = caller.GetProducts();
            Console.WriteLine("Now found {0} products", products.Count);
            Console.WriteLine("Last product is: ");
            var last = products.OrderBy(p => p.Id).Last();
            Console.WriteLine("\t{0} (ID:{1}) costs {2:c}", last.Description, last.Id, last.Price);

            Console.WriteLine();
            Console.WriteLine("Updating the last product");
            last.Description = "Waffle";

            caller.Update(last.Id, last);

            products = caller.GetProducts();
            Console.WriteLine("Now found {0} products", products.Count);
            Console.WriteLine("Last product is: ");
            last = products.OrderBy(p => p.Id).Last();
            Console.WriteLine("\t{0} (ID:{1}) costs {2:c}", last.Description, last.Id, last.Price);

            Console.WriteLine();
            Console.WriteLine("Deleting the last product");

            caller.Delete(last.Id);

            products = caller.GetProducts();
            Console.WriteLine("Now found {0} products: ", products.Count);
            foreach (var product in products)
            {
                Console.WriteLine("\t{0} (ID:{1}) costs {2:c}", product.Description, product.Id, product.Price);
            }

            Console.WriteLine();
            Console.WriteLine();

            //string serialized = JsonConvert.SerializeObject(products);

            //var deserialized = JsonConvert.DeserializeObject<List<Product>>(serialized);

            //Console.WriteLine($"Serialized data:\r\n\r\n {serialized}");

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
