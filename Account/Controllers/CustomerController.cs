using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;


namespace file_upload.solutions
{
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public async Task<ActionResult<object>> UploadFile(IFormFile file)
        {
            long size = file.Length;


            if (file.Length > 0)
            {
                var filePath = Directory.GetCurrentDirectory();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }



            return Ok(new { size });
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {

            var result = new List<object>();

            int count = 0;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Directory.GetCurrentDirectory();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }

                count++;

                result.Add(new { fileSequenceId = count, size = formFile.Length });
            }

            return Ok(result);
        }

    }
}
