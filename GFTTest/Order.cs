using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Business;
using GFTTest.Entities;
using GFTTest.Helpers;

namespace GFTTest
{
    public class Order
    {
        private string _inputed; 
        public Order(string inputedString)
        {
            _inputed = inputedString;
        }

        public string Process()
        {
            if (string.IsNullOrEmpty(_inputed))
                throw new Exception("Invalid data.");

            IDishBLL dishBusiness = new DishBLL();

            TimeOfDay inputedTimeOfDay = Parser.GetTimeOfDay(_inputed).ToTimeOfDay();
            List<string> inputedDishes = Parser.GetDishes(_inputed).ToDishName(inputedTimeOfDay);
            List<Dish> handledList = dishBusiness.CheckDuplicated(inputedTimeOfDay, inputedDishes);

            return handledList.ToOutputString(inputedTimeOfDay);
        }
    }
}
