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

namespace calc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string output ="";

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Button b = (Button)sender;
            Display.Text += b.Content.ToString();
        }

        private void outputWriter(string sender)
        {
            output += sender;
            Display.Text = output;
        }
        private void InspectionLast(char last, string sender)
        {
            if (last == '+' || last == '-' || last == '*' || last == '/' || last == '.')
            {
                output = Display.Text.ToString();
                Display.Text = output;
            }
            else if (last == '0')
            {
                Display.Text = Display.Text + sender;
                output = Display.Text.ToString();
            }
            else
                outputWriter(sender);
        }
        private void C_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                Display.Text = "Error!Try with C!";
            }
        }

        private void result()
        {
            String op;
            int iOp = 0;
            if (Display.Text.Contains("+"))
            {
                iOp = Display.Text.IndexOf("+");
            }
            else if (Display.Text.Contains("-"))
            {
                iOp = Display.Text.IndexOf("-");
            }
            else if (Display.Text.Contains("x"))
            {
                iOp = Display.Text.IndexOf("x");
            }
            else if (Display.Text.Contains("/"))
            {
                iOp = Display.Text.IndexOf("/");
            }
            else if (Display.Text.Contains("sqrt"))
            {
                iOp = Display.Text.IndexOf("sqrt");
            }
            else if (Display.Text.Contains("sqr"))
            {
                iOp = Display.Text.IndexOf("sqr");
            }
            else if (Display.Text.Contains("."))
            {
                iOp = Display.Text.IndexOf(".");
            }
            else
            { }

                op = Display.Text.Substring(iOp, 1);
                double op1 = Convert.ToDouble(Display.Text.Substring(0, iOp));
                double op2 = Convert.ToDouble(Display.Text.Substring(iOp + 1, Display.Text.Length - iOp - 1));

                if (op == "+")
                {
                Display.Text = "";
                Display.Text += + (op1 + op2);
                }
                else if (op == "-")
                {
                Display.Text = "";
                Display.Text += + (op1 - op2);
                }
                else if (op == "x")
                {
                Display.Text = "";
                Display.Text += + (op1 * op2);
                }
                else if (op == "/")
                {
                Display.Text = "";
                Display.Text += + (op1 / op2);
                }
                else if (op == ".")
                {
                Display.Text += ".";
                }
            }

        private void Button_Click_SQR(object sender, RoutedEventArgs e)
        {
            double number;
            var isDouble = double.TryParse(this.Display.Text, out number);
            if (isDouble)
            {
                this.Display.Text = Math.Round(Math.Pow(number,2)).ToString();
            }
        }

        private void Button_Click_SQRT(object sender, RoutedEventArgs e)
        {
            double number;
            var isDouble = double.TryParse(Display.Text, out number);
            if (isDouble)
            {
                Display.Text = Math.Round(Math.Sqrt(number), 2).ToString();
            }
        }
    }
}
