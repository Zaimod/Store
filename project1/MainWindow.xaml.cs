﻿using System;
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
using project1.Data.Context;
using project1.Data;

namespace project1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int IdUsers = 0;
        public bool IsAdmin = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                bool flag = false;
                System.Data.Entity.DbSet<User> check = db.Users;

                foreach (User i in check)
                {
                    if (i.Login == login.Text && i.Password == parol.Password)
                    {
                        flag = true;
                        IdUsers = i.Id;
                        IsAdmin = i.isAdmin.Value;
                        Window2 window2 = new Window2();
                        window2.Show();
                        this.Close();
                        break;
                    }
                }
                if(flag == false)
                {
                     BespokeFusion.MaterialMessageBox.ShowError("Невірний логін чи пароль!");                   
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
