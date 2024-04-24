using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    internal class Adatbazis
    {
        MySqlCommand sqlCommand;
        MySqlConnection connection;
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dolgozok";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = connection.CreateCommand();
            try
            {
                kapcsolatNyit();
                kapcsolatzar();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatzar()
        {
            if (connection.State != System.Data.ConnectionState.Closed) 
            {
                connection.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if (connection.State != System.Data.ConnectionState.Open) 
            {
                connection.Open();            
            }
        }

        internal List<Dolgozo> getAllDolgozo()
        {
            List<Dolgozo>dolgozok = new List<Dolgozo> ();
            sqlCommand.CommandText = "SELECT `nev`,`neme`,`reszleg`,`belepesev`,`ber` FROM `dolgozok`";
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dolgozo dolgozo = new Dolgozo(dr.GetString("nev"),dr.GetString("neme"),dr.GetString("reszleg"),dr.GetInt32("belepesev"),dr.GetInt32("ber"));
                    dolgozok.Add(dolgozo);
                }
            }
                return dolgozok;
        }
    }
}
