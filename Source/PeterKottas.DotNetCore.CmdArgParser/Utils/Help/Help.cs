using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterKottas.DotNetCore.CmdArgParser.Utils.Help
{
    public static class Help
    {
        private static string getSpaces(int number)
        {
            return new string(' ', number);
        }

        public static void Show(HelpData data)
        {
            int longestKeyLenght = 5;
            foreach (var item in data.parameters)
            {
                if (item.Key.Length > longestKeyLenght)
                {
                    longestKeyLenght = item.Key.Length + 2;
                }
            }
            Console.WriteLine("Help:");
            if (!string.IsNullOrEmpty(data.AppDescription))
            {
                Console.WriteLine(data.AppDescription);
            }
            Console.WriteLine("Key{0}Description", getSpaces(longestKeyLenght - 3));
            foreach (var item in data.parameters)
            {
                Console.WriteLine("{0}{1}{2}", item.Key, getSpaces(longestKeyLenght - item.Key.Length), item.Description);
            }
            Console.WriteLine("Arguments are parsed as");
            Console.WriteLine("Key:Value");

        }
    }
}
