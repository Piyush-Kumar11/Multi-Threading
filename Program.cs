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

            // Setting thread priorities (optional, OS-dependent)
            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Lowest;

            Console.WriteLine($"Thread1 State Before Start: {thread1.ThreadState}");
            Console.WriteLine($"Thread2 State Before Start: {thread2.ThreadState}");

            // Starting threads
            thread1.Start();
            thread2.Start();

            Console.WriteLine($"Thread1 State After Start: {thread1.ThreadState}");
            Console.WriteLine($"Thread2 State After Start: {thread2.ThreadState}");

            //It's especially important when you want to ensure all threads have
            //completed their tasks before exiting the program.
            thread1.Join();
            thread2.Join();

            Console.WriteLine("All threads have completed execution.");
        }

        public static void PrintNumbers()
        {
            try
            {
                for (int n = 1; n <= 10; n++)
                {
                    Console.WriteLine(n);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PrintNumbers: {ex.Message}");
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
                Console.WriteLine($"Error in PrintCharacters: {ex.Message}");
            }
        }
    }
}
