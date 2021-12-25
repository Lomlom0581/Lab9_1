using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_1
{
    class Program
    {        
        static double GetConsoleValue()
        {
            
            string Value = Console.ReadLine();

            if (                 
                 Value.Contains('.') ||                 
                 Value.Contains(' ') ||
                (!Value.StartsWith("-") && Value.Contains('-')))
                throw new FormatException("Введено число в нверном формате");

            try
            {                
                return double.Parse(Value, System.Globalization.CultureInfo.GetCultureInfo("ru-RU")); 
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось распознать введенное число");
            }
        }
        static void Addition()
        {
            Console.WriteLine("Введите первое слагаемое:");
            double v1 = GetConsoleValue();
            Console.WriteLine("Введите второе слагаемое:");
            double v2 = GetConsoleValue();

            Console.WriteLine($"Сумма: {v1 + v2}");
        }
        static void Substraction()
        {
            Console.WriteLine("Введите уменьшаемое:");
            double v1 = GetConsoleValue();
            Console.WriteLine("Введите вычитаемое:");
            double v2 = GetConsoleValue();
            Console.WriteLine($"Разность: {v1 - v2}");
        }
        static void Multiplication()
        {
            Console.WriteLine("Введите множимое:");
            double v1 = GetConsoleValue();
            Console.WriteLine("Введите множитель:");
            double v2 = GetConsoleValue();
            Console.WriteLine($"Произведение: {v1 * v2}");
        }
        static void Division()
        {
            Console.WriteLine("Введите делимое:");
            double v1 = GetConsoleValue();
            Console.WriteLine("Введите делитель:");
            double v2 = GetConsoleValue();

            try            {
                
                if (v2 == 0) throw new DivideByZeroException();

                Console.WriteLine($"Частное: {v1 / v2}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Совершена попытка разделить на ноль. На ноль делить нельзя.");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Калькулятор версия 1.0!");
        begin:
            try
            {                
                Console.WriteLine("Выберете операцию \n  1 - сложение \n  2 - вычитание \n  3 - умножение \n  4 - деление \n  5 - выход");
                string OpCode = Console.ReadLine();

                switch (OpCode)
                {
                    case "1": Addition(); break;
                    case "2": Substraction(); break;
                    case "3": Multiplication(); break;
                    case "4": Division(); break;
                    case "5": return; 
                    default:
                        Console.WriteLine("Нет такого варианта, попробуйте снова.");
                        goto begin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка :" + e.Message);
            }
            goto begin;

        }
    }
}
