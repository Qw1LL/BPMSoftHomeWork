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

	#region Class: BaseCommunicationSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseCommunicationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseCommunicationSchema(BaseCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseCommunicationSchema(BaseCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			RealUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			Name = "BaseCommunication";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("12f1d73a-43c5-4a52-9bd6-3e0ecafd3fb4")) == null) {
				Columns.Add(CreateCommunicationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0c103353-496a-4ff9-a8eb-877dfed4af26")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("c8c5a7d8-f9c8-420a-af2a-cdb3f130e16d")) == null) {
				Columns.Add(CreateSocialMediaIdColumn());
			}
			if (Columns.FindByUId(new Guid("44278aac-22bf-44eb-8b94-c5e9b3525027")) == null) {
				Columns.Add(CreateSearchNumberColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("12f1d73a-43c5-4a52-9bd6-3e0ecafd3fb4"),
				Name = @"CommunicationType",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("02fcae57-fafa-4e4f-9367-b58317a6e2ec"),
				Name = @"Number",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0c103353-496a-4ff9-a8eb-877dfed4af26"),
				Name = @"Position",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMediaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c8c5a7d8-f9c8-420a-af2a-cdb3f130e16d"),
				Name = @"SocialMediaId",
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("44278aac-22bf-44eb-8b94-c5e9b3525027"),
				Name = @"SearchNumber",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseCommunication_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseCommunication

	/// <summary>
	/// Base communication option.
	/// </summary>
	public class BaseCommunication : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCommunication";
		}

		public BaseCommunication(BaseCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// Type.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = LookupColumnEntities.GetEntity("CommunicationType") as CommunicationType);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
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

		/// <summary>
		/// Social network Id.
		/// </summary>
		public string SocialMediaId {
			get {
				return GetTypedColumnValue<string>("SocialMediaId");
			}
			set {
				SetColumnValue("SocialMediaId", value);
			}
		}

		/// <summary>
		/// Number for search.
		/// </summary>
		public string SearchNumber {
			get {
				return GetTypedColumnValue<string>("SearchNumber");
			}
			set {
				SetColumnValue("SearchNumber", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseCommunication_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseCommunicationDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseCommunicationDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseCommunicationInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseCommunicationInserting", e);
			Saved += (s, e) => ThrowEvent("BaseCommunicationSaved", e);
			Saving += (s, e) => ThrowEvent("BaseCommunicationSaving", e);
			Validating += (s, e) => ThrowEvent("BaseCommunicationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseCommunication_BaseEventsProcess

	/// <exclude/>
	public partial class BaseCommunication_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseCommunication
	{

		public BaseCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseCommunication_BaseEventsProcess";
			SchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
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

	#region Class: BaseCommunication_BaseEventsProcess

	/// <exclude/>
	public class BaseCommunication_BaseEventsProcess : BaseCommunication_BaseEventsProcess<BaseCommunication>
	{

		public BaseCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseCommunication_BaseEventsProcess

	public partial class BaseCommunication_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Entity GetCommunicationParentEntity(string schemaName, Guid id) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var entity = schema.CreateEntity(UserConnection);
			entity.FetchFromDB(id);
			return entity;
		}

		public virtual bool GetCanEditColumn(string schemaName, string columnName) {
			EntitySchemaColumnRightLevel rightLevel = UserConnection.DBSecurityEngine
					.GetEntitySchemaColumnRightLevel(schemaName, columnName, SchemaOperationRightLevels.CanEdit);
			return (rightLevel & EntitySchemaColumnRightLevel.CanEdit) == EntitySchemaColumnRightLevel.CanEdit;
		}

		public virtual void UpdateCommunicationParentEntity(string schemaName, Guid parentEntityId, string typedColumnName) {
			var parentEntity = GetCommunicationParentEntity(schemaName, parentEntityId);
			if (parentEntity == null) {
				return;
			}
			bool isCanEdit = GetCanEditColumn(schemaName, typedColumnName);
			if (isCanEdit) {
				var number = Entity.GetTypedColumnValue<string>("Number");
				SetCommunicationParentEntityColumns(parentEntity);
			}
			parentEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
			parentEntity.CreateUpdate().Execute();
			TrackingChangedColumns(parentEntity);
		}

		public virtual void SetCommunicationParentEntityColumns(Entity parentEntity) {
		}

		public virtual void TrackingChangedColumns(Entity parentEntity) {
			var schemaName = parentEntity.Schema.Name;
			var parentSchema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			parentEntity.TrackChangeInDB(parentSchema);
		}

		#endregion

	}

	#endregion


	#region Class: BaseCommunicationEventsProcess

	/// <exclude/>
	public class BaseCommunicationEventsProcess : BaseCommunication_BaseEventsProcess
	{

		public BaseCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

