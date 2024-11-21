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

	#region Class: SysPackageInInstalledAppSchema

	/// <exclude/>
	public class SysPackageInInstalledAppSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageInInstalledAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageInInstalledAppSchema(SysPackageInInstalledAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageInInstalledAppSchema(SysPackageInInstalledAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c");
			RealUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c");
			Name = "SysPackageInInstalledApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cbddea31-af71-4773-9e88-6b0bd60be3b4")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("38ec5e8b-c6f7-48a9-975a-9383e6ef6c78")) == null) {
				Columns.Add(CreateSysInstalledAppColumn());
			}
			if (Columns.FindByUId(new Guid("79d800ef-9c09-6bf4-333d-b1b45e553582")) == null) {
				Columns.Add(CreatePrimaryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cbddea31-af71-4773-9e88-6b0bd60be3b4"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
				ModifiedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("38ec5e8b-c6f7-48a9-975a-9383e6ef6c78"),
				Name = @"SysInstalledApp",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
				ModifiedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("79d800ef-9c09-6bf4-333d-b1b45e553582"),
				Name = @"Primary",
				CreatedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
				ModifiedInSchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"),
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
			return new SysPackageInInstalledApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageInInstalledApp_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageInInstalledAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageInInstalledAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageInInstalledApp

	/// <summary>
	/// Package in installed application.
	/// </summary>
	public class SysPackageInInstalledApp : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageInInstalledApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageInInstalledApp";
		}

		public SysPackageInInstalledApp(SysPackageInInstalledApp source)
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
		public Guid SysInstalledAppId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppId");
			}
			set {
				SetColumnValue("SysInstalledAppId", value);
				_sysInstalledApp = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppName");
			}
			set {
				SetColumnValue("SysInstalledAppName", value);
				if (_sysInstalledApp != null) {
					_sysInstalledApp.Name = value;
				}
			}
		}

		private SysInstalledApp _sysInstalledApp;
		/// <summary>
		/// Installed application.
		/// </summary>
		public SysInstalledApp SysInstalledApp {
			get {
				return _sysInstalledApp ??
					(_sysInstalledApp = LookupColumnEntities.GetEntity("SysInstalledApp") as SysInstalledApp);
			}
		}

		/// <summary>
		/// Primary.
		/// </summary>
		public bool Primary {
			get {
				return GetTypedColumnValue<bool>("Primary");
			}
			set {
				SetColumnValue("Primary", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageInInstalledApp_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageInInstalledAppDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageInInstalledApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageInInstalledApp_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageInInstalledApp_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageInInstalledApp
	{

		public SysPackageInInstalledApp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageInInstalledApp_BaseEventsProcess";
			SchemaUId = new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c5da825e-81b7-44cf-b07e-a7d73474b98c");
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

	#region Class: SysPackageInInstalledApp_BaseEventsProcess

	/// <exclude/>
	public class SysPackageInInstalledApp_BaseEventsProcess : SysPackageInInstalledApp_BaseEventsProcess<SysPackageInInstalledApp>
	{

		public SysPackageInInstalledApp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageInInstalledApp_BaseEventsProcess

	public partial class SysPackageInInstalledApp_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageInInstalledAppEventsProcess

	/// <exclude/>
	public class SysPackageInInstalledAppEventsProcess : SysPackageInInstalledApp_BaseEventsProcess
	{

		public SysPackageInInstalledAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

