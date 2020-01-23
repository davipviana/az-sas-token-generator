using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Azure.SasTokenGenerator
{
    public class AppConfiguration
    {
        #region Properties
        public string HostName { get; set; }
        public string PolicyName { get; set; }
        public string PolicyKey { get; set; }
        public string QueueName { get; set; }
        public int MinutesToExpire { get; set; }
        #endregion

        #region Constructors
        private AppConfiguration() { }
        #endregion

        public static AppConfiguration ReadFromJsonFile(string path)
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile(path);

            Configuration = builder.Build();

            var appConfiguration = new AppConfiguration();
            Configuration.Bind(appConfiguration);

            return appConfiguration;
        }
    }

    public static class AppConfigurationExtensions
    {
        public static bool IsConfigurationValid(this AppConfiguration appConfiguration)
        {
            return (appConfiguration != null
                && !string.IsNullOrEmpty(appConfiguration.HostName)
                && !string.IsNullOrEmpty(appConfiguration.PolicyName)
                && !string.IsNullOrEmpty(appConfiguration.PolicyKey)
                && !string.IsNullOrEmpty(appConfiguration.QueueName)
                && appConfiguration.MinutesToExpire != 0
            );
        }
    }
}
