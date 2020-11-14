using System.Data.SqlClient;
using System.Web;
using System.Windows;
using System.IO;
using System.Data;
using System.Data.SqlTypes;


namespace FileStream.Database
{
    public class Repository
    {
        public Repository()
        {
            CreateDatabase();
        }
        private string MyConnectionString(string InitialCatalog)
        {
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder
            {
                UserID = "sa",
                Password = "Technology3",
                DataSource = "l2.kaje.ucnit20.eu",
                InitialCatalog = InitialCatalog, // The USE command
                IntegratedSecurity = false /* true means windows authentication */
            };
            return connString.ConnectionString;
        }
        private void CreateDatabase()
        {
            string connString = MyConnectionString("master");
            using (SqlConnection connDB = new SqlConnection(connString))
            {
                try
                {
                    string pQuery = "CREATE DATABASE Images";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB)
                    {
                        CommandType = CommandType.Text
                    };
                    connDB.Open();
                    cmd.ExecuteNonQuery();
                    connDB.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR Creating Database");
                }
            }
            connString = MyConnectionString("Images");
            using (SqlConnection connDB = new SqlConnection(connString))
            {
                try
                {
                    string pQuery = "CREATE TABLE theStats (ID int, Images VARBINARY(MAX) FILESTREAM DEFAULT(0x), PRIMARY KEY (ID))";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    connDB.Open();
                    cmd.ExecuteNonQuery();
                    connDB.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR Creating Table");
                }
            }


        }
        public int SaveImage(HttpPostedFileBase theImage)
        {
            return 1;
        }


    }
}