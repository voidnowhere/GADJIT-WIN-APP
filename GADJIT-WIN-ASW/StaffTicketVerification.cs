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
        int ticID;
        int stafID;

        private void GetStaffID()
        {
            try
            {
                SqlCommand sqlCommandStaffID = new SqlCommand("select StafID from Staff where StafEmail = @email", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                sqlCommandStaffID.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                stafID = (int)sqlCommandStaffID.ExecuteScalar();
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

        private void FillComboBoxCategory()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select GadCatDesig from GadgetCategory", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxCategorySearch.Items.Add(dataReader.GetString(0));
                }
                ComboBoxCategorySearch.Items.Insert(0, "--tous--");
                ComboBoxCategorySearch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCategory()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void FillComboBoxBrand()
        {
            if (ComboBoxCategorySearch.SelectedIndex > 0)
            {
                ComboBoxBrandSearch.Items.Clear();
                ComboBoxReferenceSearch.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "select distinct GadBraDesig from GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb " +
                        "where gr.GadBraID = gb.GadBraID and gr.GadCatID = gc.GadCatID and GadCatDesig = @catID",
                        GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@catID", SqlDbType.VarChar).Value = ComboBoxCategorySearch.Text;
                    GADJIT.sqlConnection.Open();
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ComboBoxBrandSearch.Items.Add(dataReader.GetString(0));
                    }
                    ComboBoxBrandSearch.Items.Insert(0, "--tous--");
                    ComboBoxBrandSearch.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error FillComboBoxBrand()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataReader.Close();
                    GADJIT.sqlConnection.Close();
                }
            }
            else
            {
                ComboBoxBrandSearch.Items.Clear();
                ComboBoxReferenceSearch.Items.Clear();
            }
        }

        private void ComboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxBrand();
        }

        private void FillComboBoxReference()
        {
            if(ComboBoxBrandSearch.SelectedIndex > 0)
            {
                ComboBoxReferenceSearch.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "select GadRefDesig from GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb " +
                        "where gr.GadCatID = gc.GadCatID and gc.GadCatDesig = @catDesig and gr.GadBraID = gb.GadBraID and gb.GadBraDesig = @braDesig",
                        GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@catDesig", SqlDbType.VarChar).Value = ComboBoxCategorySearch.Text;
                    sqlCommand.Parameters.Add("@braDesig", SqlDbType.VarChar).Value = ComboBoxBrandSearch.Text;
                    GADJIT.sqlConnection.Open();
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ComboBoxReferenceSearch.Items.Add(dataReader.GetString(0));
                    }
                    ComboBoxReferenceSearch.Items.Insert(0, "--tous--");
                    ComboBoxReferenceSearch.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error FillComboBoxReference()", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComboBoxBrandSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxReference();
        }

        private void FillDGVTicket()
        {
            try
            {
                DGVTicket.Rows.Clear();
                //
                String sqlQuery = 
                    "select distinct TicID, TicDT, gc.GadCatDesig + ' ' + gb.GadBraDesig + ' ' + gr.GadRefDesig as Gadget, GadRefDescr " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w, Client as c " +
                    "where t.TicSta != 'A' and (t.StafID is null or t.StafID = @id) and t.WorID is null " +
                    "and t.GadRefID = gr.GadRefID and gr.GadCatID = gc.GadCatID and gr.GadBraID = gb.GadBraID " +
                    "and TicDT between @dateF and @dateT";

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = stafID;
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
                        DGVTicket.Rows.Add(dataReader.GetInt32(0), dataReader.GetDateTime(1), dataReader.GetString(2), dataReader.GetString(3));
                    }
                    TextBoxTotalTickets.Text = DGVTicket.Rows.Count.ToString();
                }
                else
                {
                    ButtonAssign.Enabled = false;
                    ButtonCancel.Enabled = false;
                    ButtonAssign.Enabled = false;
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
                LabelWorkerTicketsCount.Text = "";
                ComboBoxWorker.Items.Clear();
                ticID = (int)DGVTicket[0, e.RowIndex].Value;
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText =
                    "select CONVERT(varchar, t.CliID) + ' - ' + CliLastName + ' ' + CliFirstName as Client, CliEmail, CliPhoneNumber, TicAddress, TicProb, TicSta " +
                    "from Ticket as t, Client as c " +
                    "where TicID = @ticID and t.CliID = c.CliID";
                sqlCommand.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    TextBoxClient.Text = dataReader["Client"].ToString();
                    TextBoxClientEmail.Text = dataReader["CliEmail"].ToString();
                    TextBoxClientPhoneNumber.Text = dataReader["CliPhoneNumber"].ToString();
                    TextBoxTicketAddress.Text = dataReader["TicAddress"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    if (dataReader["TicSta"].ToString() == "V")
                    {
                        ButtonVerify.Enabled = false;
                        ButtonCancel.Enabled = true;
                        ButtonAssign.Enabled = true;
                    }
                    else if (dataReader["TicSta"].ToString() == "PV")
                    {
                        ButtonVerify.Enabled = true;
                        ButtonCancel.Enabled = true;
                        ButtonAssign.Enabled = false;
                    }
                }
                dataReader.Close();
                //
                sqlCommand.CommandText =
                    "declare @catID int, @braID int " +
                    "set @catID = (select GadCatID from Ticket as t, GadgetReference as gr where TicID = @ticID and t.GadRefID = gr.GadRefID) " +
                    "set @braID = (select GadBraID from Ticket as t, GadgetReference as gr where TicID = @ticID and t.GadRefID = gr.GadRefID) " +
                    "select w.WorLastName + ' ' + w.WorFirstName as Name, (select COUNT(TicID) from Ticket as t where t.WorID = w.WorID and TicSta in('V', 'ED', 'ER')) as TicketIn " +
                    "from WorkerSpecialty as ws, Worker as w " +
                    "where ws.WorID = w.WorID and ws.GadCatID = @catID and ws.GadBraID = @braID " +
                    "order by TicketIn asc";
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ComboBoxWorker.Items.Add(dataReader["Name"] + " | " + dataReader["TicketIn"] + " ticket en cours");
                    }
                    ComboBoxWorker.Items.Insert(0, "--choisissez pour affecter--");
                    ComboBoxWorker.SelectedIndex = 0;
                }
                else
                {
                    ComboBoxWorker.Items.Insert(0, "--aucun employé--");
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

        private void StaffTicketVerification_Load(object sender, EventArgs e)
        {
            DTPTicketFromSearch.MaxDate = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.MaxDate = DateTime.Now;
            //
            GetStaffID();
            FillComboBoxCategory();
            FillDGVTicket();
        }

        private void ClearTicketDetails()
        {
            TextBoxClient.Clear();
            TextBoxClientEmail.Clear();
            TextBoxClientPhoneNumber.Clear();
            TextBoxTicketAddress.Clear();
            RichTextBoxProblem.Clear();
            ComboBoxWorker.Items.Clear();
            LabelWorkerTicketsCount.Text = "";
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ClearTicketDetails();
            ComboBoxCategorySearch.SelectedIndex = 0;
            TextBoxClientLastNameSearch.Clear();
            TextBoxWorkerLastNameSearch.Clear();
            DTPTicketFromSearch.Value = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.Value = DateTime.Now;
            //
            ButtonVerify.Enabled = false;
            ButtonCancel.Enabled = false;
            ButtonAssign.Enabled = false;
            //
            FillDGVTicket();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearTicketDetails();
            ComboBoxCategorySearch.SelectedIndex = 0;
            //
            ButtonVerify.Enabled = false;
            ButtonCancel.Enabled = false;
            ButtonAssign.Enabled = false;
            //
            FillDGVTicket();
        }

        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous confirmer la verification", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "update Ticket set StafID = @stafID, TicSta = @status where TicID = @ticID";
                    sqlCommand.Parameters.Add("@stafID", SqlDbType.Int).Value = stafID;
                    sqlCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "V";
                    sqlCommand.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;

                    sqlCommand.Connection = GADJIT.sqlConnection;
                    GADJIT.sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "insert into TicketMonitoring values(@ticID, GETDATE(), 'ticket vérifié', 'S', @stafID, 1)";
                    sqlCommand.ExecuteNonQuery();

                    GADJIT.SendEmail(TextBoxClientEmail.Text, "Votre ticket sous le code [" + ticID + "] a été vérifié");

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
        }

        private void ButtonAssign_Click(object sender, EventArgs e)
        {
            if(ComboBoxWorker.SelectedIndex > 0)
            {
                if(MessageBox.Show("Voulez vous confirmer l'affectation", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        SqlCommand sqlCommandAssigne = new SqlCommand();
                        sqlCommandAssigne.CommandText = "update Ticket set WorID = @worID where TicID = @ticID";
                        sqlCommandAssigne.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
                        sqlCommandAssigne.Connection = GADJIT.sqlConnection;
                        //
                        SqlCommand sqlCommandWorkerID = new SqlCommand(
                            "select WorID from Worker where WorLastName = @lastName and WorFirstName = @firstName",
                            GADJIT.sqlConnection);
                        sqlCommandWorkerID.Parameters.Add("@lastName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[0];
                        sqlCommandWorkerID.Parameters.Add("@firstName", SqlDbType.VarChar).Value = ComboBoxWorker.Text.Split(' ')[1];
                        GADJIT.sqlConnection.Open();
                        sqlCommandAssigne.Parameters.Add("@worID", SqlDbType.Int).Value = (int)sqlCommandWorkerID.ExecuteScalar();
                        //
                        sqlCommandAssigne.ExecuteNonQuery();
                        //
                        sqlCommandAssigne.CommandText = "insert into TicketMonitoring values(@ticID, GETDATE(), 'ticket affecter', 'S', @stafID, 0)";
                        sqlCommandAssigne.Parameters.Add("@stafID", SqlDbType.Int).Value = stafID;
                        sqlCommandAssigne.ExecuteNonQuery();

                        MessageBox.Show("réussi", "Affectation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GADJIT.sqlConnection.Close();
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous confirmer l'annulation", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "update Ticket set StafID = @stafID, TicSta = 'A' where TicID = @ticID";
                    sqlCommand.Parameters.Add("@stafID", SqlDbType.Int).Value = stafID;
                    sqlCommand.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
                    sqlCommand.Connection = GADJIT.sqlConnection;
                    GADJIT.sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    //
                    sqlCommand.CommandText = "insert into TicketMonitoring values(@ticID, GETDATE(), 'ticket annulé', 'S', @stafID, 1)";
                    sqlCommand.ExecuteNonQuery();

                    GADJIT.SendEmail(TextBoxClientEmail.Text, "Votre ticket sous le code [" + ticID + "] a été annulé");

                    MessageBox.Show("réussi", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonAssign.Enabled = false;
                    GADJIT.sqlConnection.Close();
                    ButtonSearch_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error ButtonCancel_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }
    }
}
