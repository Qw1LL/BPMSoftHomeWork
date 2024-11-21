namespace BPMSoft.Configuration
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using BPMSoft.Web.Http.Abstractions;
    using Google.Apis.Auth.OAuth2;
    using global::Common.Logging;
    using RestSharp.Extensions;

    #region Class: FirebasePushNotificationProvider

    /// <summary>
    /// Firebase push notification provider.
    /// </summary>
    public class FirebasePushNotificationProvider : IPushNotificationProvider
    {

        #region Class: Request

        /// <summary>
        /// Represents push notification request.
        /// </summary>
        [DataContract]
        private class Request
        {

            #region Properties: Public

            /// <summary>
            /// Message.
            /// </summary>
            [JsonProperty("message")]
            public Message Message
            {
                get;
                set;
            }

            #endregion

        }

        #endregion


        #region Class: Message

        /// <summary>
        /// Represents push notification message data.
        /// </summary>
        [DataContract]
        private class Message
        {

            #region Properties: Public

            /// <summary>
            /// Device token.
            /// </summary>
            [JsonProperty("token")]
            public string Token
            {
                get;
                set;
            }

            /// <summary>
            /// Message.
            /// </summary>
            [JsonProperty("notification")]
            public NotificationData Notification
            {
                get;
                set;
            }

            /// <summary>
            /// Message.
            /// </summary>
            [JsonProperty("data")]
            public Dictionary<string, string> Data
            {
                get;
                set;
            }

            #endregion

        }

        #endregion

        #region Class: NotificationData

        /// <summary>
        /// Represents push notification request data.
        /// </summary>
        [DataContract]
        private class NotificationData
        {

            #region Properties: Public

            /// <summary>
            /// Message.
            /// </summary>
            [JsonProperty("body")]
            public string Message
            {
                get;
                set;
            }

            /// <summary>
            /// Title.
            /// </summary>
            [JsonProperty("title")]
            public string Title
            {
                get;
                set;
            }

            #endregion


        }

        #endregion

        #region Firebase Error Response classes

        [DataContract]
        private class FirebaseErrorResponse
        {
            [JsonProperty("error")]
            public FirebaseError Error { get; set; }
        }

        [DataContract]
        private class FirebaseError
        {
            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("details")]
            public FirebaseErrorDetail[] Details { get; set; }
        }

        [DataContract]
        private class FirebaseErrorDetail
        {
            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }
        }

        #endregion

        #region Constructors: Public

        public FirebasePushNotificationProvider(string settings)
        {
            _settings = JObject.Parse(settings);
        }

        #endregion

        #region Properties: Private

        private static readonly ILog Log = LogManager.GetLogger(typeof(FirebasePushNotificationProvider));

        private readonly JObject _settings;

        private string Url
        {
            get
            {
                return (string)_settings["url"];
            }
        }

        private string Method
        {
            get
            {
                return (string)_settings["method"];
            }
        }

        private string Scope
        {
            get
            {
                return (string)_settings["scope"];
            }
        }

        private JObject ServiceAccountJson
        {
            get
            {
                return (JObject)_settings["serviceAccountJson"];
            }
        }

        private string ProjectId
        {
            get
            {
                return (string)ServiceAccountJson["project_id"];
            }
        }

        private const string ThirdPartyAuthError = "THIRD_PARTY_AUTH_ERROR";

        #endregion

        #region Methods: Private

        private void PostData(string token, string title, string message,
                Dictionary<string, string> additionalData)
        {
            var requestBody = new Request
            {
                Message = new Message
                {
                    Token = token,
                    Notification = new NotificationData
                    {
                        Message = message,
                        Title = title
                    },
                    Data = additionalData
                }
            };
            string postData = JsonConvert.SerializeObject(requestBody);
            string relativeUri = ProjectId + "/" + Method;
            var uriAddress = new Uri(new Uri(Url), relativeUri); // sample: https://fcm.googleapis.com/v1/projects/bpmsoft-d469c/messages:send
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var accessToken = GetAccessToken();
                webClient.Headers.Add("Authorization", "Bearer " + accessToken);
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                try
                {
                    string response = webClient.UploadString(uriAddress, "POST", postData);
                }
                catch (WebException webException)
                {
                    var bytes = webException.Response.GetResponseStream().ReadAsBytes();
                    var responseBody = Encoding.UTF8.GetString(bytes);
                    Log.Error(responseBody);
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<FirebaseErrorResponse>(responseBody);
                        if (errorResponse.Error.Details?.Any(detail => detail.ErrorCode == ThirdPartyAuthError) ?? false)
                        {
                            // suppresses problems with iphone notification servers auth
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                    throw new HttpException((int)HttpStatusCode.InternalServerError, $"{responseBody}\n{webException.Message}");
                }
                catch (Exception e)
                {
                    throw new HttpException((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }
        }

        private string GetAccessToken()
        {
            return GoogleCredential
                .FromJson(ServiceAccountJson.ToString())
                .CreateScoped(Scope)
                .UnderlyingCredential
                .GetAccessTokenForRequestAsync()
                .GetAwaiter()
                .GetResult();
        }

        #endregion

        #region Methods: Public

        public void Send(PushNotificationData data)
        {
            PostData(data.Token, data.Title, data.Message, data.AdditionalData);
        }

        #endregion

    }

    #endregion

}
