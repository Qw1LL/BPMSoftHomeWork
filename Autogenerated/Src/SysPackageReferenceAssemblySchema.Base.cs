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

	#region Class: SysPackageReferenceAssemblySchema

	/// <exclude/>
	public class SysPackageReferenceAssemblySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageReferenceAssemblySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageReferenceAssemblySchema(SysPackageReferenceAssemblySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageReferenceAssemblySchema(SysPackageReferenceAssemblySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8");
			RealUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8");
			Name = "SysPackageReferenceAssembly";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("35032b37-1853-4f03-b095-ab0b571fc943")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("2705c026-08b6-4eab-b7f8-245c4625dfd6")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("2c634e49-c002-4fa2-bab0-f72869d5cb63")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("a69a40f5-dc79-400f-ae6b-7b6afded773a")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("fb2b546f-23f3-44a7-9223-9c2cd6758c90")) == null) {
				Columns.Add(CreateFullNameColumn());
			}
			if (Columns.FindByUId(new Guid("3a334b24-c670-4f56-a056-55f0ff690565")) == null) {
				Columns.Add(CreateLoadOnAppStartColumn());
			}
			if (Columns.FindByUId(new Guid("2b19941c-8b36-4963-8fb8-87f4ec57078f")) == null) {
				Columns.Add(CreateIsNetStandardColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("35032b37-1853-4f03-b095-ab0b571fc943"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2705c026-08b6-4eab-b7f8-245c4625dfd6"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("2c634e49-c002-4fa2-bab0-f72869d5cb63"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a69a40f5-dc79-400f-ae6b-7b6afded773a"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFullNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fb2b546f-23f3-44a7-9223-9c2cd6758c90"),
				Name = @"FullName",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLoadOnAppStartColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3a334b24-c670-4f56-a056-55f0ff690565"),
				Name = @"LoadOnAppStart",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNetStandardColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2b19941c-8b36-4963-8fb8-87f4ec57078f"),
				Name = @"IsNetStandard",
				CreatedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				ModifiedInSchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"),
				CreatedInPackageId = new Guid("cf097749-3e35-4668-a7a8-6c36baac79a9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageReferenceAssembly(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageReferenceAssembly_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageReferenceAssemblySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageReferenceAssemblySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageReferenceAssembly

	/// <summary>
	/// Package builds.
	/// </summary>
	public class SysPackageReferenceAssembly : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageReferenceAssembly(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageReferenceAssembly";
		}

		public SysPackageReferenceAssembly(SysPackageReferenceAssembly source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

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

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
			}
		}

		/// <summary>
		/// Load Assembly to AppDomain On Application Start.
		/// </summary>
		public bool LoadOnAppStart {
			get {
				return GetTypedColumnValue<bool>("LoadOnAppStart");
			}
			set {
				SetColumnValue("LoadOnAppStart", value);
			}
		}

		/// <summary>
		/// .Net Standard Compatible.
		/// </summary>
		public bool IsNetStandard {
			get {
				return GetTypedColumnValue<bool>("IsNetStandard");
			}
			set {
				SetColumnValue("IsNetStandard", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageReferenceAssembly_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageReferenceAssemblyDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysPackageReferenceAssemblyInserting", e);
			Validating += (s, e) => ThrowEvent("SysPackageReferenceAssemblyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageReferenceAssembly(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageReferenceAssembly_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageReferenceAssembly_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageReferenceAssembly
	{

		public SysPackageReferenceAssembly_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageReferenceAssembly_BaseEventsProcess";
			SchemaUId = new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5ace0879-2978-4c92-9589-3feccd2ec9f8");
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

	#region Class: SysPackageReferenceAssembly_BaseEventsProcess

	/// <exclude/>
	public class SysPackageReferenceAssembly_BaseEventsProcess : SysPackageReferenceAssembly_BaseEventsProcess<SysPackageReferenceAssembly>
	{

		public SysPackageReferenceAssembly_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageReferenceAssembly_BaseEventsProcess

	public partial class SysPackageReferenceAssembly_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageReferenceAssemblyEventsProcess

	/// <exclude/>
	public class SysPackageReferenceAssemblyEventsProcess : SysPackageReferenceAssembly_BaseEventsProcess
	{

		public SysPackageReferenceAssemblyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

