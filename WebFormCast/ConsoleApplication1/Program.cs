using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes("A");
                Console.WriteLine("" + asciiBytes[0]);
                int v = asciiBytes[0];
                v++;
                char[] characters = System.Text.Encoding.ASCII.GetChars(asciiBytes);
                char c = characters[0];
                Console.WriteLine("" + c);
            Console.ReadLine();
        }
    }
}
