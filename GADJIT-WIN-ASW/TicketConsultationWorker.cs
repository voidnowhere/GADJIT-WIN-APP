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

namespace GADJIT_WIN_ASW
{
    public partial class TicketConsultationWorker : Form
    {
        public TicketConsultationWorker()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        int WID ;
        int TID;
        int CID;
        string emailtemp;
        int DID;
        int CatID;
        int BrandID;
        int RefID;
        private void TicketConsultationWorker_Load(object sender, EventArgs e)
        {
            DGVTicket.BorderStyle = BorderStyle.None;
            DGVTicket.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            DGVTicket.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVTicket.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            DGVTicket.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            DGVTicket.BackgroundColor = Color.White;

            DGVTicket.EnableHeadersVisualStyles = false;
            DGVTicket.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVTicket.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            DGVTicket.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //
            WID = WorkerPanel.WID;
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatSta = 1 ", GADJIT.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxCategorySearch.Items.Add(dr["GadCatDesig"].ToString());
            }
            dr.Close();
            GADJIT.sqlConnection.Close();
            ComboBoxCategorySearch.Items.Insert(0, "Tout");
            ComboBoxCategorySearch.SelectedIndex = 0;
            //
            FillDGV();
            TicketsStats();
            clearTxtBox();
            //
            DTPTicketFromSearch.MaxDate = DateTime.Now.AddDays(-1);
            DTPTicketToSearch.MaxDate = DateTime.Now;
            GroupeBoxDiag.Visible = false;
        }
      

        private void FillDGV()
        {
            try
            {
                DGVTicket.Rows.Clear();
                //
                String sqlQuery =
                    "select distinct TicID, TicDT, TicSta, gc.GadCatDesig + ' ' + gb.GadBraDesig + ' ' + gr.GadRefDesig as Gadget " +
                    "from Ticket as t, GadgetReference as gr, GadgetCategory as gc, GadgetBrand as gb, Worker as w, Client as c " +
                    "where t.WorID = @WorID " +
                    "and t.GadRefID = gr.GadRefID and gr.GadCatID = gc.GadCatID and gr.GadBraID = gb.GadBraID " +
                    "and TicDT between @dateF and @dateT";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("@WorID", WID);
                sqlCommand.Parameters.Add("@dateF", SqlDbType.DateTime).Value = DTPTicketFromSearch.Value.AddDays(-1);
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
                            dataReader["TicDT"],
                            dataReader["Gadget"],
                            status);
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
        private void FillComboBoxsCategoryBrand()
        {
            ComboBoxBrandSearch.Items.Clear();
            ComboBoxCategorySearch.Items.Clear();
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
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxsCategoryBrand()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
                ComboBoxBrandSearch.SelectedIndex = 0;
                ComboBoxCategorySearch.SelectedIndex = 0;
            }
        }
        private void TicketsStats()
        {
            int c = DGVTicket.Rows.Count;
            int a = 0;
            int d = 0;
            for (int i = 0; i < c; i++)
            {
                if (DGVTicket[2, i].Value.ToString() == "R") a++;
                else if (DGVTicket[2, i].Value.ToString() != "R") d++;
            }
            TextBoxTicketRepare.Text = a.ToString();
            TextBoxTicketsNoRepare.Text = d.ToString();
            TextBoxTotalTickets.Text = c.ToString();
        }

