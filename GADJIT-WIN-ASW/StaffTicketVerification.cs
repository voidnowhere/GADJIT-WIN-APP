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
    public partial class StaffTicketVerification : Form
    {
        public StaffTicketVerification()
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
                //
                String sqlQuery = "select distinct TicID, TicDT, GadRefDesig " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w, Client as c " +
                    "where (t.StafID is null or t.StafID = @id) and t.WorID is null and t.GadRefID = gr.GadRefID and TicDT between @dateF and @dateT";

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = stafID;
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value;
                sqlCommand.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;

                if (ComboBoxCategorySearch.SelectedIndex > 0 || ComboBoxBrandSearch.SelectedIndex > 0 || ComboBoxReferenceSearch.SelectedIndex > 0
                    || TextBoxClientLastNameSearch.Text != "" || TextBoxWorkerLastNameSearch.Text != "")
                {
                    if(ComboBoxCategorySearch.SelectedIndex > 0)
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
                        DGVTicket.Rows.Add(dataReader.GetString(0), dataReader.GetDateTime(1), dataReader.GetString(2));
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

        private void GetGadgetReferences()
        {
            if (ComboBoxCategorySearch.SelectedIndex > 0 && ComboBoxBrandSearch.SelectedIndex > 0)
            {
                ComboBoxReferenceSearch.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "select GadRefDesig from GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb " +
                        "where gr.GadCatID = gc.GadCatID and gc.GadCatDesig = @gcDesig and gr.GadBraID = gb.GadBraID and gb.GadBraDesig = @gbDesig",
                        GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@gcDesig", SqlDbType.VarChar).Value = ComboBoxCategorySearch.Text;
                    sqlCommand.Parameters.Add("@gbDesig", SqlDbType.VarChar).Value = ComboBoxBrandSearch.Text;
                    GADJIT.sqlConnection.Open();
                    dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ComboBoxReferenceSearch.Items.Add(dataReader.GetString(0));
                        }
                        ComboBoxReferenceSearch.Items.Insert(0, "--tous--");
                        ComboBoxReferenceSearch.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error GetGadgetReferences()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataReader.Close();
                    GADJIT.sqlConnection.Close();
                }
            }
            else
            {
                ComboBoxReferenceSearch.Items.Clear();
            }
        }

        private void ComboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGadgetReferences();
        }

        private void ComboBoxBrandSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGadgetReferences();
        }

        private void DGVTicket_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                LabelWorkerTicketsCount.Text = "";
                //
                ComboBoxWorker.Items.Clear();
                ticID = DGVTicket[0, e.RowIndex].Value.ToString();
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "select t.CliID, CliLastName + ' ' + CliFirstName as CliName, CliEmail, CliPhoneNumber, TicProb, TicSta " +
                                            "from Ticket as t, Client as c " +
                                            "where TicID = @id and t.CliID = c.CliID";
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = ticID;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxClientID.Text = dataReader["CliID"].ToString();
                    TextBoxClientName.Text = dataReader["CliName"].ToString();
                    TextBoxClientEmail.Text = dataReader["CliEmail"].ToString();
                    TextBoxClientPhoneNumber.Text = dataReader["CliPhoneNumber"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    if(dataReader["TicSta"].ToString() == "vérifié")
                    {
                        ButtonVerify.Enabled = false;
                        ButtonAssign.Enabled = true;
                    }
                    else if(dataReader["TicSta"].ToString() == "pas encore vérifié")
                    {
                        ButtonVerify.Enabled = true;
                        ButtonAssign.Enabled = false;
                    }
                }
                dataReader.Close();
                //
                sqlCommand.CommandText = 
                    "select WorLastName + ' ' + WorFirstName as WorName, (select COUNT(tw.WorID) from Ticket as tw where tw.WorID = w.WorID) as TicketCount " +
                    "from WorkerSpecialty as ws, Worker as w, Ticket as t, GadgetReference as gr " +
                    "where ws.WorID = w.WorID " +
                    "and t.GadRefID = gr.GadRefID " +
                    "and gr.GadCatID = ws.GadCatID " +
                    "and gr.GadBraID = ws.GadBraID " +
                    "and t.TicID = @id " +
                    "and w.WorDispo in ('En Ligne', 'Break') " +
                    "order by TicketCount asc";
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxWorker.Items.Add(dataReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DGVTicket_CellMouseClick()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void ComboBoxWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(
                    "select COUNT(t.WorID) from Ticket as t, Worker as w " +
                    "where t.WorID = w.WorID and w.WorLastName = @lastName and w.WorFirstName = @firstName",
                    GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[0];
                sqlCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[1];
                GADJIT.sqlConnection.Open();
                LabelWorkerTicketsCount.Text = sqlCommand.ExecuteScalar().ToString() + " Ticket";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ComboBoxWorker_SelectedIndexChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void StaffTicketVerification_Load(object sender, EventArgs e)
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
            ComboBoxWorker.Items.Clear();
            LabelWorkerTicketsCount.Text = "";
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

        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "update Ticket set StafID = @sid, TicSta = @status where TicID = @tid";
                sqlCommand.Parameters.Add("@sid", SqlDbType.VarChar).Value = stafID;
                sqlCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "vérifié";
                sqlCommand.Parameters.Add("@tid", SqlDbType.VarChar).Value = ticID;

                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "insert into TicketMonitoring values(@tid, GETDATE(), 'ticket vérifié', 'S', @sid, 0, 1)";
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("réussi", "Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButtonVerify.Enabled = false;
                ButtonAssign.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ButtonVerify_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void ButtonAssign_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "update Ticket set WorID = @wid where TicID = @tid";
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                //
                SqlCommand sqlCommandWorkerID = new SqlCommand(
                    "select WorID from Worker where WorLastName = @lastName and WorFirstName = @firstName",
                    GADJIT.sqlConnection);
                sqlCommandWorkerID.Parameters.Add("@lastName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[0];
                sqlCommandWorkerID.Parameters.Add("@firstName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[1];
                string worID = sqlCommandWorkerID.ExecuteScalar().ToString();
                //
                sqlCommand.Parameters.Add("@wid", SqlDbType.VarChar).Value = worID;
                sqlCommand.Parameters.Add("@tid", SqlDbType.VarChar).Value = ticID;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "insert into TicketMonitoring values(@tid, GETDATE(), 'ticket affecter', 'W', @wid, 0, 0)";
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("réussi", "Affectation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButtonAssign.Enabled = false;
                ButtonSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ButtonAssign_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }
    }
}
