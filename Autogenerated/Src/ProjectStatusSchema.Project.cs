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

	#region Class: ProjectStatusSchema

	/// <exclude/>
	public class ProjectStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProjectStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectStatusSchema(ProjectStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectStatusSchema(ProjectStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			RealUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			Name = "ProjectStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d133f56e-288a-4ce7-93c5-b84b02ebe33a")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d133f56e-288a-4ce7-93c5-b84b02ebe33a"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37"),
				ModifiedInSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectStatus_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectStatus

	/// <summary>
	/// Состояние проекта.
	/// </summary>
	public class ProjectStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProjectStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectStatus";
		}

		public ProjectStatus(ProjectStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectStatus_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectStatusDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectStatusInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectStatus_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectStatus_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProjectStatus
	{

		public ProjectStatus_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectStatus_ProjectEventsProcess";
			SchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37");
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

	#region Class: ProjectStatus_ProjectEventsProcess

	/// <exclude/>
	public class ProjectStatus_ProjectEventsProcess : ProjectStatus_ProjectEventsProcess<ProjectStatus>
	{

		public ProjectStatus_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectStatus_ProjectEventsProcess

	public partial class ProjectStatus_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectStatusEventsProcess

	/// <exclude/>
	public class ProjectStatusEventsProcess : ProjectStatus_ProjectEventsProcess
	{

		public ProjectStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

