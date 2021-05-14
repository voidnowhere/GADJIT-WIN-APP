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
        ColumnComboBoxDisponibility
        ColumnComboBoxStatus

        StafID StafCIN StafPicture StafLastName StafFirstName StafEmail StafPassWord StafPhoneNumber StafAdress CitDesig StafSalary StafDispo StafSta
        */

        byte i = 0;

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
            if (DGVStaff.Rows.Count > 2)
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

        private void DGVStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image |*.jpg; *.jpeg; *.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DGVStaff[2, DGVStaff.CurrentRow.Index].Value = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void DGVStaff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                if (e.Button == MouseButtons.Right)
                {
                    ImageShow imageShow = new ImageShow();
                    imageShow.PictureBox.Image = (Image)DGVStaff[2, DGVStaff.CurrentRow.Index].Value;
                    imageShow.ShowDialog();
                }
            }
        }

        private void DGVStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (i == 1)
            {
                if(DGVStaff[0, rowIndex].Value == null) // ID
                {
                    InsertNewIDInDGV();
                    DGVStaff[11, rowIndex].Value = "Hors Ligne"; //Disponibility
                    DGVStaff[12, rowIndex].Value = "Désactiver"; //Status
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists(DGVStaff[0, rowIndex].Value.ToString())) // update
                    {
                        try
                        {
                            string sqlQuery = "update Staff set StafCIN = @cin, StafPicture = @img, StafLastName = @lastName, StafFirstName = @firstName, StafEmail = @email, " +
                                "StafPassWord = @password, StafPhoneNumber = @phoneNumber, StafAdress = @adress, CitDesig = @city, StafSalary = @salary, StafDispo = @dispo, " +
                                "StafSta = @status where StafID = @id";
                            SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandUpdate.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandUpdate.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandUpdate.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@adress", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandUpdate.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString();
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

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVStaff["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@adress", SqlDbType.VarChar).Value = DGVStaff["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVStaff["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVStaff["ColumnComboBoxStatus", rowIndex].Value.ToString();
                            if (status == "Activer")
                            {
                                sqlCommandInsert.Parameters["@status"].Value = 1;
                            }
                            else if (status == "Désactiver")
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
    }
}
