using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace FileSync
{
    public class Resources
    {
        public static string Namespace { get; set; }
        public static Assembly ExecutingAssembly { get; set; }

        public static Image GetImage(string key)
        {
            ResourceManager resManager = new ResourceManager(Namespace, ExecutingAssembly);
            return (Image)resManager.GetObject(key);
        }
    }
}
