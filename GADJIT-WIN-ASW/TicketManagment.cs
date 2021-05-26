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
        //
        int ticID;

        private void FillDGVTicket()
        {
            try
            {
                DGVTicket.Rows.Clear();
                DGVTicketMonitoring.Rows.Clear();
                //
                String sqlQuery = 
                    "select TicID, TicDT, TicSta, gc.GadCatDesig + ' ' + gb.GadBraDesig + ' ' + gr.GadRefDesig as Gadget, TicRepPri " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb " +
                    "where t.GadRefID = gr.GadRefID and gr.GadCatID = gc.GadCatID and gr.GadBraID = gb.GadBraID";

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
                        String status = "";
                        switch (ComboBoxStatusSearch.Text)
                        {
                            case "pas encore vérifié":
                                status = "PV";
                                break;
                            case "vérifié":
                                status = "V";
                                break;
                            case "annulé":
                                status = "A";
                                break;
                            case "en cours de diagnostic":
                                status = "ED";
                                break;
                            case "confirmation diagnostic":
                                status = "CD";
                                break;
                            case "en cours de reparation":
                                status = "ER";
                                break;
                            case "reparé":
                                status = "R";
                                break;
                            case "diagnostic validé":
                                status = "DV";
                                break;
                            case "diagnostic rejeté":
                                status = "DR";
                                break;
                            case "retour au client":
                                status = "RC";
                                break;
                            case "En cours de livraison":
                                status = "EL";
                                break;
                            case "livré":
                                status = "L";
                                break;
                        }
                        sqlQuery += " and";
                        sqlQuery += " TicSta = @sta";
                        sqlCommand.Parameters.Add("@sta", SqlDbType.VarChar).Value = status;
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
                        String status = "";
                        switch (dataReader.GetString(2))
                        {
                            case "PV":
                                status = "pas encore vérifié";
                                break;
                            case "V":
                                status = "vérifié";
                                break;
                            case "A":
                                status = "annulé";
                                break;
                            case "ED":
                                status = "en cours de diagnostic";
                                break;
                            case "CD":
                                status = "confirmation diagnostic";
                                break;
                            case "ER":
                                status = "en cours de reparation";
                                break;
                            case "R":
                                status = "reparé";
                                break;
                            case "DV":
                                status = "diagnostic validé";
                                break;
                            case "DR":
                                status = "diagnostic rejeté";
                                break;
                            case "RC":
                                status = "retour au client";
                                break;
                            case "EL":
                                status = "en cours de livraison";
                                break;
                            case "L":
                                status = "livré";
                                break;
                        }
                        DGVTicket.Rows.Add(dataReader["TicID"], dataReader["TicDT"], status,
                            dataReader["Gadget"], (dataReader["TicRepPri"] != null) ? dataReader["TicRepPri"] : "");
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
                ticID = (int)DGVTicket[0, e.RowIndex].Value;
                String sqlQuery = "";
                SqlCommand sqlCommandTicketDetail = new SqlCommand();
                sqlCommandTicketDetail.Connection = GADJIT.sqlConnection;
                //GetClient
                sqlQuery =
                    "select CONVERT(varchar, t.CliID) + ' - ' + CliLastName + ' ' + CliFirstName as Client, TicAddress, TicProb " +
                    "from Ticket as t, Client as c " +
                    "where TicID = @ticID and t.CliID = c.CliID";
                sqlCommandTicketDetail.CommandText = sqlQuery;
                sqlCommandTicketDetail.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxClient.Text = dataReader["Client"].ToString();
                    TextBoxAddress.Text = dataReader["TicAddress"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                }
                dataReader.Close();
                //GetStaff
                sqlQuery =
                    "select CONVERT(varchar, t.StafID) + ' - ' + StafLastName + ' ' + StafFirstName as Satff " +
                    "from Ticket as t, Staff as s " +
                    "where TicID = @ticID and t.StafID = s.StafID";
                sqlCommandTicketDetail.CommandText = sqlQuery;
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxStaff.Text = dataReader["Satff"].ToString();
                }
                dataReader.Close();
                //GetWorker
                sqlQuery =
                    "select CONVERT(varchar, t.WorID) + ' - ' + WorLastName + ' ' + WorFirstName as Worker " +
                    "from Ticket as t, Worker as w " +
                    "where TicID = @ticID and t.WorID = w.WorID";
                sqlCommandTicketDetail.CommandText = sqlQuery;
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxWorker.Text = dataReader["Worker"].ToString();
                }
                dataReader.Close();
                //DGVTicketMonitoring//
                TextBoxWho.Clear();
                RichTextBoxDiscription.Clear();
                DGVTicketMonitoring.Rows.Clear();
                SqlCommand sqlCommandTicketMonitoring = new SqlCommand(
                    "select TicMonDT, TicMonDes, TicMonWho, TicMonWhoID from TicketMonitoring where TicID = @ticID",
                    GADJIT.sqlConnection);
                sqlCommandTicketMonitoring.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
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
                            dataReader["TicMonDT"],
                            dataReader["TicMonDes"],
                            who,
                            dataReader["TicMonWhoID"]);
                    }
                    TextBoxTotalTicketMonitoring.Text = DGVTicketMonitoring.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVTicket_CellMouseDoubleClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sqlQuery = 
                            "select StafLastName + ' ' + StafFirstName as Name " +
                            "from Staff " +
                            "where StafID = @whoID";
                        break;
                    case "Employé":
                        sqlQuery = 
                            "select WorLastName + ' ' + WorFirstName as Name " +
                            "from Worker " +
                            "where WorID = @whoID";
                        break;
                    case "Client":
                        sqlQuery = 
                            "select CliLastName + ' ' + CliFirstName as Name " +
                            "from Client " +
                            "where CliID = @whoID";
                        break;
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                sqlCommand.Parameters.Add("@whoID", SqlDbType.Int).Value = (int)DGVTicketMonitoring[3, e.RowIndex].Value;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxWho.Text = DGVTicketMonitoring[3, e.RowIndex].Value.ToString() + " - " + dataReader["Name"].ToString();
                }
                RichTextBoxDiscription.Text = DGVTicketMonitoring[1, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVTicketMonitoring_CellMouseDoubleClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void TicketManagment_Load(object sender, EventArgs e)
        {
            DTPTicketFromSearch.MaxDate = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.MaxDate = DateTime.Now;
            ComboBoxStatusSearch.SelectedIndex = 0;
            FillDGVTicket();
        }

        private void ClearTextBooxDetails()
        {
            TextBoxClient.Clear();
            TextBoxAddress.Clear();
            RichTextBoxProblem.Clear();
            TextBoxWorker.Clear();
            TextBoxStaff.Clear();
            TextBoxWho.Clear();
            RichTextBoxDiscription.Clear();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ClearTextBooxDetails();
            FillDGVTicket();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearTextBooxDetails();
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
