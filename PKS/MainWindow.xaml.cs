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

namespace PKS
{
    public partial class MainWindow : Window
    {
        DB db;
        public MainWindow()
        {
            db = new();
            InitializeComponent();
            Orders.ItemsSource = db.GetTable("Заказ");
        }

        //Todo Окно с информацией о заказе
        private void Orders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (Orders.SelectedItem!=null)
        }
    }
}
