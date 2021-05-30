using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_ASW
{
    public partial class CityManagement : Form
    {
        public CityManagement()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        //
        bool filledDGV = false;

        private void CityStats()
        {
            int c = DGVCity.Rows.Count - 1;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVCity[2, i].Value != null)
                {
                    if (DGVCity[2, i].Value.ToString() == "Activer") a++;
                    else if (DGVCity[2, i].Value.ToString() == "Désactiver") d++;
                }
            }
            TextBoxActivedCategory.Text = a.ToString();
            TextBoxDeactivatedCategory.Text = d.ToString();
            TextBoxTotalCategory.Text = c.ToString();
        }

        private void FillDGVCity()
        {
            DGVCity.Rows.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DGVCity.Rows.Add(dataReader.GetInt32(0), dataReader.GetString(1), (dataReader.GetBoolean(2)) ? "Activer" : "Désactiver");
                    }
                    CityStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void CityManagement_Load(object sender, EventArgs e)
        {
            FillDGVCity();
            filledDGV = true;
        }

        private bool CheckIfCityIDExists(int citID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(CitID) from City where CitID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = citID;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCityIDExists(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private int GenerateCityId()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select MAX(CitID) from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                return (sqlCommand.ExecuteScalar() == DBNull.Value) ? 0 : int.Parse(sqlCommand.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GenerateCityId", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return 0;
        }

        private void DGVCity_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                int rowIndex = e.RowIndex;
                if (DGVCity["ColumnTextBoxCityDesignation", rowIndex].Value != null && DGVCity["ColumnComboBoxCityStatus", rowIndex].Value != null)
                {
                    if (DGVCity[0, rowIndex].Value != null && e.ColumnIndex != 0) //Update
                    {
                        if (CheckIfCityIDExists((int)DGVCity[0, rowIndex].Value))
                        {
                            try
                            {
                                SqlCommand sqlCommandUpdate = new SqlCommand("update City set CitDesig = @desig, CitSta = @sta where CitID = @id", GADJIT.sqlConnection);
                                string id = DGVCity[0, rowIndex].Value.ToString();
                                sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int).Value = id;
                                sqlCommandUpdate.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCity[1, rowIndex].Value.ToString();
                                sqlCommandUpdate.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVCity[2, rowIndex].Value.ToString() == "Activer") ? true : false;

                                GADJIT.sqlConnection.Open();

                                sqlCommandUpdate.ExecuteNonQuery();

                                MessageBox.Show("Modification réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CityStats();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error DGVCity_CellValueChanged update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                GADJIT.sqlConnection.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cette ville a été supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            GADJIT.sqlConnection.Close();
                            FillDGVCity();
                        }
                    }
                    else if(e.ColumnIndex != 0) // Insert
                    {
                        try
                        {
                            SqlCommand sqlCommandInsert = new SqlCommand("insert into City values(@id, @desig, @sta)", GADJIT.sqlConnection);

                            int id = GenerateCityId();
                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            sqlCommandInsert.Parameters.Add("@desig", SqlDbType.VarChar).Value = DGVCity[1, rowIndex].Value.ToString();
                            sqlCommandInsert.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVCity[2, rowIndex].Value.ToString() == "Activer") ? true : false;

                            GADJIT.sqlConnection.Open();

                            sqlCommandInsert.ExecuteNonQuery();

                            MessageBox.Show("Ajout réussi", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CityStats();

                            DGVCity[0, e.RowIndex].Value = id;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVCity_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                }
            }
        }

        private bool CheckIfCityDesigExists(int citID, string desig)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    (citID == -1) ?
                        "select COUNT(CitDesig) from City where CitDesig = @desig"
                        :
                        "select COUNT(CitDesig) from City where CitID != @id and CitDesig = @desig",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = citID;
                sqlCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCityDesigExists(int citID, string desig)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void DGVCity_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.FormattedValue != null)
            {
                if (CheckIfCityDesigExists((DGVCity[0, e.RowIndex].Value == null) ? -1 : (int)DGVCity[0, e.RowIndex].Value, e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    DGVCity.Rows[e.RowIndex].ErrorText = "cet désignation existe déjà pour une ville";
                }
                else
                {
                    DGVCity.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private void DGVCity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGVCity.Rows[e.RowIndex].ErrorText = "";
        }

        private bool CheckIfCityCanBeDeleted(int id)
        {
            try
            {
                SqlCommand sqlCommandCheckInClient = new SqlCommand("select COUNT(CitID) from Client where CitID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInClient.Parameters.Add("@id", SqlDbType.Int).Value = id;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommandCheckInClient.ExecuteScalar() > 0)
                {
                    return false;
                }
                //
                SqlCommand sqlCommandCheckInTicket = new SqlCommand("select COUNT(CitID) from Ticket where CitID = @id", GADJIT.sqlConnection);
                sqlCommandCheckInTicket.Parameters.Add("@id", SqlDbType.Int).Value = id;
                if ((int)sqlCommandCheckInTicket.ExecuteScalar() > 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfCityCanBeDeleted(int id)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return true;
        }

        private void DGVCity_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells[0].Value != null)
            {
                try
                {
                    if (CheckIfCityIDExists((int)e.Row.Cells[0].Value))
                    {
                        if (CheckIfCityCanBeDeleted((int)e.Row.Cells[0].Value))
                        {
                            SqlCommand sqlCommandDelete = new SqlCommand("delete from City where CitID = @id", GADJIT.sqlConnection);
                            sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int).Value = e.Row.Cells[0].Value;

                            if (MessageBox.Show("Voulez-vous supprimer cette ville ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                GADJIT.sqlConnection.Open();
                                sqlCommandDelete.ExecuteNonQuery();
                                MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CityStats();
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("Suppression interdit cette ville est déjà assignée à des clients ou des tickets", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error DGVCity_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void DGVCity_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CityStats();
        }

        private void OnlyLetterWhiteSpaceKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("N'entrez que des lettres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVCity_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGVCity.CurrentCell.ColumnIndex == 1) //Designation
            {
                e.Control.KeyPress -= OnlyLetterWhiteSpaceKeyPressCheck;
                e.Control.KeyPress += OnlyLetterWhiteSpaceKeyPressCheck;
            }
        }
    }
}
