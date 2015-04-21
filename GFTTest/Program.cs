using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFTTest
{
    public class Program
    {
        static void Main(string[] args)
        {   
            bool continueReading = true;
            while (continueReading)
            { 
                try
                {
                    string rd = Console.ReadLine();

                    if (!string.IsNullOrEmpty(rd))
                    {
                        if (rd.ToLower().Equals("exit"))
                        {
                            continueReading = false;
                            continue;
                        }

                        IBusiness biz = new Business();
                        
                        List<string> listInputed = Utils.GetWordTypedList(rd);
                        Console.WriteLine(biz.ApplyRules(listInputed));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valid input to time of day: morning, night");
                    Console.WriteLine("Valid input to dish types: 1 (entrée), 2 (side), 3 (drink), 4 (desserts)");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
