using MySqlConnector;
using System.Data;
namespace PKS
{
    public class DB
    {
        string StuffID;
        public DB() => conn = new Login().GetLoginString(ref StuffID);
        public DataView GetTable()
        {
            MySqlCommand cmd = new ($"SELECT Код, ФИО_клиента, Номер_телефона, Дата_заказа, Подтверждение_оплаты  FROM Заказ WHERE Сотрудник={StuffID}", conn);
            cmd.ExecuteNonQuery();
            DataTable dataTable = new ("Заказ");
            new MySqlDataAdapter(cmd).Fill(dataTable);
            return dataTable.DefaultView;
        }
        public string Req(string req, string Startinfo)
        {
            try
            {
                Startinfo += "\n";
                MySqlCommand cmd = new(req, conn);
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < reader.FieldCount; i++)
                        Startinfo += $"   {reader.GetName(i)}: {reader[i]}.\n";
                reader.Close();
            }
            catch (System.Exception) { }
            return Startinfo;
        }
        public MySqlConnection conn;
    }
}
