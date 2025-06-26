using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDeJogos
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void GameListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            GameRegistrationForm form = new GameRegistrationForm();
            form.ShowDialog();

            GameDataListView.DataSource = Functions.Search("select * from games");
            GameDataListView.ClearSelection();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            GameDataListView.DataSource = Functions.Search("select * from games");

            GameDataListView.ClearSelection();
        }

        private void GameDataListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        private void GameDataListView_Sorted(object sender, EventArgs e)
        {
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            GameRegistrationForm form = new GameRegistrationForm();
            form.IDTextBox.Text = GameDataListView.CurrentRow.Cells["ID"].Value.ToString();
            form.ShowDialog();

            GameDataListView.DataSource = Functions.Search("select * from games");
            GameDataListView.ClearSelection();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Tem certeza que deseja deletar este registro?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Functions.Delete(GameDataListView.CurrentRow.Cells["ID"].Value.ToString());
                GameDataListView.DataSource = Functions.Search("select * from games");
                GameDataListView.ClearSelection();
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreditsForm form = new CreditsForm();
            form.ShowDialog();
        }
    }
}
