using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Adventure
{
    static class Utils
    {
        public static List<Type> GetClasses(Type baseType)
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(type => type.IsSubclassOf(baseType)).ToList();
        }

        public static double clamp(double v, double min=0.0, double max=100.0)
        {
            return (v < min) ? min : (v > max) ? max : v;
        }
    }
}
