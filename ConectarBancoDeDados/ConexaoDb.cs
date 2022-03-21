﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarBd
{
    public class ConexaoDb
    {
        SqlConnection con = new SqlConnection();

        public ConexaoDb()
        {
            con.ConnectionString = @"Server=DESKTOP-G6SU7RQ\SQLSEVER;Database=Master;Trusted_Connection=True;
";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
