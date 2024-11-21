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

	#region Class: DocumentParticipantSchema

	/// <exclude/>
	public class DocumentParticipantSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DocumentParticipantSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentParticipantSchema(DocumentParticipantSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentParticipantSchema(DocumentParticipantSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0");
			RealUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0");
			Name = "DocumentParticipant";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c43ba7b-79cc-460e-9a9d-35ef87439847")) == null) {
				Columns.Add(CreateDocumentColumn());
			}
			if (Columns.FindByUId(new Guid("c84e02cb-2105-46be-9d38-be0b57af4c7c")) == null) {
				Columns.Add(CreateParticipantColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDocumentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c43ba7b-79cc-460e-9a9d-35ef87439847"),
				Name = @"Document",
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0"),
				ModifiedInSchemaUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateParticipantColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("c84e02cb-2105-46be-9d38-be0b57af4c7c"),
				Name = @"Participant",
				CreatedInSchemaUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0"),
				ModifiedInSchemaUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DocumentParticipant(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentParticipant_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentParticipantSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentParticipantSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentParticipant

	/// <summary>
	/// Участник.
	/// </summary>
	public class DocumentParticipant : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DocumentParticipant(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentParticipant";
		}

		public DocumentParticipant(DocumentParticipant source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DocumentId {
			get {
				return GetTypedColumnValue<Guid>("DocumentId");
			}
			set {
				SetColumnValue("DocumentId", value);
				_document = null;
			}
		}

		/// <exclude/>
		public string DocumentNumber {
			get {
				return GetTypedColumnValue<string>("DocumentNumber");
			}
			set {
				SetColumnValue("DocumentNumber", value);
				if (_document != null) {
					_document.Number = value;
				}
			}
		}

		private Document _document;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document Document {
			get {
				return _document ??
					(_document = LookupColumnEntities.GetEntity("Document") as Document);
			}
		}

		/// <summary>
		/// Участник.
		/// </summary>
		public string Participant {
			get {
				return GetTypedColumnValue<string>("Participant");
			}
			set {
				SetColumnValue("Participant", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentParticipant_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentParticipantDeleted", e);
			Deleting += (s, e) => ThrowEvent("DocumentParticipantDeleting", e);
			Inserted += (s, e) => ThrowEvent("DocumentParticipantInserted", e);
			Inserting += (s, e) => ThrowEvent("DocumentParticipantInserting", e);
			Saved += (s, e) => ThrowEvent("DocumentParticipantSaved", e);
			Saving += (s, e) => ThrowEvent("DocumentParticipantSaving", e);
			Validating += (s, e) => ThrowEvent("DocumentParticipantValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DocumentParticipant(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentParticipant_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentParticipant_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DocumentParticipant
	{

		public DocumentParticipant_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentParticipant_DocumentEventsProcess";
			SchemaUId = new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2e9de321-f7f2-48cf-b99e-3d4d12f1a7b0");
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

	#region Class: DocumentParticipant_DocumentEventsProcess

	/// <exclude/>
	public class DocumentParticipant_DocumentEventsProcess : DocumentParticipant_DocumentEventsProcess<DocumentParticipant>
	{

		public DocumentParticipant_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentParticipant_DocumentEventsProcess

	public partial class DocumentParticipant_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DocumentParticipantEventsProcess

	/// <exclude/>
	public class DocumentParticipantEventsProcess : DocumentParticipant_DocumentEventsProcess
	{

		public DocumentParticipantEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

