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
using project1.Data.Context;
using project1.Data;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        
        public int IdUsers = 0;
        public bool IsAdmin = false;
        public string phoneNumber = "";

        UserControl1 Control1 = new UserControl1();
        UserControl2 Control2 = new UserControl2();
        UserControl3 Control3 = new UserControl3();

        public Window2()
        {            
            InitializeComponent();
            GridPrincipal.Children.Clear();
            Control1.IdUsers = IdUsers;
            Control1.IsAdmin = IsAdmin;
            GridPrincipal.Children.Add(Control1);

            
        }

        private void ButtonOff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:                
                    GridPrincipal.Children.Clear();
                    Control1.IdUsers = IdUsers;
                    Control1.IsAdmin = IsAdmin;
                    GridPrincipal.Children.Add(Control1);
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    Control2.IdUsers = IdUsers;
                    Control2.IsAdmin = IsAdmin;
                    GridPrincipal.Children.Add(Control2);
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    Control3.IdUsers = IdUsers;
                    Control3.IsAdmin = IsAdmin;
                    Control3.phoneNumber = phoneNumber;
                    GridPrincipal.Children.Add(Control3);
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitionInContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
    }
}
