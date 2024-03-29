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
using System.Threading;

namespace GADJIT_WIN_ASW
{
    public partial class WorkerSpeciality : Form
    {
        public WorkerSpeciality()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        //
        public int workerID;
        bool dgvFilled = false;

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
                while (dataReader.Read())
                {
                    ColumnComboBoxCategory.Items.Add(new { id = dataReader.GetInt32(0), desig = dataReader.GetString(1) });
                }
                dataReader.Close();
                //
                sqlCommand.CommandText = "select GadBraID, GadBraDesig from GadgetBrand";
                dataReader = sqlCommand.ExecuteReader();
                ColumnComboBoxBrand.DisplayMember = "desig";
                ColumnComboBoxBrand.ValueMember = "id";
                while (dataReader.Read())
                {
                    ColumnComboBoxBrand.Items.Add(new { id = dataReader.GetInt32(0), desig = dataReader.GetString(1) });
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

        private void FillDGVWorkerSpecialistes()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select GadCatID, GadBraID from WorkerSpecialty where WorID = @id", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = workerID;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    DGVWorkerSpecialistes.Rows.Add(dataReader.GetInt32(0), dataReader.GetInt32(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVWorkerSpecialistes()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private bool CheckSpecialtyIfExists(int workerID, int GadCatID, int GadBraID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(*) from WorkerSpecialty where WorID = @worID and GadCatID = @catID and GadBraID = @braID", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@worID", SqlDbType.Int).Value = workerID;
                sqlCommand.Parameters.Add("@catID", SqlDbType.Int).Value = (int)DGVWorkerSpecialistes[0, DGVWorkerSpecialistes.CurrentRow.Index].Value;
                sqlCommand.Parameters.Add("@braID", SqlDbType.Int).Value = (int)DGVWorkerSpecialistes[1, DGVWorkerSpecialistes.CurrentRow.Index].Value;
                GADJIT.sqlConnection.Open();
                if((int)sqlCommand.ExecuteScalar() == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckSpecialtyIfExists(int workerID, int GadCatID, int GadBraID)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void MakeCellsReadOnly()
        {
            for(int i = 0; i < DGVWorkerSpecialistes.Rows.Count - 1; i++)
            {
                DGVWorkerSpecialistes.Rows[i].Cells["ColumnComboBoxCategory"].ReadOnly = true;
                DGVWorkerSpecialistes.Rows[i].Cells["ColumnComboBoxBrand"].ReadOnly = true;
            }
        }

        private void WorkerSpeciality_Load(object sender, EventArgs e)
        {
            FillColumnComboBoxGadgetBrand_Category();
            FillDGVWorkerSpecialistes();
            MakeCellsReadOnly();
            dgvFilled = true;
        }

        private void DGVWorkerSpecialistes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFilled)
            {
                if (DGVWorkerSpecialistes[0, e.RowIndex].Value != null && DGVWorkerSpecialistes[1, e.RowIndex].Value != null)
                {
                    if (!CheckSpecialtyIfExists(workerID, (int)DGVWorkerSpecialistes[0, e.RowIndex].Value, (int)DGVWorkerSpecialistes[1, e.RowIndex].Value)) //update
                    {
                        try
                        {
                            SqlCommand sqlCommandInsert = new SqlCommand("insert into WorkerSpecialty values(@worID, @catID, @braID)", GADJIT.sqlConnection);
                            sqlCommandInsert.Parameters.Add("@worID", SqlDbType.Int).Value = workerID;
                            sqlCommandInsert.Parameters.Add("@catID", SqlDbType.Int).Value = (int)DGVWorkerSpecialistes[0, e.RowIndex].Value;
                            sqlCommandInsert.Parameters.Add("@braID", SqlDbType.Int).Value = (int)DGVWorkerSpecialistes[1, e.RowIndex].Value;

                            GADJIT.sqlConnection.Open();

                            sqlCommandInsert.ExecuteNonQuery();

                            MessageBox.Show("Ajout réussi", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MakeCellsReadOnly();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error DGVWorkerSpecialistes_CellValueChanged insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Spécialité existe déjà", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DGVWorkerSpecialistes.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void DGVWorkerSpecialistes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(e.Row.Cells[0].Value != null && e.Row.Cells[1].Value != null)
            {
                if (CheckSpecialtyIfExists(workerID, (int)e.Row.Cells[0].Value, (int)e.Row.Cells[1].Value))
                {
                    try
                    {
                        SqlCommand sqlCommandDelete = new SqlCommand("delete from WorkerSpecialty where WorID = @worID and GadCatID = @catID and GadBraID = @braID", GADJIT.sqlConnection);
                        sqlCommandDelete.Parameters.Add("@worID", SqlDbType.Int).Value = workerID;
                        sqlCommandDelete.Parameters.Add("@catID", SqlDbType.Int).Value = (int)e.Row.Cells[0].Value;
                        sqlCommandDelete.Parameters.Add("@braID", SqlDbType.Int).Value = (int)e.Row.Cells[1].Value;

                        GADJIT.sqlConnection.Open();

                        sqlCommandDelete.ExecuteNonQuery();

                        MessageBox.Show("Suppression réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error DGVWorkerSpecialistes_UserDeletingRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        GADJIT.sqlConnection.Close();
                    }
                }
            }
        }
    }
}
