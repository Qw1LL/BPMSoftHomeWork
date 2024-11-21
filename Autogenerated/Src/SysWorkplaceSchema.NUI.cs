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

	#region Class: SysWorkplace_NUI_BPMSoftSchema

	/// <exclude/>
	public class SysWorkplace_NUI_BPMSoftSchema : BPMSoft.Configuration.BaseEntityWithPositionSchema
	{

		#region Constructors: Public

		public SysWorkplace_NUI_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysWorkplace_NUI_BPMSoftSchema(SysWorkplace_NUI_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysWorkplace_NUI_BPMSoftSchema(SysWorkplace_NUI_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			RealUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			Name = "SysWorkplace_NUI_BPMSoft";
			ParentSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
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
			if (Columns.FindByUId(new Guid("cd8bcb82-b061-468d-bcce-a5a9312866e4")) == null) {
				Columns.Add(CreateIsPersonalColumn());
			}
			if (Columns.FindByUId(new Guid("8fe2b261-a69f-4846-bf82-f36e564d0aa4")) == null) {
				Columns.Add(CreateLoaderIdColumn());
			}
			if (Columns.FindByUId(new Guid("445c4583-2f21-4d2b-a6ba-c33108797ae0")) == null) {
				Columns.Add(CreateSysApplicationClientTypeColumn());
			}
			if (Columns.FindByUId(new Guid("dae36990-bfb4-4f13-ae18-1b18b6081983")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreatePositionColumn() {
			EntitySchemaColumn column = base.CreatePositionColumn();
			column.ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("215e82ee-20b0-4aa2-af3b-ff06cbc6da52"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsPersonalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cd8bcb82-b061-468d-bcce-a5a9312866e4"),
				Name = @"IsPersonal",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected virtual EntitySchemaColumn CreateLoaderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8fe2b261-a69f-4846-bf82-f36e564d0aa4"),
				Name = @"LoaderId",
				CreatedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				CreatedInPackageId = new Guid("2c390582-306b-458b-afe1-2a3764ac60ce"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"3707a058-e6a8-4d2c-99cc-d01d9e6b70c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysApplicationClientTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("445c4583-2f21-4d2b-a6ba-c33108797ae0"),
				Name = @"SysApplicationClientType",
				ReferenceSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				CreatedInPackageId = new Guid("4f457753-d1f1-4b18-9761-0022b465f28b"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"195785b4-f55a-4e72-ace3-6480b54c8fa5"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dae36990-bfb4-4f13-ae18-1b18b6081983"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				ModifiedInSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"000a9225-728b-4778-a951-c42439ffe024"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysWorkplace_NUI_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysWorkplace_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysWorkplace_NUI_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysWorkplace_NUI_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplace_NUI_BPMSoft

	/// <summary>
	/// User's workplace.
	/// </summary>
	public class SysWorkplace_NUI_BPMSoft : BPMSoft.Configuration.BaseEntityWithPosition
	{

		#region Constructors: Public

		public SysWorkplace_NUI_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkplace_NUI_BPMSoft";
		}

		public SysWorkplace_NUI_BPMSoft(SysWorkplace_NUI_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Personal.
		/// </summary>
		public bool IsPersonal {
			get {
				return GetTypedColumnValue<bool>("IsPersonal");
			}
			set {
				SetColumnValue("IsPersonal", value);
			}
		}

		/// <summary>
		/// Workplace loader schema.
		/// </summary>
		public Guid LoaderId {
			get {
				return GetTypedColumnValue<Guid>("LoaderId");
			}
			set {
				SetColumnValue("LoaderId", value);
			}
		}

		/// <exclude/>
		public Guid SysApplicationClientTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysApplicationClientTypeId");
			}
			set {
				SetColumnValue("SysApplicationClientTypeId", value);
				_sysApplicationClientType = null;
			}
		}

		/// <exclude/>
		public string SysApplicationClientTypeName {
			get {
				return GetTypedColumnValue<string>("SysApplicationClientTypeName");
			}
			set {
				SetColumnValue("SysApplicationClientTypeName", value);
				if (_sysApplicationClientType != null) {
					_sysApplicationClientType.Name = value;
				}
			}
		}

		private SysApplicationClientType _sysApplicationClientType;
		/// <summary>
		/// Application type.
		/// </summary>
		public SysApplicationClientType SysApplicationClientType {
			get {
				return _sysApplicationClientType ??
					(_sysApplicationClientType = LookupColumnEntities.GetEntity("SysApplicationClientType") as SysApplicationClientType);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysWorkplaceType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SysWorkplaceType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysWorkplaceType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysWorkplace_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("SysWorkplace_NUI_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysWorkplace_NUI_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplace_NUIEventsProcess

	/// <exclude/>
	public partial class SysWorkplace_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityWithPosition_BaseEventsProcess<TEntity> where TEntity : SysWorkplace_NUI_BPMSoft
	{

		public SysWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysWorkplace_NUIEventsProcess";
			SchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
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

	#region Class: SysWorkplace_NUIEventsProcess

	/// <exclude/>
	public class SysWorkplace_NUIEventsProcess : SysWorkplace_NUIEventsProcess<SysWorkplace_NUI_BPMSoft>
	{

		public SysWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysWorkplace_NUIEventsProcess

	public partial class SysWorkplace_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void BaseEntityWithPositionInserting() {
			if (UserConnection.GetIsFeatureEnabled("NewWorkplaceUI")) {
				return;
			}
			base.BaseEntityWithPositionInserting();
		}

		public override void BaseEntityWithPositionDeleted() {
			if (UserConnection.GetIsFeatureEnabled("NewWorkplaceUI")) {
				return;
			}
			base.BaseEntityWithPositionDeleted();
		}

		#endregion

	}

	#endregion

}

