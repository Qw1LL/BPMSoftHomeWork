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

	#region Class: SysInstalledPackageDataSchema

	/// <exclude/>
	public class SysInstalledPackageDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysInstalledPackageDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledPackageDataSchema(SysInstalledPackageDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledPackageDataSchema(SysInstalledPackageDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf");
			RealUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf");
			Name = "SysInstalledPackageData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8377f316-a40e-40e0-b90b-c5aa8ff0d632")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("8905008e-9644-4852-9a80-3d2be40d7750")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("5679204c-625b-4389-91ad-7d705de84764")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8377f316-a40e-40e0-b90b-c5aa8ff0d632"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				ModifiedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8905008e-9644-4852-9a80-3d2be40d7750"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				ModifiedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5679204c-625b-4389-91ad-7d705de84764"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				ModifiedInSchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysInstalledPackageData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledPackageData_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledPackageDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledPackageDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledPackageData

	/// <summary>
	/// Installed package data.
	/// </summary>
	public class SysInstalledPackageData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysInstalledPackageData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledPackageData";
		}

		public SysInstalledPackageData(SysInstalledPackageData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

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

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledPackageData_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysInstalledPackageDataDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInstalledPackageData(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledPackageData_BaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledPackageData_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysInstalledPackageData
	{

		public SysInstalledPackageData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledPackageData_BaseEventsProcess";
			SchemaUId = new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54e2c1b3-afdb-4b44-b8ed-0d829fb4d8cf");
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

	#region Class: SysInstalledPackageData_BaseEventsProcess

	/// <exclude/>
	public class SysInstalledPackageData_BaseEventsProcess : SysInstalledPackageData_BaseEventsProcess<SysInstalledPackageData>
	{

		public SysInstalledPackageData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledPackageData_BaseEventsProcess

	public partial class SysInstalledPackageData_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInstalledPackageDataEventsProcess

	/// <exclude/>
	public class SysInstalledPackageDataEventsProcess : SysInstalledPackageData_BaseEventsProcess
	{

		public SysInstalledPackageDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

