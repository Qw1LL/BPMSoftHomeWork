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

	#region Class: Document_DocumentInOpportunity_BPMSoftSchema

	/// <exclude/>
	public class Document_DocumentInOpportunity_BPMSoftSchema : BPMSoft.Configuration.Document_DocumentInProject_BPMSoftSchema
	{

		#region Constructors: Public

		public Document_DocumentInOpportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Document_DocumentInOpportunity_BPMSoftSchema(Document_DocumentInOpportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Document_DocumentInOpportunity_BPMSoftSchema(Document_DocumentInOpportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2ab1b8dd-d9b4-4393-9994-00f5a9233a91");
			Name = "Document_DocumentInOpportunity_BPMSoft";
			ParentSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6609fecb-0611-4043-b793-9364d39c2783");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d9e3320f-e365-4069-b345-3b3ec6adf04c")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d9e3320f-e365-4069-b345-3b3ec6adf04c"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2ab1b8dd-d9b4-4393-9994-00f5a9233a91"),
				ModifiedInSchemaUId = new Guid("2ab1b8dd-d9b4-4393-9994-00f5a9233a91"),
				CreatedInPackageId = new Guid("6609fecb-0611-4043-b793-9364d39c2783")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Document_DocumentInOpportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Document_DocumentInOpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Document_DocumentInOpportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Document_DocumentInOpportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2ab1b8dd-d9b4-4393-9994-00f5a9233a91"));
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInOpportunity_BPMSoft

	/// <summary>
	/// Документ.
	/// </summary>
	public class Document_DocumentInOpportunity_BPMSoft : BPMSoft.Configuration.Document_DocumentInProject_BPMSoft
	{

		#region Constructors: Public

		public Document_DocumentInOpportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Document_DocumentInOpportunity_BPMSoft";
		}

		public Document_DocumentInOpportunity_BPMSoft(Document_DocumentInOpportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Document_DocumentInOpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Document_DocumentInOpportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Document_DocumentInOpportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Document_DocumentInOpportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Document_DocumentInOpportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInOpportunityEventsProcess

	/// <exclude/>
	public partial class Document_DocumentInOpportunityEventsProcess<TEntity> : BPMSoft.Configuration.Document_DocumentInProjectEventsProcess<TEntity> where TEntity : Document_DocumentInOpportunity_BPMSoft
	{

		public Document_DocumentInOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Document_DocumentInOpportunityEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2ab1b8dd-d9b4-4393-9994-00f5a9233a91");
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

	#region Class: Document_DocumentInOpportunityEventsProcess

	/// <exclude/>
	public class Document_DocumentInOpportunityEventsProcess : Document_DocumentInOpportunityEventsProcess<Document_DocumentInOpportunity_BPMSoft>
	{

		public Document_DocumentInOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Document_DocumentInOpportunityEventsProcess

	public partial class Document_DocumentInOpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

