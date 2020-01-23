using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Azure.SasTokenGenerator
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string token = GetSasToken(AppConfiguration.ReadFromJsonFile("appsettings.json"));

                Console.WriteLine("SAS Token generated successfuly:");
                Console.WriteLine(token);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        public static string GetSasToken(AppConfiguration config)
        {
            if (!config.IsConfigurationValid()) throw new ArgumentException("appsettings.json file inexistent or malformed");

            var expiry = GetExpiry(TimeSpan.FromMinutes(config.MinutesToExpire));
            string resourceUri = $"https://{config.HostName}/{config.QueueName}/messages";

            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(config.PolicyKey));
            var stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));

            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
            HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, config.PolicyName);
            return sasToken;
        }

        private static string GetExpiry(TimeSpan ttl)
        {
            TimeSpan expirySinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1) + ttl;
            return Convert.ToString((int)expirySinceEpoch.TotalSeconds);
        }
    }
}
