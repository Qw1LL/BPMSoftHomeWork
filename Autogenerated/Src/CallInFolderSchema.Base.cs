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

	#region Class: CallInFolderSchema

	/// <exclude/>
	public class CallInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public CallInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallInFolderSchema(CallInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallInFolderSchema(CallInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			RealUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			Name = "CallInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("861fce3b-3f00-4e31-a279-5d1e73575050")) == null) {
				Columns.Add(CreateCallColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("861fce3b-3f00-4e31-a279-5d1e73575050"),
				Name = @"Call",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df"),
				ModifiedInSchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CallInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df"));
		}

		#endregion

	}

	#endregion

	#region Class: CallInFolder

	/// <summary>
	/// Call in folder.
	/// </summary>
	public class CallInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public CallInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallInFolder";
		}

		public CallInFolder(CallInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CallId {
			get {
				return GetTypedColumnValue<Guid>("CallId");
			}
			set {
				SetColumnValue("CallId", value);
				_call = null;
			}
		}

		/// <exclude/>
		public string CallCaption {
			get {
				return GetTypedColumnValue<string>("CallCaption");
			}
			set {
				SetColumnValue("CallCaption", value);
				if (_call != null) {
					_call.Caption = value;
				}
			}
		}

		private Call _call;
		/// <summary>
		/// Call.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = LookupColumnEntities.GetEntity("Call") as Call);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CallInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("CallInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("CallInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CallInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class CallInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : CallInFolder
	{

		public CallInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallInFolder_BaseEventsProcess";
			SchemaUId = new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("387e7c64-c1cc-4e01-9ec2-5e3507ac35df");
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

	#region Class: CallInFolder_BaseEventsProcess

	/// <exclude/>
	public class CallInFolder_BaseEventsProcess : CallInFolder_BaseEventsProcess<CallInFolder>
	{

		public CallInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallInFolder_BaseEventsProcess

	public partial class CallInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallInFolderEventsProcess

	/// <exclude/>
	public class CallInFolderEventsProcess : CallInFolder_BaseEventsProcess
	{

		public CallInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

