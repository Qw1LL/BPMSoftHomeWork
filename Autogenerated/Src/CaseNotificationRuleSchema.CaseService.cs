namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
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

	#region Class: CaseNotificationRuleSchema

	/// <exclude/>
	public class CaseNotificationRuleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CaseNotificationRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseNotificationRuleSchema(CaseNotificationRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseNotificationRuleSchema(CaseNotificationRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b");
			RealUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b");
			Name = "CaseNotificationRule";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("44ceb0ec-dac6-4711-81c3-19579449e3c1")) == null) {
				Columns.Add(CreateCaseStatusColumn());
			}
			if (Columns.FindByUId(new Guid("2bad1645-295e-4592-bddf-15f5dc4555e5")) == null) {
				Columns.Add(CreateCaseCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("086ec50b-11d3-4990-9928-83a5602a5081")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("1ad4adab-d6e3-4f46-bc16-135b0b486b68")) == null) {
				Columns.Add(CreateRuleUsageColumn());
			}
			if (Columns.FindByUId(new Guid("fac4843f-2b65-46cc-9fd8-0de0ea4413ed")) == null) {
				Columns.Add(CreateDelayColumn());
			}
			if (Columns.FindByUId(new Guid("7ab3e63f-8cf2-4b96-beb3-45bfc4d33558")) == null) {
				Columns.Add(CreateIsQuoteOriginalEmailColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaseStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("44ceb0ec-dac6-4711-81c3-19579449e3c1"),
				Name = @"CaseStatus",
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2bad1645-295e-4592-bddf-15f5dc4555e5"),
				Name = @"CaseCategory",
				ReferenceSchemaUId = new Guid("63fec14d-0309-43b0-99c5-b085abf0c314"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("086ec50b-11d3-4990-9928-83a5602a5081"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			};
		}

		protected virtual EntitySchemaColumn CreateRuleUsageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1ad4adab-d6e3-4f46-bc16-135b0b486b68"),
				Name = @"RuleUsage",
				ReferenceSchemaUId = new Guid("f175dd0b-0652-48ef-a515-c8608452ed40"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"e34695a7-7d65-45d8-b5a0-7b69ae52be6a"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDelayColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fac4843f-2b65-46cc-9fd8-0de0ea4413ed"),
				Name = @"Delay",
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsQuoteOriginalEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7ab3e63f-8cf2-4b96-beb3-45bfc4d33558"),
				Name = @"IsQuoteOriginalEmail",
				CreatedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				ModifiedInSchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"),
				CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseNotificationRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseNotificationRule_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseNotificationRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseNotificationRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseNotificationRule

	/// <summary>
	/// Правила уведомлений контакта по обращению.
	/// </summary>
	public class CaseNotificationRule : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CaseNotificationRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseNotificationRule";
		}

		public CaseNotificationRule(CaseNotificationRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseStatusId {
			get {
				return GetTypedColumnValue<Guid>("CaseStatusId");
			}
			set {
				SetColumnValue("CaseStatusId", value);
				_caseStatus = null;
			}
		}

		/// <exclude/>
		public string CaseStatusName {
			get {
				return GetTypedColumnValue<string>("CaseStatusName");
			}
			set {
				SetColumnValue("CaseStatusName", value);
				if (_caseStatus != null) {
					_caseStatus.Name = value;
				}
			}
		}

		private CaseStatus _caseStatus;
		/// <summary>
		/// Состояния обращения.
		/// </summary>
		public CaseStatus CaseStatus {
			get {
				return _caseStatus ??
					(_caseStatus = LookupColumnEntities.GetEntity("CaseStatus") as CaseStatus);
			}
		}

		/// <exclude/>
		public Guid CaseCategoryId {
			get {
				return GetTypedColumnValue<Guid>("CaseCategoryId");
			}
			set {
				SetColumnValue("CaseCategoryId", value);
				_caseCategory = null;
			}
		}

		/// <exclude/>
		public string CaseCategoryName {
			get {
				return GetTypedColumnValue<string>("CaseCategoryName");
			}
			set {
				SetColumnValue("CaseCategoryName", value);
				if (_caseCategory != null) {
					_caseCategory.Name = value;
				}
			}
		}

		private CaseCategory _caseCategory;
		/// <summary>
		/// Категория обращения.
		/// </summary>
		public CaseCategory CaseCategory {
			get {
				return _caseCategory ??
					(_caseCategory = LookupColumnEntities.GetEntity("CaseCategory") as CaseCategory);
			}
		}

		/// <exclude/>
		public Guid EmailTemplateId {
			get {
				return GetTypedColumnValue<Guid>("EmailTemplateId");
			}
			set {
				SetColumnValue("EmailTemplateId", value);
				_emailTemplate = null;
			}
		}

		/// <exclude/>
		public string EmailTemplateName {
			get {
				return GetTypedColumnValue<string>("EmailTemplateName");
			}
			set {
				SetColumnValue("EmailTemplateName", value);
				if (_emailTemplate != null) {
					_emailTemplate.Name = value;
				}
			}
		}

		private EmailTemplate _emailTemplate;
		/// <summary>
		/// Шаблон email сообщения.
		/// </summary>
		public EmailTemplate EmailTemplate {
			get {
				return _emailTemplate ??
					(_emailTemplate = LookupColumnEntities.GetEntity("EmailTemplate") as EmailTemplate);
			}
		}

		/// <exclude/>
		public Guid RuleUsageId {
			get {
				return GetTypedColumnValue<Guid>("RuleUsageId");
			}
			set {
				SetColumnValue("RuleUsageId", value);
				_ruleUsage = null;
			}
		}

		/// <exclude/>
		public string RuleUsageName {
			get {
				return GetTypedColumnValue<string>("RuleUsageName");
			}
			set {
				SetColumnValue("RuleUsageName", value);
				if (_ruleUsage != null) {
					_ruleUsage.Name = value;
				}
			}
		}

		private NotificationRuleUsage _ruleUsage;
		/// <summary>
		/// Правило использования.
		/// </summary>
		public NotificationRuleUsage RuleUsage {
			get {
				return _ruleUsage ??
					(_ruleUsage = LookupColumnEntities.GetEntity("RuleUsage") as NotificationRuleUsage);
			}
		}

		/// <summary>
		/// Задержка отправки, минут.
		/// </summary>
		public int Delay {
			get {
				return GetTypedColumnValue<int>("Delay");
			}
			set {
				SetColumnValue("Delay", value);
			}
		}

		/// <summary>
		/// Процитировать оригинальный емейл.
		/// </summary>
		public bool IsQuoteOriginalEmail {
			get {
				return GetTypedColumnValue<bool>("IsQuoteOriginalEmail");
			}
			set {
				SetColumnValue("IsQuoteOriginalEmail", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseNotificationRule_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseNotificationRuleDeleted", e);
			Validating += (s, e) => ThrowEvent("CaseNotificationRuleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseNotificationRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseNotificationRule_CaseServiceEventsProcess

	/// <exclude/>
	public partial class CaseNotificationRule_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CaseNotificationRule
	{

		public CaseNotificationRule_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseNotificationRule_CaseServiceEventsProcess";
			SchemaUId = new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4fc8146d-b899-4e6a-bbaf-62244f00b72b");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CaseNotificationRule_CaseServiceEventsProcess

	/// <exclude/>
	public class CaseNotificationRule_CaseServiceEventsProcess : CaseNotificationRule_CaseServiceEventsProcess<CaseNotificationRule>
	{

		public CaseNotificationRule_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseNotificationRule_CaseServiceEventsProcess

	public partial class CaseNotificationRule_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseNotificationRuleEventsProcess

	/// <exclude/>
	public class CaseNotificationRuleEventsProcess : CaseNotificationRule_CaseServiceEventsProcess
	{

		public CaseNotificationRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

