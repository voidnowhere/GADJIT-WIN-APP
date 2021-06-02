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
        */

        SqlDataReader dataReader;
        //
        Dictionary<int, string> city = new Dictionary<int, string>();
        bool filledDGV = false;
        bool where = false;
        String status = "";

        private bool CheckDGVCellsIfEmpty()
        {
            if (DGVWorker["ColumnTextBoxCIN", DGVWorker.CurrentRow.Index].Value != null
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

        private bool CheckIDIfExists(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(WorID) from Worker where WorID = @id", GADJIT.sqlConnection);
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

        private int GenerateWorkerId()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select MAX(WorID) from Worker", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                return (sqlCommand.ExecuteScalar() == DBNull.Value) ? 0 : int.Parse(sqlCommand.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GenerateWorkerId", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sqlQuery += " CitID = @city";
                        sqlCommand.Parameters.Add("@city", SqlDbType.Int).Value = city.Keys.First(i => city[i] == ComboBoxCitySearch.Text);
                        where = true;
                    }
                    if (ComboBoxStatusSearch.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " WorSta = @sta";
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
                        DGVWorker.Rows.Add(
                            dataReader["WorID"],
                            dataReader["WorCIN"],
                            (dataReader["WorPicture"] == DBNull.Value) ? null : new Bitmap(new MemoryStream((byte[])dataReader["WorPicture"])),
                            dataReader["WorLastName"],
                            dataReader["WorFirstName"],
                            dataReader["WorEmail"],
                            dataReader["WorPassWord"], 
                            dataReader["WorPhoneNumber"],
                            dataReader["WorAddress"],
                            dataReader["CitID"],
                            dataReader["WorSalary"], null,
                            dataReader["WorDispo"],
                            (dataReader.GetBoolean(12)) ? "Activer" : "Désactiver");
                    }
                    WorkersStats();
                }
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
            int c = DGVWorker.Rows.Count - 1;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVWorker[13, i].Value != null)
                {
                    if (DGVWorker[13, i].Value.ToString() == "Activer") a++;
                    else if (DGVWorker[13, i].Value.ToString() == "Désactiver") d++;
                }
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
                if (DGVWorker[0, e.RowIndex].Value != null && CheckIDIfExists((int)DGVWorker[0, e.RowIndex].Value))
                {
                    WorkerSpeciality workerSpeciality = new WorkerSpeciality();
                    workerSpeciality.workerID = (int)DGVWorker[0, e.RowIndex].Value;
                    workerSpeciality.ShowDialog();
                }
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

        private void DGVWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < DGVWorker.Rows.Count)
            {
                status = (DGVWorker[13, e.RowIndex].Value != null) ? DGVWorker[13, e.RowIndex].Value.ToString() : "";
            }
        }

        private void DGVWorker_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (filledDGV)
            {
                if (DGVWorker[6, rowIndex].Value == null)
                {
                    DGVWorker[6, rowIndex].Value = GADJIT.PasswordGenerator(8); //Password
                }
                if (DGVWorker[12, rowIndex].Value == null)
                {
                    DGVWorker[12, rowIndex].Value = "Hors Ligne"; //Disponibility
                }
                if (DGVWorker[13, rowIndex].Value == null)
                {
                    DGVWorker[13, rowIndex].Value = "Activer"; //Status
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (DGVWorker[0, rowIndex].Value != null && e.ColumnIndex != 0) //update
                    {
                        if (CheckIDIfExists((int)DGVWorker[0, rowIndex].Value))
                        {
                            try
                            {
                                string sqlQuery = "update Worker set WorCIN = @cin, WorPicture = @img, WorLastName = @lastName, WorFirstName = @firstName, WorEmail = @email, " +
                                    "WorPassWord = @password, WorPhoneNumber = @phoneNumber, WorAddress = @address, CitID = @city, WorSalary = @salary, " +
                                    "WorSta = @status where WorID = @id";
                                SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                                sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVWorker["ColumnTextBoxID", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                                sqlCommandUpdate.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVWorker["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                                sqlCommandUpdate.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxLastName", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxPassword", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@address", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxAdress", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@city", SqlDbType.Int).Value = (int)DGVWorker["ColumnComboBoxCity", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVWorker["ColumnTextBoxSalary", rowIndex].Value.ToString());

                                String statusDGV = DGVWorker["ColumnComboBoxStatus", rowIndex].Value.ToString();
                                sqlCommandUpdate.Parameters.Add("@status", SqlDbType.Bit).Value = (DGVWorker["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                                GADJIT.sqlConnection.Open();

                                sqlCommandUpdate.ExecuteNonQuery();

                                MessageBox.Show("Modification réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (status != statusDGV)
                                {
                                    GADJIT.SendEmail(
                                        DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString(),
                                        "Votre compte est " + statusDGV);
                                }

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
                        else
                        {
                            MessageBox.Show("Ce technicien a été supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            GADJIT.sqlConnection.Close();
                            FillDGVWorker();
                        }
                    }
                    else if(e.ColumnIndex != 0) //insert
                    {
                        try
                        {
                            string sqlQuery = "insert into Worker " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @address, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            int id = GenerateWorkerId();
                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.Int).Value = id;

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxCIN", rowIndex].Value.ToString().ToUpper();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image).Value = (byte[])new ImageConverter().ConvertTo(DGVWorker["ColumnPictureBox", rowIndex].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxLastName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxFirstName", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar).Value = DGVWorker["ColumnTextBoxPassword", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxPhoneNumber", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@address", SqlDbType.VarChar).Value = DGVWorker["ColumnTextBoxAdress", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.Int).Value = (int)DGVWorker["ColumnComboBoxCity", rowIndex].Value;

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money).Value = Convert.ToDecimal(DGVWorker["ColumnTextBoxSalary", rowIndex].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar).Value = DGVWorker["ColumnComboBoxDisponibility", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit).Value = (DGVWorker["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            sqlCommandInsert.ExecuteNonQuery();

                            MessageBox.Show("Ajout réussi", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.SendEmail(
                                DGVWorker["ColumnTextBoxEmail", rowIndex].Value.ToString(),
                                "Votre compte d'employé a été créé.\nVoici votre mot de passe: " +
                                DGVWorker["ColumnTextBoxPassword", rowIndex].Value.ToString() +
                                "\nVeuillez supprimé cet email.");

                            GADJIT.sqlConnection.Close();

                            WorkersStats();

                            DGVWorker[0, e.RowIndex].Value = id;
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

        private bool CheckIfEmailExists(int worID, string email)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    (worID == -1) ?
                    "select COUNT(WorEmail) from Worker where WorEmail = @email"
                    :
                    "select COUNT(WorEmail) from Worker where WorID != @worID and WorEmail = @email",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@worID", SqlDbType.Int).Value = worID;
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfEmailExists(int worID, string email)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVWorker_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue != null)
            {
                if (e.ColumnIndex == 1) //CIN
                {
                    if (!GADJIT.IsCINValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVWorker.Rows[e.RowIndex].ErrorText = "format CIN incorrect";
                    }
                    else
                    {
                        DGVWorker.Rows[e.RowIndex].ErrorText = "";
                    }
                }
                else if (e.ColumnIndex == 5) //Email
                {
                    if (!GADJIT.IsEmailValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVWorker.Rows[e.RowIndex].ErrorText = "format d'email incorrect";
                    }
                    else
                    {
                        if (CheckIfEmailExists((DGVWorker[0, e.RowIndex].Value == null) ? -1 : (int)DGVWorker[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                        {
                            e.Cancel = true;
                            DGVWorker.Rows[e.RowIndex].ErrorText = "email existe déjà";
                        }
                        else
                        {
                            DGVWorker.Rows[e.RowIndex].ErrorText = "";
                        }
                    }
                }
                else if (e.ColumnIndex == 10) //Salary
                {
                    if (!GADJIT.IsSalaryValid(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        DGVWorker.Rows[e.RowIndex].ErrorText = "format du salaire incorrect";
                    }
                    else
                    {
                        DGVWorker.Rows[e.RowIndex].ErrorText = "";
                    }
                }
            }
        }

        private void DGVWorker_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGVWorker.Rows[e.RowIndex].ErrorText = "";
        }

        private bool CheckIfWorkerCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(WorID) from Ticket where WorID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfWorkerCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVWorker_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CheckIDIfExists((int)e.Row.Cells[0].Value))
                {
                    if (CheckIfWorkerCanBeDeleted((int)e.Row.Cells[0].Value))
                    {
                        int id = (int)e.Row.Cells[0].Value;

                        SqlCommand WorkerSpecialty = new SqlCommand("delete from WorkerSpecialty where WorID = @id", GADJIT.sqlConnection);
                        WorkerSpecialty.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        SqlCommand sqlCommandDeleteWorker = new SqlCommand("delete from Worker where WorID = @id", GADJIT.sqlConnection);
                        sqlCommandDeleteWorker.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        if (MessageBox.Show("Voulez-vous supprimer ce technicien ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            GADJIT.sqlConnection.Open();
                            MessageBox.Show("Suppression réussi de " + WorkerSpecialty.ExecuteNonQuery() + " spécialité et " + sqlCommandDeleteWorker.ExecuteNonQuery() + " technicien", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            WorkersStats();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show("Suppression interdit ce technicien est affectée dans des tickets", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVWorker_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVWorker_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            WorkersStats();
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
            if(TextBoxCINSearch.Text != "" || TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != ""
                || ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
            {
                FillDGVWorker();
            }
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
