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
        public static string ConvertCodeToDish(TimeOfDay meal, string code)
        {
            string strReturn = string.Empty;

            switch (meal)
            {
                case TimeOfDay.morning:
                    return GetMorningDish(code);
                case TimeOfDay.night:
                    return GetNightDish(code);
                default:
                    return "error";
            }
        }

        private static string GetMorningDish(string code)
        {
            switch (code)
            {
                case "1":
                    return "eggs";
                case "2":
                    return "toast";
                case "3":
                    return "coffee";
                default:
                    return "error";
            }
        }

        private static string GetNightDish(string code)
        {
            switch (code)
            {
                case "1":
                    return "steak";
                case "2":
                    return "potato";
                case "3":
                    return "wine";
                case "4":
                    return "cake";
                default:
                    return "error";
            }
        }

        public static List<string> OrderedDish(List<string> inputed)
        {
            return inputed.OrderBy(q => q).ToList();
        }
    }
}
