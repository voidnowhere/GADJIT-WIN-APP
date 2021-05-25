﻿using System;
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

namespace GADJIT_WIN_ASW
{
    public partial class TicketConsultationWorker : Form
    {
        public TicketConsultationWorker()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        int WID = WorkerPanel.WID;
        int TID;
        int RefID;
        int CatID;
        int BrandID;
        string Ref = "";
        string Cat = "";
        string Brand = "";
        int CID;
        string emailtemp = "";
        int DID;
        private void TicketConsultationWorker_Load(object sender, EventArgs e)
        {
            FillComboBoxsCategoryBrand();
            //
            FillDGV();
            TicketsStats();
            clearTxtBox();
            //
            DTPTicketFromSearch.MaxDate = DateTime.Now;
            DTPTicketToSearch.MaxDate = DateTime.Now;
            GroupeBoxDiag.Visible = false;
        }
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
                ComboBoxCategorySearch.SelectedIndex = 0;
                dataReader.Close();
                //
                sqlCommand.CommandText = "select GadBraDesig from GadgetBrand";
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxBrandSearch.Items.Add(dataReader.GetString(0));
                }
                ComboBoxBrandSearch.Items.Insert(0, "--tous--");
                ComboBoxBrandSearch.SelectedIndex = 0;
                dataReader.Close();
                sqlCommand.CommandText = "select TicID from Ticket where WorID=@WID";
                sqlCommand.Parameters.AddWithValue("@WID", WID);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    ComboBoxCode.Items.Add(dataReader.GetString(0));
                }
                ComboBoxCode.Items.Insert(0, "--tous--");
                ComboBoxCode.SelectedIndex = 0;
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
        private void FillDGV()
        {
            try
            {
                DGVTicket.Rows.Clear();
                //
                String sqlQuery = "select distinct TicID, TicDT, GadRefDesig,TicSta " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w " +
                    "where t.WorID = @id and t.GadRefID = gr.GadRefID and TicDT between @dateF and @dateT";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = WID;
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value;
                sqlCommand.Parameters.Add("@dateT", SqlDbType.DateTime).Value = DTPTicketToSearch.Value;

                if (ComboBoxCategorySearch.SelectedIndex > 0 || ComboBoxBrandSearch.SelectedIndex > 0 || ComboBoxReferenceSearch.SelectedIndex > 0)
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
                }
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = GADJIT.sqlConnection;
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DGVTicket.Rows.Add(dataReader.GetString(0), dataReader.GetDateTime(1), dataReader.GetString(2), dataReader.GetString(3));
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
                    TID = (int)row.Cells["CODE"].Value;
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta,CliID from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                        RefID = (int)dataReader["GadRefID"];
                        CID = (int)dataReader["CliID"];
                        ComboBoxPorg.Items.Clear();
                        switch (dataReader["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                if (GroupeBoxDiag.Visible == false)
                                {
                                    GroupeBoxDiag.Visible = true;
                                }
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dataReader.Close();
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
                    TID = (int)row.Cells["CODE"].Value;
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta,CliID from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                        RefID = (int)dataReader["GadRefID"];
                        CID = (int)dataReader["CliID"];
                        ComboBoxPorg.Items.Clear();
                        switch (dataReader["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                if (GroupeBoxDiag.Visible == false)
                                {
                                    GroupeBoxDiag.Visible = true;
                                }
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dataReader.Close();
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
                    TID = (int)row.Cells["CODE"].Value;
                    SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta,CliID from Ticket where TicID=@TID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@TID", TID);
                    GADJIT.sqlConnection.Open();
                    dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                        RefID = (int)dataReader["GadRefID"];
                        CID = (int)dataReader["CliID"];
                        ComboBoxPorg.Items.Clear();
                        switch (dataReader["TicSta"].ToString())
                        {
                            case "en cours de diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de diagnostic", "confirmation diagnostic" });
                                if (GroupeBoxDiag.Visible == false)
                                {
                                    GroupeBoxDiag.Visible = true;
                                }
                                break;
                            case "confirmation diagnostic":
                                ComboBoxPorg.Items.AddRange(new string[] { "confirmation diagnostic", "en cours de reparation" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "en cours de reparation":
                                ComboBoxPorg.Items.AddRange(new string[] { "en cours de reparation", "repare" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                            case "reparé":
                                ComboBoxPorg.Items.Add("reparé");
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;
                        }
                        ComboBoxPorg.SelectedIndex = 0;
                        dataReader.Close();
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
        private void BringBrandCatRef()
        {
            SqlCommand cmd = new SqlCommand("select GadRefDesig,GadCatID,GadBraID from GadgetReference where GadRefID=@RefID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@RefID", RefID);
            GADJIT.sqlConnection.Open();
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                Ref = dataReader["GadRefDesig"].ToString();
                CatID = (int)dataReader["GadCatID"];
                BrandID = (int)dataReader["GadBraID"];
                dataReader.Close();
                cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatID=@CatID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CatID", CatID);
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    Cat = dataReader["GadCatDesig"].ToString();
                    dataReader.Close();
                }
                //
                cmd = new SqlCommand("select GadBraDesig from GadgetBrand where GadBraID=@BraID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@BraID", BrandID);
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    Brand = dataReader["GadBraDesig"].ToString();
                    dataReader.Close();
                }
                TextBoxGadget.Text = Cat + " " + Brand + " " + Ref;
            }
            GADJIT.sqlConnection.Close();
        }
        private void TicketsStats()
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
            DID = (int)cmd.ExecuteScalar();
            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                DID++;
            }
            else
            {
                DID = '0';
            }
            GADJIT.sqlConnection.Close();
            dataReader.Close();
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
            GADJIT.sqlConnection.Open();
            cmd.CommandText = "insert into TicketMonitoring values(@TID, GETDATE(), @statut, 'W', @WID, 0, 0)";
            cmd.Parameters.AddWithValue("@TID", TID);
            cmd.Parameters.AddWithValue("@statut", ComboBoxPorg.Text);
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
            if (ComboBoxPorg.Text == "confirmation diagnostic")
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
                msg.Body = "Bonjour:\n\n le diagnostic de votre ticket code : [" + TID + "] est disponible consultez votre ticket sur notre Application Gadjit! \n\nGADJIT MAROC.";
                client.Send(msg);
            }
            else if (ComboBoxPorg.Text == "reparé")
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
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            emailtemp = dataReader["CliEmail"].ToString();
            dataReader.Close();
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
            FillDGV();
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
    }
}
