using System;
using System.Linq;
using System.Collections.Generic;

namespace FiLP_L2
{
    public struct Stroka
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
    }
    class Program
    {
        public static void PrintTable(List<Stroka> Table)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var a in Table)
                Console.WriteLine($"||Тип: {a.Type,-25}||Название: {a.Name,-6}||Размер: {a.Size,3}мм||");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        static void Main(string[] args)
        {
            List<Stroka> Table = new List<Stroka>() {
            new Stroka(){Type = "вертикально-фрезерный" ,   Name = "6М10" ,     Size = 200 },
            new Stroka(){Type = "вертикально-фрезерный" ,   Name = "6Н11" ,     Size = 250 },
            new Stroka(){Type = "горизонтально-фрезерный" , Name = "6М80Г" ,    Size = 200 },
            new Stroka(){Type = "горизонтально-фрезерный" , Name = "6Н81Г" ,    Size = 250 },
            new Stroka(){Type = "вертикально-фрезерный" ,   Name = "6Н11" ,     Size = 320 },
            new Stroka(){Type = "горизонтально-фрезерный" , Name = "6М82Г" ,    Size = 320 },
            new Stroka(){Type = "вертикально-фрезерный" ,   Name = "6М13" ,     Size = 400 },
            new Stroka(){Type = "горизонтально-фрезерный" , Name = "6М83Г" ,    Size = 400 },
            new Stroka(){Type = "вертикально-фрезерный" ,   Name = "6Н14" ,     Size = 500 },
            new Stroka(){Type = "горизонтально-фрезерный" , Name = "6Н84Г" ,    Size = 500 }};

            bool repeat = true;

            do
            {
                string sType, sName, sSize;

                Console.WriteLine("Имеются данные:");
                PrintTable(Table);
                Console.WriteLine();
                Console.WriteLine("Вы можете выполнить поиск по всем или не всем столбцам. Чтобы пропустить столбец, нажмите Enter.");

                Console.WriteLine("Введите текст для поиска по типу:");
                sType = Console.ReadLine();
                Console.WriteLine("Введите текст для поиска по имени:");
                sName = Console.ReadLine();
                Console.WriteLine("Введите текст для поиска по размеру:");
                sSize = Console.ReadLine();
                Console.WriteLine();

                var list = from a in Table
                           where string.IsNullOrEmpty(sName) ? true : a.Name.ToLower().Contains(sName.ToLower())
                           where string.IsNullOrEmpty(sType) ? true : a.Type.ToLower().Contains(sType.ToLower())
                           where string.IsNullOrEmpty(sSize) ? true : a.Size == Convert.ToInt32(sSize)
                           select a;

                Console.WriteLine("Результаты поиска:");
                PrintTable(list.ToList());
                Console.WriteLine();

                Console.WriteLine("Для продолжения поиска нажмите любую клавишу. Для завершения программы нажмите Esc.");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    repeat = false;
                else
                    Console.Clear();

            } while (repeat);


        }
    }
}