        private void ButtonEnregistrer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select max(DiagID) from Diagnostic ", GADJIT.sqlConnection);
            GADJIT.sqlConnection.Open();
            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                DID = (int)cmd.ExecuteScalar();
                DID++;
            }
            else
            {
                DID = 0;
            }
            GADJIT.sqlConnection.Close();
            dataReader.Close();
            //
            if (richTextBoxDiag.Text != "" && TextBoxPrice.Text != "" && textBoxWorkTime.Text != "" )
            {
                cmd = new SqlCommand("insert into Diagnostic Values(@DID,@TID,@DiagCmt,@Price,@Time)", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@DID", DID);
                cmd.Parameters.AddWithValue("@TID", TID);
                cmd.Parameters.AddWithValue("@DiagCmt", richTextBoxDiag.Text);
                cmd.Parameters.AddWithValue("@Price", TextBoxPrice.Text);
                cmd.Parameters.AddWithValue("@Time", textBoxWorkTime.Text);
                cmd.Parameters.AddWithValue("@prix", int.Parse(TextBoxPrice.Text));
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
                cmd = new SqlCommand("update Ticket set TicSta=@statut,TicRepPri=@price where TicID=@TID", GADJIT.sqlConnection);
                switch (ComboBoxPorg.Text)
                {
                    case "Confirmation de Diagnostic":
                        cmd.Parameters.AddWithValue("@statut", "CD");
                        break;
                    case "En cours de Reparation":
                        cmd.Parameters.AddWithValue("@statut", "ER");
                        break;
                    case "Repare":
                        cmd.Parameters.AddWithValue("@statut", "R");
                        break;
                }
                cmd.Parameters.AddWithValue("@TID", TID);
                cmd.Parameters.AddWithValue("@price", int.Parse(TextBoxPrice.Text) + 100);
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
                textBoxWorkTime.Clear();
                richTextBoxDiag.Clear();
                TextBoxPrice.Clear();
            }
            else
            {
                if(GroupeBoxDiag.Visible == true)
                {
                    MessageBox.Show("Veuillez remplir les champs avant d'enregistrer");
                    return;
                }
            }
            //
            //
            if (ComboBoxPorg.SelectedIndex > -1)
            {
                cmd = new SqlCommand("update Ticket set TicSta=@statut where TicID=@TID", GADJIT.sqlConnection);
                switch (ComboBoxPorg.Text)
                {
                    case "Confirmation de Diagnostic":
                        cmd.Parameters.AddWithValue("@statut", "CD");
                        break;
                    case "En cours de Reparation":
                        cmd.Parameters.AddWithValue("@statut", "ER");
                        break;
                    case "Repare":
                        cmd.Parameters.AddWithValue("@statut", "R");
                        break;
                }
                cmd.Parameters.AddWithValue("@TID", TID);
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
                GetClientEmail();
                if (ComboBoxPorg.Text == "CD")
                {
                    GADJIT.SendEmail(emailtemp, "Bonjour:\n\n le diagnostic de votre ticket code : [" + TID + "] est disponible consultez votre ticket sur notre Application Gadjit! \n\nGADJIT MAROC.");
                }
                else if (ComboBoxPorg.Text == "R")
                {
                    GADJIT.SendEmail(emailtemp, "Bonjour:\n\n l'Appareil avec le ticket code : [" + TID + "] a été reparé! \n On vous contactera dans le bref delais pour confirmer la livraison de votre GADJIT. \n\nGADJIT MAROC.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir une progression");
                return;
            }
            //
            GADJIT.sqlConnection.Open();
            cmd.CommandText = "insert into TicketMonitoring values(@TMID, GETDATE(), @statutTM, 'W', @WIDTM,1)";
            cmd.Parameters.AddWithValue("@TMID", TID);
            cmd.Parameters.AddWithValue("@statutTM", ComboBoxPorg.Text);
            cmd.Parameters.AddWithValue("@WIDTM", WID);
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            //
            ComboBoxPorg.Items.Clear();
            MessageBox.Show("Enregistrement reussit", "Enregister");
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
            if (ComboBoxCategorySearch.SelectedIndex > 0)
            {
                try
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select GadCatID from GadgetCategory where GadCatDesig = @CatDes", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("CatDes", ComboBoxCategorySearch.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    CatID = Convert.ToInt32(dr["GadCatID"]);
                    dr.Close();
                    //
                    ComboBoxBrandSearch.Items.Clear();
                    cmd = new SqlCommand("SELECT DISTINCT GadBraDesig FROM GadgetReference, GadgetBrand WHERE GadgetReference.GadBraID = GadgetBrand.GadBraID AND(GadCatID = @CatID) AND GadBraSta = 1 ", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ComboBoxBrandSearch.Items.Add(dr["GadBraDesig"].ToString());
                    }
                    dr.Close();
                    ComboBoxBrandSearch.Items.Insert(0, "Choisissez une marque");
                    //
                    ComboBoxBrandSearch.SelectedIndex = 0;
                    ComboBoxReferenceSearch.Items.Clear();
                    ComboBoxReferenceSearch.SelectedIndex = -1;
                    GADJIT.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cat selectedindex changed");
                }
            }
            else
            {
                ComboBoxBrandSearch.Items.Clear();
                ComboBoxReferenceSearch.Items.Clear();
            }
        }

        private void ComboBoxBrandSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxReferenceSearch.Items.Clear();
            ComboBoxReferenceSearch.SelectedIndex = -1;
            if (ComboBoxCategorySearch.SelectedIndex != 0 && ComboBoxBrandSearch.SelectedIndex != 0)
            {
                try
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select GadBraID from GadgetBrand where GadBraDesig=@bradDes", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@bradDes", ComboBoxBrandSearch.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    BrandID = Convert.ToInt32(dr["GadBraID"]);
                    dr.Close();
                    //
                    cmd = new SqlCommand("select GadRefDesig from GadgetReference where GadCatID = @CatID and GadBraID = @BrandID and GadRefSta=1", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    cmd.Parameters.AddWithValue("@BrandID", BrandID);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ComboBoxReferenceSearch.Items.Add(dr["GadRefDesig"].ToString());
                    }
                    dr.Close();
                    ComboBoxReferenceSearch.Items.Insert(0, "choisissez une reference");
                    ComboBoxReferenceSearch.SelectedIndex = 0;
                    GADJIT.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur comboBoxBrand changed index");
                }
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TicketConsultationWorker_Load(sender, e);
        }

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxWorkTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void DGVTicket_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
              try
                {
                    DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                TID = (int)row.Cells["CODE"].Value;
                SqlCommand cmd = new SqlCommand("select TicProb,TicSta,CliID from Ticket where TicID=@TID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@TID", TID);
                GADJIT.sqlConnection.Open();
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    RichTextBoxProblem.Text = dataReader["TicProb"].ToString();
                    CID = (int)dataReader["CliID"];
                    ComboBoxPorg.Items.Clear();
                    switch (dataReader["TicSta"].ToString())
                    {
                        case "ED":
                            ComboBoxPorg.Items.AddRange(new string[] { "Confirmation de Diagnostic" });
                            if (GroupeBoxDiag.Visible == false)
                            {
                                GroupeBoxDiag.Visible = true;
                            }
                            break;
                        case "DV":
                                ComboBoxPorg.Items.AddRange(new string[] { "En cours de Reparation" });
                                if (GroupeBoxDiag.Visible == true)
                                {
                                    GroupeBoxDiag.Visible = false;
                                }
                                break;

                            case "ER":
                            ComboBoxPorg.Items.AddRange(new string[] { "En cours de Reparation", "Repare" });
                            if (GroupeBoxDiag.Visible == true)
                            {
                                GroupeBoxDiag.Visible = false;
                            }
                            break;
                        case "R":
                            ComboBoxPorg.Items.Add("Repare");
                            if (GroupeBoxDiag.Visible == true)
                            {
                                GroupeBoxDiag.Visible = false;
                            }
                            break;
                        default:
                            ComboBoxPorg.Items.Add("Pas Disponible");
                            if (GroupeBoxDiag.Visible == true)
                            {
                                GroupeBoxDiag.Visible = false;
                            }
                            if (GroupeBoxDiag.Visible == true)
                            {
                                ComboBoxPorg.Visible = false;
                            }
                            break;
                    }
                    ComboBoxPorg.SelectedIndex = 0;
                    dataReader.Close();
                    GADJIT.sqlConnection.Close();
                    TextBoxGadget.Text = row.Cells["GADGET"].Value.ToString();
                    FillComboBoxsCategoryBrand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur en selection cell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
