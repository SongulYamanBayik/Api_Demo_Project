using Api_Demo_Project.DAL.Context;
using Api_Demo_Project.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        CategoryContext context = new CategoryContext();

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = context.Products.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = context.Products.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var value = context.Products.Find(product.ID);
            value.Name = product.Name;
            value.Stock = product.Stock;
            value.Status = product.Status;
            context.SaveChanges();
            return Ok();
        }
    }
}
