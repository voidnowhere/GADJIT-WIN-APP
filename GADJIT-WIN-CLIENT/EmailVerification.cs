using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_CLIENT
{
    public partial class EmailVerification : Form
    {
        public EmailVerification()
        {
            InitializeComponent();
        }
        string check = "";
        private void EmailVerification_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int num = random.Next(6, 8);
            int total = 0;
            do
            {
                int chr = random.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    check = check + (char)chr;
                    total++;
                    if (total == num)
                        break;
                    {

                    }
                }
            } while (true);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
            MailMessage msg = new MailMessage();
            msg.To.Add(Register.emailC);
            msg.From = new MailAddress("GADJITMA@gmail.com");
            msg.Subject = "Inscription chez GADJIT";
            msg.Body = "Bonjour " + Register.NomC + ":\nVotre CODE de verification est : "+check+" \nGADJIT MAROC.";
            client.Send(msg);
            MessageBox.Show("un mail de verification d'inscription a été envoyer a votre boite mail", "mail envoyez");
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if(check == textBox1.Text)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("code incorrect nouveau code a ete envoyer");
                EmailVerification_Load(sender,e);
            }
        }
    }
}
