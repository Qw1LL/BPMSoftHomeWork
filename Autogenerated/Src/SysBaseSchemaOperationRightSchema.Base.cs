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

	#region Class: SysBaseSchemaOperationRightSchema

	/// <exclude/>
	[IsVirtual]
	public class SysBaseSchemaOperationRightSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysBaseSchemaOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysBaseSchemaOperationRightSchema(SysBaseSchemaOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysBaseSchemaOperationRightSchema(SysBaseSchemaOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			RealUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			Name = "SysBaseSchemaOperationRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a72532ba-4755-4b2f-8079-c382ae6d0e9a")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("d27e9964-a7a6-46dd-9f9a-7cb470c33b98")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a72532ba-4755-4b2f-8079-c382ae6d0e9a"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				ModifiedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d27e9964-a7a6-46dd-9f9a-7cb470c33b98"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				ModifiedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
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
			return new SysBaseSchemaOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysBaseSchemaOperationRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysBaseSchemaOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysBaseSchemaOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysBaseSchemaOperationRight

	/// <summary>
	/// Base operation permissions.
	/// </summary>
	public class SysBaseSchemaOperationRight : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysBaseSchemaOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysBaseSchemaOperationRight";
		}

		public SysBaseSchemaOperationRight(SysBaseSchemaOperationRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
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
		/// User/role.
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
			var process = new SysBaseSchemaOperationRight_BaseEventsProcess(UserConnection);
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
			return new SysBaseSchemaOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysBaseSchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysBaseSchemaOperationRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysBaseSchemaOperationRight
	{

		public SysBaseSchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysBaseSchemaOperationRight_BaseEventsProcess";
			SchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
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

	#region Class: SysBaseSchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public class SysBaseSchemaOperationRight_BaseEventsProcess : SysBaseSchemaOperationRight_BaseEventsProcess<SysBaseSchemaOperationRight>
	{

		public SysBaseSchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysBaseSchemaOperationRight_BaseEventsProcess

	public partial class SysBaseSchemaOperationRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysBaseSchemaOperationRightEventsProcess

	/// <exclude/>
	public class SysBaseSchemaOperationRightEventsProcess : SysBaseSchemaOperationRight_BaseEventsProcess
	{

		public SysBaseSchemaOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

