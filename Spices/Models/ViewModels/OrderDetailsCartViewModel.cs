using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models.ViewModels
{
    public class OrderDetailsCartViewModel  //  lecture9  00:18:00
    {
        public List<ShoppingCart> ShoppingCarTSlist { get; set; }    //list of shopping carts
        public OrderHeader orderHeader { get; set; }     //single order

    }
}
