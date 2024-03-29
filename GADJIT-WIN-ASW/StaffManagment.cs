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
using System.Text.RegularExpressions;

namespace GADJIT_WIN_ASW
{
    public partial class StaffManagment : Form
    {
        public StaffManagment()
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
        ColumnComboBoxDisponibility
        ColumnComboBoxStatus
        */

        SqlDataReader dataReader;
        //
        Dictionary<int, string> city = new Dictionary<int, string>();
        bool filledDGV = false;
        bool where = false;
        String status = "";

        private bool CheckDGVCellsIfEmpty()
        {
            if(DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(StafID) from Staff where StafID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIDIfExists(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private int GenerateStaffId()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select MAX(StafID) from Staff", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                return (sqlCommand.ExecuteScalar() == DBNull.Value) ? 0 : int.Parse(sqlCommand.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GetMaxStaffId", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return 0;
        }

        private void FillComboBoxCity()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitID, CitDesig from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    ComboBoxCitySearch.Items.Add("--tous--");
                    //
                    ColumnComboBoxCity.DisplayMember = "CitDesig";
                    ColumnComboBoxCity.ValueMember = "CitID";
                    while (dataReader.Read())
                    {
                        city.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                        //
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(1));
                        //
                        ColumnComboBoxCity.Items.Add(new { CitID = dataReader.GetInt32(0), CitDesig = dataReader.GetString(1) });
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillDGVStaff()
        {
            try
            {
                DGVStaff.Rows.Clear();
                where = false;
                //
                String sqlQuery = "select * from Staff";
                SqlCommand sqlCommand = new SqlCommand();
                if (TextBoxCINSearch.Text != "" || TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != "" 
                    || ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
                {
                    sqlQuery += " where";
                    if (TextBoxCINSearch.Text != "")
                    {
                        sqlQuery += " StafCIN like @cin";
                        sqlCommand.Parameters.Add("@cin", SqlDbType.VarChar).Value = "%" + TextBoxCINSearch.Text + "%";
                        where = true;
                    }
                    if (TextBoxEmailSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " StafEmail like @email";
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = "%" + TextBoxEmailSearch.Text + "%";
                        where = true;
                    }
                    if (TextBoxLastNameSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " StafLastName like @name";
                        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = "%" + TextBoxLastNameSearch.Text + "%";
                        where = true;
                    }
                    if (ComboBoxCitySearch.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " CitID = @city";
                        sqlCommand.Parameters.Add("@city", SqlDbType.Int).Value = city.Keys.First(i => city[i] == ComboBoxCitySearch.Text);
                        where = true;
                    }
                    if (ComboBoxStatusSearch.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " StafSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatusSearch.SelectedIndex == 1) ? true : false;
                    }
                }

                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DGVStaff.Rows.Add(
                            dataReader["StafID"],
                            dataReader["StafCIN"],
                            (dataReader["StafPicture"] == DBNull.Value) ? null : new Bitmap(new MemoryStream((byte[])dataReader["StafPicture"])),
                            dataReader["StafLastName"],
                            dataReader["StafFirstName"],
                            dataReader["StafEmail"],
                            dataReader["StafPassWord"],
                            dataReader["StafPhoneNumber"], 
                            dataReader["StafAddress"],
                            dataReader["CitID"],
                            dataReader["StafSalary"],
                            dataReader["StafDispo"],
                            (dataReader.GetBoolean(12)) ? "Activer" : "Désactiver");
                    }
                    StaffsStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVStaff()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void StaffsStats()
        {
            int c = DGVStaff.Rows.Count - 1;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVStaff[12, i].Value != null)
                {
                    if (DGVStaff[12, i].Value.ToString() == "Activer") a++;
                    else if (DGVStaff[12, i].Value.ToString() == "Désactiver") d++;
                }
            }
            TextBoxActivedStaffs.Text = a.ToString();
            TextBoxDeactivatedStaffs.Text = d.ToString();
            TextBoxTotalStaffs.Text = c.ToString();
        }

        private void GestionStaff_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVStaff();
            filledDGV = true;
        }

        private void DGVStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // ColumnPictureBox
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image |*.jpg; *.jpeg; *.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DGVStaff[2, e.RowIndex].Value = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void DGVStaff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2) // ColumnPictureBox
            {
                if (e.Button == MouseButtons.Right)
                {
                    ImageShow imageShow = new ImageShow();
                    imageShow.PictureBox.Image = (Image)DGVStaff[2, e.RowIndex].Value;
                    imageShow.ShowDialog();
                }
            }
        }

