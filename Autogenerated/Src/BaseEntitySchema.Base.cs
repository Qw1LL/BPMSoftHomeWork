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

	#region Class: BaseEntity_Base_BPMSoftSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntity_Base_BPMSoftSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public BaseEntity_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntity_Base_BPMSoftSchema(BaseEntity_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntity_Base_BPMSoftSchema(BaseEntity_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			RealUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			Name = "BaseEntity_Base_BPMSoft";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeCreatedOnColumn() {
			base.InitializeCreatedOnColumn();
			CreatedOnColumn = CreateCreatedOnColumn();
			if (Columns.FindByUId(CreatedOnColumn.UId) == null) {
				Columns.Add(CreatedOnColumn);
			}
		}

		protected override void InitializeCreatedByColumn() {
			base.InitializeCreatedByColumn();
			CreatedByColumn = CreateCreatedByColumn();
			if (Columns.FindByUId(CreatedByColumn.UId) == null) {
				Columns.Add(CreatedByColumn);
			}
		}

		protected override void InitializeModifiedOnColumn() {
			base.InitializeModifiedOnColumn();
			ModifiedOnColumn = CreateModifiedOnColumn();
			if (Columns.FindByUId(ModifiedOnColumn.UId) == null) {
				Columns.Add(ModifiedOnColumn);
			}
		}

		protected override void InitializeModifiedByColumn() {
			base.InitializeModifiedByColumn();
			ModifiedByColumn = CreateModifiedByColumn();
			if (Columns.FindByUId(ModifiedByColumn.UId) == null) {
				Columns.Add(ModifiedByColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3fabd836-6a53-4d8d-9069-6df88d9dae1e")) == null) {
				Columns.Add(CreateProcessListenersColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				Name = @"CreatedOn",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ebf6bb93-8aa6-4a01-900d-c6ea67affe21"),
				Name = @"CreatedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9928edec-4272-425a-93bb-48743fee4b04"),
				Name = @"ModifiedOn",
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3015559e-cbc6-406a-88af-07f7930be832"),
				Name = @"ModifiedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateProcessListenersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3fabd836-6a53-4d8d-9069-6df88d9dae1e"),
				Name = @"ProcessListeners",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
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
			return new BaseEntity_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntity_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntity_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntity_Base_BPMSoft

	/// <summary>
	/// Базовый объект.
	/// </summary>
	public class BaseEntity_Base_BPMSoft : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BaseEntity_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntity_Base_BPMSoft";
		}

		public BaseEntity_Base_BPMSoft(BaseEntity_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = LookupColumnEntities.GetEntity("CreatedBy") as Contact);
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = LookupColumnEntities.GetEntity("ModifiedBy") as Contact);
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("BaseEntity_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntity_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntity_BaseEventsProcess

	/// <exclude/>
	public partial class BaseEntity_BaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : BaseEntity_Base_BPMSoft
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public BaseEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntity_BaseEventsProcess";
			SchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Object ProcessListeners {
			get;
			set;
		}

		public virtual Object ProcessSchemaListeners {
			get;
			set;
		}

		public virtual bool NextProcessElementReady {
			get;
			set;
		}

		public virtual bool IsProcessModeSave {
			get;
			set;
		}

		public virtual bool CanUseDcm {
			get;
			set;
		}

		public virtual Object DcmEntityUtil {
			get;
			set;
		}

		private ProcessFlowElement _baseEntityDeletingEventSubProcess2;
		public ProcessFlowElement BaseEntityDeletingEventSubProcess2 {
			get {
				return _baseEntityDeletingEventSubProcess2 ?? (_baseEntityDeletingEventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletingEventSubProcess2",
					SchemaElementUId = new Guid("08594d74-60b0-45ce-bf17-bac1a8b127f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletingStartMessage2;
		public ProcessFlowElement BaseEntityDeletingStartMessage2 {
			get {
				return _baseEntityDeletingStartMessage2 ?? (_baseEntityDeletingStartMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletingStartMessage2",
					SchemaElementUId = new Guid("496d4a3c-b644-4a65-b0ed-2534d9236da5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask2;
		public ProcessScriptTask TryProcessCompleteScriptTask2 {
			get {
				return _tryProcessCompleteScriptTask2 ?? (_tryProcessCompleteScriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask2",
					SchemaElementUId = new Guid("441daff4-4808-48db-ac28-d9a42d61ac31"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask2Execute,
				});
			}
		}

		private ProcessFlowElement _baseEntityEventSubProcess1;
		public ProcessFlowElement BaseEntityEventSubProcess1 {
			get {
				return _baseEntityEventSubProcess1 ?? (_baseEntityEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityEventSubProcess1",
					SchemaElementUId = new Guid("90027ac8-c9c3-4d21-a4f9-da1cde752cd1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityStartMessage1;
		public ProcessFlowElement BaseEntityStartMessage1 {
			get {
				return _baseEntityStartMessage1 ?? (_baseEntityStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityStartMessage1",
					SchemaElementUId = new Guid("d8b8410f-5c8a-4ddc-8fc2-353483452aed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask1;
		public ProcessScriptTask TryProcessCompleteScriptTask1 {
			get {
				return _tryProcessCompleteScriptTask1 ?? (_tryProcessCompleteScriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask1",
					SchemaElementUId = new Guid("9494818b-220e-4e19-a635-fdca641dde5f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask1Execute,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavedIndexingTask;
		public ProcessScriptTask BaseEntitySavedIndexingTask {
			get {
				return _baseEntitySavedIndexingTask ?? (_baseEntitySavedIndexingTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavedIndexingTask",
					SchemaElementUId = new Guid("b8ff0739-6ead-4da7-ac8d-538cfc641fcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavedIndexingTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseInsertedEventSubProcess;
		public ProcessFlowElement BaseInsertedEventSubProcess {
			get {
				return _baseInsertedEventSubProcess ?? (_baseInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseInsertedEventSubProcess",
					SchemaElementUId = new Guid("5f3bfbbe-1820-44ca-92f1-6f993169b2dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _insertedStartMessage1;
		public ProcessFlowElement InsertedStartMessage1 {
			get {
				return _insertedStartMessage1 ?? (_insertedStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InsertedStartMessage1",
					SchemaElementUId = new Guid("d7c806b7-a29b-4ce5-9167-b3319472e772"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskInsertedBaseEntity;
		public ProcessScriptTask ScriptTaskInsertedBaseEntity {
			get {
				return _scriptTaskInsertedBaseEntity ?? (_scriptTaskInsertedBaseEntity = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskInsertedBaseEntity",
					SchemaElementUId = new Guid("5528724d-213b-4ae6-88d5-aa7301a1dbb0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskInsertedBaseEntityExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingEventSubProcess;
		public ProcessFlowElement BaseEntitySavingEventSubProcess {
			get {
				return _baseEntitySavingEventSubProcess ?? (_baseEntitySavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntitySavingEventSubProcess",
					SchemaElementUId = new Guid("dbf48103-dcf6-4f53-a052-d727a95ea0b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingStartMessage;
		public ProcessFlowElement BaseEntitySavingStartMessage {
			get {
				return _baseEntitySavingStartMessage ?? (_baseEntitySavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntitySavingStartMessage",
					SchemaElementUId = new Guid("933bf2fc-d052-40c8-a3e0-bf60049da5d8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavingScriptTask;
		public ProcessScriptTask BaseEntitySavingScriptTask {
			get {
				return _baseEntitySavingScriptTask ?? (_baseEntitySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavingScriptTask",
					SchemaElementUId = new Guid("9b990da0-84e4-4aa1-ab8f-219ff3a429fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9;
		public ProcessFlowElement BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 {
			get {
				return _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 ?? (_baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9",
					SchemaElementUId = new Guid("f0646c74-f291-474f-9a10-143ee868f1c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428;
		public ProcessFlowElement BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 {
			get {
				return _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 ?? (_baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428",
					SchemaElementUId = new Guid("b3d5b61f-7afe-48b5-a8cc-40317ea9c428"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f;
		public ProcessScriptTask BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f {
			get {
				return _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f ?? (_baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f",
					SchemaElementUId = new Guid("a553628e-f6dc-4e09-bdcf-27e446fdc16f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedSubProcess;
		public ProcessFlowElement BaseEntityDeletedSubProcess {
			get {
				return _baseEntityDeletedSubProcess ?? (_baseEntityDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletedSubProcess",
					SchemaElementUId = new Guid("8140d7e7-fb91-4999-8347-543345440efb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedStartMessage;
		public ProcessFlowElement BaseEntityDeletedStartMessage {
			get {
				return _baseEntityDeletedStartMessage ?? (_baseEntityDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletedStartMessage",
					SchemaElementUId = new Guid("c803a450-c8dc-47a4-b704-7125c23db317"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntityDeletedScriptTask;
		public ProcessScriptTask BaseEntityDeletedScriptTask {
			get {
				return _baseEntityDeletedScriptTask ?? (_baseEntityDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntityDeletedScriptTask",
					SchemaElementUId = new Guid("60f96d87-85be-4d31-856d-8edd6bb953c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntityDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseEntityDeletingEventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingEventSubProcess2 };
			FlowElements[BaseEntityDeletingStartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingStartMessage2 };
			FlowElements[TryProcessCompleteScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask2 };
			FlowElements[BaseEntityEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityEventSubProcess1 };
			FlowElements[BaseEntityStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityStartMessage1 };
			FlowElements[TryProcessCompleteScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask1 };
			FlowElements[BaseEntitySavedIndexingTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavedIndexingTask };
			FlowElements[BaseInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseInsertedEventSubProcess };
			FlowElements[InsertedStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedStartMessage1 };
			FlowElements[ScriptTaskInsertedBaseEntity.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskInsertedBaseEntity };
			FlowElements[BaseEntitySavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingEventSubProcess };
			FlowElements[BaseEntitySavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingStartMessage };
			FlowElements[BaseEntitySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingScriptTask };
			FlowElements[BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 };
			FlowElements[BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 };
			FlowElements[BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f };
			FlowElements[BaseEntityDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedSubProcess };
			FlowElements[BaseEntityDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedStartMessage };
			FlowElements[BaseEntityDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseEntityDeletingEventSubProcess2":
						break;
					case "BaseEntityDeletingStartMessage2":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask2");
						break;
					case "TryProcessCompleteScriptTask2":
						break;
					case "BaseEntityEventSubProcess1":
						break;
					case "BaseEntityStartMessage1":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask1");
						e.Context.QueueTasks.Enqueue("BaseEntitySavedIndexingTask");
						break;
					case "TryProcessCompleteScriptTask1":
						break;
					case "BaseEntitySavedIndexingTask":
						break;
					case "BaseInsertedEventSubProcess":
						break;
					case "InsertedStartMessage1":
						e.Context.QueueTasks.Enqueue("ScriptTaskInsertedBaseEntity");
						break;
					case "ScriptTaskInsertedBaseEntity":
						break;
					case "BaseEntitySavingEventSubProcess":
						break;
					case "BaseEntitySavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntitySavingScriptTask");
						break;
					case "BaseEntitySavingScriptTask":
						break;
					case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
						break;
					case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
						e.Context.QueueTasks.Enqueue("BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f");
						break;
					case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
						break;
					case "BaseEntityDeletedSubProcess":
						break;
					case "BaseEntityDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntityDeletedScriptTask");
						break;
					case "BaseEntityDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseEntityDeletingStartMessage2");
			ActivatedEventElements.Add("BaseEntityStartMessage1");
			ActivatedEventElements.Add("InsertedStartMessage1");
			ActivatedEventElements.Add("BaseEntitySavingStartMessage");
			ActivatedEventElements.Add("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
			ActivatedEventElements.Add("BaseEntityDeletedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseEntityDeletingEventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletingStartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletingStartMessage2";
					result = BaseEntityDeletingStartMessage2.Execute(context);
					break;
				case "TryProcessCompleteScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask2";
					result = TryProcessCompleteScriptTask2.Execute(context, TryProcessCompleteScriptTask2Execute);
					break;
				case "BaseEntityEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityStartMessage1";
					result = BaseEntityStartMessage1.Execute(context);
					break;
				case "TryProcessCompleteScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask1";
					result = TryProcessCompleteScriptTask1.Execute(context, TryProcessCompleteScriptTask1Execute);
					break;
				case "BaseEntitySavedIndexingTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavedIndexingTask";
					result = BaseEntitySavedIndexingTask.Execute(context, BaseEntitySavedIndexingTaskExecute);
					break;
				case "BaseInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "InsertedStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertedStartMessage1";
					result = InsertedStartMessage1.Execute(context);
					break;
				case "ScriptTaskInsertedBaseEntity":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskInsertedBaseEntity";
					result = ScriptTaskInsertedBaseEntity.Execute(context, ScriptTaskInsertedBaseEntityExecute);
					break;
				case "BaseEntitySavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntitySavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingStartMessage";
					result = BaseEntitySavingStartMessage.Execute(context);
					break;
				case "BaseEntitySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingScriptTask";
					result = BaseEntitySavingScriptTask.Execute(context, BaseEntitySavingScriptTaskExecute);
					break;
				case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428";
					result = BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.Execute(context);
					break;
				case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f";
					result = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.Execute(context, BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute);
					break;
				case "BaseEntityDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedStartMessage";
					result = BaseEntityDeletedStartMessage.Execute(context);
					break;
				case "BaseEntityDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedScriptTask";
					result = BaseEntityDeletedScriptTask.Execute(context, BaseEntityDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool TryProcessCompleteScriptTask2Execute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Deleted);
			LocalMessageExecuting(EntityChangeType.Deleted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool TryProcessCompleteScriptTask1Execute(ProcessExecutingContext context) {
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavedIndexingTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Index, Entity.PrimaryColumnValue);
			return true;
		}

		public virtual bool ScriptTaskInsertedBaseEntityExecute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Inserted);
			LocalMessageExecuting(EntityChangeType.Inserted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.StoringState == StoringObjectState.New
					|| Entity.StoringState == StoringObjectState.Deleted) {
				return true;
			}
			InitDcmOnEntityChanging();
			TryProcessComplete(EntityChangeType.Updated);
			LocalMessageExecuting(EntityChangeType.Updated);
			return true;
		}

		public virtual bool BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute(ProcessExecutingContext context) {
			if (CanUseDcm) {
				DcmEntityUtilities dcmEntityUtilities = GetDcmEntityUtilities();
				dcmEntityUtilities.ValidateDcmRequiredElement(Entity, (Collection<ProcessListener>)ProcessListeners);
				if (UserConnection.GetIsFeatureEnabled("DcmStagesPermissions")) {
					dcmEntityUtilities.ValidateDcmStagePermissions(Entity, (Collection<ProcessListener>)ProcessListeners);
				}
			}
			return true;
		}

		public virtual bool BaseEntityDeletedScriptTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Delete, Entity.PrimaryColumnValue);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntity_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("BaseEntityDeletingStartMessage2")) {
							context.QueueTasks.Enqueue("BaseEntityDeletingStartMessage2");
						}
						break;
					case "BaseEntity_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("BaseEntityStartMessage1")) {
							context.QueueTasks.Enqueue("BaseEntityStartMessage1");
						}
						break;
					case "BaseEntity_Base_BPMSoftInserted":
							if (ActivatedEventElements.Contains("InsertedStartMessage1")) {
							context.QueueTasks.Enqueue("InsertedStartMessage1");
						}
						break;
					case "BaseEntity_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("BaseEntitySavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntitySavingStartMessage");
						}
						break;
					case "BaseEntity_Base_BPMSoftValidating":
							if (ActivatedEventElements.Contains("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428")) {
							context.QueueTasks.Enqueue("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
						}
						break;
					case "BaseEntity_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("BaseEntityDeletedStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntityDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntity_BaseEventsProcess

	/// <exclude/>
	public class BaseEntity_BaseEventsProcess : BaseEntity_BaseEventsProcess<BaseEntity_Base_BPMSoft>
	{

		public BaseEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntity_BaseEventsProcess

	public partial class BaseEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void TryProcessComplete(EntityChangeType changeType) {
			var processEngine = UserConnection.ProcessEngine;
			ProcessListeners = processEngine.GetProcessListeners(UserConnection, Entity, changeType);
			ProcessSchemaListeners = processEngine.GetProcessSchemaListeners(Entity, changeType);
		}

		public virtual bool IsConditionDataMatch(string conditionData) {
			if (string.IsNullOrEmpty(conditionData)) {
				return true;
			}
			var esq = new EntitySchemaQuery(Entity.Schema);
			IEntitySchemaQueryFilterItem filterCollection = null;
			try {
				var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
				var processDataContractFilterConverter = ClassFactory
					.Get<IProcessDataContractFilterConverter>(userConnectionArgument);
				filterCollection = processDataContractFilterConverter.ConvertToEntitySchemaQueryFilterItem(esq, conditionData);
			} catch {
				var oldConditionData = ConditionData.Deserialize(conditionData);
				bool oldConditionCompleted = oldConditionData == null || oldConditionData.Count == 0;
				if (!oldConditionCompleted) {
					foreach (var condition in oldConditionData) {
						oldConditionCompleted = Entity.GetColumnValue(Entity.Schema.Columns.GetByUId(condition.Key)).Equals(condition.Value);
						if (oldConditionCompleted) {
							break;
						}
					}
				}
				return oldConditionCompleted;
			}
			if (filterCollection != null) {
				esq.AddColumn(Entity.Schema.PrimaryColumn.Name);
				esq.Filters.Add(filterCollection);
				var entity = esq.GetEntity(UserConnection, Entity.PrimaryColumnValue);
				return entity != null;
			}
			return true;
		}

		public virtual bool IsChangedColumnsMatch(string changedColumns) {
			if (string.IsNullOrEmpty(changedColumns)) {
				return true;
			}
			var changedColumnsMetaPaths = JsonConvert.DeserializeObject<Collection<string>>(changedColumns);
			foreach(var columnMetaPath in changedColumnsMetaPaths){
				var changedColumn = Entity.Schema.GetSchemaColumnByMetaPath(columnMetaPath);
				foreach (var columnValue in Entity.GetChangedColumnValues()) {
					if (Guid.Equals(columnValue.Column.UId, changedColumn.UId)) {
						return true;
					}
				}
			}
			return false;
		}

		public virtual void ProcessCompleteExecuting() {
			var processEngine = UserConnection.ProcessEngine;
			var processListeners = (Collection<ProcessListener>)ProcessListeners;
			var processSchemaListeners = (Collection<ProcessSchemaListener>)ProcessSchemaListeners;
			processEngine.ActualizeProcessSchemaListeners(Entity, processSchemaListeners);
			Collection<ProcessDescriptor> processDescriptors;
			bool nextPrcElReady = false;
			IList<ProcessListener> clonedProcessListeners = null;
			if (processListeners != null && processListeners.Count > 0) {
				clonedProcessListeners = new List<ProcessListener>(processListeners);
				processDescriptors = processEngine.ContinueExecuting(UserConnection, Entity, processListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReady = nextPrcElReady || processDescriptor.IsNextElementReady;
				}
				processListeners.Clear();
			}
			if (CanUseDcm) {
				processEngine.RunDcmProcesses(Entity, clonedProcessListeners);
			}
			bool nextPrcElReadyBySignal = false;
			if (processSchemaListeners != null && processSchemaListeners.Count > 0) {
				processDescriptors = processEngine.RunProcesses(UserConnection, Entity, processSchemaListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReadyBySignal = nextPrcElReadyBySignal || processDescriptor.IsNextElementReady;
				}
				processSchemaListeners.Clear();
			}
			if (!nextPrcElReady) {
				nextPrcElReady = nextPrcElReadyBySignal;
			}
			NextProcessElementReady = NextProcessElementReady || nextPrcElReady;
		}

		public virtual bool GetNextPrcElReadyPropertyValue(Entity entity) {
			if (entity != null && entity.Process != null) {
				object nextPrcElReady;
				if (entity.Process.TryGetPropertyValue("NextProcessElementReady", out nextPrcElReady)) {
					return (bool)nextPrcElReady;
				}
			}
			return false;
		}

		public virtual void LocalMessageExecuting(EntityChangeType changeType) {
			return;
		}

		public virtual void InitDcmOnEntityChanging() {
			if (!CanInitDcmForEntity()) {
				return;
			}
			var dcmEntityUtilities = GetDcmEntityUtilities();
			CanUseDcm = dcmEntityUtilities.GetCanEntityUseDcm(Entity.Schema.UId, Entity.GetChangedColumnValues());
			CancelNotEnabledDcmProcess();
		}

		public virtual void CancelNotEnabledDcmProcess() {
			if (CanUseDcm) {
				UserConnection.IProcessEngine.CancelNotEnabledDcmProcess(Entity.Schema.UId, Entity.PrimaryColumnValue);
			}
		}

		public virtual DcmEntityUtilities GetDcmEntityUtilities() {
			if (DcmEntityUtil == null) {
				DcmEntityUtil = new DcmEntityUtilities(UserConnection);
			}
			return (DcmEntityUtilities)DcmEntityUtil;
		}

		public virtual bool CanInitDcmForEntity() {
			var schema = Entity.Schema;
			return schema != null &&
				schema.Name != "AdminUnitFeatureState" &&
				schema.Name != "Feature";
		}

		public virtual void IndexEntity(IndexingOperationType indexingOperationType, Guid primaryColumnValue) {
		}

		#endregion

	}

	#endregion

}

