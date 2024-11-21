namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Mail.Sender;
	using CoreSysSettings = Core.Configuration.SysSettings;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;

	#region Enum: EmailPriority

	/// <summary>
	/// Approver type of approval.
	/// </summary>
	public enum ApproverTypeEnum
	{
		/// <summary>
		/// Employee.
		/// </summary>
		Employee = 0,

		/// <summary>
		/// Employee manager.
		/// </summary>
		EmployeeManager = 1,

		/// <summary>
		/// Role.
		/// </summary>
		Role = 2
	}

	#endregion

	#region Class: ApprovalUserTaskMacrosHelper

	public class ApprovalUserTaskMacrosHelper : GlobalMacrosHelper
	{

		#region Methods: Protected

		protected override string GetMacrosValue(KeyValuePair<string, string> macros) {
			return macros.Value;
		}

		#endregion

	}

	#endregion

	#region Class: ApprovalUserTask

	/// <summary>
	/// Partial class of ApprovalUserTask, that implement user task runtime behaviour.
	/// </summary>
	public partial class ApprovalUserTask
	{

		#region Constants: Private

		/// <summary>
		/// Email template entity schema name.
		/// </summary>
		private const string EmailTemplateSchemaName = "EmailTemplate";

		/// <summary>
		/// Tag for getting email template user task language iterator.
		/// </summary>
		private const string EmailTemplateUserTaskLanguageIteratorTag = "EmailTemplateUserTask";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Process");

		#endregion

		#region Properties: Private

		private MLangContentFactory _contentFactory;
		/// <summary>
		/// Multi language content factory.
		/// </summary>
		public MLangContentFactory MLangContentFactory
		{
			get => _contentFactory ?? (_contentFactory = new MLangContentFactory(UserConnection));
			set => _contentFactory = value;
		}

		#endregion

		#region Properties: Protected

		private ApprovalUserTaskMacrosHelper _macrosHelper;
		protected ApprovalUserTaskMacrosHelper MacrosHelper {
			get => _macrosHelper ?? new ApprovalUserTaskMacrosHelper {
					UserConnection = UserConnection,
					UseAdminRights = false
				};
			set => _macrosHelper = value;
		}

		#endregion

		#region Properties: Public

		private MacrosExtendedProperties _macrosExtendedProperties;
		/// <summary>
		/// Extended properties, that use <see cref="MacrosHelper"/>
		/// </summary>
		public MacrosExtendedProperties MacrosExtendedProperties
			=> _macrosExtendedProperties ?? (_macrosExtendedProperties = new MacrosExtendedProperties());

		#endregion

		#region Methods: Private

		private Guid GetEmployeeId() {
			var selectById =
				(Select)new Select(UserConnection).Top(1)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(EmployeeId));
			Guid employeeId = selectById.ExecuteScalar<Guid>();
			if (employeeId.IsNotEmpty()) {
				return employeeId;
			}
			var selectByContactId =
				(Select)new Select(UserConnection).Top(1)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("ContactId").IsEqual(Column.Parameter(EmployeeId));
			employeeId = selectByContactId.ExecuteScalar<Guid>();
			return employeeId;
		}

		private Guid GetEmployeeManagerId() {
			var selectById =
				(Select)new Select(UserConnection).Top(1)
						.Column("sm", "Id")
				.From("SysAdminUnit").As("sm")
				.InnerJoin("Employee").As("m").On("m", "ContactId").IsEqual("sm", "ContactId")
				.InnerJoin("Employee").As("e").On("e", "ManagerId").IsEqual("m", "Id")
				.InnerJoin("SysAdminUnit").As("se").On("se", "ContactId").IsEqual("e", "ContactId")
				.Where("se", "Id").IsEqual(Column.Parameter(EmployeeId));
			Guid employeeId = selectById.ExecuteScalar<Guid>();
			if (employeeId.IsNotEmpty()) {
				return employeeId;
			}
			var selectByContactId =
				(Select)new Select(UserConnection).Top(1)
					.Column("sm", "Id")
				.From("SysAdminUnit").As("sm")
				.InnerJoin("Employee").As("m").On("m", "ContactId").IsEqual("sm", "ContactId")
				.InnerJoin("Employee").As("e").On("e", "ManagerId").IsEqual("m", "Id")
				.Where("e", "ContactId").IsEqual(Column.Parameter(EmployeeId));
			employeeId = selectByContactId.ExecuteScalar<Guid>();
			return employeeId;
		}

		private Guid GetVisaOwnerId() {
			Guid visaOwnerId = Guid.Empty;
			switch ((ApproverTypeEnum)ApproverType) {
				case ApproverTypeEnum.Employee:
					visaOwnerId = GetEmployeeId();
					break;
				case ApproverTypeEnum.EmployeeManager:
					visaOwnerId = GetEmployeeManagerId();
					break;
				case ApproverTypeEnum.Role:
					visaOwnerId = RoleId;
					break;
			}
			return visaOwnerId;
		}

		private void FillApprovalColumns(Entity entity) {
			var approvalEntity = (BaseVisa)entity;
			approvalEntity.Objective = Purpose;
			approvalEntity.VisaOwnerId = GetVisaOwnerId();
			approvalEntity.IsAllowedToDelegate = IsAllowedToDelegate;
			approvalEntity.IsRequiredDigitalSignature = IsRequiredDigitalSignature;
			approvalEntity.Id = UId;
			EntitySchemaColumn masterColumn = approvalEntity.Schema.Columns.GetByUId(MasterColumnUId);
			approvalEntity.SetColumnValue(masterColumn, RecordId);
			if (approvalEntity.VisaOwnerId.IsEmpty()) {
				approvalEntity.ForceSetColumnValue("VisaOwnerId", null);
				approvalEntity.IsAllowedToDelegate = true;
			}
		}

		private Entity CreateApprovalEntity(EntitySchema schema) {
			Entity entity = schema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			entity.SetDefColumnValues();
			FillApprovalColumns(entity);
			return entity;
		}

		private DataContract.Filter CreateStatusFilter(Guid statusId) {
			var filter = new DataContract.Filter {
				FilterType = DataContract.FilterType.CompareFilter,
				LeftExpression = new DataContract.BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.SchemaColumn,
					ColumnPath = "Status"
				},
				ComparisonType = FilterComparisonType.Equal,
				RightExpression = new DataContract.BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.Parameter,
					Parameter = new DataContract.Parameter {
						DataValueType = DataContract.DataValueType.Guid,
						Value = statusId
					}
				}
			};
			return filter;
		}

		private string GetConditionData() {
			var filterCollection = new Dictionary<string, DataContract.Filter>();
			var select =
				(Select)new Select(UserConnection)
					.Column("Id")
				.From("VisaStatus")
				.Where("IsFinal").IsEqual(Column.Const(true));
			select.ExecuteReader(reader => {
				Guid statusId = reader.GetColumnValue<Guid>("Id");
				DataContract.Filter filter = CreateStatusFilter(statusId);
				filterCollection.Add(statusId.ToString("N"), filter);
			});
			var filters = new DataContract.Filters {
				FilterType = DataContract.FilterType.FilterGroup,
				LogicalOperation = LogicalOperationStrict.Or,
				Items = filterCollection
			};
			return JsonConvert.SerializeObject(filters)
				.ReplaceFirstInstanceOf("{", $"{{{ProcessConvertorUtilities.DataContractFiltersClassName},");
		}

		private void CancelApprovalEntity(Guid approvalId) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByUId(ApprovalSchemaUId);
			Entity entity = schema.CreateEntity(UserConnection);
			if (entity.FetchFromDB("Id", approvalId)) {
				entity.SetColumnValue("IsCanceled", true);
				entity.SetColumnValue("StatusId", ApprovalConstants.Canceled);
				entity.UseAdminRights = false;
				entity.Save(false);
			}
		}

		private void SendEmail(List<string> recepients, Guid emailTemplateId) {
			try {
				EmailMessage message = CreateEmailMessage(recepients, emailTemplateId);
				ReplaceMacroses(message);
				var constructorArguments = new ConstructorArgument("userConnection", UserConnection);
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(constructorArguments);
				var emailSender = new HtmlEmailMessageSender(emailClientFactory, UserConnection);
				emailSender.Send(message, true);
			} catch (Exception e) {
				_log.Error(e);
				if (!IgnoreEmailErrors) {
					throw;
				}
			}
		}

		private EmailMessage CreateEmailMessage(List<string> recipients, Guid emailTemplateId) {
			string sender = GetSenderEmailAddress();
			Entity emailTemplateEntity;
			if (UserConnection.GetIsFeatureEnabled("EmailTemplateUserTaskMultiLanguageV2")) {
				emailTemplateEntity = GetMultiLanguageTemplate(emailTemplateId, GetTemplateEmployeeContactId(),
					EmailTemplateUserTaskLanguageIteratorTag);
				if (UserConnection.GetIsFeatureEnabled("UseMacrosAdditionalParameters")) {
					MacrosExtendedProperties.LanguageId = emailTemplateEntity.GetTypedColumnValue<Guid>("LanguageId");
				}
			} else {
				emailTemplateEntity = GetEmailTemplateEntity(emailTemplateId);
			}
			string subject = GetEmailSubject(emailTemplateEntity);
			string body = GetEmailBody(emailTemplateEntity);
			var message = new EmailMessage {
				From = sender,
				To = recipients,
				Priority = EmailPriority.Normal,
				Subject = subject,
				Body = body,
				IsHtmlBody = true
			};
			return message;
		}

		private void ReplaceMacroses(EmailMessage emailMessage) {
			var managerItem = UserConnection.EntitySchemaManager.GetItemByUId(ApprovalSchemaUId);
			var entityId = CurrentApprovalId;
			var entityName = managerItem.Name;
			emailMessage.Body = MacrosHelper.GetTextTemplate(emailMessage.Body, entityName, entityId,
				MacrosExtendedProperties);
			emailMessage.Subject = MacrosHelper.GetPlainTextTemplate(emailMessage.Subject, entityName, entityId,
				MacrosExtendedProperties);
		}

		private string GetEmailBody(Entity emailTemplateEntity) {
			string body = string.Empty;
			if (emailTemplateEntity != null) {
				body = emailTemplateEntity.GetTypedColumnValue<string>("Body");
			}
			return body;
		}

		private string GetEmailSubject(Entity emailTemplateEntity) {
			string subject = string.Empty;
			if (emailTemplateEntity != null) {
				subject = emailTemplateEntity.GetTypedColumnValue<string>("Subject");
			}
			return subject;
		}

		private Entity GetEmailTemplateEntity(Guid emailTemplateId) {
			var templateEsq = GetEmailTemplateBodyEsq();
			return templateEsq.GetEntity(UserConnection, emailTemplateId);
		}

		private EntitySchemaQuery GetEmailTemplateBodyEsq() {
			EntitySchemaManager manager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(manager, "EmailTemplate");
			esq.AddColumn("Body");
			esq.AddColumn("Subject");
			return esq;
		}

		private string GetSenderEmailAddress() {
			string senderEmailAddress = string.Empty;
			if (CoreSysSettings.TryGetValue(UserConnection, "VisaMailboxSettings", out object value)) {
				Guid mailboxSettingsId = (Guid)value;
				var select = (Select)new Select(UserConnection)
						.Column("SenderEmailAddress")
					.From("MailboxSyncSettings")
					.Where("MailboxSyncSettings", "Id").IsEqual(Column.Parameter(mailboxSettingsId));
				senderEmailAddress = select.ExecuteScalar<String>();
			}
			if (senderEmailAddress.IsNullOrEmpty()) {
				throw new Exception("Sender email address is empty. Check 'VisaMailboxSettings' system settings value");
			}
			return senderEmailAddress;

		}

		private List<string> GetAuthorEmailAddresses() {
			var result = new List<string>();
			BaseProcessSchemaElement userTaskSchema = GetSchemaElement();
			var parametersMetaInfo = (IProcessParametersMetaInfo)userTaskSchema;
			ProcessSchemaParameterCollection parameters = parametersMetaInfo.ForceGetParameters();
			ProcessSchemaParameter parameter = parameters.FindByName("AuthorEmailAddress");
			if (parameter != null) {
				object propertyValue = GetParameterValue(parameter);
				result = EmailTemplateUserTaskUtilities.GetParameterEmailAddresses(UserConnection, propertyValue,
					parameter);
			}
			return result;
		}

		private List<string> GetApproversEmailAddresses() {
			Select select = (ApproverTypeEnum)ApproverType == ApproverTypeEnum.Role
				? GetRoleEmailAddressSelect()
				: GetEmployeeEmailAddressSelect();
			List<string> result = new List<string>();
			select.ExecuteReader(reader => {
				string email = reader.GetColumnValue<String>("Email");
				if (email.IsNotEmpty()) {
					result.Add(email);
				}
			});
			return result;
		}

		private Select GetEmployeeEmailAddressSelect() {
			Guid visaOwnerId = GetVisaOwnerId();
			var select =
				(Select)new Select(UserConnection)
					.Column("Contact", "Email").As("Email")
				.From("Contact")
				.InnerJoin("SysAdminUnit").On("Contact", "Id").IsEqual("SysAdminUnit", "ContactId")
				.Where("SysAdminUnit", "Id").IsEqual(Column.Parameter(visaOwnerId))
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true));
			return select;
		}

		/// <summary>
		/// Returns employee contact identifier <see cref="Select"/> instance.
		/// </summary>
		/// <param name="employeeId"><see cref="SysAdminUnit"/> employee identifier.</param>
		/// <returns>Employee contact identifier <see cref="Select"/> instance.</returns>
		private Select GetEmployeeContactIdSelect(Guid employeeId) {
			var select =
				(Select)new Select(UserConnection)
					.Column("Contact", "Id")
				.From("Contact")
				.InnerJoin("SysAdminUnit").On("Contact", "Id").IsEqual("SysAdminUnit", "ContactId")
				.Where("SysAdminUnit", "Id").IsEqual(Column.Parameter(employeeId));
			return select;
		}

		private Select GetRoleEmailAddressSelect() {
			Guid visaOwnerId = GetVisaOwnerId();
			var select =
				(Select)new Select(UserConnection)
					.Column("Contact", "Email").As("Email")
				.From("SysUserInRole")
				.InnerJoin("SysAdminUnit").On("SysAdminUnit", "Id").IsEqual("SysUserInRole", "SysUserId")
				.InnerJoin("Contact").On("Contact", "Id").IsEqual("SysAdminUnit", "ContactId")
				.Where("SysUserInRole", "SysRoleId").IsEqual(Column.Parameter(visaOwnerId))
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true));
			return select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns employee contact identifier from email template user task.
		/// </summary>
		/// <returns>Employee contact identifier from email template user task.</returns>
		protected virtual Guid GetTemplateEmployeeContactId() {
			BaseProcessSchemaElement userTaskSchema = GetSchemaElement();
			var processParametersMetaInfo = userTaskSchema as IProcessParametersMetaInfo;
			ProcessSchemaParameterCollection parameters = processParametersMetaInfo?.ForceGetParameters();
			if (parameters == null || parameters.Count == 0) {
				return Guid.Empty;
			}
			var contactId = Guid.Empty;
			if (ResultParameter == Guid.Empty) {
				var employeeId = (Guid)GetParameterValue(parameters.FindByName("EmployeeId"));
				Select select = GetEmployeeContactIdSelect(employeeId);
				select.ExecuteReader(reader => {
					contactId = reader.GetColumnValue<Guid>("Id");
				});
			} else {
				ProcessSchemaParameter authorEmailAddress = parameters.FindByName("AuthorEmailAddress");
				if (authorEmailAddress.DataValueType.IsLookup) {
					contactId = (Guid)GetParameterValue(authorEmailAddress);
				}
			}
			return contactId;
		}

		/// <summary>
		/// Executes the current element.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns><c>false</c>.</returns>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			bool isRunning = CurrentApprovalId != Guid.Empty;
			bool isError = Status == ProcessStatus.Error;
			if (!isRunning || isError) {
				EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByUId(ApprovalSchemaUId);
				Entity entity = CreateApprovalEntity(schema);
				string conditionData = GetConditionData();
				UserConnection.IProcessEngine.AddProcessListener(entity, UId, conditionData);
				CurrentApprovalId = entity.PrimaryColumnValue;
				if (IsSendEmailToApprovers) {
					List<string> recipients = GetApproversEmailAddresses();
					if (recipients.IsNotEmpty()) {
						SendEmail(recipients, ApproverEmailTemplate);
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Gets multi language template entity.
		/// </summary>
		/// <param name="templateId">Template record identifier.</param>
		/// <param name="recordId">Entity record identifier.</param>
		/// <param name="schemaName">Tag name to get an iterator.</param>
		/// <returns>Multi language template entity.</returns>
		protected Entity GetMultiLanguageTemplate(Guid templateId, Guid recordId, string schemaName) {
			var contentKit = MLangContentFactory.GetContentKit(schemaName, EmailTemplateSchemaName);
			Entity template = contentKit.GetContent(templateId, recordId);
			return template;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Completes executing the current element.
		/// </summary>
		/// <param name="parameters">Array of the parameter values.</param>
		/// <returns><c>true</c>, if element was successfully executed and conditions for moving to the next step were
		/// satisfied; otherwise - <c>false</c>.</returns>
		public override bool CompleteExecuting(params object[] parameters) {
			var approvalEntity = parameters[0] as BaseVisa;
			if (approvalEntity == null) {
				return false;
			}
			ResultParameter = approvalEntity.StatusId;
			if (IsSendEmailToAuthor) {
				List<string> recepients = GetAuthorEmailAddresses();
				if (recepients.IsNotEmpty()) {
					SendEmail(recepients, AuthorEmailTemplate);
				}
			}
			return base.CompleteExecuting(parameters);
		}

		/// <summary>
		/// Cancels execution of the current stage.
		/// </summary>
		/// <param name="parameters">Array of the parameter values.</param>
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			UserConnection.IProcessEngine.RemoveProcessListener(CurrentApprovalId, ApprovalSchemaUId, UId);
			CancelApprovalEntity(CurrentApprovalId);
		}

		public override string GetExecutionData() {
			return SerializeToString(new {});
		}

		#endregion

	}

	#endregion

}
