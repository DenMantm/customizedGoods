using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedGoods.Entites
{
    public class OrderedItemsModel
    {
        public int itemType { get; set; }
        public string userOrdered { get; set; }
        public DateTime orderDate { get; set; }
        public Boolean isDelivered { get; set; }
        public DateTime timeDelivered { get; set; }
        public ItemModel itemOrdered { get; set; }
    }
}
