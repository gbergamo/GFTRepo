using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFTTest
{
    public interface IBusiness
    {
        string ApplyRules(List<string> inputed);
        bool ValidateTimeOfDay(string inputed);
        bool ValidateOrder(List<string> inputed);
    }
}
