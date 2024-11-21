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

	#region Class: SysSubProcessInProcessSchema

	/// <exclude/>
	public class SysSubProcessInProcessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSubProcessInProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSubProcessInProcessSchema(SysSubProcessInProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSubProcessInProcessSchema(SysSubProcessInProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4");
			RealUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4");
			Name = "SysSubProcessInProcess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fb7efc77-f006-4653-89e5-383b980315d3")) == null) {
				Columns.Add(CreateProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f089ad99-d3d8-4d17-b0d4-0008e761a4a0")) == null) {
				Columns.Add(CreateParentProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f3c1536b-43cc-48bc-ab57-93671ffc76ef")) == null) {
				Columns.Add(CreateSubProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("0c275024-8301-4d0e-9d16-2b9d849e8870")) == null) {
				Columns.Add(CreateParentSubProcessUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fb7efc77-f006-4653-89e5-383b980315d3"),
				Name = @"ProcessUId",
				CreatedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				ModifiedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90")
			};
		}

		protected virtual EntitySchemaColumn CreateParentProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f089ad99-d3d8-4d17-b0d4-0008e761a4a0"),
				Name = @"ParentProcessUId",
				CreatedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				ModifiedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90")
			};
		}

		protected virtual EntitySchemaColumn CreateSubProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f3c1536b-43cc-48bc-ab57-93671ffc76ef"),
				Name = @"SubProcessUId",
				CreatedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				ModifiedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90")
			};
		}

		protected virtual EntitySchemaColumn CreateParentSubProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0c275024-8301-4d0e-9d16-2b9d849e8870"),
				Name = @"ParentSubProcessUId",
				CreatedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				ModifiedInSchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"),
				CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSubProcessInProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSubProcessInProcess_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSubProcessInProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSubProcessInProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSubProcessInProcess

	/// <summary>
	/// SysSubProcessInProcess.
	/// </summary>
	public class SysSubProcessInProcess : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSubProcessInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSubProcessInProcess";
		}

		public SysSubProcessInProcess(SysSubProcessInProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ProcessUId.
		/// </summary>
		public Guid ProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessUId");
			}
			set {
				SetColumnValue("ProcessUId", value);
			}
		}

		/// <summary>
		/// ParentProcessUId.
		/// </summary>
		public Guid ParentProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ParentProcessUId");
			}
			set {
				SetColumnValue("ParentProcessUId", value);
			}
		}

		/// <summary>
		/// SubProcessUId.
		/// </summary>
		public Guid SubProcessUId {
			get {
				return GetTypedColumnValue<Guid>("SubProcessUId");
			}
			set {
				SetColumnValue("SubProcessUId", value);
			}
		}

		/// <summary>
		/// ParentSubProcessUId.
		/// </summary>
		public Guid ParentSubProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ParentSubProcessUId");
			}
			set {
				SetColumnValue("ParentSubProcessUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSubProcessInProcess_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSubProcessInProcessDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSubProcessInProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSubProcessInProcess_BaseEventsProcess

	/// <exclude/>
	public partial class SysSubProcessInProcess_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSubProcessInProcess
	{

		public SysSubProcessInProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSubProcessInProcess_BaseEventsProcess";
			SchemaUId = new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("40bba32d-291c-41a1-8445-64f60f26b2d4");
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

	#region Class: SysSubProcessInProcess_BaseEventsProcess

	/// <exclude/>
	public class SysSubProcessInProcess_BaseEventsProcess : SysSubProcessInProcess_BaseEventsProcess<SysSubProcessInProcess>
	{

		public SysSubProcessInProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSubProcessInProcess_BaseEventsProcess

	public partial class SysSubProcessInProcess_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSubProcessInProcessEventsProcess

	/// <exclude/>
	public class SysSubProcessInProcessEventsProcess : SysSubProcessInProcess_BaseEventsProcess
	{

		public SysSubProcessInProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

