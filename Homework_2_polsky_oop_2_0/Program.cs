using System;

namespace Homework_2_polsky_oop_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode;
            string input_line = "";

            Console.WriteLine("Укажите пожалуйста режим работы:\n1 - Своя формула (бой)\n2- Предзаполнение (тест) [2 / (3 + 2) * 5]");
            mode = Console.ReadLine();

            if (mode == "1")
            {
                Console.WriteLine("Введите пожалуйста математическое выражение:");
                input_line = Console.ReadLine();
            }
            else if (mode == "2")
            {
                input_line = "2 / (3 + 2) * 5";
                Console.WriteLine("Проверяем работу программы на выражении {0}", input_line);
            }

            if (input_line == "")
                Console.WriteLine("Строка выражения пустая, обработка невозмможна");

            if (input_line != "")
            {
                Console.WriteLine("Берем в обработку {0}", input_line);

                input_line = input_line.Replace(" ","");
                ProcessingExpression collect = new ProcessingExpression();
                collect.GetOutputString(input_line);
                CalculatePolskyReverse calculate = new CalculatePolskyReverse();
                calculate.GetResult(collect.resultExpression);

                Console.WriteLine(collect.resultExpression + "\n" + calculate.result);
            }
            else
                Console.WriteLine("Передана пустая строка!");
        }
    }
}
