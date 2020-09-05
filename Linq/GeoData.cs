using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Linq
{
    public class GeoData
    {
        static string fileName = "geo.json";
        public static string Data = File.ReadAllText(fileName);

        public JObject GeoJson = JObject.Parse(Data);
    }
}
