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

namespace GADJIT_WIN_ASW
{
    public partial class GadgetCategoryBrandManagment : Form
    {
        public GadgetCategoryBrandManagment()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        //
        bool filledDGV = false;

        private void FillDGVCategory()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from GadgetCategory", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string status = (dataReader.GetBoolean(2)) ? "Activer" : "Désactiver";
                        DGVCategory.Rows.Add(dataReader.GetString(0), dataReader.GetString(1), status);
                    }
                    CategoryStats();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVCategory()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillDGVBrand()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from GadgetBrand", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string status = (dataReader.GetBoolean(2)) ? "Activer" : "Désactiver";
                        DGVBrand.Rows.Add(dataReader.GetString(0), dataReader.GetString(1), status);
                    }
                    BrandStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVBrand()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void InsertNewIDInDGVCategory()
        {
            if (DGVCategory.Rows.Count > 2)
            {
                DGVCategory[0, DGVCategory.CurrentRow.Index].Value = GADJIT.IDGenerator((string)DGVCategory[0, DGVCategory.CurrentRow.Index - 1].Value);
            }
            else
            {
                DGVCategory[0, DGVCategory.CurrentRow.Index].Value = GADJIT.IDGenerator("GC0");
            }
        }

        private bool CheckIfCategoryIDExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(*) from GadgetCategory where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCategoryIDExists(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void CategoryStats()
        {
            int c = DGVCategory.Rows.Count - 1;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVCategory[2, i].Value.ToString() == "Activer") a++;
                else if (DGVCategory[2, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxActivedCategory.Text = a.ToString();
            TextBoxDeactivatedCategory.Text = d.ToString();
            TextBoxTotalCategory.Text = c.ToString();
        }

        private void DGVCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (filledDGV)
            {
                if (DGVCategory[0, rowIndex].Value == null)
                {
                    InsertNewIDInDGVCategory();
                }
                if (DGVCategory["ColumnTextBoxCategoryDesignation", rowIndex].Value != null && DGVCategory["ColumnComboBoxCategoryStatus", rowIndex].Value != null)
                {
                    if (CheckIfCategoryIDExists(DGVCategory[0, rowIndex].Value.ToString())) // Update
                    {
                        try
                        {
                            SqlCommand sqlCommandUpdateCategory = new SqlCommand("update GadgetCategory set GadCatDesig = @desig, GadCatSta = @sta where GadCatID = @id", GADJIT.sqlConnection);
                            string id = DGVCategory[0, rowIndex].Value.ToString();
                            sqlCommandUpdateCategory.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                            sqlCommandUpdateCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCategory[1, rowIndex].Value.ToString();
                            int status = (DGVCategory[2, rowIndex].Value.ToString() == "Activer") ? 1 : 0;
                            sqlCommandUpdateCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            SqlCommand sqlCommandUpdateReference = new SqlCommand("update GadgetReference set GadRefSta = @sta where GadCatID = @id", GADJIT.sqlConnection);
                            sqlCommandUpdateReference.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                            sqlCommandUpdateReference.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandUpdateCategory.ExecuteNonQuery() + sqlCommandUpdateReference.ExecuteNonQuery() + " réussi", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CategoryStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVCategory_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                    else // Insert
                    {
                        try
                        {
                            SqlCommand sqlCommandInsertCategory = new SqlCommand("insert into GadgetCategory values(@id, @desig, @sta)", GADJIT.sqlConnection);
                            sqlCommandInsertCategory.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVCategory[0, rowIndex].Value.ToString();
                            sqlCommandInsertCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCategory[1, rowIndex].Value.ToString();
                            sqlCommandInsertCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVCategory[2, rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsertCategory.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CategoryStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVCategory_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                }
            }
        }

        private bool CheckIfCategoryCanBeDeleted(string id)
        {
            try
            {
                SqlCommand sqlCommandCheckInGadgetReference = new SqlCommand("select COUNT(GadCatID) from GadgetReference where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInGadgetReference.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommandCheckInGadgetReference.ExecuteScalar() >= 1)
                {
                    return false;
                }
                //
                SqlCommand sqlCommandCheckInWorkerSpecialty = new SqlCommand("select COUNT(GadCatID) from WorkerSpecialty where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInWorkerSpecialty.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                if ((int)sqlCommandCheckInWorkerSpecialty.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCategoryCanBeDeleted(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVCategory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CheckIfCategoryIDExists(e.Row.Cells[0].Value.ToString()))
                {
                    if (CheckIfCategoryCanBeDeleted(e.Row.Cells[0].Value.ToString()))
                    {
                        SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetCategory where GadCatID = @id", GADJIT.sqlConnection);
                        sqlCommandDelete.Parameters.Add("@id", SqlDbType.VarChar).Value = e.Row.Cells[0].Value;
                        GADJIT.sqlConnection.Open();

                        if (MessageBox.Show("Voulez vous supprimer cet catégorie", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
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
                        MessageBox.Show("interdit", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVCategory_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVCategory_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CategoryStats();
        }

        private void DGVCategory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGVCategory.CurrentCell.ColumnIndex == 1) //Designation
            {
                e.Control.KeyPress -= OnlyLetterWhiteSpaceKeyPressCheck;
                e.Control.KeyPress += OnlyLetterWhiteSpaceKeyPressCheck;
            }
        }

        private void InsertNewIDInDGVBrand()
        {
            if (DGVBrand.Rows.Count > 2)
            {
                DGVBrand[0, DGVBrand.CurrentRow.Index].Value = GADJIT.IDGenerator((string)DGVBrand[0, DGVBrand.CurrentRow.Index - 1].Value);
            }
            else
            {
                DGVBrand[0, DGVBrand.CurrentRow.Index].Value = GADJIT.IDGenerator("GB0");
            }
        }

        private bool CheckIfBrandIDExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadBraID) from GadgetBrand where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfBrandIDExists(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void BrandStats()
        {
            int c = DGVBrand.Rows.Count - 1;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVBrand[2, i].Value.ToString() == "Activer") a++;
                else if (DGVBrand[2, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxActivedBrand.Text = a.ToString();
            TextBoxDeactivatedBrand.Text = d.ToString();
            TextBoxTotalBrand.Text = c.ToString();
        }

        private void DGVBrand_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (filledDGV)
            {
                if (DGVBrand[0, rowIndex].Value == null)
                {
                    InsertNewIDInDGVBrand();
                }
                if (DGVBrand["ColumnTextBoxBrandDesignation", rowIndex].Value != null && DGVBrand["ColumnComboBoxBrandStatus", rowIndex].Value != null)
                {
                    if (CheckIfBrandIDExists(DGVBrand[0, rowIndex].Value.ToString())) // Update
                    {
                        try
                        {
                            SqlCommand sqlCommandUpdateCategory = new SqlCommand("update GadgetBrand set GadBraDesig = @desig, GadBraSta = @sta where GadBraID = @id", GADJIT.sqlConnection);
                            string id = DGVBrand[0, rowIndex].Value.ToString();
                            sqlCommandUpdateCategory.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                            sqlCommandUpdateCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVBrand[1, rowIndex].Value.ToString();
                            int status = (DGVBrand[2, rowIndex].Value.ToString() == "Activer") ? 1 : 0;
                            sqlCommandUpdateCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            SqlCommand sqlCommandUpdateReference = new SqlCommand("update GadgetReference set GadRefSta = @sta where GadBraID = @id", GADJIT.sqlConnection);
                            sqlCommandUpdateReference.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                            sqlCommandUpdateReference.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandUpdateCategory.ExecuteNonQuery() + sqlCommandUpdateReference.ExecuteNonQuery() + " réussi", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            BrandStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVBrand_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                    else // Insert
                    {
                        try
                        {
                            SqlCommand sqlCommandInsertCategory = new SqlCommand("insert into GadgetBrand values(@id, @desig, @sta)", GADJIT.sqlConnection);
                            sqlCommandInsertCategory.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVBrand[0, rowIndex].Value.ToString();
                            sqlCommandInsertCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVBrand[1, rowIndex].Value.ToString();
                            sqlCommandInsertCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVBrand[2, rowIndex].Value.ToString() == "Activer") ? 1 : 0;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show(sqlCommandInsertCategory.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            BrandStats();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVBrand_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                }
            }
        }

        private bool CheckIfBrandCanBeDeleted(string id)
        {
            try
            {
                SqlCommand sqlCommandCheckInGadgetReference = new SqlCommand("select COUNT(GadBraID) from GadgetReference where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInGadgetReference.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommandCheckInGadgetReference.ExecuteScalar() >= 1)
                {
                    return false;
                }
                //
                SqlCommand sqlCommandCheckInWorkerSpecialty = new SqlCommand("select COUNT(GadBraID) from WorkerSpecialty where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInWorkerSpecialty.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                if ((int)sqlCommandCheckInWorkerSpecialty.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfBrandCanBeDeleted(string id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVBrand_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CheckIfBrandIDExists(e.Row.Cells[0].Value.ToString()))
                {
                    if (CheckIfBrandCanBeDeleted(e.Row.Cells[0].Value.ToString()))
                    {
                        SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetBrand where GadBraID = @id", GADJIT.sqlConnection);
                        sqlCommandDelete.Parameters.Add("@id", SqlDbType.VarChar).Value = e.Row.Cells[0].Value;
                        GADJIT.sqlConnection.Open();

                        if (MessageBox.Show("Voulez vous supprimer cet marque", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
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
                        MessageBox.Show("interdit", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVBrand_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVBrand_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BrandStats();
        }

        private void DGVBrand_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(DGVBrand.CurrentCell.ColumnIndex == 1) //Designation
            {
                e.Control.KeyPress -= OnlyLetterWhiteSpaceKeyPressCheck;
                e.Control.KeyPress += OnlyLetterWhiteSpaceKeyPressCheck;
            }
        }

        private void OnlyLetterWhiteSpaceKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("N'entrez que des lettres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GadgetCategoryBrandManagment_Load(object sender, EventArgs e)
        {
            FillDGVCategory();
            FillDGVBrand();
            filledDGV = true;
        }
    }
}
