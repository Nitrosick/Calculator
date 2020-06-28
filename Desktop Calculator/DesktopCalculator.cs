using System;
using System.Windows.Forms;
using Calculator;


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
            Calculate calc = new Calculate();
            this.Output.Text = calc.Calc(this.UserInput.Text);
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
    }
}

//MessageBox.Show('+');
