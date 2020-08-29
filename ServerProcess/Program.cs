using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Diagnostics.Debugger.Launch();

            FakeTaskManager proc = new FakeTaskManager();

            proc.ConsoleStart(args);

            Console.WriteLine("Starting the loop. Good Luck!");
            while (true)
            {
                int cKey = Console.Read();
                if ((ConsoleKey)cKey == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Console.WriteLine("You made it out of the loop! Congrats");
            proc.ConsoleStop();
        }
    }
}
