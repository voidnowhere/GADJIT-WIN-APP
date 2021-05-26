using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GADJIT_WIN_CLIENT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string Cemail;

        private void LabelInscritpion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {          
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Client WHERE CliEmail=@Email and CliPassWord=@pass and CliSta=1", GADJIT.sqlConnection);
            GADJIT.sqlConnection.Open();
            cmd.Parameters.AddWithValue("@pass", TextBoxPassWord.Text);
            cmd.Parameters.AddWithValue("@Email", TexrBoxEmail.Text);
            if ((int) cmd.ExecuteScalar() == 1)
            {
                Cemail = TexrBoxEmail.Text.Trim();
                GADJIT.sqlConnection.Close();
                this.Hide();
                HOME home = new HOME();
                home.ShowDialog();
                this.Show();
                ButtonClear_Click(sender, e);               
            }
            else
            {
                LabelErreur.Visible = true;
                GADJIT.sqlConnection.Close();
            }
            
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TexrBoxEmail.Clear();
            TextBoxPassWord.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LabelErreur.Visible = false;
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void TexrBoxEmail_TextChanged(object sender, EventArgs e)
        {
            TexrBoxEmail.Text = TexrBoxEmail.Text.Trim();
        }
    }
}
