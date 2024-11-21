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

	#region Class: SysPrcPersistentStoreSchema

	/// <exclude/>
	public class SysPrcPersistentStoreSchema : BPMSoft.Configuration.SysPersistentStoreSchema
	{

		#region Constructors: Public

		public SysPrcPersistentStoreSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcPersistentStoreSchema(SysPrcPersistentStoreSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcPersistentStoreSchema(SysPrcPersistentStoreSchema source)
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

		private EntitySchemaIndex CreateSysPersStoreGroupKeyIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("6d4ce0fe-821a-4905-ba5b-ded0c0c7d855");
			index.Name = "SysPersStoreGroupKey";
			index.CreatedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			index.ModifiedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn groupKeyIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("9634f51f-f42c-4ae4-8020-626edb52eaaa"),
				ColumnUId = new Guid("71d06b6d-238f-475c-9d79-f8253167e7c7"),
				CreatedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608"),
				ModifiedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(groupKeyIndexColumn);
			EntitySchemaIndexColumn keyIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("050de166-dad1-4f27-be13-2713a457386c"),
				ColumnUId = new Guid("c0fd48aa-3304-417c-9dff-56d010a6f6de"),
				CreatedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608"),
				ModifiedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(keyIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			RealUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			Name = "SysPrcPersistentStore";
			ParentSchemaUId = new Guid("d718a0d7-8ea6-4a52-9ca7-b143262f13f9");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			return column;
		}

		protected override EntitySchemaColumn CreateGroupKeyColumn() {
			EntitySchemaColumn column = base.CreateGroupKeyColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysPersStoreCreatedOnIndex());
			Indexes.Add(CreateSysPersStoreGroupKeyIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcPersistentStore(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcPersistentStore_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcPersistentStoreSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcPersistentStoreSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcPersistentStore

	/// <summary>
	/// Process Persistent Store.
	/// </summary>
	public class SysPrcPersistentStore : BPMSoft.Configuration.SysPersistentStore
	{

		#region Constructors: Public

		public SysPrcPersistentStore(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcPersistentStore";
		}

		public SysPrcPersistentStore(SysPrcPersistentStore source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcPersistentStore_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcPersistentStoreDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPrcPersistentStoreValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcPersistentStore(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcPersistentStore_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcPersistentStore_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysPersistentStore_BaseEventsProcess<TEntity> where TEntity : SysPrcPersistentStore
	{

		public SysPrcPersistentStore_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcPersistentStore_BaseEventsProcess";
			SchemaUId = new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c7c8b94-a580-4b96-8840-f4c9ca322608");
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

	#region Class: SysPrcPersistentStore_BaseEventsProcess

	/// <exclude/>
	public class SysPrcPersistentStore_BaseEventsProcess : SysPrcPersistentStore_BaseEventsProcess<SysPrcPersistentStore>
	{

		public SysPrcPersistentStore_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcPersistentStore_BaseEventsProcess

	public partial class SysPrcPersistentStore_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcPersistentStoreEventsProcess

	/// <exclude/>
	public class SysPrcPersistentStoreEventsProcess : SysPrcPersistentStore_BaseEventsProcess
	{

		public SysPrcPersistentStoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

