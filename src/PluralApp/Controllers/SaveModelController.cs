using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PluralApp.Entites;
using PluralApp.Models;
using PluralApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class SaveModelController : Controller
{
    private IHostingEnvironment hostingEnv;
    private IItemData _itemData;

    public SaveModelController(IHostingEnvironment environment, IItemData itemData)
    {
        hostingEnv = environment;
        _itemData = itemData;
    }

    [HttpPost]
    public IActionResult SaveModel() {


        //storing object
        ItemModel m = new ItemModel();
        m.item_color = Request.Form["item_color"];
        m.item_type = Request.Form["item_type"];
        m.item_view_allowed = true;
        m.item_model_json = Request.Form["item_model_json"];

        var fileName = _itemData.Add(m);

        //storing image
        string filename = fileName + ".png";
        filename = hostingEnv.WebRootPath + $@"\upload\models\{filename}";
        string image = Request.Form["byteImage"];
        // if would use other database type, i would store image in database
        var bytes = Convert.FromBase64String(image);
        using (var imageFile = new FileStream(filename, FileMode.Create))
        {
            imageFile.Write(bytes, 0, bytes.Length);
            imageFile.Flush();
        }

        // return new ObjectResult(m);

        // string message = $@"\upload\user_images\" + tmp;



        return Json(m);
    }


}