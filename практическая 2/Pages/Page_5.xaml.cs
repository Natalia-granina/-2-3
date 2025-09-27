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
    /// Логика взаимодействия для Page_5.xaml
    /// </summary>
    public partial class Page_5 : Window
    {
        public Page_5()
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

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Page_4 page = new Page_4();
            Switching(page);
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(InputN.Text);
                int m = int.Parse(InputM.Text);
                if ((n <= 0 || n > 6) && (m == 0 || m > 6)) throw new Exception();
                Random random = new Random();
                int[,] startMatrix = new int[n,m];
                for (int i = 0; i < n; i++) 
                {
                    for (int j=0; j<m; j++ )
                    startMatrix[i,j] = random.Next(-10, 10);
                }

                StringBuilder strb = new StringBuilder();
                AddToTextBlock(n, m, strb, GenMatrix, startMatrix);
                SortMatrix(startMatrix,n,m, 0); //сортировка по убыванию
                SortMatrix(startMatrix,n,m, 1); // сортировка по возрастанию

            }
            catch { MessageBox.Show("Значения размерности массива находятся в неверном диапазоне!", 
                "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }

        }

        public void SortMatrix(int[,] matrix, int rows, int columns, int num)
        {
            int[] list = new int[rows*columns];
            int count = 0;
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    list[count++] = matrix[i, j];
                }
            }
            Array.Sort(list);
            
            if (num == 0)
            {
                count = 0;
                Array.Reverse(list);
                for (int i = 0; i < rows; i++)
                {

                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = list[count++];
                    }
                }
                StringBuilder stringBuilder = new StringBuilder();
                AddToTextBlock(rows, columns, stringBuilder, DescendOrder, matrix);
                Maxim.Content += Convert.ToString(list.Max());
            }
            if (num == 1)
            {
                count = 0;
                for (int i = 0; i < rows; i++)
                {

                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = list[count++];
                    }
                }
                StringBuilder stringBuilder = new StringBuilder();
                AddToTextBlock(rows, columns, stringBuilder, AscendOrder, matrix);
                Minim.Content += Convert.ToString(list.Min());
            }
        }

        public void AddToTextBlock(int rows, int columns, StringBuilder sb, TextBlock tb, int[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                
                for (int j = 0; j < columns; j++)
                {
                    sb.Append($"{matrix[i, j],4}");
                }
                sb.AppendLine();
            }

            tb.Text += sb.ToString();
        }
    }
}
