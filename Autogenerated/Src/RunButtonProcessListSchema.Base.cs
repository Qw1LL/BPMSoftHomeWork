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

	#region Class: RunButtonProcessListSchema

	/// <exclude/>
	public class RunButtonProcessListSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RunButtonProcessListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RunButtonProcessListSchema(RunButtonProcessListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RunButtonProcessListSchema(RunButtonProcessListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			RealUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			Name = "RunButtonProcessList";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e3c93e3d-7f92-4a2c-92c1-92608c3370fa")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e3c93e3d-7f92-4a2c-92c1-92608c3370fa"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"),
				ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RunButtonProcessList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RunButtonProcessList_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RunButtonProcessListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RunButtonProcessListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"));
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList

	/// <summary>
	/// Run process button list setup.
	/// </summary>
	/// <remarks>
	/// Run process button list setup.
	/// </remarks>
	public class RunButtonProcessList : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RunButtonProcessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RunButtonProcessList";
		}

		public RunButtonProcessList(RunButtonProcessList source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new RunButtonProcessList_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RunButtonProcessListDeleted", e);
			Inserting += (s, e) => ThrowEvent("RunButtonProcessListInserting", e);
			Validating += (s, e) => ThrowEvent("RunButtonProcessListValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RunButtonProcessList(this);
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList_BaseEventsProcess

	/// <exclude/>
	public partial class RunButtonProcessList_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RunButtonProcessList
	{

		public RunButtonProcessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunButtonProcessList_BaseEventsProcess";
			SchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
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

	#region Class: RunButtonProcessList_BaseEventsProcess

	/// <exclude/>
	public class RunButtonProcessList_BaseEventsProcess : RunButtonProcessList_BaseEventsProcess<RunButtonProcessList>
	{

		public RunButtonProcessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RunButtonProcessList_BaseEventsProcess

	public partial class RunButtonProcessList_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RunButtonProcessListEventsProcess

	/// <exclude/>
	public class RunButtonProcessListEventsProcess : RunButtonProcessList_BaseEventsProcess
	{

		public RunButtonProcessListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

