using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newsapp
{
    public partial class Share : Form
    {
        public Share(string link)
        {
            InitializeComponent();
            fpl_Emoji.Visible = false;
            txtContent.Text = link + "\n";
        }
        bool a = false;
        private void btn_emoji_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                fpl_Emoji.Visible = true;
                a = true;
            }
            else
            {
                fpl_Emoji.Visible = false;
                a = false;
            }
        }

        string from;
        string pass;
        string content;
        string subject;

        private void btn_send_Click(object sender, EventArgs e)
        {
            from = txtSender.Text.Trim();
            pass = txtPass.Text.Trim();
            content = txtContent.Text;
            subject = txtSubject.Text.Trim();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = subject;
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


        private void ptb_Kiss_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Kissing_Heart;
        }

        private void ptb_ClosedEye_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Stuck_Out_Tongue_Closed_Eyes;
        }

        private void ptb_Joy_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Joy;
        }

        private void ptb_Sweat_Smile_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Sweat_Smile;
        }

        private void ptb_smile_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Smile;
        }

        private void ptb_HeartEyes_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Heart_Eyes;
        }

        private void ptb_Cry_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Cry;
        }

        private void ptb_Unamused_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Unamused;
        }

        private void ptb_Angry_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Angry;
        }

        private void ptb_dissappointed_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Disappointed;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptb_Triumph_Click(object sender, EventArgs e)
        {
            txtContent.Text = txtContent.Text.Trim() + Emoji.Triumph;
        }
    }
}
