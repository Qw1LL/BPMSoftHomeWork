namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
 
 	#region Class: Activity_BaseEventsProcess

	public partial class Activity_BaseEventsProcess<TEntity>
	{

		#region Methods: Private

		private bool GetIsColumnValueEmpty(string name) {
			return !Entity.GetIsColumnValueLoaded(name) || Entity.GetTypedColumnValue<Guid>(name).IsEmpty();
		}

		private bool GetIsOwnerNotAssigned() {
			return UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment") &&
				GetIsColumnValueEmpty("OwnerId");
		}

		#endregion

		#region Methods: Public

		public virtual Guid FindEmailSendStatusByCode(string emailSendStatusCode) {
			var emailSendStatusSchemaQuery =
				new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmailSendStatus") {
					UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic,
					Cache = UserConnection.ApplicationCache,
					CacheItemName = string.Format("EmailSendStatus_GetByCode_{0}", emailSendStatusCode)
				};
			emailSendStatusSchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			emailSendStatusSchemaQuery.AddColumn("Code");
			emailSendStatusSchemaQuery.Filters.Add(emailSendStatusSchemaQuery
				.CreateFilterWithParameters(FilterComparisonType.Equal, "Code", emailSendStatusCode));
			EntityCollection entityCollection = emailSendStatusSchemaQuery.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				return entityCollection[0].PrimaryColumnValue;
			}
			return Guid.Empty;
		}

		public virtual string FindActivityTypeCodeById(Guid activityTypeId) {
			string activityTypeCode = string.Empty;
			var activitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityType") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic,
				Cache = UserConnection.ApplicationCache,
				CacheItemName = $"ActivityType_GetCodeById_{activityTypeId}"
			};
			activitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			EntitySchemaQueryColumn codeQueryColumn = activitySchemaQuery.AddColumn("Code");
			Entity activityTypeEntity = activitySchemaQuery.GetEntity(UserConnection, activityTypeId);
			if (activityTypeEntity != null) {
				activityTypeCode = activityTypeEntity.GetTypedColumnValue<string>(codeQueryColumn.Name);
			}
			return activityTypeCode;
		}

		public virtual void SetEmailParticipants() {
			string senderEmail = SenderEmail;
			var recepientsEmails = (List<string>)RecepientsEmails;
			var copyRecepientsEmails = (List<string>)CopyRecepientsEmails;
			var blindCopyRecepientsEmails = (List<string>)BlindCopyRecepientsEmails;
			var recepientsEmailsForDelete = (List<string>)RecepientsEmailsForDelete;
			RemoveEmailParticipants();
			var emails = GetUsedEmails();
			if (emails.Count == 0) {
				return;
			}
			if (senderEmail == null) {
				senderEmail = GetSenderEmail();
			}
			var contacts = ContactUtilities.GetContactsByEmails(UserConnection, emails);
			Dictionary<string, Guid> participantRoles = new Dictionary<string, Guid>();
			Dictionary<Guid, string[]> rolesToEmailsResolverDictionary = new Dictionary<Guid, string[]>();
			if (contacts.Count > 0) {
				participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
				rolesToEmailsResolverDictionary.Add(participantRoles["To"], recepientsEmails.ToArray());
				rolesToEmailsResolverDictionary.Add(participantRoles["CC"], copyRecepientsEmails.ToArray());
				rolesToEmailsResolverDictionary.Add(participantRoles["From"], new string[] {senderEmail});
				rolesToEmailsResolverDictionary.Add(participantRoles["BCC"], blindCopyRecepientsEmails.ToArray());
			}
			foreach (KeyValuePair<Guid, string> contact in contacts) {
				string email = contact.Value;
				Guid contactId = contact.Key;
				foreach (var resolverValue in rolesToEmailsResolverDictionary) {
					if (resolverValue.Value.Contains(email, StringComparer.OrdinalIgnoreCase)) {
						AddActivityParticipantToInsertedValues(
							contactId,
							new Dictionary<string, object> {
									{"ReadMark", resolverValue.Key.Equals(participantRoles["From"])},
									{"RoleId", resolverValue.Key}
							},
							true
						);
					}
				}
			}
		}

		public virtual List<string> GetEmailsByFormatedEmails(string formatedEmails) {
			return formatedEmails.ParseEmailAddress();
		}

		public virtual List<string> GetRecepientsForAdding(List<string> newRecepientsEmails,
				List<string> oldRecepientsEmails) {
			var recepientsEmailForAdding = new List<string>();
			foreach(string email in newRecepientsEmails) {
				if (!oldRecepientsEmails.Contains(email)) {
					recepientsEmailForAdding.Add(email);
				}
			}
			return recepientsEmailForAdding;
		}

		public virtual List<string> GetRecepientsEmailsForDelete(List<string> newRecepientsEmails,
				List<string> oldRecepientsEmails) {
			var participantsEmailsForDelete = new List<string>();
			foreach (string email in oldRecepientsEmails){
				if (!newRecepientsEmails.Contains(email)) {
					participantsEmailsForDelete.Add(email);
				}
			}
			return participantsEmailsForDelete;
		}

		public virtual void RemoveEmailParticipants() {
			var recepientEmails = RecepientsEmailsForDelete as List<string>;
			if (recepientEmails?.Count > 0) {
				var queryParameters = recepientEmails.Select(item => new QueryParameter(item)).ToList();
				new Delete(UserConnection)
					.From("ActivityParticipant")
					.Where("ActivityId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue))
					.And("ParticipantId").In(
						new Select(UserConnection)
							.Column("Id")
							.From("Contact")
							.Where("Email").In(queryParameters)).Execute();
			}
		}

		public virtual void UpdateParticipantsByOwnerContact() {
			DeleteOldOwnerAndContactParticipants();
			Dictionary<string, Guid> participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
			if ((newOwnerId != oldOwnerId) && (newOwnerId != Guid.Empty) && (newOwnerId != SenderId)) {
				AddActivityParticipantToInsertedValues(
					newOwnerId,
					new Dictionary<string, object> {
						{"RoleId", participantRoles["Responsible"]}
					},
					true
				);
				if (oldOwnerId != Guid.Empty) {
					EntitySchemaColumn authorColumn = Entity.Schema.Columns.FindByName("Author");
					if (authorColumn != null) {
						var authorId = Entity.GetTypedColumnValue<Guid>(authorColumn.ColumnValueName);
						AddActivityParticipantToInsertedValues(
							authorId,
							new Dictionary<string, object> {
								{"RoleId", participantRoles["Participant"]}
							},
							false
						);
					}
				}
			}
			if ((newContactId != oldContactId) && (newContactId != Guid.Empty) && (newContactId != newOwnerId) &&
					(newContactId != SenderId)) {
				AddActivityParticipantToInsertedValues(
					newContactId,
					new Dictionary<string, object> {
						{"RoleId", participantRoles["Participant"]}
					},
					false
				);
			}
		}

		public virtual string GetSenderEmail() {
			EntitySchemaColumn senderColumn = Entity.Schema.Columns.FindByName("Sender");
			if (senderColumn != null) {
				string sender = Entity.GetTypedColumnValue<string>(senderColumn.ColumnValueName);
				string[] strSplit = sender.Split(new string[] {"<", "<"}, sender.Length, StringSplitOptions.None);
				string result = strSplit[1].Replace(">", "").Replace(">", "").Replace(" ", "");
				return result;
			}
			return null;
		}

		public virtual void SetParticipantSender() {
			if (Entity.MessageTypeId == ActivityConsts.OutgoingEmailTypeId) {
				EntitySchemaColumn senderColumn = Entity.Schema.Columns.FindByName("Sender");
				if (senderColumn == null) {
					return;
				}
				string sender = Entity.GetTypedColumnValue<string>(senderColumn.ColumnValueName);
				string[] strSplit = sender.Split(new string[] {"<", ">"}, sender.Length, StringSplitOptions.None);
				if (strSplit.Length == 0) {
					return;
				}
				string senderName = strSplit[0];
				Dictionary<string, Guid> participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
				EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
				var contactESQ = new EntitySchemaQuery(entitySchemaManager, "Contact") {
					UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic
				};
				contactESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
				contactESQ.Filters.Add(
					contactESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", senderName));
				EntitySchemaQueryColumn createdOn = contactESQ.AddColumn("CreatedOn");
				createdOn.OrderDirection = OrderDirection.Ascending;
				EntityCollection contactCollection = contactESQ.GetEntityCollection(UserConnection);
				if(contactCollection.Count > 0) {
					Entity contactEntity = contactCollection[0];
					AddActivityParticipantToInsertedValues(
						contactEntity.PrimaryColumnValue,
						new Dictionary<string, object> {
							{"RoleId", participantRoles["From"]}
						},
						false
					);
				}
			}
		}

		public virtual List<string> GetUsedEmails() {
			var emails = new List<string>() {SenderEmail};
			return Enumerable.Union(
				Enumerable.Union((IEnumerable<string>)emails, (IEnumerable<string>)RecepientsEmails),
				Enumerable.Union((IEnumerable<string>)CopyRecepientsEmails,
					(IEnumerable<string>)BlindCopyRecepientsEmails))
				.ToList();
		}

		public virtual void SetFromParticipantOnSent() {
			Dictionary<string, Guid> participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
			Guid contactId = UserConnection.CurrentUser.ContactId;
			AddActivityParticipantToInsertedValues(
				contactId,
				new Dictionary<string, object> {
					{"RoleId", participantRoles["From"]},
					{"ReadMark", true}
				},
				false
			);
		}

		public virtual void UpdateParticipantsByOwnerContactEmail() {
			DeleteOldOwnerAndContactParticipants();
			Dictionary<string, Guid> participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
			bool isOutgoing = Entity.MessageTypeId == ActivityConsts.OutgoingEmailTypeId;
			if (newOwnerId != Guid.Empty) {
				AddActivityParticipantToInsertedValues(
					newOwnerId,
					new Dictionary<string, object> {
						{"ReadMark", isOutgoing},
						{"RoleId", participantRoles["Responsible"]}
					},
					true
				);
				if ((newOwnerId != oldOwnerId) && (oldOwnerId != Guid.Empty)) {
					EntitySchemaColumn authorColumn = Entity.Schema.Columns.FindByName("Author");
					if (authorColumn != null) {
						Guid authorId = Entity.GetTypedColumnValue<Guid>(authorColumn.ColumnValueName);
						AddActivityParticipantToInsertedValues(
							authorId,
							new Dictionary<string, object> {
								{"RoleId", participantRoles["Participant"]}
							},
							false
						);
					}
				}
			}
			if (newContactId != Guid.Empty && (newContactId != SenderId || isOutgoing)) {
				AddActivityParticipantToInsertedValues(
					newContactId,
					new Dictionary<string, object>() {
						{"ReadMark", isOutgoing},
						{"RoleId", participantRoles["Participant"]}
					},
					false
				);
			}
		}

		public virtual void DeleteOldOwnerAndContactParticipants() {
			Dictionary<string, Guid> participantRoles = ActivityUtils.GetParticipantsRoles(UserConnection);
			if ((newOwnerId != oldOwnerId) && (oldOwnerId != Guid.Empty)) {
				var del = new Delete(UserConnection).From("ActivityParticipant")
					.Where("ActivityId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue)).
					And("ParticipantId").IsEqual(Column.Parameter(oldOwnerId)).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["To"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["CC"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["BCC"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["From"])) as Delete;
				del.Execute();
			}
			if ((newContactId != oldContactId) && (oldContactId != Guid.Empty) && (oldContactId != oldOwnerId)) {
				var del = new Delete(UserConnection).From("ActivityParticipant")
					.Where("ActivityId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue)).
					And("ParticipantId").IsEqual(Column.Parameter(oldContactId)).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["To"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["CC"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["BCC"])).
					And("RoleId").Not().IsEqual(Column.Parameter(participantRoles["From"])) as Delete;
				del.Execute();
			}
		}

		public virtual bool DoCollectEmailParticipants() {
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			return typeId == ActivityConsts.EmailTypeUId;
		}

		public virtual bool ActivityDeleting(ProcessExecutingContext  context) {
			return true;
		}

		public virtual void PrepereSynchronizeSubjectRemindingUserTask(SynchronizeSubjectRemindingUserTask userTask,
				Guid contact, DateTime remindTime, bool active, Guid source) {
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			var activityTypeQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityType") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic,
				Cache = UserConnection.ApplicationCache,
				CacheItemName = $"ActivityType_GetNameById_{typeId}"
			};
			activityTypeQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			EntitySchemaQueryColumn nameColumn = activityTypeQuery.AddColumn("Name");
			Entity activityTypeEntity = activityTypeQuery.GetEntity(UserConnection, typeId);
			if (activityTypeEntity != null) {
				userTask.TypeCaption = activityTypeEntity.GetTypedColumnValue<string>(nameColumn.Name);
			}
			bool isOwnerRoleAssignment = source == RemindingConsts.RemindingSourceOwnerId && GetIsOwnerNotAssigned();
			userTask.IsSubjectDelete = Entity.IsInDeleting || isOwnerRoleAssignment;
			userTask.Active = !Entity.IsInDeleting && !IsFinalStatus() && active && !isOwnerRoleAssignment;
			userTask.SubjectPrimaryColumnValue = Entity.PrimaryColumnValue;
			userTask.Contact = contact;
			userTask.Source = source;
			userTask.RemindTime = remindTime;
			userTask.SysEntitySchema = Entity.Schema.UId;
			userTask.Description = Entity.GetTypedColumnValue<string>("Title");
			userTask.NotificationType = RemindingConsts.NotificationTypeRemindingId;
		}

		public virtual bool IsFinalStatus() {
			Guid statusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityStatus") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic,
				Cache = UserConnection.ApplicationCache,
				CacheItemName = $"ActivityStatus_GetFinishById_{statusId}"
			};
			string finalColumnName = entitySchemaQuery.AddColumn("Finish").Name;
			Entity entity = entitySchemaQuery.GetEntity(UserConnection, statusId);
			if (entity != null) {
				return entity.GetTypedColumnValue<bool>(finalColumnName);
			}
			return false;
		}

		public virtual void SetActivityParticipantProcessPropertyValue(Entity activityParticipant,
				string propertyName, object value) {
			activityParticipant.Process.SetPropertyValue(propertyName, value);
		}

		public virtual void AddActivityParticipantToInsertedValues(Guid participantId,
				Dictionary<string, object> participantParams, bool overrideExistingParticipant) {
			var insertedValues = (InsertedValues as Dictionary<Guid, object>) ?? new Dictionary<Guid, object>();
			InsertedValues = insertedValues;
			if (overrideExistingParticipant || !insertedValues.ContainsKey(participantId)) {
				insertedValues[participantId] = participantParams;
			}
		}

		public virtual bool OnActivitySaved(ProcessExecutingContext context) {
			SetActivityParticipantRightsOnSaved();
			string typeColumnValueName = Entity.Schema.Columns.FindByName("Type").ColumnValueName;
			Guid typeId = Entity.GetTypedColumnValue<Guid>(typeColumnValueName);
			if (typeId == ActivityConsts.EmailTypeUId) {
				InitializeEmailParticipantHelper().InitializeParameters(Entity);
				AutoEmailRelationProceed();
				InitializeEmailParticipantHelper().SetEmailParticipants();
			} else {
				UpdateParticipantsByOwnerContact();
				SynchronizeActivityOnSaved();
				AutoEmailRelationProceed();
				CreateActivityParticipantsFromInsertedValues();
			}
			return true;
		}

		public virtual void SetActivityParticipantRightsOnSaved() {
			Guid author = Entity.GetTypedColumnValue<Guid>("AuthorId");
			Guid owner = Entity.GetTypedColumnValue<Guid>("OwnerId");
			IsDifferentContacts = !author.Equals(owner);
			if (Entity.GetTypedColumnValue<Guid>("EmailSendStatusId") != ActivityConsts.IncomingEmailTypeId) {
				return;
			}
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic
			};
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCommunication:Contact:Contact].Number", SenderEmail));
			EntityCollection entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				Guid adminUnitId = entities.First.Value.PrimaryColumnValue;
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema,
					Entity.PrimaryColumnValue, SchemaRecordRightLevels.All);
			}
			entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic
			};
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Contact", owner));
			entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				Guid adminUnitId = entities.First.Value.PrimaryColumnValue;
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema,
					Entity.PrimaryColumnValue, SchemaRecordRightLevels.All);
			}
		}

		public virtual void SynchronizeActivityOnSaved() {

			// TODO method for backward compatibility
		}

		public virtual bool OnActivitySaving(ProcessExecutingContext context) {
			SaveOldValuesOnSaving();
			SetRemindDatesOnSaving();
			CalculateDurationOnSaving();
			SavingEmailOnSaving();
			SetTypeByCategoryOnSaving();
			CheckNeedAutoEmailRelation();
			InitCanGenerateAnniversaryReminding();
			return true;
		}

		public virtual void SaveOldValuesOnSaving() {
			//####### ##### ### ######## #############
			if (InsertedValues == null) {
				InsertedValues = new Dictionary<Guid, object>();
			}
		}

		public virtual void CalculateDurationOnSaving() {
			TimeSpan duration = Entity.DueDate - Entity.StartDate;
			Entity.DurationInMinutes = (int)duration.TotalMinutes;
			Entity.DurationInMnutesAndHours = string.Concat((int)duration.TotalHours, Hour, duration.Minutes, Minute);
		}

		public virtual void SavingEmailOnSaving() {
			string ownerIdColumnName = Entity.Schema.Columns.GetByName("Owner").ColumnValueName;
			string contactIdColumnName = Entity.Schema.Columns.GetByName("Contact").ColumnValueName;
			object ownerIdOldValue = Entity.GetColumnOldValue(ownerIdColumnName);
			if (ownerIdOldValue != null) {
				oldOwnerId = new Guid(ownerIdOldValue.ToString());
			}
			object contactIdOldValue = Entity.GetColumnOldValue(contactIdColumnName);
			if (contactIdOldValue != null) {
				oldContactId = new Guid(contactIdOldValue.ToString());
			}
			if (Entity.GetIsColumnValueLoaded(ownerIdColumnName)) {
				newOwnerId = Entity.GetTypedColumnValue<Guid>(ownerIdColumnName);
			}
			if (Entity.GetIsColumnValueLoaded(contactIdColumnName)) {
				newContactId = Entity.GetTypedColumnValue<Guid>(contactIdColumnName);
			}
			if (!DoCollectEmailParticipants()) {
				return;
			}
			InitializeEmailParticipantHelper().InitializeParameters(Entity);
			string body = (string)Entity.GetColumnValue("Body");
			Entity.SetColumnValue("Preview", StringUtilities.GetPlainTextFromHtml(body, 245));
			if (Entity.GetColumnValue("SendDate") != null) {
				string hash = Entity.GetTypedColumnValue<string>("MailHash");
				if (string.IsNullOrEmpty(hash)) {
					string title = (string)Entity.GetColumnValue("Title");
					DateTime sendDate = (DateTime)Entity.GetColumnValue("SendDate");
					hash = ActivityUtils.GetEmailHash(UserConnection, (string)Entity.GetColumnValue("Sender"), sendDate, title, body,
						UserConnection.CurrentUser.TimeZone);
					Entity.SetColumnValue("MailHash", hash);
				}
			}
			EmailRightsManager rightsManager = GetEmailRightsManager();
			rightsManager.SetUseDefRights(Entity);
		}

		public virtual void SetTypeByCategoryOnSaving() {
			if (Entity.GetTypedColumnValue<Guid>("TypeId") == Guid.Empty) {
				Guid categoryId = Entity.GetTypedColumnValue<Guid>("ActivityCategoryId");
				var schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityCategory") {
					UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic,
					Cache = UserConnection.ApplicationCache,
					CacheItemName = $"ActivityCategory_GetActivityTypeById_{categoryId}"
				};
				EntitySchemaQueryColumn typeColumn = schemaQuery.AddColumn("ActivityType.Id");
				Entity category = schemaQuery.GetEntity(UserConnection, categoryId);
				Entity.SetColumnValue("TypeId", category.GetTypedColumnValue<Guid>(typeColumn.Name));
			};
		}

		public virtual bool OnActivityInserting(ProcessExecutingContext context) {
			string activityTypeColumnName = Entity.Schema.Columns.GetByName("Type").ColumnValueName;
			Guid activityTypeId = Entity.GetTypedColumnValue<Guid>(activityTypeColumnName);
			string activityTypeCode = FindActivityTypeCodeById(activityTypeId);
			if (activityTypeCode == "Email") {
				if (Entity.EmailSendStatusId.IsEmpty()) {
					Guid notSendStatusId = FindEmailSendStatusByCode("NotSend");
					Entity.EmailSendStatusId = notSendStatusId;
				}
				Entity.SetColumnValue("IsNeedProcess", true);
			}
			InitializeEmailParticipantHelper().InitializeParameters(Entity);
			InitializeEmailParticipantHelper().IsNew = true;
			IsNew = true;
			return true;
		}

		public virtual void CreateActivityParticipantsFromInsertedValues() {
			var insertedValues = InsertedValues as Dictionary<Guid, object>;
			foreach(var kvp in insertedValues) {
				if (kvp.Value is Dictionary<string, object> participantParams) {
					EntitySchema activityParticipantSchema =
						UserConnection.EntitySchemaManager.GetInstanceByName("ActivityParticipant");
					Entity activityParticipant = activityParticipantSchema.CreateEntity(UserConnection);
					activityParticipant.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
					activityParticipant.SetDefColumnValues();
					activityParticipant.SetColumnValue("ActivityId", Entity.PrimaryColumnValue);
					activityParticipant.SetColumnValue("ParticipantId", kvp.Key);
					foreach(var parameter in participantParams) {
						activityParticipant.SetColumnValue(parameter.Key, parameter.Value);
					}
					if (IsNew) {
						SetActivityParticipantProcessPropertyValue(activityParticipant, "IsUnique", true);
					}
					activityParticipant.Save();
				}
			}
		}

		public virtual bool OnActivityInserted(ProcessExecutingContext context) {
			EmailRightsManager rightsManager = GetEmailRightsManager();
			rightsManager.SetAuthorRights(Entity);
			string typeColumnValueName = Entity.Schema.Columns.FindByName("Type").ColumnValueName;
			Guid typeId = Entity.GetTypedColumnValue<Guid>(typeColumnValueName);
			if (typeId == ActivityConsts.EmailTypeUId && Entity.GetColumnValue("SendDate") == null) {
				EmailMessageHelper helper =
					ClassFactory.Get<EmailMessageHelper>(new ConstructorArgument("userConnection", UserConnection));
				helper.CreateEmailMessage(Entity, Guid.Empty);
			}
			return true;
		}

		public virtual void SetEmailIsNeedProcess() {
			Guid id = Entity.GetTypedColumnValue<Guid>("Id");
			bool contactIsEmpty = Guid.Empty == Entity.GetTypedColumnValue<Guid>("Contact");
			bool accountIsEmpty = Guid.Empty == Entity.GetTypedColumnValue<Guid>("Account");
			bool thirdPartEntitiesIsEmpty = true;
			Guid schemaUId = Entity.InstanceUId;
			var esq = new EntitySchemaQuery(Entity.EntitySchemaManager, "EntityConnection") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic
			};
			string columnUIdName = esq.AddColumn("ColumnUId").Name;
			esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysEntitySchemaUId", schemaUId);
			EntityCollection activityConnections = esq.GetEntityCollection(UserConnection);
			foreach (Entity activityConnection in activityConnections) {
				EntitySchemaColumn columnName =
					Entity.Schema.Columns.GetByUId(activityConnection.GetTypedColumnValue<Guid>(columnUIdName));
				if (Entity.GetTypedColumnValue<Guid>(columnName) != Guid.Empty) {
					thirdPartEntitiesIsEmpty = false;
				}
			}
			Update update = (Update)new Update(UserConnection, "Activity").Where("Id").IsEqual(Column.Parameter(id));
			bool needUpdate = false;
			if (contactIsEmpty && accountIsEmpty) {
				update.Set("IsNeedProcess", Column.Parameter(true));
				needUpdate = true;
			}
			if (!contactIsEmpty && !accountIsEmpty && thirdPartEntitiesIsEmpty) {
				update.Set("IsNeedProcess", Column.Parameter(true));
				needUpdate = true;
			}
			if (needUpdate) {
				update.Execute();
			}
		}

		public virtual void AutoEmailRelationProceed() {
			if (IsNeedAutoEmailRelation) {
				var autoEmailRelation = new BPMSoft.Configuration.AutoEmailRelation.AutoEmailRelation(UserConnection);
				autoEmailRelation.ProceedRelation(Entity);
			}
		}

		public virtual void CheckNeedAutoEmailRelation() {
			if (Entity.GetTypedColumnValue<Guid>("TypeId") != ActivityConsts.EmailTypeUId) {
				return;
			}
			IsNeedAutoEmailRelation = false;
			string titleValue = Entity.GetTypedColumnValue<string>("Title");
			string titleOldValue = Entity.GetTypedOldColumnValue<string>("Title");
			if (titleValue != titleOldValue) {
				IsNeedAutoEmailRelation = true;
				return;
			}
			string senderValue = Entity.GetTypedColumnValue<string>("Sender");
			string senderOldValue = Entity.GetTypedOldColumnValue<string>("Sender");
			if (senderValue != senderOldValue) {
				IsNeedAutoEmailRelation = true;
				return;
			}
			string recepientValue = Entity.GetTypedColumnValue<string>("Recepient");
			string recepientcOldValue = Entity.GetTypedOldColumnValue<string>("Recepient");
			if (recepientValue != recepientcOldValue) {
				IsNeedAutoEmailRelation = true;
				return;
			}
			string copyRecepientValue = Entity.GetTypedColumnValue<string>("CopyRecepient");
			string copyRecepientOldValue = Entity.GetTypedOldColumnValue<string>("CopyRecepient");
			if (copyRecepientValue != copyRecepientOldValue) {
				IsNeedAutoEmailRelation = true;
				return;
			}
			string blindCopyRecepientValue = Entity.GetTypedColumnValue<string>("BlindCopyRecepient");
			string blindCopyRecepientOldValue = Entity.GetTypedOldColumnValue<string>("BlindCopyRecepient");
			if (blindCopyRecepientValue != blindCopyRecepientOldValue) {
				IsNeedAutoEmailRelation = true;
				return;
			}
		}

		public virtual EmailParticipantHelper InitializeEmailParticipantHelper() {
			EmailParticipantHelper = EmailParticipantHelper ??
				ClassFactory.Get<EmailParticipantHelper>(new ConstructorArgument("userConnection", UserConnection));
			return (EmailParticipantHelper)EmailParticipantHelper;
		}

		public virtual void SetRemindDatesOnSaving() {
			var newStartDate = Entity.GetTypedColumnValue<DateTime>("StartDate");
			var oldStartDate = Entity.GetTypedOldColumnValue<DateTime>("StartDate");
			if(!oldStartDate.Equals(DateTime.MinValue) && !newStartDate.Equals(oldStartDate)) {
				var dateDiff = newStartDate.Subtract(oldStartDate);
				var hasAuthorRemind = Entity.GetTypedColumnValue<bool>("RemindToAuthor");
				var hasOwnerRemind = Entity.GetTypedColumnValue<bool>("RemindToOwner");
				if (hasAuthorRemind) {
					var authorRemindDate = Entity.GetTypedColumnValue<DateTime>("RemindToAuthorDate");
					var oldAuthorRemindDate = Entity.GetTypedOldColumnValue<DateTime>("RemindToAuthorDate");
					if (authorRemindDate.Equals(oldAuthorRemindDate) && authorRemindDate > DateTime.MinValue) {
						authorRemindDate = authorRemindDate.Add(dateDiff);
						Entity.SetColumnValue("RemindToAuthorDate", authorRemindDate);
					}
				}
				if (hasOwnerRemind) {
					var ownerRemindDate = Entity.GetTypedColumnValue<DateTime>("RemindToOwnerDate");
					var oldOwnerRemindDate = Entity.GetTypedOldColumnValue<DateTime>("RemindToOwnerDate");
					if (ownerRemindDate.Equals(oldOwnerRemindDate) && ownerRemindDate > DateTime.MinValue) {
						ownerRemindDate = ownerRemindDate.Add(dateDiff);
						Entity.SetColumnValue("RemindToOwnerDate", ownerRemindDate);
					}
				}
			};
		}

		public virtual void OnActivityUpdated_aa5f074ac858455d865435cc7584e9ca(ProcessExecutingContext context) {
			UserConnection.IProcessEngine.SynchronizeProcessNotification(Entity, context);
		}

		public virtual EmailRightsManager GetEmailRightsManager() {
			return ClassFactory.Get<EmailRightsManager>(new ConstructorArgument("userConnection", UserConnection));
		}

		public virtual void InitCanGenerateAnniversaryReminding() {
			bool isContactNotEmpty = Entity.GetTypedColumnValue<Guid>("ContactId").IsNotEmpty();
			bool isAccountNotEmpty = Entity.GetTypedColumnValue<Guid>("AccountId").IsNotEmpty();
			var columns = GetAnniversaryDependentColumns();
			var changedColumns = Entity.GetChangedColumnValues();
			EntityChangedColumns = changedColumns.ToList();
			bool anniversaryColumnsChanged = changedColumns.Any(col => columns.Contains(col.Name));
			CanGenerateAnniversaryReminding = (isContactNotEmpty || isAccountNotEmpty) && anniversaryColumnsChanged;
		}

		public virtual IEnumerable<string> GetAnniversaryDependentColumns() {
			return  new[] { "ContactId", "AccountId", "OwnerId" };
		}

		public virtual IEnumerable<string> GetRemindingOptions() {
			var options = new List<string>();
			var changedColumns = EntityChangedColumns as List<EntityColumnValue> ?? new List<EntityColumnValue>();
			if (changedColumns.Any(col => col.Name == "OwnerId")) {
				options.AddRange(new[] {
					ActivityAnniversaryReminding.AccountOption,
					ActivityAnniversaryReminding.ContactOption,
					ActivityAnniversaryReminding.ParticipantOption
				});
				return options;
			}
			if (changedColumns.Any(col => col.Name == "ContactId")) {
				options.Add(ActivityAnniversaryReminding.ContactOption);
			}
			if (changedColumns.Any(col => col.Name == "AccountId")) {
				options.Add(ActivityAnniversaryReminding.AccountOption);
			}
			return options;
		}

		public virtual void GenerateRemindings() {
			if (!CanGenerateAnniversaryReminding) {
				return;
			}
			Guid id = Entity.GetTypedColumnValue<Guid>("Id");
			if (Entity.GetTypedColumnValue<Guid>("TypeId") != ActivityConsts.EmailTypeUId) {
				ActivityAnniversaryReminding remindingsGenerator =
					new ActivityAnniversaryReminding(UserConnection, id) {
						Options = GetRemindingOptions()
					};
				remindingsGenerator.GenerateActualRemindings();
			}
		}

		public virtual void OnActivityValidating(ProcessExecutingContext context) {
			EntityValidationEventArgs eventArgs = (EntityValidationEventArgs)context.ThrowEventArgs;
			if (!GetIsColumnValueEmpty("OwnerId")) {
				return;
			}
			if (!UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				EntitySchemaColumn ownerColumn = Entity.Schema.Columns.FindByName("Owner");
				eventArgs.Messages.Add(new EntityValidationMessage {
					Text = OwnerIsEmptyErrorMessage,
					Column = ownerColumn
				});
				return;
			}
			if (GetIsColumnValueEmpty("OwnerRoleId")) {
				eventArgs.Messages.Add(new EntityValidationMessage {
					Text = OwnerAndOwnerRoleAreEmptyErrorMessage
				});
			}
		}

		#endregion

	}

	#endregion

}
