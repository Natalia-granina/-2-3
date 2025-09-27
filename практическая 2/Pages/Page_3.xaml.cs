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
    /// Логика взаимодействия для Page_3.xaml
    /// </summary>
    public partial class Page_3 : Window
    {
        public Page_3()
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

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Page_2 page = new Page_2();
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
            MaxNum.Content = "";
            RepitNum.Content = "";
            matrix.Content = "";
            int num = Convert.ToInt32(tbxInput.Text);

            if ((num > 20 || num < 1) || (!tbxInput.Text.All(char.IsDigit)))
            {
                MessageBox.Show("Неверный формат данных.", "Ошибка",
                               MessageBoxButton.OK, MessageBoxImage.Error);
            }
            int[] list = new int[num];
            Random rand = new Random();
            for(int i = 0; i < list.Length; i++)
            {
                list[i]=rand.Next(15,40);
                matrix.Content += Convert.ToString(list[i]);
                matrix.Content += " ";
            }
            int[] uniqnum = list.Distinct().ToArray();
            int max = 0;
            int count = 0;
            int repNum = 0;
            for(int i = 0;i < uniqnum.Length; i++)
            {
                count = 0;
                for(int j = 0; j < list.Length; j++)
                {
                    if (uniqnum[i] == list[j])
                    {
                        count++;
                    }

                }
                if (count > max) max = count;
                if (count == max) repNum = uniqnum[i]; 
            }
            MaxNum.Content = Convert.ToString(max);
            RepitNum.Content = Convert.ToString(repNum);   
        }
    }
}
