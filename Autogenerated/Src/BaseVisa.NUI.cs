namespace BPMSoft.Configuration
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.Mail.Sender;

	#region Class: BaseVisa_NUIEventsProcess

	public partial class BaseVisa_NUIEventsProcess<TEntity>
	{
		
		#region Constants: Private

		private static readonly ILog _log = LogManager.GetLogger("BaseVisa_NUIEventsProcess");

		#endregion
		
		#region: Properties: Private

		private Guid MobileApplicationOnlineModeId = new Guid("623DC2DB-31B8-4D3A-BC9A-8B9E8FB66E82");

		#endregion

		#region: Methods: Private

		private bool IsUser(Guid sysAdminUnitId) {
			var sysAdminUnitSelect = new Select(UserConnection).Column("SAU", "Id")
				.From("SysAdminUnit").As("SAU")
				.Where("Id").IsEqual(Column.Parameter(sysAdminUnitId))
				.And()
				.OpenBlock("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)BPMSoft.Core.DB.SysAdminUnitType.User))
				.Or("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)BPMSoft.Core.DB.SysAdminUnitType.SelfServicePortalUser))
				.CloseBlock() as Select;
			return sysAdminUnitSelect.ExecuteScalar<Guid>().IsNotEmpty();
		}

		private bool IsMobileApplicationModeOnline() {
			Guid mobileApplicationModeId =
				(Guid)Core.Configuration.SysSettings.GetValue(UserConnection.AppConnection.SystemUserConnection, 
					Entity.VisaOwnerId, "MobileApplicationMode");
			return MobileApplicationOnlineModeId.Equals(mobileApplicationModeId);
		}

		private void SendPushNotification() {
			var referenceEntity = GetFetchedReferenceEntity();
			if (referenceEntity == null) {
				return;
			}
			var sysAdminUnitId = Entity.VisaOwnerId;
			string cultureName = GetUserCultureName(sysAdminUnitId);
			string title = GetLocalizableValue(PopupTitleTemplate, cultureName);
			string body = GetPushNotificationBody(referenceEntity, cultureName);
			var referenceEntityId = referenceEntity.PrimaryColumnValue;
			string entityName = referenceEntity.SchemaName;
			Dictionary<string, string> additionalData = new Dictionary<string, string>();
			additionalData.Add("entityName", entityName);
			additionalData.Add("recordId", referenceEntityId.ToString());
			additionalData.Add("visaEntityName", Entity.SchemaName);
			additionalData.Add("visaRecordId", Entity.PrimaryColumnValue.ToString());
			var pushNotification = new PushNotification(UserConnection);
			try {
				pushNotification.Send(sysAdminUnitId, title, body, additionalData);
			} catch (Exception ex) {
				_log.Error(ex);
			}
		}

		private string GetUserCultureName(Guid sysAdminUnitId) {
			var userEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var cultureColumn = userEsq.AddColumn("SysCulture.Name");
			var idFilter = userEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", sysAdminUnitId);
			userEsq.Filters.Add(idFilter);
			var userCollection = userEsq.GetEntityCollection(UserConnection);
			if (userCollection.Count > 0) {
				return userCollection[0].GetTypedColumnValue<string>(cultureColumn.Name);
			} else {
				return UserConnection.CurrentUser.Culture.Name;
			}
		}

		private string GetLocalizableValue(LocalizableString localizableString, string cultureName) {
			var culture = CultureInfo.GetCultureInfo(cultureName);
			return localizableString.GetCultureValueWithFallback(culture, false);
		}

		private string GetPushNotificationBody(Entity referenceEntity, string cultureName) {
			string schemaCaption = GetLocalizableValue(referenceEntity.Schema.Caption, cultureName);
			var entityDisplayValue = referenceEntity.PrimaryDisplayColumnValue;
			if (entityDisplayValue.IsNotNullOrWhiteSpace()) {
				entityDisplayValue = $", {entityDisplayValue}";
			}
			string defaultBody = string.Format(PopupBodyDefaultTemplate, schemaCaption, entityDisplayValue);
			var objective = Entity.Objective;
			if (objective.IsNotNullOrWhiteSpace()) {
				objective = $", {objective}";
			}
			return defaultBody + objective;
		}

		#endregion

		#region Methods: Public

		public virtual void SendEmail(Dictionary<Guid, string> recepients) {
			object useEmails;
			if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, "SendVisaEmail", out useEmails)) {
				if (useEmails is bool && !((bool)useEmails)) {
					return;
				}
			}
			var tempalteId = GetEmailTemplateId();
			if (tempalteId == Guid.Empty) {
				return;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmailTemplate");
			esq.AddColumn("Subject");
			esq.AddColumn("Body");
			esq.AddColumn("IsHtmlBody");
			esq.AddColumn("Macros");
			var template = (BPMSoft.Configuration.EmailTemplate)esq.GetEntity(UserConnection, tempalteId);
			if (template == null) {
				return;
			}
			var credentials = new MailCredentials();
			credentials.Host = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpHost");
			credentials.Port = int.Parse(BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpPort").ToString());
			credentials.UseSsl = (bool)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpEnableSsl");
			credentials.UserName = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpUserName");
			credentials.UserPassword = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpUserPassword");
			if (string.IsNullOrEmpty(credentials.Host) || string.IsNullOrEmpty(credentials.UserName)) {
				return;
			}
			foreach (var recepient in recepients) {
				if (string.IsNullOrEmpty(recepient.Value)) {
					continue;
				}
				var priorityId = Guid.Parse("ab96fa02-7fe6-df11-971b-001d60e938c6");
				var body = ProcessEmailBody(template.Body, recepient.Key, template.GetBytesValue("Macros"));
				var attachments = EmailTemplateUtility.GetEmailTemplateAttachments(UserConnection, tempalteId);
				var emailMessage = new EmailMessage {
					From = credentials.UserName,
					To = new List<string> { recepient.Value },
					Subject = template.Subject,
					Body = body,
					Priority = EmailPriorityConverter.GetEmailPriority(priorityId),
					IsHtmlBody = template.IsHtmlBody,
					Attachments = attachments,
				};
				try {
					var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
					IEmailSender emailSender = ClassFactory.Get<IEmailSender>(
						new ConstructorArgument("emailClientFactory", emailClientFactory),
						new ConstructorArgument("userConnection", UserConnection));
					emailSender.Send(emailMessage, credentials);
				} catch (SmtpException e) {
					// TODO: log exception
				}
			}
		}

		public virtual Dictionary<Guid, string> GetGroupContacts(Guid sysAdminUnitId) {
			Dictionary<Guid, string> emails = new Dictionary<Guid, string>();
			Select manhourHierarchicalSelect = new Select(UserConnection)
				.Column("SysAdminUnit", "Id").As("Id")
				.Column("Contact", "Id").As("ContactId")
				.Column("Contact", "Email").As("Email")
				.Column("Contact2", "Id").As("BaseContactId")
				.Column("Contact2", "Email").As("BaseEmail")
				.Column("SysAdminUnit", "ParentRoleId").As("ParentRoleId")
				.From("SysAdminUnit")
				.LeftOuterJoin("Contact").As("Contact2").On("Contact2", "Id").IsEqual("SysAdminUnit", "ContactId")
				.LeftOuterJoin("SysUserInRole").On("SysUserInRole", "SysRoleId").IsEqual("SysAdminUnit", "Id")
				.LeftOuterJoin("SysAdminUnit").As("SysAdminUnit2").On("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit2", "Id")
				.LeftOuterJoin("Contact").On("Contact", "Id").IsEqual("SysAdminUnit2", "ContactId") as Select;
			HierarchicalSelectOptions options = new HierarchicalSelectOptions() {
							PrimaryColumnName = "Id",
							ParentColumnName = "ParentRoleId",
							SelectType = HierarchicalSelectType.Children,
							IncludeLevelColumn = true,
							IsDistinct = true
						};
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.IsEqual(Column.Parameter(sysAdminUnitId, "ParentRoleId", BPMSoft.Common.ParameterDirection.Input));
			manhourHierarchicalSelect.HierarchicalOptions = options;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = manhourHierarchicalSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						if (!reader.IsDBNull(1)){
							var contactId = UserConnection.DBTypeConverter.DBValueToGuid(reader[1]);
							var email = reader[2].ToString();
							if (!string.IsNullOrEmpty(email) && !emails.ContainsKey(contactId)) {
								emails.Add(contactId, email);
							}
						}
						if (!reader.IsDBNull(3)){
							var contactId = UserConnection.DBTypeConverter.DBValueToGuid(reader[3]);
							var email = reader[4].ToString();
							if (!string.IsNullOrEmpty(email) && !emails.ContainsKey(contactId)) {
								emails.Add(contactId, email);
							}
						}
					}
				}
			}
			
			return emails;
		}

		public virtual Guid GetSchemaTypeColumnUId(Guid schemaUId) {
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEntity");
			var primaryColumnName = entitySchemaQuery.AddColumn(entitySchemaQuery.RootSchema.GetPrimaryColumnName()).Name;
			var typeColumnIdName = entitySchemaQuery.AddColumn("TypeColumnUId").Name;
			
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
			"SysEntitySchemaUId", new object[]{schemaUId}));
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			
			
			var typeColumnUId = Guid.Empty;
			if (entityCollection.Count > 0) {
				var entity = entityCollection[0];
				typeColumnUId = entity.GetTypedColumnValue<Guid>(typeColumnIdName);
				SysModuleEntityId = entity.GetTypedColumnValue<Guid>(primaryColumnName);
			}
			return typeColumnUId;
		}

		public virtual Guid GetSchemaTypeColumnValue(string referenceSchemaName, string typeColumnName, Guid primaryColumnValue) {
			var typeColumnValue = Guid.Empty;
			
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, referenceSchemaName);
			var typeColumn = entitySchemaQuery.AddColumn(typeColumnName);
			
			var entity = entitySchemaQuery.GetEntity(UserConnection, primaryColumnValue);
			if (entity != null) {
				typeColumnValue = entity.GetTypedColumnValue<Guid>(typeColumn.Name);
			}
			return typeColumnValue;
		}

		public virtual Guid GetCardSchemaUId(Guid typeColumnValue, Guid sysModuleEntityId) {
			var cardSchemaUId = Guid.Empty;
			
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEdit");
			var typeColumn = entitySchemaQuery.AddColumn("CardSchemaUId");
			
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
			"SysModuleEntity", new object[]{sysModuleEntityId}));
			
			if (!typeColumnValue.Equals(Guid.Empty)) {
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"TypeColumnValue", new object[]{typeColumnValue}));
			};
			
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			
			if (entityCollection.Count > 0) {
				var entity = entityCollection[0];
				cardSchemaUId = entity.GetTypedColumnValue<Guid>(typeColumn.Name);
			}
			return cardSchemaUId;
			
			
			
		}

		public virtual string GetCardSchemaName(Guid cardSchemaUId) {
			var cardSchemaName  = string.Empty;
			
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysSchema");
			var typeColumn = entitySchemaQuery.AddColumn("Name");
			
			entitySchemaQuery.IsDistinct = true;
			
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
			"UId", new object[]{cardSchemaUId}));
			
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			
			if (entityCollection.Count > 0) {
				var entity = entityCollection[0];
				cardSchemaName = entity.GetTypedColumnValue<string>(typeColumn.Name);
			}
			
			return cardSchemaName;
		}

		public virtual void SetRight(Guid adminUnitId, int operation, int rightLevel) {
			string schemaName = Entity.SchemaName;
			string administratedRecordId = Entity.PrimaryColumnValue.ToString();
			var rightsHelper = ClassFactory.Get<RightsHelper>();
			Guid rightId = rightsHelper.SetRecordRight(adminUnitId, schemaName, administratedRecordId, operation, rightLevel);
		}

		public virtual string GetVisaLink() {
			var schemaColumns = Entity.Schema.Columns;
			var referenceSchemaName = string.Empty;
			var referenceSchemaUId = Guid.Empty;
			EntitySchemaColumnCollection referenceSchemaColumns = null;
			
			foreach (var column in schemaColumns) {
				if (!column.IsInherited && column.DataValueType.IsLookup) {
					referenceSchemaName = column.ReferenceSchema.Name;
					referenceSchemaUId = column.ReferenceSchema.UId;
					referenceSchemaColumns = column.ReferenceSchema.Columns;
				}
			}
			var mainEntityId = Entity.GetTypedColumnValue<Guid>(referenceSchemaName + "Id");
			var typeColumnUId = GetSchemaTypeColumnUId(referenceSchemaUId);
			var cardSchemaName = string.Concat(referenceSchemaName, "Page");
			var cardSchemaUId = Guid.Empty;
			if (!typeColumnUId.Equals(Guid.Empty)) {
				var typeColumnName = referenceSchemaColumns.GetByUId(typeColumnUId).Name + ".Id";
				var typeColumnValue = GetSchemaTypeColumnValue(referenceSchemaName, typeColumnName, mainEntityId);
				cardSchemaUId = GetCardSchemaUId(typeColumnValue, SysModuleEntityId);
				cardSchemaName = GetCardSchemaName(cardSchemaUId);
			} else {
				cardSchemaUId = GetCardSchemaUId(Guid.Empty, SysModuleEntityId);
				cardSchemaName = GetCardSchemaName(cardSchemaUId);
			}
			var sectionNameUId = GetSectionName(SysModuleEntityId);
			var sectionName = GetCardSchemaName(sectionNameUId);
			var template = string.Empty;
			var formatStr = string.Empty;
			string baseUrl = BPMSoft.Web.Common.WebUtilities
				.GetBaseApplicationUrl(BPMSoft.Web.Http.Abstractions.HttpContext.Current.Request);
			if (sectionName.Contains("V2")) {
				template = "{3}/Nui/ViewModule.aspx#SectionModuleV2/{2}/{0}/edit/{1}";
				formatStr = string.Format(template, cardSchemaName, mainEntityId, sectionName, baseUrl);
			} else {
				template = "{2}/Nui/ViewModule.aspx#CardModule/{0}/view/{1}";
				formatStr = string.Format(template, cardSchemaName, mainEntityId, baseUrl);
			};
			return formatStr;
		}

		public virtual void AddWriteRights(Guid adminUnitId) {
			UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name,
				Entity.PrimaryColumnValue, EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightLevel.AllowAndGrant,
				Guid.Empty, false);
			UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name,
				Entity.PrimaryColumnValue, EntitySchemaRecordRightOperation.Edit, EntitySchemaRecordRightLevel.AllowAndGrant,
				Guid.Empty, false);
		}

		public virtual void RemoveWriteRights(Guid adminUnitId) {
			UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name,
				Entity.PrimaryColumnValue, EntitySchemaRecordRightOperation.Edit, EntitySchemaRecordRightLevel.Deny,
				Guid.Empty, false);
		}

		public virtual string ProcessEmailBody(string body, Guid contactId, byte[] macrosBytes) {
			var url = GetVisaLink();
			body = string.Format(body, url);
			
			var visaEntitySchemaQuery = GetVisaTemplateEntitySchemaQuery();
			var visaEntityCollection = visaEntitySchemaQuery.GetEntityCollection(UserConnection);
			if (visaEntityCollection.Count == 0) { 
				return body;
			}
			var visaEntity = visaEntityCollection[0];
			var addedColumns = (List<EntitySchemaQueryColumn>)AddedTemplateColumns;
			
			StringBuilder sbBody =  new StringBuilder(body);
			foreach (EntitySchemaQueryColumn esqColumn in addedColumns) {
				var value = visaEntity.GetColumnValue(esqColumn.Name);
				var stringValue = value is DateTime ? ((DateTime)value).ToShortDateString() : value.ToString();
				var caption = esqColumn.Caption.ToString();
				if (String.IsNullOrEmpty(stringValue)) {
					var reqexp = string.Format("#DeleteIfEmpty#([^#]*?)\\[#{0}#\\]([^#]*?)#\\/DeleteIfEmpty#", caption);
					Regex r = new Regex(reqexp);
					foreach (Match match in r.Matches(body)) {
						sbBody.Replace(match.Value, string.Empty);
					}
				}
				sbBody.Replace(string.Format("[#{0}#]", esqColumn.Caption.ToString()), stringValue);
			}
			sbBody.Replace("#DeleteIfEmpty#", string.Empty);
			sbBody.Replace("#/DeleteIfEmpty#", string.Empty);
			sbBody.Insert(0, "<div style=\"font-family: 'Verdana';\">");
			sbBody.Append("</div>");
			body = sbBody.ToString();
			var macrosList = Json.Deserialize<List<DictionaryEntry>>(System.Text.Encoding.UTF8.GetString(macrosBytes));
			body = EmailTemplateUtility.ReplaceRecipientMacrosText(body, contactId, macrosList, UserConnection);
			return body;
		}

		public virtual Guid GetEmailTemplateId() {
			object tempalteId;
			string entitySchemaName = Entity.Schema.Name;
			string templateSysSettingCode = string.Format("{0}EmailTemplate", entitySchemaName);
			if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, templateSysSettingCode, out tempalteId) &&
				tempalteId is Guid) {
				return (Guid)tempalteId;
			}
			return Guid.Empty;
		}

		public virtual EntitySchemaQuery GetVisaTemplateEntitySchemaQuery() {
			var tableESQ = new EntitySchemaQuery(Entity.Schema);
			var columns = GetVisaTemplateSchemaQueryColumns();
			var addedColumns = new List<EntitySchemaQueryColumn>();
			foreach(string columnName in columns) {
				addedColumns.Add(tableESQ.AddColumn(columnName));
			}
			AddedTemplateColumns = addedColumns;
			tableESQ.Filters.Add(tableESQ.CreateFilterWithParameters(FilterComparisonType.Equal, 
				Entity.Schema.GetPrimaryColumnName(), 
				Entity.PrimaryColumnValue));
			return tableESQ;
		}

		public virtual List<string> GetVisaTemplateSchemaQueryColumns() {
			List<string> columns = new List<string>() {
				"VisaOwner.Name",
				"Objective"
			};
			return columns;
		}

		public virtual bool BaseVisaSaving(ProcessExecutingContext context) {
			oldVisaOwnerId = Entity.GetTypedOldColumnValue<Guid>("VisaOwnerId");
			oldDelegatedFromId = Entity.GetTypedOldColumnValue<Guid>("DelegatedFromId");
			return true;
		}

		public virtual bool BaseVisaSaved(ProcessExecutingContext context) {
			var visaOwnerId = Entity.VisaOwnerId;
			var delegatedFromId = Entity.DelegatedFromId;
			if (visaOwnerId.IsNotEmpty() && visaOwnerId != oldVisaOwnerId) {
				var emails = GetGroupContacts(visaOwnerId);
				if (emails.Count > 0) {
					SendEmail(emails);
				}
				AddWriteRights(visaOwnerId);
				if (oldDelegatedFromId.IsNotEmpty()
					&& oldVisaOwnerId.IsNotEmpty()
					&& oldVisaOwnerId != oldDelegatedFromId
					&& oldVisaOwnerId != delegatedFromId) {
					RemoveWriteRights(oldVisaOwnerId);
				}
				if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
					if (oldVisaOwnerId.IsNotEmpty()) {
						PublishClientVisaInfo(oldVisaOwnerId, "delete");
					}
					SendNotification();
				}
			}
			if (IsNew) {
				if (visaOwnerId != UserConnection.CurrentUser.Id) {
					UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(UserConnection.CurrentUser.Id,
						Entity.Schema.Name, Entity.PrimaryColumnValue, SchemaRecordRightLevels.CanRead
						| SchemaRecordRightLevels.CanChangeReadRight, false);
				}
				if (visaOwnerId.IsNotEmpty() && UserConnection.GetIsFeatureEnabled("UseMobileApprovalPushNotifications") && 
						IsUser(visaOwnerId) && IsMobileApplicationModeOnline()) {
					SendPushNotification();
				}
			}
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				bool isFinalStatus = IsFinalStatus(Entity.StatusId);
				if (isFinalStatus) {
					PublishClientVisaInfo(visaOwnerId, "delete");
				}
			} else {
				PublishClientRemindingInfo("update");
			}
			return true;
		}

		public virtual bool BaseVisaInserted(ProcessExecutingContext context) {
			IsNew = true;
			return true;
		}

		public virtual Guid GetSectionName(Guid Id) {
			var cardSchemaUId = Guid.Empty;
			
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModule");
			var typeColumn = entitySchemaQuery.AddColumn("SectionSchemaUId");
			
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
			"SysModuleEntity", new object[]{Id}));
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			
			if (entityCollection.Count > 0) {
				var entity = entityCollection[0];
				cardSchemaUId = entity.GetTypedColumnValue<Guid>(typeColumn.Name);
			}
			return cardSchemaUId;
		}

		public virtual void PublishClientRemindingInfo(string operation) {
			var visaOwnerId = Entity.GetTypedColumnValue<Guid>("VisaOwnerId");
			var delegatedFromId = Entity.GetTypedColumnValue<Guid>("DelegatedFromId");
			PublishClientVisaInfo(visaOwnerId, operation);
			if (oldVisaOwnerId.IsNotEmpty()) {
				PublishClientVisaInfo(delegatedFromId, operation);
			}
		}

		public virtual Dictionary<Guid, Tuple<byte[], string>> GetEmailAttachmentsFromTemplate(Guid templateId) {
			var result = new Dictionary<Guid, Tuple<byte[], string>>();
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("EmailTemplateFile");
			var srcESQ = new EntitySchemaQuery(entitySchema);
			srcESQ.IsDistinct = true;
			var idColumn =srcESQ.AddColumn(srcESQ.RootSchema.GetPrimaryColumnName());
			var nameColumn = srcESQ.AddColumn("Name");	   
			srcESQ.Filters.Add(srcESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "EmailTemplate", templateId));
			var srcList = srcESQ.GetEntityCollection(UserConnection);
			var fileRepository = ClassFactory.Get<FileRepository>(
						new ConstructorArgument("userConnection", UserConnection));
			foreach (var src in srcList) {
				var idSchemaColumn = src.Schema.Columns.GetByName(idColumn.Name);
				var fileId = src.GetTypedColumnValue<Guid>(idSchemaColumn.ColumnValueName);
				var nameSchemaColumn = src.Schema.Columns.GetByName(nameColumn.Name);
				var fileName = src.GetTypedColumnValue<String>(nameSchemaColumn.ColumnValueName);
				using (var memoryStream = new MemoryStream()) {
					var bwriter = new BinaryWriter(memoryStream);
					var fileInfo = fileRepository.LoadFile(entitySchema.UId, fileId, bwriter);
					Tuple<byte[], string> attach = Tuple.Create<byte[], string>(memoryStream.ToArray(), fileName);
					result.Add(fileId, attach);
				}							
			}
			
			return result;
		}

		public virtual IEnumerable<Guid> GetSysAdminUnitsInGroup(Guid sysAdminUnit) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			esq.AddColumn("SysUser");
			esq.AddColumn("SysRole");
			IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
			    "SysRole", (object)sysAdminUnit);
			esq.Filters.Add(filter);
			EntityCollection result = esq.GetEntityCollection(UserConnection);
			IEnumerable<Guid> sysAdminUnitInGroup =
							result.Select(entity => entity.GetTypedColumnValue<Guid>("SysUserId"));
			return sysAdminUnitInGroup;
		}

		public virtual INotificationInfo GetNotificationInfo() {
			INotificationSettingsRepository notificationSettingsRepository = ClassFactory.Get<NotificationSettingsRepository>(
						new ConstructorArgument("userConnection", UserConnection));
					Guid imageId = notificationSettingsRepository.GetNotificationImage(Entity.Schema.UId, null);
					var referenceEntity = GetFetchedReferenceEntity();
					var body = string.Empty;
					var referenceEntityId = Guid.Empty;
					string schemaName;
					if (referenceEntity != null) {
						body = GetPopupBody(referenceEntity);
						referenceEntityId = referenceEntity.PrimaryColumnValue;
						schemaName = referenceEntity.SchemaName;
					} else {
						schemaName = Entity.SchemaName;
					}
					return new NotificationInfo {
						Body = body,
						MessageId = Entity.Id,
						EntityId = referenceEntityId,
						Title = PopupTitleTemplate,
						ImageId = imageId,
						EntitySchemaName = schemaName,
						SysAdminUnit = Entity.VisaOwnerId,
						RemindTime = DateTime.UtcNow,
						GroupName = "Visa"
					};
		}

		public virtual void SendNotification() {
			INotificationInfo notificationInfo = GetNotificationInfo();
			IEnumerable<INotificationInfo> notificationInfos = new[] {notificationInfo};
			NotificationInfoUtilities.GetUsers(ref notificationInfos, UserConnection);
			var notificationSender = ClassFactory.Get<INotificationSender>(
				new ConstructorArgument("userConnection", UserConnection));
			notificationSender.Send(notificationInfos);
		}

		public virtual string GetPopupBody(Entity referenceEntity) {
			string schemaCaption = referenceEntity.Schema.Caption;
			var displayValue = referenceEntity.PrimaryDisplayColumnValue;
			if (displayValue.IsNotNullOrWhiteSpace()) {
				displayValue = $", {displayValue}";
			}
			var body = string.Format(PopupBodyDefaultTemplate, schemaCaption, displayValue);
			return body;
		}

		public virtual Entity GetFetchedReferenceEntity() {
			var sysModuleVisaSchema = UserConnection.EntitySchemaManager.FindInstanceByName("SysModuleVisa");
			Entity sysModuleVisaEntity = sysModuleVisaSchema.CreateEntity(UserConnection);
			var columnName = "MasterColumnUId";
			EntitySchemaColumn referenceColumn;
			EntitySchemaColumnCollection columns = Entity.Schema.Columns;
			if (sysModuleVisaEntity.FetchFromDB("VisaSchemaUId", Entity.Schema.UId, new[] { columnName })) {
				var masterColumnUId = sysModuleVisaEntity.GetTypedColumnValue<Guid>(columnName);
				referenceColumn = columns.FirstOrDefault(c => c.UId == masterColumnUId);
			} else {
				var entityName = Entity.SchemaName.Replace("Visa", "");
				referenceColumn = columns.FirstOrDefault(c => c.ReferenceSchema != null &&
					c.ReferenceSchema.Name == entityName);
			}
			if (referenceColumn != null) {
				var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(referenceColumn.ReferenceSchema.Name);
				Entity entity = entitySchema.CreateEntity(UserConnection);
				entity.FetchPrimaryInfoFromDB("Id", Entity.GetTypedColumnValue<Guid>(referenceColumn.ColumnValueName));
				return entity;
			}
			return null;
		}

		public virtual void PublishClientVisaInfo(Guid visaOwnerId, string operation) {
			var adminUnitIds = new List<Guid>();
			var sysAdminUnitInGroup = GetSysAdminUnitsInGroup(visaOwnerId).ToList();
			if (sysAdminUnitInGroup.Any()) {
				adminUnitIds.AddRange(sysAdminUnitInGroup);
			} else {
				adminUnitIds.Add(visaOwnerId);
			}
			var manager = MsgChannelManager.Instance;
			var message = new {
				recordId = Entity.Id,
				notificationGroup = NotificationGroupConst.Visa,
				operation,
				status = Entity.StatusId,
				isCanceled = Entity.IsCanceled
			};
			foreach (var sysAdminUnitId in adminUnitIds) {
				var channel = manager.FindItemByUId(sysAdminUnitId);
				if (channel == null) {
					continue;
				}
				var simpleMessage = new SimpleMessage {
					Body = JsonConvert.SerializeObject(message),
					Id = sysAdminUnitId
				};
				simpleMessage.Header.Sender = "UpdateReminding";
				channel.PostMessage(simpleMessage);
			}
		}

		public virtual bool IsFinalStatus(Guid statusId) {
			Guid[] finallyStatuses = NotificationUtilities.GetFinallyVisaStatuses(UserConnection);
			return finallyStatuses.Contains(statusId);
		}

		#endregion

	}

	#endregion

}

