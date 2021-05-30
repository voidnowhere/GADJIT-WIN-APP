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
        Dictionary<int, string> category = new Dictionary<int, string>();
        Dictionary<int, string> brand = new Dictionary<int, string>();
        Dictionary<int, string> reference = new Dictionary<int, string>();
        public int staffID;
        int ticID;
        public String ticCancelDes;
        public bool isTicCanceled = false;
        bool ticStaCancel = false;

        private void FillComboBoxCategory()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select GadCatID, GadCatDesig from GadgetCategory", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    category.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                    ComboBoxCategorySearch.Items.Add(dataReader.GetString(1));
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
                brand.Clear();
                ComboBoxBrandSearch.Items.Clear();
                ComboBoxReferenceSearch.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "select distinct gr.GadBraID, GadBraDesig from GadgetReference as gr, GadgetBrand as gb " +
                        "where gr.GadBraID = gb.GadBraID and GadCatID = @catID",
                        GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@catID", SqlDbType.Int).Value = category.Keys.First(k => category[k] == ComboBoxCategorySearch.Text);
                    GADJIT.sqlConnection.Open();
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        brand.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                        ComboBoxBrandSearch.Items.Add(dataReader.GetString(1));
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
                brand.Clear();
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
                reference.Clear();
                ComboBoxReferenceSearch.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "select GadRefID, GadRefDesig from GadgetReference " +
                        "where GadCatID = @catID and GadBraID = @braID",
                        GADJIT.sqlConnection);
                    sqlCommand.Parameters.Add("@catID", SqlDbType.Int).Value = category.Keys.First(k => category[k] == ComboBoxCategorySearch.Text);
                    sqlCommand.Parameters.Add("@braID", SqlDbType.Int).Value = brand.Keys.First(k => brand[k] == ComboBoxBrandSearch.Text);
                    GADJIT.sqlConnection.Open();
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        reference.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                        ComboBoxReferenceSearch.Items.Add(dataReader.GetString(1));
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
                reference.Clear();
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
                    "where t.StafID = @satfID and (t.WorID is not null or (t.WorID is null and TicSta = 'A')) " +
                    "and t.GadRefID = gr.GadRefID and gr.GadCatID = gc.GadCatID and gr.GadBraID = gb.GadBraID " +
                    "and TicDT between @dateF and @dateT";

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.Add("@satfID", SqlDbType.Int).Value = staffID;
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DateTime.Parse(DTPTicketFromSearch.Value.ToShortDateString());
                sqlCommand.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;

                if (ComboBoxCategorySearch.SelectedIndex > 0 || ComboBoxBrandSearch.SelectedIndex > 0 || ComboBoxReferenceSearch.SelectedIndex > 0
                    || TextBoxClientLastNameSearch.Text != "" || TextBoxWorkerLastNameSearch.Text != "")
                {
                    if (ComboBoxCategorySearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadCatID = @catID";
                        sqlCommand.Parameters.Add("@catID", SqlDbType.Int).Value = category.Keys.First(k => category[k] == ComboBoxCategorySearch.Text);
                    }
                    if (ComboBoxBrandSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadBraID = @braID";
                        sqlCommand.Parameters.Add("@braID", SqlDbType.Int).Value = brand.Keys.First(k => brand[k] == ComboBoxBrandSearch.Text);
                    }
                    if (ComboBoxReferenceSearch.SelectedIndex > 0)
                    {
                        sqlQuery += " and gr.GadRefID = @refID";
                        sqlCommand.Parameters.Add("@refID", SqlDbType.Int).Value = reference.Keys.First(k => brand[k] == ComboBoxReferenceSearch.Text);
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
                                status = "en cours de livraison";
                                break;
                            case "L":
                                status = "livré";
                                break;
                        }
                        DGVTicket.Rows.Add(
                            dataReader["TicID"],
                            dataReader["TicDT"], 
                            status,
                            (dataReader["TicRepPri"] == DBNull.Value) ? "" : dataReader.GetSqlMoney(3).ToString(),
                            dataReader["Gadget"],
                            dataReader["GadRefDescr"]);
                    }
                    TextBoxTotalTickets.Text = DGVTicket.Rows.Count.ToString();
                    GADJIT.sqlConnection.Close();
                    DGVTicket_CellMouseDoubleClick(null, new DataGridViewCellMouseEventArgs(0, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0)));
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
                ClearTicketDetails();
                DGVTicketMonitoring.Rows.Clear();
                ComboBoxProgression.Items.Clear();
                //
                string ticSta = DGVTicket[2, e.RowIndex].Value.ToString();
                //
                SqlCommand sqlCommandTicketDetail = new SqlCommand(
                    (ticSta != "annulé") ?
                    "select TicSta, TicAddress + ' - ' + CitDesig as Address, TicProb, CONVERT(varchar, t.CliID) + ' - ' + CliLastName + ' ' + CliFirstName as Client, CliEmail, CliPhoneNumber, WorLastName + ' ' + WorFirstName as WorName " +
                    "from Ticket as t, Worker as w, Client as cl, City as ci " +
                    "where TicID = @ticID and t.WorID = w.WorID and t.CliID = cl.CliID and t.CitID = ci.CitID"
                    :
                    "select TicSta, TicAddress + ' - ' + CitDesig as Address, TicProb, CONVERT(varchar, t.CliID) + ' - ' + CliLastName + ' ' + CliFirstName as Client, CliEmail, CliPhoneNumber " +
                    "from Ticket as t, Client as cl, City as ci " +
                    "where TicID = @ticID and t.CliID = cl.CliID and t.CitID = ci.CitID",
                    GADJIT.sqlConnection);
                ticID = (int)DGVTicket[0, e.RowIndex].Value;
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
                        case "DR":
                            ticStaCancel = true;
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "retour au client"
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "R":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "en cours de livraison"
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "EL":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "livré"
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        case "DV":
                            ComboBoxProgression.Items.AddRange(new String[] {
                                "--choisissez pour enregistrer--",
                                "annulé"
                            });
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = true;
                            break;
                        default:
                            ComboBoxProgression.Items.Add("--non disponible--");
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = false;
                            break;
                    }
                    //
                    GroupBoxClient.Text = "Client - " + dataReader["Client"].ToString();
                    TextBoxClientEmail.Text = dataReader["CliEmail"].ToString();
                    TextBoxClientPhoneNumber.Text = dataReader["CliPhoneNumber"].ToString();
                    TextBoxTicketAddress.Text = dataReader["Address"].ToString();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    if(ticSta != "annulé")
                    {
                        TextBoxWorker.Text = dataReader["WorName"].ToString();
                    }
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
                    if (ticStaCancel)
                    {
                        if(DGVTicketMonitoring.Rows.Count < 4)
                        {
                            ComboBoxProgression.Items.Clear();
                            ComboBoxProgression.Items.Add("--non disponible--");
                            ComboBoxProgression.SelectedIndex = 0;
                            ButtonSave.Enabled = false;
                        }
                        ticStaCancel = false;
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
            DTPTicketFromSearch.MaxDate = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            DTPTicketToSearch.MaxDate = DateTime.Parse(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59).AddSeconds(59);
            FillComboBoxCategory();
            FillDGVTicket();
        }

        private void ClearTicketDetails()
        {
            GroupBoxClient.Text = "";
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
            DTPTicketFromSearch.MaxDate = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            DTPTicketToSearch.MaxDate = DateTime.Now;
            ComboBoxCategorySearch.SelectedIndex = 0;
            TextBoxClientLastNameSearch.Clear();
            TextBoxWorkerLastNameSearch.Clear();
            //
            ButtonSave.Enabled = false;
            //
            FillDGVTicket();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if(ComboBoxProgression.SelectedIndex > 0)
            {
                if (MessageBox.Show("Voulez-vous confirmer la progression ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        if(ComboBoxProgression.Text == "annulé")
                        {
                            TicketCancellationReason ticketCancellationReason = new TicketCancellationReason();
                            ticketCancellationReason.staffTicketProgression = this;
                            ticketCancellationReason.ShowDialog();
                            if (!isTicCanceled) return;
                        }
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
                        sqlCommand.Parameters["@status"].Value = (isTicCanceled) ? ticCancelDes : ComboBoxProgression.Text;
                        sqlCommand.Parameters.Add("@stafID", SqlDbType.VarChar).Value = staffID;
                        sqlCommand.ExecuteNonQuery();

                        GADJIT.SendEmail(
                            TextBoxClientEmail.Text,
                            "Votre ticket sous le code [" + ticID.ToString() + "] " +
                            "a changer de progression vers \"" + ComboBoxProgression.Text + "\"");

                        MessageBox.Show("Etat du ticket changé", "Progression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Veuillez choisir une progression", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
