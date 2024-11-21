namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.Interfaces;
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Class: OmnichannelContactIdentifier

	/// <summary>
	/// Class that identifies contact by messenger identifier.
	/// </summary>
	public class OmnichannelContactIdentifier
	{
		#region Constants: Public

		public static string ContactsByIdentifierCacheKey = "OmnichannelContactsByChannelAndIdentifier";

		#endregion

		#region Properties: Private

		private readonly string _newContactName = "NewContactNameLocalizableString";

		ConcurrentDictionary<string, Guid> _contactsByChannelAndIdentifier;
		private ConcurrentDictionary<string, Guid> ContactsByChannelAndIdentifier {
			get	{
					_contactsByChannelAndIdentifier = _contactsByChannelAndIdentifier ?? UserConnection.ApplicationCache
						.GetValue<ConcurrentDictionary<string, Guid>>(ContactsByIdentifierCacheKey);
					if (_contactsByChannelAndIdentifier == null) {
						InitializeContactsByIdentifier();
					}
				return _contactsByChannelAndIdentifier;
			}
		}

		private readonly MessageWorkerFactory<IProfileDataProvider> _profileDataProviderFactory;
		private readonly ProfileImageLoader _profileImageLoader;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection	{
			get;
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private static ILog _log;
		protected static ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelContactIdentifier"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="OmnichannelContactIdentifier"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public OmnichannelContactIdentifier(UserConnection userConnection) {
			UserConnection = userConnection;
			_profileDataProviderFactory = new MessageWorkerFactory<IProfileDataProvider>(userConnection);
			_profileImageLoader = new ProfileImageLoader(UserConnection);
		}

		#endregion

		#region Methods: Private

		private void InitializeContactsByIdentifier() {
			_contactsByChannelAndIdentifier = new ConcurrentDictionary<string, Guid>();
			UserConnection.ApplicationCache
				.SetOrRemoveValue(ContactsByIdentifierCacheKey, _contactsByChannelAndIdentifier);
		}
		
		private Guid GetPhotoId(ProfileData contactData, string contactName) {
			var photoId = Guid.Empty;
			if (contactData?.ProfilePhoto != null) {
				photoId = _profileImageLoader.SaveImage(contactData.ProfilePhoto, contactName);
			} else if (!string.IsNullOrEmpty(contactData?.ProfilePhotoUrl)) {
				photoId = _profileImageLoader.GetProfilePhotoIdByUrl(contactData.ProfilePhotoUrl, contactName);
			}
			return photoId;
		}

		private void DeleteCreatedContact(Guid contactId) {
			new Delete(UserConnection)
				.From("Contact")
				.Where("Id").IsEqual(Column.Parameter(contactId))
				.Execute();
		}

		private void InsertIdentityContactInfo(Guid contactId, MessagingMessage message) {
			Entity contactIdentity = UserConnection.EntitySchemaManager
				.GetInstanceByName("ContactIdentity")
				.CreateEntity(UserConnection);
			contactIdentity.SetColumnValue("ContactId", contactId);
			contactIdentity.SetColumnValue("ChannelIdentity", message.SenderIfEcho);
			contactIdentity.SetColumnValue("ChannelId", message.ChannelId);
			contactIdentity.SetColumnValue("IsGuestUser", message.IsGuestUser);
			contactIdentity.Save(false);
			Log.DebugFormat("ContactIdentity was created: ContactId={0}, ChannelIdentity={1}," +
				" ChannelId={2}", contactId, message.SenderIfEcho, message.ChannelId);
		}

		private string GetContactName(string channelName, string contactIdentifier)		{
			return string.Format("{0} ({1} - {2})", new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"OmnichannelContactIdentifier", "LocalizableStrings." + _newContactName + ".Value").ToString(), 
				channelName, contactIdentifier);
		}

		private Guid GetExistingContact(MessagingMessage message) {
			Guid contactId = GetContactByChannelIdentity(message, out bool isNeedToCreateContactIdentity);
			if (contactId == default(Guid) && message.ContactIdentification != null) {
				contactId = GetContactByIdentification(message.ContactIdentification);
				isNeedToCreateContactIdentity = true;
			}
			if (contactId != default && isNeedToCreateContactIdentity) {
				InsertIdentityContactInfo(contactId, message);
			}
			return contactId;
		}

		private Guid GetContactByChannelIdentity(MessagingMessage message, out bool IsContactIdentityByChannelExists) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.AddColumn("Channel");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ChannelIdentity", message.SenderIfEcho));
			var contactCollection = esq.GetEntityCollection(UserConnection);
			var contactIdentityCollection = contactCollection.Where((item) => item.GetTypedColumnValue<Guid>("ChannelId").ToString() == message.ChannelId);
			IsContactIdentityByChannelExists = contactIdentityCollection.IsEmpty();
			return contactCollection.Any() ? contactCollection.First().GetTypedColumnValue<Guid>("ContactId") : default(Guid);
		}

		private Guid GetContactByIdentification(Dictionary<ContactIdentificationType, string> identification) {
			Guid contactId = default(Guid);
			if (identification.TryGetValue(ContactIdentificationType.Phone, out string phoneNumber) 
					&& phoneNumber.IsNotNullOrEmpty()) {
				contactId = GetContactByPhoneNumber(phoneNumber);
				if (contactId != default(Guid)) {
					return contactId;
				}
			}
			return contactId;
		}

		private Guid GetContactByPhoneNumber(string phoneNumber) {
			return ContactUtilities.GetContactsByPhone(UserConnection, phoneNumber).FirstOrDefault();
		}

		private void PushContactIdToCache(string cacheKey, Guid contactId)	{
			ContactsByChannelAndIdentifier[cacheKey] = contactId;
			UserConnection.ApplicationCache
				.SetOrRemoveValue(ContactsByIdentifierCacheKey, ContactsByChannelAndIdentifier);
		}

		private bool TryGetContactIdFromCache(string cacheKey, out Guid contactId)	{
			return ContactsByChannelAndIdentifier.TryGetValue(cacheKey, out contactId);
		}
		
		private void UpdateGuestMode(Guid contactId) {
			var update = new Update(UserConnection, "ContactIdentity")
				.Set("IsGuestUser", Column.Parameter(true))						
				.Where("ContactId").IsEqual(Column.Const(contactId)) as Update;
			update.Execute();
		}

		#endregion

		#region Methods: Protected

		protected virtual ProfileData GetContactData(MessagingMessage message)	{
			if (message.ContactIdentification != null
					&& message.ContactIdentification.TryGetValue(ContactIdentificationType.Name, out string name)
					&& name.IsNotNullOrEmpty()) {
				return new ProfileData() {
					Id = message.SenderIfEcho,
					FirstName = name
				};
			}
			if (message.IsGuestUser) {
				return null;
			}
			var provider = _profileDataProviderFactory.GetWorkerByMessenger(message.ChannelName);
			return provider.GetProfileDataByProfileId(message.SenderIfEcho, message.ChannelId);
		}

		#endregion

		#region Methods: Public

		public Guid CreateNewContact(MessagingMessage message)	{
			var contactData = GetContactData(message);
			if (contactData != null) {
				Log.DebugFormat("Got contact data: first_name={0}, id={1}," +
					" picture_url={2}", contactData.FirstName, contactData.Id, contactData.ProfilePhotoUrl);
			} else {
				Log.DebugFormat("No contact data found");
			}
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			var contactId = Guid.NewGuid();
			contact.SetDefColumnValues();
			contact.SetColumnValue("Id", contactId);
			if (message.ContactIdentification != null && message.ContactIdentification.TryGetValue(ContactIdentificationType.Phone, out string phoneNumber)
					&& phoneNumber.IsNotNullOrEmpty()) {
				contact.SetColumnValue("MobilePhone", phoneNumber);
			}
			var contactName = (contactData != null) && (contactData.FirstName.IsNotNullOrEmpty() || contactData.LastName.IsNotNullOrEmpty()) ?
				contactData.FirstName + " " + contactData.LastName : GetContactName(message.ChannelName, message.SenderIfEcho);
			var photoId = GetPhotoId(contactData, contactName);
			if (photoId != Guid.Empty) {
				contact.SetColumnValue("PhotoId", photoId);
			}
			contact.SetColumnValue("Name", contactName);
			contact.Save(false);
			Log.InfoFormat("Contact with Name {0} and Id {1} was created", contactName, contactId);
			try {
				InsertIdentityContactInfo(contactId, message);
			} catch (Exception e) {
				DeleteCreatedContact(contactId);
				contactId = GetExistingContact(message);
			}
			return contactId;
		}
		
		/// <summary>
		/// Creates ContactIdentity with flag isGuestUser = true
		/// <param name="message">Incoming message.</param>
		/// </summary>
		public void CreateGuestContactIdentity(MessagingMessage message) {
			Guid contactId = GetContactId(message);
			UpdateGuestMode(contactId);
			Log.Info($"Set guest mode to true for contact {contactId}");
		}

		/// <summary>
		/// Gets contact via its messenger identifier.
		/// <param name="message">Message from contact.</param>
		/// <returns>Contact identifier.</returns>
		/// </summary>
		public Guid GetContactId(MessagingMessage message)	{
			string contactSender = message.SenderIfEcho;
			var contactId = default(Guid);
			var cacheKey = message.ChannelId + contactSender;
			Log.DebugFormat("Got message parameters: Sender={0}, ChannelId={1}," +
							" Source={2}", contactSender, message.ChannelId, message.Source);
			if (!string.IsNullOrEmpty(message.ChannelId) && !TryGetContactIdFromCache(cacheKey, out contactId))	{
				contactId = GetExistingContact(message);
				if (contactId == default(Guid)) {
					Log.InfoFormat("Contact with Sender {0} wasn't found", contactSender, message.ChannelId);
					contactId = CreateNewContact(message);
				}
				PushContactIdToCache(cacheKey, contactId);
			} else {
				Log.InfoFormat("Contact with Id {0} was found in cache by key {1}", contactId, cacheKey);
			}
			return contactId;
		}

		/// <summary>
		/// Gets contact display value via its bpmstudio identifier.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Contact display value.</returns>
		public string GetContactDisplayValue(Guid contactId) {
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			return contact.FetchPrimaryInfoFromDB(contactSchema.PrimaryColumn, contactId) ? contact.PrimaryDisplayColumnValue : string.Empty;
		}

		/// <summary>
		/// Removes contact identity from cache.
		/// </summary>
		/// <param name="id">Contact identifier.</param>
		/// <param name="userConnection">User connection.</param>
		public static void RemoveIdentityFromCache(Guid id, UserConnection userConnection) {
			if (id == null || userConnection == null) {
				return;
			}
			var contacts = userConnection.ApplicationCache
				.GetValue<ConcurrentDictionary<string, Guid>>(ContactsByIdentifierCacheKey);
			if (contacts != null) {
				var keys = contacts.Where(c => c.Value == id).Select(c => c.Key);
				Log.DebugFormat("Removed contact (id={0}) identity cache by keys: {1}",
					id, string.Join(", ", keys));
				keys.ForEach(k => contacts.TryRemove(k, out var deleted));
				Log.DebugFormat("Rest contact ids in identity cache", string.Join(", ", contacts.Values));
				userConnection.ApplicationCache.SetOrRemoveValue(ContactsByIdentifierCacheKey, contacts);
			}
		}

		/// <summary>
		/// Flush contacts cache.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public static void FlushContactsCache(UserConnection userConnection) {
			userConnection.ApplicationCache.SetOrRemoveValue(ContactsByIdentifierCacheKey, null);
		}

		#endregion

	}

	#endregion

}
