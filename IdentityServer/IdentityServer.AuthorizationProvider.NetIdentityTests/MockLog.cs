using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider.NetIdentityTests
{
    class MockLog : ILogger
    {
        public void Trace(string message)
        {
        }

        public void Trace(string message, Exception exception)
        {
        }

        public void Debug(string message)
        {
        }

        public void Debug(string message, Exception exception)
        {
        }

        public void Info(string message)
        {
        }

        public void Info(string message, Exception exception)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(string message, Exception exception)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string message, Exception exception)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(string message, Exception exception)
        {
        }
    }
}
