using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task2.Run();
            Task3.Run();
            Task4.Run();
            Task1.Run();
        }
    }
}
class Task1
{
    public static void Run()
    {
        Process process = new Process();
        process.StartInfo.FileName = "notepad.exe";
        process.Start();
        process.WaitForExit();
        int exitCode = process.ExitCode;
        Console.WriteLine($"Код завершення процесу: {exitCode}");
    }

}
class Task2
{
    public static void Run()
    {
        Process process = new Process();
        process.StartInfo.FileName = "notepad.exe";
        process.Start();

        Console.WriteLine("Введіть 1, щоб чекати завершення процесу, або 2 для примусового завершення:");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            process.WaitForExit();
            Console.WriteLine($"Код завершення процесу: {process.ExitCode}");
        }
        else if (choice == "2")
        {
            System.Threading.Thread.Sleep(3000);
            process.Kill();
            Console.WriteLine("Процес примусово завершено.");
        }
    }
}
class Task3
{
    public static void Run()
    {
        Console.Write("Введіть перше число: ");
        string num1 = Console.ReadLine();
        Console.Write("Введіть друге число: ");
        string num2 = Console.ReadLine();
        Console.Write("Введіть операцію (+, -, *, /): ");
        string operation = Console.ReadLine();

        Process process = new Process();
        process.StartInfo.FileName = "ChildProcess.exe";
        process.StartInfo.Arguments = $"{num1} {num2} {operation}";
        process.Start();
        process.WaitForExit();
    }
}
class Task4
{
    public static void Run()
    {
        Console.Write("Введіть шлях до файлу: ");
        string filePath = Console.ReadLine();
        Console.Write("Введіть слово для пошуку: ");
        string word = Console.ReadLine();

        Process process = new Process();
        process.StartInfo.FileName = "ChildProcess.exe";
        process.StartInfo.Arguments = $"\"{filePath}\" {word}";
        process.Start();
        process.WaitForExit();
    }
}
