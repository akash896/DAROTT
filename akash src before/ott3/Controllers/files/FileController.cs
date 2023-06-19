﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ott3.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.files
{
    [Route("file/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        AppDbContext db = new AppDbContext();
        // GET: file/<FileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET file/<FileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BasicFile f = db.Files.Find(id);
            if (f == null)
            {
                return NotFound();
            }
            var stream = System.IO.File.OpenRead($"E:/dynamic/ott/templateApp/ott2/upload/{id}");

             // returns a NotFoundResult with Status404NotFound response.

            return File(stream, "application/octet-stream", f.name);
        }

        // POST file/<FileController>
        [HttpPost]
        public BasicFile Post(IFormFile file)
        {
            BasicFile p = new BasicFile();
            p.url = "/file/File/0";
            p.status = "error";
            p.response = "unknown";
            try
            {
                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    AppDbContext db = new AppDbContext();
                    // p.id = 1;

                    p.name = file.FileName;
                    p.url = file.FileName;
                    p.ext = System.IO.Path.GetExtension(file.FileName);
                    p.size = file.Length;

                    db.Files.Add(p);
                    db.SaveChanges();
                    int id = p.uid;
                    using (FileStream fileSave = new FileStream($"E:/dynamic/ott/templateApp/ott2/upload/{id}", FileMode.Create, FileAccess.Write))
                    {
                        target.WriteTo(fileSave);
                    }
                    // System.IO.File.WriteAllBytes($"E:/dynamic/ott/templateApp/ott2/upload/{id}", target);
                    p.url = $"/file/File/{id}";
                    p.status = "done";
                    p.response = "ok";
                }
            } catch (Exception ex)
            {
                p.response = ex.Message;
            }
            return p;
        }

        // PUT file/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE file/<FileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}