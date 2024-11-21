namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using System.Linq;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Core.Entities;

	#region Class:  BulkEmailRecipientValidatorBuilder

	/// <summary>
	/// Represents a class for building macro validation rules.
	/// </summary>
	public class BulkEmailRecipientValidatorBuilder
	{

		#region Constants: Private

		private const string ActiveDomainStatus = "active";

		#endregion

		#region Fields: Private

		private readonly ICESApi _serviceApi;

		private readonly BulkEmail _bulkEmail;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailRecipientValidatorBuilder"/> class.
		/// </summary>
		/// <param name="serviceApi">Service for working with api.</param>
		[Obsolete("7.18.4 | Use BulkEmailRecipientValidatorBuilder(ICESApi serviceApi, Entity bulkEmail) instead.")]
		public BulkEmailRecipientValidatorBuilder(ICESApi serviceApi) {
			_serviceApi = serviceApi;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailRecipientValidatorBuilder"/> class.
		/// </summary>
		/// <param name="serviceApi">Service for working with api.</param>
		/// <param name="bulkEmail">BulkEmail entity.</param>
		public BulkEmailRecipientValidatorBuilder(ICESApi serviceApi, Entity bulkEmail) {
			_serviceApi = serviceApi;
			_bulkEmail = bulkEmail as BulkEmail;
		}

		#endregion

		#region Methods: Private

		private HashSet<string> GetValidDomains() {
			var request = new SenderDomainsInfoRequest {
				ApiKey = _serviceApi.ApiKey,
				ProviderName = _bulkEmail?.ProviderName
			};
			var response = _serviceApi.SenderDomainsInfo(request);
			var domains = response.Domains
				.Where(x => x.Status == ActiveDomainStatus)
				.Select(x => x.Domain);
			return domains.ToHashSet();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes validation rules.
		/// </summary>
		public List<BaseValidationRule> InitRules() {
			var domains = new Lazy<HashSet<string>>(GetValidDomains);
			var result = new List<BaseValidationRule> {
				new FromNameNotNullValidationRule(),
				new FromEmailMaskValidationRule(),
				new FromEmailDomainValidationRule(domains)
			};
			return result;
		}

		#endregion

	}

	#endregion
}
