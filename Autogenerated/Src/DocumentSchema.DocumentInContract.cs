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

	#region Class: DocumentSchema

	/// <exclude/>
	public class DocumentSchema : BPMSoft.Configuration.Document_DocumentInOpportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public DocumentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentSchema(DocumentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentSchema(DocumentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("05ec5c8c-fd85-418e-8d4a-95cd4f8b1f77");
			Name = "Document";
			ParentSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7f2d0fd0-8147-4292-af7e-8927e24f9683");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2eb5cfde-2a75-43fa-a3d0-cbea861f2a81")) == null) {
				Columns.Add(CreateContractColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContractColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2eb5cfde-2a75-43fa-a3d0-cbea861f2a81"),
				Name = @"Contract",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("05ec5c8c-fd85-418e-8d4a-95cd4f8b1f77"),
				ModifiedInSchemaUId = new Guid("05ec5c8c-fd85-418e-8d4a-95cd4f8b1f77"),
				CreatedInPackageId = new Guid("7f2d0fd0-8147-4292-af7e-8927e24f9683")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Document(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Document_DocumentInContractEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("05ec5c8c-fd85-418e-8d4a-95cd4f8b1f77"));
		}

		#endregion

	}

	#endregion

	#region Class: Document

	/// <summary>
	/// Документ.
	/// </summary>
	public class Document : BPMSoft.Configuration.Document_DocumentInOpportunity_BPMSoft
	{

		#region Constructors: Public

		public Document(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Document";
		}

		public Document(Document source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = LookupColumnEntities.GetEntity("Contract") as Contract);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Document_DocumentInContractEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentDeleted", e);
			Validating += (s, e) => ThrowEvent("DocumentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Document(this);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInContractEventsProcess

	/// <exclude/>
	public partial class Document_DocumentInContractEventsProcess<TEntity> : BPMSoft.Configuration.Document_DocumentInOpportunityEventsProcess<TEntity> where TEntity : Document
	{

		public Document_DocumentInContractEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Document_DocumentInContractEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("05ec5c8c-fd85-418e-8d4a-95cd4f8b1f77");
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

	#region Class: Document_DocumentInContractEventsProcess

	/// <exclude/>
	public class Document_DocumentInContractEventsProcess : Document_DocumentInContractEventsProcess<Document>
	{

		public Document_DocumentInContractEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Document_DocumentInContractEventsProcess

	public partial class Document_DocumentInContractEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DocumentEventsProcess

	/// <exclude/>
	public class DocumentEventsProcess : Document_DocumentInContractEventsProcess
	{

		public DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

