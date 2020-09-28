using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace json2mssql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Corona myDeserializedClass = JsonConvert.DeserializeObject<Corona>(System.IO.File.ReadAllText(textBox1.Text));
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUser.Text;
            connString.Password = textBoxPasswd.Text;
            connString.DataSource = textBoxURL.Text;
            connString.IntegratedSecurity = false; // if true then windows authentication

            connString.InitialCatalog = "master";
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    connDB.Close();
                    textBoxResult.Text = "SQL Connection OK";
                    textBoxResult.Update();
                }
                catch( SqlException ex )
                {
                    textBoxResult.Text = ex.ToString();
                    textBoxResult.Update();
                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.InitialDirectory = "C:\\";
            dialog.Title = "Select the JSON file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                textBox1.Update();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Corona myDeserializedClass = JsonConvert.DeserializeObject<Corona>(System.IO.File.ReadAllText(textBox1.Text));
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = textBoxUser.Text;
            connString.Password = textBoxPasswd.Text;
            connString.DataSource = textBoxURL.Text;
            connString.IntegratedSecurity = false; // if true then windows authentication

            connString.InitialCatalog = "master";
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    connDB.Open();
                    connDB.Close();
                    textBoxResult.Text = "SQL Connection OK";
                    textBoxResult.Update();
                }
                catch (SqlException ex)
                {
                    textBoxResult.Text = ex.ToString();
                    textBoxResult.Update();
                }
            }
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    string pQuery = "DROP DATABASE IF EXISTS Corona";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    connDB.Open();
                    cmd.ExecuteNonQuery();
                    connDB.Close();
                }
                catch (SqlException ex)
                {
                    textBoxResult.Text = ex.ToString();
                    textBoxResult.Update();
                }
            }
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    string pQuery = "CREATE DATABASE Corona";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    connDB.Open();
                    cmd.ExecuteNonQuery();
                    connDB.Close();
                }
                catch (SqlException ex)
                {
                    textBoxResult.Text = ex.ToString();
                    textBoxResult.Update();
                }
            }

            connString.InitialCatalog = "Corona";
            using (SqlConnection connDB = new SqlConnection(connString.ConnectionString))
            {
                try
                {
                    string pQuery = "CREATE TABLE theStats (countrycode char(4), date smalldatetime, cases int, deaths int, recovered int, PRIMARY KEY(countrycode, date))";
                    SqlCommand cmd = new SqlCommand(pQuery, connDB);
                    cmd.CommandType = CommandType.Text;
                    connDB.Open();
                    cmd.ExecuteNonQuery();
                    connDB.Close();
                }
                catch (SqlException ex)
                {
                    textBoxResult.Text = ex.ToString();
                    textBoxResult.Update();
                }
                connDB.Open();
                int counter = 0;
                foreach( Datum theRegistration in myDeserializedClass.data)
                {
                    try
                    {
                        string pQuery = "INSERT INTO theStats (countrycode, date, cases, deaths, recovered)";
                        pQuery += " VALUES (@countrycode, @date, @cases, @deaths, @recovered)";
                        SqlCommand myCommand = new SqlCommand(pQuery, connDB);
                        myCommand.Parameters.AddWithValue("@countrycode", theRegistration.countrycode);
                        myCommand.Parameters.AddWithValue("@date", theRegistration.date);
                        myCommand.Parameters.AddWithValue("@cases", theRegistration.cases);
                        myCommand.Parameters.AddWithValue("@deaths", theRegistration.deaths);
                        myCommand.Parameters.AddWithValue("@recovered", theRegistration.recovered);
                        myCommand.ExecuteNonQuery();
                        counter++;
                        if ( counter % 100 == 0)
                        {
                            textBoxResult.Text = "Processed : " + counter.ToString();
                            textBoxResult.Update();
                        }
                    }
                    catch (SqlException ex)
                    {
                        textBoxResult.Text = ex.ToString();
                        textBoxResult.Update();
                    }
                }
                connDB.Close();
                textBoxResult.Text = "Processing Done: " + counter.ToString();
                textBoxResult.Update();
            }
        }
    }
}
