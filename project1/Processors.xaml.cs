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

using project1.Data.Context;
using project1.Data;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для Processors.xaml
    /// </summary>
    public partial class Processors
    {
        public int IdUsers = 0;
        public bool IsAdmin = false;
        int id = 0;
        double price = 0f;

        int temp = 16;
        public Processors()
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var prod = db.products;
                foreach (var i in prod)
                {
                    if (i.title == "Intel Core i9-9900K")
                    {
                        Price.Text = "$" + i.price.ToString();
                        price = Convert.ToDouble(i.price);
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                        id = i.Id;
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
                var prod = db.products.Where(p => p.cat_id == 1);
                foreach (var i in prod)
                {
                    if (i.Id == temp)
                    {
                        Price.Text = "$" + i.price.ToString();
                        price = Convert.ToDouble(i.price);
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                        id = i.Id;
                        if (temp == idNumber)
                            temp = 15;
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
                var prod = db.products.Where(p => p.cat_id == 1);
                foreach (var i in prod.OrderByDescending(u => u.Id))
                {
                    if (i.Id == temp)
                    {
                        id = i.Id;
                        price = Convert.ToDouble(i.price);
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                        ImageVideo.Source = new BitmapImage(new Uri(i.image));
                        imagespecvideo.Source = new BitmapImage(new Uri(i.description));
                        if (temp == idNumber)
                            temp = 15;
                    }
                }
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                order order = new order { user_id = IdUsers, prod_id = id, price = price, qty = 1, dateTime = DateTime.Now };
                db.orders.Add(order);
                db.SaveChanges();
                BespokeFusion.MaterialMessageBox.Show("Добавлено в корзину!");
            }
        }
    }
}
