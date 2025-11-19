using System;
using System.Collections.Generic;
using System.Data;
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
using практическая_2.Models;
using практическая_2.Services;

namespace практическая_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {

        int click;
        public Autho()
        {
            InitializeComponent();
            click = 0;
        }

        private void btn_EnterAsGuest(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }

        private void GenCapcha()
        {
            tblockCapthca.Visibility = Visibility.Visible;
            tbxCaptcha.Visibility = Visibility.Visible;
            tblOutCapcha.Visibility = Visibility.Visible;

            tblOutCapcha.Text = CaptchaGen.GenCaptchaText(6);
            tblOutCapcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void btn_Enter(object sender, RoutedEventArgs e)
        {
            click += 1;
            string login = tbxLogin.Text.Trim();
            string password = Hash.HashPassw(tbxPassword.Text.Trim());

            EstateAgancyEntities db = EstateAgancyEntities.GetContext();

            var user = db.Authoriz.Where(x => x.UserLogin == login && x.hashPassword == password).FirstOrDefault();
            if (user != null && click == 1)
            {
                string role = RoleIs(user); 
                LoadPage(role, user);
                MessageBox.Show("Вы вошли как:" + role);
            }

            else if (click > 1)
            {
                if (user != null && tblOutCapcha.Text == tbxCaptcha.Text)
                {
                    string role = RoleIs(user);
                    LoadPage(role, user);
                    MessageBox.Show("Вы вошли как:" + role);
                    
                }
                else
                {
                    MessageBox.Show("Введите данные заново!");
                }
            }
            
            else
            {
                MessageBox.Show("Вы ввели логин или пароль неверно!");
                GenCapcha();
                tbxPassword.Clear();
            }

            
        }

        public string RoleIs(Authoriz user)
        {
            int who = (user.UserLogin.StartsWith("agent_", StringComparison.OrdinalIgnoreCase) ? 1 : 2);
            string role = (who == 1 ? "агент" : "клиент");
            return role;
        }

        private void LoadPage(string role, Authoriz user)
        {
            click = 0;
            switch (role)
            {
                case "клиент":
                    NavigationService.Navigate(new Client(user, role));
                    break;
            }
        }
    }
}
