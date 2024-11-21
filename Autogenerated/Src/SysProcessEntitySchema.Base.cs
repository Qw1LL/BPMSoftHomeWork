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

	#region Class: SysProcessEntity_Base_BPMSoftSchema

	/// <exclude/>
	public class SysProcessEntity_Base_BPMSoftSchema : BPMSoft.Configuration.SysBaseProcessEntitySchema
	{

		#region Constructors: Public

		public SysProcessEntity_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessEntity_Base_BPMSoftSchema(SysProcessEntity_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessEntity_Base_BPMSoftSchema(SysProcessEntity_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysProcessEntity_EntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d9d3d491-459e-4147-a675-d4bfcbff6acd");
			index.Name = "IX_SysProcessEntity_EntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7c31ffa3-d76e-06f7-0987-765d0615fcfe"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIXSPE_EntitySchemaUIdEntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("b81c981e-76a1-4a35-87f9-75afc549af29");
			index.Name = "IXSPE_EntitySchemaUIdEntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entitySchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("621ef70c-7357-6560-463f-c66725c87d06"),
				ColumnUId = new Guid("36dc520e-160c-4d05-916b-2c4d4c0b0689"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entitySchemaUIdIndexColumn);
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("df46e2d2-e70a-6f02-72a7-d6c3f839038d"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			RealUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			Name = "SysProcessEntity_Base_BPMSoft";
			ParentSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3c7ebc1b-a71d-4072-b990-f7d4550774e8")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3c7ebc1b-a71d-4072-b990-f7d4550774e8"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SysProcessEntity_EntityIdIndex());
			Indexes.Add(CreateIXSPE_EntitySchemaUIdEntityIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessEntity_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessEntity_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessEntity_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity_Base_BPMSoft

	/// <summary>
	/// Object in process.
	/// </summary>
	public class SysProcessEntity_Base_BPMSoft : BPMSoft.Configuration.SysBaseProcessEntity
	{

		#region Constructors: Public

		public SysProcessEntity_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessEntity_Base_BPMSoft";
		}

		public SysProcessEntity_Base_BPMSoft(SysProcessEntity_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysProcessLog _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysProcessLog);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessEntity_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessEntity_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessEntity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysBaseProcessEntity_BaseEventsProcess<TEntity> where TEntity : SysProcessEntity_Base_BPMSoft
	{

		public SysProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessEntity_BaseEventsProcess";
			SchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
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

	#region Class: SysProcessEntity_BaseEventsProcess

	/// <exclude/>
	public class SysProcessEntity_BaseEventsProcess : SysProcessEntity_BaseEventsProcess<SysProcessEntity_Base_BPMSoft>
	{

		public SysProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessEntity_BaseEventsProcess

	public partial class SysProcessEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

