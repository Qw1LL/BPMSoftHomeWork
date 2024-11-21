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

	#region Class: VwSysDcmLibFolderSchema

	/// <exclude/>
	public class VwSysDcmLibFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public VwSysDcmLibFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysDcmLibFolderSchema(VwSysDcmLibFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysDcmLibFolderSchema(VwSysDcmLibFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			RealUId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			Name = "VwSysDcmLibFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysDcmLibFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysDcmLibFolder_DcmDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysDcmLibFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysDcmLibFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("450fb78c-441c-4563-abb3-f7867c9400e2"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLibFolder

	/// <summary>
	/// Section folder - "DCM library".
	/// </summary>
	public class VwSysDcmLibFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public VwSysDcmLibFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysDcmLibFolder";
		}

		public VwSysDcmLibFolder(VwSysDcmLibFolder source)
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

		private VwSysDcmLibFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public VwSysDcmLibFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as VwSysDcmLibFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysDcmLibFolder_DcmDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysDcmLibFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSysDcmLibFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysDcmLibFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLibFolder_DcmDesignerEventsProcess

	/// <exclude/>
	public partial class VwSysDcmLibFolder_DcmDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : VwSysDcmLibFolder
	{

		public VwSysDcmLibFolder_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysDcmLibFolder_DcmDesignerEventsProcess";
			SchemaUId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
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

	#region Class: VwSysDcmLibFolder_DcmDesignerEventsProcess

	/// <exclude/>
	public class VwSysDcmLibFolder_DcmDesignerEventsProcess : VwSysDcmLibFolder_DcmDesignerEventsProcess<VwSysDcmLibFolder>
	{

		public VwSysDcmLibFolder_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysDcmLibFolder_DcmDesignerEventsProcess

	public partial class VwSysDcmLibFolder_DcmDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysDcmLibFolderEventsProcess

	/// <exclude/>
	public class VwSysDcmLibFolderEventsProcess : VwSysDcmLibFolder_DcmDesignerEventsProcess
	{

		public VwSysDcmLibFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

