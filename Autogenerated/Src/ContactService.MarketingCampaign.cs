namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;

	#region Class: ContactService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ContactService : BaseService
	{
		#region Properties: Public

		private ContactServiceHelper _contactServiceHelper;

		/// <summary>
		/// Instance of ContactServiceHelper.
		/// </summary>
		public ContactServiceHelper ContactServiceHelper {
			get => _contactServiceHelper ?? (_contactServiceHelper = new ContactServiceHelper(UserConnection));
			set => _contactServiceHelper = value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Removes flag NonActual from Contact and Contact Communication.
		/// </summary>
		/// <param name="filters">Filters to select Contact.</param>
		/// <param name="entitySchemaUId">Schema unique identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetActualEmails", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetActualEmails(string filters, string entitySchemaUId) {
			ContactServiceHelper.UpdateContactAsyncCore(filters, entitySchemaUId);
		}		

		#endregion

	}

	#endregion
}

