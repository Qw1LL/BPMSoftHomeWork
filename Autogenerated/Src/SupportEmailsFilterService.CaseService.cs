namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Web.Common;

	#region Class: SupportEmailsFilterServiceResponse

	[DataContract]
	public class SupportEmailsFilterServiceResponse : ConfigurationServiceResponse
	{
		/// <summary>
		/// result emails.
		/// </summary>
		[DataMember(Name = "resultEmails")]
		public string resultEmails
		{
			get;
			set;
		}
	}

	#endregion

	#region Class: SupportEmailsFilterService

	/// <summary>
	/// Filter emails uses <see cref="IncindentRegistrationMailboxFilter"/>.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SupportEmailsFilterService : BaseService
	{

		#region Methods: Public

		/// <summary>
		/// Gets processed template text.
		/// </summary>
		/// <param name="emails">emails.</param>
		/// <returns>Processed emails.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SupportEmailsFilterServiceResponse GetEmailsWithoutSupport(string emails) {
			var response = new SupportEmailsFilterServiceResponse();
			var incindentRegistrationMailboxFilter = new IncindentRegistrationMailboxFilter(UserConnection);
			try {
				response.resultEmails = incindentRegistrationMailboxFilter.GetRecipientWithoutIncindent(emails);
				response.Success = true;
			} catch (Exception e) {
				response.Exception = e;
				response.Success = false;
			}
			return response;
		}

		#endregion
	}

	#endregion

}
