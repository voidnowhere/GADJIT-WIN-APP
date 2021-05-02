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
        ColumnTextBoxDisponibility
        ColumnComboBoxStatus

        StafID StafCIN StafPicture StafLastName StafFirstName StafEmail StafPassWord StafPhoneNumber StafAdress CitDesig StafSalary StafDispo StafSta
        */

        byte i = 0;

        private bool CheckDGVCellsIfEmpty()
        {
            if(DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnPictureBox", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value != null && DGVStaff["ColumnTextBoxDisponibility", DGVStaff.CurrentRow.Index].Value != null
                && DGVStaff["ColumnComboBoxStatus", DGVStaff.CurrentRow.Index].Value != null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIDIfExists(string id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select StafID from Staff", GADJIT.sqlConnection);
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
            try
            {
                SqlCommand sqlCommandID = new SqlCommand("select max(StafID) from Staff", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                object id = sqlCommandID.ExecuteScalar();
                if (id != DBNull.Value)
                {
                    DGVStaff[0, DGVStaff.CurrentRow.Index].Value = GADJIT.IDGenerator((string)id);
                }
                else
                {
                    DGVStaff[0, DGVStaff.CurrentRow.Index].Value = GADJIT.IDGenerator("S0");
                }
                GADJIT.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error InsertNewIDInDGV()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
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

        private void GestionStaff_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            i = 1;
        }

        private void DGVStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (i == 1)
            {
                if(DGVStaff[0, DGVStaff.CurrentRow.Index].Value == null) // ID
                {
                    InsertNewIDInDGV();
                }
                if (!CheckDGVCellsIfEmpty())
                {
                    if (CheckIDIfExists(DGVStaff[0, DGVStaff.CurrentRow.Index].Value.ToString())) // update
                    {

                    }
                    else // insert
                    {
                        try
                        {
                            string sqlQuery = "insert into Staff " +
                            "values(@id, @cin, @img, @lastName, @firstName, @email, @password, @phoneNumber, @adress, @city, @salary, @dispo, @status)";
                            SqlCommand sqlCommandInsert = new SqlCommand(sqlQuery, GADJIT.sqlConnection);

                            sqlCommandInsert.Parameters.Add("@id", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@id"].Value = DGVStaff["ColumnTextBoxID", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@cin", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@cin"].Value = DGVStaff["ColumnTextBoxCIN", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@img", SqlDbType.Image);
                            sqlCommandInsert.Parameters["@img"].Value = (byte[])new ImageConverter().ConvertTo(DGVStaff["ColumnPictureBox", DGVStaff.CurrentRow.Index].Value, typeof(byte[]));

                            sqlCommandInsert.Parameters.Add("@lastName", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@lastName"].Value = DGVStaff["ColumnTextBoxLastName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@firstName", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@firstName"].Value = DGVStaff["ColumnTextBoxFirstName", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@email", SqlDbType.NVarChar);
                            sqlCommandInsert.Parameters["@email"].Value = DGVStaff["ColumnTextBoxEmail", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@password", SqlDbType.NVarChar);
                            sqlCommandInsert.Parameters["@password"].Value = DGVStaff["ColumnTextBoxPassword", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@phoneNumber"].Value = DGVStaff["ColumnTextBoxPhoneNumber", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@adress", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@adress"].Value = DGVStaff["ColumnTextBoxAdress", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@city", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@city"].Value = DGVStaff["ColumnComboBoxCity", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@salary", SqlDbType.Money);
                            sqlCommandInsert.Parameters["@salary"].Value = Convert.ToDecimal(DGVStaff["ColumnTextBoxSalary", DGVStaff.CurrentRow.Index].Value.ToString());

                            sqlCommandInsert.Parameters.Add("@dispo", SqlDbType.VarChar);
                            sqlCommandInsert.Parameters["@dispo"].Value = DGVStaff["ColumnTextBoxDisponibility", DGVStaff.CurrentRow.Index].Value.ToString();

                            sqlCommandInsert.Parameters.Add("@status", SqlDbType.Bit);
                            string status = DGVStaff["ColumnComboBoxStatus", DGVStaff.CurrentRow.Index].Value.ToString();
                            if (status == "Activer")
                            {
                                sqlCommandInsert.Parameters["@status"].Value = 1;
                            }
                            else if(status == "Désactiver")
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

        }

        private void DGVStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image |*.jpg; *.jpeg; *.png;";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    DGVStaff[2, DGVStaff.CurrentRow.Index].Value = Image.FromFile(ofd.FileName);
                }
            }   
        }

        private void DGVStaff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVStaff.CurrentCell.ColumnIndex == 2) // ColumnPictureBox
            {
                if(e.Button == MouseButtons.Right)
                {
                    ImageShow imageShow = new ImageShow();
                    imageShow.PictureBox.Image = (Image)DGVStaff[2, DGVStaff.CurrentRow.Index].Value;
                    imageShow.ShowDialog();
                }
            }
        }
    }
}
