using System;
using System.Threading;

namespace exercise4
{
    //this code prints a char in the Console. per default its a star.
    //When pressing another key and then enter the code wil now print whatever you pressed before enter
    class threprog
    {
        public static void Main()
        {
            Program pg = new Program();
            Thread printer = new Thread(pg.Print);
            Thread reader = new Thread(pg.Read);
            
            printer.Start();
            reader.Start();
        }
    }
    class Program
    {
        public static volatile char ch = '*';
        public void Print()
        {
            while (true)
            {
                Console.Write(ch);
                Thread.Sleep(1000);
            }
        }

        public void Read()
        {
            char temp;
            while (true)
            {
                do
                {
                    temp = Console.ReadKey(true).KeyChar;
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

                ch = temp;
            }
        }
    }
}