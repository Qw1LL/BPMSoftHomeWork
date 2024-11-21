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

	#region Class: SysModuleFolderModeSchema

	/// <exclude/>
	public class SysModuleFolderModeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleFolderModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleFolderModeSchema(SysModuleFolderModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleFolderModeSchema(SysModuleFolderModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b");
			RealUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b");
			Name = "SysModuleFolderMode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("08025b84-2e5a-43dd-b158-1a02fffb6400")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9066965f-535b-469d-b60b-b2e2e91054a1"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"),
				ModifiedInSchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("08025b84-2e5a-43dd-b158-1a02fffb6400"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"),
				ModifiedInSchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleFolderMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleFolderMode_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleFolderModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleFolderModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleFolderMode

	/// <summary>
	/// Section folders mode.
	/// </summary>
	public class SysModuleFolderMode : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleFolderMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleFolderMode";
		}

		public SysModuleFolderMode(SysModuleFolderMode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleFolderMode_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleFolderModeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleFolderModeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleFolderModeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleFolderModeInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleFolderModeSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleFolderModeSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleFolderModeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleFolderMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleFolderMode_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleFolderMode_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleFolderMode
	{

		public SysModuleFolderMode_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleFolderMode_BaseEventsProcess";
			SchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b");
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

	#region Class: SysModuleFolderMode_BaseEventsProcess

	/// <exclude/>
	public class SysModuleFolderMode_BaseEventsProcess : SysModuleFolderMode_BaseEventsProcess<SysModuleFolderMode>
	{

		public SysModuleFolderMode_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleFolderMode_BaseEventsProcess

	public partial class SysModuleFolderMode_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleFolderModeEventsProcess

	/// <exclude/>
	public class SysModuleFolderModeEventsProcess : SysModuleFolderMode_BaseEventsProcess
	{

		public SysModuleFolderModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

