using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdentityServer.AuthorizationProvider.NetIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider.NetIdentity.Tests
{
    [TestClass()]
    public class UsersRepositoryTests
    {
        [TestMethod()]
        public void UsersRepositoryTest()
        {
          var t = new UsersRepository("ProviderContext");
            var result = t.RegisterUser("TestUser", "TestUser").Result;
        }

        [TestMethod()]
        public void RegisterUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}