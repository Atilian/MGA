using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MGA.WindowsApps.Comptabilite
{
    internal class BDDComptabilite
    {
        private MySqlConnection _Conn;

        private string _Server;
        private string _Database;
        private string _User;
        private string _Password;
        private string _Port;

        public BDDComptabilite(
            string server = "109.234.164.218", 
            string database = "wkmk7941_MGA_Comptabilite", 
            string user = "wkmk7941_MGA_Host", 
            string password = "APYmJ9X@568hbgL5", 
            string port = "3306")
        {

            this._Server = server;
            this._Database = database;
            this._User = user;
            this._Password = password;
            this._Port = port;

            this._Conn = new MySqlConnection($"server={server};port={port};user id={user};password={password};database={database}");

        }

        public void Connect()
        {
            try
            {
                this._Conn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                this._Conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Operation> Select()
        {
            Connect();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM operations", this._Conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Operation> operations = new List<Operation>();

            while (reader.Read())
            {
                Operation x = new Operation(int.Parse(reader["id"].ToString()), reader["libele"].ToString(), int.Parse(reader["montant"].ToString()), reader["date"].ToString());
                operations.Add(x);
            }

            Disconnect();

            return operations;
        }

        public void Insert(string index, string libele, string montant, string date)
        {
            Connect();

            string query = "INSERT INTO operations (id,libele,montant,date) VALUES ('"+index+"','"+libele+"','"+montant+"','"+date+"')";

            MySqlCommand cmd = new MySqlCommand(query, this._Conn);

            cmd.ExecuteNonQuery();

            Disconnect();
        }

        public void Delete(string index)
        {
            Connect();

            string query = "DELETE FROM operations WHERE id = "+index;

            MySqlCommand cmd = new MySqlCommand(query, this._Conn);

            cmd.ExecuteNonQuery();

            Disconnect();
        }

        public void Update(string index, string libele, string montant)
        {
            Connect();

            string query = "UPDATE operations SET libele = '" + libele + "', montant = '"+montant+"' WHERE id = "+index;

            MySqlCommand cmd = new MySqlCommand(query, this._Conn);

            cmd.ExecuteNonQuery();

            Disconnect();
        }
    }
}
