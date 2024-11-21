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

	#region Class: SysPersistentStoreSchema

	/// <exclude/>
	[IsVirtual]
	public class SysPersistentStoreSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPersistentStoreSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPersistentStoreSchema(SysPersistentStoreSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPersistentStoreSchema(SysPersistentStoreSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysPersStoreCreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d9cf0e69-79ef-414c-a010-7def7d285ad5");
			index.Name = "ISysPersStoreCreatedOn";
			index.CreatedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			index.ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			index.CreatedInPackageId = new Guid("53c6a55b-73f6-4900-9445-a818892f6106");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("95e136c4-66d1-4111-9363-370f74c60383"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				CreatedInPackageId = new Guid("53c6a55b-73f6-4900-9445-a818892f6106"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			RealUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			Name = "SysPersistentStore";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("71d06b6d-238f-475c-9d79-f8253167e7c7")) == null) {
				Columns.Add(CreateGroupKeyColumn());
			}
			if (Columns.FindByUId(new Guid("c0fd48aa-3304-417c-9dff-56d010a6f6de")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("28682aff-b65b-4f76-9f25-026cf3de969b")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			return column;
		}

		protected virtual EntitySchemaColumn CreateGroupKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("71d06b6d-238f-475c-9d79-f8253167e7c7"),
				Name = @"GroupKey",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c0fd48aa-3304-417c-9dff-56d010a6f6de"),
				Name = @"Key",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("28682aff-b65b-4f76-9f25-026cf3de969b"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				ModifiedInSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysPersStoreCreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPersistentStore(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPersistentStore_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPersistentStoreSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPersistentStoreSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPersistentStore

	/// <summary>
	/// Base Persistent Store.
	/// </summary>
	public class SysPersistentStore : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPersistentStore(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPersistentStore";
		}

		public SysPersistentStore(SysPersistentStore source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Group key.
		/// </summary>
		public string GroupKey {
			get {
				return GetTypedColumnValue<string>("GroupKey");
			}
			set {
				SetColumnValue("GroupKey", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPersistentStore_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPersistentStoreDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPersistentStoreValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPersistentStore(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPersistentStore_BaseEventsProcess

	/// <exclude/>
	public partial class SysPersistentStore_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPersistentStore
	{

		public SysPersistentStore_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPersistentStore_BaseEventsProcess";
			SchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
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

	#region Class: SysPersistentStore_BaseEventsProcess

	/// <exclude/>
	public class SysPersistentStore_BaseEventsProcess : SysPersistentStore_BaseEventsProcess<SysPersistentStore>
	{

		public SysPersistentStore_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPersistentStore_BaseEventsProcess

	public partial class SysPersistentStore_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPersistentStoreEventsProcess

	/// <exclude/>
	public class SysPersistentStoreEventsProcess : SysPersistentStore_BaseEventsProcess
	{

		public SysPersistentStoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

