using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Banto;

namespace BantoDemoApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {

            OleDbConnection CON = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Projetos\Banto\BantoDemoApplication\UFRN.mdb");

            try
            {
                OleDbCommand comand = new OleDbCommand(txtLDM.Text.ToSQLCommand(), CON);

                DataTable tabela = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comand);
                adapter.Fill(tabela);

                dataGridView2.DataSource = tabela.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uFRNDataSet.Alunos' table. You can move, or remove it, as needed.
        }
    }
}
