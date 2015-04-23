using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Entities;

namespace GFTTest.Business
{
    public class DishBLL : IDishBLL
    {
        /// <summary>
        /// Convert inputed dish code to dish name
        /// </summary>
        /// <param name="meal">time of day inputed</param>
        /// <param name="code">dish code inputed</param>
        /// <returns>Name of the dish</returns>
        public string ConvertCodeToDish(TimeOfDay meal, string code)
        {
            string strReturn = string.Empty;

            int dishCode = 0;
            if (!int.TryParse(code, out dishCode))
                throw new Exception("Invalid dish code.");
            
            switch (meal)
            {
                case TimeOfDay.morning:
                    return GetMorningDish(dishCode);
                case TimeOfDay.night:
                    return GetNightDish(dishCode);
                default:
                    return "error";
            }
        }

        private string GetMorningDish(int code)
        {
            switch (code)
            {
                case 1:
                    return "eggs";
                case 2:
                    return "toast";
                case 3:
                    return "coffee";
                default:
                    return "error";
            }
        }

        private string GetNightDish(int code)
        {
            switch (code)
            {
                case 1:
                    return "steak";
                case 2:
                    return "potato";
                case 3:
                    return "wine";
                case 4:
                    return "cake";
                default:
                    return "error";
            }
        }

        /// <summary>
        /// Check if has a duplicated dish on list. 
        /// Make sure the dishes are ordered.
        /// </summary>
        /// <param name="timeOfDay"></param>
        /// <param name="dishesInputed"></param>
        /// <returns></returns>
        public List<Dish> CheckDuplicated(TimeOfDay timeOfDay, List<string> dishesInputed)
        {
            List<Dish> list = new List<Dish>();
            foreach (string item in dishesInputed)
            {
                int HasInList = (from d in list where d.name == item select d).Count();
                if (HasInList > 0)
                    continue;

                Dish current = new Dish();
                int q = (from dish in dishesInputed where dish == item select dish).Count();
                current.name = item;
                current.count = q;

                if (!AllowDuplicated(timeOfDay, current))
                    throw new Exception(string.Format("It's not allowed to order duplicated {0}", current.name));

                list.Add(current);
            }

            return list;
        }

        private bool AllowDuplicated(TimeOfDay timeOfDay, Dish dish)
        {
            if (dish.count == 1)
                return true;

            if (timeOfDay == TimeOfDay.morning && dish.count > 1 && dish.name.Equals("coffee"))
                return true;

            if (timeOfDay == TimeOfDay.night && dish.count > 1 && dish.name.Equals("potato"))
                return true;

            return false;
        }
    }
}
