using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] U = { 1,2,3 };
            Console.WriteLine("Az univerzum minden eleme páros?");
            for (int i = 0; i < U.Length; i++)
            {
                if (!(U[i]%2==0))
                {
                    Console.WriteLine("Nem igaz");
                    return;


                }
            }
            
            Console.WriteLine("Igaz");
            Console.ReadLine();
        }
    }
}
