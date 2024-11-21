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

	#region Class: LookupFolderSchema

	/// <exclude/>
	public class LookupFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public LookupFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LookupFolderSchema(LookupFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LookupFolderSchema(LookupFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			RealUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			Name = "LookupFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LookupFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LookupFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LookupFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LookupFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651"));
		}

		#endregion

	}

	#endregion

	#region Class: LookupFolder

	/// <summary>
	/// Section folder - "Lookup".
	/// </summary>
	public class LookupFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public LookupFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LookupFolder";
		}

		public LookupFolder(LookupFolder source)
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

		private LookupFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public LookupFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as LookupFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LookupFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LookupFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("LookupFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LookupFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: LookupFolder_BaseEventsProcess

	/// <exclude/>
	public partial class LookupFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : LookupFolder
	{

		public LookupFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LookupFolder_BaseEventsProcess";
			SchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
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

	#region Class: LookupFolder_BaseEventsProcess

	/// <exclude/>
	public class LookupFolder_BaseEventsProcess : LookupFolder_BaseEventsProcess<LookupFolder>
	{

		public LookupFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LookupFolder_BaseEventsProcess

	public partial class LookupFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: LookupFolderEventsProcess

	/// <exclude/>
	public class LookupFolderEventsProcess : LookupFolder_BaseEventsProcess
	{

		public LookupFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

