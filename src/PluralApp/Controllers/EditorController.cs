using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PluralApp.Models;
using PluralApp.Entites;
using PluralApp.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PluralApp.Controllers
{
    public class EditorController : Controller
    {
        private IItemData _itemData;

        string[] fonts;
        string[] colours;
        string[] colours_base;

        public EditorController(IItemData itemData)
        {
            _itemData = itemData;

            fonts = new string[] {"Georgia, serif","'Palatino Linotype', 'Book Antiqua', Palatino, serif"
                ,"'Times New Roman', Times, serif","Arial, Helvetica, sans-serif","'Arial Black', Gadget, sans-serif",
                 "'Comic Sans MS', cursive, sans-serif"};

            colours = new string[] { "black", "white", "red", "gray", "purple", "yellow", "pink", "orange", "blue" };

            colours_base = new string[] { "#00aff0", "#60a917", "#fa6800", "#ce352c", "#16499a", "#f0a30a", "#dc4fad", "white" };
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            //here wee need to get item from the database with the id of ->

            EditorModel model = new EditorModel();


            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);




            return View(model);
        }




        //tshirts


        public IActionResult Tshirt()
        {
            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "t-shirt",
                editFlag = false
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);


            return View(model);
        }

        public IActionResult viewTshirt(int id) {

            //here wee need to get item from the database with the id of ->
            ItemModel itemModel = _itemData.GetTshirt(id);
          

            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "t-shirt",
                itemModel = itemModel,
                editFlag = true
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);

                return View("Tshirt",model);
            
            
        }


        //cups



        public IActionResult Cup(){
            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "cup"
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);


            return View(model);

        }
        public IActionResult viewCup(int id)
        {

            //here wee need to get item from the database with the id of ->
            ItemModel itemModel = _itemData.GetCup(id);


            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "cup",
                itemModel = itemModel,
                editFlag = true
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);

            return View("cup", model);


        }



        //Hat




        public IActionResult Hat()
        {
            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "hat"
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);


            return View(model);

        }
        public IActionResult viewHat(int id)
        {

            //here wee need to get item from the database with the id of ->
            ItemModel itemModel = _itemData.GetHat(id);


            EditorModel model = new EditorModel
            {
                fonts = fonts,
                colours = colours,
                colours_base = colours_base,
                itemType = "hat",
                itemModel = itemModel,
                editFlag = true
            };

            model.bestAvalableTshirts = (from r in _itemData.GetAll() where r.item_type == "t-shirt" select r);
            model.bestAvalableCups = (from r in _itemData.GetAll() where r.item_type == "cup" select r);
            model.bestAvalableHats = (from r in _itemData.GetAll() where r.item_type == "hat" select r);

            return View("hat", model);


        }





    }
}
