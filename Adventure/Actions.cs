using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Actions
    {
        public static ResourceManager action_strings;

        public static bool DoAction(string action)
        {
            CultureInfo cul = Program.cul;
            action_strings = new ResourceManager("Adventure.Resource.actions_" + cul, Assembly.GetExecutingAssembly());
            List<string> actions_list;
            string[] words = action.Split(' ');

            actions_list = GetKeywords("go");
            foreach (string word in words)
            {
                if (actions_list.Contains(word))
                {
                    foreach (string direction in words)
                    {
                        List<string> forward_list = GetKeywords("forward");
                        List<string> left_list = GetKeywords("left");
                        List<string> right_list = GetKeywords("right");
                        List<string> backward_list = GetKeywords("backward");
                        if (forward_list.Contains(direction))
                        {
                            Program.position.y++;
                            Program.move();
                            return true;
                        } else if (left_list.Contains(direction))
                        {
                            Program.position.x--;
                            Program.move();
                            return true;
                        }
                        else if (right_list.Contains(direction))
                        {
                            Program.position.x++;
                            Program.move();
                            return true;
                        }
                        else if (backward_list.Contains(direction))
                        {
                            Program.position.y--;
                            Program.move();
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static List<string> GetKeywords(string Key)
        {
            List<string> actions_list = new List<string>();
            int i = 0;
            while (action_strings.GetString(Key + "_" + i) != null)
            {
                actions_list.Add(action_strings.GetString(Key + "_" + i));
                i++;
            }
            return actions_list;
        }
    }
}
