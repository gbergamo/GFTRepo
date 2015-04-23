using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFTTest.Business
{
    public interface ITimeOfDayBLL
    {
        bool ValidateTimeOfDay(string inputed);
    }
}
