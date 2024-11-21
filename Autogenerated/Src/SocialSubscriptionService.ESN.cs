namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using CoreEntityCollection = BPMSoft.Core.Entities.EntityCollection;
	using CoreEntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using CoreEntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SocialSubscriptionService : BaseService, IReadOnlySessionState
	{
		#region Properties: Public

		private DBSecurityEngine DBSecurityEngine {
			get;
			set;
		}

		private Guid SysAdminUnitId {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		public SocialSubscriptionService() {
			DBSecurityEngine = UserConnection.DBSecurityEngine;
			SysAdminUnitId = UserConnection.CurrentUser.Id;
		}

		#endregion

		#region Methods: Private

		private void CheckCanEdit(Guid[] socialSubscriptionIds, Guid channelId) {
			CheckRights(socialSubscriptionIds, channelId, BPMSoft.Core.DB.SchemaRecordRightLevels.CanEdit,
				"LocalizableStrings.SubscriptionCanNotBeEdited.Value");
		}

		private void CheckCanDelete(Guid[] socialSubscriptionIds, Guid channelId) {
			CheckRights(socialSubscriptionIds, channelId, BPMSoft.Core.DB.SchemaRecordRightLevels.CanDelete,
				"LocalizableStrings.SubscriptionCanNotBeDeleted.Value");
		}

		private void CheckRights(Guid[] socialSubscriptionIds, Guid channelId, 
			BPMSoft.Core.DB.SchemaRecordRightLevels rightLevel, string messageLocalizableString) {
				int result = 0;
				foreach (var socialSubscriptionId in socialSubscriptionIds) {
					var socialSubscriptionRightLevel = DBSecurityEngine.GetEntitySchemaRecordRightLevel("SocialSubscription", socialSubscriptionId);
					if ((socialSubscriptionRightLevel & rightLevel) != rightLevel) {
						result++;
					}
				}
				var socialChannelRightLevel = DBSecurityEngine.GetEntitySchemaRecordRightLevel("SocialChannel", channelId);
				if ((socialChannelRightLevel & rightLevel) != rightLevel) {
					result++;
				}
				if (result > 0) {
					throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"SocialSubscriptionService", messageLocalizableString));
				}
		}

		private CoreEntityCollection GetSysAdminUnits(object[] contactIds) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			esq.AddAllSchemaColumns();
			var contactFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact.Id", contactIds);
			esq.Filters.Add(contactFilter);
			object actualizeDemoDate = null;
			if (Convert.ToBoolean((bool)BPMSoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, "ActualizedDemoDate", out actualizeDemoDate))) {
				var sysAdminUnitIdFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", SysAdminUnitId);
				esq.Filters.Add(sysAdminUnitIdFilter);
			}
			return esq.GetEntityCollection(UserConnection);
		}

		private CoreEntityCollection GetSocialSubscriptions(object[] socialSubscriptionIds) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialSubscription");
			esq.AddAllSchemaColumns();
			var primaryColumnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", socialSubscriptionIds);
			esq.Filters.Add(primaryColumnFilter);
			return esq.GetEntityCollection(UserConnection);
		}

		/// <summary>
		/// Returns unique identifier of the contact who created the feed.
		/// </summary>
		/// <param name="socialSubscriptionId">Subscription unique identifier.</param>
		/// <param name="entityId">Entity unique identifier.</param>
		private Guid GetSocialChannelOwnerId(Guid socialSubscriptionId, Guid entityId) {
			CoreEntitySchema schema = GetSchema(socialSubscriptionId);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schema.Name);
			EntitySchemaQueryColumn ownerColumn;
			var ownerColumnExist = schema.Columns.Any(c => c.Name == "Owner");
			if (ownerColumnExist) {
				ownerColumn = esq.AddColumn("Owner");
			} else {
				ownerColumn = esq.AddColumn("CreatedBy");
			}
			Entity socialChannel = esq.GetEntity(UserConnection, entityId);
			CoreEntitySchemaColumn entitySchemaColumn = socialChannel.Schema.FindSchemaColumnByPath(ownerColumn.Name);
			Guid ownerId = socialChannel.GetTypedColumnValue<Guid>(entitySchemaColumn);
			return ownerId;
		}

		private Guid FindOwnerUserId(Guid contactId) {
			var sysAdminUnit = new SysAdminUnit(UserConnection);
			var conditions = new Dictionary<string, object> {
				{"Contact", contactId}
			};
			if (sysAdminUnit.FetchFromDB(conditions)) {
				return sysAdminUnit.Id;
			}
			return Guid.Empty;
		}

		private Guid GetSchemaUId(Guid socialSubscriptionId) {
			var schemaUIdSelect = new Select(UserConnection)
					.Column("EntitySchemaUId")
				.From("SocialSubscription")
				.Where("Id").IsEqual(Column.Parameter(socialSubscriptionId)) as Select;
			var schemaUId = schemaUIdSelect.ExecuteScalar<Guid>();
			return schemaUId;
		}

		private CoreEntitySchema GetSchema(Guid socialSubscriptionId) {
			var schemaUId = GetSchemaUId(socialSubscriptionId);
			return UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
		}

		private void DeleteAuthorRights(SocialSubscription socialSubscription) {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			Guid sysAdminUnitId = socialSubscription.SysAdminUnitId;
			Guid socialChannelOwnerId = GetSocialChannelOwnerId(socialSubscription.Id, socialSubscription.EntityId);
			bool currentUserIsOwner = socialChannelOwnerId.Equals(currentUser.ContactId);
			bool currentUserIsSubscriber = sysAdminUnitId.Equals(currentUser.Id);
			if (currentUserIsOwner || currentUserIsSubscriber) {
				return;
			}
			var schemaName = "SocialSubscription";
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			if (!schema.AdministratedByRecords) {
				return;
			}
			ForceDeleteEntitySchemaRecordRightLevel(currentUser.Id, schemaName, socialSubscription.Id);
		}

		private void DeleteSocialSubscription(Guid sysAdminUnitId, Guid entityId) {
			var socialSubscription = new SocialSubscription(UserConnection);
			var conditions = new Dictionary<string, object> {
				{"SysAdminUnit", sysAdminUnitId},
				{"EntityId", entityId}
			};
			if (!socialSubscription.FetchFromDB(conditions)) {
				return;
			}
			InnerCheckCanUnsubscribe(socialSubscription);
			socialSubscription.Delete();
		}
		
		private void DeleteSubscription(Guid socialSubscriptionId) {
			var socialSubscription = new SocialSubscription(UserConnection);
			var conditions = new Dictionary<string, object> {
				{"Id", socialSubscriptionId}
			};
			if (!socialSubscription.FetchFromDB(conditions)) {
				return;
			}
			socialSubscription.Delete();
		}

		private int DeleteSocialUnsubscription(Guid sysAdminUnitId, Guid entityId) {
			var delete = new Delete(UserConnection)
					.From("SocialUnsubscription")
				.Where("SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("EntityId").IsEqual(Column.Parameter(entityId)) as Delete;
			var result = delete.Execute();
			return result;
		}

		private void DeleteSubscriberEditRight(SocialSubscription socialSubscription) {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			Guid sysAdminUnitId = socialSubscription.SysAdminUnitId;
			Guid socialChannelOwnerId = GetSocialChannelOwnerId(socialSubscription.Id, socialSubscription.EntityId);
			bool currentUserIsOwner = socialChannelOwnerId.Equals(currentUser.ContactId);
			bool currentUserIsSubscriber = sysAdminUnitId.Equals(currentUser.Id);
			if ((currentUserIsSubscriber && currentUserIsOwner) || !currentUserIsSubscriber) {
				return;
			}
			var schemaName = "SocialSubscription";
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			if (!schema.AdministratedByRecords) {
				return;
			}
			DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId, EntitySchemaRecordRightOperation.Edit, schemaName, socialSubscription.Id);
		}

		private void ForceDeleteEntitySchemaRecordRightLevel(Guid adminUnitId, string schemaName, Guid recordId) {
			foreach (EntitySchemaRecordRightOperation operation in Enum.GetValues(typeof(EntitySchemaRecordRightOperation))) {
				DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(adminUnitId, operation, schemaName, recordId);
			}
		}

		private SocialSubscription InsertSocialSubscription(Guid sysAdminUnitId, Guid entityId, Guid entitySchemaUId, bool canUnsubscribe = true) {
			var socialSubscription = (SocialSubscription)UserConnection.EntitySchemaManager.GetInstanceByName("SocialSubscription").CreateEntity(UserConnection);
			socialSubscription.SetDefColumnValues();
			socialSubscription.SysAdminUnitId = sysAdminUnitId;
			socialSubscription.EntitySchemaUId = entitySchemaUId;
			socialSubscription.EntityId = entityId;
			socialSubscription.CanUnsubscribe = canUnsubscribe;
			socialSubscription.Save();
			return socialSubscription;
		}

		private int InsertSocialUnsubscription(Guid sysAdminUnitId, Guid entityId) {
			var insert = new Insert(UserConnection).Into("SocialUnsubscription")
				.Set("SysAdminUnitId", Column.Parameter(sysAdminUnitId))
				.Set("EntityId", Column.Parameter(entityId));
			var result = insert.Execute();
			return result;
		}

		private void InnerChangeCanUnsubscribe(Guid[] socialSubscriptionIds, Guid channelId, bool canUnsubscribe) {
			CheckCanEdit(socialSubscriptionIds, channelId);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialSubscription");
			esq.AddAllSchemaColumns();
			foreach (var socialSubscriptionId in socialSubscriptionIds) {
				var record = esq.GetEntity(UserConnection, socialSubscriptionId);
				if (record == null) {
					continue;
				}
				record.SetColumnValue("CanUnsubscribe", canUnsubscribe);
				record.Save();
			}
		}

		private void InnerCheckCanUnsubscribe(SocialSubscription socialSubscription) {
			if (!socialSubscription.CanUnsubscribe) {
				throw new InvalidOperationException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SocialSubscriptionService", "LocalizableStrings.SubscriptionCanNotBeCancelled.Value"));
			}
			var canDeleteRight = BPMSoft.Core.DB.SchemaRecordRightLevels.CanDelete;
			var schemaRightLevel = DBSecurityEngine.GetEntitySchemaRecordRightLevel("SocialSubscription", socialSubscription.Id);
			if ((schemaRightLevel & canDeleteRight) != canDeleteRight) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SocialSubscriptionService", "LocalizableStrings.SubscriptionCanNotBeDeleted.Value"));
			}
		}
		
		private void CheckChannelEditRights(Guid socialChannelId) {
			var canEditRight = BPMSoft.Core.DB.SchemaRecordRightLevels.CanEdit;
			var schemaRightLevel = DBSecurityEngine.GetEntitySchemaRecordRightLevel("SocialChannel", socialChannelId);
			if ((schemaRightLevel & canEditRight) != canEditRight) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SocialSubscriptionService", "LocalizableStrings.SubscriptionCanNotBeEdited.Value"));
			}
		}

		/// <summary>
		/// Checks whether current users has read access right for the feed.
		/// </summary>
		/// <param name="entitySchemaUId">Feed entity schema unique identifier.</param>
		/// <param name="primaryColumnValue">Feed unique identifier.</param>
		private void CheckChannelReadRights(Guid entitySchemaUId, Guid primaryColumnValue) {
			SchemaRecordRightLevels canReadRight = BPMSoft.Core.DB.SchemaRecordRightLevels.CanRead;
			ISchemaManagerItem<CoreEntitySchema> schemaItem = UserConnection.EntitySchemaManager.GetItemByUId(entitySchemaUId);
			SchemaRecordRightLevels schemaRightLevel = DBSecurityEngine.GetEntitySchemaRecordRightLevel(schemaItem.Name, primaryColumnValue);
			if ((schemaRightLevel & canReadRight) != canReadRight) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SocialSubscriptionService", "LocalizableStrings.SocialChannelCanNotBeRead.Value"));
			}
		}

		/// <summary>
		/// Subscribes a user for an entity feed.
		/// </summary>
		/// <param name="sysAdminUnitId">User unique identifier.</param>
		/// <param name="entityId">Entity unique identifier.</param>
		/// <param name="entitySchemaUId">Entity schema unique identifier.</param>
		private void InnerSubscribeUser(Guid sysAdminUnitId, Guid entityId, Guid entitySchemaUId) {
			if (InnerGetIsUserSubscribed(sysAdminUnitId, entityId)) {
				return;
			}
			CheckChannelReadRights(entitySchemaUId, entityId);
			DeleteSocialUnsubscription(sysAdminUnitId, entityId);
			SocialSubscription socialSubscription = InsertSocialSubscription(sysAdminUnitId, entityId, entitySchemaUId);
			SetDefaultRights(socialSubscription);
		}

		private void CheckCanUnsubscribeFromFolder(Guid sysAdminUnitId, Guid entityId) {
			var query =
				new Select(UserConnection)
					.Column(Func.Count("SocialSubscription", "CanUnsubscribe"))
				.From("SocialSubscription")
				.InnerJoin("SysAdminUnitInRole")
					.On("SysAdminUnitInRole", "SysAdminUnitRoleId").IsEqual("SocialSubscription", "SysAdminUnitId")
				.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("SocialSubscription", "CanUnsubscribe").IsEqual(Column.Parameter(false))
				.And("SocialSubscription", "EntityId").IsEqual(Column.Parameter(entityId)) as Select;
			var result = query.ExecuteScalar<int>();
			if (result > 0) {
				throw new InvalidOperationException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SocialSubscriptionService", "LocalizableStrings.SubscriptionCanNotBeCancelled.Value"));
			}
		}

		private string InnerUnsubscribeUser(Guid sysAdminUnitId, Guid entityId) {
			try {
				DeleteSocialSubscription(sysAdminUnitId, entityId);
				if (InnerGetIsUserSubscribed(sysAdminUnitId, entityId)) {
					CheckCanUnsubscribeFromFolder(sysAdminUnitId, entityId);
					InsertSocialUnsubscription(sysAdminUnitId, entityId);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		private bool InnerGetIsUserSubscribed(Guid sysAdminUnitId, Guid entityId) {
			var query = new Select(UserConnection)
					.Column(Func.Count("SocialSubscription", "Id"))
				.From("SocialSubscription")
				.Join(JoinType.Inner, "SysAdminUnitInRole")
					.On("SysAdminUnitInRole", "SysAdminUnitRoleId").IsEqual("SocialSubscription", "SysAdminUnitId")
				.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("SocialSubscription", "EntityId").IsEqual(Column.Parameter(entityId)) 
				.And().Not().Exists(
					new Select(UserConnection)
						.Column("SocialUnsubscription", "Id")
					.From("SocialUnsubscription")
					.Where("SocialUnsubscription", "SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
						.And("SocialUnsubscription", "EntityId").IsEqual(Column.Parameter(entityId)) as Select
				) as Select;
			var result = query.ExecuteScalar<int>();
			return (result != 0);
		}

		private void SetDefaultRights(SocialSubscription socialSubscription) {
			SetOwnerDefaultRights(socialSubscription);
			SetSubscriberDefaultRights(socialSubscription);
			DeleteSubscriberEditRight(socialSubscription);
			DeleteAuthorRights(socialSubscription);
		}

		private void SetEntitySchemaRecordRightLevel(Guid adminUnitId, string schemaName, Guid administratedRecordId,
				EntitySchemaRecordRightLevel rightLevel, bool useDenyRecordRights) {
			foreach (EntitySchemaRecordRightOperation operation in Enum.GetValues(typeof(EntitySchemaRecordRightOperation))) {
				DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, schemaName, administratedRecordId, operation, rightLevel, useDenyRecordRights);
			}
		}

		/// <summary>
		/// Sets up full rights for the owner of the feed.
		/// </summary>
		/// <param name="socialSubscription">The feed to which access rights are being given.</param>
		private void SetOwnerDefaultRights(SocialSubscription socialSubscription) {
			Guid socialSubscriptionId = socialSubscription.Id;
			Guid socialChannelOwnerId = GetSocialChannelOwnerId(socialSubscriptionId, socialSubscription.EntityId);
			if (socialChannelOwnerId.Equals(UserConnection.CurrentUser.ContactId)) {
				return;
			}
			if (socialChannelOwnerId.IsEmpty()) {
				return;
			}
			CoreEntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialSubscription");
			if (!schema.AdministratedByRecords) {
				return;
			}
			Guid ownerUserId = FindOwnerUserId(socialChannelOwnerId);
			if (ownerUserId.IsEmpty()) {
				return;
			}
			SetEntitySchemaRecordRightLevel(ownerUserId, schema.Name, socialSubscriptionId, EntitySchemaRecordRightLevel.AllowAndGrant, schema.UseDenyRecordRights);
		}

		private void SetSubscriberDefaultRights(SocialSubscription socialSubscription) {
			var sysAdminUnitId = socialSubscription.SysAdminUnitId;
			if (sysAdminUnitId.Equals(UserConnection.CurrentUser.Id)) {
				return;
			}
			var socialSubscriptionId = socialSubscription.Id;
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialSubscription");
			if (!schema.AdministratedByRecords) {
				return;
			}
			DBSecurityEngine.SetEntitySchemaRecordRightLevel(sysAdminUnitId, schema.Name, socialSubscriptionId,
				EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightLevel.AllowAndGrant, schema.UseDenyRecordRights);
			DBSecurityEngine.SetEntitySchemaRecordRightLevel(sysAdminUnitId, schema.Name, socialSubscriptionId,
				EntitySchemaRecordRightOperation.Delete, EntitySchemaRecordRightLevel.AllowAndGrant, schema.UseDenyRecordRights);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ChangeCanUnsubscribe(Guid[] socialSubscriptionIds, Guid channelId, bool canUnsubscribe) {
			try {
				InnerChangeCanUnsubscribe(socialSubscriptionIds, channelId, canUnsubscribe);
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteSubscription(Guid[] socialSubscriptionIds, Guid channelId) {
			try {
				CheckCanDelete(socialSubscriptionIds, channelId);
				foreach (var socialSubscriptionId in socialSubscriptionIds) {
					DeleteSubscription(socialSubscriptionId);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CheckCanUnsubscribe(object[] socialSubscriptionIds) {
			var socialSubscriptions = GetSocialSubscriptions(socialSubscriptionIds);
			try {
				foreach (SocialSubscription socialSubscription in socialSubscriptions) {
					InnerCheckCanUnsubscribe(socialSubscription);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetIsUserSubscribed(Guid entityId) {
			return InnerGetIsUserSubscribed(SysAdminUnitId, entityId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SubscribeUser(Guid entityId, Guid entitySchemaUId) {
			var response = new ConfigurationServiceResponse();
			try {
				InnerSubscribeUser(SysAdminUnitId, entityId, entitySchemaUId);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SubscribeContact(Guid contactId, Guid entityId, Guid entitySchemaUId) {
			var response = new ConfigurationServiceResponse();
			object[] contactIds = new object[] { contactId };
			CoreEntityCollection sysAdminUnits = GetSysAdminUnits(contactIds);
			try {
				foreach (SysAdminUnit sysAdminUnit in sysAdminUnits) {
					InnerSubscribeUser(sysAdminUnit.Id, entityId, entitySchemaUId);
					break;
				}
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SubscribeUsers(object[] contactIds, Guid entityId, Guid entitySchemaUId) {
			var sysAdminUnits = GetSysAdminUnits(contactIds);
			try {
				foreach (SysAdminUnit sysAdminUnit in sysAdminUnits) {
					InnerSubscribeUser(sysAdminUnit.Id, entityId, entitySchemaUId);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SubscribeUserGroups(Guid[] sysAdminUnitIds, Guid entityId, Guid entitySchemaUId) {
			try {
				if (sysAdminUnitIds.Length > 0) {
					foreach (Guid sysAdminUnitId in sysAdminUnitIds) {
						InnerSubscribeUser(sysAdminUnitId, entityId, entitySchemaUId);
					}
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UnsubscribeUser(Guid entityId) {
			return InnerUnsubscribeUser(SysAdminUnitId, entityId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UnsubscribeUsers(object[] socialSubscriptionIds) {
			var socialSubscriptions = GetSocialSubscriptions(socialSubscriptionIds);
			foreach (SocialSubscription socialSubscription in socialSubscriptions) {
				InnerUnsubscribeUser(socialSubscription.SysAdminUnitId, socialSubscription.EntityId);
			}
		}

		#endregion
	}
}

