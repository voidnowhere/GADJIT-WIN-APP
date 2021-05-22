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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GADJIT_WIN_ASW
{
    public partial class TicketConsultationWorker : Form
    {
        public TicketConsultationWorker()
        {
            InitializeComponent();
        }
        SqlDataReader dataReader;
        string WID = WorkerPanel.WID;
        string TID = "";
        string RefID = "";
        string CatID = "";
        string BrandID = "";
        string Ref = "";
        string Cat = "";
        string Brand = "";
        string CID = "";
        string emailtemp = "";
        string DID = "D";
        string Statut = "";
        private void TicketConsultationWorker_Load(object sender, EventArgs e)
        {
            FillComboBoxGadgetBrand_Category_ref_sta();
            ComboBoxStatut.SelectedIndex = 0;
            //
            FillDGV();
            ClientsStats();
            clearTxtBox();
            //
            DTPTicketFromSearch.MaxDate = DateTime.Now;
            DTPTicketToSearch.MaxDate = DateTime.Now;
        }
        private void FillComboBoxGadgetBrand_Category_ref_sta()
        {
            GADJIT.sqlConnection.Open();
            //
            SqlCommand cmd = new SqlCommand("select GadRefDesig from GadgetReference", GADJIT.sqlConnection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ComboBoxRef.Items.Add(dataReader["GadRefDesig"].ToString());
            }
            dataReader.Close();
            ComboBoxRef.Items.Insert(0, "TOUT");
            ComboBoxRef.SelectedIndex = 0;
            cmd = new SqlCommand("select DISTINCT TicSta , TicID from Ticket where WorID = @WID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@WID", WID);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ComboBoxCODE.Items.Add(dataReader["TicID"].ToString());
                ComboBoxStatut.Items.Add(dataReader["TicSta"].ToString());
            }
            dataReader.Close();
            ComboBoxCODE.Items.Insert(0, "TOUT");
            ComboBoxCODE.SelectedIndex = 0;
            ComboBoxStatut.Items.Insert(0, "TOUT");
            ComboBoxStatut.SelectedIndex = 0;
            GADJIT.sqlConnection.Close();
        }
        private void FillDGV()
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
        private void clearTxtBox()
        {
            RichTextBoxProblem.Clear();
            richTextBoxDiag.Clear();
            TextBoxGadget.Clear();
            TextBoxPrice.Clear();
            ComboBoxPorg.Items.Clear();
        }

        private void DGVTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                    TID = row.Cells["CODE"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        RichTextBoxProblem.Text = dr["TicProb"].ToString();
                        RefID = dr["GadRefID"].ToString();
                        CID = dr["CliID"].ToString();
                        ComboBoxPorg.Items.Clear();
                        switch (dr["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                richTextBoxDiag.ReadOnly = false;
                                TextBoxPrice.ReadOnly = false;
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                        BringBrandCatRef();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur en selection cell", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DGVTicket_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                    TID = row.Cells["CODE"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        RichTextBoxProblem.Text = dr["TicProb"].ToString();
                        RefID = dr["GadRefID"].ToString();
                        CID = dr["CliID"].ToString();
                        ComboBoxPorg.Items.Clear();
                        switch (dr["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                richTextBoxDiag.ReadOnly = false;
                                TextBoxPrice.ReadOnly = false;
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                        BringBrandCatRef();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur en selection cell", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DGVTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                    TID = row.Cells["CODE"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta,CliID from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        RichTextBoxProblem.Text = dr["TicProb"].ToString();
                        RefID = dr["GadRefID"].ToString();
                        CID = dr["CliID"].ToString();
                        ComboBoxPorg.Items.Clear();
                        switch (dr["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                richTextBoxDiag.ReadOnly = false;
                                TextBoxPrice.ReadOnly = false;
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                richTextBoxDiag.ReadOnly = true;
                                TextBoxPrice.ReadOnly = true;
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dr.Close();
                        GADJIT.sqlConnection.Close();
                        BringBrandCatRef();
                    }   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erreur en selection cell", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BringBrandCatRef()
        {
            SqlCommand cmd = new SqlCommand("select GadRefDesig,GadCatID,GadBraID from GadgetReference where GadRefID=@RefID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@RefID", RefID);
            GADJIT.sqlConnection.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Ref  = dr["GadRefDesig"].ToString();
                CatID = dr["GadCatID"].ToString();
                BrandID = dr["GadBraID"].ToString();
                dr.Close();
                cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatID=@CatID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CatID", CatID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Cat  = dr["GadCatDesig"].ToString();
                    dr.Close();
                }
                //
                cmd = new SqlCommand("select GadBraDesig from GadgetBrand where GadBraID=@BraID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@BraID", BrandID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Brand = dr["GadBraDesig"].ToString();
                    dr.Close();
                }
                TextBoxGadget.Text = Cat +" "+ Brand + " "+Ref;
            }
            GADJIT.sqlConnection.Close();
        }
        private void ClientsStats()
        {
            int c = DGVTicket.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVTicket[2, i].Value.ToString() == "reparé") a++;
                else if (DGVTicket[2, i].Value.ToString() != "reparé") d++;
            }
            TextBoxTicketRepare.Text = a.ToString();
            TextBoxTicketsNoRepare.Text = d.ToString();
            TextBoxTotalTickets.Text = c.ToString();
        }

        private void ButtonEnregistrer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select max(DiagID) from Diagnostic ", GADJIT.sqlConnection);
            GADJIT.sqlConnection.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                DID += (Convert.ToInt32(Regex.Match(dr.GetString(0), @"[0-9]").ToString()) + 1).ToString();
            }
            catch
            {
                DID = "D0";
            }
            GADJIT.sqlConnection.Close();
            dr.Close();
            //
            cmd = new SqlCommand("insert into Diagnostic Values(@DID,@TID,@DiagCmt,@Price,@Time)", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@DID", DID);
            cmd.Parameters.AddWithValue("@TID", TID);
            cmd.Parameters.AddWithValue("@DiagCmt", richTextBoxDiag.Text);
            cmd.Parameters.AddWithValue("@Price", TextBoxPrice.Text);
            cmd.Parameters.AddWithValue("@Time", textBoxWorkTime.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            //
            cmd = new SqlCommand("update Ticket set TicSta=@statut where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@statut", ComboBoxPorg.Text);
            cmd.Parameters.AddWithValue("@TID", TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            GetClientEmail();
            if (ComboBoxPorg.Text== "confirmation diagnostic")
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
                MailMessage msg = new MailMessage();
                msg.To.Add(emailtemp);
                msg.From = new MailAddress("GADJITMA@gmail.com");
                msg.Subject = "Diagnostic Disponible";
                msg.Body = "Bonjour:\n\n le diagnostic de votre ticket code : ["+TID+"] est disponible consultez votre ticket sur notre Application Gadjit! \n\nGADJIT MAROC.";
                client.Send(msg);
            }
            else if(ComboBoxPorg.Text == "reparé")
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
                MailMessage msg = new MailMessage();
                msg.To.Add(emailtemp);
                msg.From = new MailAddress("GADJITMA@gmail.com");
                msg.Subject = "Appareil reparé  ";
                msg.Body = "Bonjour:\n\n l'Appareil avec le ticket code : [" + TID + "] a été reparé! \n On vous contactera dans le bref delais pour confirmer la livraison de votre GADJIT. \n\nGADJIT MAROC.";
                client.Send(msg);
            }
            TicketConsultationWorker_Load(sender, e);
        }
        private void GetClientEmail()
        {
            SqlCommand cmd = new SqlCommand("select CliEmail from client where CliID=@CID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            emailtemp = dr["CliEmail"].ToString();
            dr.Close();
            GADJIT.sqlConnection.Close();
        }

        private void TicketConsultationWorker_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='Hors Ligne' where WorID=@WID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@WID", WID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
        }

        private void ButtonRecherche_Click(object sender, EventArgs e)
        {
            DGVTicket.Rows.Clear();
            if (ComboBoxCODE.SelectedIndex != 0)
            {
                TID = ComboBoxCODE.Text;
            }
            if (ComboBoxRef.SelectedIndex != 0)
            {
                SqlCommand cmd = new SqlCommand("select GadRefID from GadgetReference where GadRefDesig=@RefDes", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@RefDes", ComboBoxRef.Text);
                GADJIT.sqlConnection.Open();
                dr.Read();
                RefID = dr["GadRefID"].ToString();
                dr.Close();
                GADJIT.sqlConnection.Close();
            }
            if (ComboBoxStatut.SelectedIndex != 0)
            {
                Statut = ComboBoxStatut.Text;
            }
            SqlCommand cm = new SqlCommand("Select TicID,TicDT,TicSta from ticket where WorID=@WID and GadRefID=@Ref and TicSta=@Sta and TicID=@TID and TicDT between @dateF and @dateT", GADJIT.sqlConnection);
            cm.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value;
            cm.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;
            cm.Parameters.AddWithValue("@WID", WID);
            cm.Parameters.AddWithValue("@Ref", RefID);
            cm.Parameters.AddWithValue("@Sta", Statut);
            cm.Parameters.AddWithValue("@TID", TID);
            GADJIT.sqlConnection.Open();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DGVTicket.Rows.Add(dr["TicID"], dr["TicDT"], dr["TicSta"]);
                }
            }
            dr.Close();
            GADJIT.sqlConnection.Close();
        }
    }
}
