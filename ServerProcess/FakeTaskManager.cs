using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProcess
{
    //I can't make this class public in production

    //originally looked like this - added inheritance to MarshalByRefObject and changed to public, still cant create instance in new app domain
    //internal class FakeTaskManager
    public class FakeTaskManager : MarshalByRefObject
    {
        
        public FakeTaskManager()
        {

        }

        public void ConsoleStart(string[] args)
        {
            //In the real app this will spin up many leader and worker threads. Each leader and worker gets 
            //logged into a CurrentUsers table in the Database
            Console.WriteLine($"There were {args.Length} passed!");
        }


        public void ConsoleStop()
        {
            //This will stop all the leaders and workers and
            //remove the entries from the CurrentUsers table in the Database

            //At some point down the chain I think this is setting API.SecurityManager = null
            //For this reason, I think it needs to be run in its own appdomain?
            Console.WriteLine("Simulating Stopped Console");
        }
    }
}
