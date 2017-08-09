using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTemplate.Common;
using ProjectTemplate.IBusiness;

namespace ProjectTemplate.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.Info("start");
            InstanceFactory.GetInstance<ITestServer>().Test();
        }
    }
}
