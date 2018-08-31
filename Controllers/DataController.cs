using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using janrain.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;

namespace janrain.Controllers
{
    public class DataController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = $"{Directory.GetCurrentDirectory()}\\{DateTime.Now.Ticks}.txt";

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                 while ((line = reader.ReadLine()) != null) 
                {
                     var pp=line;
                }
               
              
            }

          
            return Ok(new { count = files.Count, size, filePath });
        }

        public IActionResult test()
        {
            return Ok("aaa");

        }

    }
}
