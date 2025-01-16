using System;
using System.Threading;

namespace MultiThreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating threads and assigning methods
            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintCharacters);

            // Starting threads
            thread1.Start();
            thread2.Start();

            //It's especially important when you want to ensure all threads have
            //completed their tasks before exiting the program.
            thread1.Join();
            thread2.Join();

            Console.WriteLine("All threads have completed execution.");
        }

        // Method to print numbers
        public static void PrintNumbers()
        {
            try
            {
                int n = 1;
                while (n <= 10)
                {
                    Console.WriteLine(n++);
                    Thread.Sleep(100); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to print characters
        public static void PrintCharacters()
        {
            try
            {
                for (char ch = 'A'; ch <= 'Z'; ch++)
                {
                    Console.WriteLine(ch);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
