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
    public partial class StaffTicketProgression : Form
    {
        public StaffTicketProgression()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        //
        public string email;
        string ticID;
        string stafID;

        private void FillComboBoxsCategoryBrand()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                //
                sqlCommand.CommandText = "select GadCatDesig from GadgetCategory";
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxCategorySearch.Items.Add(dataReader.GetString(0));
                }
                ComboBoxCategorySearch.Items.Insert(0, "--tous--");
                dataReader.Close();
                //
                sqlCommand.CommandText = "select GadBraDesig from GadgetBrand";
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxBrandSearch.Items.Add(dataReader.GetString(0));
                }
                ComboBoxBrandSearch.Items.Insert(0, "--tous--");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxsCategoryBrand()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void GetStaffID()
        {
            try
            {
                SqlCommand sqlCommandStaffID = new SqlCommand("select StafID from Staff where StafEmail = @email", GADJIT.sqlConnection);

                GADJIT.sqlConnection.Open();
                sqlCommandStaffID.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                stafID = sqlCommandStaffID.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GetStaffID()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillDGVTicket()
        {
            try
            {
                DGVTicket.Rows.Clear();
                DGVTicketMonitoring.Rows.Clear();
                //
                String sqlQuery = "select distinct TicID, TicDT, GadRefDesig, TicSta, TicRepPri " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w, Client as c " +
                    "where t.StafID = @id and t.WorID is not null and t.GadRefID = gr.GadRefID and TicDT between @dateF and @dateT";

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = stafID;
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value;
                sqlCommand.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;

                if (ComboBoxCategorySearch.SelectedIndex > 0 || ComboBoxBrandSearch.SelectedIndex > 0 || ComboBoxReferenceSearch.SelectedIndex > 0
                    || TextBoxClientLastNameSearch.Text != "" || TextBoxWorkerLastNameSearch.Text != "")
                {
                    if (ComboBoxCategorySearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadCatID = gc.GadCatID and gc.GadCatDesig = @gcDesig";
                        sqlCommand.Parameters.Add("@gcDesig", SqlDbType.VarChar).Value = ComboBoxCategorySearch.Text;
                    }
                    if (ComboBoxBrandSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadBraID = gb.GadBraID and gb.GadBraDesig = @gbDesig";
                        sqlCommand.Parameters.Add("@gbDesig", SqlDbType.VarChar).Value = ComboBoxBrandSearch.Text;
                    }
                    if (ComboBoxReferenceSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadRefDesig = @grDesig";
                        sqlCommand.Parameters.Add("@grDesig", SqlDbType.VarChar).Value = ComboBoxReferenceSearch.Text;
                    }
                    if (TextBoxClientLastNameSearch.Text != "")
                    {
                        sqlQuery += " and t.CliID = c.CliID and c.CliLastName like @cLastName";
                        sqlCommand.Parameters.Add("@cLastName", SqlDbType.VarChar).Value = "%" + TextBoxClientLastNameSearch.Text + "%";
                    }
                    if (TextBoxWorkerLastNameSearch.Text != "")
                    {
                        sqlQuery += " and t.WorID = w.WorID and w.WorLastName like @wLastName";
                        sqlCommand.Parameters.Add("@wLastName", SqlDbType.VarChar).Value = "%" + TextBoxWorkerLastNameSearch.Text + "%";
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
                        DGVTicket.Rows.Add(dataReader.GetString(0), dataReader.GetDateTime(1), dataReader.GetString(2), dataReader.GetString(3)
                            , (dataReader["TicRepPri"].ToString() == "") ? "" : dataReader.GetSqlMoney(4).ToString());
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

        private void DGVTicket_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SqlCommand sqlCommandTicketDetail = new SqlCommand(
                    "select t.CliID, CliLastName + ' ' + CliFirstName as CliName, CliEmail, CliPhoneNumber, CliAdress, c.CitDesig, TicProb, WorLastName + ' ' + WorFirstName as WorName " +
                        "from Ticket as t, Worker as w, Client as c " +
                            "where TicID = @id and t.WorID = w.WorID and t.CliID = c.CliID",
                    GADJIT.sqlConnection);
                ticID = DGVTicket[0, e.RowIndex].Value.ToString();
                sqlCommandTicketDetail.Parameters.Add("@id", SqlDbType.VarChar).Value = ticID;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxClientID.Text = dataReader["CliID"].ToString();
                    TextBoxClientName.Text = dataReader["CliName"].ToString();
                    TextBoxClientEmail.Text = dataReader["CliEmail"].ToString();
                    TextBoxClientPhoneNumber.Text = dataReader["CliPhoneNumber"].ToString();
                    TextBoxClientAddress.Text = dataReader["CliAdress"].ToString() + " " + dataReader["CitDesig"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    TextBoxWorker.Text = dataReader["WorName"].ToString();
                }
                dataReader.Close();
                //
                DGVTicketMonitoring.Rows.Clear();
                SqlCommand sqlCommandTicketMonitoring = new SqlCommand(
                    "select TicMonDT, TicMonWho, TicMonDes, TicMonSta from TicketMonitoring where TicID = @id",
                    GADJIT.sqlConnection);
                sqlCommandTicketMonitoring.Parameters.Add("@id", SqlDbType.VarChar).Value = ticID;
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
                            who,
                            dataReader["TicMonDes"],
                            (dataReader.GetBoolean(3) ? "traiter" : "non traiter"));
                    }
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

        private void StaffTicketProgression_Load(object sender, EventArgs e)
        {
            DTPTicketFromSearch.MaxDate = DateTime.Now;
            DTPTicketToSearch.MaxDate = DateTime.Now;
            //
            GetStaffID();
            FillComboBoxsCategoryBrand();
            ComboBoxCategorySearch.SelectedIndex = 0;
            ComboBoxBrandSearch.SelectedIndex = 0;
            FillDGVTicket();
        }

        private void ClearTicketDetails()
        {
            TextBoxClientID.Clear();
            TextBoxClientName.Clear();
            TextBoxClientEmail.Clear();
            TextBoxClientPhoneNumber.Clear();
            RichTextBoxProblem.Clear();
            TextBoxWorker.Clear();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ClearTicketDetails();
            //
            FillDGVTicket();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearTicketDetails();
            //
            ComboBoxCategorySearch.SelectedIndex = 0;
            ComboBoxBrandSearch.SelectedIndex = 0;
            TextBoxClientLastNameSearch.Clear();
            TextBoxWorkerLastNameSearch.Clear();
            FillDGVTicket();
        }
    }
}
