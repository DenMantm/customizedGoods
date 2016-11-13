using Microsoft.AspNetCore.Mvc;
using PluralApp.Services;
using PluralApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralApp.ViewModels;

namespace PluralApp.Controllers
{
    public class HomeController : Controller
    {
        private IItemData _itemData;

        public HomeController(IItemData itemData)
        {
            _itemData = itemData;
        }
        public IActionResult Index() {

            HomeModel model = new HomeModel();
            
            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);


            return View(model);
        }
    }
}
