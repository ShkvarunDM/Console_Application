using System;
using Npgsql;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;


    namespace Connect_DB
    {
        class Connect
        {
            
       private NpgsqlConnection nconnect;


        public Connect()
            {
                nconnect = new NpgsqlConnection($@"Server= {Environment.GetEnvironmentVariable("myserver")}; Port = {Environment.GetEnvironmentVariable("myport")}; Database= {Environment.GetEnvironmentVariable("mybase")};User ID = {Environment.GetEnvironmentVariable("myID")};password = {Environment.GetEnvironmentVariable("mypass")};");
            }
            private void connect()
            {
                if (nconnect.State == System.Data.ConnectionState.Closed)
                    nconnect.Open();
            }
            private void disconnect()
            {
                if (nconnect.State == System.Data.ConnectionState.Closed)
                    nconnect.Open();
            }

            public int ExecuteNonQuery(NpgsqlCommand command)
            {
                connect();
                command.Connection = nconnect;
                int res = command.ExecuteNonQuery();
                disconnect();
                return res;
            }

            public NpgsqlDataReader ExecuteReader(NpgsqlCommand command)
            {
                connect();
                command.Connection = nconnect;
                NpgsqlDataReader res = command.ExecuteReader();
                disconnect();
                return res;
            }

            public object ExecuteScalar(NpgsqlCommand command)
            {
                connect();
                command.Connection = nconnect;
                object res = command.ExecuteScalar();
                disconnect();
                return res;
            }


        }
    }
