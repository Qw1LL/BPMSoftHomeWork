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

	#region Class: SysModuleEntityInPortalSchema

	/// <exclude/>
	public class SysModuleEntityInPortalSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleEntityInPortalSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleEntityInPortalSchema(SysModuleEntityInPortalSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleEntityInPortalSchema(SysModuleEntityInPortalSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			RealUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			Name = "SysModuleEntityInPortal";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c86fd533-a630-42fa-8042-c604384abe1f")) == null) {
				Columns.Add(CreateSysPortalColumn());
			}
			if (Columns.FindByUId(new Guid("a9afe7de-15cf-48a6-b6fb-249b1883c032")) == null) {
				Columns.Add(CreateSysModuleEntityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysPortalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c86fd533-a630-42fa-8042-c604384abe1f"),
				Name = @"SysPortal",
				ReferenceSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf"),
				ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf"),
				CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a9afe7de-15cf-48a6-b6fb-249b1883c032"),
				Name = @"SysModuleEntity",
				ReferenceSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf"),
				ModifiedInSchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf"),
				CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleEntityInPortal(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleEntityInPortal_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleEntityInPortalSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleEntityInPortalSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntityInPortal

	/// <summary>
	/// Portal section object.
	/// </summary>
	public class SysModuleEntityInPortal : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleEntityInPortal(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEntityInPortal";
		}

		public SysModuleEntityInPortal(SysModuleEntityInPortal source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPortalId {
			get {
				return GetTypedColumnValue<Guid>("SysPortalId");
			}
			set {
				SetColumnValue("SysPortalId", value);
				_sysPortal = null;
			}
		}

		/// <exclude/>
		public string SysPortalName {
			get {
				return GetTypedColumnValue<string>("SysPortalName");
			}
			set {
				SetColumnValue("SysPortalName", value);
				if (_sysPortal != null) {
					_sysPortal.Name = value;
				}
			}
		}

		private SysPortal _sysPortal;
		/// <summary>
		/// Portal.
		/// </summary>
		public SysPortal SysPortal {
			get {
				return _sysPortal ??
					(_sysPortal = LookupColumnEntities.GetEntity("SysPortal") as SysPortal);
			}
		}

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// SysModuleEntity.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = LookupColumnEntities.GetEntity("SysModuleEntity") as SysModuleEntity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleEntityInPortal_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleEntityInPortalDeleted", e);
			Validating += (s, e) => ThrowEvent("SysModuleEntityInPortalValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleEntityInPortal(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntityInPortal_SSPEventsProcess

	/// <exclude/>
	public partial class SysModuleEntityInPortal_SSPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleEntityInPortal
	{

		public SysModuleEntityInPortal_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleEntityInPortal_SSPEventsProcess";
			SchemaUId = new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0933e2c4-342c-41e0-adce-7dbc2c8860bf");
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

	#region Class: SysModuleEntityInPortal_SSPEventsProcess

	/// <exclude/>
	public class SysModuleEntityInPortal_SSPEventsProcess : SysModuleEntityInPortal_SSPEventsProcess<SysModuleEntityInPortal>
	{

		public SysModuleEntityInPortal_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleEntityInPortal_SSPEventsProcess

	public partial class SysModuleEntityInPortal_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleEntityInPortalEventsProcess

	/// <exclude/>
	public class SysModuleEntityInPortalEventsProcess : SysModuleEntityInPortal_SSPEventsProcess
	{

		public SysModuleEntityInPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

