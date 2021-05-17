using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_ASW
{
    public partial class WorkerManagment : Form
    {
        public WorkerManagment()
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
        ColumnSpecialty
        ColumnComboBoxDisponibility
        ColumnComboBoxStatus

        WorID WorCIN WorPicture WorLastName WorFirstName WorEmail WorPassWord WorPhoneNumber WorAdress WorDesig WorSalary WorDispo WorSta
        */

        SqlDataReader dataReader;
        //
        bool filledDGV = false;
        bool where = false;

        private bool CheckDGVCellsIfEmpty()
        {
            if (DGVWorker["ColumnTextBoxID", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxCIN", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxLastName", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxFirstName", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxEmail", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxPassword", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxPhoneNumber", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxAdress", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnComboBoxCity", DGVWorker.CurrentRow.Index].Value != null
                && DGVWorker["ColumnTextBoxSalary", DGVWorker.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select WorID from Worker where WorID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                GADJIT.sqlConnection.Open();
                object idFromDB = sqlCommand.ExecuteScalar();
                if (idFromDB != DBNull.Value)
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
            if (DGVWorker.Rows.Count > 2)
            {
                DGVWorker[0, DGVWorker.CurrentRow.Index].Value = GADJIT.IDGenerator((string)DGVWorker[0, DGVWorker.CurrentRow.Index - 1].Value);
            }
            else
            {
                DGVWorker[0, DGVWorker.CurrentRow.Index].Value = GADJIT.IDGenerator("W0");
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
                    ComboBoxCitySearch.Items.Add("--choisissez--");
                    while (dataReader.Read())
                    {
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(0));
                        ColumnComboBoxCity.Items.Add(dataReader.GetString(0));
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

        private void FillDGVWorker()
        {
            try
            {
                DGVWorker.Rows.Clear();
                where = false;
                //
                String sqlQuery = "select * from Worker";
                SqlCommand sqlCommand = new SqlCommand();
                if (TextBoxCINSearch.Text != "" || TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != ""
                    || ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
                {
                    DGVWorker.AllowUserToAddRows = false;
                    sqlQuery += " where";
                    if (TextBoxCINSearch.Text != "")
                    {
                        sqlQuery += " WorCIN like @cin";
                        sqlCommand.Parameters.Add("@cin", SqlDbType.VarChar).Value = "%" + TextBoxCINSearch.Text + "%";
                        where = true;
                    }
                    if (TextBoxEmailSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " WorEmail like @email";
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = "%" + TextBoxEmailSearch.Text + "%";
                        where = true;
                    }
                    if (TextBoxLastNameSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " WorLastName like @name";
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
                        sqlQuery += " WorSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatusSearch.SelectedIndex == 1) ? 1 : 0;
                    }
                }
                else
                {
                    DGVWorker.AllowUserToAddRows = true;
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        String status = (dataReader.GetBoolean(12)) ? "Activer" : "Désactiver";
                        DGVWorker.Rows.Add(dataReader["WorID"], dataReader["WorCIN"], new Bitmap(new MemoryStream((byte[])dataReader["WorPicture"])),
                            dataReader["WorLastName"], dataReader["WorFirstName"], dataReader["WorEmail"], dataReader["WorPassWord"], 
                            dataReader["WorPhoneNumber"], dataReader["WorAdress"], dataReader["CitDesig"], dataReader["WorSalary"], null,
                            dataReader["WorDispo"],
                            status);
                    }
                }
                WorkersStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVWorker()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void WorkersStats()
        {
            int c = (DGVWorker.AllowUserToAddRows) ? DGVWorker.Rows.Count - 1 : DGVWorker.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVWorker[13, i].Value.ToString() == "Activer") a++;
                else if (DGVWorker[13, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxActivedStaffs.Text = a.ToString();
            TextBoxDeactivatedStaffs.Text = d.ToString();
            TextBoxTotalStaffs.Text = c.ToString();
        }

        private void WorkerManagment_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVWorker();
            filledDGV = true;
        }

        private void DGVWorker_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // ColumnPictureBox
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image |*.jpg; *.jpeg; *.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DGVWorker[2, e.RowIndex].Value = Image.FromFile(ofd.FileName);
                }
            }
            else if(e.ColumnIndex == 11) // Speciality
            {
                WorkerSpeciality workerSpeciality = new WorkerSpeciality();
                workerSpeciality.workerID = DGVWorker[0, e.RowIndex].Value.ToString();
                workerSpeciality.ShowDialog();
            }
        }

        private void DGVWorker_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2) // ColumnPictureBox
            {
                if (e.Button == MouseButtons.Right)
                {
                    ImageShow imageShow = new ImageShow();
                    imageShow.PictureBox.Image = (Image)DGVWorker[2, e.RowIndex].Value;
                    imageShow.ShowDialog();
                }
            }
        }

        private void DGVWorker_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (filledDGV)
            {
                if (DGVWorker[0, rowIndex].Value == null) // ID
                {
                    InsertNewIDInDGV();
                    DGVWorker[12, rowIndex].Value = "Hors Ligne"; //Disponibility
                    DGVWorker[13, rowIndex].Value = "Désactiver"; //Status
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists(DGVWorker[0, rowIndex].Value.ToString())) // update
                    {
                        try
                        {
                            string sqlQuery = "update Worker set WorCIN = @cin, WorPicture = @img, WorLastName = @lastName, WorFirstName = @firstName, WorEmail = @email, " +
                                "WorPassWord = @password, WorPhoneNumber = @phoneNumber, WorAdress = @adress, CitDesig = @city, WorSalary = @salary, WorDispo = @dispo, " +
                                "WorSta = @status where WorID = @id";
                            SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandUpdate.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandUpdate.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVWorker["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandUpdate.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@adress", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVWorker["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVWorker["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandUpdate.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVWorker["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVWorker["ColumnComboBoxStatus", rowIndex].Value.ToString();
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

                            WorkersStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVWorker_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string sqlQuery = "insert into Worker " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @adress, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVWorker["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@adress", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.VarChar).Value = DGVWorker["ColumnComboBoxCity", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVWorker["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVWorker["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVWorker["ColumnComboBoxStatus", rowIndex].Value.ToString();
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

                            WorkersStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVWorker_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            switch (DGVWorker.CurrentCell.ColumnIndex)
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
            FillDGVWorker();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxCINSearch.Clear();
            TextBoxEmailSearch.Clear();
            TextBoxLastNameSearch.Clear();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVWorker();
        }
    }
}
