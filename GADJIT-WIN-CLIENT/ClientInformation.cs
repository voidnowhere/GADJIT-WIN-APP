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
        public int CID;
        int cityID;
        private void ClientInformation_Load(object sender, EventArgs e)
        {
            ComboxBoxCity.SelectedIndex = 0;
            getcity();
            //
            SqlCommand cmd = new SqlCommand("select CliLastName,CliFirstName,CliEmail,CliPassWord,CliPhoneNumber,CliAddress,CitID from Client where CliID=@CID ", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBoxEmail.Text = dr["CliEmail"].ToString();
                TextBoxNom.Text = dr["CliLastName"].ToString();
                TextBoxPrenom.Text = dr["CliFirstName"].ToString();
                TextBoxTelephone.Text = dr["CliPhoneNumber"].ToString();
                RichTextBoxAdress.Text = dr["CliAddress"].ToString();
                passCont = dr["CliPassWord"].ToString();
                cityID = (int)dr["CitID"];
                dr.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Close();
            ClientInformation_Load(sender, e);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            getcityid();
            try
            {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("update Client set" +
                                                   "CliEmail=@email" +
                                                   "CliLastName=@name," +
                                                   "CliFirstName=@prenom," +
                                                   "CliPhoneNumber=@phone," +
                                                   "CliAddress=@adress," +
                                                   "CitID=@city " +
                                                   "where CliID = @CID", GADJIT.sqlConnection);                 
                    cmd.Parameters.AddWithValue("@name", TextBoxNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", TextBoxPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", TextBoxTelephone.Text.Trim());
                    cmd.Parameters.AddWithValue("@adress", RichTextBoxAdress.Text);
                    cmd.Parameters.AddWithValue("@city", cityID);
                    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@CID", CID);
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                    MessageBox.Show("Modification reussite");
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
            UpdatePassword passupd = new UpdatePassword();
            passupd.CID = CID;
            passupd.mdp = passCont;
            passupd.ShowDialog();
            ClientInformation_Load(sender, e);
        }
        private void getcity()
        {
            SqlCommand cmd = new SqlCommand("select CitDesig from City where CitID=@CITID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CITID", cityID);
            GADJIT.sqlConnection.Open();
            ComboxBoxCity.SelectedItem = cmd.ExecuteScalar().ToString();
            GADJIT.sqlConnection.Close();
        }
        private void getcityid()
        {
            SqlCommand cmd = new SqlCommand("select CitID from city where CitDesig=@city", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@city", ComboxBoxCity.Text);
            GADJIT.sqlConnection.Open();
            cityID = (int)cmd.ExecuteScalar();
            GADJIT.sqlConnection.Close();
        }
    }
}
