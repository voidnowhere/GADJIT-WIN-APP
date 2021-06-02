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
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_CLIENT
{
    public partial class CreationTicket : Form
    {
        public CreationTicket()
        {
            InitializeComponent();
        }
        public int CID;
        int ID;
        int CatID;
        int BrandID;
        int RefID;
        string email = "";
        int cityID;
        SqlDataReader dataReader;
        private void CreationTicket_Load(object sender, EventArgs e)
        {
            FillComboBoxCity();
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select GadCatDesig from GadgetCategory where GadCatSta = 1 ", GADJIT.sqlConnection);
            SqlDataReader dr =  cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxCatGadjit.Items.Add(dr["GadCatDesig"].ToString());
            }              
            dr.Close();
            ComboBoxCatGadjit.SelectedIndex = 0;
            ComboBoxville.SelectedIndex = 0;
            //
            GADJIT.sqlConnection.Close();
            getclientemail();
        }

        private void ButtonConfirmer_Click(object sender, EventArgs e)
        {
            if(RichTextBoxAdress.Text !="" && RichTextBoxProbTicket.Text != "" && ComboBoxCatGadjit.SelectedIndex >0 && ComboBoxMarque.SelectedIndex>0 && ComboBoxRefGadjit.SelectedIndex>0 && ComboBoxville.SelectedIndex>0)
            {
                try
                {
                    getcityid();
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select max(TicID) from Ticket ", GADJIT.sqlConnection);
                    if (cmd.ExecuteScalar() != DBNull.Value)
                    {
                        ID = (int)cmd.ExecuteScalar() + 1;
                    }
                    else
                    {
                        ID = 0;
                    }
                    cmd = new SqlCommand("insert into Ticket(TicID, TicDT, TicProb, TicAddress, CitID, TicSta, CliID, GadRefID) values(@ID, GETDATE(), @prob, @Adres,@city, 'PV', @CID, @ref)", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@prob", RichTextBoxProbTicket.Text);
                    cmd.Parameters.AddWithValue("@CID", CID);
                    cmd.Parameters.AddWithValue("@Ref", RefID);
                    cmd.Parameters.AddWithValue("@Adres", RichTextBoxAdress.Text);
                    cmd.Parameters.AddWithValue("@city", cityID);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("select max(TicID) from TicketMonitoring ", GADJIT.sqlConnection);
                    int TID;
                    if (cmd.ExecuteScalar() != DBNull.Value)
                    {
                        TID = (int)cmd.ExecuteScalar() + 1;
                    }
                    else
                    {
                        TID = 0;
                    }
                    cmd = new SqlCommand("insert into TicketMonitoring values(@id,GETDATE(),'Ticket Cree','C',@CID,1)", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@id", TID);
                    cmd.Parameters.AddWithValue("@CID", CID);
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                    GADJIT.SendEmail(email, "\n\nVotre Ticket a été Crée.\nVoici votre code de ticket:[" + ID + "]. \n\n - Pour consulter votre ticket veuillez rejoindre le panel consultez votre ticket.\n Merci. \n \n");
                    MessageBox.Show("Ticket a été Crée", "Nouvelle Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur in Creation Ticket");
                }
                
            }
            else
            {
                MessageBox.Show("Veuillez remplicer tout les champs","champ vide",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBoxCatGadjit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxCatGadjit.SelectedIndex > 0)
            {
                try
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select GadCatID from GadgetCategory where GadCatDesig = @CatDes", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("CatDes", ComboBoxCatGadjit.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    CatID = Convert.ToInt32(dr["GadCatID"]);
                    dr.Close();
                    //
                    ComboBoxMarque.Items.Clear();
                    cmd = new SqlCommand("SELECT DISTINCT GadBraDesig FROM GadgetReference, GadgetBrand WHERE GadgetReference.GadBraID = GadgetBrand.GadBraID AND(GadCatID = @CatID) AND GadBraSta = 1 ", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ComboBoxMarque.Items.Add(dr["GadBraDesig"].ToString());
                    }
                    dr.Close();
                    ComboBoxMarque.Items.Insert(0, "Choisissez une marque");
                    //
                    ComboBoxMarque.SelectedIndex = 0;
                    ComboBoxRefGadjit.Items.Clear();
                    ComboBoxRefGadjit.SelectedIndex = -1;
                    GADJIT.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cat selectedindex changed");
                }
            }
            else
            {
                ComboBoxMarque.Items.Clear();
                ComboBoxRefGadjit.Items.Clear();
            }                     
        }

        private void ComboBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxRefGadjit.Items.Clear();
            ComboBoxRefGadjit.SelectedIndex = -1;
            if (ComboBoxCatGadjit.SelectedIndex!=0 && ComboBoxMarque.SelectedIndex != 0)
            {
                try
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select GadBraID from GadgetBrand where GadBraDesig=@bradDes", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@bradDes", ComboBoxMarque.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    BrandID = Convert.ToInt32(dr["GadBraID"]);
                    dr.Close();
                    //
                    ComboBoxRefGadjit.Items.Clear();
                    cmd = new SqlCommand("select GadRefDesig from GadgetReference where GadCatID = @CatID and GadBraID = @BrandID and GadRefSta=1", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    cmd.Parameters.AddWithValue("@BrandID", BrandID);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ComboBoxRefGadjit.Items.Add(dr["GadRefDesig"].ToString());
                    }
                    dr.Close();
                    ComboBoxRefGadjit.Items.Insert(0, "choisissez une reference");
                    ComboBoxRefGadjit.SelectedIndex = 0;
                    GADJIT.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur comboBoxBrand changed index");
                }
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
                try
                {
                    GADJIT.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select GadRefID from GadgetReference where GadRefDesig=@RefDes", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@RefDes", ComboBoxRefGadjit.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    RefID = Convert.ToInt32(dr["GadRefID"]);
                    dr.Close();
                    GADJIT.sqlConnection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur getting refID from selected index change in comboRef ");
                }
            }   
        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getclientemail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select CliEmail from Client where CliID=@CID", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@CID", CID);
                GADJIT.sqlConnection.Open();
                email = cmd.ExecuteScalar().ToString();
                GADJIT.sqlConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur getting client email");
            }
        }
        private void getcityid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select CitID from City where CitDesig=@city ", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@city", ComboBoxville.Text);
                GADJIT.sqlConnection.Open();
                cityID = (int)cmd.ExecuteScalar();
                GADJIT.sqlConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur getting city ID");
            }
        }
        private void FillComboBoxCity()
        {
            ComboBoxville.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select CitDesig from City where CitSta=1", GADJIT.sqlConnection);
                GADJIT.sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    ComboBoxville.Items.Add("----Votre Ville---");
                    while (dataReader.Read())
                    {
                        ComboBoxville.Items.Add(dataReader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error FillComboBoxCity()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                GADJIT.sqlConnection.Close();
            }
        }
    }
}
