using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{

    class Calculate
    {
        public string Calc(string s)
        {
            String task = "";
            double result = 0;
            bool minus = false;
            try
            {
                String startTask = s.Replace(" ", "");

                //Проверка на первое отрицательное число
                if (startTask.StartsWith("-"))
                {
                    minus = true;
                    task = startTask.Substring(1);
                }
                else
                {
                    task = startTask;
                }

                string pattern = "[\\+\\-]";
                string[] digits = Regex.Split(task, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500)); // Числа
                char[] task1 = task.ToCharArray(); // Массив символов выражения

                // Арифметические знаки
                var symbols = new List<char>();
                for (int i = 0; i < task1.Length; i++)
                {
                    if (task1[i] == '-' || task1[i] == '+')
                    {
                        symbols.Add(task1[i]);
                    }
                }

                // Вычисление
                if (minus)
                {
                    result = double.Parse(digits[0]) * -1;
                }
                else
                {
                    result = double.Parse(digits[0]);
                }
                for (int i = 0; i < symbols.Count(); i++)
                {
                    if (symbols[i] == '+')
                    {
                        result = result + double.Parse(digits[i + 1]);
                    }
                    else
                    {
                        result = result - double.Parse(digits[i + 1]);
                    }
                }
            }
            catch (Exception e)
            {
                return "Input error!";
            }
            return result.ToString();
        }
    }
}
