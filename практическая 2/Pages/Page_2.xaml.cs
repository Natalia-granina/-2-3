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
    /// Логика взаимодействия для Page_2.xaml
    /// </summary>
    public partial class Page_2 : Window
    {
        public Page_2()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Page_1 page = new Page_1();
            Switching(page);
        }

        public void Switching(Window win)
        {
            win.Show();

            this.Close();
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

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            rtbRes.Document.Blocks.Clear() ;
            
            string str = tbxInput.Text;

            if (!tbxInput.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Неверный формат данных.", "Ошибка",
                               MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                char[] chars = str.ToCharArray();
                bool isFirst = true;
                StringBuilder sb = new StringBuilder(chars.Length);
                for (int i = 0; i < chars.Length; i++)
                {
                    if (char.IsLetter(chars[i]))
                    {
                        if (isFirst) sb.Append(char.ToUpper(chars[i]));
                        else sb.Append(char.ToLower(chars[i]));
                        isFirst = false;
                    }
                    else
                    {
                        sb.Append(chars[i]);
                        isFirst = true;
                    }
                }
                string result = sb.ToString();
                rtbRes.AppendText(result);
            }
        }
    }
}
