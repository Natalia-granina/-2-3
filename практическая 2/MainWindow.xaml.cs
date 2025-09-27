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
using практическая_2.Pages;

namespace практическая_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new Autho()); // подгрузка страницы в данный фрейм
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

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Page_5 page = new Page_5();
            Switching(page);
        }

        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.CanGoBack)
            {
                btn1.Visibility = Visibility.Visible;
                btn2.Visibility = Visibility.Visible;
                btn3.Visibility = Visibility.Visible;
                btn4.Visibility = Visibility.Visible;
                btn5.Visibility = Visibility.Visible;
                Welcome.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btn1.Visibility = Visibility.Hidden;
                btn2.Visibility = Visibility.Hidden;
                btn3.Visibility = Visibility.Hidden;
                btn4.Visibility = Visibility.Hidden;
                btn5.Visibility = Visibility.Hidden;
                Welcome.Visibility = Visibility.Hidden;
                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.GoBack();
        }
    }
}
