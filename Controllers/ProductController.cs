using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SouqAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace SouqAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly SouqEntity context;

        public ProductController(SouqEntity context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Product> productlist = context.Products.Include(c=>c.category).ToList();
            return Ok(productlist);
        }
        [HttpGet("{id}", Name = "getTwoRoutes")]
        public IActionResult getByID(int id)
        {
            Product pro = context.Products.Include(c => c.category).FirstOrDefault(c => c.id == id);
            if (pro == null)
            {
                return BadRequest("Empty Categories");
            }
            return Ok(pro);
        }

        [HttpGet("Catid")]
        public IActionResult getproductsByCatID([FromQuery] int catID)
        {
            List<Product> ProductList = context.Products.Where(P => P.Category_ID == catID).ToList();
            if (ProductList == null)
            {
                return BadRequest("NO Matches");
            }
            return Ok(ProductList);
        }
        [HttpPost]
        public IActionResult New(Product pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Products.Add(pro);
                    context.SaveChanges();
                    string url = Url.Link("getOneRoutes", new { id = pro.id });
                    return Created(url, pro);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Product pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product proModel =
                        context.Products.FirstOrDefault(d => d.id == id);
                    proModel.Name = pro.Name;
                    proModel.Price = pro.Price;
                    proModel.Quantity = pro.Quantity;
                    proModel.Image = pro.Image;
                    proModel.Category_ID = pro.Category_ID;
                    context.SaveChanges();

                    return StatusCode(200, proModel);// Created(url, dep);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPatch("{id:int}")]
        public IActionResult Editone(int id, Product pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product proModel =
                        context.Products.FirstOrDefault(d => d.id == id);
                    proModel.Name = pro.Name;

                    context.SaveChanges();

                    return StatusCode(200, proModel);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product promodel =
                        context.Products.FirstOrDefault(d => d.id == id);

                    context.Remove(promodel);
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
        [HttpPost, DisableRequestSizeLimit]
        [Route("Images")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}

