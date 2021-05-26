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

namespace GADJIT_WIN_CLIENT
{
    public partial class ConsultationTicketForClient : Form
    {
        public ConsultationTicketForClient()
        {
            InitializeComponent();
        }
        string emailtemp = "";
        public static int CID ;
        public static int TID ;
        int RefID;
        int CatID ;
        int BrandID ;
        public static string price = "";
        public static string Ref = "";
        public static string Cat = "";
        public static string Brand = "";
        public static string prob = "";
        //
        SqlDataReader dr;
        private void ConsultationTicketForClient_Load(object sender, EventArgs e)
        {
            emailtemp = Login.Cemail;
            //
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select CliID from Client where CliEmail = '" + emailtemp + "'", GADJIT.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            CID = Convert.ToInt32(dr["CliID"]);
            dr.Close();
            //
            cmd = new SqlCommand("select TicID from Ticket where CliID = @CID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CID", CID);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxCodeTicket.Items.Add(dr["TicID"].ToString());
            }
            dr.Close();
            ComboBoxCodeTicket.SelectedIndex = -1;
            //
            GADJIT.sqlConnection.Close();
            DGVTicket.Rows.Clear();
            FillDGVTicket();
        }

        private void FillDGVTicket()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select TicID,TicDT,TicRepPri,TicSta from ticket ", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DGVTicket.Rows.Add(dr["TicID"], dr["TicDT"], dr["TicRepPri"], dr["TicSta"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"erreur FillDGVTicket");
            }
            finally
            {
                dr.Close();
                GADJIT.sqlConnection.Close();
            }
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void PictureBoxSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DGVTicket.Rows.Clear();
                SqlCommand cmd = new SqlCommand("Select TicID,TicDT,TicRepPri,TicSta from ticket where TicID=@ID ", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@ID", ComboBoxCodeTicket.Text);
                GADJIT.sqlConnection.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DGVTicket.Rows.Add(dr["TicID"], dr["TicDT"], dr["TicRepPri"], dr["TicSta"]);
                    }
                }
                price = dr["TicRepPri"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur Search");
            }
            finally
            {
                dr.Close();
                GADJIT.sqlConnection.Close();
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
                Ref= TextBoxRef.Text = dr["GadRefDesig"].ToString();
                CatID = Convert.ToInt32(dr["GadCatID"]);
                BrandID = Convert.ToInt32(dr["GadBraID"]);
                dr.Close();
                cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatID=@CatID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CatID", CatID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Cat = TextBoxCat.Text = dr["GadCatDesig"].ToString();
                    dr.Close();
                }
                //
                cmd = new SqlCommand("select GadBraDesig from GadgetBrand where GadBraID=@BraID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@BraID", BrandID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Brand = TextBoxMarque.Text = dr["GadBraDesig"].ToString();
                    dr.Close();
                }
            }
            GADJIT.sqlConnection.Close();
        }

        private void DGVTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                TID = Convert.ToInt32(row.Cells["TicketID"].Value);
                SqlCommand cmd = new SqlCommand("select TicRepPri,TicProb,GadRefID,TicSta from Ticket where TicID=@TID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@TID", TID);
                GADJIT.sqlConnection.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    prob = RichTextBoxProb.Text = dr["TicProb"].ToString();
                    if(dr["TicSta"].ToString()== "en cours de diagnostic")
                    {
                        labelDiag.Visible =TextBoxDiag.Visible=ButtonDiagnostic.Visible =true;
                        TextBoxDiag.Text = "Diagnostic Disponible";
                    }
                    RefID = Convert.ToInt32(dr["GadRefID"]);
                    price = dr["TicRepPri"].ToString();
                    dr.Close();
                    GADJIT.sqlConnection.Close();
                    BringBrandCatRef();
                }
            }
        }
        private void clearTxtBox()
        {
            TextBoxCat.Clear();
            TextBoxDiag.Clear();
            TextBoxMarque.Clear();
            TextBoxRef.Clear();
            RichTextBoxProb.Clear();
            labelDiag.Visible = TextBoxDiag.Visible = ButtonDiagnostic.Visible = false;
        }

        private void DGVTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                TID = Convert.ToInt32(row.Cells["TicketID"].Value);
                SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta,TicRepPri from Ticket where TicID=@TID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@TID", TID);
                GADJIT.sqlConnection.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    prob = RichTextBoxProb.Text = dr["TicProb"].ToString();
                    if (dr["TicSta"].ToString() == "en cours de diagnostic")
                    {
                        labelDiag.Visible = TextBoxDiag.Visible = ButtonDiagnostic.Visible = true;
                        TextBoxDiag.Text = "Diagnostic Disponible";
                    }
                    RefID = Convert.ToInt32(dr["GadRefID"]);
                    price = dr["TicRepPri"].ToString();
                    dr.Close();
                    GADJIT.sqlConnection.Close();
                    BringBrandCatRef();
                }
            }
        }

        private void DGVTicket_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTxtBox();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVTicket.Rows[e.RowIndex];
                TID = Convert.ToInt32(row.Cells["TicketID"].Value);
                SqlCommand cmd = new SqlCommand("select TicProb,GadRefID,TicSta from Ticket where TicID=@TID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@TID", TID);
                GADJIT.sqlConnection.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    prob = RichTextBoxProb.Text = dr["TicProb"].ToString();
                    if (dr["TicSta"].ToString() == "en cours de diagnostic")
                    {
                        labelDiag.Visible = TextBoxDiag.Visible = ButtonDiagnostic.Visible = true;
                        TextBoxDiag.Text = "Diagnostic Disponible";
                    }
                    RefID = Convert.ToInt32(dr["GadRefID"]);
                    price = dr["TicRepPri"].ToString();
                    dr.Close();
                    GADJIT.sqlConnection.Close();
                    BringBrandCatRef();
                }
            }
        }

        private void ButtonDiagnostic_Click(object sender, EventArgs e)
        {
            DiagnosticTicketForClient diag = new DiagnosticTicketForClient();
            diag.ShowDialog();
            ConsultationTicketForClient_Load(sender, e);
        }
    }
}
