using System;
using IdentityServer.AuthorizationProvider;

namespace IdentityServer.Core
{
    public class NlogAdapter : ILogger
    {
        private readonly NLog.ILogger _log;

        public NlogAdapter()
        {
            _log = NLog.LogManager.GetCurrentClassLogger();
        }

        public NlogAdapter(string loggerName)
        {
            _log = NLog.LogManager.GetLogger(loggerName);
        }

        public void Trace(string message)
        {
            _log.Trace(message);
        }

        public void Trace(string message, Exception exception)
        {
            _log.Trace(exception, message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            _log.Debug(exception, message);
        }

        public void Info(string message)
        {
            _log.Debug(message);
        }

        public void Info(string message, Exception exception)
        {
            _log.Debug(exception, message);
        }

        public void Warning(string message)
        {
            _log.Warn(message);
        }

        public void Warning(string message, Exception exception)
        {
            _log.Warn(exception, message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(exception, message);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _log.Fatal(exception, message);
        }
    }
}
