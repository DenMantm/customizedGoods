using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PluralApp.Entites;
using PluralApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class UploadFileController : Controller
{
    private IHostingEnvironment hostingEnv;

    public UploadFileController(IHostingEnvironment environment)
    {
        hostingEnv = environment;
    }

    [HttpPost]
    public IActionResult UploadFilesAjax()
    {

        //generating uneque name
        Random random = new Random();
        int randomNumber = random.Next(0, 1000);

        var filename = "";
        var tmp = "";
        long size = 0;
        var files = Request.Form.Files;
        foreach (var file in files)
        {
             filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            filename = randomNumber + filename;
            tmp = filename;
            filename = hostingEnv.WebRootPath + $@"\upload\user_images\{filename}";
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        string message = $@"\upload\user_images\" +tmp;
        return Json(message);
    }


}