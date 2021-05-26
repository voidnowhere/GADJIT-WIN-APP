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

        StafID StafCIN StafPicture StafLastName StafFirstName StafEmail StafPassWord StafPhoneNumber StafAdress CitDesig StafSalary StafDispo StafSta
        */

        SqlDataReader dataReader;
        //
        bool filledDGV = false;
        bool where = false;

        private bool CheckDGVCellsIfEmpty()
        {
            if(DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value != null
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

        private void InsertNewIDInDGV()
        {
            if (DGVStaff.Rows.Count > 2)
            {
                DGVStaff[0, DGVStaff.CurrentRow.Index].Value = (int)DGVStaff[0, DGVStaff.CurrentRow.Index - 1].Value + 1;
            }
            else
            {
                DGVStaff[0, DGVStaff.CurrentRow.Index].Value = 0;
            }
        }

        private void FillComboBoxCity()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitDesig from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    ComboBoxCitySearch.Items.Add("--tous--");
                    while (dataReader.Read())
                    {
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(0));
                        ColumnComboBoxCity.Items.Add(dataReader.GetString(0));
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
                    DGVStaff.AllowUserToAddRows = false;
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
                        sqlQuery += " CitDesig = @city";
                        sqlCommand.Parameters.Add("@city", SqlDbType.VarChar).Value = ComboBoxCitySearch.Text;
                        where = true;
                    }
                    if (ComboBoxStatusSearch.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " StafSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatusSearch.SelectedIndex == 1) ? true : false;
                    }
                }
                else
                {
                    DGVStaff.AllowUserToAddRows = true;
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DGVStaff.Rows.Add(dataReader["StafID"],
                            dataReader["StafCIN"],
                            (dataReader["StafPicture"] == DBNull.Value) ? null : new Bitmap(new MemoryStream((byte[])dataReader["StafPicture"])),
                            dataReader["StafLastName"],
                            dataReader["StafFirstName"],
                            dataReader["StafEmail"],
                            dataReader["StafPassWord"],
                            dataReader["StafPhoneNumber"], 
                            dataReader["StafAddress"],
                            dataReader["CitDesig"],
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
            int c = (DGVStaff.AllowUserToAddRows) ? DGVStaff.Rows.Count - 1 : DGVStaff.Rows.Count;
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

        private void DGVStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                if (DGVStaff[0, rowIndex].Value == null) // ID
                {
                    InsertNewIDInDGV();
                    DGVStaff[6, rowIndex].Value = GADJIT.PasswordGenerator(8); //Password
                    DGVStaff[11, rowIndex].Value = "Hors Ligne"; //Disponibility
                    DGVStaff[12, rowIndex].Value = "Activer"; //Status
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists((int)DGVStaff[0, rowIndex].Value)) //update
                    {
                        try
                        {
                            string sqlQuery = "update Staff set StafCIN = @cin, StafPicture = @img, StafLastName = @lastName, StafFirstName = @firstName, StafEmail = @email, " +
                                "StafPassWord = @password, StafPhoneNumber = @phoneNumber, StafAddress = @address, CitDesig = @city, StafSalary = @salary, " +
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

                            sqlCommandUpdate.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit).Value = (DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandUpdate.ExecuteNonQuery() + " réussi", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    else // insert
                    {
                        try
                        {
                            string sqlQuery = "insert into Staff " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @address, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVStaff["ColumnTextBoxID", rowIndex].Value;

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxFirstName", rowIndex].Value.ToString();
                            
                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@address", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit).Value = (DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsert.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.SendEmail(
                                DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString(),
                                "Votre compte de personnel a été créé.\nVoici votre mot de passe: "+ 
                                DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString() +
                                "\nVeuillez supprimé cet email.");

                            StaffsStats();
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

        private bool CheckIfEmailExists(string email, string stafID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    "select COUNT(StafEmail) from Staff where StafID != @stafID and StafEmail = @email",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@stafID", SqlDbType.NVarChar).Value = stafID;
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfEmailExists(string email, string stafID)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVStaff_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.FormattedValue != null && (e.RowIndex < ((DGVStaff.AllowUserToAddRows) ? DGVStaff.Rows.Count - 1 : DGVStaff.Rows.Count)))
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
                        if (CheckIfEmailExists(e.FormattedValue.ToString(), DGVStaff[0, e.RowIndex].Value.ToString()))
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

        private bool CheckIfStaffCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(StafID) from Ticket where StafID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() >= 1)
                {
                    return false;
                }
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

                            if (MessageBox.Show("Voulez vous supprimer ce personnel", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                GADJIT.sqlConnection.Open();
                                MessageBox.Show(sqlCommandDelete.ExecuteNonQuery() + " réussi", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("interdit ce personnel est affecté dans des tickets", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            FillDGVStaff();
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
