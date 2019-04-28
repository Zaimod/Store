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
using project1.Data;
using project1.Data.Context;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {      
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                if (login.Text != "" && parol.Password != "" && email.Text != "" && tel.Text != "")
                { 
                    User user = new User { Login = login.Text, Password = parol.Password, isAdmin = false, email = email.Text, numberPhone = tel.Text };
                    db.Users.Add(user);
                    db.SaveChanges();
                    BespokeFusion.MaterialMessageBox.Show("Вітаємо!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    
                    
                }
                else
                {
                    BespokeFusion.MaterialMessageBox.ShowError("Введіть правильні дані!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Tel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
