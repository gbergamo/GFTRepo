using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Business;

namespace GFTTest.Helpers
{
    public class Parser
    {
        public static string GetTimeOfDay(string input)
        {
            string currentTimeOfDay =  input.Split(',').First().ToLower();
            ITimeOfDayBLL timeOfDayBusiness = new TimeOfDayBLL();
            if (!timeOfDayBusiness.ValidateTimeOfDay(currentTimeOfDay))
                throw new Exception("Invalid time of day.");

            return currentTimeOfDay;
        }

        public static List<string> GetDishes(string input)
        {
            List<string> dishesList = input.Split(',').Skip(1).OrderBy(d => d).ToList();

            if (dishesList == null || dishesList.Count == 0)
                throw new Exception("Please, select a dish.");

            return dishesList;
        }
    }
}
