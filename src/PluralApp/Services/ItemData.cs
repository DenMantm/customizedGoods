using CustomizedGoods.Entites;
using CustomizedGoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CustomizedGoods.Services
{
    public interface IItemData
    {
        IEnumerable<ItemModel> GetAll();
        string Add(ItemModel item);
        ItemModel GetTshirt(int id);
        List<ItemModel> GetSampleTshirts();
        ItemModel GetCup(int id);
        ItemModel GetHat(int id);
    }

    public class SqlItemData : IItemData{

        private ITemsProjectDbContext _context;
        private int id;

        public SqlItemData(ITemsProjectDbContext context)
        {
            _context = context;
        }

        public string Add(ItemModel item)
        {
            var id = 0;
            if (item.item_type == "t-shirt") {
                //incrementing field
                var fileRecord = (from r in _context.ItemCounters where r.id == 1 select r).Single();
                id = fileRecord.tshirt ++;
                _context.SaveChanges();

            }
            else if(item.item_type == "cup"){
                //incrementing field
                var fileRecord = (from r in _context.ItemCounters where r.id == 1 select r).Single();
                id = fileRecord.cup++;
                _context.SaveChanges();


            }
            else if(item.item_type == "hat"){
                //incrementing field
                var fileRecord = (from r in _context.ItemCounters where r.id == 1 select r).Single();
                id = fileRecord.hat++;
                _context.SaveChanges();

            }

            //assigning id
            item.id_in_category = id;
            //saving item
            _context.Add(item);
            _context.SaveChanges();
            return item.item_type + item.id_in_category;


        }

        public ItemModel GetTshirt(int id)
        {
            var result = (from r in _context.ItemModels where r.item_type == "t-shirt" && r.id_in_category == id select r).Single();

            return result;
        }
        public ItemModel GetCup(int id)
        {
            var result = (from r in _context.ItemModels where r.item_type == "cup" && r.id_in_category == id select r).Single();

            return result;
        }

        public ItemModel GetHat(int id)
        {
            var result = (from r in _context.ItemModels where r.item_type == "hat" && r.id_in_category == id select r).Single();

            return result;
        }


        public List<ItemModel> GetSampleTshirts() {
            //generating random numbers
            List<ItemModel> itemList = new List<ItemModel>();
            var result = (from r in _context.ItemModels where r.item_type == "t-shirt" select r).Max(x => x.id_in_category);

            Random random = new Random();

            //int randomNumber = random.Next(0, max);
            
            for (int n = 0; n < 15; n++) {

                int randomNumber = random.Next(0, result);
                itemList.Add((ItemModel)(from r in _context.ItemModels where r.item_type == "t-shirt" && r.id_in_category == randomNumber select r));

            }

            return itemList;
        }


        public IEnumerable<ItemModel> GetAll()
        {
            return _context.ItemModels;
        }
    }



    //public class InMemoryItemData :IItemData
    //{
    //    static InMemoryItemData()
    //    {


    //        _itemList = new List<ItemModel> {
    //            new ItemModel { id= 1, item_type = "t-shirt"},
    //            new ItemModel { id = 2, item_type = "t-shirt"}
    //        };
    //    }

    //    public IEnumerable<ItemModel> GetAll()
    //    {
    //        return _itemList;
    //    }
    //    public ItemModel GetTshirt(int id)
    //    {

    //        return _itemList.FirstOrDefault(i => i.id == id);
    //    }

    //    public string Add(ItemModel item)
    //    {
            
    //        item.id = _itemList.Max(i => i.id)+1;
    //        _itemList.Add(item);
    //        return item.id;
    //    }

    //    public IEnumerable<ItemModel> GetSampleTshirts()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    static List<ItemModel> _itemList;
    //}
}
