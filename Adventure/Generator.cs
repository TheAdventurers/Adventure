using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Generator
    {
        public static void GenerateRandomTile(Position position)
        {
            List<Type> t = Utils.GetClasses(typeof(Tile));
            dynamic tile = Activator.CreateInstance(t[Program.r.Next(0, t.Count - 1)]);
            Program.tiles.Add(position, tile);
        }
    }
}
