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

	#region Class: Call_CaseService_BPMSoftSchema

	/// <exclude/>
	public class Call_CaseService_BPMSoftSchema : BPMSoft.Configuration.Call_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public Call_CaseService_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Call_CaseService_BPMSoftSchema(Call_CaseService_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Call_CaseService_BPMSoftSchema(Call_CaseService_BPMSoftSchema source)
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
			RealUId = new Guid("577a8217-3cfc-4b88-b23e-c96a69336590");
			Name = "Call_CaseService_BPMSoft";
			ParentSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			ExtendParent = true;
			CreatedInPackageId = new Guid("30de0e3b-0a22-4b21-aec2-eb5dee3a342f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("16ce91c0-7761-4db6-88a3-f1d9ae4c34dc")) == null) {
				Columns.Add(CreateCaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16ce91c0-7761-4db6-88a3-f1d9ae4c34dc"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("577a8217-3cfc-4b88-b23e-c96a69336590"),
				ModifiedInSchemaUId = new Guid("577a8217-3cfc-4b88-b23e-c96a69336590"),
				CreatedInPackageId = new Guid("30de0e3b-0a22-4b21-aec2-eb5dee3a342f")
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
			return new Call_CaseService_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Call_CaseService_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Call_CaseService_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("577a8217-3cfc-4b88-b23e-c96a69336590"));
		}

		#endregion

	}

	#endregion

	#region Class: Call_CaseService_BPMSoft

	/// <summary>
	/// Звонок.
	/// </summary>
	public class Call_CaseService_BPMSoft : BPMSoft.Configuration.Call_Lead_BPMSoft
	{

		#region Constructors: Public

		public Call_CaseService_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call_CaseService_BPMSoft";
		}

		public Call_CaseService_BPMSoft(Call_CaseService_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Call_CaseService_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Call_CaseService_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Call_CaseService_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_CaseServiceEventsProcess

	/// <exclude/>
	public partial class Call_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.Call_LeadEventsProcess<TEntity> where TEntity : Call_CaseService_BPMSoft
	{

		public Call_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("577a8217-3cfc-4b88-b23e-c96a69336590");
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

	#region Class: Call_CaseServiceEventsProcess

	/// <exclude/>
	public class Call_CaseServiceEventsProcess : Call_CaseServiceEventsProcess<Call_CaseService_BPMSoft>
	{

		public Call_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_CaseServiceEventsProcess

	public partial class Call_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

