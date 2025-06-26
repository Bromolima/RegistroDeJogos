using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeJogos
{
    internal class Functions
    {
        public static DataTable Search(string command)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                using (OleDbCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = command;

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
        
            return dt;
        }

        public static void Delete(string id)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                using (OleDbCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = "delete from games where id = ?";
                    cmd.Parameters.AddWithValue("?", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
