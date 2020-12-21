using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using livecsharp.Classes;

namespace livecsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno( 
                0, txtNome.Text,
                txtEmail.Text, 
                txtTelefone.Text, 
                txtSenha.Text,
                true
                );
            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
            MessageBox.Show("Aluno inserido com sucesso!");
            LimparCampos();

        }
        private void LimparCampos()
        {
            txtNome.Clear();txtEmail.Clear();txtTelefone.Clear();
            txtSenha.Clear(); txtConfirmaSenha.Clear();
            chkAtivo.Checked = false; txtId.Clear();txtId.ReadOnly = true;
            btnInserir.Enabled = true;
            btnHabilitaBusca.Text = "...";
            btnAlterar.Enabled = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos();
            lista.ForEach(a => {
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnAtivo.Index].Value = a.Ativo;
            });
               
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (decimal)Aluno.ObterQuantidadeRegistros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos(0,(int)numericUpDown1.Value);
            lista.ForEach(a => {
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnAtivo.Index].Value = a.Ativo;
            });
        }

        private void btnHabilitaBusca_Click(object sender, EventArgs e)
        {
            if (btnHabilitaBusca.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                btnInserir.Enabled = false;
                btnAlterar.Enabled = true;
                btnHabilitaBusca.Text = "Buscar";
                chkAtivo.Enabled = true;
            }
            else if (btnHabilitaBusca.Text == "Buscar")
            { 
                if (txtId.Text != string.Empty)
                {
                    Aluno aluno = new Aluno();
                    aluno.ConsutarPorId(int.Parse(txtId.Text));
                    txtNome.Text = aluno.Nome;
                    txtEmail.Text = aluno.Email;
                    //txtEmail.ReadOnly = true;
                    txtTelefone.Text = aluno.Telefone;
                    //txtSenha.Text = aluno.Senha;
                    chkAtivo.Checked = aluno.Ativo;
                }
            }

           

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                txtSenha.UseSystemPasswordChar = false;
            else
                txtSenha.UseSystemPasswordChar = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Id = int.Parse(txtId.Text);
            aluno.Nome = txtNome.Text;
            aluno.Telefone = txtTelefone.Text;
            aluno.Ativo = chkAtivo.Checked;
            aluno.Alterar(aluno);

            MessageBox.Show("Aluno alterado com sucesso!");
            LimparCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aluno a = new Aluno();
            a.Excluir(int.Parse(txtId.Text), false);
            MessageBox.Show("Aluno excluído com sucesso!");
            LimparCampos();

        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==dgvLista.Columns.IndexOf(clnAtivo))
            {
                
                Aluno aluno = new Aluno();
                bool situacao = Convert.ToBoolean(dgvLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (situacao)
                {
                    dgvLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    string id = dgvLista.Rows[e.RowIndex].Cells[clnId.Index].Value.ToString();
                    aluno.Excluir(int.Parse(id), false);
                }
                else
                {
                    dgvLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    string id = dgvLista.Rows[e.RowIndex].Cells[clnId.Index].Value.ToString();
                    aluno.Excluir(int.Parse(id), true);
                }
              if(dgvLista.EndEdit())
                {
                    MessageBox.Show("Concluído");
                }
            }
        }
    }
}
