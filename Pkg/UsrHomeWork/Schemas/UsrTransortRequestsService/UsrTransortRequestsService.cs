namespace BPMSoft.Configuration
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using BPMSoft.Core.Factories;
    using BPMSoft.Web.Common;

    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UsrTransortRequestsService: BaseService
    {
        private readonly UsrTransortRequestsHelper helper;

        public UsrTransortRequestsService() : base () {
            helper = ClassFactory.Get<UsrTransortRequestsHelper>(new ConstructorArgument("UserConnection", this.UserConnection));
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, // POST из-за сервис хелпера на фронте
            ResponseFormat = WebMessageFormat.Json)]
        public int GetActivityCount(string driverId) {
            Guid.TryParse(driverId, out Guid id);
            return this.helper.getActivityCount(id);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public int DeleteActivities(string usrReqId) {
            Guid.TryParse(usrReqId, out Guid id);
            return this.helper.deleteActivities(id);
        }

    }

    [DataContract]
    public class CustomDto
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "data")]
        public string Data;

        [DataMember(Name = "typeId")]
        public Guid TypeId;

		
        [DataMember(Name = "size")]
        public int Size;

		
        [DataMember(Name = "version")]
        public int Version;
    }
}
