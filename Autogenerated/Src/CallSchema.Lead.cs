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

	#region Class: Call_Lead_BPMSoftSchema

	/// <exclude/>
	public class Call_Lead_BPMSoftSchema : BPMSoft.Configuration.Call_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public Call_Lead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Call_Lead_BPMSoftSchema(Call_Lead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Call_Lead_BPMSoftSchema(Call_Lead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateICallCreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8f49136d-4605-4a5e-94bf-dec8cd6b8c60");
			index.Name = "ICallCreatedOn";
			index.CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fbd9727b-1533-41f4-b11a-e3e7a77a63e9"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fdb30b0c-2da8-49ce-80dc-2ca0628668c8");
			Name = "Call_Lead_BPMSoft";
			ParentSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			ExtendParent = true;
			CreatedInPackageId = new Guid("96386906-0220-46aa-a190-2514d5228612");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("02a029f7-23d2-4c19-86b8-0aa9b96fe246")) == null) {
				Columns.Add(CreateLeadColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("02a029f7-23d2-4c19-86b8-0aa9b96fe246"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fdb30b0c-2da8-49ce-80dc-2ca0628668c8"),
				ModifiedInSchemaUId = new Guid("fdb30b0c-2da8-49ce-80dc-2ca0628668c8"),
				CreatedInPackageId = new Guid("96386906-0220-46aa-a190-2514d5228612")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateICallCreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Call_Lead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Call_Lead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Call_Lead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fdb30b0c-2da8-49ce-80dc-2ca0628668c8"));
		}

		#endregion

	}

	#endregion

	#region Class: Call_Lead_BPMSoft

	/// <summary>
	/// Звонок.
	/// </summary>
	public class Call_Lead_BPMSoft : BPMSoft.Configuration.Call_Base_BPMSoft
	{

		#region Constructors: Public

		public Call_Lead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call_Lead_BPMSoft";
		}

		public Call_Lead_BPMSoft(Call_Lead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Call_Lead_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Call_Lead_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Call_Lead_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Call_Lead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_LeadEventsProcess

	/// <exclude/>
	public partial class Call_LeadEventsProcess<TEntity> : BPMSoft.Configuration.Call_BaseEventsProcess<TEntity> where TEntity : Call_Lead_BPMSoft
	{

		public Call_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_LeadEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fdb30b0c-2da8-49ce-80dc-2ca0628668c8");
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

	#region Class: Call_LeadEventsProcess

	/// <exclude/>
	public class Call_LeadEventsProcess : Call_LeadEventsProcess<Call_Lead_BPMSoft>
	{

		public Call_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_LeadEventsProcess

	public partial class Call_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

