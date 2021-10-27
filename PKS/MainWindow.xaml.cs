using System;
using System.Data;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
/*
mysql> CREATE USER '1'@'localhost' IDENTIFIED BY '123456789';
mysql> GRANT SELECT ON Заказ TO '1'@'localhost';
 * */
namespace PKS
{
    public partial class MainWindow : Window
    {
        DB db;
        DispatcherTimer dispTimer = new();
        public MainWindow()
        {
            db = new();
            InitializeComponent();
            Update();
            dispTimer.Interval = TimeSpan.FromHours(2);
            dispTimer.Tick += DispTimer_Tick;
            dispTimer.Start();
        }
        private void DispTimer_Tick(object sender, EventArgs e) => Update();
        void Update()
        {
            if (Orders.ItemsSource is DataView) ((DataView)Orders.ItemsSource).Dispose();
            Orders.ItemsSource = db.GetTable();
            GC.Collect();
        }
        private void Timer1_Elapsed(object sender, ElapsedEventArgs e) => Update();
        //Todo Окно с информацией о заказе
        private void Orders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Orders.SelectedItem != null) new OrderView(Orders.SelectedItem as DataRowView, db).ShowDialog();
        }
    }
}
