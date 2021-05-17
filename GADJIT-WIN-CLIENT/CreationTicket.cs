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
        string ID = "";

        private void CreationTicket_Load(object sender, EventArgs e)
        {
            emailtemp = Login.Cemail;
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select GadCatDesig from GadgetCategory ", GADJIT.sqlConnection);
            SqlDataReader dr =  cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxCatGadjit.Items.Add(dr["GadCatDesig"].ToString());
            }              
            dr.Close();
            cmd = new SqlCommand("select GadBraDesig from GadgetBrand", GADJIT.sqlConnection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxMarque.Items.Add(dr["GadBraDesig"].ToString());
            }
            dr.Close();
            cmd = new SqlCommand("select GadRefDesig from GadgetReference", GADJIT.sqlConnection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxRefGadjit.Items.Add(dr["GadRefDesig"].ToString());
            }
            dr.Close();
            ComboBoxCatGadjit.SelectedIndex = 0;
            ComboBoxMarque.SelectedIndex = 0;
            ComboBoxRefGadjit.SelectedIndex = 0;
            cmd = new SqlCommand("select max(TicID) from Ticket ", GADJIT.sqlConnection);
            dr = cmd.ExecuteReader();
            dr.Read();
            ID += (Convert.ToInt32(Regex.Match(dr.GetString(0), @"[0-9]").ToString()) + 1).ToString();
            GADJIT.sqlConnection.Close();
            dr.Close();
        }

        private void ButtonConfirmer_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Ticket values(@ID,@date,@prob,'en attente de validation',@CID,null,null,@ref,null)", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss"));
            cmd.Parameters.AddWithValue("@prob", RichTextBoxProbTicket.Text);
            cmd.Parameters.AddWithValue("@CID", CID);
            cmd.Parameters.AddWithValue("@Ref", ComboBoxRefGadjit.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("ajout reussi");
            
        }
    }
}
