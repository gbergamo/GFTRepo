using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Entities;

namespace GFTTest.Business
{
    public class TimeOfDayBLL : ITimeOfDayBLL
    {
        public bool ValidateTimeOfDay(string inputed)
        {
            TimeOfDay inputedTimeOfDay;
            if (!Enum.TryParse(inputed, false, out inputedTimeOfDay))
                return false;

            return true;
        }
    }
}
