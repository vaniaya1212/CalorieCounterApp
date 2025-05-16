using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace CalorieCounterApp
{
    public static class Storage
    {
        private static string filePath = "products.json";

        public static void Save(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<Product> Load()
        {
            if (!File.Exists(filePath))
                return new List<Product>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }
    }
}
