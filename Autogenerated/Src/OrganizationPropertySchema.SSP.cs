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

	#region Class: OrganizationPropertySchema

	/// <exclude/>
	public class OrganizationPropertySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OrganizationPropertySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrganizationPropertySchema(OrganizationPropertySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrganizationPropertySchema(OrganizationPropertySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115");
			RealUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115");
			Name = "OrganizationProperty";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4f77d403-0bf8-4a27-95fc-170e07e5b490")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("1f26cda5-1513-4abf-bb79-2f1c62d715bd")) == null) {
				Columns.Add(CreateLicenseNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4f77d403-0bf8-4a27-95fc-170e07e5b490"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115"),
				ModifiedInSchemaUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateLicenseNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1f26cda5-1513-4abf-bb79-2f1c62d715bd"),
				Name = @"LicenseName",
				CreatedInSchemaUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115"),
				ModifiedInSchemaUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrganizationProperty(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrganizationProperty_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrganizationPropertySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrganizationPropertySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115"));
		}

		#endregion

	}

	#endregion

	#region Class: OrganizationProperty

	/// <summary>
	/// OrganizationProperty.
	/// </summary>
	public class OrganizationProperty : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OrganizationProperty(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrganizationProperty";
		}

		public OrganizationProperty(OrganizationProperty source)
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
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// License name.
		/// </summary>
		public string LicenseName {
			get {
				return GetTypedColumnValue<string>("LicenseName");
			}
			set {
				SetColumnValue("LicenseName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrganizationProperty_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrganizationProperty(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrganizationProperty_SSPEventsProcess

	/// <exclude/>
	public partial class OrganizationProperty_SSPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OrganizationProperty
	{

		public OrganizationProperty_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrganizationProperty_SSPEventsProcess";
			SchemaUId = new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ca657f2e-e2fc-46b0-a986-fa5c6aa84115");
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

	#region Class: OrganizationProperty_SSPEventsProcess

	/// <exclude/>
	public class OrganizationProperty_SSPEventsProcess : OrganizationProperty_SSPEventsProcess<OrganizationProperty>
	{

		public OrganizationProperty_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrganizationProperty_SSPEventsProcess

	public partial class OrganizationProperty_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OrganizationPropertyEventsProcess

	/// <exclude/>
	public class OrganizationPropertyEventsProcess : OrganizationProperty_SSPEventsProcess
	{

		public OrganizationPropertyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

