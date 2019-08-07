using Avanade.HackathonAzul.DaniBot.Constants;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.DaniBot.Models
{
	public static class SendEmail
	{
		public static async Task Execute(string userMail, string mailSubject, string mailBody)
		{

			var client = new SendGridClient(ConfigurationConstants.SendGridKey);
			var from = new EmailAddress(ConfigurationConstants.SendGridMail, "Hackathon Azul");
			var subject = mailSubject;
			var to = new EmailAddress(userMail);
			var htmlContent = mailBody;

			var response = await client.SendEmailAsync(MailHelper.CreateSingleEmail(from, to, subject, plainTextContent: string.Empty, htmlContent));
		}
	}
}