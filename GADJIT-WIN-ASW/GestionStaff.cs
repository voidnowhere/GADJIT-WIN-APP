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
using System.IO;

namespace GADJIT_WIN_ASW
{
    public partial class GestionStaff : Form
    {
        public GestionStaff()
        {
            InitializeComponent();
        }

        /*
        ColumnTextBoxID
        ColumnTextBoxCIN
        ColumnPictureBox
        ColumnTextBoxLastName
        ColumnTextBoxFirstName
        ColumnTextBoxEmail
        ColumnTextBoxPassword
        ColumnTextBoxPhoneNumber
        ColumnTextBoxAdress
        ColumnComboBoxCity
        ColumnTextBoxSalary
        ColumnTextBoxDisponibility
        ColumnComboBoxStatus

        StafID StafCIN StafPicture StafLastName StafFirstName StafEmail StafPassWord StafPhoneNumber StafAdress CitDesig StafSalary StafDispo StafSta
        */

        byte i = 0;

        private bool CheckDGVCellsIfEmpty()
        {
            if(DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value != null 
                && DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value != null 
                && DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value != null 
                && DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value != null 
                && DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value != null 
                && DGVStaff["ColumnTextBoxDisponibility", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnComboBoxStatus", DGVStaff.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select StafID from Staff where StafID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                GADJIT.sqlConnection.Open();
                object idFromDB = sqlCommand.ExecuteScalar();
                if(idFromDB != DBNull.Value)
                {
                    if ((string)idFromDB == id)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIDIfExists(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void InsertNewIDInDGV()
        {
            if (DGVStaff.Rows.Count > 0)
            {
                DGVStaff[0, DGVStaff.CurrentRow.Index].Value = GADJIT.IDGenerator((string)DGVStaff[0, DGVStaff.CurrentRow.Index - 1].Value);
            }
            else
            {
                DGVStaff[0, DGVStaff.CurrentRow.Index].Value = GADJIT.IDGenerator("S0");
            }
        }

        private void FillComboBoxCity()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitDesig from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(0));
                        ColumnComboBoxCity.Items.Add(dataReader.GetString(0));
                    }
                }
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillDGVStaff()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Staff", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        String status = (dataReader.GetBoolean(12)) ? "Activer" : "Désactiver";
                        DGVStaff.Rows.Add(dataReader["StafID"], dataReader["StafCIN"], new Bitmap(new MemoryStream((byte[])dataReader["StafPicture"])), dataReader["StafLastName"],
                            dataReader["StafFirstName"], dataReader["StafEmail"], dataReader["StafPassWord"], dataReader["StafPhoneNumber"], 
                            dataReader["StafAdress"], dataReader["CitDesig"], dataReader["StafSalary"], dataReader["StafDispo"], 
                            status);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVStaff()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void GestionStaff_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            FillDGVStaff();
            i = 1;
        }

        private void DGVStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (i == 1)
            {
                if(DGVStaff[0, DGVStaff.CurrentRow.Index].Value == null) // ID
                {
                    InsertNewIDInDGV();
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists(DGVStaff[0, DGVStaff.CurrentRow.Index].Value.ToString())) // update
                    {
                        try
                        {
                            string sqlQuery = "update Staff set StafCIN = @cin, StafPicture = @img, StafLastName = @lastName, StafFirstName = @firstName, StafEmail = @email, " +
                                "StafPassWord = @password, StafPhoneNumber = @phoneNumber, StafAdress = @adress, CitDesig = @city, StafSalary = @salary, StafDispo = @dispo, " +
                                "StafSta = @status where StafID = @id";
                            SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandUpdate.Parameters.Add("@id", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@id"].Value = DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@cin", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@cin"].Value = DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@img", SqlDbType.Image);
                            sqlCommandUpdate.Parameters["@img"].Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", DGVStaff.CurrentRow.Index].Value, typeof(byte[]));

                            sqlCommandUpdate.Parameters.Add("@lastName", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@lastName"].Value = DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@firstName", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@firstName"].Value = DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@email", SqlDbType.NVarChar);
                            sqlCommandUpdate.Parameters["@email"].Value = DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@password", SqlDbType.NVarChar);
                            sqlCommandUpdate.Parameters["@password"].Value = DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@phoneNumber"].Value = DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@adress", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@adress"].Value = DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@city", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@city"].Value = DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money);
                            sqlCommandUpdate.Parameters["@salary"].Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value.ToString());

                            sqlCommandUpdate.Parameters.Add("@dispo", SqlDbType.VarChar);
                            sqlCommandUpdate.Parameters["@dispo"].Value = DGVStaff["ColumnTextBoxDisponibility", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVStaff["ColumnComboBoxStatus", DGVStaff.CurrentRow.Index].Value.ToString();
                            if (status == "Activer")
                            {
                                sqlCommandUpdate.Parameters["@status"].Value = 1;
                            }
                            else if (status == "Désactiver")
                            {
                                sqlCommandUpdate.Parameters["@status"].Value = 0;
                            }

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandUpdate.ExecuteNonQuery() + " réussi", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.sqlConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVStaff_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                    else // insert
                    {
                        try
                        {
                            string sqlQuery = "insert into Staff " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @adress, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@id"].Value = DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@cin"].Value = DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image);
                            sqlCommandInsert.Parameters["@img"].Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", DGVStaff.CurrentRow.Index].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@lastName"].Value = DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@firstName"].Value = DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar);
                            sqlCommandInsert.Parameters["@email"].Value = DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar);
                            sqlCommandInsert.Parameters["@password"].Value = DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@phoneNumber"].Value = DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@adress", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@adress"].Value = DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@city"].Value = DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money);
                            sqlCommandInsert.Parameters["@salary"].Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@dispo"].Value = DGVStaff["ColumnTextBoxDisponibility", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVStaff["ColumnComboBoxStatus", DGVStaff.CurrentRow.Index].Value.ToString();
                            if (status == "Activer")
                            {
                                sqlCommandInsert.Parameters["@status"].Value = 1;
                            }
                            else if(status == "Désactiver")
                            {
                                sqlCommandInsert.Parameters["@status"].Value = 0;
                            }

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsert.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.sqlConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVStaff_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                }
            }
        }

        private void DGVStaff_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void DGVStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image |*.jpg; *.jpeg; *.png;";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    DGVStaff[2, DGVStaff.CurrentRow.Index].Value = Image.FromFile(ofd.FileName);
                }
            }   
        }

        private void DGVStaff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                if(e.Button == MouseButtons.Right)
                {
                    ImageShow imageShow = new ImageShow();
                    imageShow.PictureBox.Image = (Image)DGVStaff[2, DGVStaff.CurrentRow.Index].Value;
                    imageShow.ShowDialog();
                }
            }
        }
    }
}
