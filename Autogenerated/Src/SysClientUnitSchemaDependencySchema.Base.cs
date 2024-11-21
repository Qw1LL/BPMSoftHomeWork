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

	#region Class: SysClientUnitSchemaDependencySchema

	/// <exclude/>
	public class SysClientUnitSchemaDependencySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysClientUnitSchemaDependencySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysClientUnitSchemaDependencySchema(SysClientUnitSchemaDependencySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysClientUnitSchemaDependencySchema(SysClientUnitSchemaDependencySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404");
			RealUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404");
			Name = "SysClientUnitSchemaDependency";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6b02e0a6-3eb8-43c8-a420-e66f8d82a1d6")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4649d729-8242-4fb3-97e2-6f0a241573cd")) == null) {
				Columns.Add(CreateCreatedInSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ba2b2b42-396b-432c-b2e7-e545ff56a184")) == null) {
				Columns.Add(CreateModifiedInSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("73bc3a53-9800-4b99-bf58-6aa4ab579c6d")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("ceb8ebc5-b984-4122-8121-c479ee82cac7")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ce393404-e869-422a-97d5-f18fa872e055")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("861cfc4b-62da-4c17-a737-c2c3e06df6b6")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6b02e0a6-3eb8-43c8-a420-e66f8d82a1d6"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedInSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4649d729-8242-4fb3-97e2-6f0a241573cd"),
				Name = @"CreatedInSchemaUId",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedInSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ba2b2b42-396b-432c-b2e7-e545ff56a184"),
				Name = @"ModifiedInSchemaUId",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("73bc3a53-9800-4b99-bf58-6aa4ab579c6d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ceb8ebc5-b984-4122-8121-c479ee82cac7"),
				Name = @"SchemaUId",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ce393404-e869-422a-97d5-f18fa872e055"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("861cfc4b-62da-4c17-a737-c2c3e06df6b6"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
				ModifiedInSchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"),
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
			return new SysClientUnitSchemaDependency(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysClientUnitSchemaDependency_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysClientUnitSchemaDependencySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysClientUnitSchemaDependencySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404"));
		}

		#endregion

	}

	#endregion

	#region Class: SysClientUnitSchemaDependency

	/// <summary>
	/// System client unit schema dependency.
	/// </summary>
	public class SysClientUnitSchemaDependency : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysClientUnitSchemaDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysClientUnitSchemaDependency";
		}

		public SysClientUnitSchemaDependency(SysClientUnitSchemaDependency source)
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
		/// CreatedInSchemaUId.
		/// </summary>
		public Guid CreatedInSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CreatedInSchemaUId");
			}
			set {
				SetColumnValue("CreatedInSchemaUId", value);
			}
		}

		/// <summary>
		/// ModifiedInSchemaUId.
		/// </summary>
		public Guid ModifiedInSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ModifiedInSchemaUId");
			}
			set {
				SetColumnValue("ModifiedInSchemaUId", value);
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

		/// <summary>
		/// SchemaUId.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
			}
		}

		/// <summary>
		/// ManagerName.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
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
		/// SchemaId.
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
			var process = new SysClientUnitSchemaDependency_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysClientUnitSchemaDependencyDeleted", e);
			Validating += (s, e) => ThrowEvent("SysClientUnitSchemaDependencyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysClientUnitSchemaDependency(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysClientUnitSchemaDependency_BaseEventsProcess

	/// <exclude/>
	public partial class SysClientUnitSchemaDependency_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysClientUnitSchemaDependency
	{

		public SysClientUnitSchemaDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysClientUnitSchemaDependency_BaseEventsProcess";
			SchemaUId = new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e535f9ed-74ef-4a35-9f6c-e07bacb08404");
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

	#region Class: SysClientUnitSchemaDependency_BaseEventsProcess

	/// <exclude/>
	public class SysClientUnitSchemaDependency_BaseEventsProcess : SysClientUnitSchemaDependency_BaseEventsProcess<SysClientUnitSchemaDependency>
	{

		public SysClientUnitSchemaDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysClientUnitSchemaDependency_BaseEventsProcess

	public partial class SysClientUnitSchemaDependency_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysClientUnitSchemaDependencyEventsProcess

	/// <exclude/>
	public class SysClientUnitSchemaDependencyEventsProcess : SysClientUnitSchemaDependency_BaseEventsProcess
	{

		public SysClientUnitSchemaDependencyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

