using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralApp.Entites
{

    public class ItemModel
    {
        //t-shirt, cup, card e.c.t
        
        public int id { get; set; }
        public int id_in_category { get; set; }

        public string item_type { get; set; }
        public double item_price { get; set; }
        public string item_description { get; set; }
        

        public string item_owner { get; set; }
        public string item_color { get; set; }

        //this setting allows to create item visible only by creator
        public bool item_view_allowed { get; set; }

        //this is the model for canvas
        public string item_model_json { get; set; }
        
    }
}
