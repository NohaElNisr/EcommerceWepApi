using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SouqAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SouqAPI.DTO;
using Microsoft.AspNetCore.Authorization;

namespace SouqAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly SouqEntity context;

        public CategoryController(SouqEntity context)
        {
            this.context = context;
        }[HttpGet]
        public IActionResult getAll()
        {
            List<Category> categorieslist = context.Categories.Include(p => p.Product).ToList();
            return Ok(categorieslist);
        }
        [HttpGet("{id}",Name ="getOneRoute")]
        public IActionResult getByID(int id)
        {
            Category cat = context.Categories.Include(p => p.Product).FirstOrDefault(c => c.id == id);
            if (cat == null)
            {
                return BadRequest("Empty Categories");
            }
            return Ok(cat);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult getByname(string name)
        {
            Category cat = context.Categories.Include(p => p.Product).FirstOrDefault(c => c.Name.Contains(name));
            if (cat == null)
            {
                return BadRequest("Empty Categories");
            }
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult New(Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Categories.Add(cat);
                    context.SaveChanges();
                    string url = Url.Link("getOneRoute", new { id = cat.id });
                    return Created(url, cat);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category catModel =
                        context.Categories.FirstOrDefault(d => d.id == id);
                    catModel.Name = cat.Name;
                    context.SaveChanges();

                    return StatusCode(200, catModel);// Created(url, dep);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

        [HttpGet("Details/{catid:int}")]
        public IActionResult CatgoryWithDTo(int catid)
        {
            Category catModel =
                context.Categories.Include(d => d.Product).FirstOrDefault(d => d.id == catid);
            CategoreDTO catDto = new CategoreDTO()
            {
                catid=catModel.id,
                catname=catModel.Name
            };
            foreach (var item in catModel.Product)
            {
                ProductDTO prodto = new ProductDTO();
                prodto.id = item.id;
                prodto.Name = item.Name;
                prodto.Price = item.Price;
                prodto.Quantity = item.Quantity;
                prodto.Image = item.Image;
                catDto.product.Add(prodto);
            }

            return Ok(catDto);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category catModel =
                        context.Categories.FirstOrDefault(d => d.id == id);

                    context.Remove(catModel);
                    context.SaveChanges();

                    return StatusCode(200, "Data Deleted");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

    }
}