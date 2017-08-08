using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTemplate.IBusiness;
using ProjectTemplate.Model;

namespace ProjectTemplate.Business
{
    public class TestServer:ITestServer
    {
        public void Test()
        {
            DbContextFactory.Instance.Tests.Add(new Test() {Name = "测试"});
        }
    }
}
