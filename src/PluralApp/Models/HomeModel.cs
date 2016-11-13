using PluralApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralApp.Models
{
    public class HomeModel
    {
        public IEnumerable<ItemModel> bestAvalableCups { get; set; }
        public IEnumerable<ItemModel> bestAvalableTshirts { get; set; }
        public IEnumerable<ItemModel> bestAvalableHats { get; set; }
    }
}
