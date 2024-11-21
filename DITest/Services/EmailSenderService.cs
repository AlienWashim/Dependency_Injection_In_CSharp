using DITest.Services;

public class EmailSenderService : IEmailSenderService
{
    public bool SendEmail(string to, string subject, string body)
    {
        try
        {
            // Here you would use your SMTP service or any email sending service to send the email.
            // For now, we will simulate the email sending by returning true
            Console.WriteLine($"Sending email to {to} with subject {subject} and body {body}");

            // If the email was sent successfully
            return true;
        }
        catch (Exception)
        {
            // If something went wrong
            return false;
        }
    }
}
