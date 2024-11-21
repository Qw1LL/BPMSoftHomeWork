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

	#region Class: ProcessInModules_Base_BPMSoftSchema

	/// <exclude/>
	public class ProcessInModules_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProcessInModules_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessInModules_Base_BPMSoftSchema(ProcessInModules_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessInModules_Base_BPMSoftSchema(ProcessInModules_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			RealUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			Name = "ProcessInModules_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4420cc5f-5a43-490b-b583-f8572ac29dce")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("a9f680eb-bc67-4aac-919e-0ad9f1000690")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4420cc5f-5a43-490b-b583-f8572ac29dce"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a9f680eb-bc67-4aac-919e-0ad9f1000690"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessInModules_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessInModules_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessInModules_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessInModules_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInModules_Base_BPMSoft

	/// <summary>
	/// Business processes in sections.
	/// </summary>
	/// <remarks>
	/// Business processes in sections.
	/// </remarks>
	public class ProcessInModules_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProcessInModules_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessInModules_Base_BPMSoft";
		}

		public ProcessInModules_Base_BPMSoft(ProcessInModules_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
			}
		}

		/// <summary>
		/// Process.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessInModules_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProcessInModules_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProcessInModules_Base_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("ProcessInModules_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProcessInModules_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInModules_BaseEventsProcess

	/// <exclude/>
	public partial class ProcessInModules_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProcessInModules_Base_BPMSoft
	{

		public ProcessInModules_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessInModules_BaseEventsProcess";
			SchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
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

	#region Class: ProcessInModules_BaseEventsProcess

	/// <exclude/>
	public class ProcessInModules_BaseEventsProcess : ProcessInModules_BaseEventsProcess<ProcessInModules_Base_BPMSoft>
	{

		public ProcessInModules_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessInModules_BaseEventsProcess

	public partial class ProcessInModules_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

