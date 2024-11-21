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

	#region Class: ExternalAccessFolderSchema

	/// <exclude/>
	public class ExternalAccessFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public ExternalAccessFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessFolderSchema(ExternalAccessFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessFolderSchema(ExternalAccessFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			RealUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			Name = "ExternalAccessFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("386ac9f6-07c1-4d11-8d16-e4e9424ba4e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessFolder_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessFolder

	/// <summary>
	/// External access folder.
	/// </summary>
	public class ExternalAccessFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public ExternalAccessFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessFolder";
		}

		public ExternalAccessFolder(ExternalAccessFolder source)
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

		private ExternalAccessFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public ExternalAccessFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ExternalAccessFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessFolder_ExternalAccessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ExternalAccessFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessFolder_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessFolder_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : ExternalAccessFolder
	{

		public ExternalAccessFolder_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessFolder_ExternalAccessEventsProcess";
			SchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
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

	#region Class: ExternalAccessFolder_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessFolder_ExternalAccessEventsProcess : ExternalAccessFolder_ExternalAccessEventsProcess<ExternalAccessFolder>
	{

		public ExternalAccessFolder_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessFolder_ExternalAccessEventsProcess

	public partial class ExternalAccessFolder_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessFolderEventsProcess

	/// <exclude/>
	public class ExternalAccessFolderEventsProcess : ExternalAccessFolder_ExternalAccessEventsProcess
	{

		public ExternalAccessFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

