namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.GeneratedWebFormService;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using HttpUtility = System.Web.HttpUtility;

	#region Interface: ITouchSource

	/// <summary>
	/// Describes instance that can define source and channel by ref and utm params.
	/// </summary>
	public interface ITouchSource
	{

		#region Properties: Public

		/// <summary>
		/// Collection of href parameters to analyze.
		/// </summary>
		NameValueCollection BpmHrefParameters { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines channel and source by parameters specified.
		/// </summary>
		/// <param name="parameters"><see cref="Dictionary{string, string}"/> of parameters available.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		(Guid Medium, Guid Source) ComputeMediumAndSource(Dictionary<string, string> parameters);

		/// <summary>
		/// Defines channel and source by form data specified.
		/// </summary>
		/// <param name="formData">Form data instance.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		(Guid Medium, Guid Source) ComputeMediumAndSource(FormData formData);

		#endregion

	}

	#endregion

	#region Class: LeadSourceHelper

	/// <summary>
	/// Helps to define source and channel.
	/// </summary>
	[DefaultBinding(typeof(ITouchSource))]
	public class LeadSourceHelper : ITouchSource
	{

		#region Constructors: Public

		/// <summary>
		/// ############## ##### ######### ###### <see cref="LeadSourceHelper"/>.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="bpmHref">URL ########.</param>
		/// <param name="bpmRef">URL #########.</param>
		public LeadSourceHelper(UserConnection userConnection, string bpmHref, string bpmRef) {
			UserConnection = userConnection;
			this.bpmHref = bpmHref;
			this.bpmRef = bpmRef;
			InitBpmHrefParameters();
		}

		/// <summary>
		/// ############## ##### ######### ###### <see cref="LeadSourceHelper"/>.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public LeadSourceHelper(UserConnection userConnection) {
			UserConnection = userConnection;
			InitBpmHrefParameters();
		}

		#endregion

		#region Properties: Private

		private string bpmHref;

		private string bpmRef;

		private EntityCollection _leadMedium = null;

		private EntityCollection LeadMedium {
			get {
				if (_leadMedium != null) {
					return _leadMedium;
				}
				_leadMedium = GetEntityCollection("LeadMedium");
				return _leadMedium;
			}
		}

		private EntityCollection _leadMediumCode = null;

		private EntityCollection LeadMediumCode {
			get {
				if (_leadMediumCode != null) {
					return _leadMediumCode;
				}
				_leadMediumCode = GetEntityCollection("LeadMediumCode");
				return _leadMediumCode;
			}
		}

		private EntityCollection _leadSource = null;

		private EntityCollection LeadSource {
			get {
				if (_leadSource != null) {
					return _leadSource;
				}
				_leadSource = GetEntityCollection("LeadSource");
				return _leadSource;
			}
		}

		private EntityCollection _leadSourceCode = null;

		private EntityCollection LeadSourceCode {
			get {
				if (_leadSourceCode != null) {
					return _leadSourceCode;
				}
				_leadSourceCode = GetEntityCollection("LeadSourceCode");
				return _leadSourceCode;
			}
		}

		private EntityCollection _leadSourceUrl = null;

		private EntityCollection LeadSourceUrl {
			get {
				if (_leadSourceUrl != null) {
					return _leadSourceUrl;
				}
				_leadSourceUrl = GetEntityCollection("LeadSourceUrl");
				return _leadSourceUrl;
			}
		}

		private NameValueCollection bpmHrefParameters = null;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Referrer url parameters.
		/// </summary>
		public NameValueCollection BpmHrefParameters {
			get => bpmHrefParameters;
			private set => bpmHrefParameters = value;
		}

		/// <summary>
		/// Channel unique identifier.
		/// </summary>
		public Guid ResultLeadMediumId { get; private set; }

		/// <summary>
		/// Source unique identifier.
		/// </summary>
		public Guid ResultLeadSourceId { get; private set; }

		#endregion

		#region Methods: Private

		private void InitBpmHrefParameters() {
			Uri uri;
			if (Uri.TryCreate(this.bpmHref, UriKind.Absolute, out uri)) {
				bpmHrefParameters = HttpUtility.ParseQueryString(uri.Query);
			} else {
				bpmHrefParameters = HttpUtility.ParseQueryString(string.Empty);
			}
		}

		private EntityCollection GetEntityCollection(string entityname) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entityname);
			esq.AddAllSchemaColumns();
			return esq.GetEntityCollection(UserConnection);
		}

		private void GetMediumSourceByUtm() {
			string utmMediumValue = bpmHrefParameters["utm_medium"];
			string utmSourceValue = bpmHrefParameters["utm_source"];
			string utmCampaignValue = bpmHrefParameters["utm_campaign"];
			GetMediumSourceByUtm(utmMediumValue, utmSourceValue, utmCampaignValue);
		}

		private void GetMediumSourceByUtm(string utmMedium, string utmSource, string utmCampaign) {
			Guid leadMediumId = Guid.Empty;
			Guid leadSourceId = Guid.Empty;
			if (!string.IsNullOrWhiteSpace(utmMedium)) {
				var leadMediumEntity = LeadMediumCode.Find("Code", utmMedium);
				if (leadMediumEntity != null) {
					leadMediumId = leadMediumEntity.GetTypedColumnValue<Guid>("LeadMediumId");
				}
			}
			if (!string.IsNullOrWhiteSpace(utmSource) || !string.IsNullOrWhiteSpace(utmCampaign)) {
				var searchValue = !string.IsNullOrWhiteSpace(utmSource) ? utmSource : utmCampaign;
				var LeadSourceCodeEntity = LeadSourceCode.Find("Code", searchValue);
				if (LeadSourceCodeEntity != null) {
					leadSourceId = LeadSourceCodeEntity.GetTypedColumnValue<Guid>("LeadSourceId");
					if (leadMediumId == Guid.Empty) {
						var leadSourceEntity = LeadSource.Find("Id", leadSourceId);
						if (leadSourceEntity != null) {
							leadMediumId = leadSourceEntity.GetTypedColumnValue<Guid>("LeadMediumId");
						}
					}
				}
			}
			ResultLeadMediumId = leadMediumId;
			ResultLeadSourceId = leadSourceId;
		}

		private void GetMediumSourceBySearchAd() {
			string gclid = bpmHrefParameters["gclid"];
			if (!string.IsNullOrEmpty(gclid)) {
				ResultLeadMediumId = LeadMediumConsts.LeadMediumSearchAdId;
				ResultLeadSourceId = LeadSourceConsts.LeadSourceGoogleAdWordsId;
			}
			string yclid = bpmHrefParameters["yclid"];
			if (!string.IsNullOrEmpty(yclid)) {
				ResultLeadMediumId = LeadMediumConsts.LeadMediumSearchAdId;
				ResultLeadSourceId = LeadSourceConsts.LeadSourcekYandexDirectId;
			}
		}

		private void GetMediumSourceByRef(string referrerUrl) {
			if (string.IsNullOrWhiteSpace(referrerUrl)) {
				return;
			}
			Entity leadSourceUrlEntity = null;
			Entity subDomainLeadSourceUrlEntity = null;
			Uri.TryCreate(referrerUrl, UriKind.Absolute, out var uri);
			if (uri != null) {
				referrerUrl = uri.Host;
			}
			foreach (Entity item in LeadSourceUrl) {
				string urlLookupValue = item.GetTypedColumnValue<string>("URL");
				string dotUrlLookupValue = string.Format(".{0}", urlLookupValue);
				if (referrerUrl.Equals(urlLookupValue, StringComparison.OrdinalIgnoreCase)) {
					leadSourceUrlEntity = item;
				}
				if (referrerUrl.EndsWith(dotUrlLookupValue, StringComparison.OrdinalIgnoreCase)) {
					subDomainLeadSourceUrlEntity = item;
				}
			}
			leadSourceUrlEntity = leadSourceUrlEntity ?? subDomainLeadSourceUrlEntity;
			if (leadSourceUrlEntity == null) {
				if (ResultLeadMediumId == Guid.Empty) {
					ResultLeadMediumId = LeadMediumConsts.LeadMediumReferrerTrafficId;
				}
				ResultLeadSourceId = LeadSourceConsts.LeadSourceOtherId;
				return;
			}
			ResultLeadSourceId = leadSourceUrlEntity.GetTypedColumnValue<Guid>("LeadSourceId");
			var leadSourceEntity = LeadSource.Find("Id", leadSourceUrlEntity.GetTypedColumnValue<Guid>("LeadSourceId"));
			if (leadSourceEntity != null) {
				ResultLeadSourceId = leadSourceEntity.GetTypedColumnValue<Guid>("Id");
				if (ResultLeadMediumId == Guid.Empty) {
					ResultLeadMediumId = leadSourceEntity.GetTypedColumnValue<Guid>("LeadMediumId");
				}
			}
		}

		private void GetMediumSourceByRef() {
			GetMediumSourceByRef(bpmRef);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns collection of parameters by form data specified.
		/// </summary>
		/// <param name="formData">The form data.</param>
		/// <returns><see cref="Dictionary{string, string}"/> of parameters.</returns>
		protected virtual Dictionary<string, string> GetParamsByFormData(FormData formData) {
			formData.CheckArgumentNull("formData");
			var bpmHref = formData.formFieldsData?.SingleOrDefault(x => x.name == "BpmHref")?.value ?? "";
			var bpmRef = formData.formFieldsData?.SingleOrDefault(x => x.name == "BpmRef")?.value ?? "";
			return new Dictionary<string, string> {
				{ "bpmRef", bpmRef },
				{ "bpmHref", bpmHref }
			};
		}

		/// <summary>
		/// Resets helper search state and clears result values to empty.
		/// </summary>
		protected void ClearResults() {
			ResultLeadMediumId = Guid.Empty;
			ResultLeadSourceId = Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines channel and source.
		/// </summary>
		public void ComputeMediumAndSource() {
			ClearResults();
			if (string.IsNullOrEmpty(bpmHref) && string.IsNullOrEmpty(bpmRef)) {
				return;
			}
			GetMediumSourceByUtm();
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId != Guid.Empty) {
				return;
			}
			GetMediumSourceBySearchAd();
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId != Guid.Empty) {
				return;
			}
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId == Guid.Empty) {
				ResultLeadSourceId = LeadSourceConsts.LeadSourceOtherId;
				return;
			}
			if (ResultLeadMediumId == Guid.Empty && ResultLeadSourceId == Guid.Empty && string.IsNullOrEmpty(bpmRef)) {
				ResultLeadMediumId = LeadMediumConsts.LeadMediumDirectTrafficId;
				return;
			}
			GetMediumSourceByRef();
		}

		/// <summary>
		/// Defines channel and source by parameters specified.
		/// </summary>
		/// <param name="parameters"><see cref="Dictionary{string, string}"/> of parameters available.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		public virtual (Guid Medium, Guid Source) ComputeMediumAndSource(Dictionary<string, string> parameters) {
			string bpmRef = string.Empty;
			string bpmHref;
			ClearResults();
			if (parameters.ContainsKey("bpmRef")) {
				bpmRef = parameters["bpmRef"];
				this.bpmRef = bpmRef;
			}
			if (parameters.ContainsKey("bpmHref")) {
				bpmHref = parameters["bpmHref"];
				this.bpmHref = bpmHref;
				InitBpmHrefParameters();
				ComputeMediumAndSource();
				return (ResultLeadMediumId, ResultLeadSourceId);
			}
			var utmMedium = parameters.ContainsKey("utm_medium") ? parameters["utm_medium"] : string.Empty;
			var utmSource = parameters.ContainsKey("utm_source") ? parameters["utm_source"] : string.Empty;
			var utmCampaign = parameters.ContainsKey("utm_campaign") ? parameters["utm_campaign"] : string.Empty;
			GetMediumSourceByUtm(utmMedium, utmSource, utmCampaign);
			if (ResultLeadMediumId.IsNotEmpty() && ResultLeadSourceId.IsNotEmpty()) {
				return (ResultLeadMediumId, ResultLeadSourceId);
			}
			GetMediumSourceByRef(bpmRef);
			return (ResultLeadMediumId, ResultLeadSourceId);
		}

		/// <summary>
		/// Defines channel and source by form data specified.
		/// </summary>
		/// <param name="formData">Form data instance.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		public virtual (Guid Medium, Guid Source) ComputeMediumAndSource(FormData formData) {
			var parameters = GetParamsByFormData(formData);
			return ComputeMediumAndSource(parameters);
		}

		#endregion
	}

	#endregion

	#region Class: LeadMediumConsts

	/// <summary>
	/// Contains lookup constant values.
	/// </summary>
	public static class LeadMediumConsts
	{

		/// <summary>
		/// Social networks.
		/// </summary>
		public static readonly Guid LeadMediumSocialNetworkId = new Guid("FA3F5AD8-56DA-4FCF-AA79-7033BDF62178");

		/// <summary>
		/// Email
		/// </summary>
		public static readonly Guid LeadMediumEmailId = new Guid("E95C0D56-E773-4A7C-81D8-148619BEEBB0");

		/// <summary>
		/// Search ads.
		/// </summary>
		public static readonly Guid LeadMediumSearchAdId = new Guid("33A3B3FE-FAB9-4256-91BB-B574E021C70A");

		/// <summary>
		/// Other online ads.
		/// </summary>
		public static readonly Guid LeadMediumOtherOnlineAdId = new Guid("7E9F5358-E4FF-4139-A23A-0BFC4A1F1BB5");

		/// <summary>
		/// Media ads.
		/// </summary>
		public static readonly Guid LeadMediumMediaId = new Guid("39B44989-6790-4231-9058-BCB149EEFF80");

		/// <summary>
		/// Other channels.
		/// </summary>
		public static readonly Guid LeadMediumOtherMediaId = new Guid("22BCD15D-99AC-4ED1-BDA9-2CDF7CA566EF");

		/// <summary>
		/// Free search.
		/// </summary>
		public static readonly Guid LeadMediumFreeSearchId = new Guid("AE811C69-D09F-4BFB-B619-71F4FB19FD14");

		/// <summary>
		/// Switching from another site.
		/// </summary>
		public static readonly Guid LeadMediumReferrerTrafficId = new Guid("CD64D8C3-746A-4C73-93AD-09A75AE71501");

		/// <summary>
		/// Direct traffic.
		/// </summary>
		public static readonly Guid LeadMediumDirectTrafficId = new Guid("E896A7AC-A6FE-43AA-A2CD-161B0FAF65BB");

		/// <summary>
		/// Offline ads.
		/// </summary>
		public static readonly Guid LeadMediumOfflineAdId = new Guid("93412DDD-98C1-4F6E-8D98-696875D057FB");

	}

	#endregion

	#region Class: LeadSourceConsts

	/// <summary>
	/// Contains LeadSource lookup constant values.
	/// </summary>
	public static class LeadSourceConsts
	{

		/// <summary>
		/// Google AdWords.
		/// </summary>
		public static readonly Guid LeadSourceGoogleAdWordsId = new Guid("6177C15B-5439-4C60-BA46-4D2EB201270E");

		/// <summary>
		/// Yandex Direct.
		/// </summary>
		public static readonly Guid LeadSourcekYandexDirectId = new Guid("339FBDD8-2CA0-4A40-98A5-1B4B96A01661");

		/// <summary>
		/// Other site.
		/// </summary>
		public static readonly Guid LeadSourceOtherId = new Guid("F5E73B24-BD68-45BA-9EC6-DEE40A35C615");

	}

	#endregion

}
