using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFTTest.Entities;

namespace GFTTest.Business
{
    public interface IDishBLL
    {
        string ConvertCodeToDish(TimeOfDay meal, string code);

        List<Dish> CheckDuplicated(TimeOfDay timeOfDay, List<string> dishesInputed);
    }
}
