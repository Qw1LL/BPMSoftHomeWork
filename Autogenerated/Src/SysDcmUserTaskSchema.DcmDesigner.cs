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

	#region Class: SysDcmUserTaskSchema

	/// <exclude/>
	public class SysDcmUserTaskSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDcmUserTaskSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDcmUserTaskSchema(SysDcmUserTaskSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDcmUserTaskSchema(SysDcmUserTaskSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795");
			RealUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795");
			Name = "SysDcmUserTask";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c9089cd6-c7fc-4c89-ae0d-da891132232d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1dbf6705-f9e1-476d-9128-be6c70790668")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("76732351-6bf4-4f02-ba1c-73ab5a95a438")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1dbf6705-f9e1-476d-9128-be6c70790668"),
				Name = @"SchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795"),
				ModifiedInSchemaUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795"),
				CreatedInPackageId = new Guid("c9089cd6-c7fc-4c89-ae0d-da891132232d")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("76732351-6bf4-4f02-ba1c-73ab5a95a438"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795"),
				ModifiedInSchemaUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795"),
				CreatedInPackageId = new Guid("c9089cd6-c7fc-4c89-ae0d-da891132232d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDcmUserTask(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDcmUserTask_DcmDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDcmUserTaskSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDcmUserTaskSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmUserTask

	/// <summary>
	/// DCM user task.
	/// </summary>
	public class SysDcmUserTask : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDcmUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDcmUserTask";
		}

		public SysDcmUserTask(SysDcmUserTask source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Identifier of user task.
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
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDcmUserTask_DcmDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDcmUserTaskDeleted", e);
			Validating += (s, e) => ThrowEvent("SysDcmUserTaskValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDcmUserTask(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmUserTask_DcmDesignerEventsProcess

	/// <exclude/>
	public partial class SysDcmUserTask_DcmDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysDcmUserTask
	{

		public SysDcmUserTask_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDcmUserTask_DcmDesignerEventsProcess";
			SchemaUId = new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07eed1f5-14ee-4a2c-b771-e986f04b1795");
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

	#region Class: SysDcmUserTask_DcmDesignerEventsProcess

	/// <exclude/>
	public class SysDcmUserTask_DcmDesignerEventsProcess : SysDcmUserTask_DcmDesignerEventsProcess<SysDcmUserTask>
	{

		public SysDcmUserTask_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDcmUserTask_DcmDesignerEventsProcess

	public partial class SysDcmUserTask_DcmDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDcmUserTaskEventsProcess

	/// <exclude/>
	public class SysDcmUserTaskEventsProcess : SysDcmUserTask_DcmDesignerEventsProcess
	{

		public SysDcmUserTaskEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

