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
using System.Data.Entity;
using project1.Data.Context;
using project1.Data;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
    public partial class UserControl2
    {
        int temp = 1;
        public UserControl2()
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var prod = db.products;
                foreach (var i in prod)
                {
                    if (i.title == "NVIDIA GeForce RTX 2080 Ti")
                    {
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                    }
                }
            }
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (Model1 db = new Model1())
            {
                temp++;
                var idNumber = db.products.Count();
                var prod = db.products;
                foreach (var i in prod)
                {
                    if (i.Id == temp)
                    {
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                        if (temp == idNumber)
                            temp = 0;
                    }
                }

            }

        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                temp++;
                var idNumber = db.products.Count();
                var prod = db.products;
                foreach (var i in prod.OrderByDescending(u => u.Id))
                {
                    if (i.Id == temp)
                    {
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                        if (temp == idNumber)
                            temp = 0;
                    }
                }

            }
        }
    }
}
