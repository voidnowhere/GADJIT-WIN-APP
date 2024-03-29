﻿using System;
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

        SqlDataReader dr;

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(TextBoxEMail.Text != "" && TextBoxPassWord.Text != "")
            {
                if (GADJIT.IsEmailValid(TextBoxEMail.Text))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                        "select AdmLastName, AdmFirstName, null, AdmID, null, 'A' as Who from Admin where AdmEmail = @email and AdmPassWord = @pass " +
                        "union all " +
                        "select StafLastName, StafFirstName, StafPicture, StafID, StafSta, 'S' as Who from Staff where StafEmail = @email and StafPassWord = @pass " +
                        "UNION all " +
                        "select WorLastName, WorFirstName, WorPicture, WorID, WorSta, 'W' as Who from Worker where WorEmail = @email and WorPassWord = @pass",
                        GADJIT.sqlConnection);
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = TextBoxEMail.Text;
                        cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxPassWord.Text;
                        GADJIT.sqlConnection.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            switch (dr.GetString(5))
                            {
                                case "A":
                                    AdminPanel Admin = new AdminPanel();
                                    Admin.login = this;
                                    Admin.LabelLastName.Text = dr.GetString(0);
                                    Admin.LabelFirstName.Text = dr.GetString(1);
                                    Admin.LabelEmail.Text = TextBoxEMail.Text;
                                    Admin.adminID = dr.GetInt32(3);
                                    //
                                    dr.Close();
                                    GADJIT.sqlConnection.Close();
                                    this.Hide();
                                    Admin.ShowDialog();
                                    break;
                                case "S":
                                    if (dr.GetBoolean(4) == true)
                                    {
                                        StaffPanel Staff = new StaffPanel();
                                        Staff.login = this;
                                        Staff.LabelLastName.Text = dr.GetString(0);
                                        Staff.LabelFirstName.Text = dr.GetString(1);
                                        Staff.LabelEmail.Text = TextBoxEMail.Text;
                                        Staff.CircularProfilPicture.Image = (dr.GetValue(2) == DBNull.Value) ? null : Image.FromStream(new MemoryStream((byte[])dr.GetValue(2)));
                                        Staff.staffID = dr.GetInt32(3);
                                        //
                                        dr.Close();
                                        GADJIT.sqlConnection.Close();
                                        this.Hide();
                                        Staff.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("est desactive", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    break;
                                case "W":
                                    if (dr.GetBoolean(4) == true)
                                    {
                                        WorkerPanel Worker = new WorkerPanel();
                                        Worker.login = this;
                                        Worker.LabelLastName.Text = dr.GetString(0);
                                        Worker.LabelFirstName.Text = dr.GetString(1);
                                        Worker.LabelEmail.Text = TextBoxEMail.Text;
                                        Worker.CircularProfilPicture.Image = (dr.GetValue(2) == DBNull.Value) ? null : Image.FromStream(new MemoryStream((byte[])dr.GetValue(2)));
                                        //Worker.workerID = dr.GetInt32(3);
                                        //
                                        dr.Close();
                                        GADJIT.sqlConnection.Close();
                                        this.Hide();
                                        Worker.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("est desactive", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    break;
                            }
                            TextBoxEMail.Clear();
                            TextBoxPassWord.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Veuillez vérifier vos informations", "Informations Erronées", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur ButtonLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Format d'email incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void TextBoxEMail_TextChanged(object sender, EventArgs e)
        {
            TextBoxEMail.Text = TextBoxEMail.Text.Trim();
        }

        private void TextBoxPassWord_TextChanged(object sender, EventArgs e)
        {
            TextBoxPassWord.Text = TextBoxPassWord.Text.Trim();
        }
    }
}
