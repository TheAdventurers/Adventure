using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{

    abstract class Tile
    {
        public bool[] enterable = new bool[4];
        public Tile(bool[] enterable)
        {
            this.enterable = enterable;
        }
    }
}
