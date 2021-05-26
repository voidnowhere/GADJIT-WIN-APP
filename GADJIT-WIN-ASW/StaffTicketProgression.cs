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
            if (ComboBoxBrandSearch.SelectedIndex > 0)
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
                DGVTicketMonitoring.Rows.Clear();
                //
                String sqlQuery =
                    "select distinct TicID, TicDT, TicSta, TicRepPri, gc.GadCatDesig + ' ' + gb.GadBraDesig + ' ' + gr.GadRefDesig as Gadget, GadRefDescr " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w, Client as c " +
                    "where t.StafID = @satfID and t.WorID is not null " +
                    "and t.GadRefID = gr.GadRefID and gr.GadCatID = gc.GadCatID and gr.GadBraID = gb.GadBraID " +
                    "and TicDT between @dateF and @dateT";

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.Add("@satfID", SqlDbType.VarChar).Value = stafID;
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
                        String status = "";
                        switch (dataReader["TicSta"].ToString())
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
                                status = "En cours de livraison";
                                break;
                            case "L":
                                status = "livré";
                                break;
                        }
                        DGVTicket.Rows.Add(
                            dataReader["TicID"],
                            dataReader["TicDT"], status,
                            (dataReader["TicRepPri"].ToString() == "") ? "" : dataReader.GetSqlMoney(4).ToString(),
                            dataReader["Gadget"],
                            dataReader["GadRefDescr"]);
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
                DGVTicketMonitoring.Rows.Clear();
                ComboBoxProgression.Items.Clear();
                //
                SqlCommand sqlCommandTicketDetail = new SqlCommand(
                    "select TicSta, TicAddress, TicProb, CONVERT(varchar, t.CliID) + ' - ' + CliLastName + ' ' + CliFirstName as Client, CliEmail, CliPhoneNumber, WorLastName + ' ' + WorFirstName as WorName " +
                    "from Ticket as t, Worker as w, Client as c " +
                    "where TicID = @ticID and t.WorID = w.WorID and t.CliID = c.CliID",
                    GADJIT.sqlConnection);
                ticID = DGVTicket[0, e.RowIndex].Value.ToString();
                sqlCommandTicketDetail.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommandTicketDetail.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    switch (dataReader["TicSta"].ToString())
                    {
                        case "V":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "en cours de diagnostic",
                                "annulé"
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "A":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "retour au client",
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "R":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "en cours de livraison",
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "EL":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "livré",
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                    }
                    //
                    TextBoxClient.Text = dataReader["Client"].ToString();
                    TextBoxClientEmail.Text = dataReader["CliEmail"].ToString();
                    TextBoxClientPhoneNumber.Text = dataReader["CliPhoneNumber"].ToString();
                    TextBoxTicketAddress.Text = dataReader["TicAddress"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    TextBoxWorker.Text = dataReader["WorName"].ToString();
                }
                dataReader.Close();
                //
                DGVTicketMonitoring.Rows.Clear();
                SqlCommand sqlCommandTicketMonitoring = new SqlCommand(
                    "select TicMonDT, TicMonWho, TicMonDes from TicketMonitoring where TicID = @ticID",
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
                        DGVTicketMonitoring.Rows.Add(dataReader["TicMonDT"], who, dataReader["TicMonDes"]);
                    }
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

        private void StaffTicketProgression_Load(object sender, EventArgs e)
        {
            DTPTicketFromSearch.MaxDate = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.MaxDate = DateTime.Now;
            FillComboBoxCategory();
            GetStaffID();
            FillDGVTicket();
        }

        private void ClearTicketDetails()
        {
            TextBoxClient.Clear();
            TextBoxClientEmail.Clear();
            TextBoxClientPhoneNumber.Clear();
            RichTextBoxProblem.Clear();
            TextBoxWorker.Clear();
            ComboBoxProgression.SelectedIndex = -1;
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
            ComboBoxCategorySearch.SelectedIndex = 0;
            TextBoxClientLastNameSearch.Clear();
            TextBoxWorkerLastNameSearch.Clear();
            DTPTicketFromSearch.Value = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.Value = DateTime.Now;
            //
            ButtonSave.Enabled = false;
            //
            FillDGVTicket();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if(ComboBoxProgression.SelectedIndex > 0)
            {
                if (MessageBox.Show("Voulez vous confirmer la progression", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = "update Ticket set TicSta = @status where TicID = @ticID";
                        String status = "";
                        switch (ComboBoxProgression.Text)
                        {
                            case "en cours de diagnostic":
                                status = "ED";
                                break;
                            case "annulé":
                                status = "A";
                                break;
                            case "retour au client":
                                status = "RC";
                                break;
                            case "en cours de livraison":
                                status = "EL";
                                break;
                            case "livré":
                                status = "L";
                                break;
                        }
                        sqlCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                        sqlCommand.Parameters.Add("@ticID", SqlDbType.Int).Value = ticID;

                        sqlCommand.Connection = GADJIT.sqlConnection;
                        GADJIT.sqlConnection.Open();

                        sqlCommand.ExecuteNonQuery();

                        sqlCommand.CommandText = "insert into TicketMonitoring values(@ticID, GETDATE(), @status, 'S', @stafID, 1)";
                        sqlCommand.Parameters["@status"].Value = ComboBoxProgression.Text;
                        sqlCommand.Parameters.Add("@stafID", SqlDbType.VarChar).Value = stafID;
                        sqlCommand.ExecuteNonQuery();

                        GADJIT.SendEmail(
                            TextBoxClientEmail.Text,
                            "Votre ticket sous le code [" + ticID.ToString() + "] " +
                            "a changer de progression vers \"" + ComboBoxProgression.Text + "\"");

                        MessageBox.Show("Modifier", "Progression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ButtonSave.Enabled = false;
                        GADJIT.sqlConnection.Close();
                        ButtonSearch_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error ButtonSave_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
