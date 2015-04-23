using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Business;
using GFTTest.Entities;

namespace GFTTest.Helpers
{
    public static class Extension
    {
        public static TimeOfDay ToTimeOfDay(this string inputed)
        {
            TimeOfDay current;
            Enum.TryParse(inputed, true, out current);
            return current;
        }

        public static List<string> ToDishName(this List<string> inputed, TimeOfDay timeOfDay)
        {
            IDishBLL dishBusiness = new DishBLL();
            List<string> namedDish = new List<string>();

            foreach (string item in inputed)
            {
                namedDish.Add(dishBusiness.ConvertCodeToDish(timeOfDay, item));
            }

            return namedDish;
        }

        public static string ToOutputString(this List<Dish> inputed, TimeOfDay timeOfDay)
        {
            List<string> output = new List<string>();
            output.Add(timeOfDay.ToString());

            inputed.ForEach(d =>
            {
                output.Add(String.Format("{0}{1}", d.name, (d.count > 1 ? String.Format("(x{0})", d.count) : "")));
            });

            
            return string.Join(", ", output);
        }
    }
}
