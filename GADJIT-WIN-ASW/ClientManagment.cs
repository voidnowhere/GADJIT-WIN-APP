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
    public partial class ClientManagment : Form
    {
        public ClientManagment()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        //
        bool where = false;
        bool filledDGV = false;

        private void FillComboBoxCity()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitDesig from City", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    ComboBoxCitySearch.Items.Add("--tous--");
                    while (dataReader.Read())
                    {
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(0));
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

        private void FillDGVClient()
        {
            try
            {
                DGVClient.Rows.Clear();
                where = false;
                //
                String sqlQuery = "select CliID, CliLastName, CliFirstName, CliEmail, CliPhoneNumber, CliAdress, CitDesig, CliSta from Client";
                SqlCommand sqlCommand = new SqlCommand();
                if (TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != "" || 
                    ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
                {
                    sqlQuery += " where";
                    if (TextBoxEmailSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " CliEmail like @email";
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = "%" + TextBoxEmailSearch.Text + "%";
                        where = true;
                    }
                    if (TextBoxLastNameSearch.Text != "")
                    {
                        if (where) sqlQuery += " and";
                        sqlQuery += " CliLastName like @name";
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
                        sqlQuery += " CliSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatusSearch.SelectedIndex == 1) ? 1 : 0;
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
                        DGVClient.Rows.Add(dataReader["CliID"], dataReader["CliLastName"], dataReader["CliFirstName"], dataReader["CliEmail"],
                            dataReader["CliPhoneNumber"], dataReader["CliAdress"], dataReader["CitDesig"],
                            (dataReader.GetBoolean(7)) ? "Activer" : "Désactiver");
                    }
                    ClientsStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVClient()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVClient_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (filledDGV)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("update Client set CliSta = @sta where CliID = @id ", GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVClient[0, e.RowIndex].Value;
                    sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (DGVClient[7, e.RowIndex].Value.ToString() == "Activer") ? 1 : 0;
                    GADJIT.sqlConnection.Open();

                    MessageBox.Show(sqlCommand.ExecuteNonQuery() + " réussi", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error DGVClient_CellValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void ClientsStats()
        {
            int c = DGVClient.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVClient[7, i].Value.ToString() == "Activer") a++;
                else if (DGVClient[7, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxActivedClients.Text = a.ToString();
            TextBoxDeactivatedClients.Text = d.ToString();
            TextBoxTotalClients.Text = c.ToString();
        }

        private void ClientManagment_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVClient();
            filledDGV = true;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            FillDGVClient();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxEmailSearch.Clear();
            TextBoxLastNameSearch.Clear();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVClient();
        }
    }
}
