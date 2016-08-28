using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Action
    {

        public static void Execute(string input)
        {
            string[] command = input.Split(' ');
            try
            {
                typeof(Action).GetMethod(command[0]).Invoke(command[0], new object[] { command });
            } catch
            {
                Console.WriteLine("Invalid command!");
            }
        }

        public static void say(string[] c)
        {
            Console.Write("You: ");
            c[0] = "";
            foreach(string word in c)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }

        public static void examine(string[] c)
        {
            Console.WriteLine("You found {0}", c[1]);
        }
    }
}
