using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarBd
{
    public class ComandoSql
    {
        private string Comando { get; set; }
        private string tabela { get; set; }
        private string campo { get; set; }
        private string value { get; set; }

        SqlCommand cmd = new SqlCommand();

        public void InsertTabela(string tabelaNome)
        {
            tabela = $"insert into {tabelaNome}";
        }

        public void InsertSqlObj(string tabelaCampo, string objetoValor, bool ultuimoCmapo = false)
        {
            if (ultuimoCmapo == false)
            {
                if (objetoValor != null)
                {
                    campo += $"{tabelaCampo}, ";
                    value += $"{objetoValor}, ";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campo += $"{tabelaCampo}, ";
                    value += $"null, ";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }
            }
            else if (ultuimoCmapo == true)
            {
                if (objetoValor != null)
                {
                    campo += $"{tabelaCampo}";
                    value += $"{objetoValor}";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campo += $"{tabelaCampo}";
                    value += $"null, ";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }

            }

        }

        public int ExecutarComandoSql()
        {
            ConexaoDb db = new ConexaoDb();
            cmd.Connection = db.Conectar();
            
            Comando = $"{tabela}({campo}) values ({value});";
            cmd.CommandText = Comando;
            SqlDataReader dataRow  = cmd.ExecuteReader();
            db.Desconectar();
            return dataRow.RecordsAffected;
        }


    }
}

