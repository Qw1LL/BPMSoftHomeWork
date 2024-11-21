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

	#region Class: SysEntityOperationGranteeSchema

	/// <exclude/>
	public class SysEntityOperationGranteeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntityOperationGranteeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityOperationGranteeSchema(SysEntityOperationGranteeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityOperationGranteeSchema(SysEntityOperationGranteeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed");
			RealUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed");
			Name = "SysEntityOperationGrantee";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1e4aabf8-46ea-8a22-61fe-2c01a0b18d25")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("49a9ace9-78f1-dcd9-717b-5ad7ff4d4ab8")) == null) {
				Columns.Add(CreateSysEntityOperationColumn());
			}
			if (Columns.FindByUId(new Guid("7dd2b165-c1e6-c178-fb63-6c6bee04e0a7")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1e4aabf8-46ea-8a22-61fe-2c01a0b18d25"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				ModifiedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntityOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("49a9ace9-78f1-dcd9-717b-5ad7ff4d4ab8"),
				Name = @"SysEntityOperation",
				ReferenceSchemaUId = new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				ModifiedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7dd2b165-c1e6-c178-fb63-6c6bee04e0a7"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				ModifiedInSchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityOperationGrantee(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityOperationGrantee_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityOperationGranteeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityOperationGranteeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityOperationGrantee

	/// <summary>
	/// Entity operation grantee.
	/// </summary>
	public class SysEntityOperationGrantee : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntityOperationGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityOperationGrantee";
		}

		public SysEntityOperationGrantee(SysEntityOperationGrantee source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Schema UId.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid SysEntityOperationId {
			get {
				return GetTypedColumnValue<Guid>("SysEntityOperationId");
			}
			set {
				SetColumnValue("SysEntityOperationId", value);
				_sysEntityOperation = null;
			}
		}

		/// <exclude/>
		public string SysEntityOperationName {
			get {
				return GetTypedColumnValue<string>("SysEntityOperationName");
			}
			set {
				SetColumnValue("SysEntityOperationName", value);
				if (_sysEntityOperation != null) {
					_sysEntityOperation.Name = value;
				}
			}
		}

		private SysEntityOperation _sysEntityOperation;
		/// <summary>
		/// Entity operation.
		/// </summary>
		public SysEntityOperation SysEntityOperation {
			get {
				return _sysEntityOperation ??
					(_sysEntityOperation = LookupColumnEntities.GetEntity("SysEntityOperation") as SysEntityOperation);
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
		/// User/Role.
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
			var process = new SysEntityOperationGrantee_BaseEventsProcess(UserConnection);
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
			return new SysEntityOperationGrantee(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityOperationGrantee_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntityOperationGrantee_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEntityOperationGrantee
	{

		public SysEntityOperationGrantee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityOperationGrantee_BaseEventsProcess";
			SchemaUId = new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("94e2445e-1960-43ca-a869-b1be8b0772ed");
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

	#region Class: SysEntityOperationGrantee_BaseEventsProcess

	/// <exclude/>
	public class SysEntityOperationGrantee_BaseEventsProcess : SysEntityOperationGrantee_BaseEventsProcess<SysEntityOperationGrantee>
	{

		public SysEntityOperationGrantee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityOperationGrantee_BaseEventsProcess

	public partial class SysEntityOperationGrantee_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityOperationGranteeEventsProcess

	/// <exclude/>
	public class SysEntityOperationGranteeEventsProcess : SysEntityOperationGrantee_BaseEventsProcess
	{

		public SysEntityOperationGranteeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

