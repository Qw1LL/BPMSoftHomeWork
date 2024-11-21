 namespace BPMSoft.Configuration
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using AGConnectAdmin;
    using AGConnectAdmin.Messaging;

    #region Class: HuaweiPushNotificationProvider

    /// <summary>
    /// Huawei push notification provider.
    /// </summary>
    public class HuaweiPushNotificationProvider : IPushNotificationProvider
    {
        #region Class: PushNotificationProviderSettings

        private class PushNotificationProviderSettings
        {
            /// <summary>
            /// ClientId.
            /// </summary>
            [JsonProperty("clientId")]
            public string ClientId { get; set; }

            /// <summary>
            /// ClientSecret.
            /// </summary>
            [JsonProperty("clientSecret")]
            public string ClientSecret { get; set; }
        }

        #endregion

        #region Constructors: Public

        public HuaweiPushNotificationProvider(string settings)
        {
            _settings = JsonConvert.DeserializeObject<PushNotificationProviderSettings>(settings);
        }

        #endregion

        #region Properties: Private

        private readonly PushNotificationProviderSettings _settings;
        
        #endregion

        #region Methods: Private

        private async Task Send(string token, string title, string message, Dictionary<string, string> additionalData)
        {
            if (AGConnectApp.DefaultInstance is null)
            {
                AGConnectApp.Create(new AppOptions
                {
                    ClientId = _settings.ClientId,
                    ClientSecret = _settings.ClientSecret
                });
            }

            await AGConnectMessaging.DefaultInstance.SendAsync(new Message()
            {
                Android = new AndroidConfig()
                {
                    Notification = new AndroidNotification()
                    {
                        ForegroundShow = false,
                        Title = title,
                        Body = message,
                        ClickAction = ClickAction.OpenApp()
                    }
                },
                Token = new List<string>() { token },
                Data = JsonConvert.SerializeObject(additionalData)
            });
        }

        #endregion

        #region Methods: Public

        public void Send(PushNotificationData data)
        {
            Send(data.Token, data.Title, data.Message, data.AdditionalData).GetAwaiter().GetResult();
        }

        #endregion
    }

    #endregion
}
