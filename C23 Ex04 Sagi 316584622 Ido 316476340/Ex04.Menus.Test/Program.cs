using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Start()
        {
            Boolean Exit = false;
            int inPut;
            Interfaces.MainMenu mainMenuByInterface = new Interfaces.MainMenu();
            Delegates.MainMenu mainMenuByDelegates = new Delegates.MainMenu();
            do
            {
                Console.WriteLine(string.Format(@"Please select a method:
1-> By Interface
2-> By Delegates
0-> Exit"));
                try
                {
                    inPut = int.Parse(Console.ReadLine());
                    if (inPut == 0)
                    {
                        Exit = true;
                    }
                    else if (inPut == 1)
                    {
                        Console.WriteLine("By Interface:");
                        mainMenuByDelegates.Start();
                    }
                    else if (inPut == 2)
                    {
                        Console.WriteLine("By Delegates:");
                        mainMenuByInterface.Start();
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invald input");
                }
            } while (!Exit);
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
