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
using System.Text.RegularExpressions;

namespace GADJIT_WIN_CLIENT
{
    public partial class CreationTicket : Form
    {
        public CreationTicket()
        {
            InitializeComponent();
        }

        string emailtemp = "";
        string CID = "";
        string ID = "T";
        string CatID = "";
        string BrandID = "";
        string RefID = "";

        private void CreationTicket_Load(object sender, EventArgs e)
        {
            emailtemp = Login.Cemail;
            //
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select CliID from Client where CliEmail = '" + emailtemp + "'", GADJIT.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            CID = dr["CliID"].ToString();
            dr.Close();//check this
            //
            cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatSta = 1 ", GADJIT.sqlConnection);
            dr =  cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxCatGadjit.Items.Add(dr["GadCatDesig"].ToString());
            }              
            dr.Close();
            ComboBoxCatGadjit.SelectedIndex = 0;
            //
            cmd = new SqlCommand("select max(TicID) from Ticket ", GADJIT.sqlConnection);
            dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                ID += (Convert.ToInt32(Regex.Match(dr.GetString(0), @"[0-9]").ToString()) + 1).ToString();
            }
            catch
            {
                ID = "T0";
            }       
            GADJIT.sqlConnection.Close();
            dr.Close();

        }

        private void ButtonConfirmer_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Ticket values(@ID,@date,@prob,'en attente de validation',@CID,null,null,@ref,null)", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@prob", RichTextBoxProbTicket.Text);
            cmd.Parameters.AddWithValue("@CID", CID);
            cmd.Parameters.AddWithValue("@Ref", RefID);
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Nouvelle Ticket Créer. Voici votre code de ticket :[ " + ID + " ]. \n\n -Pour consulter votre ticket veuillez rejoindre le panel consultez votre ticket. ", "Nouvelle Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ComboBoxCatGadjit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxCatGadjit.SelectedIndex > 0)
            {
                GADJIT.sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select GadBraDesig from GadgetBrand where GadBraSta = 1", GADJIT.sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ComboBoxMarque.Items.Add(dr["GadBraDesig"].ToString());
                }
                dr.Close();
                //
                cmd = new SqlCommand("select GadCatID from GadgetCategory where GadCatDesig = @CatDes", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("CatDes", ComboBoxCatGadjit.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                CatID = dr["GadCatID"].ToString();
                dr.Close();
                ComboBoxMarque.SelectedIndex = 0;
                GADJIT.sqlConnection.Close();
            }

        }

        private void ComboBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxCatGadjit.SelectedIndex!=0 && ComboBoxMarque.SelectedIndex != 0)
            {
                GADJIT.sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select GadBraID from GadgetBrand where GadBraDesig=@bradDes", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@bradDes", ComboBoxMarque.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                BrandID = dr["GadBraID"].ToString();
                dr.Close();
                //
                cmd = new SqlCommand("select GadRefDesig from GadgetReference where GadCatID = @CatID and GadBraID = @BrandID and GadRefSta=1", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CatID", CatID);
                cmd.Parameters.AddWithValue("@BrandID", BrandID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ComboBoxRefGadjit.Items.Add(dr["GadRefDesig"].ToString());
                }
                dr.Close();
                ComboBoxRefGadjit.SelectedIndex = 0;
                GADJIT.sqlConnection.Close();
            }
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ComboBoxRefGadjit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRefGadjit.SelectedIndex != 0)
            {
                GADJIT.sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select GadRefID from GadgetReference where GadRefDesig=@RefDes", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@RefDes", ComboBoxRefGadjit.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                RefID = dr["GadRefID"].ToString();
                dr.Close();
                GADJIT.sqlConnection.Close();
            }   
        }
    }
}
