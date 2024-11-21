namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Enrichment.Interfaces;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Interface: IDeduplicator

	/// <summary>
	/// Provides utility methods for deduplication of mined data.
	/// </summary>
	public interface IDeduplicator
	{

		#region Methods: Public

		/// <summary>
		/// Marks mined entities, that are already present in contact, as duplicates.
		/// </summary>
		/// <param name="identifiedContact">
		/// Dictionary, where key is mined contact text entity id and value is identified contact.
		/// </param>
		/// <param name="entities">Mined entities.</param>
		void DeduplicateContactData(Dictionary<Guid, Guid> identifiedContacts, TextEntities entities);

		#endregion

	}

	#endregion

	#region Class: Deduplicator

	/// <summary>
	/// Default implementation of <see cref="BPMSoft.Configuration.EmailMining.IDeduplicator"/>.
	/// </summary>
	[DefaultBinding(typeof(IDeduplicator))]
	public class Deduplicator : IDeduplicator
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of <see cref="BPMSoft.Configuration.EmailMining.Deduplicator"/> class.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public Deduplicator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		/// <summary>
		/// Initializes a new Iinstance of <see cref="BPMSoft.Configuration.EmailMining.Deduplicator"/> class
		/// with custom <see cref="BPMSoft.Configuration.IPhoneNumberComparer"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="phoneNumberComparer">Phone number comparer.</param>
		public Deduplicator(UserConnection userConnection, IPhoneNumberComparer phoneNumberComparer) {
			_userConnection = userConnection;
			_phoneComparer = phoneNumberComparer;
		}

		#endregion

		#region Properties: Private

		private IPhoneNumberComparer _phoneComparer;
		private IPhoneNumberComparer PhoneComparer {
			get {
				return _phoneComparer ?? (_phoneComparer = new PhoneNumberComparer(_userConnection));
			}
		}

		private HashSet<Guid> _phoneTypes;
		private HashSet<Guid> PhoneTypes {
			get {
				return _phoneTypes ?? (_phoneTypes = LoadPhoneTypes());
			}
		}

		#endregion

		#region Methods: Private

		private HashSet<Guid> LoadPhoneTypes() {
			var select = (Select)new Select(_userConnection)
					.Column("CommunicationTypeId")
				.From("ComTypebyCommunication").InnerJoin("Communication")
				.On("CommunicationId").IsEqual("Communication", "Id")
				.Where("Code").IsEqual(Column.Parameter("Phone"));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					return new HashSet<Guid>(reader.GetAllColumnValues<Guid>("CommunicationTypeId"));
				}
			}
		}

		private void LoadCommunications(HashSet<Guid> contactIds,
				out Dictionary<Guid, HashSet<string>> phones,
				out Dictionary<Guid, HashSet<string>> others) {
			phones = contactIds.ToDictionary(id => id, id => new HashSet<string>());
			others = contactIds.ToDictionary(id => id, id => new HashSet<string>());
			var select = (Select)new Select(_userConnection)
					.Column("ContactId")
					.Column("Number")
					.Column("SearchNumber")
					.Column("CommunicationTypeId")
				.From("ContactCommunication")
				.Where("ContactId").In(Column.Parameters(contactIds));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid contactId = reader.GetColumnValue<Guid>("ContactId");
						bool isPhone = PhoneTypes.Contains(reader.GetColumnValue<Guid>("CommunicationTypeId"));
						if (isPhone) {
							phones[contactId].Add(reader.GetColumnValue<string>("SearchNumber"));
						} else {
							others[contactId].Add(reader.GetColumnValue<string>("Number"));
						}
					}
				}
			}
		}

		private Dictionary<Guid, string> LoadInfo(HashSet<Guid> ids, string schema, string field) {
			Dictionary<Guid, string> info = ids.ToDictionary(id => id, id => string.Empty);
			Select select = (Select)new Select(_userConnection)
					.Column("Id")
					.Column(field)
				.From(schema)
				.Where("Id").In(Column.Parameters(ids));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = reader.GetColumnValue<Guid>("Id");
						string filedValue = reader.GetColumnValue<string>(field);
						info[id] = filedValue;
					}
				}
			}
			return info;
		}

		private void UpdateDuplicateEntities(IEnumerable<Guid> duplicateEntities) {
			Update update = (Update)new Update(_userConnection, "EnrchTextEntity")
				.Set("DuplicationStatus", Column.Parameter(EnrchDuplicateStatus.ExistsInEntity.ToString()))
				.Where("Id").In(Column.Parameters(duplicateEntities));
			update.Execute();
		}

		private IEnumerable<Guid> FindDuplicateCommunications(Dictionary<Guid, Guid> identifiedContacts,
				TextEntities textEntities) {
			List<Guid> duplicateCommunications = new List<Guid>();
			IEnumerable<CommunicationEntity> minedCommunicationEntities = textEntities.Communications
				.Where(minedCommunication => identifiedContacts.ContainsKey(minedCommunication.ContactId));
			if (minedCommunicationEntities.IsEmpty()) {
				return duplicateCommunications;
			}
			Dictionary<Guid, HashSet<string>> phones;
			Dictionary<Guid, HashSet<string>> others;
			HashSet<Guid> contactIds = new HashSet<Guid>(identifiedContacts.Values);
			LoadCommunications(contactIds, out phones, out others);
			foreach (CommunicationEntity minedCommunication in minedCommunicationEntities) {
				Guid identifiedContact = identifiedContacts[minedCommunication.ContactId];
				if (minedCommunication.IsPhone) {
					HashSet<string> knownContactPhones = phones[identifiedContact];
					if (PhoneComparer.MatchAny(minedCommunication.Value, knownContactPhones)) {
						duplicateCommunications.Add(minedCommunication.Id);
					}
				} else {
					HashSet<string> knownOtherCommunications = others[identifiedContact];
					if (knownOtherCommunications.Contains(minedCommunication.Value)) {
						duplicateCommunications.Add(minedCommunication.Id);
					}
				}
			}
			return duplicateCommunications;
		}

		private IEnumerable<Guid> FindDuplicateAddresses(Dictionary<Guid, Guid> identifiedContacts,
				TextEntities textEntities) {
			List<Guid> duplicateAddresses = new List<Guid>();
			IEnumerable<AddressEntity> minedAddressEntities = textEntities.Addresses
				.Where(minedAddress => identifiedContacts.ContainsKey(minedAddress.ContactId));
			if (minedAddressEntities.IsNotEmpty()) {
				HashSet<Guid> contactIds = new HashSet<Guid>(identifiedContacts.Values);
				Dictionary<Guid, string> addresses = LoadInfo(contactIds, "Contact", "Address");
				foreach (AddressEntity minedAddress in minedAddressEntities) {
					Guid identifiedContact = identifiedContacts[minedAddress.ContactId];
					string knownAddress = addresses[identifiedContact];
					if (knownAddress == minedAddress.Value) {
						duplicateAddresses.Add(minedAddress.Id);
					}
				}
			}
			return duplicateAddresses;
		}

		private IEnumerable<Guid> FindDuplicateJobs(Dictionary<Guid, Guid> identifiedContacts,
				TextEntities textEntities) {
			List<Guid> duplicateJobs = new List<Guid>();
			IEnumerable<JobEntity> minedJobEntities = textEntities.Jobs
				.Where(minedJob => identifiedContacts.ContainsKey(minedJob.ContactId));
			if (minedJobEntities.IsNotEmpty()) {
				HashSet<Guid> contactIds = new HashSet<Guid>(identifiedContacts.Values);
				Dictionary<Guid, string> jobs = LoadInfo(contactIds, "Contact", "JobTitle");
				foreach (JobEntity minedJob in minedJobEntities) {
					Guid identifiedContact = identifiedContacts[minedJob.ContactId];
					string knownJob = jobs[identifiedContact];
					if (knownJob == minedJob.Value) {
						duplicateJobs.Add(minedJob.Id);
					}
				}
			}
			return duplicateJobs;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Marks mined entities, that are already present in contact, as duplicates.
		/// </summary>
		/// <param name="identifiedContact">
		/// Dictionary, where key is mined contact text entity id and value is identified contact.
		/// </param>
		/// <param name="entities">Mined entities.</param>
		public void DeduplicateContactData(Dictionary<Guid, Guid> identifiedContacts, TextEntities entities) {
			var duplicateCommunications = FindDuplicateCommunications(identifiedContacts, entities);
			var duplicateAddresses = FindDuplicateAddresses(identifiedContacts, entities);
			var duplicateJobs = FindDuplicateJobs(identifiedContacts, entities);
			var duplicates = duplicateCommunications.Concat(duplicateAddresses).Concat(duplicateJobs);
			if (duplicates.IsNotEmpty()) {
				UpdateDuplicateEntities(duplicates);
			}
		}

		#endregion

	}

	#endregion

}

