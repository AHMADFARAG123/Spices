using Spices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models.ViewModels
{
    public class MenuItemViewModel                 //lecture4  23:00minuts
    {

        public MenItem MeNUitem { get; set; }  // انشئت بروبرتى من المينيو ايتم موديل وسميتها مينيو ايتم
        public IEnumerable<Category>categorieslisT { get; set; }
        public IEnumerable<SubCategory> suBcategorieslisT{ get; set; }//lecture4  25:00minuts


    }
}
