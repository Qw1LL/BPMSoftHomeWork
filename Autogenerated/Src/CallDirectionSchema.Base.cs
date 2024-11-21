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

	#region Class: CallDirectionSchema

	/// <exclude/>
	public class CallDirectionSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public CallDirectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallDirectionSchema(CallDirectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallDirectionSchema(CallDirectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			RealUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			Name = "CallDirection";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
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
			return new CallDirection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallDirection_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallDirectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallDirectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e"));
		}

		#endregion

	}

	#endregion

	#region Class: CallDirection

	/// <summary>
	/// Call direction.
	/// </summary>
	public class CallDirection : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public CallDirection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallDirection";
		}

		public CallDirection(CallDirection source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CallDirection_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallDirectionDeleted", e);
			Inserting += (s, e) => ThrowEvent("CallDirectionInserting", e);
			Validating += (s, e) => ThrowEvent("CallDirectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CallDirection(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallDirection_BaseEventsProcess

	/// <exclude/>
	public partial class CallDirection_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : CallDirection
	{

		public CallDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallDirection_BaseEventsProcess";
			SchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e");
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

	#region Class: CallDirection_BaseEventsProcess

	/// <exclude/>
	public class CallDirection_BaseEventsProcess : CallDirection_BaseEventsProcess<CallDirection>
	{

		public CallDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallDirection_BaseEventsProcess

	public partial class CallDirection_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallDirectionEventsProcess

	/// <exclude/>
	public class CallDirectionEventsProcess : CallDirection_BaseEventsProcess
	{

		public CallDirectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

