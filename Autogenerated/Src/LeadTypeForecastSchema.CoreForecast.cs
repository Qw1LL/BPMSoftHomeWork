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

	#region Class: LeadTypeForecastSchema

	/// <exclude/>
	public class LeadTypeForecastSchema : BPMSoft.Configuration.EntityInForecastCellSchema
	{

		#region Constructors: Public

		public LeadTypeForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadTypeForecastSchema(LeadTypeForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadTypeForecastSchema(LeadTypeForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5");
			RealUId = new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5");
			Name = "LeadTypeForecast";
			ParentSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1efd0e2b-3d75-47d5-a126-8bdd9a2b1fdd")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1efd0e2b-3d75-47d5-a126-8bdd9a2b1fdd"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5"),
				ModifiedInSchemaUId = new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5"),
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
			return new LeadTypeForecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadTypeForecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadTypeForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadTypeForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeForecast

	/// <summary>
	/// Планирование по потребностям.
	/// </summary>
	public class LeadTypeForecast : BPMSoft.Configuration.EntityInForecastCell
	{

		#region Constructors: Public

		public LeadTypeForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadTypeForecast";
		}

		public LeadTypeForecast(LeadTypeForecast source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadTypeForecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("LeadTypeForecastInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadTypeForecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeForecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class LeadTypeForecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.EntityInForecastCell_CoreForecastEventsProcess<TEntity> where TEntity : LeadTypeForecast
	{

		public LeadTypeForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadTypeForecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dba8758c-3f3e-4df2-83c7-dec4ef8e22d5");
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

	#region Class: LeadTypeForecast_CoreForecastEventsProcess

	/// <exclude/>
	public class LeadTypeForecast_CoreForecastEventsProcess : LeadTypeForecast_CoreForecastEventsProcess<LeadTypeForecast>
	{

		public LeadTypeForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadTypeForecast_CoreForecastEventsProcess

	public partial class LeadTypeForecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadTypeForecastEventsProcess

	/// <exclude/>
	public class LeadTypeForecastEventsProcess : LeadTypeForecast_CoreForecastEventsProcess
	{

		public LeadTypeForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

