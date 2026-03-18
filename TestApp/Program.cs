using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list_1 = new List<int>();

            list_1.Add(0);

            List<object> list_2 = new List<object>();

            list_2.Add("0");

            Dictionary<string,string> dict = new Dictionary<string,string>();

            dict.Add("zero", "ноль");
            dict.Add("one", "один");
            dict.Add("two", "два");
            dict.Add("three", "три");
            dict.Add("four", "четыре");
            dict.Add("five", "пять");
            dict.Add("six", "шесть");

            foreach(string key in dict.Keys)
            {
                Console.WriteLine($"{key}={dict[key]}");
            }
        }
    }
}
