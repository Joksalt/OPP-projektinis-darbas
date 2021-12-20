using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Flyweight
{
    public class ImageFactory
    {
        public Dictionary<string, string> cache = new Dictionary<string, string>();

        public string GetImagePath(string key)
        {
            if (cache.ContainsKey(key))
                return cache[key];
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path += "Images\\";
            path = path + key + ".png";
            cache.Add(key, path);
            return path;
        }

    }
}
