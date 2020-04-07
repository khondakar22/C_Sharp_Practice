using System;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Please write your name");
            var name =  Console.ReadLine();
            Console.WriteLine("Hello World!" + name);
            Console.WriteLine("How long you have been slept?");
            var hoursOfSleep = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(hoursOfSleep > 8 ? "You slept well" : "You need more sleep");
        }
    }
}
