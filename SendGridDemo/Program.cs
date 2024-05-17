using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var response = await SendEmail();
            if (response.IsSuccessStatusCode)
                await Console.Out.WriteLineAsync("Send sucessfully");

            Console.ReadKey();
        }

        static async Task<Response> SendEmail()
        {
            var apiKey = "api key";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@test.com", "Mohamed Ehab");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@test.com", "Google account");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>Welcome from sendGrid, Hello Iam Mohamed Ehab ElHelaly, Just enjoy.</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var message = MailHelper.CreateSingleEmailToMultipleRecipients(from,
                new List<EmailAddress>
                {
                    new("test@test.com"),
                    new("test@test.com")
                }, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(message);
            return response;
        }
    }
}
