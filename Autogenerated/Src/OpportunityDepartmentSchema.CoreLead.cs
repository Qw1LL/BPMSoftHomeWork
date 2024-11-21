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

	#region Class: OpportunityDepartmentSchema

	/// <exclude/>
	public class OpportunityDepartmentSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityDepartmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityDepartmentSchema(OpportunityDepartmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityDepartmentSchema(OpportunityDepartmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			RealUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			Name = "OpportunityDepartment";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5dc3e9fe-4683-488c-8151-b6ad92164a63")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e5b2fbc9-3939-43d2-8443-aa5c9b863253")) == null) {
				Columns.Add(CreateSalesDirectorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			column.CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5dc3e9fe-4683-488c-8151-b6ad92164a63"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected virtual EntitySchemaColumn CreateSalesDirectorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e5b2fbc9-3939-43d2-8443-aa5c9b863253"),
				Name = @"SalesDirector",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				ModifiedInSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityDepartment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityDepartment_CoreLeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityDepartmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityDepartmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityDepartment

	/// <summary>
	/// Направление в продаже.
	/// </summary>
	public class OpportunityDepartment : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityDepartment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityDepartment";
		}

		public OpportunityDepartment(OpportunityDepartment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// Группа пользователей.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid SalesDirectorId {
			get {
				return GetTypedColumnValue<Guid>("SalesDirectorId");
			}
			set {
				SetColumnValue("SalesDirectorId", value);
				_salesDirector = null;
			}
		}

		/// <exclude/>
		public string SalesDirectorName {
			get {
				return GetTypedColumnValue<string>("SalesDirectorName");
			}
			set {
				SetColumnValue("SalesDirectorName", value);
				if (_salesDirector != null) {
					_salesDirector.Name = value;
				}
			}
		}

		private Contact _salesDirector;
		/// <summary>
		/// Руководитель.
		/// </summary>
		public Contact SalesDirector {
			get {
				return _salesDirector ??
					(_salesDirector = LookupColumnEntities.GetEntity("SalesDirector") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityDepartment_CoreLeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityDepartmentDeleted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityDepartmentInserting", e);
			Validating += (s, e) => ThrowEvent("OpportunityDepartmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityDepartment(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityDepartment_CoreLeadEventsProcess

	/// <exclude/>
	public partial class OpportunityDepartment_CoreLeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityDepartment
	{

		public OpportunityDepartment_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityDepartment_CoreLeadEventsProcess";
			SchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0");
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

	#region Class: OpportunityDepartment_CoreLeadEventsProcess

	/// <exclude/>
	public class OpportunityDepartment_CoreLeadEventsProcess : OpportunityDepartment_CoreLeadEventsProcess<OpportunityDepartment>
	{

		public OpportunityDepartment_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityDepartment_CoreLeadEventsProcess

	public partial class OpportunityDepartment_CoreLeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityDepartmentEventsProcess

	/// <exclude/>
	public class OpportunityDepartmentEventsProcess : OpportunityDepartment_CoreLeadEventsProcess
	{

		public OpportunityDepartmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

