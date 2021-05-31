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
        Dictionary<int, string> city = new Dictionary<int, string>();
        bool filledDGV = false;

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
                    while (dataReader.Read())
                    {
                        city.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                        ComboBoxCitySearch.Items.Add(dataReader.GetString(1));
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
                //
                String sqlQuery =
                    "select CliID, CliLastName, CliFirstName, CliEmail, CliPhoneNumber, CliAddress, CitDesig, CliSta, CliVerCod " +
                    "from Client as cl, City as ci " +
                    "where cl.CitID = ci.CitID";
                SqlCommand sqlCommand = new SqlCommand();
                if (TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != "" || 
                    ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
                {
                    if (TextBoxEmailSearch.Text != "")
                    {
                        sqlQuery += " and";
                        sqlQuery += " CliEmail like @email";
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = "%" + TextBoxEmailSearch.Text + "%";
                    }
                    if (TextBoxLastNameSearch.Text != "")
                    {
                        sqlQuery += " and";
                        sqlQuery += " CliLastName like @name";
                        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = "%" + TextBoxLastNameSearch.Text + "%";
                    }
                    if (ComboBoxCitySearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and";
                        sqlQuery += " cl.CitID = @citID";
                        sqlCommand.Parameters.Add("@citID", SqlDbType.Int).Value = city.Keys.First(i => city[i] == ComboBoxCitySearch.Text);
                    }
                    if (ComboBoxStatusSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and";
                        sqlQuery += " CliSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (ComboBoxStatusSearch.SelectedIndex == 1) ? true : false;
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
                        DGVClient.Rows.Add(
                            dataReader["CliID"],
                            dataReader["CliLastName"],
                            dataReader["CliFirstName"],
                            dataReader["CliEmail"],
                            dataReader["CliPhoneNumber"],
                            dataReader["CliAddress"],
                            dataReader["CitDesig"],
                            (dataReader["CliVerCod"] == DBNull.Value) ? "oui" : "non",
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
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = (int)DGVClient[0, e.RowIndex].Value;
                    string status = DGVClient[8, e.RowIndex].Value.ToString();
                    sqlCommand.Parameters.Add("@sta", SqlDbType.Bit).Value = (status == "Activer") ? true : false;
                    GADJIT.sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Compte client est " + ((status == "Activer") ? "activé" : "désactivé"), "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClientsStats();

                    GADJIT.SendEmail(
                        DGVClient[3, e.RowIndex].Value.ToString(),
                        "Votre compte est " + DGVClient[8, e.RowIndex].Value.ToString());
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
            int v = 0;
            int n = 0;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVClient[7, i].Value.ToString() == "oui") v++;
                else if (DGVClient[7, i].Value.ToString() == "non") n++;
                if (DGVClient[8, i].Value.ToString() == "Activer") a++;
                else if (DGVClient[8, i].Value.ToString() == "Désactiver") d++;
            }
            TextBoxVerifiedClients.Text = v.ToString();
            TextBoxUnverifiedClients.Text = n.ToString();
            TextBoxDeactivatedClients.Text = d.ToString();
            TextBoxTotalClients.Text = c.ToString();
            TextBoxActivedClients.Text = a.ToString();
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
            if (TextBoxEmailSearch.Text != "" || TextBoxLastNameSearch.Text != ""
                || ComboBoxCitySearch.SelectedIndex > 0 || ComboBoxStatusSearch.SelectedIndex > 0)
            {
                FillDGVClient();
                ClientsStats();
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxEmailSearch.Clear();
            TextBoxLastNameSearch.Clear();
            ComboBoxCitySearch.SelectedIndex = 0;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVClient();
            ClientsStats();
        }
    }
}
