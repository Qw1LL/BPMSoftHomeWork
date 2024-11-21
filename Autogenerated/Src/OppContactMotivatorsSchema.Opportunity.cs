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

	#region Class: OppContactMotivators_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OppContactMotivators_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OppContactMotivators_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactMotivators_Opportunity_BPMSoftSchema(OppContactMotivators_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactMotivators_Opportunity_BPMSoftSchema(OppContactMotivators_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			RealUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			Name = "OppContactMotivators_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c9ccd90-06fc-4547-9eb4-c63723b2d23e")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c9ccd90-06fc-4547-9eb4-c63723b2d23e"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("d0771203-0cb0-4b03-9cea-20ae8f431e08"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6"),
				ModifiedInSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OppContactMotivators_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactMotivators_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactMotivators_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactMotivators_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivators_Opportunity_BPMSoft

	/// <summary>
	/// Мотиваторы контакта в продаже.
	/// </summary>
	public class OppContactMotivators_Opportunity_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OppContactMotivators_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactMotivators_Opportunity_BPMSoft";
		}

		public OppContactMotivators_Opportunity_BPMSoft(OppContactMotivators_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private OppContactMotivatType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public OppContactMotivatType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as OppContactMotivatType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactMotivators_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OppContactMotivators_Opportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OppContactMotivators_Opportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OppContactMotivators_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OppContactMotivators_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivators_OpportunityEventsProcess

	/// <exclude/>
	public partial class OppContactMotivators_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OppContactMotivators_Opportunity_BPMSoft
	{

		public OppContactMotivators_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactMotivators_OpportunityEventsProcess";
			SchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
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

	#region Class: OppContactMotivators_OpportunityEventsProcess

	/// <exclude/>
	public class OppContactMotivators_OpportunityEventsProcess : OppContactMotivators_OpportunityEventsProcess<OppContactMotivators_Opportunity_BPMSoft>
	{

		public OppContactMotivators_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactMotivators_OpportunityEventsProcess

	public partial class OppContactMotivators_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

