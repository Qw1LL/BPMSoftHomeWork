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

	#region Class: SysProcessLogInFolderSchema

	/// <exclude/>
	public class SysProcessLogInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SysProcessLogInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessLogInFolderSchema(SysProcessLogInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessLogInFolderSchema(SysProcessLogInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a");
			RealUId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a");
			Name = "SysProcessLogInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("baa961ed-501d-4b28-be33-9d3cd4d64fd4")) == null) {
				Columns.Add(CreateSysProcessLogColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysProcessLogColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("baa961ed-501d-4b28-be33-9d3cd4d64fd4"),
				Name = @"SysProcessLog",
				ReferenceSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a"),
				ModifiedInSchemaUId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessLogInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessLogInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessLogInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessLogInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLogInFolder

	/// <summary>
	/// Process in folder.
	/// </summary>
	public class SysProcessLogInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SysProcessLogInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessLogInFolder";
		}

		public SysProcessLogInFolder(SysProcessLogInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessLogId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessLogId");
			}
			set {
				SetColumnValue("SysProcessLogId", value);
				_sysProcessLog = null;
			}
		}

		/// <exclude/>
		public string SysProcessLogName {
			get {
				return GetTypedColumnValue<string>("SysProcessLogName");
			}
			set {
				SetColumnValue("SysProcessLogName", value);
				if (_sysProcessLog != null) {
					_sysProcessLog.Name = value;
				}
			}
		}

		private SysProcessLog _sysProcessLog;
		/// <summary>
		/// Process log.
		/// </summary>
		public SysProcessLog SysProcessLog {
			get {
				return _sysProcessLog ??
					(_sysProcessLog = LookupColumnEntities.GetEntity("SysProcessLog") as SysProcessLog);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessLogInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessLogInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessLogInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessLogInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessLogInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessLogInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessLogInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessLogInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessLogInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLogInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessLogInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SysProcessLogInFolder
	{

		public SysProcessLogInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessLogInFolder_BaseEventsProcess";
			SchemaUId = new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3fafe3e9-14d7-4359-8924-4a1ee15fcc3a");
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

	#region Class: SysProcessLogInFolder_BaseEventsProcess

	/// <exclude/>
	public class SysProcessLogInFolder_BaseEventsProcess : SysProcessLogInFolder_BaseEventsProcess<SysProcessLogInFolder>
	{

		public SysProcessLogInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessLogInFolder_BaseEventsProcess

	public partial class SysProcessLogInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessLogInFolderEventsProcess

	/// <exclude/>
	public class SysProcessLogInFolderEventsProcess : SysProcessLogInFolder_BaseEventsProcess
	{

		public SysProcessLogInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

