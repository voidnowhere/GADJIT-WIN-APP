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
using System.IO;

namespace GADJIT_WIN_ASW
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            TextBoxPassWord.PasswordChar = '*';
            TextBoxPassWord.MaxLength = 16;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select AdmLastName, AdmFirstName, AdmEmail, null, AdmID, null, 'A' as Who from Admin where AdmEmail = @Email and AdmPassWord = @Pass " +
                "UNION ALL " +
                "SELECT StafLastName, StafFirstName, StafEmail, StafPicture, StafID, StafSta, 'S' as Who FROM Staff where StafEmail = @Email and StafPassWord = @Pass " +
                "UNION ALL " +
                "SELECT WorLastName, WorFirstName, WorEmail, WorPicture, WorID, WorSta, 'W' as Who FROM Worker where WorEmail = @Email and WorPassWord = @Pass", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", TextBoxEMail.Text);
            cmd.Parameters.AddWithValue("@Pass", TextBoxPassWord.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();              
                switch(dr.GetString(6))
                {
                    case "A":
                        AdminPanel Admin = new AdminPanel();
                        Admin.login = this;
                        //
                        Admin.LabelLastName.Text = dr.GetString(0);
                        Admin.LabelFirstName.Text = dr.GetString(1);
                        Admin.LabelEmail.Text = dr.GetString(2);
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                        //
                        this.Hide();
                        Admin.ShowDialog();
                        break;
                    case "S":
                        if (dr.GetBoolean(5) == true)
                        {
                            StaffPanel Staff = new StaffPanel();
                            Staff.login = this;
                            Staff.LabelLastName.Text = dr.GetString(0);
                            Staff.LabelFirstName.Text = dr.GetString(1);
                            Staff.LabelEmail.Text = dr.GetString(2);
                            Staff.CircularProfilPicture.Image = (dr.GetValue(3) == DBNull.Value) ? null : Image.FromStream(new MemoryStream((byte[])dr.GetValue(3)));
                            dr.Close();
                            GADJIT.sqlConnection.Close();
                            this.Hide();
                            Staff.ShowDialog();
                        }
                        else
                        {
                            dr.Close();
                            GADJIT.sqlConnection.Close();
                            MessageBox.Show("votre compte est desactive", "compte desactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case "W":
                        if (dr.GetBoolean(5) == true)
                        {
                            WorkerPanel Worker = new WorkerPanel();
                            Worker.LabelLastName.Text = dr.GetString(0);
                            Worker.LabelFirstName.Text = dr.GetString(1);
                            Worker.LabelEmail.Text = dr.GetString(2);
                            Worker.CircularProfilPicture.Image = (dr.GetValue(3) == DBNull.Value) ? null : Image.FromStream(new MemoryStream((byte[])dr.GetValue(3)));
                            dr.Close();
                            GADJIT.sqlConnection.Close();
                            Worker.ShowDialog();
                        }
                        else
                        {
                            dr.Close();
                            GADJIT.sqlConnection.Close();
                            MessageBox.Show("votre compte est desactive", "compte desactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
                TextBoxEMail.Clear();
                TextBoxPassWord.Clear();                                
            }
            else
            {
                dr.Close();
                GADJIT.sqlConnection.Close();
                MessageBox.Show( "Veuillez vérifier vos informations", "Informations Erronées", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
