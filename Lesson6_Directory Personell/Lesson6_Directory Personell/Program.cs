using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Directory_Personell
{
    internal class Program
    {  
         static void DataInput (string pred)
            {
            int ID = 0;

            if (File.Exists(pred))
                ID = File.ReadAllLines(pred).Length + 1;

            using (StreamWriter sw = new StreamWriter(pred,true,Encoding.Unicode))
            {
               

                string Data = string.Empty;
                
         
                Data += $"#{ID}";

                string Date = DateTime.Now.ToString();
                Console.WriteLine($"\nДата и время:{Date}");
                Data += $"#{Date}";

                Console.Write("\n Ф.И.О: ");
                Data += $"#{Console.ReadLine()}";

          
                Console.Write("\n Возраст: ");
                int Age=Convert.ToInt32(Console.ReadLine());
                Data += $"#{Age}";

                Console.Write("\n Рост: ");
                int Hieght = Convert.ToInt32(Console.ReadLine());
                Data += $"#{Hieght}";

                Console.Write("\n Дата рождения: ");
                string DateBirt=Convert.ToDateTime(Console.ReadLine()).ToString("dd.MM.yyyy");
                Data += $"#{DateBirt}";

                Console.Write("\n Место рождение: ");
                Data += $"#{Console.ReadLine()}";

                sw.WriteLine(Data);
            }
         

             }
        static void  OutputConsole (string str)
        {
            if (!File.Exists(str))
                Console.WriteLine("Данных в файле нет");
            else
            {
                using (StreamReader sr = new StreamReader(str, Encoding.Unicode))
                {                  
                    while (!sr.EndOfStream)
                        Console.WriteLine(sr.ReadLine().Replace("#", " "));
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 или 2 для работа в справочнике. \n 1- ввывести данные на экран.\n 2-Добавить новую запись");
            string WorkBase = Console.ReadLine();
            string File = @"Derectory_Personell.txt";
            switch (WorkBase)
            {
                case "1": OutputConsole(File);break;
                case "2": DataInput(File);break;
                    default:Console.Write("Вы ввели не существующую команду");break;
             }
            Console.ReadKey();

        }
    }
}
