using System;
using System.Collections.Generic;
using IdentityServer.AuthorizationProvider.TestProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer.AuthorizationProvider.TestProviderTests
{
    [TestClass()]
    public class TestProviderTests
    {
      

        [TestMethod()]
        public void AuthorizeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllRightsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            string userName = Guid.NewGuid().ToString();

            var parameters = new Dictionary<string, string>() { {"ConnectionString", @"Data Source=C:\Temp\testBase2.db" } };
            var provider = new Provider();
            provider.Initialize(parameters, null);
            var registerResult = provider.Register(userName, userName).Result;
            var registerResult2 = provider.Register(userName, userName).Result;
            var authresult = provider.Authorize(userName, userName).Result;

        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}