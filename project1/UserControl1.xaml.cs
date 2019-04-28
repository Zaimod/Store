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
using project1;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    /// 

    public partial class UserControl1
    {
        public int IdUsers;
        public bool IsAdmin;
        int id = 0;
        double price = 0f;
        public UserControl1()
        {            
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var prod = db.products;
                foreach (var i in prod)
                {
                    if(i.title == "NVIDIA GeForce RTX 2080 Ti")
                    {
                        id = i.Id;
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                        price = Convert.ToDouble(i.price);
                    }
                }
                
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
