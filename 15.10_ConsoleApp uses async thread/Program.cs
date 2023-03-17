using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15._10_ConsoleApp_uses_async_thread
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PrintAsync();

            Console.WriteLine("\nЗавершение работы приложения");
            Console.ReadLine();
        }

        static void Print()
        {
            Console.WriteLine("Начало работы метода Print");
            var th = Thread.CurrentThread;

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Работа потока {th.GetType()} ID {th.GetHashCode()}");
                Thread.Sleep(500);
            }
            Console.WriteLine("\nКонец работы метода Print");
        }

        static async Task PrintAsync()
        {
            Console.WriteLine("Начало работы метода PrintAsync");

            var th = Thread.CurrentThread;

            await Task.Run(() => Print());

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Работа потока {th.GetType()} ID {th.GetHashCode()}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("\nКонец работы метода PrintAsync");
        }
    }
}
