using MySqlConnector;
using System.Collections.Generic;
using System.Data;
namespace PKS
{
    class DB
    {
        public DB() => conn = new Login().GetLoginString();
        public DataView GetTable(string Table)
        {
            MySqlCommand cmd = new ($"SELECT * FROM {Table}", conn);
            cmd.ExecuteNonQuery();
            DataTable dataTable = new (Table);
            new MySqlDataAdapter(cmd).Fill(dataTable);
            return dataTable.DefaultView;
        }
        public void Req(string req) => new MySqlCommand(req, conn).ExecuteNonQuery();
        public MySqlConnection conn;
    }
}
