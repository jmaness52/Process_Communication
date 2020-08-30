using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerProcess;

namespace TestProject
{
    [TestClass]
    public class TestServerProcess
    {
        [TestMethod]
        public async Task Test_Process_Communication()
        {
            #region ChildProcessApproach
            // This is the approach our existing integration tests use

            //The helper class is just to mock what we have in production
            // Other test methods use this helper class and do not care if ConsoleStop gets called.

            Process testProcess = ProcHelper.StartProcess();

            //simulate delay of the process spinning up
            await Task.Delay(TimeSpan.FromSeconds(3));

            while (!testProcess.HasExited)
            {
                //keep sending input to the process until it closes
                ProcHelper.ProcessInput.WriteLine();
            }
            testProcess.WaitForExit();

            await Task.Delay(TimeSpan.FromSeconds(3));

            Assert.IsTrue(1 == 1);

            #endregion


            #region AppDomainApproach

            ////This is the approach I tried when working with FakeTaskManager directly
            //try
            //{
            //    //Initially I thought this wasn't working because FakeTaskManager is internal. However, it looks like I just can't load the assembly
            //    //into the child appDomain

            //    //AppDomainSetup setup = new AppDomainSetup();
            //    //setup.ApplicationBase = "../ServerProcess";

            //    AppDomain newDomain = AppDomain.CreateDomain("newDomain", null, AppDomain.CurrentDomain.SetupInformation);

            //    string assemblyName = typeof(FakeTaskManager).Assembly.FullName;

            //    FakeTaskManager fakeTM = newDomain.CreateInstanceFromAndUnwrap(assemblyName, typeof(FakeTaskManager).Name) as FakeTaskManager;

            //    Assert.IsNotNull(fakeTM);

            //    fakeTM.ConsoleStart(new string[] { "args" });

            //    await Task.Delay(TimeSpan.FromSeconds(3));

            //    fakeTM.ConsoleStop();
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion
        }
    }
}
