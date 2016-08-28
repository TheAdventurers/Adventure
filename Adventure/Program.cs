using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace Adventure
{
    class Program
    {
        public static Random r;
        public static Dictionary<Position, Tile> tiles = new Dictionary<Position, Tile>();
        public static Position position = new Position(0, 0);
        public static ResourceManager lang_strings;
        public static CultureInfo cul;

        static void Main(string[] args)
        {
            while (true)
            {
                Action.Execute(Console.ReadLine());
            }
            string langcode = "";
            while (langcode != "en" & langcode != "de")
            {
                Console.WriteLine("Please enter language(en or de)");
                langcode = Console.ReadLine();
            }
            cul = CultureInfo.CreateSpecificCulture(langcode);
            lang_strings = new ResourceManager("Adventure.Resource." + cul, Assembly.GetExecutingAssembly());
            //Console.WriteLine(cul);

            Console.WriteLine(lang_strings.GetString("Enter_your_Name"));
            string name = Console.ReadLine();
            string seed = name;
            r = new Random(seed.GetHashCode());

            move();
            /*foreach (bool b in tiles[position].enterable)
            {
                Console.WriteLine(b);
            }

            if(tiles[position].enterable.Contains(true))
            {
                Console.WriteLine("KEKSE");
            }*/

            Console.ReadKey();
        }

        public static void move()
        {
            if (!tiles.ContainsKey(position))
            {
                Generator.GenerateRandomTile(position);
            }

            EnterTile();
            Console.WriteLine(lang_strings.GetString("What_to_do"));
            while (!Actions.DoAction(Console.ReadLine()))
            {
                Console.WriteLine(lang_strings.GetString("Could_not_understand"));
            }
        }

        public static void EnterTile()
        {
            string[] fullname = tiles[position].ToString().Split('.');
            string tilename = fullname[1];
            int i = 0;
            while (lang_strings.GetString("Enter_" + tilename + "_" + i) != null)
            {
                i++;
            }
            i = r.Next(0,i);
            Console.WriteLine(lang_strings.GetString("Enter_" + tilename + "_" + i));
        }



    }
}
