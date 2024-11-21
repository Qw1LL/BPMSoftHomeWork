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

	#region Class: SysSSPCustomerSchemaSchema

	/// <exclude/>
	public class SysSSPCustomerSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSSPCustomerSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSSPCustomerSchemaSchema(SysSSPCustomerSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSSPCustomerSchemaSchema(SysSSPCustomerSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("85ed8ed0-f906-49db-abac-2310dd47da67");
			RealUId = new Guid("85ed8ed0-f906-49db-abac-2310dd47da67");
			Name = "SysSSPCustomerSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e6cecc45-0743-43e1-bb47-9189a8e65cbd")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6cecc45-0743-43e1-bb47-9189a8e65cbd"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("85ed8ed0-f906-49db-abac-2310dd47da67"),
				ModifiedInSchemaUId = new Guid("85ed8ed0-f906-49db-abac-2310dd47da67"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSSPCustomerSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSSPCustomerSchema_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSSPCustomerSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSSPCustomerSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85ed8ed0-f906-49db-abac-2310dd47da67"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSSPCustomerSchema

	/// <summary>
	/// Self-service portal configuration item for customer.
	/// </summary>
	public class SysSSPCustomerSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSSPCustomerSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSSPCustomerSchema";
		}

		public SysSSPCustomerSchema(SysSSPCustomerSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSSPCustomerSchema_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSSPCustomerSchemaDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysSSPCustomerSchemaInserting", e);
			Validating += (s, e) => ThrowEvent("SysSSPCustomerSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSSPCustomerSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSSPCustomerSchema_BaseEventsProcess

	/// <exclude/>
	public partial class SysSSPCustomerSchema_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSSPCustomerSchema
	{

		public SysSSPCustomerSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSSPCustomerSchema_BaseEventsProcess";
			SchemaUId = new Guid("85ed8ed0-f906-49db-abac-2310dd47da67");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("85ed8ed0-f906-49db-abac-2310dd47da67");
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

	#region Class: SysSSPCustomerSchema_BaseEventsProcess

	/// <exclude/>
	public class SysSSPCustomerSchema_BaseEventsProcess : SysSSPCustomerSchema_BaseEventsProcess<SysSSPCustomerSchema>
	{

		public SysSSPCustomerSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSSPCustomerSchema_BaseEventsProcess

	public partial class SysSSPCustomerSchema_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSSPCustomerSchemaEventsProcess

	/// <exclude/>
	public class SysSSPCustomerSchemaEventsProcess : SysSSPCustomerSchema_BaseEventsProcess
	{

		public SysSSPCustomerSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

