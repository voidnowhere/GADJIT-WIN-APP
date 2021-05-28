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
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_CLIENT
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        int ID;
        int cityID;
        string check;
        public static string emailC;
        public static string NomC;
        SqlDataReader dataReader;

        private void Register_Load(object sender, EventArgs e)
        {
            TextBoxPassword.PasswordChar = '*';
            TextBoxPassword.MaxLength = 16;
            FillComboBoxCity();
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
            //verification code
            random = new Random();
            num = random.Next(6, 8);
            total = 0;
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
            if (LabelCaptcha.Text == TextBoxCaptcha.Text.Trim())
            {
                try
                {
                    if (ComboxBoxCity.SelectedIndex != 0)
                    {
                        emailC = TextBoxEmail.Text;
                        NomC = TextBoxNom.Text;
                        SqlCommand cmd = new SqlCommand("select max(CliID) from Client ", GADJIT.sqlConnection);
                        GADJIT.sqlConnection.Open();
                        if (cmd.ExecuteScalar() != DBNull.Value)
                        {
                            ID = (int)cmd.ExecuteScalar() + 1;
                        }
                        else
                        {
                            ID = 0;
                        }
                        GADJIT.sqlConnection.Close();
                        try
                        {
                            getcityid();
                            //
                            errorProviderCity.SetError(ComboxBoxCity, null);
                            errorProviderCaptcha.SetError(TextBoxCaptcha, null);
                            errorProviderEmail.SetError(TextBoxEmail, null);
                            cmd = new SqlCommand("insert into client values(@ClientID,@LastName,@FirstName,@Email,@PassWord,@PhoneNumber,@Adress,@City,1,null)", GADJIT.sqlConnection);
                            cmd.Parameters.AddWithValue("@ClientID", ID);
                            cmd.Parameters.AddWithValue("@LastName", TextBoxNom.Text.Trim());
                            cmd.Parameters.AddWithValue("@FirstName", TextBoxPrenom.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@PassWord", TextBoxPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@PhoneNumber", TextBoxPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("@Adress", RichTextBoxAdress.Text);
                            cmd.Parameters.AddWithValue("@City", cityID);
                            GADJIT.sqlConnection.Open();
                            cmd.ExecuteNonQuery();
                            GADJIT.sqlConnection.Close();
                            EmailVerification v = new EmailVerification();
                            v.email = TextBoxEmail.Text;
                            v.nom = TextBoxNom.Text;
                            v.CID = ID;
                            v.check = check;
                            v.ShowDialog();
                            //
                            GADJIT.SendEmail(TextBoxEmail.Text, "Bonjour " + TextBoxNom.Text + " :\nvotre inscription a bien été traitée bienvenue chez GADJIT. \nGADJIT MAROC.");
                            MessageBox.Show("Inscription réussite", "Inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message,"Email non valider");
                        }
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
                    MessageBox.Show( ex.Message, "Veuillez vérifier vos informations", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        
                }             
                                       
            }
            else
            {
                errorProviderCaptcha.SetError(TextBoxCaptcha, "Captcha incorrect");
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
                errorProviderTelephone.SetError(TextBoxPhone, "Entrez un numéro de téléphone valide ");
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
                errorProviderPasswordConfirmation.SetError(TextBoxConfPassword, "Les mots de passe saisis ne sont pas identiques");
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

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            TextBoxEmail.Text = TextBoxEmail.Text.Trim();
        }
        private void getcityid()
        {
            SqlCommand cmd = new SqlCommand("select CitID from City where CitDesig=@city ", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@city", ComboxBoxCity.Text);
            GADJIT.sqlConnection.Open();
            cityID = (int)cmd.ExecuteScalar();
            GADJIT.sqlConnection.Close();
        }
        private void FillComboBoxCity()
        {
            ComboxBoxCity.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitDesig from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    ComboxBoxCity.Items.Add("----Votre Ville---");
                    while (dataReader.Read())
                    {
                        ComboxBoxCity.Items.Add(dataReader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }
    }
}
