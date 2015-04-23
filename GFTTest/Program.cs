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
                    Console.Write("Enter your order: ");
                    string rd = Console.ReadLine();

                    if (!string.IsNullOrEmpty(rd))
                    {
                        if (rd.ToLower().Equals("exit"))
                        {
                            continueReading = false;
                            continue;
                        }

                        Order o = new Order(rd);

                        Console.WriteLine();
                        
                        string output = o.Process();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Output: ");
                        Console.ResetColor();
                        Console.WriteLine(output);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Valid input to time of day: morning, night");
                    Console.WriteLine("Valid input to dish types: 1 (entrée), 2 (side), 3 (drink), 4 (desserts)");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
