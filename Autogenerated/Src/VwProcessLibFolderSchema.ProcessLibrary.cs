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

	#region Class: VwProcessLibFolderSchema

	/// <exclude/>
	public class VwProcessLibFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public VwProcessLibFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessLibFolderSchema(VwProcessLibFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessLibFolderSchema(VwProcessLibFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			RealUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			Name = "VwProcessLibFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessLibFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessLibFolder_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessLibFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessLibFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibFolder

	/// <summary>
	/// Section folder - "Process library".
	/// </summary>
	public class VwProcessLibFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public VwProcessLibFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLibFolder";
		}

		public VwProcessLibFolder(VwProcessLibFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private VwProcessLibFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public VwProcessLibFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as VwProcessLibFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessLibFolder_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProcessLibFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProcessLibFolderInserting", e);
			Validating += (s, e) => ThrowEvent("VwProcessLibFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessLibFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwProcessLibFolder_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : VwProcessLibFolder
	{

		public VwProcessLibFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessLibFolder_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50341da6-8ff5-4041-b37f-bbe72d78a6d2");
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

	#region Class: VwProcessLibFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwProcessLibFolder_ProcessLibraryEventsProcess : VwProcessLibFolder_ProcessLibraryEventsProcess<VwProcessLibFolder>
	{

		public VwProcessLibFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessLibFolder_ProcessLibraryEventsProcess

	public partial class VwProcessLibFolder_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: VwProcessLibFolderEventsProcess

	/// <exclude/>
	public class VwProcessLibFolderEventsProcess : VwProcessLibFolder_ProcessLibraryEventsProcess
	{

		public VwProcessLibFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

