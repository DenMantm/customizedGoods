using PluralApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralApp.Models
{
    public class EditorModel
    {
        public string[] fonts { get; set; }
        public string[] colours { get; set; }
        public string[] colours_base { get; set; }
        public string itemType { get; set; }
        public string showItem { get; set; }
        public ItemModel itemModel { get; set; }
        public IEnumerable<ItemModel> bestAvalableCups { get; set; }
        public IEnumerable<ItemModel> bestAvalableTshirts { get; set; }
        public IEnumerable<ItemModel> bestAvalableHats { get; set; }
        public IEnumerable<ItemModel> userCreatedItems { get; set; }
        public bool editFlag { get; set; }
    }
}
