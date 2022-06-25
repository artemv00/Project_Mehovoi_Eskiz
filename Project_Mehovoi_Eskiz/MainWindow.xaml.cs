using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project_Mehovoi_Eskiz.Core;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Mehovoi_Eskiz
{
    /// всем работать.
    public partial class MainWindow : Window
    {
        SessionClass session = new SessionClass(null, null);
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += OpenWindow;

        }

        private void CheckDBConnection()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Console.WriteLine("Connection success!");
                context.SaveChanges();
            }
        }

        public void OpenWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (session.Login != null && session.IsAdmin == "1")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (session.Login != null && session.IsAdmin == "0")
            {
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();

            registrationWindow.Show();

            this.Close();
        }

        private void AuthorisationButton_Click(object sender, RoutedEventArgs e)
        {
            string login;
            string password;
            login = LoginField.Text;
            password = PasswordField.Password;

            using (DataBaseContext context = new DataBaseContext())

            {
                var logined = from users in context.Polzovatels.ToList()
                             where users.EMail == login
                             where users.Password == password
                             select users;
                                                                   
                if (logined.Any() == true)                         
                {                                                  
                    session.Login = logined.ToList()[0].UName;     

                    session.IsAdmin = logined.ToList()[0].isAdmin;

                    /* session.Password = logined.ToList()[0].UName;  */

                    /*var checkAdmin = from users in context.Polzovatels.ToList()
                                      where users.EMail == login
                                      select users.isAdmin;

                    session.IsAdmin = checkAdmin.ToList();*/

                    this.Close();

                    /*UserWindow userWindow = new UserWindow();

                    userWindow.Show();

                    this.Close();*/
                }
                else
                {
                    ErrorTextBox.Text = "Неправильно введен логин или пароль.";
                }


            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
