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

	#region Class: CallFolder_Base_BPMSoftSchema

	/// <exclude/>
	public class CallFolder_Base_BPMSoftSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public CallFolder_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallFolder_Base_BPMSoftSchema(CallFolder_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallFolder_Base_BPMSoftSchema(CallFolder_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			RealUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			Name = "CallFolder_Base_BPMSoft";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CallFolder_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallFolder_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallFolder_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b"));
		}

		#endregion

	}

	#endregion

	#region Class: CallFolder_Base_BPMSoft

	/// <summary>
	/// Call folder.
	/// </summary>
	public class CallFolder_Base_BPMSoft : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public CallFolder_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallFolder_Base_BPMSoft";
		}

		public CallFolder_Base_BPMSoft(CallFolder_Base_BPMSoft source)
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

		private CallFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public CallFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as CallFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CallFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallFolder_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("CallFolder_Base_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("CallFolder_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CallFolder_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallFolder_BaseEventsProcess

	/// <exclude/>
	public partial class CallFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : CallFolder_Base_BPMSoft
	{

		public CallFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallFolder_BaseEventsProcess";
			SchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
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

	#region Class: CallFolder_BaseEventsProcess

	/// <exclude/>
	public class CallFolder_BaseEventsProcess : CallFolder_BaseEventsProcess<CallFolder_Base_BPMSoft>
	{

		public CallFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallFolder_BaseEventsProcess

	public partial class CallFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion

}

