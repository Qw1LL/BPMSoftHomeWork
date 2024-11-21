namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Mail;
	using System.Text.RegularExpressions;
	using BPMSoft.Enrichment.Interfaces;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: EnrichEntitySearchHelper

	/// <summary>
	/// Utility methods for contact and accounts identification by communications like phones, e-mails, web.
	/// </summary>
	public class EnrichEntitySearchHelper
	{

		#region Consts: Private

		private const int MaxDomainCountForSearch = 3;

		#endregion

		#region Fields: Private

		private readonly IAccountSearcher _accountSearcher;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public EnrichEntitySearchHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			var userConnectionConstructorArgument = new ConstructorArgument("userConnection", userConnection);
			_accountSearcher = ClassFactory.Get<IAccountSearcher>(userConnectionConstructorArgument);
		}

		#endregion

		#region Methods: Private

		private HashSet<CommunicationEntity> ConvertToCommunicationEntities(
				List<EnrichTextDataItem> enrichTextItems) {
			IEnumerable<CommunicationEntity> communicationEntities = enrichTextItems
				.Where(item => item.Type == EnrchTextEntityType.Communication && item.JsonData.IsNotNullOrEmpty())
				.Select(item => Json.Deserialize<CommunicationEntity>(item.JsonData));
			return new HashSet<CommunicationEntity>(communicationEntities);
		}

		private TextEntities ConvertToTextEntities(List<EnrichTextDataItem> enrichTextItems) {
			var result = new TextEntities();
			foreach (EnrichTextDataItem item in enrichTextItems) {
				if (item.JsonData.IsNullOrEmpty()) {
					continue;
				}
				if (item.Type == EnrchTextEntityType.Organization) {
					result.Organizations.Add(Json.Deserialize<OrganizationEntity>(item.JsonData));
				} else if (item.Type == EnrchTextEntityType.Address) {
					result.Addresses.Add(Json.Deserialize<AddressEntity>(item.JsonData));
				} else if (item.Type == EnrchTextEntityType.Communication) {
					result.Communications.Add(Json.Deserialize<CommunicationEntity>(item.JsonData));
				} else if (item.Type == EnrchTextEntityType.Contact) {
					result.Contacts.Add(Json.Deserialize<ContactEntity>(item.JsonData));
				} else if (item.Type == EnrchTextEntityType.Job) {
					result.Jobs.Add(Json.Deserialize<JobEntity>(item.JsonData));
				}
			}
			return result;
		}

		private void AddIdentification(Guid entityId, IEnumerable<Guid> identifiedRecordIds,
				IdentificationType identificationType, string foundEntityTableName, string entityColumnName) {
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				foreach (Guid identifiedRecordId in identifiedRecordIds) {
					Insert insert = new Insert(_userConnection).Into(foundEntityTableName);
					insert.Set("EnrchTextEntityId", Column.Parameter(entityId));
					insert.Set("IdentificationType", Column.Parameter(identificationType.ToString()));
					insert.Set(entityColumnName, Column.Parameter(identifiedRecordId));
					insert.Execute(dbExecutor);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the emails.
		/// </summary>
		/// <param name="textEntities">The text entities.</param>
		/// <param name="parentEntityId">The parent entity identifier.</param>
		/// <returns></returns>
		public static List<string> GetEmails(TextEntities textEntities, Guid parentEntityId) {
			List<string> emails = textEntities.Communications
				.Where(entity => entity.Type == EnrchCommunicationType.Email && entity.ContactId == parentEntityId)
				.Select(entity => entity.Value)
				.ToList();
			return emails;
		}

		/// <summary>
		/// Gets the phones.
		/// </summary>
		/// <param name="textEntities">The text entities.</param>
		/// <param name="parentEntityId">The parent entity identifier.</param>
		/// <returns></returns>
		public static List<string> GetPhones(TextEntities textEntities, Guid parentEntityId) {
			List<string> phones = textEntities.Communications
				.Where(entity => entity.IsPhone && entity.Type == EnrchCommunicationType.Mobile
					&& entity.ContactId == parentEntityId)
				.Select(entity => entity.Value)
				.ToList();
			return phones;
		}

		/// <summary>
		/// Extracts the email domain.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <returns>The domain of email.</returns>
		public static string ExtractEmailDomain(string email) {
			if (email.IsNullOrEmpty()) {
				return null;
			}
			MailAddress address;
			try {
				address = new MailAddress(email);
			} catch (FormatException) {
				return null;
			}
			return address.Host;
		}

		/// <summary>
		/// Extracts the web domain.
		/// </summary>
		/// <param name="webAddress">The web address.</param>
		/// <returns></returns>
		public static string ExtractWebDomain(string webAddress) {
			UriBuilder uriBuilder;
			try {
				uriBuilder = new UriBuilder(webAddress);
			} catch (UriFormatException) {
				return null;
			}
			var noWorldWideWebRegex = new Regex(@"^www\.");
			string domain = noWorldWideWebRegex.Replace(uriBuilder.Host, "");
			return domain;
		}

		/// <summary>
		/// Gets the email domains for search.
		/// </summary>
		/// <param name="communications">The communications.</param>
		/// <returns></returns>
		public static List<string> GetEmailDomainsForSearch(ICollection<CommunicationEntity> communications) {
			List<string> addressesForSearch = communications
				.Where(info => info.Type == EnrchCommunicationType.Email && !info.IsFreeDomain)
				.Select(info => ExtractEmailDomain(info.Value))
				.Distinct()
				.Take(MaxDomainCountForSearch)
				.ToList();
			return addressesForSearch;
		}

		/// <summary>
		/// Gets the web domains for search.
		/// </summary>
		/// <param name="communications">The communication set.</param>
		/// <returns></returns>
		public static List<string> GetWebDomainsForSearch(ICollection<CommunicationEntity> communications) {
			List<string> webAddressesForSearch = communications
				.Where(info => info.Type == EnrchCommunicationType.Web)
				.Select(info => ExtractWebDomain(info.Value))
				.Distinct()
				.Take(MaxDomainCountForSearch)
				.ToList();
			return webAddressesForSearch;
		}

		/// <summary>
		/// Identifies the account by enriched text entities.
		/// </summary>
		/// <param name="communications">The communication set.</param>
		/// <param name="accountIds">The account ids found by.</param>
		/// <returns></returns>
		public AccountIdentificationType IdentifyAccountByEte(ICollection<CommunicationEntity> communications,
				out IEnumerable<Guid> accountIds) {
			List<string> webDomains = GetWebDomainsForSearch(communications);
			accountIds = _accountSearcher.SearchByDomain(webDomains);
			if (!accountIds.IsNullOrEmpty()) {
				return AccountIdentificationType.WebDomain;
			}
			List<string> emailDomains = GetEmailDomainsForSearch(communications);
			accountIds = _accountSearcher.SearchByDomain(emailDomains);
			if (!accountIds.IsNullOrEmpty()) {
				return AccountIdentificationType.EmailDomain;
			}
			return null;
		}

		/// <summary>
		/// Identifies the account by enriched text entities.
		/// </summary>
		/// <param name="enrichTextItems">The enrich text items.</param>
		/// <returns></returns>
		public IList<Guid> IdentifyAccountByEte(List<EnrichTextDataItem> enrichTextItems) {
			IEnumerable<Guid> accountIds;
			HashSet<CommunicationEntity> communications = ConvertToCommunicationEntities(enrichTextItems);
			IdentifyAccountByEte(communications, out accountIds);
			if (accountIds != null) {
				return accountIds.ToList();
			}
			return new List<Guid>();
		}

		/// <summary>
		/// Updates the account identification information.
		/// </summary>
		/// <param name="enrichTextItems">The enrich text items.</param>
		/// <returns></returns>
		public List<EnrichAccountItem> UpdateAccountIdentificationInfo(List<EnrichTextDataItem> enrichTextItems) {
			TextEntities textEntities = ConvertToTextEntities(enrichTextItems);
			HashSet<OrganizationEntity> organizations = textEntities.Organizations;
			var result = new List<EnrichAccountItem>();
			foreach (OrganizationEntity organizationEntity in organizations) {
				IEnumerable<Guid> accountIds;
				AccountIdentificationType identificationType = IdentifyAccount(organizationEntity, textEntities,
					out accountIds);
				var guids = accountIds != null ? accountIds.ToList() : null;
				if (!guids.IsNullOrEmpty()) {
					Guid entityId = organizationEntity.Id;
					AddFoundAccounts(entityId, guids, identificationType);
					foreach (Guid id in guids) {
						result.Add(new EnrichAccountItem {
							Id = id,
							EnrchTextEntityId = entityId
						});
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Adds the found contacts.
		/// </summary>
		/// <param name="contactEntityId">The contact entity identifier.</param>
		/// <param name="contactIds">The contact ids.</param>
		/// <param name="identificationType">Type of the identification.</param>
		public void AddFoundContacts(Guid contactEntityId, IEnumerable<Guid> contactIds,
				ContactIdentificationType identificationType) {
			AddIdentification(contactEntityId, contactIds, identificationType, "EnrchFoundContact", "ContactId");
		}

		/// <summary>
		/// Adds the found accounts.
		/// </summary>
		/// <param name="accountEntityId">The account entity id.</param>
		/// <param name="accountIds">The account ids.</param>
		/// <param name="identificationType">Type of the identification.</param>
		public void AddFoundAccounts(Guid accountEntityId, IEnumerable<Guid> accountIds,
				AccountIdentificationType identificationType) {
			AddIdentification(accountEntityId, accountIds, identificationType, "EnrchFoundAccount", "AccountId");
		}

		/// <summary>
		/// Executes chain identification for account by name and communicatications.
		/// </summary>
		/// <param name="organizationEntity">The organization entity.</param>
		/// <param name="textEntities">The text entities.</param>
		/// <param name="accountIds">The account ids.</param>
		/// <returns></returns>
		public AccountIdentificationType IdentifyAccount(OrganizationEntity organizationEntity,
				TextEntities textEntities, out IEnumerable<Guid> accountIds) {
			accountIds = _accountSearcher.SearchByName(organizationEntity.Value);
			if (!accountIds.IsNullOrEmpty()) {
				return AccountIdentificationType.Name;
			}
			IEnumerable<CommunicationEntity> organizationCommunications =
				from communication in textEntities.Communications
				join contact in textEntities.Contacts on communication.ContactId equals contact.Id
				where contact.OrganizationId == organizationEntity.Id
				select communication;
			return IdentifyAccountByEte(organizationCommunications.ToList(), out accountIds);
		}

		#endregion

	}

	#endregion


}

