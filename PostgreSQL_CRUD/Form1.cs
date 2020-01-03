using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_CRUD
{
    public partial class Form1 : Form
    {

        private Pessoa pessoaSelecionada;
        DAL acesso = new DAL();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                atualizarExibicao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void atualizarExibicao()
        {
            List<Pessoa> listaPessoa = new List<Pessoa>();
            foreach (DataRow item in acesso.GetTodosRegistros().Rows)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.id = Convert.ToInt32(item["id"].ToString());
                pessoa.nome = item["nome"].ToString();
                pessoa.email = item["email"].ToString();
                pessoa.idade = Convert.ToInt32(item["idade"].ToString());
                listaPessoa.Add(pessoa);
            }
            dgvFunci.DataSource = listaPessoa;

        }

        private void dgvFunci_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pessoaSelecionada = (dgvFunci.SelectedRows[0].DataBoundItem as Pessoa);

            prencherCampos(pessoaSelecionada);

        }

        private void prencherCampos(Pessoa pessoa)
        {
            txtNome.Text = pessoa.nome;
            txtEmail.Text = pessoa.email;
            txtIdade.Text = Convert.ToString(pessoa.idade);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (!pessoaSelecionada.nome.Equals(""))
            {
                acesso.DeletarRegistro(pessoaSelecionada.nome);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            acesso.AtualizarRegistro(pessoaSelecionada.id, txtEmail.Text, Convert.ToInt32(txtIdade.Text));
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            acesso.InserirRegistros(txtNome.Text, txtEmail.Text, Convert.ToInt32(txtIdade.Text));
        }
    }
}
