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
        Dictionary<int, string> category = new Dictionary<int, string>();
        Dictionary<int, string> brand = new Dictionary<int, string>();
        //
        bool filledDGV = false;
        bool where = false;

        private bool CheckDGVCellsIfEmpty()
        {
            if (DGVReference["ColumnComboBoxCategory", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnComboBoxBrand", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnTextBoxDesignation", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnTextBoxDescription", DGVReference.CurrentRow.Index].Value != null
                && DGVReference["ColumnComboBoxStatus", DGVReference.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadRefID) from GadgetReference where GadRefID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1)
                {
                    return true;
                }
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

        private int GetMaxGadgetReferenceId()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select MAX(GadRefID) from GadgetReference", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                return (sqlCommand.ExecuteScalar() == DBNull.Value) ? 0 : int.Parse(sqlCommand.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GetMaxGadgetReferenceId", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return 0;
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
                    ColumnComboBoxCategory.Items.Add(new { id = dataReader.GetInt32(0), desig = dataReader.GetString(1) });
                    ComboBoxCategory.Items.Add(dataReader.GetString(1));
                    category.Add(dataReader.GetInt32(0), dataReader.GetString(1));
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
                    ColumnComboBoxBrand.Items.Add(new { id = dataReader.GetInt32(0), desig = dataReader.GetString(1) });
                    ComboBoxBrand.Items.Add(dataReader.GetString(1));
                    brand.Add(dataReader.GetInt32(0), dataReader.GetString(1));
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
                    sqlQuery += " where";
                    if (ComboBoxCategory.SelectedIndex > 0)
                    {
                        sqlQuery += " GadCatID = @cat";
                        sqlCommand.Parameters.Add("@cat", SqlDbType.Int).Value = category.Keys.First(k => category[k].ToString() == ComboBoxCategory.Text);
                        where = true;
                    }
                    if (ComboBoxBrand.SelectedIndex > 0)
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " GadBraID = @bra";
                        sqlCommand.Parameters.Add("@bra", SqlDbType.Int).Value = brand.Keys.First(k => brand[k].ToString() == ComboBoxBrand.Text);
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
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatus.SelectedIndex == 1) ? true : false;
                        where = true;
                    }
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
            int c = DGVReference.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if(DGVReference[5, i].Value != null)
                {
                    if (DGVReference[5, i].Value.ToString() == "Activer") a++;
                    else if (DGVReference[5, i].Value.ToString() == "Désactiver") d++;
                }
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
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                if (!CheckDGVCellsIfEmpty())
                {
                    if (DGVReference[0, rowIndex].Value != null) //update
                    {
                        if (CheckIDIfExists((int)DGVReference[0, rowIndex].Value))
                        {
                            try
                            {
                                SqlCommand sqlCommandUpdate = new SqlCommand(
                                    "update GadgetReference set GadCatID = @catID, GadBraID = @braID, GadRefDesig = @desig, GadRefDescr = @descr, GadRefSta = @sta where GadRefID = @id"
                                    , GADJIT.sqlConnection);

                                sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVReference["ColumnTextBoxID", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@catID", SqlDbType.Int).Value = (int)DGVReference["ColumnComboBoxCategory", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@braID", SqlDbType.Int).Value = (int)DGVReference["ColumnComboBoxBrand", rowIndex].Value;

                                sqlCommandUpdate.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDesignation", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@descr", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDescription", rowIndex].Value.ToString();

                                sqlCommandUpdate.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVReference["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? true : false;

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
                        else
                        {
                            MessageBox.Show("Cette référence a été supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            GADJIT.sqlConnection.Close();
                            FillDGVReference();
                        }
                    }
                    else // insert
                    {
                        try
                        {
                            SqlCommand sqlCommandInsert = new SqlCommand("insert into GadgetReference values(@id, @catID, @braID, @desig, @descr, @sta)", GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.Int).Value = GetMaxGadgetReferenceId();

                            sqlCommandInsert.Parameters.Add("@catID", SqlDbType.Int).Value = (int)DGVReference["ColumnComboBoxCategory", rowIndex].Value;

                            sqlCommandInsert.Parameters.Add("@braID", SqlDbType.Int).Value = (int)DGVReference["ColumnComboBoxBrand", rowIndex].Value;

                            sqlCommandInsert.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDesignation", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@descr", SqlDbType.VarChar).Value = DGVReference["ColumnTextBoxDescription", rowIndex].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVReference["ColumnComboBoxStatus", rowIndex].Value.ToString() == "Activer") ? true : false;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsert.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GADJIT.sqlConnection.Close();

                            FillDGVReference();
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

        private bool CheckIfReferenceDesigExists(int id, string desig)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    (id == -1) ?
                        "select COUNT(GadRefDesig) from GadgetReference where GadRefDesig = @desig"
                        :
                        "select COUNT(GadRefDesig) from GadgetReference where GadRefID != @id and GadRefDesig = @desig",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfReferenceDesigExists(int id, string desig)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVReference_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.FormattedValue != null)
            {
                if (CheckIfReferenceDesigExists((DGVReference[0, e.RowIndex].Value == null) ? -1 : (int)DGVReference[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    DGVReference.Rows[e.RowIndex].ErrorText = "cet désignation existe déjà pour une référence";
                }
                else
                {
                    DGVReference.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private void DGVReference_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGVReference.Rows[e.RowIndex].ErrorText = "";
        }

        private bool CheckIfReferenceCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadRefID) from Ticket where GadRefID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if((int)sqlCommand.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfReferenceCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (CheckIDIfExists((int)e.Row.Cells[0].Value))
                    {
                        if (CheckIfReferenceCanBeDeleted((int)e.Row.Cells[0].Value))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetReference where GadRefID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int).Value = (int)e.Row.Cells[0].Value;

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
                    else
                    {
                        MessageBox.Show("réussi", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
