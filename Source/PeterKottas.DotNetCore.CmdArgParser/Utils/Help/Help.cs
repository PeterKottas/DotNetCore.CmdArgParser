using System;

namespace PeterKottas.DotNetCore.CmdArgParser.Utils.Help
{
    public static class Help
    {
        private static string GetSpaces(int number)
        {
            return new string(' ', number);
        }

        public static void Show(HelpData data)
        {
            int longestKeyLength = 5;

            foreach (var item in data.Parameters)
            {
                if (item.Key.Length > longestKeyLength)
                {
                    longestKeyLength = item.Key.Length + 2;
                }
            }

            Console.WriteLine("Help:");

            if (!string.IsNullOrEmpty(data.AppDescription))
            {
                Console.WriteLine(data.AppDescription);
            }

            Console.WriteLine("Key{0}Description", GetSpaces(longestKeyLength - 3));

            foreach (var item in data.Parameters)
            {
                Console.WriteLine("{0}{1}{2}", item.Key, GetSpaces(longestKeyLength - item.Key.Length), item.Description);
            }

            Console.WriteLine("Arguments are parsed as");
            Console.WriteLine("Key:Value");
        }
    }
}
