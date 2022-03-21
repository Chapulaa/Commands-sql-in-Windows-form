using ConectarBd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarBancoDeDados
{
    public class PessoBd
    {
        public int Gravar(Pessoa pPessoa)
        {
            int retorno = 0;

            ConexaoDb db = new ConexaoDb();
            ComandoSql sql = new ComandoSql();
            sql.InsertTabela("Cliente");
            sql.InsertSqlObj("nome", $"'{pPessoa.nome}'");
            sql.InsertSqlObj("codigo", $"'{pPessoa.codigo}'");
            sql.InsertSqlObj("telefone", $"'{pPessoa.telefone}'", true);
            if(sql.ExecutarComandoSql() == 1)
            {
                retorno = 1;
            }
            else
            {
                retorno = -1;
            }
            return retorno;
        }
    }
}
