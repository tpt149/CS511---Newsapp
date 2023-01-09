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

namespace Newsapp
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string from, pass, content;
            from = txtSender.Text.Trim();
            pass = txtPass.Text.Trim();
            content = txtContent.Text;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = "Newsapp C#";
            message.To.Add(new MailAddress("newsapp1201@gmail.com"));
            message.Body = "<html><body>" + content + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, pass),
                EnableSsl = true,
            };
            try
            {
                smtpClient.Send(message);
                MessageBox.Show("Mail sent successfully.", "Email.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
