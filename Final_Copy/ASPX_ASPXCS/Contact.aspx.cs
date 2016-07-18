using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            string defaultAddress = "loreric@dunwoody.edu";
            string toAddress = "loreric@dunwoody.edu,ricgram@dunwoody.edu";
            //string[] toArray = toAddress.Split(',');
            if (senderEmail.Text.Length == 0 || !checkAddresses(senderEmail.Text))
            {
                emailForm.Visible = false;
                sentEmail.Visible = true;
                sentEmail.Text = "You have issues in your email addresses. Please fix"
                        + " by clicking your browser's back button and updating the "
                        + " information.";
            }
            else
            {
                try {
                    MailAddress messageFrom = new MailAddress(defaultAddress);
                    string messageSubject = subject.Text;
                    string messageBody = message.Text;
                    MailMessage emailMessage = new MailMessage();
                    emailMessage.From = messageFrom;

                    MailAddress address = new MailAddress(toAddress);
                    emailMessage.To.Add(address);

                    emailMessage.Subject = messageSubject;
                    emailMessage.Body = messageBody;

                    SmtpClient mailClient = new SmtpClient();
                    mailClient.UseDefaultCredentials = true;
                    mailClient.Send(emailMessage);

                    emailForm.Visible = false;
                    sentEmail.Visible = true;

                    sentEmail.Text = "<p>Your message was sent successfully. We will reply as soon as possible. </p><hr />"
                            + "<p><b>Customer Email: </b>"
                            + senderEmail.Text
                            + "</p>"
                            +"<p><b>Message Subject: </b>"
                            + emailMessage.Subject
                            + "</p>"
                            + "<p><b>Message</b>: "
                            + emailMessage.Body
                            + "</p>";
                }
                catch (Exception ex)
                {
                    emailForm.Visible = false;
                    sentEmail.Visible = true;
                    sentEmail.Text = Convert.ToString(ex) + "";
                }
            }
        }
    }

    protected Boolean validateAddress(string senderEmail)
    {
        Regex emailPattern = new Regex(@"^([^\n\b\t\r\s][\w\.]{1,30})((\.){0,25})([@]{1})([\w]{1,30})(\.{1})([A-Za-z]{1,25})");
        Match emailMatch = emailPattern.Match(senderEmail);
        if (emailMatch.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    protected Boolean checkAddresses(string address)
    {
        address.TrimEnd(' ');
        if (!validateAddress(address))
        {
            return false;
        }
        return true;
    }
}
