using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Taskly.Dal
{
    public class JsonRepository
    {
        private static string GetJsonFilePath<T>()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var res = Path.GetDirectoryName(path);
            var fileName = String.Format("{0}\\{1}", res, typeof(T).Name + ".json");

            fileName = fileName.Replace("[]", "s").Replace("[", "").Replace("]", "");

            return fileName;
        }

        public static IReadOnlyCollection<T> Get<T>()
        {
            var filePath = GetJsonFilePath<T[]>();
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            return JsonConvert.DeserializeObject<T[]>(File.ReadAllText(filePath));
        }

        public static void Set<T>(IEnumerable<T> items)
        {
            var filePath = GetJsonFilePath<T[]>();
            File.WriteAllText(filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
        }
    }
}