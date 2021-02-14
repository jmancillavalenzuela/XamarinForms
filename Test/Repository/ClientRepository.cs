using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Models;

namespace Test.Repository
{
    class ClientRepository
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=12345;database=test";

        public bool LoginAccess(Client user)
        {
            List<Client> result = new List<Client>();

            var connection = new MySqlConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT RUT, Nombre FROM Client WHERE RUT = " + user.RUT + " AND PASSWORD = " + user.Password + " + AND deleted = 0";

            var reader = command.ExecuteReader();
            if (reader.Read()) // if query is true!
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<Client> GetClients()
        {
            List<Client> result = new List<Client>();

            var connection = new MySqlConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT RUT, Nombre FROM Client WHERE deleted = 0";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Client
                {
                    RUT = reader.GetString("RUT"),
                    Nombre = reader.GetString("Nombre"),
                });
            }
            return result;
        }
    }
}

