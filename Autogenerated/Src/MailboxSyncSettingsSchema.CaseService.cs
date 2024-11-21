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

	#region Class: MailboxSyncSettingsSchema

	/// <exclude/>
	public class MailboxSyncSettingsSchema : BPMSoft.Configuration.MailboxSyncSettings_ExchangeListener_BPMSoftSchema
	{

		#region Constructors: Public

		public MailboxSyncSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxSyncSettingsSchema(MailboxSyncSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxSyncSettingsSchema(MailboxSyncSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ac8c9f06-5246-4e89-9138-fd1290a80344");
			Name = "MailboxSyncSettings";
			ParentSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			ExtendParent = true;
			CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3b904cdb-75c1-4c56-89ed-aaf18f956a91")) == null) {
				Columns.Add(CreateMessageLanguageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3b904cdb-75c1-4c56-89ed-aaf18f956a91"),
				Name = @"MessageLanguage",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac8c9f06-5246-4e89-9138-fd1290a80344"),
				ModifiedInSchemaUId = new Guid("ac8c9f06-5246-4e89-9138-fd1290a80344"),
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
			return new MailboxSyncSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxSyncSettings_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxSyncSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxSyncSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac8c9f06-5246-4e89-9138-fd1290a80344"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings

	/// <summary>
	/// Настройки синхронизации с почтовым ящиком.
	/// </summary>
	public class MailboxSyncSettings : BPMSoft.Configuration.MailboxSyncSettings_ExchangeListener_BPMSoft
	{

		#region Constructors: Public

		public MailboxSyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSyncSettings";
		}

		public MailboxSyncSettings(MailboxSyncSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Язык общения.
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
			var process = new MailboxSyncSettings_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxSyncSettingsDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxSyncSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_CaseServiceEventsProcess

	/// <exclude/>
	public partial class MailboxSyncSettings_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.MailboxSyncSettings_ExchangeListenerEventsProcess<TEntity> where TEntity : MailboxSyncSettings
	{

		public MailboxSyncSettings_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxSyncSettings_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ac8c9f06-5246-4e89-9138-fd1290a80344");
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

	#region Class: MailboxSyncSettings_CaseServiceEventsProcess

	/// <exclude/>
	public class MailboxSyncSettings_CaseServiceEventsProcess : MailboxSyncSettings_CaseServiceEventsProcess<MailboxSyncSettings>
	{

		public MailboxSyncSettings_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxSyncSettings_CaseServiceEventsProcess

	public partial class MailboxSyncSettings_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailboxSyncSettingsEventsProcess

	/// <exclude/>
	public class MailboxSyncSettingsEventsProcess : MailboxSyncSettings_CaseServiceEventsProcess
	{

		public MailboxSyncSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

