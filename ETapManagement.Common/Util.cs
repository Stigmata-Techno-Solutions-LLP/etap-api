using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using Serilog;
using Standard.Licensing;
using Standard.Licensing.Validation;
using System.IO;
using System.Text;

namespace ETapManagement.Common {

    public static class Util {

        public static void LogError (Exception ex) {
            Log.Logger.Error (ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.Message) + "\n" + ex.StackTrace);
        }

        public static void LogInfo (string messages) {
            Log.Logger.Information (messages);
        }

        public static bool SendMail (string subject, string bodyHtml, string toEmail, string fromMail, string pwd, string server, int port, string userName) {
            bool isEMailSent = false;
            try {
                var email = new MimeMessage ();
                email.Sender = MailboxAddress.Parse (fromMail);
                email.To.Add (MailboxAddress.Parse (toEmail));
                email.Subject = subject;
                email.Body = new TextPart (TextFormat.Html) { Text = bodyHtml };

                // send email
                using var smtp = new SmtpClient ();
                smtp.Connect (server, Convert.ToInt32 (port), SecureSocketOptions.StartTls);
                smtp.Authenticate (userName, pwd);
                smtp.Send (email);
                smtp.Disconnect (true);

                isEMailSent = true;
                return isEMailSent;
            } catch (Exception ex) {
                Log.Logger.Error (ex.Message);
                Log.Logger.Information (ex.Message);
                return false;
            }
        }

        public static bool SendMail_SendGrid (string subject, string bodyHtml, string toEmail, string fromMail, string pwd, string server, int port, string userName) {
            bool isEMailSent = false;
            try {
                var client = new SendGridClient (pwd);
                var msg = new SendGridMessage () {
                    From = new EmailAddress (fromMail, "L&T ETapManagement"),
                    Subject = subject,
                    HtmlContent = bodyHtml
                };

                msg.AddTo (new EmailAddress (toEmail));

                Task response = client.SendEmailAsync(msg);

                isEMailSent = true;
                return isEMailSent;
            } catch (Exception ex) {
                Log.Logger.Error (ex.Message);
                return false;
            }
        }


        public static string[] GenerateLicense (){
try{

  var keyGenerator = Standard.Licensing.Security.Cryptography.KeyGenerator.Create(); 
var keyPair = keyGenerator.GenerateKeyPair(); 
var privateKey = keyPair.ToEncryptedPrivateKeyString("test");  
var publicKey = keyPair.ToPublicKeyString();

var license = License.New()  
    .WithUniqueIdentifier(Guid.NewGuid())  
    .As(LicenseType.Trial)
      
    .ExpiresAt(DateTime.Now.AddDays(30))  
    .WithMaximumUtilization(5)  
    .WithProductFeatures(new Dictionary<string, string>  
        {  
            {"Sales Module", "yes"},  
            {"Purchase Module", "yes"},  
            {"Maximum Transactions", "10000"}  
        })  
    .LicensedTo("John Doe", "john.doe@example.com")  
    .CreateAndSignWithPrivateKey(privateKey, "test");
File.WriteAllText("/Users/admin/Documents/personal/etap-api/License.lic", license.ToString(), Encoding.UTF8);
string[] resultArr = {license.ToString(),publicKey};
    return resultArr;
} catch(Exception ex){
throw ex;
}
}


public static void checkLicenseKeyValidation(string publicKey,string licenseXml) {
try {
    var license = License.Load(licenseXml);
    var validationFailures = license.Validate()  
                                .ExpirationDate()  
                                .When(lic => lic.Type == LicenseType.Trial )
                            
                                .AssertValidLicense();

} catch(Exception ex) {
throw ex;
}
}
      
        public static string Base64Decode (string base64EncodedData) {
            try {

                var base64EncodedBytes = System.Convert.FromBase64String (base64EncodedData);
                return System.Text.Encoding.UTF8.GetString (base64EncodedBytes);
            } catch (Exception ex) {
                throw new ValueNotFoundException ("password is incorrect");
            }
        }
    
        

        public static string CreateRandomPassword (int length = 10) {
            try {
                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
                Random random = new Random ();
                char[] chars = new char[length];
                for (int i = 0; i < length; i++) {
                    chars[i] = validChars[random.Next (0, validChars.Length)];
                }
                return new string (chars);
            } catch (Exception ex) {
                return "";
            }
        }
    }
}