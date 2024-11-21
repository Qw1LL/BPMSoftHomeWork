 namespace BPMSoft.Configuration.UisWebHookService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.ServiceModel.Activation;
    using BPMSoft.Core;
    using BPMSoft.Web.Common;
    using BPMSoft.Core.Entities; 
	
	/// <summary>
    /// Сервис для использования веб-хуков Uis.
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UisWebHookService: BaseService
    {
        private SystemUserConnection _systemUserConnection;
        private SystemUserConnection SystemUserConnection {
            get {
                return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
            }
        }
        
        /// <summary>
    	/// Метод приема записи звонка
    	/// </summary>
        [OperationContract]
        [WebInvoke(Method = "Post", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json)]
        public string SetRecordLink(string Name)
		{
			//to do...
           return "";
        }
    }
}
