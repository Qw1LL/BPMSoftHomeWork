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

	#region Class: SysModuleReportInPackageSchema

	/// <exclude/>
	public class SysModuleReportInPackageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleReportInPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleReportInPackageSchema(SysModuleReportInPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleReportInPackageSchema(SysModuleReportInPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			RealUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			Name = "SysModuleReportInPackage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3383ea10-6bb2-4c96-8d65-fab13975fe04")) == null) {
				Columns.Add(CreateSysModuleReportPackageColumn());
			}
			if (Columns.FindByUId(new Guid("856a698b-fa4d-4cc8-a3a0-be19361d3702")) == null) {
				Columns.Add(CreateSysModuleReportColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysModuleReportPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3383ea10-6bb2-4c96-8d65-fab13975fe04"),
				Name = @"SysModuleReportPackage",
				ReferenceSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5"),
				ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5"),
				CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleReportColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("856a698b-fa4d-4cc8-a3a0-be19361d3702"),
				Name = @"SysModuleReport",
				ReferenceSchemaUId = new Guid("0a62cd3d-6541-4c5c-903f-e5b0fc665297"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5"),
				ModifiedInSchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5"),
				CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleReportInPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleReportInPackage_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleReportInPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleReportInPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportInPackage

	/// <summary>
	/// Printable in package.
	/// </summary>
	public class SysModuleReportInPackage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleReportInPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportInPackage";
		}

		public SysModuleReportInPackage(SysModuleReportInPackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleReportPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleReportPackageId");
			}
			set {
				SetColumnValue("SysModuleReportPackageId", value);
				_sysModuleReportPackage = null;
			}
		}

		/// <exclude/>
		public string SysModuleReportPackageName {
			get {
				return GetTypedColumnValue<string>("SysModuleReportPackageName");
			}
			set {
				SetColumnValue("SysModuleReportPackageName", value);
				if (_sysModuleReportPackage != null) {
					_sysModuleReportPackage.Name = value;
				}
			}
		}

		private SysModuleReportPackage _sysModuleReportPackage;
		/// <summary>
		/// Package of section printables.
		/// </summary>
		public SysModuleReportPackage SysModuleReportPackage {
			get {
				return _sysModuleReportPackage ??
					(_sysModuleReportPackage = LookupColumnEntities.GetEntity("SysModuleReportPackage") as SysModuleReportPackage);
			}
		}

		/// <exclude/>
		public Guid SysModuleReportId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleReportId");
			}
			set {
				SetColumnValue("SysModuleReportId", value);
				_sysModuleReport = null;
			}
		}

		/// <exclude/>
		public string SysModuleReportCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleReportCaption");
			}
			set {
				SetColumnValue("SysModuleReportCaption", value);
				if (_sysModuleReport != null) {
					_sysModuleReport.Caption = value;
				}
			}
		}

		private SysModuleReport _sysModuleReport;
		/// <summary>
		/// Printable.
		/// </summary>
		public SysModuleReport SysModuleReport {
			get {
				return _sysModuleReport ??
					(_sysModuleReport = LookupColumnEntities.GetEntity("SysModuleReport") as SysModuleReport);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleReportInPackage_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleReportInPackageDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleReportInPackageInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleReportInPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleReportInPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportInPackage_NUIEventsProcess

	/// <exclude/>
	public partial class SysModuleReportInPackage_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleReportInPackage
	{

		public SysModuleReportInPackage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleReportInPackage_NUIEventsProcess";
			SchemaUId = new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a1c90e6-f7e1-427d-9788-538b50df82b5");
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

	#region Class: SysModuleReportInPackage_NUIEventsProcess

	/// <exclude/>
	public class SysModuleReportInPackage_NUIEventsProcess : SysModuleReportInPackage_NUIEventsProcess<SysModuleReportInPackage>
	{

		public SysModuleReportInPackage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleReportInPackage_NUIEventsProcess

	public partial class SysModuleReportInPackage_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleReportInPackageEventsProcess

	/// <exclude/>
	public class SysModuleReportInPackageEventsProcess : SysModuleReportInPackage_NUIEventsProcess
	{

		public SysModuleReportInPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

