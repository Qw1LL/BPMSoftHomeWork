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

	#region Class: VwSysProcessInFolderSchema

	/// <exclude/>
	public class VwSysProcessInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public VwSysProcessInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessInFolderSchema(VwSysProcessInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessInFolderSchema(VwSysProcessInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484");
			RealUId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484");
			Name = "VwSysProcessInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3c49ef39-a850-47bb-ab17-bed6f4463bdf")) == null) {
				Columns.Add(CreateVwSysProcessColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("d2400815-883b-4b02-a4c7-baf3208d05b3");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateVwSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3c49ef39-a850-47bb-ab17-bed6f4463bdf"),
				Name = @"VwSysProcess",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484"),
				ModifiedInSchemaUId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484"),
				CreatedInPackageId = new Guid("47d9f451-70d6-4014-b0c9-4ad37a1eb8b7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcessInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessInFolder

	/// <summary>
	/// Process in folder (view).
	/// </summary>
	public class VwSysProcessInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public VwSysProcessInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessInFolder";
		}

		public VwSysProcessInFolder(VwSysProcessInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process (view).
		/// </summary>
		public Guid VwSysProcess {
			get {
				return GetTypedColumnValue<Guid>("VwSysProcess");
			}
			set {
				SetColumnValue("VwSysProcess", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysProcessInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysProcessInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysProcessInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysProcessInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysProcessInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysProcessInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcessInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : VwSysProcessInFolder
	{

		public VwSysProcessInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessInFolder_BaseEventsProcess";
			SchemaUId = new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d17c2fa-20b4-4f52-a620-928cbf98e484");
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

	#region Class: VwSysProcessInFolder_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcessInFolder_BaseEventsProcess : VwSysProcessInFolder_BaseEventsProcess<VwSysProcessInFolder>
	{

		public VwSysProcessInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessInFolder_BaseEventsProcess

	public partial class VwSysProcessInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessInFolderEventsProcess

	/// <exclude/>
	public class VwSysProcessInFolderEventsProcess : VwSysProcessInFolder_BaseEventsProcess
	{

		public VwSysProcessInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

