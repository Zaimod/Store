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

namespace project1
{
    /// <summary>
    /// Логика взаимодействия для SettingsBase.xaml
    /// </summary>
    public partial class SettingsBase : Window
    {
        public SettingsBase()
        {
            InitializeComponent();
        }

        private void ButtonOff_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            project1.projectDataSet projectDataSet = ((project1.projectDataSet)(this.FindResource("projectDataSet")));
            // Загрузить данные в таблицу products. Можно изменить этот код как требуется.
            project1.projectDataSetTableAdapters.productsTableAdapter projectDataSetproductsTableAdapter = new project1.projectDataSetTableAdapters.productsTableAdapter();
            projectDataSetproductsTableAdapter.Fill(projectDataSet.products);
            System.Windows.Data.CollectionViewSource productsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productsViewSource")));
            productsViewSource.View.MoveCurrentToFirst();
        }

    }
}
