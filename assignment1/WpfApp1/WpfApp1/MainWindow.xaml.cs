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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double num1, num2;
        public char ch;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ch = '+';
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            ch = '-';
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            ch = '*';
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            ch = '/';
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string s1 = testBox1.Text;
            num1 = double.Parse(s1);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s2 = testBox2.Text;
            num2 = double.Parse(s2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double answer = 0;
            switch (ch)
            {
                case '+':
                    answer = num1 + num2;
                    MessageBox.Show(answer.ToString());
                    break;
                case '-':
                    answer = num1 - num2;
                    MessageBox.Show(answer.ToString());
                    break;
                case '*':
                    answer = num1 * num2;
                    MessageBox.Show(answer.ToString());
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        answer = num1 / num2;
                        MessageBox.Show(answer.ToString());
                    }
                   else MessageBox.Show("除数不能为零");
                    break;
                default:
                    break;
            }
        }
    }
}
