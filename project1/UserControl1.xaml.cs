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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1
    {
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
                        Price.Text = "$" + i.price.ToString();
                        Title.Text = i.title;
                    }
                }
            }
        }
    }
}
