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

	#region Class: SysAdminUnitInWorkplaceSchema

	/// <exclude/>
	public class SysAdminUnitInWorkplaceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminUnitInWorkplaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitInWorkplaceSchema(SysAdminUnitInWorkplaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitInWorkplaceSchema(SysAdminUnitInWorkplaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			RealUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			Name = "SysAdminUnitInWorkplace";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d5cfaf4a-0900-4ef9-aee8-2ede7f9d97fb")) == null) {
				Columns.Add(CreateSysWorkplaceColumn());
			}
			if (Columns.FindByUId(new Guid("b96bb4ca-a133-44f1-aa7d-24495d89e278")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysWorkplaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5cfaf4a-0900-4ef9-aee8-2ede7f9d97fb"),
				Name = @"SysWorkplace",
				ReferenceSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a"),
				ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b96bb4ca-a133-44f1-aa7d-24495d89e278"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a"),
				ModifiedInSchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitInWorkplace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitInWorkplace_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitInWorkplaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitInWorkplaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitInWorkplace

	/// <summary>
	/// Object in workplace.
	/// </summary>
	public class SysAdminUnitInWorkplace : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminUnitInWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitInWorkplace";
		}

		public SysAdminUnitInWorkplace(SysAdminUnitInWorkplace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysWorkplaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkplaceId");
			}
			set {
				SetColumnValue("SysWorkplaceId", value);
				_sysWorkplace = null;
			}
		}

		/// <exclude/>
		public string SysWorkplaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkplaceName");
			}
			set {
				SetColumnValue("SysWorkplaceName", value);
				if (_sysWorkplace != null) {
					_sysWorkplace.Name = value;
				}
			}
		}

		private SysWorkplace _sysWorkplace;
		/// <summary>
		/// Workplace.
		/// </summary>
		public SysWorkplace SysWorkplace {
			get {
				return _sysWorkplace ??
					(_sysWorkplace = LookupColumnEntities.GetEntity("SysWorkplace") as SysWorkplace);
			}
		}

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
		/// Object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnitInWorkplace_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnitInWorkplaceDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnitInWorkplaceInserting", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnitInWorkplaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnitInWorkplace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitInWorkplace_NUIEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitInWorkplace_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminUnitInWorkplace
	{

		public SysAdminUnitInWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitInWorkplace_NUIEventsProcess";
			SchemaUId = new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c24608d4-6299-45ab-8b08-84cbdff67d9a");
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

	#region Class: SysAdminUnitInWorkplace_NUIEventsProcess

	/// <exclude/>
	public class SysAdminUnitInWorkplace_NUIEventsProcess : SysAdminUnitInWorkplace_NUIEventsProcess<SysAdminUnitInWorkplace>
	{

		public SysAdminUnitInWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitInWorkplace_NUIEventsProcess

	public partial class SysAdminUnitInWorkplace_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitInWorkplaceEventsProcess

	/// <exclude/>
	public class SysAdminUnitInWorkplaceEventsProcess : SysAdminUnitInWorkplace_NUIEventsProcess
	{

		public SysAdminUnitInWorkplaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

