using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using RealEstateClassLibrary;

namespace RetailClassLibrary
{
    internal class Email
    {
        private MailMessage objMail = new MailMessage();
        private MailAddress toAddress;
        private MailAddress fromAddress;
        private String subject;
        private String messageBody;
        private Boolean isHTMLBody = true;
        private MailPriority priority = MailPriority.Normal;
        private String mailHost = "smtp.temple.edu";

        public void SendMail(Offer offer)
        {
            try
            {
                this.Recipient = offer.Client.Email;
                this.Sender = offer.Home.Agent.WorkEmail;
                this.Subject = offer.Status == OfferStatus.accepted? 
                    "Offer Accepted" : "Offer Rejected";
                this.Message = offer.Status == OfferStatus.accepted ?
                    $"Good Evening {offer.Client.FirstName} {offer.Client.LastName}, Your offer of {offer.Amount.ToString("C2")} was accepted for the purchase of {offer.Home.Address.ToString()}. We will be in touch soon! -{offer.Home.Agent.FirstName} {offer.Home.Agent.LastName}" :
                    $"Good Evening {offer.Client.FirstName} {offer.Client.LastName}, Your offer of {offer.Amount.ToString("C2")} was rejected for the purchase of {offer.Home.Address.ToString()}. -{offer.Home.Agent.FirstName} {offer.Home.Agent.LastName}";
                objMail.To.Add(this.toAddress);
                objMail.From = this.fromAddress;
                objMail.Subject = this.subject;
                objMail.Body = this.messageBody;
                objMail.IsBodyHtml = this.isHTMLBody;
                objMail.Priority = this.priority;
                SmtpClient smtpMailClient = new SmtpClient(this.mailHost);
                smtpMailClient.Send(objMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean SendMail()
        {
            try
            {
                objMail.To.Add(this.toAddress);
                objMail.From = this.fromAddress;
                objMail.Subject = this.subject;
                objMail.Body = this.messageBody;
                objMail.IsBodyHtml = this.isHTMLBody;
                objMail.Priority = this.priority;
                SmtpClient smtpMailClient = new SmtpClient(this.mailHost);
                smtpMailClient.Send(objMail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public String Recipient
        {
            get { return this.toAddress.ToString(); }
            set { this.toAddress = new MailAddress(value); }
        }
        public String Sender

        {
            get { return this.fromAddress.ToString(); }
            set { this.fromAddress = new MailAddress(value); }
        }
        public String Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        public String Message
        {
            get { return this.messageBody; }
            set { this.messageBody = value; }
        }
        public Boolean HTMLBody
        {
            get { return this.isHTMLBody; }
            set { this.isHTMLBody = value; }
        }
        public MailPriority Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }
        public String MailHost
        {
            get { return this.mailHost; }
            set { this.mailHost = value; }
        }
    }
}
