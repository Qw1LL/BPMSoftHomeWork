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

	#region Class: CallFileSchema

	/// <exclude/>
	public class CallFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CallFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallFileSchema(CallFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallFileSchema(CallFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			RealUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			Name = "CallFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c1234fc6-f628-458a-87ff-feace83a63ca")) == null) {
				Columns.Add(CreateCallColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c1234fc6-f628-458a-87ff-feace83a63ca"),
				Name = @"Call",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166"),
				ModifiedInSchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166"),
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
			return new CallFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5956808f-648a-428e-be89-f2dd71f98166"));
		}

		#endregion

	}

	#endregion

	#region Class: CallFile

	/// <summary>
	/// Call attachment.
	/// </summary>
	public class CallFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public CallFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallFile";
		}

		public CallFile(CallFile source)
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
			var process = new CallFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("CallFileInserting", e);
			Updated += (s, e) => ThrowEvent("CallFileUpdated", e);
			Validating += (s, e) => ThrowEvent("CallFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CallFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallFile_BaseEventsProcess

	/// <exclude/>
	public partial class CallFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : CallFile
	{

		public CallFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallFile_BaseEventsProcess";
			SchemaUId = new Guid("5956808f-648a-428e-be89-f2dd71f98166");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5956808f-648a-428e-be89-f2dd71f98166");
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

	#region Class: CallFile_BaseEventsProcess

	/// <exclude/>
	public class CallFile_BaseEventsProcess : CallFile_BaseEventsProcess<CallFile>
	{

		public CallFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallFile_BaseEventsProcess

	public partial class CallFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallFileEventsProcess

	/// <exclude/>
	public class CallFileEventsProcess : CallFile_BaseEventsProcess
	{

		public CallFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

