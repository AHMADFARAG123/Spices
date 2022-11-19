using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models.ViewModels
{
    public class SubCategoryAndCategoryViewModel     //lecture3 15  minuts
    {
        public IEnumerable<Category> CategoriesList { get; set; }
        public SubCategory SubCAtegory { get; set; }  // i I mean upr case "000 CA 00000" => SubCAegory
       // public  List<string> SubCaegoriesList { get; set; }          //  وبعد مالغاها عمل رييبيلد  //<==لغاها فى الدرس الثالث الدقيقه 53
        public string  StatusMessage { get; set; }   //lecture3    17:45minuts


    }
}
