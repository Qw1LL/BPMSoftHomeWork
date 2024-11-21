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

	#region Class: VwProcessLibInFolderSchema

	/// <exclude/>
	public class VwProcessLibInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public VwProcessLibInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessLibInFolderSchema(VwProcessLibInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessLibInFolderSchema(VwProcessLibInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			RealUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			Name = "VwProcessLibInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("88321d97-a1f0-4bf7-b6ef-fcf7a39306e2")) == null) {
				Columns.Add(CreateVwProcessLibColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateVwProcessLibColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("88321d97-a1f0-4bf7-b6ef-fcf7a39306e2"),
				Name = @"VwProcessLib",
				CreatedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a"),
				ModifiedInSchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a"),
				CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessLibInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessLibInFolder_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessLibInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessLibInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibInFolder

	/// <summary>
	/// "Process library" object in folder.
	/// </summary>
	public class VwProcessLibInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public VwProcessLibInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLibInFolder";
		}

		public VwProcessLibInFolder(VwProcessLibInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process library.
		/// </summary>
		public Guid VwProcessLib {
			get {
				return GetTypedColumnValue<Guid>("VwProcessLib");
			}
			set {
				SetColumnValue("VwProcessLib", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessLibInFolder_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProcessLibInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProcessLibInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("VwProcessLibInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessLibInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibInFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwProcessLibInFolder_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : VwProcessLibInFolder
	{

		public VwProcessLibInFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessLibInFolder_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("86aed0a7-3dc4-469a-a266-71b974dc4a6a");
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

	#region Class: VwProcessLibInFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwProcessLibInFolder_ProcessLibraryEventsProcess : VwProcessLibInFolder_ProcessLibraryEventsProcess<VwProcessLibInFolder>
	{

		public VwProcessLibInFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessLibInFolder_ProcessLibraryEventsProcess

	public partial class VwProcessLibInFolder_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessLibInFolderEventsProcess

	/// <exclude/>
	public class VwProcessLibInFolderEventsProcess : VwProcessLibInFolder_ProcessLibraryEventsProcess
	{

		public VwProcessLibInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

