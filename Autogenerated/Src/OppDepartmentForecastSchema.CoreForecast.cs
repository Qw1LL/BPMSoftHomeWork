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

	#region Class: OppDepartmentForecastSchema

	/// <exclude/>
	public class OppDepartmentForecastSchema : BPMSoft.Configuration.EntityInForecastCellSchema
	{

		#region Constructors: Public

		public OppDepartmentForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppDepartmentForecastSchema(OppDepartmentForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppDepartmentForecastSchema(OppDepartmentForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c88d3cda-460f-4c2c-a194-d7857df830af");
			RealUId = new Guid("c88d3cda-460f-4c2c-a194-d7857df830af");
			Name = "OppDepartmentForecast";
			ParentSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2f575a08-3870-413f-a2a0-8c6014b18dcc")) == null) {
				Columns.Add(CreateOpportunityDepartmentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2f575a08-3870-413f-a2a0-8c6014b18dcc"),
				Name = @"OpportunityDepartment",
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c88d3cda-460f-4c2c-a194-d7857df830af"),
				ModifiedInSchemaUId = new Guid("c88d3cda-460f-4c2c-a194-d7857df830af"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OppDepartmentForecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppDepartmentForecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppDepartmentForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppDepartmentForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c88d3cda-460f-4c2c-a194-d7857df830af"));
		}

		#endregion

	}

	#endregion

	#region Class: OppDepartmentForecast

	/// <summary>
	/// Планирование по подразделению.
	/// </summary>
	public class OppDepartmentForecast : BPMSoft.Configuration.EntityInForecastCell
	{

		#region Constructors: Public

		public OppDepartmentForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppDepartmentForecast";
		}

		public OppDepartmentForecast(OppDepartmentForecast source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityDepartmentId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityDepartmentId");
			}
			set {
				SetColumnValue("OpportunityDepartmentId", value);
				_opportunityDepartment = null;
			}
		}

		/// <exclude/>
		public string OpportunityDepartmentName {
			get {
				return GetTypedColumnValue<string>("OpportunityDepartmentName");
			}
			set {
				SetColumnValue("OpportunityDepartmentName", value);
				if (_opportunityDepartment != null) {
					_opportunityDepartment.Name = value;
				}
			}
		}

		private OpportunityDepartment _opportunityDepartment;
		/// <summary>
		/// Подразделение.
		/// </summary>
		public OpportunityDepartment OpportunityDepartment {
			get {
				return _opportunityDepartment ??
					(_opportunityDepartment = LookupColumnEntities.GetEntity("OpportunityDepartment") as OpportunityDepartment);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppDepartmentForecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("OppDepartmentForecastInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OppDepartmentForecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppDepartmentForecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class OppDepartmentForecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.EntityInForecastCell_CoreForecastEventsProcess<TEntity> where TEntity : OppDepartmentForecast
	{

		public OppDepartmentForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppDepartmentForecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("c88d3cda-460f-4c2c-a194-d7857df830af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c88d3cda-460f-4c2c-a194-d7857df830af");
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

	#region Class: OppDepartmentForecast_CoreForecastEventsProcess

	/// <exclude/>
	public class OppDepartmentForecast_CoreForecastEventsProcess : OppDepartmentForecast_CoreForecastEventsProcess<OppDepartmentForecast>
	{

		public OppDepartmentForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppDepartmentForecast_CoreForecastEventsProcess

	public partial class OppDepartmentForecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppDepartmentForecastEventsProcess

	/// <exclude/>
	public class OppDepartmentForecastEventsProcess : OppDepartmentForecast_CoreForecastEventsProcess
	{

		public OppDepartmentForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

