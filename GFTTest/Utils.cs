using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace GFTTest
{
    public class Utils
    {
        /// <summary>
        /// Check duplicated entrys
        /// </summary>
        /// <param name="meal">Meal entered: morning/night</param>
        /// <param name="listTyped">List of dishes</param>
        public static void CheckDuplicated(string meal, List<string> listTyped)
        {
            int count = 0;
            if (meal.Equals("morning"))
            {
                count += listTyped.Count(item => item == "1");
                count += listTyped.Count(item => item == "2");

                if (count > 2)
                    throw new Exception("Error on number of order.");
            }
            else if (meal.Equals("night"))
            {
                count += listTyped.Count(item => item == "1");
                count += listTyped.Count(item => item == "3");
                count += listTyped.Count(item => item == "4");

                if (count > 3)
                    throw new Exception("Error on number of order.");
            }

        }

        /// <summary>
        /// Remove duplicated entrys
        /// </summary>
        /// <param name="output">String to check duplicated</param>
        /// <returns></returns>
        public static string RemoveDuplicated(string output)
        {
            string strOutput = string.Empty;

            List<string> noDuplicates = output.Replace(" ", string.Empty).Split(',').Distinct().ToList();
            foreach (string item in noDuplicates)
            {
                if (!string.IsNullOrEmpty(strOutput))
                    strOutput += ", ";

                strOutput += item;
            }

            return strOutput;
        }

        /// <summary>
        /// Get string typed ans convert to list to manipulate
        /// </summary>
        /// <param name="typed">string that user entered</param>
        /// <returns></returns>
        public static List<string> GetWordTypedList(string typed)
        {
            List<string> wordsTyped = typed.Split(',').ToList();
            return wordsTyped.ConvertAll(word => word.ToLower().Trim());
        }
    }
}
