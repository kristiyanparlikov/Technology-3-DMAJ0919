/*
 * Excercise
 * Refactor this code so that the buttonConA_Click and buttonConB_Click are using a common base
 * Refactor buttonPrepareTest_Click likewise
 * 
 * Exercise
 * Transform into using TransactionScope
 * 
 * Read: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/begin-end-transact-sql?view=sql-server-ver15
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace TransactionScope
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectionTestGeneral(SqlConnectionStringBuilder connString, string database)
        {
            connString.InitialCatalog = "master";
            connString.IntegratedSecurity = false; /* true means windows authentication */
            SqlConnection connDB = new SqlConnection(connString.ConnectionString);
            try
            {
                connDB.Open();
                connDB.Close();
                textBoxResult.Text = database + "\nSQL Connection OK";
                textBoxResult.Update();
            }
            catch (SqlException ex)
            {
                textBoxResult.Text = ex.ToString();
                textBoxResult.Update();
            }
        }

        private void buttonConA_Click(object sender, EventArgs e)
        {
            //Testing the connectivity to Database-A
            //InitialCatalog must be set to "master" as no database may present
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUserA.Text;
            connString.Password = textBoxPasswordA.Text;
            connString.DataSource = textBoxUrlA.Text;
            ConnectionTestGeneral(connString, "Database-A");
        }

        private void buttonConB_Click(object sender, EventArgs e)
        {
            //Testing the connectivity to Database-B
            //InitialCatalog must be set to "master" as no database may present
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUserB.Text;
            connString.Password = textBoxPasswordB.Text;
            connString.DataSource = textBoxUrlB.Text;
            ConnectionTestGeneral(connString, "Database-B");
        }

        private void PrepareTestGeneral(SqlConnectionStringBuilder connString, string databaseName)
        {
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {

                try
                {
                    connDB.Open();
                    textBoxResult.Text = databaseName + "\n" + "SQL Connection OK";
                    textBoxResult.Update();
                }
                catch (SqlException ex)
                {
                    textBoxResult.Text = databaseName + "\n" + ex.ToString();
                    textBoxResult.Update();
                    connDB.Close();
                    return;
                }
                connString.InitialCatalog = "";
                string[] cmds = new string[] {
                    "BEGIN USE master DROP DATABASE IF EXISTS " + databaseName + " END",
                    "BEGIN CREATE DATABASE " + databaseName + " END",
                    "BEGIN USE " + databaseName + " CREATE TABLE theAccounts (id int, saldo int, PRIMARY KEY (id)) END"
                };
                foreach (var theCmd in cmds)
                {
                    try
                    {
                        string pQuery = theCmd;
                        SqlCommand cmd = new SqlCommand(pQuery, connDB);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        textBoxResult.Text = databaseName + "\n" + theCmd+ "\n" + ex.ToString();
                        textBoxResult.Update();
                        connDB.Close();
                        return;
                    }
                }
                for (int indx = 1; indx < 11; indx++)
                {
                    try
                    {
                        string pQuery = "INSERT INTO theAccounts(id, saldo) VALUES(@id, @saldo)";
                        SqlCommand cmd = new SqlCommand(pQuery, connDB);
                        cmd.Parameters.AddWithValue("@id", indx);
                        cmd.Parameters.AddWithValue("@saldo", 1000);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        textBoxResult.Text = databaseName + "\n" + ex.ToString();
                        textBoxResult.Update();
                        connDB.Close();
                        return;
                    }
                }
                connDB.Close();
            }
        }

            private void buttonPrepareTest_Click(object sender, EventArgs e)
        {
            // Drop the test databases if they exist and create new ones
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.IntegratedSecurity = false;          // true means windows authentication
            connString.InitialCatalog = "";

            connString.UserID = textBoxUserA.Text;
            connString.Password = textBoxPasswordA.Text;
            connString.DataSource = textBoxUrlA.Text;
            PrepareTestGeneral(connString, "Copenhagen");

            connString.UserID = textBoxUserB.Text;
            connString.Password = textBoxPasswordB.Text;
            connString.DataSource = textBoxUrlB.Text;
            PrepareTestGeneral(connString, "Aalborg");

            textBoxResult.Text = "Prepare for Test... Done";
            textBoxResult.Update();
        }

        private int ThreadA()
        {
            // This thread will move 100 from Copenhagen(1) to Aalborg(1)
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUserA.Text;
            connString.Password = textBoxPasswordA.Text;
            connString.DataSource = textBoxUrlA.Text;
            // Withdraw 100 from Copenhagen (1)
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    Console.WriteLine("Copenhagen (TA) \n" + "SQL Connection OK");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Copenhagen (TA) \n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                try
                {
                    string pQuery = "BEGIN USE Copenhagen UPDATE theAccounts SET saldo = 900 WHERE id = 1 END";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Withdraw 100 from Copenhagen(1)\n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                connDB.Close();
            }
            //
            // Sleep ing 5 seconds
            //
            Thread.Sleep(5000);
            connString.UserID = textBoxUserB.Text;
            connString.Password = textBoxPasswordB.Text;
            connString.DataSource = textBoxUrlB.Text;
            // Deposit 100 to Aalborg (1)
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    Console.WriteLine("Aalborg (TA) \n" + "SQL Connection OK");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Aalborg (TA) \n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                try
                {
                    string pQuery = "BEGIN USE Aalborg UPDATE theAccounts SET saldo = 1100 WHERE id = 1 END";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Deposit 100 to Aalborg(1)\n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                connDB.Close();
            }
            return 0;
        }

        private int ThreadB()
        {
            // This thread will collect balance for both branches
            int balance = 0;
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUserA.Text;
            connString.Password = textBoxPasswordA.Text;
            connString.DataSource = textBoxUrlA.Text;
            //
            // Start by sleeping 2.5 seconds
            //
            Thread.Sleep(2500);
            //
            // Get saldoes from Copenhagen
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    Console.WriteLine("Copenhagen (TB) \n" + "SQL Connection OK");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Copenhagen (TB) \n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                try
                {
                    string pQuery = "BEGIN USE Copenhagen SELECT saldo FROM theAccounts END";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            balance += Convert.ToInt32(reader["saldo"]);
                            Console.WriteLine("Subtotal= " + balance.ToString());
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Getting Balance from Copenhagen(1)\n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                connDB.Close();
            }
            connString.UserID = textBoxUserB.Text;
            connString.Password = textBoxPasswordB.Text;
            connString.DataSource = textBoxUrlB.Text;
            // Withdraw 100 fromm Aalborg (1)
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    Console.WriteLine("Aalborg (TB) \n" + "SQL Connection OK");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Aalborg (TB) \n" + ex.ToString());
                    connDB.Close();
                    return - 1;
                }
                try
                {
                    string pQuery = "BEGIN USE Aalborg SELECT saldo FROM theAccounts END";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            balance += Convert.ToInt32(reader["saldo"]);
                            Console.WriteLine("Subtotal= " + balance.ToString());
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Getting Balance from Aalborg(1)\n" + ex.ToString());
                    connDB.Close();
                    return -1;
                }
                connDB.Close();
            }
            return 0;
        }

        private void ThreadWoTSA()
        {
            ThreadA();
        }

        private void ThreadWoTSB()
        {
            ThreadB();
        }

        private void buttonTestWoTS_Click(object sender, EventArgs e)
        {
            ThreadStart childRefA = new ThreadStart(ThreadWoTSA);
            Thread childA = new Thread(childRefA);
            ThreadStart childRefB = new ThreadStart(ThreadWoTSB);
            Thread childB = new Thread(childRefB);
            childA.Start();
            childB.Start();
        }

        private void ThreadWTSA()
        {
            // Implicit Transaction
            Boolean again = true;
            while (again)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    if ( ThreadA() == 0 ) {
                        again = false;
                        scope.Complete();
                    } else
                    {
                        Console.WriteLine("ThreadWTSA fails and reties");
                        scope.Dispose();
                    }
                }
            }
        }

            private void ThreadWTSB()
        {
            // Implicit Transaction
            // Implicit Transaction
            Boolean again = true;
            while (again)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    if ( ThreadB() == 0 ) {
                        again = false;
                        scope.Complete();
                    } else
                    {
                        Console.WriteLine("ThreadWTSB fails and reties");
                        scope.Dispose();
                    }
                }
            }
        }

        private void buttonTestWTS_Click(object sender, EventArgs e)
        {
            ThreadStart childRefA = new ThreadStart(ThreadWTSA);
            Thread childA = new Thread(childRefA);
            ThreadStart childRefB = new ThreadStart(ThreadWTSB);
            Thread childB = new Thread(childRefB);
            childA.Start();
            childB.Start();
        }
    }
}
