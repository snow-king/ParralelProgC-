// See https://aka.ms/new-console-template for more information

using Parallel_programming.Tasks;
using Parallel_programming.utils;

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("Лабораторная работа 1. Организация параллельно выполняемых потоков и межпроцессное взаимодействие.");
Console.WriteLine("Для запуска задачи введите её номер.");
Console.WriteLine("Для выхода нажмите q");
Console.ResetColor();
Console.WriteLine();

var isExit = true;
do
{
    var commands = new ComandValidator();
    Console.Write("\nВведите данные: ");
    var command = Console.ReadLine();
    isExit = commands.ParseCommand(command!);
} while (isExit);

Console.WriteLine("Завершение программы.");