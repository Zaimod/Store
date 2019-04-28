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
using System.Data.Entity;

using Nexmo.Api;

using System.Net.Mail;
using System.Net;

using project1.Decorator;
namespace project1
{
    /// <summary>
    /// Логика взаимодействия для UserControl3.xaml
    /// </summary>
    public partial class UserControl3
    {
        public int IdUsers = 0;
        public bool IsAdmin = false;
        public string phoneNumber = "";
        double sum = 0;
        public UserControl3()
        {
            InitializeComponent();
            

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            using (Model1 db = new Model1())
            {
                var t = db.orders
                    .Where(p => p.user_id == IdUsers);
                db.orders.RemoveRange(t);
                db.SaveChanges();

            }
            listBox.Items.Add("Кошик порожній");
            textBox.Text = "0";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            sum = 0;
            using (Model1 db = new Model1())
            {
                var v = from p in db.orders
                        join c in db.products on p.prod_id equals c.Id
                        select new { Name = c.title, Price = p.price, Id = p.user_id };

                foreach (var i in v)
                {
                    if (i.Id == IdUsers)
                    {
                        listBox.Items.Add(i.Name + "        " + i.Price + "$");
                    }
                }

                var v1 = db.orders
                    .Where(t => t.user_id == IdUsers);

                foreach (var i in v1)
                {
                    sum += Convert.ToDouble(i.price);
                }
                textBox.Text = sum.ToString();
            }

            

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }


        int selected_item_listBox = -1;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_item_listBox = listBox.SelectedIndex;
        }
        int pr_id = 0;
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            sum = 0;
            if(selected_item_listBox == -1 || listBox.Items[0].ToString() == "Кошик порожній")
            {
                BespokeFusion.MaterialMessageBox.ShowError("Оберіть товар зі списку!");
            }
            else
            {
                string temp = listBox.SelectedItem.ToString().Substring(0, listBox.SelectedItem.ToString().IndexOf("  "));
                
                using (Model1 db = new Model1())
                {

                    var v = db.products;
                    
                    foreach (var i in v)
                    {
                        if (i.title == temp)
                        {
                            pr_id = i.Id;
                        }
                    }
                    listBox.Items.RemoveAt(listBox.SelectedIndex);
                    var t = db.orders
                    .First(p => p.prod_id == pr_id);
                    db.orders.Remove(t);

                    db.SaveChanges();
                    BespokeFusion.MaterialMessageBox.Show("Товар видалено зі списку!");

                    var v1 = db.orders
                    .Where(ht => ht.user_id == IdUsers);

                    foreach (var i in v1)
                    {
                        sum += Convert.ToDouble(i.price);
                    }
                    textBox.Text = sum.ToString();

                }
            }
    
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            BespokeFusion.MaterialMessageBox.Show("Вам надіслано смс");

            string t1 = "";
            string t = "Vash zakaz pruinyato" + "\n" + "Do splatu: " + sum.ToString() + "$\n";

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                t1 += i + 1 + ". " + listBox.Items[i] + "\n";
            }
            t1 += $"Vash zakaz pruinyato\nDo splatu: {sum.ToString()}$\n";

            /*
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "31bbd8d7",
                ApiSecret = "fRWvlac5j3ZMKn6H"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Project",
                to = phoneNumber,
                text = t
            });
            */

            /*
            try
            {
                MailMessage message = new MailMessage();
                message.Subject = "Zakaz####";
                message.From = new MailAddress("ivashchuk67@gmail.com");
                message.Body = t1;
                message.To.Add("ivashchuk65@gmail.com");

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new NetworkCredential("ivashchuk67@gmail.com", "Vv18052000"),
                    EnableSsl = true,
                    Port = 587
                };
                smtp.Send(message);
            }
            catch(Exception ex)
            {
                BespokeFusion.MaterialMessageBox.ShowError(ex.Message);
            }
            */
            int price = 0;
            Tovar tovar = new Videokarta();
            
            string tb = "";
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString().Substring(0, 6) == "NVIDIA")
                {
                    tovar = new NvidiaVideokarta(tovar);
                    tb = listBox.Items[i].ToString().Substring(0, listBox.Items[i].ToString().IndexOf("  "));

                    price += tovar.GetCost(tb);
                }
                else if(listBox.Items[i].ToString().Substring(0, 3) == "AMD")
                {
                    tovar = new AMDVideokarta(tovar);
                    tb = listBox.Items[i].ToString().Substring(0, listBox.Items[i].ToString().IndexOf("  "));

                    price += tovar.GetCost(tb);
                }
            }
            textBox.Text = price.ToString();
        }
    }
}
