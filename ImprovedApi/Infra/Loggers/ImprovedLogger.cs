using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ImprovedApi.Infra.Loggers
{

    internal static class ApplicationLogging
    {
        internal static ILoggerFactory LoggerFactory { get; set; }
        internal static ILogger CreateLogger<T>()
        {
            return LoggerFactory.CreateLogger<T>();
        }

        internal static ILogger CreateLogger(string categoryName)
        {
            return LoggerFactory.CreateLogger(categoryName);
        }
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
            log.LogWarning(JsonConvert.SerializeObject(error, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            log.LogWarning($"------------------------- {title} END -------------------------------");
        }
    }
}
