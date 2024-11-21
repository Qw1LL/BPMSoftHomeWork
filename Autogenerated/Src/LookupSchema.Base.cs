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

	#region Class: LookupSchema

	/// <exclude/>
	public class LookupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LookupSchema(LookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LookupSchema(LookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			RealUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			Name = "Lookup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("009571ab-9c5d-4a20-bf83-dd499ed5a833")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("91bcbbaa-7f66-4cbf-9de4-9170da8b8d4b")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("91f76f42-e24d-4ebd-95b3-5b5517e917c3")) == null) {
				Columns.Add(CreateSysPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("8b099885-e3bc-4585-920d-a497f2611e2c")) == null) {
				Columns.Add(CreateSysLookupColumn());
			}
			if (Columns.FindByUId(new Guid("9f530727-41f3-e880-b5a7-e3a03e39838b")) == null) {
				Columns.Add(CreateIsNotAvailableInStudioColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("547bff8d-f717-4316-846c-3ff1f0e36e6e"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("009571ab-9c5d-4a20-bf83-dd499ed5a833"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("91bcbbaa-7f66-4cbf-9de4-9170da8b8d4b"),
				Name = @"SysEntitySchemaUId",
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("91f76f42-e24d-4ebd-95b3-5b5517e917c3"),
				Name = @"SysPageSchemaUId",
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8b099885-e3bc-4585-920d-a497f2611e2c"),
				Name = @"SysLookup",
				ReferenceSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNotAvailableInStudioColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9f530727-41f3-e880-b5a7-e3a03e39838b"),
				Name = @"IsNotAvailableInStudio",
				CreatedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				ModifiedInSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
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
			return new Lookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"));
		}

		#endregion

	}

	#endregion

	#region Class: Lookup

	/// <summary>
	/// Справочник.
	/// </summary>
	public class Lookup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Lookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lookup";
		}

		public Lookup(Lookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор объекта.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор страницы.
		/// </summary>
		public Guid SysPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaUId");
			}
			set {
				SetColumnValue("SysPageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid SysLookupId {
			get {
				return GetTypedColumnValue<Guid>("SysLookupId");
			}
			set {
				SetColumnValue("SysLookupId", value);
				_sysLookup = null;
			}
		}

		/// <exclude/>
		public string SysLookupName {
			get {
				return GetTypedColumnValue<string>("SysLookupName");
			}
			set {
				SetColumnValue("SysLookupName", value);
				if (_sysLookup != null) {
					_sysLookup.Name = value;
				}
			}
		}

		private SysLookup _sysLookup;
		/// <summary>
		/// Справочник в старом интерфейсе.
		/// </summary>
		public SysLookup SysLookup {
			get {
				return _sysLookup ??
					(_sysLookup = LookupColumnEntities.GetEntity("SysLookup") as SysLookup);
			}
		}

		/// <summary>
		/// Недоступно.
		/// </summary>
		public bool IsNotAvailableInStudio {
			get {
				return GetTypedColumnValue<bool>("IsNotAvailableInStudio");
			}
			set {
				SetColumnValue("IsNotAvailableInStudio", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LookupDeleted", e);
			Validating += (s, e) => ThrowEvent("LookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lookup_BaseEventsProcess

	/// <exclude/>
	public partial class Lookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Lookup
	{

		public Lookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lookup_BaseEventsProcess";
			SchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
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

	#region Class: Lookup_BaseEventsProcess

	/// <exclude/>
	public class Lookup_BaseEventsProcess : Lookup_BaseEventsProcess<Lookup>
	{

		public Lookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Lookup_BaseEventsProcess

	public partial class Lookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LookupEventsProcess

	/// <exclude/>
	public class LookupEventsProcess : Lookup_BaseEventsProcess
	{

		public LookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

