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

	#region Class: DepartmentSchema

	/// <exclude/>
	public class DepartmentSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DepartmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DepartmentSchema(DepartmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DepartmentSchema(DepartmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
			RealUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
			Name = "Department";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Department(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Department_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DepartmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DepartmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"));
		}

		#endregion

	}

	#endregion

	#region Class: Department

	/// <summary>
	/// Department.
	/// </summary>
	public class Department : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Department(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Department";
		}

		public Department(Department source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Department_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DepartmentDeleted", e);
			Deleting += (s, e) => ThrowEvent("DepartmentDeleting", e);
			Inserted += (s, e) => ThrowEvent("DepartmentInserted", e);
			Inserting += (s, e) => ThrowEvent("DepartmentInserting", e);
			Saved += (s, e) => ThrowEvent("DepartmentSaved", e);
			Saving += (s, e) => ThrowEvent("DepartmentSaving", e);
			Validating += (s, e) => ThrowEvent("DepartmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Department(this);
		}

		#endregion

	}

	#endregion

	#region Class: Department_BaseEventsProcess

	/// <exclude/>
	public partial class Department_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Department
	{

		public Department_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Department_BaseEventsProcess";
			SchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8");
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

	#region Class: Department_BaseEventsProcess

	/// <exclude/>
	public class Department_BaseEventsProcess : Department_BaseEventsProcess<Department>
	{

		public Department_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Department_BaseEventsProcess

	public partial class Department_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: DepartmentEventsProcess

	/// <exclude/>
	public class DepartmentEventsProcess : Department_BaseEventsProcess
	{

		public DepartmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

