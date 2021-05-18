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
using System.IO;
using System.Text.RegularExpressions;

namespace GADJIT_WIN_CLIENT
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        String ID = "C";

        private void Register_Load(object sender, EventArgs e)
        {
            TextBoxPassword.PasswordChar = '*';
            TextBoxPassword.MaxLength = 16;
            ComboxBoxCity.SelectedIndex = 0;
            //Captcha
            Random random = new Random();
            int num = random.Next(6, 8);
            string captcha = "";
            int total = 0;
            do
            {
                int chr = random.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    total++;
                    if (total == num)
                        break;
                    {

                    }
                }
            } while (true);
            LabelCaptcha.Text = captcha;
            //
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select max(CliID) from client ", GADJIT.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                ID += (Convert.ToInt32(Regex.Match(dr.GetString(0), @"[0-9]").ToString()) + 1).ToString();
            }
            catch
            {
                ID = "C0";
            }
            
            GADJIT.sqlConnection.Close();
            dr.Close();

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBoxNom.Clear();
            TextBoxPrenom.Clear();
            TextBoxEmail.Clear();
            TextBoxPassword.Clear();
            TextBoxConfPassword.Clear();
            TextBoxPhone.Clear();
            RichTextBoxAdress.Clear();
            TextBoxCaptcha.Clear();
            ComboxBoxCity.SelectedIndex = 0;
            
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void LabelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            if (LabelCaptcha.Text == TextBoxCaptcha.Text.Trim())
            {
                try
                {
                    if (ComboxBoxCity.SelectedIndex != 0)
                    {
                        errorProviderCity.SetError(ComboxBoxCity, null);
                        SqlCommand cmd = new SqlCommand("insert into client values(@ClientID,@LastName,@FirstName,@Email,@PassWord,@PhoneNumber,@Adress,@City,1)", GADJIT.sqlConnection);
                        cmd.Parameters.AddWithValue("@ClientID", ID);
                        cmd.Parameters.AddWithValue("@LastName", TextBoxNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@FirstName", TextBoxPrenom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@PassWord", TextBoxPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhoneNumber", TextBoxPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Adress", RichTextBoxAdress.Text);
                        cmd.Parameters.AddWithValue("@City", ComboxBoxCity.GetItemText(ComboxBoxCity.SelectedItem));
                        cmd.ExecuteNonQuery();
                        errorProviderCaptcha.SetError(TextBoxCaptcha, null);
                        errorProviderEmail.SetError(TextBoxEmail, null);
                        MessageBox.Show("Inscription reussite", "Inscritpion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        errorProviderCity.SetError(ComboxBoxCity, "Vous devez choisir une ville");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show( ex.Message, "Verifiez vos information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        
                }             
                                       
            }
            else
            {
                errorProviderCaptcha.SetError(TextBoxCaptcha, "Captcha pas correcte");
                this.OnLoad(e);
            }
            GADJIT.sqlConnection.Close();
        }

        private void TextBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            Regex ex = new Regex("^[0-9]{10}");
            bool isValid = ex.IsMatch(TextBoxPhone.Text);
            if (!isValid)
            {
                errorProviderTelephone.SetError(TextBoxPhone, "Entrez un numero de telephone valide ");
            }
            else
            {
                errorProviderTelephone.SetError(TextBoxPhone, null);
            }
        }

        private void TextBoxConfPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxConfPassword.Text)
            {
                errorProviderPasswordConfirmation.SetError(TextBoxConfPassword, "mot de passe n'est pas identique");
            }
            else
            {
                errorProviderPasswordConfirmation.SetError(TextBoxConfPassword, null);
            }
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
