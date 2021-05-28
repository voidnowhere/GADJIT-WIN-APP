using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace GADJIT_WIN_CLIENT
{
    public partial class EmailVerification : Form
    {
        public EmailVerification()
        {
            InitializeComponent();
        }
        public string check ;
        public int CID;
        public string email;
        public string nom;
        private void EmailVerification_Load(object sender, EventArgs e)
        {
            MessageBox.Show(check);
            SqlCommand cmd = new SqlCommand("update Client set CliVerCod=@code where CliID=@CID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@code", check);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            GADJIT.SendEmail(email, "Bonjour " + nom + ":\nVotre CODE de verification est : " + check + " \nGADJIT MAROC.");
            MessageBox.Show("un email de verification d'inscription a été envoyer a votre boite mail", "mail envoyez",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if(check == textBox1.Text)
            {
                SqlCommand cmd = new SqlCommand("update Client set CliVerCod=null where CliID=@CID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CID", CID);
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("code incorrect nouveau code a été  envoyer");
                EmailVerification_Load(sender,e);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
