using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Utilit
{
    public class SD       //  static definition    Lecture7  21:00   
    {

        public const string manageruser = "ManagEr";
        public const string kitchenuser = " kitchEn";
        public const string frontdeskuser = "front dEsk";    //Lecture7  24:00   
        public const string customerenduser = "customEr";



        public const string shoppingcartcount = "shoppingcartcounT";// Lecture8  47:32:00

        public static string ConvertToRawHtml(string source)    // Lecture9  43:15:00
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

    }
}
