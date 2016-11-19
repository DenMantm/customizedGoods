using Microsoft.AspNetCore.Mvc;
using CustomizedGoods.Entites;
using CustomizedGoods.Models;

namespace CustomizedGoods.Controllers 
{
    public class AboutController : Controller
    {

        public IActionResult Index() {



            //returns json result
            return View();
        }
        public IActionResult View()
        {
            var model = new CustomisedGoods { Title = "Customized goods web site" };

            return View("Index",model);
        }

    }
}
