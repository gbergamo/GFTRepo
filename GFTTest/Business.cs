using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFTTest
{
    public class Business : IBusiness
    {
        public static List<string> possibleTimeOfDay = new List<string>() { "morning", "night" };

        /// <summary>
        /// Apply rules described in document
        /// </summary>
        /// <param name="inputed">list of params inserted</param>
        /// <returns></returns>
        public string ApplyRules(List<string> inputed)
        {
            Utils.CheckDuplicated(inputed.First(), inputed);

            string meal = inputed.First();

            if (!ValidateTimeOfDay(meal))
                throw new Exception("Invalid time of day.");

            // Rule: There is no dessert for morning meals 
            if (!ValidateOrder(inputed))
                throw new Exception("There's no dessert for morning!");

            // Remove first item (time of day)
            inputed.RemoveAt(0);
            inputed = Dishes.OrderedDish(inputed);

            string output = string.Empty;

            List<string> outputList = new List<string>();

            foreach (string item in inputed)
            {
                outputList.Add(Dishes.ConvertCodeToDish(meal, item));
            }

            foreach (string outputItem in outputList)
            {
                int i = outputList.Count(item => item == outputItem);

                if (!string.IsNullOrEmpty(output))
                    output += ", ";

                if (i == 1)
                    output += outputItem;
                else
                    output += outputItem + " (x" + i.ToString() + ")";
            }

            output = Utils.RemoveDuplicated(output);

            return output;
        }

        public bool ValidateTimeOfDay(string inputed)
        {
            if (!possibleTimeOfDay.Contains(inputed))
                return false;
            return true;
        }

        public bool ValidateOrder(List<string> inputed)
        {
            if (inputed.Contains("4") && inputed.First().Equals("morning"))
                return false;

            return true;
        }
        
    }
}
