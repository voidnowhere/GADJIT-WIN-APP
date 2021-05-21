using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GADJIT_WIN_ASW
{
    public partial class GadgetReferenceManagment : Form
    {
        public GadgetReferenceManagment()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        Dictionary<string, string> category = new Dictionary<string, string>();
        Dictionary<string, string> brand = new Dictionary<string, string>();
        //
        bool filledDGV = false;
        bool where = false;

        private bool CheckDGVCellsIfEmpty()
        {
            if (DGVReference["ColumnTextBoxID", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnComboBoxCategory", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnComboBoxBrand", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnTextBoxDesignation", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnTextBoxDescription", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnComboBoxStatus", DGVReference.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadRefID) from GadgetReference where GadRefID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1)
                {
                    return true;
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
            if (DGVReference.Rows.Count > 2)
            {
                DGVReference[0, DGVReference.CurrentRow.Index].Value = GADJIT.IDGenerator((string)DGVReference[0, DGVReference.CurrentRow.Index - 1].Value);
            }
            else
            {
                DGVReference[0, DGVReference.CurrentRow.Index].Value = GADJIT.IDGenerator("GR0");
            }
        }

        private void FillColumnComboBoxGadgetBrand_Category()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                //
                sqlCommand.CommandText = "select GadCatID, GadCatDesig from GadgetCategory";
                dataReader = sqlCommand.ExecuteReader();

                ColumnComboBoxCategory.DisplayMember = "desig";
                ColumnComboBoxCategory.ValueMember = "id";
                ComboBoxCategory.Items.Add("--tous--");

                while (dataReader.Read())
                {
                    ColumnComboBoxCategory.Items.Add(new { id = dataReader.GetString(0), desig = dataReader.GetString(1) });
                    ComboBoxCategory.Items.Add(dataReader.GetString(1));
                    category.Add(dataReader.GetString(0), dataReader.GetString(1));
                }
                dataReader.Close();
                //
                sqlCommand.CommandText = "select GadBraID, GadBraDesig from GadgetBrand";
                dataReader = sqlCommand.ExecuteReader();

                ColumnComboBoxBrand.DisplayMember = "desig";
                ColumnComboBoxBrand.ValueMember = "id";
                ComboBoxBrand.Items.Add("--tous--");
                while (dataReader.Read())
                {
                    ColumnComboBoxBrand.Items.Add(new { id = dataReader.GetString(0), desig = dataReader.GetString(1) });
                    ComboBoxBrand.Items.Add(dataReader.GetString(1));
                    brand.Add(dataReader.GetString(0), dataReader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillColumnComboBoxGadgetBrand_Category()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillDGVReference()
        {
            try
            {
                DGVReference.Rows.Clear();
                where = false;
                //
                String sqlQuery = "select * from GadgetReference";
                SqlCommand sqlCommand = new SqlCommand();
                if (ComboBoxCategory.SelectedIndex > 0 || ComboBoxBrand.SelectedIndex > 0 || TextBoxDesignation.Text != "" || ComboBoxStatus.SelectedIndex > 0)
                {
                    DGVReference.AllowUserToAddRows = false;
                    sqlQuery += " where";
                    if (ComboBoxCategory.SelectedIndex > 0)
                    {
                        sqlQuery += " GadCatID = @cat";
                        sqlCommand.Parameters.Add("@cat", SqlDbType.VarChar).Value = category.Keys.First(k => category[k].ToString() == ComboBoxCategory.Text);
                        where = true;
                    }
                    if (ComboBoxBrand.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " GadBraID = @bra";
                        sqlCommand.Parameters.Add("@bra", SqlDbType.VarChar).Value = brand.Keys.First(k => brand[k].ToString() == ComboBoxBrand.Text);
                        where = true;
                    }
                    if (TextBoxDesignation.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " GadRefDesig like @desig";
                        sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = "%" + TextBoxDesignation.Text + "%";
                        where = true;
                    }
                    if (ComboBoxStatus.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " GadRefSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatus.SelectedIndex == 1) ? 1 : 0;
                        where = true;
                    }
                }
                else
                {
                    DGVReference.AllowUserToAddRows = true;
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DGVReference.Rows.Add(
                            dataReader["GadRefID"],
                            dataReader["GadCatID"],
                            dataReader["GadBraID"],
                            dataReader["GadRefDesig"],
                            dataReader["GadRefDescr"],
                            (dataReader.GetBoolean(5)) ? "Activer" : "Désactiver");
                    }
                    ReferencesStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVReference()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void ReferencesStats()
        {
            int c = (DGVReference.AllowUserToAddRows) ? DGVReference.Rows.Count - 1 : DGVReference.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVReference[5, i].Value.ToString() == "Activer") a++;
                else if (DGVReference[5, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxActivedReference.Text = a.ToString();
            TextBoxDeactivatedReference.Text = d.ToString();
            TextBoxTotalReference.Text = c.ToString();
        }

        private void GadgetReferenceManagment_Load(object sender, EventArgs e)
        {
            FillColumnComboBoxGadgetBrand_Category();
            ComboBoxCategory.SelectedIndex = 0;
            ComboBoxBrand.SelectedIndex = 0;
            ComboBoxStatus.SelectedIndex = 0;
            FillDGVReference();
            filledDGV = true;

        }

        private void DGVReference_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (filledDGV)
            {
                if (DGVReference[0, rowIndex].Value == null) // ID
                {
                    InsertNewIDInDGV();
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists(DGVReference[0, rowIndex].Value.ToString())) // update
                    {
                        try
                        {
                            string sqlQuery = "update GadgetReference set GadCatID = @catID, GadBraID = @braID, GadRefDesig = @desig, GadRefDescr = @descr, GadRefSta = @sta where GadRefID = @id";
                            SqlCommand sqlCommandUpdate = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandUpdate.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@catID", SqlDbType.VarChar).Value = DGVReference["ColumnComboBoxCategory", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@braID", SqlDbType.VarChar).Value = DGVReference["ColumnComboBoxBrand", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDesignation", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@descr", SqlDbType.NVarChar).Value = DGVReference["ColumnTextBoxDescription", rowIndex].Value.ToString();

                            sqlCommandUpdate.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVReference["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandUpdate.ExecuteNonQuery() + " réussi", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReferencesStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVReference_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            SqlCommand sqlCommandInsert = new SqlCommand("insert into GadgetReference values(@id, @catID, @braID, @desig, @descr, @sta)", GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxID", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@catID", SqlDbType.VarChar).Value = DGVReference["ColumnComboBoxCategory", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@braID", SqlDbType.VarChar).Value = DGVReference["ColumnComboBoxBrand", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDesignation", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@descr", SqlDbType.NVarChar).Value = DGVReference["ColumnTextBoxDescription", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVReference["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsert.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReferencesStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVReference_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                }
            }
        }

        private bool CheckIfReferenceDesigExists(string id, string desig)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadRefDesig) from GadgetReference where GadRefID != @id and GadRefDesig = @desig", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfReferenceDesigExists(string id, string desig)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVReference_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.FormattedValue != null && DGVReference[0, e.RowIndex].Value != null)
            {
                if (CheckIfReferenceDesigExists(DGVReference[0, e.RowIndex].Value.ToString(), e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show("cet désignation existe déjà pour une référence", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckIfReferenceCanBeDeleted(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadRefID) from Ticket where GadRefID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                GADJIT.sqlConnection.Open();
                if((int)sqlCommand.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfReferenceCanBeDeleted(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVReference_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(e.Row.Cells[0].Value != null)
            {
                try
                {
                    if (CheckIDIfExists(e.Row.Cells[0].Value.ToString()))
                    {
                        if (CheckIfReferenceCanBeDeleted(e.Row.Cells[0].Value.ToString()))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetReference where GadRefID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.VarChar).Value = e.Row.Cells[0].Value;

                            if (MessageBox.Show("Voulez vous supprimer cet référence", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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
                            MessageBox.Show("interdit cette référence est deja assigné a une ticket", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error DGVReference_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void DGVReference_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ReferencesStats();
        }

        private void DGVReference_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (DGVReference.CurrentCell.ColumnIndex)
            {
                case 3:
                case 4:
                    e.Control.KeyPress -= OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    e.Control.KeyPress += OnlyLetterNumberWhiteSpaceKeyPressCheck;
                    break;
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

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            FillDGVReference();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ComboBoxCategory.SelectedIndex = 0;
            ComboBoxBrand.SelectedIndex = 0;
            TextBoxDesignation.Clear();
            ComboBoxStatus.SelectedIndex = 0;
            FillDGVReference();
        }
    }
}
