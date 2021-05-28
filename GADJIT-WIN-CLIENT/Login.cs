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
        string check;

        private void LabelInscritpion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {          
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Client WHERE CliEmail=@Email and CliPassWord=@pass", GADJIT.sqlConnection);
            GADJIT.sqlConnection.Open();
            cmd.Parameters.AddWithValue("@pass", TextBoxPassWord.Text);
            cmd.Parameters.AddWithValue("@Email", TexrBoxEmail.Text);
            if ((int) cmd.ExecuteScalar() == 1)
            {
                Cemail = TexrBoxEmail.Text.Trim();
                cmd = new SqlCommand("select CliID, CliSta, CliFirstName, CliLastName,CliVerCod from Client where CliEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email",Cemail);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.IsDBNull(4))
                {
                    if (dr.GetBoolean(1) == true)
                    {
                        this.Hide();
                        HOME home = new HOME();
                        home.CID = dr.GetInt32(0);
                        home.lblemail.Text = Cemail;
                        home.lblPrenom.Text = dr.GetString(2);
                        home.LblNom.Text = dr.GetString(3);
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                        this.Hide();
                        home.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Votre compte est desactive pour plus d'information contacte le service clienttelle", "compte desactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    EmailVerification v = new EmailVerification();
                    v.email = Cemail;
                    v.nom = dr.GetString(3);
                    v.CID = dr.GetInt32(0);
                    GADJIT.sqlConnection.Close();
                    Random random = new Random();
                    int num = random.Next(6, 8);
                    int total = 0;
                    do
                    {
                        int chr = random.Next(48, 123);
                        if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                        {
                            check = check + (char)chr;
                            total++;
                            if (total == num)
                                break;
                            {

                            }
                        }
                    } while (true);
                    v.check = check;
                    v.ShowDialog();
                }
                
         
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
