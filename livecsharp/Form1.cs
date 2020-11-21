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
            chkAtivo.Checked = false; txtId.Clear();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstLista.Items.Clear();
            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos();
            foreach (var item in lista)
            {
                lstLista.Items.Add(item.Nome + " - " +item.Email + " - "+ item.Telefone);
            }
        }
    }
}
