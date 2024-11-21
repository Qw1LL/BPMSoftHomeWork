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

	#region Class: DocumentStatusSchema

	/// <exclude/>
	public class DocumentStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DocumentStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentStatusSchema(DocumentStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentStatusSchema(DocumentStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
			RealUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
			Name = "DocumentStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0d324e79-756f-4965-b549-df85c1130d5f")) == null) {
				Columns.Add(CreateFinalColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0d324e79-756f-4965-b549-df85c1130d5f"),
				Name = @"Final",
				CreatedInSchemaUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252"),
				ModifiedInSchemaUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DocumentStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentStatus_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentStatus

	/// <summary>
	/// Состояние документа (старое).
	/// </summary>
	public class DocumentStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DocumentStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentStatus";
		}

		public DocumentStatus(DocumentStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool Final {
			get {
				return GetTypedColumnValue<bool>("Final");
			}
			set {
				SetColumnValue("Final", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentStatus_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("DocumentStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("DocumentStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("DocumentStatusInserting", e);
			Saved += (s, e) => ThrowEvent("DocumentStatusSaved", e);
			Saving += (s, e) => ThrowEvent("DocumentStatusSaving", e);
			Validating += (s, e) => ThrowEvent("DocumentStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DocumentStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentStatus_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentStatus_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DocumentStatus
	{

		public DocumentStatus_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentStatus_DocumentEventsProcess";
			SchemaUId = new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d32d5914-e52f-40c6-a0eb-f80ef1d2e252");
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

	#region Class: DocumentStatus_DocumentEventsProcess

	/// <exclude/>
	public class DocumentStatus_DocumentEventsProcess : DocumentStatus_DocumentEventsProcess<DocumentStatus>
	{

		public DocumentStatus_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentStatus_DocumentEventsProcess

	public partial class DocumentStatus_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DocumentStatusEventsProcess

	/// <exclude/>
	public class DocumentStatusEventsProcess : DocumentStatus_DocumentEventsProcess
	{

		public DocumentStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

