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
    public partial class TicketManagment : Form
    {
        public TicketManagment()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;

        private void FillDGVTicket()
        {
            try
            {
                DGVTicket.Rows.Clear();
                //
                String sqlQuery = "select TicID, TicDT, TicSta, GadRefDesig, TicRepPri" +
                    " from Ticket as t, GadgetReference as gr" +
                    " where t.GadRefID = gr.GadRefID";

                SqlCommand sqlCommand = new SqlCommand();

                sqlQuery += " and TicDT between @dateF and @dateT";
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value;
                sqlCommand.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;

                if (TextBoxRepairePriceFromSearch.Text != "" || TextBoxRepairePriceToSearch.Text != ""
                    || ComboBoxStatusSearch.SelectedIndex > 0)
                {
                    if (TextBoxRepairePriceFromSearch.Text != "" && TextBoxRepairePriceToSearch.Text != "")
                    {
                        sqlQuery += " and";
                        sqlQuery += " TicRepPri between @priceF and @priceT";
                        sqlCommand.Parameters.Add("@priceF", SqlDbType.Money).Value = Convert.ToDecimal(TextBoxRepairePriceFromSearch.Text);
                        sqlCommand.Parameters.Add("@priceT", SqlDbType.Money).Value = Convert.ToDecimal(TextBoxRepairePriceToSearch.Text);
                    }
                    if (ComboBoxStatusSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and";
                        sqlQuery += " TicSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.VarChar).Value = ComboBoxStatusSearch.Text;
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
                        DGVTicket.Rows.Add(dataReader.GetString(0), dataReader.GetDateTime(1), dataReader.GetString(2),
                            dataReader.GetString(3), dataReader.GetSqlMoney(4));
                    }
                    TextBoxTotalTickets.Text = DGVTicket.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillDGVTicket()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVTicket_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SqlCommand sqlCommandTicketDetail = new SqlCommand(
                    "select t.CliID, (CliLastName + ' ' + CliFirstName) as CliName, TicProb, t.StafID, StafLastName, t.WorID, WorLastName " +
                    "from Ticket as t, Client as c, Staff as s, Worker as w " +
                    "where TicID = @id and t.CliID = c.CliID and t.StafID = s.StafID and t.WorID = w.WorID",
                    GADJIT.sqlConnection);
                sqlCommandTicketDetail.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVTicket[0, e.RowIndex].Value.ToString();
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxClientID.Text = dataReader["CliID"].ToString();
                    TextBoxClientName.Text = dataReader["CliName"].ToString();
                    //
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    //
                    TextBoxStaffID.Text = dataReader["StafID"].ToString();
                    TextBoxStaffLastName.Text = dataReader["StafLastName"].ToString();
                    //
                    TextBoxWorkerID.Text = dataReader["WorID"].ToString();
                    TextBoxWorkerLastName.Text = dataReader["WorLastName"].ToString();
                }
                dataReader.Close();
                //
                TextBoxWhoID.Clear();
                TextBoxWhoName.Clear();
                RichTextBoxDiscription.Clear();
                DGVTicketMonitoring.Rows.Clear();
                SqlCommand sqlCommandTicketMonitoring = new SqlCommand(
                    "select TicID, TicMonDT, TicMonWho, TicMonSta from TicketMonitoring where TicID = @id",
                    GADJIT.sqlConnection);
                sqlCommandTicketMonitoring.Parameters.Add("@id", SqlDbType.VarChar).Value = DGVTicket[0, e.RowIndex].Value.ToString();
                dataReader = sqlCommandTicketMonitoring.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        String who = "";
                        switch (dataReader["TicMonWho"].ToString())
                        {
                            case "S":
                                who = "Personnel";
                                break;
                            case "W":
                                who = "Employé";
                                break;
                            case "C":
                                who = "Client";
                                break;
                        }
                        DGVTicketMonitoring.Rows.Add(
                            dataReader["TicID"],
                            dataReader["TicMonDT"],
                            who,
                            (dataReader.GetBoolean(3) ? "traiter" : "non traiter"));
                    }
                    TextBoxTotalTicketMonitoring.Text = DGVTicketMonitoring.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVTicket_CellClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void DGVTicketMonitoring_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                String sqlQuery = "";
                switch (DGVTicketMonitoring[2, e.RowIndex].Value.ToString())
                {
                    case "Personnel":
                        sqlQuery = "select TicMonWhoID, StafLastName + ' ' + StafFirstName as Name, TicMonDes " +
                            "from TicketMonitoring, Staff " +
                            "where TicMonWhoID = StafID";
                        break;
                    case "Employé":
                        sqlQuery = "select TicMonWhoID, WorLastName + ' ' + WorFirstName as Name, TicMonDes " +
                            "from TicketMonitoring, Worker " +
                            "where TicMonWhoID = WorID";
                        break;
                    case "Client":
                        sqlQuery = "select TicMonWhoID, CliLastName + ' ' + CliFirstName as Name, TicMonDes " +
                            "from TicketMonitoring, Client " +
                            "where TicMonWhoID = CliID";
                        break;
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxWhoID.Text = dataReader["TicMonWhoID"].ToString();
                    TextBoxWhoName.Text = dataReader["Name"].ToString();
                    RichTextBoxDiscription.Text = dataReader["TicMonDes"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVTicketMonitoring_CellClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void TicketManagment_Load(object sender, EventArgs e)
        {
            DTPTicketFromSearch.MaxDate = DateTime.Now;
            DTPTicketToSearch.MaxDate = DateTime.Now;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVTicket();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            FillDGVTicket();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxRepairePriceFromSearch.Clear();
            TextBoxRepairePriceToSearch.Clear();
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVTicket();
        }

        private void OnlyNumbersKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("n'entrez que des nombres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
