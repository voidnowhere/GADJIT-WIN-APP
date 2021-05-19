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
        string CID = "";
        string ID = "";
        string CatID = "";
        string BrandID = "";

        private void ConsultationTicketForClient_Load(object sender, EventArgs e)
        {
            emailtemp = Login.Cemail;
            //
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select CliID from Client where CliEmail = '" + emailtemp + "'", GADJIT.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            CID = dr["CliID"].ToString();
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
            GADJIT.sqlConnection.Close();
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
