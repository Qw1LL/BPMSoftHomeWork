namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using BPMSoft.Web.Common;

    #region Class: MessagePublisherService

    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MessagePublisherService : BaseService
    {

        #region Methods: Private

        private void InternalPublishMessage(string className, Dictionary<string, string> fieldsData) {
            if (!string.IsNullOrEmpty(className)) {
                var messagePublisherManager = new MessagePublisherManager(UserConnection);
                messagePublisherManager.Publish(className, fieldsData);
            }
        }

        #endregion

        #region Methods: Public

        [Obsolete("7.11.0 | Use PublishMessage instead.")]
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public void Publish(string className, Dictionary<string, string> fieldsData) {
            InternalPublishMessage(className, fieldsData);
        }

        /// <summary>
        /// Publish message and handle exception.
        /// </summary>
        /// <param name="className">Concrete publisher class name.</param>
        /// <param name="fieldsData">Parameters for message sending.</param>
        /// <returns>Response with publishing status. In case when exteption thrown return exception message.</returns>
        /// <exception cref="Exception">Throws when an error occurred while publishing message.</exception>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public ConfigurationServiceResponse PublishMessage(string className, Dictionary<string, string> fieldsData) {
            ConfigurationServiceResponse response = new ConfigurationServiceResponse();
            try {
                InternalPublishMessage(className, fieldsData);
            } catch (Exception ex) {
                response.Exception = ex;
            }
            return response;
        }

        #endregion

    }

    #endregion

}
