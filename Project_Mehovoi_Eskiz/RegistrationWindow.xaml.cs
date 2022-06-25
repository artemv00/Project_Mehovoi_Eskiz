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
using Project_Mehovoi_Eskiz.Core;
using System.Drawing;

namespace Project_Mehovoi_Eskiz
{
    /// ЧЕЛЫ РАБОТАЕЕМ
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            SaveRegButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }

        private void GoToTheMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        private void SaveRegButton_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                ErrorTextBox.Text = "";

                Polzovatel user = new Polzovatel();

                user.UName = nameField.Text;
                user.USurname = surnameField.Text;
                user.ContactNumber = numberField.Text;
                user.Password = passwordField.Password;
                user.EMail = emailField.Text;
                user.isAdmin = "0";

                

                var alreadyUser = from users in context.Polzovatels.ToList()
                                  where users.EMail == user.EMail
                                  select users;

                Console.WriteLine(alreadyUser);
                Console.WriteLine(alreadyUser.Any());

                if (user.UName == null || user.USurname == null || user.ContactNumber == null || user.Password == null || user.Password == null || user.EMail == null)
                {
                    ErrorTextBox.Text = "Все поля должны быть заполнены!"; // условие не работает
                }
                else if (alreadyUser.Any() == false)
                {
                    context.Polzovatels.Add(user);
                    context.SaveChanges();

                    MessageBox.Show("Вы успешно зарегистрированы!");

                    MainWindow mainWindow = new MainWindow();

                    mainWindow.Show();

                    this.Close();


                }
                else
                {
                    ErrorTextBox.Text = "Пользователь уже зарегистрирован в системе!";
                }
            }
        }
    }
}
