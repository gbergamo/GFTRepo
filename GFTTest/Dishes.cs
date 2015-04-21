using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFTTest
{
    public class Dishes
    {
        /// <summary>
        /// Convert dish code to dish name
        /// </summary>
        /// <param name="meal">Meal entered: morning/night</param>
        /// <param name="code">Dish code</param>
        /// <returns></returns>
        public static string ConvertCodeToDish(string meal, string code)
        {
            string strReturn = string.Empty;

            switch (code)
            {
                case "1":
                    strReturn = meal == "morning" ? "eggs" : "steak";
                    break;
                case "2":
                    strReturn = meal == "morning" ? "toast" : "potato";
                    break;
                case "3":
                    strReturn = meal == "morning" ? "coffee" : "wine";
                    break;
                case "4":
                    strReturn = meal == "morning" ? "N/A" : "cake";
                    break;
                default:
                    strReturn = "error";
                    //throw new Exception("You entered a invalid dish code.");
                    break;
            }

            return strReturn;
        }

        public static List<string> OrderedDish(List<string> inputed)
        {
            return inputed.OrderBy(q => q).ToList();
        }
    }
}
