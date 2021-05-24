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
                        DGVCategory.Rows.Add(dataReader.GetInt32(0), dataReader.GetString(1), (dataReader.GetBoolean(2)) ? "Activer" : "Désactiver");
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
                        DGVBrand.Rows.Add(dataReader.GetInt32(0), dataReader.GetString(1), (dataReader.GetBoolean(2)) ? "Activer" : "Désactiver");
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
            if (DGVCategory.Rows.Count > 1)
            {
                DGVCategory[0, DGVCategory.CurrentRow.Index].Value = (int)DGVCategory[0, DGVCategory.CurrentRow.Index - 1].Value + 1;
            }
            else
            {
                DGVCategory[0, DGVCategory.CurrentRow.Index].Value = 0;
            }
        }

        private bool CheckIfCategoryIDExists(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadCatID) from GadgetCategory where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCategoryIDExists(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private bool CheckIfCategoryDesigExists(int id, string desig)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadCatDesig) from GadgetCategory where GadCatID != @id and GadCatDesig = @desig", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCategoryDesigExists(int id, string desig)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (DGVCategory[2, i].Value != null)
                {
                    if (DGVCategory[2, i].Value.ToString() == "Activer") a++;
                    else if (DGVCategory[2, i].Value.ToString() == "Désactiver") d++;
                }   
            }
            TextBoxActivedCategory.Text = a.ToString();
            TextBoxDeactivatedCategory.Text = d.ToString();
            TextBoxTotalCategory.Text = c.ToString();
        }

        private void DGVCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                DGVCategory.Rows[rowIndex].ErrorText = "";
                if (DGVCategory[0, rowIndex].Value == null)
                {
                    InsertNewIDInDGVCategory();
                }
                if (DGVCategory["ColumnTextBoxCategoryDesignation", rowIndex].Value != null && DGVCategory["ColumnComboBoxCategoryStatus", rowIndex].Value != null)
                {
                    if (CheckIfCategoryIDExists((int)DGVCategory[0, rowIndex].Value)) //Update
                    {
                        try
                        {
                            SqlCommand sqlCommandUpdateCategory = new SqlCommand("update GadgetCategory set GadCatDesig = @desig, GadCatSta = @sta where GadCatID = @id", GADJIT.sqlConnection);
                            string id = DGVCategory[0, rowIndex].Value.ToString();
                            sqlCommandUpdateCategory.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            sqlCommandUpdateCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCategory[1, rowIndex].Value.ToString();
                            bool status = (DGVCategory[2, rowIndex].Value.ToString() == "Activer") ? true : false;
                            sqlCommandUpdateCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            SqlCommand sqlCommandUpdateReference = new SqlCommand("update GadgetReference set GadRefSta = @sta where GadCatID = @id", GADJIT.sqlConnection);
                            sqlCommandUpdateReference.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            sqlCommandUpdateReference.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show("réussi pour " + sqlCommandUpdateCategory.ExecuteNonQuery() + " catégorie et " + sqlCommandUpdateReference.ExecuteNonQuery() + " référence", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            if (!CheckIfCategoryDesigExists((int)DGVCategory[0, e.RowIndex].Value, DGVCategory[1, e.RowIndex].Value.ToString()))
                            {
                                SqlCommand sqlCommandInsertCategory = new SqlCommand("insert into GadgetCategory values(@id, @desig, @sta)", GADJIT.sqlConnection);
                                sqlCommandInsertCategory.Parameters.Add("@id", SqlDbType.Int).Value = DGVCategory[0, rowIndex].Value.ToString();
                                sqlCommandInsertCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCategory[1, rowIndex].Value.ToString();
                                sqlCommandInsertCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVCategory[2, rowIndex].Value.ToString() == "Activer") ? true : false;

                                GADJIT.sqlConnection.Open();

                                MessageBox.Show(sqlCommandInsertCategory.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CategoryStats();
                            }
                            else
                            {
                                DGVCategory.Rows[rowIndex].ErrorText = "cet désignation existe déjà pour une catégorie";
                            }
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

        private void DGVCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.FormattedValue != null && DGVCategory[0, e.RowIndex].Value != null)
            {
                if (CheckIfCategoryDesigExists((int)DGVCategory[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    DGVCategory.Rows[e.RowIndex].ErrorText = "cet désignation existe déjà pour une catégorie";
                }
                else
                {
                    DGVCategory.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private bool CheckIfCategoryCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommandCheckInGadgetReference = new SqlCommand("select COUNT(GadCatID) from GadgetReference where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInGadgetReference.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommandCheckInGadgetReference.ExecuteScalar() >= 1)
                {
                    return false;
                }
                //
                SqlCommand sqlCommandCheckInWorkerSpecialty = new SqlCommand("select COUNT(GadCatID) from WorkerSpecialty where GadCatID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInWorkerSpecialty.Parameters.Add("@id", SqlDbType.Int).Value = id;
                if ((int)sqlCommandCheckInWorkerSpecialty.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCategoryCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVCategory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(e.Row.Cells[0].Value != null)
            {
                try
                {
                    if (CheckIfCategoryIDExists((int)e.Row.Cells[0].Value))
                    {
                        if (CheckIfCategoryCanBeDeleted((int)e.Row.Cells[0].Value))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetCategory where GadCatID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int).Value = e.Row.Cells[0].Value;

                            if (MessageBox.Show("Voulez vous supprimer cet catégorie", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                GADJIT.sqlConnection.Open();
                                MessageBox.Show(sqlCommandDelete.ExecuteNonQuery() + " réussi", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CategoryStats();
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("interdit cet catégorie est deja assigné a une reference ou une specialité d'un employé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (DGVBrand.Rows.Count > 1)
            {
                DGVBrand[0, DGVBrand.CurrentRow.Index].Value = (int)DGVBrand[0, DGVBrand.CurrentRow.Index - 1].Value + 1;
            }
            else
            {
                DGVBrand[0, DGVBrand.CurrentRow.Index].Value = 0;
            }
        }

        private bool CheckIfBrandIDExists(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadBraID) from GadgetBrand where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfBrandIDExists(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private bool CheckIfBrandDesigExists(int id, string desig)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(GadBraDesig) from GadgetBrand where GadBraID != @id and GadBraDesig = @desig", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfBrandDesigExists(int id, string desig)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(DGVBrand[2, i].Value != null)
                {
                    if (DGVBrand[2, i].Value.ToString() == "Activer") a++;
                    else if (DGVBrand[2, i].Value.ToString() == "Désactiver") d++;
                }
            }
            TextBoxActivedBrand.Text = a.ToString();
            TextBoxDeactivatedBrand.Text = d.ToString();
            TextBoxTotalBrand.Text = c.ToString();
        }

        private void DGVBrand_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                DGVBrand.Rows[rowIndex].ErrorText = "";
                if (DGVBrand[0, rowIndex].Value == null)
                {
                    InsertNewIDInDGVBrand();
                }
                if (DGVBrand["ColumnTextBoxBrandDesignation", rowIndex].Value != null && DGVBrand["ColumnComboBoxBrandStatus", rowIndex].Value != null)
                {
                    if (CheckIfBrandIDExists((int)DGVBrand[0, rowIndex].Value)) //Update
                    {
                        try
                        {
                            SqlCommand sqlCommandUpdateCategory = new SqlCommand("update GadgetBrand set GadBraDesig = @desig, GadBraSta = @sta where GadBraID = @id", GADJIT.sqlConnection);
                            string id = DGVBrand[0, rowIndex].Value.ToString();
                            sqlCommandUpdateCategory.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            sqlCommandUpdateCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVBrand[1, rowIndex].Value.ToString();
                            bool status = (DGVBrand[2, rowIndex].Value.ToString() == "Activer") ? true : false;
                            sqlCommandUpdateCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            SqlCommand sqlCommandUpdateReference = new SqlCommand("update GadgetReference set GadRefSta = @sta where GadBraID = @id", GADJIT.sqlConnection);
                            sqlCommandUpdateReference.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            sqlCommandUpdateReference.Parameters.Add("@sta", SqlDbType.Bit).Value = status;

                            GADJIT.sqlConnection.Open();

                            MessageBox.Show("réussi pour " + sqlCommandUpdateCategory.ExecuteNonQuery() + " marque et "
                                + sqlCommandUpdateReference.ExecuteNonQuery() + " référence", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            if (!CheckIfBrandDesigExists((int)DGVBrand[0, e.RowIndex].Value, DGVBrand[1, e.RowIndex].Value.ToString()))
                            {
                                SqlCommand sqlCommandInsertCategory = new SqlCommand("insert into GadgetBrand values(@id, @desig, @sta)", GADJIT.sqlConnection);
                                sqlCommandInsertCategory.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVBrand[0, rowIndex].Value;
                                sqlCommandInsertCategory.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVBrand[1, rowIndex].Value.ToString();
                                sqlCommandInsertCategory.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVBrand[2, rowIndex].Value.ToString() == "Activer") ? true : false;

                                GADJIT.sqlConnection.Open();

                                MessageBox.Show(sqlCommandInsertCategory.ExecuteNonQuery() + " réussi", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                BrandStats();
                            }
                            else
                            {
                                DGVBrand.Rows[rowIndex].ErrorText = "cet désignation existe déjà pour une marque";
                            }
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

        private void DGVBrand_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.FormattedValue != null && DGVBrand[0, e.RowIndex].Value != null)
            {
                if (CheckIfBrandDesigExists((int)DGVBrand[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    DGVBrand.Rows[e.RowIndex].ErrorText = "cet désignation existe déjà pour une marque";
                }
                else
                {
                    DGVBrand.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private bool CheckIfBrandCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommandCheckInGadgetReference = new SqlCommand("select COUNT(GadBraID) from GadgetReference where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInGadgetReference.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommandCheckInGadgetReference.ExecuteScalar() >= 1)
                {
                    return false;
                }
                //
                SqlCommand sqlCommandCheckInWorkerSpecialty = new SqlCommand("select COUNT(GadBraID) from WorkerSpecialty where GadBraID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInWorkerSpecialty.Parameters.Add("@id", SqlDbType.Int).Value = id;
                if ((int)sqlCommandCheckInWorkerSpecialty.ExecuteScalar() >= 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfBrandCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVBrand_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells[0].Value != null)
            {
                try
                {
                    if (CheckIfBrandIDExists((int)e.Row.Cells[0].Value))
                    {
                        if (CheckIfBrandCanBeDeleted((int)e.Row.Cells[0].Value))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from GadgetBrand where GadBraID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int).Value = e.Row.Cells[0].Value;

                            if (MessageBox.Show("Voulez vous supprimer cet marque", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                GADJIT.sqlConnection.Open();
                                MessageBox.Show(sqlCommandDelete.ExecuteNonQuery() + " réussi", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BrandStats();
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("interdit cet marque est deja assigné a une reference ou une specialité d'un employé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
