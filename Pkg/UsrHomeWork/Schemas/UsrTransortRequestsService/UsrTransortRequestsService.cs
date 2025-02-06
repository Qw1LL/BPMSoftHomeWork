namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using BPMSoft.Core.Entities;
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
        [WebInvoke(Method = "GET", UriTemplate = "UsrTransportRequest/GetAllRecords", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Guid> GetAllUsrTransportRequests() {
            return this.helper.GetAllUsrTransportRequests();
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsrTransportRequest/GetRecordById", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public Guid GetUsrTransportRequestsById(string usrReqId) {
            return this.helper.GetUsrTransportRequestsById(usrReqId);
        }
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsrTransportRequest/UpdateRecordByIdCore", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public int UpdateUsrTransportRequestsByIdCore(string usrReqId, string name) {
            return this.helper.UpdateUsrTransportRequestsByIdCore(usrReqId, name);
        }
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsrTransportRequest/UpdateRecordByIdEntity", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public Guid UpdateUsrTransportRequestsByIdEntity(string usrReqId, string name) {
            return this.helper.UpdateUsrTransportRequestsByIdEntity(usrReqId, name);
        }
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsrTransportRequest/DeleteRecordById", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        public void DeleteUsrTransportRequestsById(string usrReqId) {
            this.helper.DeleteUsrTransportRequestsById(usrReqId);
        }
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsrTransportRequest/CreateRecord", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        public Guid CreateUsrTransportRequests(UsrTransportRequestData data) {
            return this.helper.CreateUsrTransportRequests(data);
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
}
