using ConectarBd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConectarBancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pessoa pPessoa = new Pessoa();
                pPessoa.codigo = Convert.ToInt32(txtCod.Text);
                pPessoa.nome = txtNome.Text;
                pPessoa.telefone = txtTell.Text;

                PessoBd pessoaDb = new PessoBd();
                if (pessoaDb.Gravar(pPessoa) == 1)
                {
                    MessageBox.Show("Cliente Gravado com seucesso");
                }
                else
                {
                    throw new Exception("Houve um erro ao gravar o Cliente");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
