using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ImprovedApi.Infra.Loggers
{

    internal static class ApplicationLogging
    {
        internal static ILoggerFactory LoggerFactory { get; set; }
        internal static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);

    }

    public static class ImprovedLogger
    {
        private static ILogger log = ApplicationLogging.CreateLogger("ImprovedApi.Log");
        public static void Write(string error, string title = "ERROR")
        {

            log.LogWarning($"------------------------- {title} BEGIN -------------------------------");
            log.LogWarning(error);
            log.LogWarning($"------------------------- {title} END -------------------------------");
        }

        public static void Write(object error, string title = "ERROR")
        {
            log.LogWarning($"------------------------- {title} BEGIN -------------------------------");
            log.LogWarning(JsonConvert.SerializeObject(error));
            log.LogWarning($"------------------------- {title} END -------------------------------");
        }
    }
}
