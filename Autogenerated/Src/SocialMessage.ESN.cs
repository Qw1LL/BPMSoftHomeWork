namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Security;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ESN;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Configuration.ESN;

	#region Class: SocialMessage_ESNEventsProcess

	public partial class SocialMessage_ESNEventsProcess<TEntity>
	{
		
		#region Properties: Private

		private ISocialMentionExecutor _socialMentionExecutor;
		private ISocialMentionExecutor SocialMentionExecutor => _socialMentionExecutor ?? (
			_socialMentionExecutor = ClassFactory.Get<SocialMentionExecutor>(
				new ConstructorArgument("userConnection", UserConnection))
			);
		
		#endregion

		#region Methods: Public

		public virtual void SendUpdateDeleteSocialMessage(string operation) {
			if (GetIsComment()) {
				return;
			}
			SimpleMessage simpleMessage = CreateSimpleMessage(operation);
			List<Guid> subscriptors = GetSubscriptors();
			MsgChannelManager manager = MsgChannelManager.Instance;
			manager.Post(subscriptors, simpleMessage);
		}

		public virtual SimpleMessage CreateSimpleMessage(string operation) {
			var socialMessageId = Entity.GetTypedColumnValue<Guid>("Id");
			var sysAdminUnitId = UserConnection.CurrentUser.Id;
			var entityId = Entity.GetTypedColumnValue<Guid>("EntityId");
			return new SimpleMessage {
				Id = socialMessageId,
				Header = {
					Sender = "UpdateSocialMessage"
				},
				Body = string.Format("{{ \"sysAdminUnitId\": \"{0}\", \"channelId\": \"{1}\", \"operation\": \"{2}\"}}",
					sysAdminUnitId, entityId, operation)
			};
		}

		public virtual bool GetIsComment() {
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			return parentId.IsNotEmpty();
		}

		public virtual List<Guid> GetSubscriptors() {
			var channelId = Entity.GetTypedColumnValue<Guid>("EntityId");
			List<Guid> channelSubscriptors = new List<Guid>();
			string roleSubscriptionTable = "SocialSubscription";
			string roleSubscriptionColumnPath = "=[SysUserInRole:SysRole:SysAdminUnit].SysUser.Id";
			List<Guid> roleSubscriptors = GetChannelSubscriptors(channelId, roleSubscriptionTable, roleSubscriptionColumnPath);
			string userSubscriptionTable = "SocialSubscription";
			string userSubscriptionColumnPath = "=[SysUserInRole:SysUser:SysAdminUnit].SysUser.Id";
			List<Guid> userSubscriptors = GetChannelSubscriptors(channelId, userSubscriptionTable, userSubscriptionColumnPath);
			string userUnsubscriptionTable = "SocialUnsubscription";
			string userUnsubscriptionColumnPath = "=[SysUserInRole:SysUser:SysAdminUnit].SysUser.Id";
			List<Guid> userUnsubscriptors = GetChannelSubscriptors(channelId, userUnsubscriptionTable, userUnsubscriptionColumnPath);
			channelSubscriptors.AddRange(roleSubscriptors);
			channelSubscriptors.AddRange(userSubscriptors);
			channelSubscriptors.RemoveAll(subscriptor => userUnsubscriptors.Contains(subscriptor));
			return channelSubscriptors;
		}

		public virtual List<Guid> GetChannelSubscriptors(Guid channelId, string subscriptionTable, string columnPath) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, subscriptionTable) {
				UseAdminRights = false
			};
			var column = esq.AddColumn(columnPath);
			var currentChannelFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", channelId);
			esq.Filters.Add(currentChannelFilter);
			EntityCollection channelSubscriptors = esq.GetEntityCollection(UserConnection);
			var list = new List<Guid>();
			foreach (var subscriptor in channelSubscriptors) {
				list.Add(subscriptor.GetTypedColumnValue<Guid>(column.Name));
			}
			return list;
		}

		public virtual bool IsAllAllowedChannelPost(Guid channelId) {
			Select select = new Select(UserConnection)
				.Column("PublisherRightKind")
				.From("SocialChannel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		public virtual Guid GetParentEntitySchemaUId(Guid parentId) {
			Select select = new Select(UserConnection)
					.Column("EntitySchemaUId")
					.From("SocialMessage")
					.Where("Id").IsEqual(Column.Parameter(parentId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		public virtual Guid GetEntitySchemaUId() {
			Guid entitySchemaUId = Entity.GetTypedColumnValue<Guid>("EntitySchemaUId");
			if (entitySchemaUId.IsEmpty()) {
				entitySchemaUId = GetParentEntitySchemaUId(Entity.GetTypedColumnValue<Guid>("ParentId"));
			}
			return entitySchemaUId;
		}

		public virtual string GetTargetSchemaName() {
			Guid entitySchemaUId = GetEntitySchemaUId();
			EntitySchema currentEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			string targetSchemaName = currentEntitySchema.Name;
			return targetSchemaName;
		}

		public virtual void CheckSchemaRecordRightLevels(string targetSchemaName, Guid recordId) {
			SchemaRecordRightLevels canEditRight = SchemaRecordRightLevels.CanEdit;
			SchemaRecordRightLevels schemaRightLevel = UserConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(targetSchemaName, recordId);
			if ((schemaRightLevel & canEditRight) != canEditRight) {
				throw new SecurityException(string.Format(new LocalizableString("BPMSoft.Core",
						"DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"), targetSchemaName));
			}
		}

		public virtual void CheckInsertRights() {
			Guid recordId = Entity.GetTypedColumnValue<Guid>("EntityId");
			string targetSchemaName = GetTargetSchemaName();
			if (recordId.IsNotEmpty() && targetSchemaName == "SocialChannel") {
				if (IsAllAllowedChannelPost(recordId)) {
					return;
				}
				else {
					CheckSchemaRecordRightLevels(targetSchemaName, recordId);
				}
			}
		}

		public virtual Dictionary<Guid,Guid> GetConnectedNotifications(Guid socialMessageId) {
			EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ESNNotification");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var sysAdminUnitIdColumn = esq.AddColumn("[SysAdminUnit:Contact:Owner].Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SocialMessage", socialMessageId));
			return esq.GetEntityCollection(UserConnection).ToDictionary(e=>e.PrimaryColumnValue, 
				e=>e.GetTypedColumnValue<Guid>(sysAdminUnitIdColumn.Name));
		}

		public virtual void PublishDeleteNotificationsMessage() {
			var manager = MsgChannelManager.Instance;
			Dictionary<Guid, Guid> notificationsByOwner = GetConnectedNotifications(Entity.PrimaryColumnValue);
			foreach (var notification in notificationsByOwner) {
				Guid recordId = notification.Key;
				Guid recordOwnerSysAdminUnitId = notification.Value;
				var channel = manager.FindItemByUId(recordOwnerSysAdminUnitId);
				if (channel == null) {
					continue;
				}
				var message = new {
					recordId = recordId,
					notificationGroup = NotificationGroupConst.ESNNotification,
					operation = "delete",
				};
				var simpleMessage = new SimpleMessage {
					Body = JsonConvert.SerializeObject(message),
					Id = recordOwnerSysAdminUnitId,
					Header = {
						Sender = "UpdateReminding"
					}
				};
				channel.PostMessage(simpleMessage);
			}
		}

		public virtual bool IsURLValid(string url) {
			Uri uriResult;
			return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}

		public virtual string StripHtmlTags(string text) {
			return Regex.Replace(text, "\\<[^\\>]*\\>", String.Empty);
		}

		public virtual void DeleteLinkPreviewInfo() {
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
			linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
		}

		public virtual void DeleteLinkPreviewInfoIfUpdated() {
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			string oldMessage = (string)Entity.GetColumnOldValue("Message");
			oldMessage = StripHtmlTags(oldMessage).Trim();
			if (IsURLValid(oldMessage)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public virtual void AddLinkPreviewInfo() {
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			var message = Entity.GetTypedColumnValue<string>("Message");
			message = StripHtmlTags(message).Trim();
			if (IsURLValid(message)) {
				LinkPreview linkPreview = new LinkPreview();
				LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(message);
				if (linkPreviewInfo != null) {
					LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
					linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
				}
			}
		}
		
		public virtual void MentionUsers() {
			if (UserConnection.GetIsFeatureEnabled("AddSocialMentionOnUI")) {
				return;
			}
			var message = Entity.GetTypedColumnValue<string>("Message");
			var messageId = Entity.GetTypedColumnValue<Guid>("Id");
			SocialMentionExecutor.MentionContacts(messageId, message);
		}

		#endregion

	}

	#endregion

}

