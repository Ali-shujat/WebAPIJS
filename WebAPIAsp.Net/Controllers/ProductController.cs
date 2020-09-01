using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIAsp.Net.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIAsp.Net.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>() {

             new Product
                        {
                            Id= 123,
                            Name= "Lorem Ipsum",
                            Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries",
                            Price=23.34
             },
              new Product
                        {
                            Id= 1234,
                            Name= "Why do we use it?",
                            Description= "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters,",
                            Price=678.0
              },
               new Product
                        {
                            Id= 12345,
                            Name= "Where does it come from?",
                            Description= "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old",
                            Price=56.90
               },

        };
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }


        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var pro = products.Find(p => p.Id == id);
            return pro;
        }


        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var currentProduct = products.Where(p => p.Id == id);
            products = products.Except(currentProduct).ToList();
            products.Add(product);
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prod = products.Where(p => p.Id == id);
            products = products.Except(prod).ToList();

        }
    }
}
