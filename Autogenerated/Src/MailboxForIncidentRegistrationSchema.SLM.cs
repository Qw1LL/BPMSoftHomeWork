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

	#region Class: MailboxForIncidentRegistrationSchema

	/// <exclude/>
	public class MailboxForIncidentRegistrationSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MailboxForIncidentRegistrationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxForIncidentRegistrationSchema(MailboxForIncidentRegistrationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxForIncidentRegistrationSchema(MailboxForIncidentRegistrationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c");
			RealUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c");
			Name = "MailboxForIncidentRegistration";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysMailboxForIncidentRegisLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c5b6b4ae-6d42-4706-9469-06bdcb40d713")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("4d4d5f2a-2960-4e84-9b17-46554f3a08d0")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("2191c656-ec42-4e2d-b708-712664c59819")) == null) {
				Columns.Add(CreateAliasAddressColumn());
			}
			if (Columns.FindByUId(new Guid("75bda3d6-12e0-ae44-e912-cb7e6dca9045")) == null) {
				Columns.Add(CreateUseMailboxLanguageColumn());
			}
			if (Columns.FindByUId(new Guid("4471d3c9-07bf-771f-dd91-c23d76734c5f")) == null) {
				Columns.Add(CreateMessageLanguageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c5b6b4ae-6d42-4706-9469-06bdcb40d713"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				ModifiedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4d4d5f2a-2960-4e84-9b17-46554f3a08d0"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("63fec14d-0309-43b0-99c5-b085abf0c314"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				ModifiedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected virtual EntitySchemaColumn CreateAliasAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2191c656-ec42-4e2d-b708-712664c59819"),
				Name = @"AliasAddress",
				CreatedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				ModifiedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected virtual EntitySchemaColumn CreateUseMailboxLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("75bda3d6-12e0-ae44-e912-cb7e6dca9045"),
				Name = @"UseMailboxLanguage",
				CreatedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				ModifiedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				CreatedInPackageId = new Guid("5c519463-1fa4-4c1e-acaf-02bcff203125")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4471d3c9-07bf-771f-dd91-c23d76734c5f"),
				Name = @"MessageLanguage",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				ModifiedInSchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"),
				CreatedInPackageId = new Guid("5c519463-1fa4-4c1e-acaf-02bcff203125")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailboxForIncidentRegistration(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxForIncidentRegistration_SLMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxForIncidentRegistrationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxForIncidentRegistrationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxForIncidentRegistration

	/// <summary>
	/// Почтовый ящик для регистрации обращений.
	/// </summary>
	public class MailboxForIncidentRegistration : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MailboxForIncidentRegistration(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxForIncidentRegistration";
		}

		public MailboxForIncidentRegistration(MailboxForIncidentRegistration source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Почтовый ящик.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private CaseCategory _category;
		/// <summary>
		/// Категория обращения.
		/// </summary>
		public CaseCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as CaseCategory);
			}
		}

		/// <summary>
		/// Название пересылки.
		/// </summary>
		public string AliasAddress {
			get {
				return GetTypedColumnValue<string>("AliasAddress");
			}
			set {
				SetColumnValue("AliasAddress", value);
			}
		}

		/// <summary>
		/// Всегда использовать язык почтового ящика.
		/// </summary>
		public bool UseMailboxLanguage {
			get {
				return GetTypedColumnValue<bool>("UseMailboxLanguage");
			}
			set {
				SetColumnValue("UseMailboxLanguage", value);
			}
		}

		/// <exclude/>
		public Guid MessageLanguageId {
			get {
				return GetTypedColumnValue<Guid>("MessageLanguageId");
			}
			set {
				SetColumnValue("MessageLanguageId", value);
				_messageLanguage = null;
			}
		}

		/// <exclude/>
		public string MessageLanguageName {
			get {
				return GetTypedColumnValue<string>("MessageLanguageName");
			}
			set {
				SetColumnValue("MessageLanguageName", value);
				if (_messageLanguage != null) {
					_messageLanguage.Name = value;
				}
			}
		}

		private SysLanguage _messageLanguage;
		/// <summary>
		/// Язык сообщений.
		/// </summary>
		public SysLanguage MessageLanguage {
			get {
				return _messageLanguage ??
					(_messageLanguage = LookupColumnEntities.GetEntity("MessageLanguage") as SysLanguage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxForIncidentRegistration_SLMEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxForIncidentRegistrationDeleted", e);
			Validating += (s, e) => ThrowEvent("MailboxForIncidentRegistrationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxForIncidentRegistration(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxForIncidentRegistration_SLMEventsProcess

	/// <exclude/>
	public partial class MailboxForIncidentRegistration_SLMEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MailboxForIncidentRegistration
	{

		public MailboxForIncidentRegistration_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxForIncidentRegistration_SLMEventsProcess";
			SchemaUId = new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("27347e94-29a6-4853-a0d4-73b525ba9a9c");
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

	#region Class: MailboxForIncidentRegistration_SLMEventsProcess

	/// <exclude/>
	public class MailboxForIncidentRegistration_SLMEventsProcess : MailboxForIncidentRegistration_SLMEventsProcess<MailboxForIncidentRegistration>
	{

		public MailboxForIncidentRegistration_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxForIncidentRegistration_SLMEventsProcess

	public partial class MailboxForIncidentRegistration_SLMEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: MailboxForIncidentRegistrationEventsProcess

	/// <exclude/>
	public class MailboxForIncidentRegistrationEventsProcess : MailboxForIncidentRegistration_SLMEventsProcess
	{

		public MailboxForIncidentRegistrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

