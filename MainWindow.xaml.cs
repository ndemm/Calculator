using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Calculator
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e) // numbers
        {
            Button btn = (Button)sender;
            string num = btn.Content.ToString();

            if (textValue.Text == "0")
                textValue.Text = num;
            else
                textValue.Text += num;

            if (op == "")
            {
                num1 = double.Parse(textValue.Text);
            }
            else
            {
                num2 = double.Parse(textValue.Text);
            }
        }

        private void btn_op_Click(object sender, RoutedEventArgs e) // +, -, *,/
        {
            Button btn = (Button)sender;
            op = btn.Content.ToString();
            textValue.Text = "0";
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e) // =
        {
            double result = 0; 
            switch (op)
            {
                case "+":result = num1 + num2; break; //плюс
                case "-":result = num1 - num2; break; //минус
                case "*":result = num1 * num2; break; //умножение
                case "/":result = num1 / num2; break; //деление
                case "min":result = Math.Min(num1, num2); break; //минимум
                case "max":result = Math.Max(num1, num2); break; //максимум
                case "avg":result = (num1 + num2) / 2; break; //вычесление среднего
                case "x^y":result = Pow(num1, (int)num2); break; //возведение в степень
            }
            textValue.Text = result.ToString();
            op = "";
            num1 = result;
            num2 = 0;
        }

        //x^4 = x * x * x * x = x3 * x; 
        //x^3 = x * x * x = x^2 * x;
        //x^2 = x * x = x^1 * x;
        //x^1 = x = x^0 * x;
        //x^0 = 1;
        private double Pow(double x, int y)
        {
            if (y == 0)
                return 1;
            return Pow(x, y -1) * x;

        }

        private void btn_C_Click(object sender, RoutedEventArgs e) //C
        {
            num1 = 0;
            num2 = 0;
            op = "";
            textValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e) //CE
        {
            if (op == "")
            {
                num1 = 0;
            }
            else
            {
                num2 = 0;
            }
            textValue.Text = "0";
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e) //backspace
        {
            textValue.Text = DropLastChar(textValue.Text);
            if (op == "")
            {
                num1 = Double.Parse(textValue.Text);
            }
            else
            {
                num2 = Double.Parse(textValue.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
                text = "0";

            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e) // +/-
        {
            if (op == "")
            {
                num1 *= -1;
                textValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                textValue.Text=num2.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e) // ,
        {
            if (op == "")
                SetComma(num1);
            else
                SetComma(num2);
        }

        private void SetComma(double num)
        {
            if (textValue.Text.Contains(','))
                return;

            textValue.Text += ',';
        }
    }
}
