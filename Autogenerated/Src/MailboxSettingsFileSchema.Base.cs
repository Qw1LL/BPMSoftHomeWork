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

	#region Class: MailboxSettingsFileSchema

	/// <exclude/>
	public class MailboxSettingsFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public MailboxSettingsFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxSettingsFileSchema(MailboxSettingsFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxSettingsFileSchema(MailboxSettingsFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3");
			RealUId = new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3");
			Name = "MailboxSettingsFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5fc4e2a4-a26d-4f80-8139-9ad09f5627da")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5fc4e2a4-a26d-4f80-8139-9ad09f5627da"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3"),
				ModifiedInSchemaUId = new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailboxSettingsFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxSettingsFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxSettingsFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxSettingsFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSettingsFile

	/// <summary>
	/// File and link of mailbox synchronization settings.
	/// </summary>
	public class MailboxSettingsFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public MailboxSettingsFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSettingsFile";
		}

		public MailboxSettingsFile(MailboxSettingsFile source)
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
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxSettingsFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxSettingsFileDeleted", e);
			Updated += (s, e) => ThrowEvent("MailboxSettingsFileUpdated", e);
			Validating += (s, e) => ThrowEvent("MailboxSettingsFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxSettingsFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSettingsFile_BaseEventsProcess

	/// <exclude/>
	public partial class MailboxSettingsFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : MailboxSettingsFile
	{

		public MailboxSettingsFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxSettingsFile_BaseEventsProcess";
			SchemaUId = new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1e6627f4-a981-4c60-9a12-3e193b92c0a3");
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

	#region Class: MailboxSettingsFile_BaseEventsProcess

	/// <exclude/>
	public class MailboxSettingsFile_BaseEventsProcess : MailboxSettingsFile_BaseEventsProcess<MailboxSettingsFile>
	{

		public MailboxSettingsFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxSettingsFile_BaseEventsProcess

	public partial class MailboxSettingsFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailboxSettingsFileEventsProcess

	/// <exclude/>
	public class MailboxSettingsFileEventsProcess : MailboxSettingsFile_BaseEventsProcess
	{

		public MailboxSettingsFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

