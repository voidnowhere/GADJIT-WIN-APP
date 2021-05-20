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
using System.Text.RegularExpressions;

namespace GADJIT_WIN_CLIENT
{
    public partial class ClientInformation : Form
    {
        public ClientInformation()
        {
            InitializeComponent();
        }

        string passCont = "";
        string emailtemp = "";

        private void ClientInformation_Load(object sender, EventArgs e)
        {
            TextBoxEmail.Text= emailtemp= Login.Cemail;
            ComboxBoxCity.SelectedIndex = 0;
            //
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select CliLastName,CliFirstName,CliPassWord,CliPhoneNumber,CliAdress,CitDesig from Client where CliEmail=@email ", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@email", emailtemp);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBoxNom.Text = dr["CliLastName"].ToString();
                TextBoxPrenom.Text = dr["CliFirstName"].ToString();
                TextBoxTelephone.Text = dr["CliPhoneNumber"].ToString();
                RichTextBoxAdress.Text = dr["CliAdress"].ToString();
                passCont = dr["CliPassWord"].ToString();
                ComboxBoxCity.Text = dr["CitDesig"].ToString();
            }
            dr.Close();
            GADJIT.sqlConnection.Close();
        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Close();
            ClientInformation_Load(sender, e);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPassord.Text==passCont)
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("update Client set" +
                                                   "CliEmail=@email" +
                                                   "CliLastName=@name," +
                                                   "CliFirstName=@prenom," +
                                                   "CliPhoneNumber=@phone," +
                                                   "CliAdress=@adress," +
                                                   "CitDesig=@city " +
                                                   "where CliEmail = @emailtemp", GADJIT.sqlConnection);                 
                    cmd.Parameters.AddWithValue("@name", TextBoxNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", TextBoxPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", TextBoxTelephone.Text.Trim());
                    cmd.Parameters.AddWithValue("@adress", RichTextBoxAdress.Text);
                    cmd.Parameters.AddWithValue("@city", ComboxBoxCity.GetItemText(ComboxBoxCity.SelectedItem));
                    cmd.Parameters.AddWithValue("@emailtemp", emailtemp);
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                    MessageBox.Show("Modification reussite");
                }
                else
                {
                    errorProviderPass.SetError(textBoxPassord, "Mot de passe Incorrect ");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Verifiez vos information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void TextBoxTelephone_Validating(object sender, CancelEventArgs e)
        {
            Regex ex = new Regex("^[0-9]{10}");
            bool isValid = ex.IsMatch(TextBoxTelephone.Text);
            if (!isValid)
            {
                errorProviderTelephone.SetError(TextBoxTelephone, "Entrez un numero de telephone valide ");
            }
            else
            {
                errorProviderTelephone.SetError(TextBoxTelephone, null);
            }
        }

        private void labelshowGroupBox_Click(object sender, EventArgs e)
        {
            if(textBoxPassord.Text == passCont)
            {
                UpdatePassword passupd = new UpdatePassword();
                passupd.ShowDialog();
                errorProviderPass.SetError(textBoxPassord, null);
                ClientInformation_Load(sender,e);
            }
            else
            {
                errorProviderPass.SetError(textBoxPassord, "Pour votre sécurité entrez votre ancien mot de passe");
            }
           
        }
    }
}
