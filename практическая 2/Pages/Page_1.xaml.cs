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
using System.Windows.Shapes;

namespace практическая_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_1.xaml
    /// </summary>
    public partial class Page_1 : Window
    {
        public Page_1()
        {
            InitializeComponent();
        }

        public void Switching(Window win)
        {
            win.Show();

            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Page_2 page = new Page_2();
            Switching(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Page_3 page = new Page_3();
            Switching(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Page_4 page = new Page_4();
            Switching(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Page_5 page = new Page_5();
            Switching(page);
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            string str = tbxInput.Text;
            int num;
            bool exst = int.TryParse(str, out num);
            if (exst)
            {
                if ((num > 16 || num < 1) || (!tbxInput.Text.All(char.IsDigit)))
                {
                    MessageBox.Show("Неверный формат данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string endnum = Convert.ToString(Convert.ToUInt64(Math.Pow(num, num)));
                ResultLbl.Foreground = Brushes.Red;
                ResultLbl.Content += endnum;

                char[] chars = endnum.ToCharArray();
                char[] units = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int count = 0;
                for (int i = 0; i < units.Length; i++)
                {
                    count = 0;
                    for (int j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] == units[i]) count++;
                    }
                    string textBoxName = "tbx" + i;
                    TextBox textBox = this.FindName(textBoxName) as TextBox;
                    textBox.Text = Convert.ToString(count);
                }
            }
            else
            {
                MessageBox.Show("Не введены данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
