using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
    /// Логика взаимодействия для Page_4.xaml
    /// </summary>
    public partial class Page_4 : Window
    {
        public Page_4()
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

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Page_3 page = new Page_3();
            Switching(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Page_5 page = new Page_5();
            Switching(page);
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] list = InputText.Text.Split(new char[] { ',' });
                string[] mat = { "2", "3", "4", "1", "7", "9", "12", "8", "9", "10" };
                for (int i = 0; i < mat.Length; i++)
                {
                    if (mat[i] != list[i]) throw new Exception();
                }
                int[] nums = new int[mat.Length];
                for (int i = 0;i < nums.Length; i++)
                {
                    nums[i] = int.Parse(mat[i]);
                }
                Array.Sort(nums);

                List<int> part_1 = new List<int>();
                List<int> part_2 = new List<int>();
                int sum1 = 0; int sum2 = 0; 

                for (int i = 0; i<nums.Length; i++)
                {
                    if (sum1 <= sum2)
                    {
                        part_1.Add(nums[i]);
                        sum1 += nums[i];
                    }
                    else
                    {
                        part_2.Add(nums[i]);
                        sum2 += nums[i];
                    }
                }
                float diff = sum1>sum2? (float)sum1/sum2: (float)sum2/sum1;
                if (diff <= 1.5)
                {
                    part_1.AddRange(part_2);
                    string end = string.Join(" ", part_1);
                    OutPut.Text = end;
                    OutDiff.Text += Convert.ToString(diff);
                }
                else
                {
                    OutPut.Text = "Решить данную задачу невозможно!";
                    OutDiff.Text += Convert.ToString(diff);
                }

                }
            catch (Exception) { MessageBox.Show("Неверно введён массив!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
