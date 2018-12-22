using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BaseApi.Infra.Loggers.QueryLogger
{
    internal class TraceLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new TraceLogger(categoryName);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    internal class TraceLogger : ILogger
    {
        private readonly string categoryName;

        public TraceLogger(string categoryName) => this.categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Trace.WriteLine("---------------------------------- DBCONTEXT LOGGER BEGIN ---------------------------------------------------------------------");
            Trace.WriteLine($"{DateTime.Now.ToString("o")} {logLevel} {eventId.Id} {this.categoryName}");
            Trace.WriteLine(formatter(state, exception));
            Trace.WriteLine("---------------------------------- DBCONTEXT LOGGER ENDS ---------------------------------------------------------------------");
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
