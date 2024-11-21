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

	#region Class: SysRecentEntitySchema

	/// <exclude/>
	public class SysRecentEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysRecentEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRecentEntitySchema(SysRecentEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRecentEntitySchema(SysRecentEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_USEDONIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("55af71fb-ab2d-4c1d-9cdb-e17ef8fc86f5");
			index.Name = "IDX_USEDON";
			index.CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
			index.ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn usedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ac6c0780-c4f4-432f-99c2-d7af9916c568"),
				ColumnUId = new Guid("9edb17cb-30d2-4950-8f15-fa3da72bf164"),
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(usedOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
			RealUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
			Name = "SysRecentEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntityCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d75e0423-e043-478d-a44b-731db30588ce")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("46458579-9344-4d74-aedb-00a3cade1e46")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("9edb17cb-30d2-4950-8f15-fa3da72bf164")) == null) {
				Columns.Add(CreateUsedOnColumn());
			}
			if (Columns.FindByUId(new Guid("4edff1ad-8471-41ca-a7cb-e2872a90e0ee")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d75e0423-e043-478d-a44b-731db30588ce"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0fc15c07-2c8e-4f74-bd95-58cbae046e9c"),
				Name = @"EntityCaption",
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("46458579-9344-4d74-aedb-00a3cade1e46"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUser")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUsedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9edb17cb-30d2-4950-8f15-fa3da72bf164"),
				Name = @"UsedOn",
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4edff1ad-8471-41ca-a7cb-e2872a90e0ee"),
				Name = @"SysEntitySchemaUId",
				CreatedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				ModifiedInSchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_USEDONIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRecentEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRecentEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRecentEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRecentEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("501e569a-fd18-4c8a-a718-36b46451f27a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRecentEntity

	/// <summary>
	/// Recent item.
	/// </summary>
	public class SysRecentEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysRecentEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRecentEntity";
		}

		public SysRecentEntity(SysRecentEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object Id.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// Primary object value.
		/// </summary>
		public string EntityCaption {
			get {
				return GetTypedColumnValue<string>("EntityCaption");
			}
			set {
				SetColumnValue("EntityCaption", value);
			}
		}

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Last opened.
		/// </summary>
		public DateTime UsedOn {
			get {
				return GetTypedColumnValue<DateTime>("UsedOn");
			}
			set {
				SetColumnValue("UsedOn", value);
			}
		}

		/// <summary>
		/// Unique identifier of object schema.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysRecentEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysRecentEntityDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysRecentEntityDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysRecentEntityInserted", e);
			Inserting += (s, e) => ThrowEvent("SysRecentEntityInserting", e);
			Saved += (s, e) => ThrowEvent("SysRecentEntitySaved", e);
			Saving += (s, e) => ThrowEvent("SysRecentEntitySaving", e);
			Validating += (s, e) => ThrowEvent("SysRecentEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysRecentEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRecentEntity_BaseEventsProcess

	/// <exclude/>
	public partial class SysRecentEntity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysRecentEntity
	{

		public SysRecentEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRecentEntity_BaseEventsProcess";
			SchemaUId = new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("501e569a-fd18-4c8a-a718-36b46451f27a");
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

	#region Class: SysRecentEntity_BaseEventsProcess

	/// <exclude/>
	public class SysRecentEntity_BaseEventsProcess : SysRecentEntity_BaseEventsProcess<SysRecentEntity>
	{

		public SysRecentEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRecentEntity_BaseEventsProcess

	public partial class SysRecentEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRecentEntityEventsProcess

	/// <exclude/>
	public class SysRecentEntityEventsProcess : SysRecentEntity_BaseEventsProcess
	{

		public SysRecentEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

