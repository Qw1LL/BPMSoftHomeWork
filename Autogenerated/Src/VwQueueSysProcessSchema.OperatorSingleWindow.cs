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

	#region Class: VwQueueSysProcessSchema

	/// <exclude/>
	public class VwQueueSysProcessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwQueueSysProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwQueueSysProcessSchema(VwQueueSysProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwQueueSysProcessSchema(VwQueueSysProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054");
			RealUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054");
			Name = "VwQueueSysProcess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("020f3316-a45e-4a36-bdd4-fd42393b9da0")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("c2856c73-5d6f-4840-97a2-6d9393b8471a")) == null) {
				Columns.Add(CreateIsMaxVersionColumn());
			}
			if (Columns.FindByUId(new Guid("5ad508b0-8f6b-41f9-9d5c-92f47d224dfc")) == null) {
				Columns.Add(CreateTagPropertyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("020f3316-a45e-4a36-bdd4-fd42393b9da0"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				ModifiedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("96c033c2-bdfa-4afa-9e39-455ff197117d"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				ModifiedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsMaxVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c2856c73-5d6f-4840-97a2-6d9393b8471a"),
				Name = @"IsMaxVersion",
				CreatedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				ModifiedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				CreatedInPackageId = new Guid("1ad7176a-4e4a-423b-bb1b-aa5da30581f3")
			};
		}

		protected virtual EntitySchemaColumn CreateTagPropertyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5ad508b0-8f6b-41f9-9d5c-92f47d224dfc"),
				Name = @"TagProperty",
				CreatedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				ModifiedInSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				CreatedInPackageId = new Guid("1ad7176a-4e4a-423b-bb1b-aa5da30581f3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwQueueSysProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwQueueSysProcess_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwQueueSysProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwQueueSysProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93b95b14-135f-4692-94f3-4d974fe74054"));
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueSysProcess

	/// <summary>
	/// Доступные процессы очередей (представление).
	/// </summary>
	public class VwQueueSysProcess : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwQueueSysProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwQueueSysProcess";
		}

		public VwQueueSysProcess(VwQueueSysProcess source)
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
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Максимальная версия.
		/// </summary>
		public bool IsMaxVersion {
			get {
				return GetTypedColumnValue<bool>("IsMaxVersion");
			}
			set {
				SetColumnValue("IsMaxVersion", value);
			}
		}

		/// <summary>
		/// Тэг.
		/// </summary>
		public string TagProperty {
			get {
				return GetTypedColumnValue<string>("TagProperty");
			}
			set {
				SetColumnValue("TagProperty", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwQueueSysProcess_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwQueueSysProcessDeleted", e);
			Validating += (s, e) => ThrowEvent("VwQueueSysProcessValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwQueueSysProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueSysProcess_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class VwQueueSysProcess_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwQueueSysProcess
	{

		public VwQueueSysProcess_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwQueueSysProcess_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("93b95b14-135f-4692-94f3-4d974fe74054");
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

	#region Class: VwQueueSysProcess_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class VwQueueSysProcess_OperatorSingleWindowEventsProcess : VwQueueSysProcess_OperatorSingleWindowEventsProcess<VwQueueSysProcess>
	{

		public VwQueueSysProcess_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwQueueSysProcess_OperatorSingleWindowEventsProcess

	public partial class VwQueueSysProcess_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwQueueSysProcessEventsProcess

	/// <exclude/>
	public class VwQueueSysProcessEventsProcess : VwQueueSysProcess_OperatorSingleWindowEventsProcess
	{

		public VwQueueSysProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

