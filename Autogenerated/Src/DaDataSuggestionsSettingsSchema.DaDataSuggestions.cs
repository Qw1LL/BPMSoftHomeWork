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

	#region Class: DaDataSuggestionsSettingsSchema

	/// <exclude/>
	public class DaDataSuggestionsSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DaDataSuggestionsSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataSuggestionsSettingsSchema(DaDataSuggestionsSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataSuggestionsSettingsSchema(DaDataSuggestionsSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088");
			RealUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088");
			Name = "DaDataSuggestionsSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5e6dda3c-547d-406d-af9c-578ca4bac03a")) == null) {
				Columns.Add(CreateDaDataSuggestionsEntityColumn());
			}
			if (Columns.FindByUId(new Guid("d303b4cc-22e0-4412-b5b0-94f6b694008d")) == null) {
				Columns.Add(CreateDaDataSuggestionsFieldColumn());
			}
			if (Columns.FindByUId(new Guid("9fa2d719-3c70-4d6b-b9c7-13935ca3fcb3")) == null) {
				Columns.Add(CreateEntityColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("365d53eb-5afc-4bc5-9c44-ff87e1fac926")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDaDataSuggestionsEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5e6dda3c-547d-406d-af9c-578ca4bac03a"),
				Name = @"DaDataSuggestionsEntity",
				ReferenceSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				ModifiedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected virtual EntitySchemaColumn CreateDaDataSuggestionsFieldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d303b4cc-22e0-4412-b5b0-94f6b694008d"),
				Name = @"DaDataSuggestionsField",
				ReferenceSchemaUId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				ModifiedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9fa2d719-3c70-4d6b-b9c7-13935ca3fcb3"),
				Name = @"EntityColumnName",
				CreatedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				ModifiedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("365d53eb-5afc-4bc5-9c44-ff87e1fac926"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				ModifiedInSchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DaDataSuggestionsSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataSuggestionsSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataSuggestionsSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsSettings

	/// <summary>
	/// Настройки подсказок DaData.
	/// </summary>
	public class DaDataSuggestionsSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DaDataSuggestionsSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataSuggestionsSettings";
		}

		public DaDataSuggestionsSettings(DaDataSuggestionsSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DaDataSuggestionsEntityId {
			get {
				return GetTypedColumnValue<Guid>("DaDataSuggestionsEntityId");
			}
			set {
				SetColumnValue("DaDataSuggestionsEntityId", value);
				_daDataSuggestionsEntity = null;
			}
		}

		/// <exclude/>
		public string DaDataSuggestionsEntityEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("DaDataSuggestionsEntityEntitySchemaCaption");
			}
			set {
				SetColumnValue("DaDataSuggestionsEntityEntitySchemaCaption", value);
				if (_daDataSuggestionsEntity != null) {
					_daDataSuggestionsEntity.EntitySchemaCaption = value;
				}
			}
		}

		private DaDataSuggestionsEntity _daDataSuggestionsEntity;
		/// <summary>
		/// Объект.
		/// </summary>
		public DaDataSuggestionsEntity DaDataSuggestionsEntity {
			get {
				return _daDataSuggestionsEntity ??
					(_daDataSuggestionsEntity = LookupColumnEntities.GetEntity("DaDataSuggestionsEntity") as DaDataSuggestionsEntity);
			}
		}

		/// <exclude/>
		public Guid DaDataSuggestionsFieldId {
			get {
				return GetTypedColumnValue<Guid>("DaDataSuggestionsFieldId");
			}
			set {
				SetColumnValue("DaDataSuggestionsFieldId", value);
				_daDataSuggestionsField = null;
			}
		}

		/// <exclude/>
		public string DaDataSuggestionsFieldName {
			get {
				return GetTypedColumnValue<string>("DaDataSuggestionsFieldName");
			}
			set {
				SetColumnValue("DaDataSuggestionsFieldName", value);
				if (_daDataSuggestionsField != null) {
					_daDataSuggestionsField.Name = value;
				}
			}
		}

		private DaDataSuggestionsField _daDataSuggestionsField;
		/// <summary>
		/// Поле из DaData.
		/// </summary>
		public DaDataSuggestionsField DaDataSuggestionsField {
			get {
				return _daDataSuggestionsField ??
					(_daDataSuggestionsField = LookupColumnEntities.GetEntity("DaDataSuggestionsField") as DaDataSuggestionsField);
			}
		}

		/// <summary>
		/// Имя колонки объекта.
		/// </summary>
		public string EntityColumnName {
			get {
				return GetTypedColumnValue<string>("EntityColumnName");
			}
			set {
				SetColumnValue("EntityColumnName", value);
			}
		}

		/// <summary>
		/// Используется.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DaDataSuggestionsSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DaDataSuggestionsSettings
	{

		public DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b51d8f75-123d-44ed-9782-9b6d7e935088");
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

	#region Class: DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess : DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess<DaDataSuggestionsSettings>
	{

		public DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess

	public partial class DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataSuggestionsSettingsEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsSettingsEventsProcess : DaDataSuggestionsSettings_DaDataSuggestionsEventsProcess
	{

		public DaDataSuggestionsSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

