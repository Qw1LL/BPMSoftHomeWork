namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Configuration.EmailMining;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: EnrichContactService

	/// <summary>
	/// Contact enrichment actions service class.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EnrichContactService : BaseService, IReadOnlySessionState
	{
		#region Properties: Protected

		/// <summary>
		/// <see cref="EnrichContactHelper"/> instance.
		/// </summary>
		private EnrichContactHelper _helper;
		protected virtual EnrichContactHelper Helper {
			get {
				if (_helper == null) {
					var userConnection = new ConstructorArgument("userConnection", UserConnection);
					_helper = ClassFactory.Get<EnrichContactHelper>(userConnection);
				}
				return _helper;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns contacts enrichment information for email.
		/// </summary>
		/// <param name="activityId"><see cref="Activity"/> instance unique identifier.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "CloudStateResponse")]
		public CloudDataResponse GetCloudStateForEmail(Guid activityId) {
			return Helper.GetCloudActions(activityId, "Activity");
		}

		/// <summary>
		/// Returns contact enrichment information.
		/// </summary>
		/// <param name="contactId"><see cref="Contact"/> instance unique identifier.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "CloudStateResponse")]
		public CloudDataResponse GetCloudStateForContact(Guid contactId) {
			return Helper.GetCloudActions(contactId, "Contact");
		}

		/// <summary>
		/// Returns text data enrichment information by <paramref name="contactId"/>.
		/// </summary>
		/// <param name="contactId"><see cref="Contact"/> instance unique identifier.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "CloudTextDataResponse")]
		public EnrichTextDataResponse GetTextDataForExistContact(Guid contactId) {
			return Helper.GetEnrchTextData(contactId, "Contact");
		}

		/// <summary>
		/// Returns text data enrichment information by <paramref name="textDataId"/>.
		/// </summary>
		/// <param name="textDataId"><see cref="EnrchTextEntity"/> instance unique identifier.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "CloudTextDataResponse")]
		public EnrichTextDataResponse GetTextDataForNewContact(Guid textDataId) {
			return Helper.GetEnrchTextData(textDataId, "EnrchTextEntity");
		}

		/// <summary>
		/// Saves all enriched items from <paramref name="rawData"/>.
		/// </summary>
		/// <param name="rawData"><see cref="EnrichSaveEntityData"/> collection.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SaveEnrichedData(List<EnrichSaveEntityData> rawData) {
			Helper.SaveEnrichedData(rawData);
		}

		/// <summary>
		/// Manually runs email mining process.
		/// </summary>
		/// <returns>The count of the processed emails or <c>-1</c> if feature is not enabled.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "processedEmailCount")]
		public int RunEmailMining() {
			EmailMiningJob miningJob = ClassFactory.Get<EmailMiningJob>();
			return miningJob.RunMiner(UserConnection);
		}


		/// <summary>
		/// Searches for the country by its code.
		/// </summary>
		/// <returns>The identifier and the name of the country or <c>null</c> if nothing was found.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "resultEntity")]
		public Tuple<Guid, string> SearchForCountry(string countryCode) {
			//TODO Remove temporary service method
			var locationHelper = new LocationHelper(UserConnection);
			var country = locationHelper.SearchForCountry(countryCode);
			if (country == null) {
				return null;
			}
			return new Tuple<Guid, string>(
				country.GetTypedColumnValue<Guid>("Id"), country.GetTypedColumnValue<string>("Name"));
		}

		/// <summary>
		/// Searches for the city by its variants of name.
		/// </summary>
		/// <returns>The identifier and the name of the city or <c>null</c> if nothing was found.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "resultEntity")]
		public Tuple<Guid, string> SearchForCity(List<string> cityNames) {
			//TODO Remove temporary service method
			var locationHelper = new LocationHelper(UserConnection);
			var city = locationHelper.SearchForCity(cityNames);
			if (city == null) {
				return null;
			}
			return new Tuple<Guid, string>(
				city.GetTypedColumnValue<Guid>("Id"), city.GetTypedColumnValue<string>("Name"));
		}

		#endregion

	}

	#endregion

}

