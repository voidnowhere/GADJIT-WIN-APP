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
        SqlDataReader dr;
        private Dictionary<int, string> city = new Dictionary<int,string>();
        public HOME home;
        private void ClientInformation_Load(object sender, EventArgs e)
        {
            ComboxBoxCity.SelectedIndex = 0;
            FillComboBoxCity();
            //
            SqlCommand cmd = new SqlCommand("select CliLastName,CliFirstName,CliEmail,CliPassWord,CliPhoneNumber,CliAddress,CitDesig from Client, City where CliID=@CID and Client.CitID = City.CitID ", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                TextBoxEmail.Text = dr["CliEmail"].ToString();
                TextBoxNom.Text = dr["CliLastName"].ToString();
                TextBoxPrenom.Text = dr["CliFirstName"].ToString();
                TextBoxTelephone.Text = dr["CliPhoneNumber"].ToString();
                RichTextBoxAdress.Text = dr["CliAddress"].ToString();
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
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("update Client set " +
                                                   "CliEmail=@email, " +
                                                   "CliLastName=@name, " +
                                                   "CliFirstName=@prenom, " +
                                                   "CliPhoneNumber=@phone, " +
                                                   "CliAddress=@adress, " +
                                                   "CitID=@city " +
                                                   "where CliID = @CID", GADJIT.sqlConnection);                 
                    cmd.Parameters.AddWithValue("@name", TextBoxNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", TextBoxPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", TextBoxTelephone.Text.Trim());
                    cmd.Parameters.AddWithValue("@adress", RichTextBoxAdress.Text);
                    cmd.Parameters.AddWithValue("@city", city.Keys.First(i => city[i]==ComboxBoxCity.Text));
                    cmd.Parameters.AddWithValue("@CID", CID);
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                    MessageBox.Show("Modification reussite");
                    home.lblemail.Text = TextBoxEmail.Text;
                    home.lblPrenom.Text = TextBoxPrenom.Text;
                    home.LblNom.Text = TextBoxNom.Text;
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
        private void FillComboBoxCity()
        {
            ComboxBoxCity.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    ComboxBoxCity.Items.Add("----Votre Ville---");
                    while (dr.Read())
                    {
                        ComboxBoxCity.Items.Add(dr.GetString(1));
                        city.Add(dr.GetInt32(0), dr.GetString(1));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                GADJIT.sqlConnection.Close();
            }
        }
    }
}