        private void DGVStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.RowIndex < DGVStaff.Rows.Count)
            {
                status = (DGVStaff[12, e.RowIndex].Value != null) ? DGVStaff[12, e.RowIndex].Value.ToString() : "";
            }
        }

        private void DGVStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                if (DGVStaff[6, rowIndex].Value == null)
                {
                    DGVStaff[6, rowIndex].Value = GADJIT.PasswordGenerator(8); //Password
                }
                if (DGVStaff[11, rowIndex].Value == null)
                {
                    DGVStaff[11, rowIndex].Value = "Hors Ligne"; //Disponibility
                }
                if (DGVStaff[12, rowIndex].Value == null)
                {
                    DGVStaff[12, rowIndex].Value = "Activer"; //Status
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (DGVStaff[0, rowIndex].Value != null && e.ColumnIndex != 0) //update
                    {
                        if (CheckIDIfExists((int)DGVStaff[0, rowIndex].Value))
                        {
                            try
                            {
                                string sqlQuery = "update Staff set StafCIN = @cin, StafPicture = @img, StafLastName = @lastName, StafFirstName = @firstName, StafEmail = @email, " +
                                    "StafPassWord = @password, StafPhoneNumber = @phoneNumber, StafAddress = @address, CitID = @city, StafSalary = @salary, " +
                                    "StafSta = @status where StafID = @id";
                                SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                                sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVStaff["ColumnTextBoxID", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                                sqlCommandUpdate.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                                sqlCommandUpdate.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxLastName", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@address", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxAdress", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@city", SqlDbType.Int).Value = (int)DGVStaff["ColumnComboBoxCity", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                                String statusDGV = DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString();
                                sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit).Value = (statusDGV == "Activer") ? 1 : 0;

                                GADJIT.sqlConnection.Open();

                                sqlCommandUpdate.ExecuteNonQuery();

                                MessageBox.Show("Modification réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (status != statusDGV)
                                {
                                    GADJIT.SendEmail(
                                        DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString(),
                                        "Votre compte est " + statusDGV);
                                }

                                StaffsStats();
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
                        else
                        {
                            MessageBox.Show("Ce personnel a été supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            GADJIT.sqlConnection.Close();
                            FillDGVStaff();
                        }
                    }
                    else if(e.ColumnIndex != 0) // insert
                    {
                        try
                        {
                            string sqlQuery = "insert into Staff " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @address, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            int id = GenerateStaffId();
                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.Int).Value = id;

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxFirstName", rowIndex].Value.ToString();
                            
                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@address", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.Int).Value = (int)DGVStaff["ColumnComboBoxCity", rowIndex].Value;

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit).Value = (DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            sqlCommandInsert.ExecuteNonQuery();

                            MessageBox.Show("Ajout réussi", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.SendEmail(
                                DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString(),
                                "Votre compte de personnel a été créé.\nVoici votre mot de passe: "+ 
                                DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString() +
                                "\nVeuillez supprimé cet email.");

                            StaffsStats();

                            DGVStaff[0, e.RowIndex].Value = id;
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

        private bool CheckIfEmailExists(int stafID, string email)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    (stafID == -1) ?
                        "select COUNT(StafEmail) from Staff where StafEmail = @email"
                        :
                        "select COUNT(StafEmail) from Staff where StafID != @stafID and StafEmail = @email",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@stafID", SqlDbType.Int).Value = stafID;
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfEmailExists(int stafID, string email)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVStaff_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.FormattedValue.ToString() != "")
            {
                if (e.ColumnIndex == 1) //CIN
                {
                    if (!GADJIT.IsCINValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVStaff.Rows[e.RowIndex].ErrorText = "format CIN incorrect";
                    }
                    else
                    {
                        DGVStaff.Rows[e.RowIndex].ErrorText = "";
                    }
                }
                else if (e.ColumnIndex == 5) //Email
                {
                    if (!GADJIT.IsEmailValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVStaff.Rows[e.RowIndex].ErrorText = "format d'email incorrect";
                    }
                    else
                    {
                        if (CheckIfEmailExists((DGVStaff[0, e.RowIndex].Value == null) ? -1 : (int)DGVStaff[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                        {
                            e.Cancel = true;
                            DGVStaff.Rows[e.RowIndex].ErrorText = "email existe déjà";
                        }
                        else
                        {
                            DGVStaff.Rows[e.RowIndex].ErrorText = "";
                        }
                    }
                }
                else if(e.ColumnIndex == 10) //Salary
                {
                    if (!GADJIT.IsSalaryValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVStaff.Rows[e.RowIndex].ErrorText = "format du salaire incorrect";
                    }
                    else
                    {
                        DGVStaff.Rows[e.RowIndex].ErrorText = "";
                    }
                }
            }
        }

        private void DGVStaff_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGVStaff.Rows[e.RowIndex].ErrorText = "";
        }

        private bool CheckIfStaffCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(StafID) from Ticket where StafID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfStaffCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVStaff_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(e.Row.Cells[0].Value != null)
            {
                try
                {
                    if (CheckIDIfExists((int)e.Row.Cells[0].Value))
                    {
                        if (CheckIfStaffCanBeDeleted((int)e.Row.Cells[0].Value))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from Staff where StafID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int).Value = (int)e.Row.Cells[0].Value;

                            if (MessageBox.Show("Voulez-vous supprimer ce personnel ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                GADJIT.sqlConnection.Open();

                                sqlCommandDelete.ExecuteNonQuery();

                                MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("Suppression interdit ce personnel est affectée dans des tickets", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error DGVStaff_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void DGVStaff_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            StaffsStats();
        }

        private void DGVStaff_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (DGVStaff.CurrentCell.ColumnIndex)
            {
                case 1: //CIN
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyLetterNumberKeyPressCheck;
                    break;
                case 3: //LastName
                case 4: //FirstName
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyLetterKeyPressCheck;
                    break;
                case 5: //Email
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyEmailCharKeyPressCheck;
                    break;
                case 6: //Password
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    break;
                case 7: //Phone
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyNumberKeyPressCheck;
                    break;
                case 8: //Adress
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    break;
                case 10: //Salary
                    //Clear KeyPressEvents
                    e.Control.KeyPress -= OnlyLetterNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterKeyPressCheck;
                    e.Control.KeyPress -= OnlyEmailCharKeyPressCheck;
                    e.Control.KeyPress -= OnlyNumberKeyPressCheck;
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress -= OnlyDoubleNumberKeyPressCheck;
                    //
                    e.Control.KeyPress += OnlyDoubleNumberKeyPressCheck;
                    break;
            }
        }

        private void OnlyNumberKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("N'entrez que des nombres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyEmailCharKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            // 46 => . && 64 => @ && 45 => - && 95 => _
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) 
                && e.KeyChar != 46 && e.KeyChar != 64 && e.KeyChar != 45 && e.KeyChar != 95
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractère interdit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyDoubleNumberKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
                MessageBox.Show("N'entrez que des nombres décimaux", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyLetterNumberWhiteSpaceKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractère interdit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyLetterNumberKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractère interdit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyLetterKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("N'entrez que des lettres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxCINSearch.Text != "" || TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != ""
                || ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
            {
                FillDGVStaff();
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxCINSearch.Clear();
            TextBoxEmailSearch.Clear();
            TextBoxLastNameSearch.Clear();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVStaff();
        }
    }
}
