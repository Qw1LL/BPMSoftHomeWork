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

	#region Class: File_Base_BPMSoftSchema

	/// <exclude/>
	public class File_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public File_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public File_Base_BPMSoftSchema(File_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public File_Base_BPMSoftSchema(File_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			RealUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			Name = "File_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8f7c60c3-7d35-4de4-a234-6e18470eb34c")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("6b37344b-b460-44c5-9fd7-a623689bba4c")) == null) {
				Columns.Add(CreateLockedByColumn());
			}
			if (Columns.FindByUId(new Guid("f906243b-8d5c-48f0-8220-89d5c9175806")) == null) {
				Columns.Add(CreateLockedOnColumn());
			}
			if (Columns.FindByUId(new Guid("73c5b07b-3c1a-44fc-953e-f2ce6cbb7420")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("6255f70e-45c9-4346-8ee0-8d604459e7d8")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("8d8676ce-6974-4157-9a96-841d4499fccb")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("5d9d91dd-892d-4652-8da1-e7a53b96ba4a")) == null) {
				Columns.Add(CreateSizeColumn());
			}
			if (Columns.FindByUId(new Guid("1e656a41-011a-ed7e-8903-5fd6e6dabb49")) == null) {
				Columns.Add(CreateSysFileStorageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4a35bb09-6c8c-4de8-8773-4e9e3b3cf3b0"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8f7c60c3-7d35-4de4-a234-6e18470eb34c"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLockedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b37344b-b460-44c5-9fd7-a623689bba4c"),
				Name = @"LockedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLockedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f906243b-8d5c-48f0-8220-89d5c9175806"),
				Name = @"LockedOn",
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("73c5b07b-3c1a-44fc-953e-f2ce6cbb7420"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6255f70e-45c9-4346-8ee0-8d604459e7d8"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("3c6fc826-bca3-49a7-ae4c-7e9454b386a5"),
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8d8676ce-6974-4157-9a96-841d4499fccb"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5d9d91dd-892d-4652-8da1-e7a53b96ba4a"),
				Name = @"Size",
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysFileStorageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e656a41-011a-ed7e-8903-5fd6e6dabb49"),
				Name = @"SysFileStorage",
				ReferenceSchemaUId = new Guid("7ef214db-a12c-6ef8-7951-c90f6cfe7732"),
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				ModifiedInSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new File_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new File_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new File_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new File_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("556c5867-60a7-4456-aae1-a57a122bef70"));
		}

		#endregion

	}

	#endregion

	#region Class: File_Base_BPMSoft

	/// <summary>
	/// Файл.
	/// </summary>
	public class File_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public File_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "File_Base_BPMSoft";
		}

		public File_Base_BPMSoft(File_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid LockedById {
			get {
				return GetTypedColumnValue<Guid>("LockedById");
			}
			set {
				SetColumnValue("LockedById", value);
				_lockedBy = null;
			}
		}

		/// <exclude/>
		public string LockedByName {
			get {
				return GetTypedColumnValue<string>("LockedByName");
			}
			set {
				SetColumnValue("LockedByName", value);
				if (_lockedBy != null) {
					_lockedBy.Name = value;
				}
			}
		}

		private Contact _lockedBy;
		/// <summary>
		/// Заблокировал.
		/// </summary>
		public Contact LockedBy {
			get {
				return _lockedBy ??
					(_lockedBy = LookupColumnEntities.GetEntity("LockedBy") as Contact);
			}
		}

		/// <summary>
		/// Дата блокировки.
		/// </summary>
		public DateTime LockedOn {
			get {
				return GetTypedColumnValue<DateTime>("LockedOn");
			}
			set {
				SetColumnValue("LockedOn", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private FileType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public FileType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as FileType);
			}
		}

		/// <summary>
		/// Версия.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Размер файла.
		/// </summary>
		public int Size {
			get {
				return GetTypedColumnValue<int>("Size");
			}
			set {
				SetColumnValue("Size", value);
			}
		}

		/// <exclude/>
		public Guid SysFileStorageId {
			get {
				return GetTypedColumnValue<Guid>("SysFileStorageId");
			}
			set {
				SetColumnValue("SysFileStorageId", value);
				_sysFileStorage = null;
			}
		}

		/// <exclude/>
		public string SysFileStorageName {
			get {
				return GetTypedColumnValue<string>("SysFileStorageName");
			}
			set {
				SetColumnValue("SysFileStorageName", value);
				if (_sysFileStorage != null) {
					_sysFileStorage.Name = value;
				}
			}
		}

		private SysFileContentStorage _sysFileStorage;
		/// <summary>
		/// Хранилище файлов.
		/// </summary>
		public SysFileContentStorage SysFileStorage {
			get {
				return _sysFileStorage ??
					(_sysFileStorage = LookupColumnEntities.GetEntity("SysFileStorage") as SysFileContentStorage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new File_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("File_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("File_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("File_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("File_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("File_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("File_Base_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("File_Base_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("File_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new File_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: File_BaseEventsProcess

	/// <exclude/>
	public partial class File_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : File_Base_BPMSoft
	{

		public File_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "File_BaseEventsProcess";
			SchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _subProcessFileSaving;
		public ProcessFlowElement SubProcessFileSaving {
			get {
				return _subProcessFileSaving ?? (_subProcessFileSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcessFileSaving",
					SchemaElementUId = new Guid("c4a1ae26-a39e-43e2-b93d-c5cb941bcc9b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _fileSaving;
		public ProcessFlowElement FileSaving {
			get {
				return _fileSaving ?? (_fileSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "FileSaving",
					SchemaElementUId = new Guid("db0a76ef-5451-47e8-b959-cd2c064f9357"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptFileSaving;
		public ProcessScriptTask ScriptFileSaving {
			get {
				return _scriptFileSaving ?? (_scriptFileSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptFileSaving",
					SchemaElementUId = new Guid("5ba15992-0baa-42d9-8a7d-59869fa5068f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptFileSavingExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess_FileSaved_Base;
		public ProcessFlowElement EventSubProcess_FileSaved_Base {
			get {
				return _eventSubProcess_FileSaved_Base ?? (_eventSubProcess_FileSaved_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess_FileSaved_Base",
					SchemaElementUId = new Guid("2fef8c1d-3142-4adf-a4b6-4b392df860a5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage_FileSaved_Base;
		public ProcessFlowElement StartMessage_FileSaved_Base {
			get {
				return _startMessage_FileSaved_Base ?? (_startMessage_FileSaved_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage_FileSaved_Base",
					SchemaElementUId = new Guid("ccdb328d-e3ec-4c15-b0c0-6a9e57fc3689"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_FileSaved_Base;
		public ProcessScriptTask ScriptTask_FileSaved_Base {
			get {
				return _scriptTask_FileSaved_Base ?? (_scriptTask_FileSaved_Base = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_FileSaved_Base",
					SchemaElementUId = new Guid("4b235097-edd5-4001-b093-fba760960c0d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_FileSaved_BaseExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess_FileDeleted_Base;
		public ProcessFlowElement EventSubProcess_FileDeleted_Base {
			get {
				return _eventSubProcess_FileDeleted_Base ?? (_eventSubProcess_FileDeleted_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess_FileDeleted_Base",
					SchemaElementUId = new Guid("1f7586d6-f5b2-4137-b2f4-7b0201162878"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage_FileDeleted_Base;
		public ProcessFlowElement StartMessage_FileDeleted_Base {
			get {
				return _startMessage_FileDeleted_Base ?? (_startMessage_FileDeleted_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage_FileDeleted_Base",
					SchemaElementUId = new Guid("0d0cfcdd-3777-4972-8ce9-b546177fc794"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_FileDeleted_Base;
		public ProcessScriptTask ScriptTask_FileDeleted_Base {
			get {
				return _scriptTask_FileDeleted_Base ?? (_scriptTask_FileDeleted_Base = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_FileDeleted_Base",
					SchemaElementUId = new Guid("1413793a-ca7c-43d4-8067-b342ffeb4005"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_FileDeleted_BaseExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess_FileUpdated_Base;
		public ProcessFlowElement EventSubProcess_FileUpdated_Base {
			get {
				return _eventSubProcess_FileUpdated_Base ?? (_eventSubProcess_FileUpdated_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess_FileUpdated_Base",
					SchemaElementUId = new Guid("61e148aa-c479-405e-8567-d2e981eca9a1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage_FileUpdated_Base;
		public ProcessFlowElement StartMessage_FileUpdated_Base {
			get {
				return _startMessage_FileUpdated_Base ?? (_startMessage_FileUpdated_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage_FileUpdated_Base",
					SchemaElementUId = new Guid("de5fd116-8a33-473b-8958-d1427e228f45"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_FileUpdated_Base;
		public ProcessScriptTask ScriptTask_FileUpdated_Base {
			get {
				return _scriptTask_FileUpdated_Base ?? (_scriptTask_FileUpdated_Base = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_FileUpdated_Base",
					SchemaElementUId = new Guid("46a65bf2-fe91-411a-a013-a1eb643d74c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_FileUpdated_BaseExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_ee4e0682099441ec85c1e99998eb19ba;
		public ProcessFlowElement EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba {
			get {
				return _eventSubProcess3_ee4e0682099441ec85c1e99998eb19ba ?? (_eventSubProcess3_ee4e0682099441ec85c1e99998eb19ba = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba",
					SchemaElementUId = new Guid("ee4e0682-0994-41ec-85c1-e99998eb19ba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_4f9b19c998cf4c53ae58661a869294f3;
		public ProcessFlowElement StartMessage3_4f9b19c998cf4c53ae58661a869294f3 {
			get {
				return _startMessage3_4f9b19c998cf4c53ae58661a869294f3 ?? (_startMessage3_4f9b19c998cf4c53ae58661a869294f3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_4f9b19c998cf4c53ae58661a869294f3",
					SchemaElementUId = new Guid("4f9b19c9-98cf-4c53-ae58-661a869294f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_FileDeleting_Base;
		public ProcessScriptTask ScriptTask_FileDeleting_Base {
			get {
				return _scriptTask_FileDeleting_Base ?? (_scriptTask_FileDeleting_Base = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_FileDeleting_Base",
					SchemaElementUId = new Guid("fe94c898-f631-4680-b57a-5ea09ae36ca8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_FileDeleting_BaseExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SubProcessFileSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcessFileSaving };
			FlowElements[FileSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { FileSaving };
			FlowElements[ScriptFileSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptFileSaving };
			FlowElements[EventSubProcess_FileSaved_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess_FileSaved_Base };
			FlowElements[StartMessage_FileSaved_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage_FileSaved_Base };
			FlowElements[ScriptTask_FileSaved_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_FileSaved_Base };
			FlowElements[EventSubProcess_FileDeleted_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess_FileDeleted_Base };
			FlowElements[StartMessage_FileDeleted_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage_FileDeleted_Base };
			FlowElements[ScriptTask_FileDeleted_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_FileDeleted_Base };
			FlowElements[EventSubProcess_FileUpdated_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess_FileUpdated_Base };
			FlowElements[StartMessage_FileUpdated_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage_FileUpdated_Base };
			FlowElements[ScriptTask_FileUpdated_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_FileUpdated_Base };
			FlowElements[EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba };
			FlowElements[StartMessage3_4f9b19c998cf4c53ae58661a869294f3.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_4f9b19c998cf4c53ae58661a869294f3 };
			FlowElements[ScriptTask_FileDeleting_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_FileDeleting_Base };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcessFileSaving":
						break;
					case "FileSaving":
						e.Context.QueueTasks.Enqueue("ScriptFileSaving");
						break;
					case "ScriptFileSaving":
						break;
					case "EventSubProcess_FileSaved_Base":
						break;
					case "StartMessage_FileSaved_Base":
						e.Context.QueueTasks.Enqueue("ScriptTask_FileSaved_Base");
						break;
					case "ScriptTask_FileSaved_Base":
						break;
					case "EventSubProcess_FileDeleted_Base":
						break;
					case "StartMessage_FileDeleted_Base":
						e.Context.QueueTasks.Enqueue("ScriptTask_FileDeleted_Base");
						break;
					case "ScriptTask_FileDeleted_Base":
						break;
					case "EventSubProcess_FileUpdated_Base":
						break;
					case "StartMessage_FileUpdated_Base":
						e.Context.QueueTasks.Enqueue("ScriptTask_FileUpdated_Base");
						break;
					case "ScriptTask_FileUpdated_Base":
						break;
					case "EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba":
						break;
					case "StartMessage3_4f9b19c998cf4c53ae58661a869294f3":
						e.Context.QueueTasks.Enqueue("ScriptTask_FileDeleting_Base");
						break;
					case "ScriptTask_FileDeleting_Base":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("FileSaving");
			ActivatedEventElements.Add("StartMessage_FileSaved_Base");
			ActivatedEventElements.Add("StartMessage_FileDeleted_Base");
			ActivatedEventElements.Add("StartMessage_FileUpdated_Base");
			ActivatedEventElements.Add("StartMessage3_4f9b19c998cf4c53ae58661a869294f3");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcessFileSaving":
					context.QueueTasks.Dequeue();
					break;
				case "FileSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "FileSaving";
					result = FileSaving.Execute(context);
					break;
				case "ScriptFileSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptFileSaving";
					result = ScriptFileSaving.Execute(context, ScriptFileSavingExecute);
					break;
				case "EventSubProcess_FileSaved_Base":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage_FileSaved_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage_FileSaved_Base";
					result = StartMessage_FileSaved_Base.Execute(context);
					break;
				case "ScriptTask_FileSaved_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_FileSaved_Base";
					result = ScriptTask_FileSaved_Base.Execute(context, ScriptTask_FileSaved_BaseExecute);
					break;
				case "EventSubProcess_FileDeleted_Base":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage_FileDeleted_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage_FileDeleted_Base";
					result = StartMessage_FileDeleted_Base.Execute(context);
					break;
				case "ScriptTask_FileDeleted_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_FileDeleted_Base";
					result = ScriptTask_FileDeleted_Base.Execute(context, ScriptTask_FileDeleted_BaseExecute);
					break;
				case "EventSubProcess_FileUpdated_Base":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage_FileUpdated_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage_FileUpdated_Base";
					result = StartMessage_FileUpdated_Base.Execute(context);
					break;
				case "ScriptTask_FileUpdated_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_FileUpdated_Base";
					result = ScriptTask_FileUpdated_Base.Execute(context, ScriptTask_FileUpdated_BaseExecute);
					break;
				case "EventSubProcess3_ee4e0682099441ec85c1e99998eb19ba":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_4f9b19c998cf4c53ae58661a869294f3":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_4f9b19c998cf4c53ae58661a869294f3";
					result = StartMessage3_4f9b19c998cf4c53ae58661a869294f3.Execute(context);
					break;
				case "ScriptTask_FileDeleting_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_FileDeleting_Base";
					result = ScriptTask_FileDeleting_Base.Execute(context, ScriptTask_FileDeleting_BaseExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptFileSavingExecute(ProcessExecutingContext context) {
			OnFileSaving();
			return true;
		}

		public virtual bool ScriptTask_FileSaved_BaseExecute(ProcessExecutingContext context) {
			OnFileSaved();
			return true;
		}

		public virtual bool ScriptTask_FileDeleted_BaseExecute(ProcessExecutingContext context) {
			OnFileDeleted();
			return true;
		}

		public virtual bool ScriptTask_FileUpdated_BaseExecute(ProcessExecutingContext context) {
			OnFileUpdated();
			return true;
		}

		public virtual bool ScriptTask_FileDeleting_BaseExecute(ProcessExecutingContext context) {
			DeleteFileUsingFileApi();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "File_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("FileSaving")) {
							context.QueueTasks.Enqueue("FileSaving");
						}
						break;
					case "File_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("StartMessage_FileSaved_Base")) {
							context.QueueTasks.Enqueue("StartMessage_FileSaved_Base");
						}
						break;
					case "File_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("StartMessage_FileDeleted_Base")) {
							context.QueueTasks.Enqueue("StartMessage_FileDeleted_Base");
						}
						break;
					case "File_Base_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("StartMessage_FileUpdated_Base")) {
							context.QueueTasks.Enqueue("StartMessage_FileUpdated_Base");
						}
						break;
					case "File_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("StartMessage3_4f9b19c998cf4c53ae58661a869294f3")) {
							context.QueueTasks.Enqueue("StartMessage3_4f9b19c998cf4c53ae58661a869294f3");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: File_BaseEventsProcess

	/// <exclude/>
	public class File_BaseEventsProcess : File_BaseEventsProcess<File_Base_BPMSoft>
	{

		public File_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

