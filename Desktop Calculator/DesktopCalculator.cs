using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Calculator
{
    public partial class DesktopCalculator : Form
    {
        public DesktopCalculator()
        {
            InitializeComponent();
        }

        // Поле ввода
        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }

        // Кнопка вычисления
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            this.Output.Text = Calculate(this.UserInput.Text);
        }

        // Очистка поля ввода
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.UserInput.Text = string.Empty;
            this.Output.Text = string.Empty;
            this.FocusInput();
        }

        // Курсор на поле ввода
        private void FocusInput()
        {
            this.UserInput.Focus();
        }

        // Вывод результата
        private void Output_TextChanged(object sender, EventArgs e)
        {

        }

        // Метод вычисления
        private static string Calculate(string s)
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

//MessageBox.Show('+');
