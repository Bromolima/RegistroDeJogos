using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace RegistroDeJogos
{
    public partial class GameRegistrationForm : Form
    {
        string accessConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public GameRegistrationForm()
        {
            InitializeComponent();
        }

        private List<string> Validatation()
        {
            List<string> Errors = new List<string>();
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                Errors.Add("Campo nome é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                Errors.Add("Campo descrição é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(DeveloperTextBox.Text))
            {
                Errors.Add("Campo desenvolvedora é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(GenreComboBox.Text))
            {
                Errors.Add("Campo gênero é obrigatório");
            }

            if (DateMaskedTextBox.Text == "  /  /")
            {
                Errors.Add("Campo data de publicação é obrigatório");
            }
            else
            {
                try
                {
                    DateTime.Parse(DateMaskedTextBox.Text);
                }
                catch
                {
                    Errors.Add("Data de publicação inválida");
                }
            }


            try
            {
                if (string.IsNullOrWhiteSpace(ScoreTextBox.Text))
                {
                    Errors.Add("Campo nota é obrigatório");
                }
                else
                {
                    float nota = float.Parse(ScoreTextBox.Text);
                    if (nota < 0 || nota > 10)
                    {
                        Errors.Add("Nota inválida (deve ser entre 0 e 10)");
                    }
                }
            }
            catch
            {
                Errors.Add("Nota precisa ser um número");
            }

            return Errors;
        }

        private void SaveGame()
        {
            using (OleDbConnection conection = new OleDbConnection(accessConnectionString))
            {
                conection.Open();

                using (OleDbCommand cmd = conection.CreateCommand())
                {

                    if (IDTextBox.Text == "")
                    {
                        cmd.CommandText = "insert into Games(game_name, description, developer, genre, publicationDate, rating) " +
                                          "values(?, ?, ?, ?, ?, ?)";
                    }
                    else
                    {
                        cmd.CommandText = "update games set " +
                                          "game_name = ?, description = ?, developer = ?, genre = ?, publicationDate = ?, rating = ? where id = " + IDTextBox.Text; 
                    }

                    cmd.Parameters.AddWithValue("?", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("?", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("?", DeveloperTextBox.Text);
                    cmd.Parameters.AddWithValue("?", GenreComboBox.Text);
                    cmd.Parameters.AddWithValue("?", DateMaskedTextBox.Text);
                    cmd.Parameters.AddWithValue("?", ScoreTextBox.Text);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            List<string> errors = Validatation();
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Erros de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveGame();
            MessageBox.Show("Jogo registrado como sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja limpar todos os campos?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            NameTextBox.Text = "";
            DescriptionTextBox.Text = "";
            DeveloperTextBox.Text = "";
            GenreComboBox.Text = "";
            DateMaskedTextBox.Text = "";
            ScoreTextBox.Text = "";
        }

        private void GameRegistrationForm_Load(object sender, EventArgs e)
        {
            if (IDTextBox.Text == "")
            {
                return;
            }

            SaveButton.Text = "Atualizar";
            DataTable dt = Functions.Search("Select * from games where id = " + IDTextBox.Text);


            NameTextBox.Text = dt.Rows[0]["game_name"].ToString();
            DeveloperTextBox.Text = dt.Rows[0]["developer"].ToString();
            DescriptionTextBox.Text = dt.Rows[0]["description"].ToString();
            GenreComboBox.Text = dt.Rows[0]["genre"].ToString();
            DateMaskedTextBox.Text = dt.Rows[0]["publicationDate"].ToString();
            ScoreTextBox.Text = dt.Rows[0]["rating"].ToString();
        }
    }
}
