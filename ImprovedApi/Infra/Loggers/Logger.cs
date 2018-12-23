using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ImprovedApi.Infra.Loggers
{
    public static class Logger
    {
        public static void Write(string error, string title = "ERROR")
        {
            Debug.WriteLine($"------------------------- {title} BEGIN -------------------------------");
            Debug.WriteLine(error);
            Debug.WriteLine($"------------------------- {title} END -------------------------------");
        }

        public static void Write(object error, string title = "ERROR")
        {
            Debug.WriteLine($"------------------------- {title} BEGIN -------------------------------");
            Debug.WriteLine(JsonConvert.SerializeObject(error));
            Debug.WriteLine($"------------------------- {title} END -------------------------------");
        }
    }
}
