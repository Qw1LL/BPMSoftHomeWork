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

	#region Class: EntitySynchronizerSchema

	/// <exclude/>
	public class EntitySynchronizerSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntitySynchronizerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntitySynchronizerSchema(EntitySynchronizerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntitySynchronizerSchema(EntitySynchronizerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateRemoteKey_UniqueIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("c00c6925-bb27-4a0c-98bc-fae1917e28cd");
			index.Name = "RemoteKey_Unique";
			index.CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			index.ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			index.CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d");
			EntitySchemaIndexColumn remoteKeyIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3295e00f-7a7b-4aa0-aba7-b8e24eb9587c"),
				ColumnUId = new Guid("75ec57bf-77be-4b9e-9c83-7e05c32c40ef"),
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(remoteKeyIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateEntity_CreatedBy_System_UniqueIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f6eefece-6677-4ce0-8d2f-0cc1a55fbb45");
			index.Name = "Entity_CreatedBy_System_Unique";
			index.CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			index.ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			index.CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d");
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dcaaed9c-c7ca-4711-8d4f-60c5ff69278f"),
				ColumnUId = new Guid("222df7a2-ccbd-4184-8ac2-89653ca4a2d7"),
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			EntitySchemaIndexColumn createdByIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a5f5cc32-1f03-4679-a2ae-c570b7d08d99"),
				ColumnUId = new Guid("ebf6bb93-8aa6-4a01-900d-c6ea67affe21"),
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(createdByIdIndexColumn);
			EntitySchemaIndexColumn integrationSystemIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("068b6a66-be5b-46de-805c-692e201d4046"),
				ColumnUId = new Guid("e97bcaf3-daf4-4132-ae8d-966512fd3090"),
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(integrationSystemIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			RealUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			Name = "EntitySynchronizer";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("75ec57bf-77be-4b9e-9c83-7e05c32c40ef")) == null) {
				Columns.Add(CreateRemoteKeyColumn());
			}
			if (Columns.FindByUId(new Guid("222df7a2-ccbd-4184-8ac2-89653ca4a2d7")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("e97bcaf3-daf4-4132-ae8d-966512fd3090")) == null) {
				Columns.Add(CreateIntegrationSystemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRemoteKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("75ec57bf-77be-4b9e-9c83-7e05c32c40ef"),
				Name = @"RemoteKey",
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("222df7a2-ccbd-4184-8ac2-89653ca4a2d7"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("008b5e35-cd1d-462d-aec0-4fb9d28e872d")
			};
		}

		protected virtual EntitySchemaColumn CreateIntegrationSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e97bcaf3-daf4-4132-ae8d-966512fd3090"),
				Name = @"IntegrationSystem",
				CreatedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				ModifiedInSchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54"),
				CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateRemoteKey_UniqueIndex());
			Indexes.Add(CreateEntity_CreatedBy_System_UniqueIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntitySynchronizer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntitySynchronizer_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntitySynchronizerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntitySynchronizerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("062699d9-028d-4266-8f21-66b4c9394f54"));
		}

		#endregion

	}

	#endregion

	#region Class: EntitySynchronizer

	/// <summary>
	/// Entity external repository linkage.
	/// </summary>
	public class EntitySynchronizer : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntitySynchronizer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntitySynchronizer";
		}

		public EntitySynchronizer(EntitySynchronizer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Remote key.
		/// </summary>
		public string RemoteKey {
			get {
				return GetTypedColumnValue<string>("RemoteKey");
			}
			set {
				SetColumnValue("RemoteKey", value);
			}
		}

		/// <summary>
		/// EntityId.
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
		/// IntegrationSystem.
		/// </summary>
		public string IntegrationSystem {
			get {
				return GetTypedColumnValue<string>("IntegrationSystem");
			}
			set {
				SetColumnValue("IntegrationSystem", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntitySynchronizer_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EntitySynchronizerDeleted", e);
			Validating += (s, e) => ThrowEvent("EntitySynchronizerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntitySynchronizer(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntitySynchronizer_BaseEventsProcess

	/// <exclude/>
	public partial class EntitySynchronizer_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EntitySynchronizer
	{

		public EntitySynchronizer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntitySynchronizer_BaseEventsProcess";
			SchemaUId = new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("062699d9-028d-4266-8f21-66b4c9394f54");
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

	#region Class: EntitySynchronizer_BaseEventsProcess

	/// <exclude/>
	public class EntitySynchronizer_BaseEventsProcess : EntitySynchronizer_BaseEventsProcess<EntitySynchronizer>
	{

		public EntitySynchronizer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntitySynchronizer_BaseEventsProcess

	public partial class EntitySynchronizer_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntitySynchronizerEventsProcess

	/// <exclude/>
	public class EntitySynchronizerEventsProcess : EntitySynchronizer_BaseEventsProcess
	{

		public EntitySynchronizerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

