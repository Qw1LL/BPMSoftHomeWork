namespace BPMSoft.Configuration.EmailSendService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Mail.Sender;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EmailSendService : BaseService
	{

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Send", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<SendResult> Send(string ActivityId) {
			string SendEmailStatus = "InProgress";
			bool hasFollowingProcessElement = false;
			try {
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
				var activityEmailSender = new ActivityEmailSender(emailClientFactory, UserConnection);
				Activity activity = activityEmailSender.Send(Guid.Parse(ActivityId));
				hasFollowingProcessElement = (bool)activity.Process.GetPropertyValue("NextProcessElementReady");
				SendEmailStatus = "Sended";
			} catch (EmailException e) {
				SendEmailStatus = e.EmailSendStatus;
			}
			var sendStatusESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmailSendStatus");
			sendStatusESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			sendStatusESQ.AddColumn("Name");
			sendStatusESQ.AddColumn("Code");
			sendStatusESQ.Filters.Add(sendStatusESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal, 
					"Code", 
					SendEmailStatus
				));
			var sendStatusEntityCollection = sendStatusESQ.GetEntityCollection(UserConnection);
			var sendResultList = new List<SendResult>();
			if (sendStatusEntityCollection.Count > 0) {
				var item = sendStatusEntityCollection[0];
				sendResultList.Add(new SendResult() {
					DisplayValue = item.PrimaryDisplayColumnValue,
					Value = item.PrimaryColumnValue.ToString(),
					Code = item.GetTypedColumnValue<string>("Code"),
					HasFollowingProcessElement = hasFollowingProcessElement
				});
			} 
			return sendResultList;
		}
		
	}
	public class SendResult
	{
		public string DisplayValue {
			get;
			set;
		}
		public string Value {
			get;
			set;
		}
		public string Code {
			get;
			set;
		}
		public bool HasFollowingProcessElement {
			get;
			set;
		}
	}
}
