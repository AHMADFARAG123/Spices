using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models.ViewModels
{
    public class IndexViewModel
    {

        public IEnumerable<Category> CategorieS { get; set; }
        public IEnumerable<Coupon> CouponS { get; set; }
        public IEnumerable<MenItem> MenItemS { get; set; }

    }
}
