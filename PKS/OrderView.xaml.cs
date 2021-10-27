using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows;
namespace PKS
{
    public partial class OrderView : Window
    {
        PrintDocument printDoc = new();
        public OrderView(DataRowView dataRow, DB db)
        {
            InitializeComponent();
            printDoc.PrintPage += PrintPageHandler;
            string ID = dataRow.Row["Код"].ToString();
            OrderInfo.Text += $"\nНомер заказа = {ID}\n";
            OrderInfo.Text += db.Req($"SELECT ФИО_клиента FROM Заказ WHERE Код={ID}", "ФИО клиента:");
            OrderInfo.Text += db.Req($"SELECT Номер_телефона FROM Заказ WHERE Код={ID}", "Номер клиента:");
            OrderInfo.Text += db.Req($"SELECT Дата_заказа FROM Заказ WHERE Код={ID}", "Дата заказа:");
            OrderInfo.Text += db.Req($"SELECT Изображение_аэрографии FROM Заказ WHERE Код={ID}", "Ссылка на изображение для аэрографии:");
            OrderInfo.Text += db.Req($"SELECT 3D_Модель FROM Заказ WHERE Код={ID}", "Ссылка на 3D-модель гитары:");
            OrderInfo.Text += db.Req($"SELECT * FROM Колки WHERE Код=(SELECT Колки FROM Заказ where Код = '{ID}')", "Колки:");
            OrderInfo.Text += db.Req($"SELECT * FROM Звукосниматель WHERE Код=(SELECT Звукосниматель FROM Заказ WHERE Код='{ID}')", "Звукосниматель:");
            OrderInfo.Text += db.Req($"SELECT * FROM Бридж WHERE Код=(SELECT Бридж FROM Заказ WHERE Код='{ID}')", "Бридж:");
            OrderInfo.Text += db.Req($"SELECT * FROM Анкер WHERE Код=(SELECT Анкер FROM Заказ WHERE Код='{ID}')", "Анкер:");
            OrderInfo.Text += db.Req($"SELECT * FROM Вид_сборки WHERE Код=(SELECT Вид_сборки FROM Заказ WHERE Код='{ID}')", "Вид_сборки:");
            OrderInfo.Text += db.Req($"SELECT * FROM Материал_корпуса WHERE Код=(SELECT Материал_корпуса FROM Заказ WHERE Код='{ID}')", "Материал_корпуса:");
            OrderInfo.Text += db.Req($"SELECT * FROM Струны WHERE Код=(SELECT Струны FROM Заказ WHERE Код='{ID}')", "Струны:");
            OrderInfo.Text += db.Req($"SELECT * FROM Покраска WHERE Код=(SELECT Покраска FROM Заказ WHERE Код='{ID}')", "Покраска:");
            OrderInfo.Text += db.Req($"SELECT * FROM Материал_грифа WHERE Код=(SELECT Материал_грифа FROM Заказ WHERE Код='{ID}')", "Материал_грифа:");
            OrderInfo.Text += db.Req($"SELECT * FROM Электронная_начинка WHERE Код=(SELECT Колки FROM Заказ WHERE Код='{ID}')", "Электронная_начинка:");
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e) =>
            e.Graphics.DrawString(OrderInfo.Text, new("Arial", 16), Brushes.Black, 0, 0);
        private void Print_Click(object sender, RoutedEventArgs e) => printDoc.Print();
        private void Exit_Click(object sender, RoutedEventArgs e) => Close();
    }
}
