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
    public class CategoryController : ControllerBase
    {
        CategoryContext context = new CategoryContext();

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete()]
        public IActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            if (values!=null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = context.Categories.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var values = context.Categories.Find(category.ID);
            values.Name = category.Name;
            values.Description = category.Description;
            values.Status = category.Status;
            context.SaveChanges();
            return Ok();

        }
    }
}
