namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Translation;
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
	using CoreSysCulture = BPMSoft.Core.Configuration.SysCulture;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
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

	#region Class: SysCultureSchema

	/// <exclude/>
	public class SysCultureSchema : BPMSoft.Configuration.SysCulture_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysCultureSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCultureSchema(SysCultureSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCultureSchema(SysCultureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a");
			Name = "SysCulture";
			ParentSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			ExtendParent = true;
			CreatedInPackageId = new Guid("40d35dd0-7421-45de-9f03-34d8a7341beb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("88a9958c-6878-4adb-b534-d894dda3c7e8")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("46bd9122-9f52-4b8a-930b-f1b9d5b21b1a")) == null) {
				Columns.Add(CreateIndexColumn());
			}
			if (Columns.FindByUId(new Guid("08419b1c-0aec-49ab-9229-ecc7c42b6279")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("cb8ceccd-8515-47d9-87ed-5dcb1249571d"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				ModifiedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				CreatedInPackageId = new Guid("40d35dd0-7421-45de-9f03-34d8a7341beb")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("88a9958c-6878-4adb-b534-d894dda3c7e8"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				ModifiedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				CreatedInPackageId = new Guid("40d35dd0-7421-45de-9f03-34d8a7341beb")
			};
		}

		protected virtual EntitySchemaColumn CreateIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("46bd9122-9f52-4b8a-930b-f1b9d5b21b1a"),
				Name = @"Index",
				CreatedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				ModifiedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("08419b1c-0aec-49ab-9229-ecc7c42b6279"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				ModifiedInSchemaUId = new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"),
				CreatedInPackageId = new Guid("cde2c5f9-9833-484d-a601-140e8f10df72")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCulture(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCulture_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCultureSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCultureSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture

	/// <summary>
	/// Culture.
	/// </summary>
	public class SysCulture : BPMSoft.Configuration.SysCulture_Base_BPMSoft
	{

		#region Constructors: Public

		public SysCulture(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCulture";
		}

		public SysCulture(SysCulture source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Index.
		/// </summary>
		public int Index {
			get {
				return GetTypedColumnValue<int>("Index");
			}
			set {
				SetColumnValue("Index", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Name.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCulture_TranslationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysCultureDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysCultureDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysCultureInserted", e);
			Inserting += (s, e) => ThrowEvent("SysCultureInserting", e);
			Updated += (s, e) => ThrowEvent("SysCultureUpdated", e);
			Updating += (s, e) => ThrowEvent("SysCultureUpdating", e);
			Validating += (s, e) => ThrowEvent("SysCultureValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysCulture(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture_TranslationEventsProcess

	/// <exclude/>
	public partial class SysCulture_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.SysCulture_BaseEventsProcess<TEntity> where TEntity : SysCulture
	{

		public SysCulture_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCulture_TranslationEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b3195259-2c68-44b4-a6e9-c7d250a1522a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual string TranslationColumnName {
			get;
			set;
		}

		public virtual string VerificationColumnName {
			get;
			set;
		}

		public virtual string IsChangedColumnName {
			get;
			set;
		}

		private ProcessFlowElement _sysCultureUpdatingEventSubProcess;
		public ProcessFlowElement SysCultureUpdatingEventSubProcess {
			get {
				return _sysCultureUpdatingEventSubProcess ?? (_sysCultureUpdatingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysCultureUpdatingEventSubProcess",
					SchemaElementUId = new Guid("6274a749-6cd6-40d7-a0d8-1bb1516a655a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysCultureUpdatingScriptTask;
		public ProcessScriptTask SysCultureUpdatingScriptTask {
			get {
				return _sysCultureUpdatingScriptTask ?? (_sysCultureUpdatingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysCultureUpdatingScriptTask",
					SchemaElementUId = new Guid("9563ff96-fbeb-47ec-b863-db13ed157ec5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysCultureUpdatingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysCultureUpdatingStartMessage;
		public ProcessFlowElement SysCultureUpdatingStartMessage {
			get {
				return _sysCultureUpdatingStartMessage ?? (_sysCultureUpdatingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysCultureUpdatingStartMessage",
					SchemaElementUId = new Guid("0d6a48e3-0f75-4cb5-8cc2-2ac44d0b7d7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysCultureDeletingEventSubProcess;
		public ProcessFlowElement SysCultureDeletingEventSubProcess {
			get {
				return _sysCultureDeletingEventSubProcess ?? (_sysCultureDeletingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysCultureDeletingEventSubProcess",
					SchemaElementUId = new Guid("0464738a-4230-45a1-a58b-f1142f3bf36d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysCultureDeletingStartMessage;
		public ProcessFlowElement SysCultureDeletingStartMessage {
			get {
				return _sysCultureDeletingStartMessage ?? (_sysCultureDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysCultureDeletingStartMessage",
					SchemaElementUId = new Guid("57b197c5-c301-4dc4-949a-3246316c3250"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysCultureDeletingScriptTask;
		public ProcessScriptTask SysCultureDeletingScriptTask {
			get {
				return _sysCultureDeletingScriptTask ?? (_sysCultureDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysCultureDeletingScriptTask",
					SchemaElementUId = new Guid("9d74c5fc-517b-4b89-a033-6e3c560e0712"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysCultureDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysCultureDeletedEventSubProcess;
		public ProcessFlowElement SysCultureDeletedEventSubProcess {
			get {
				return _sysCultureDeletedEventSubProcess ?? (_sysCultureDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysCultureDeletedEventSubProcess",
					SchemaElementUId = new Guid("a48de969-1568-48b1-aaff-3fffd960bc92"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysCultureDeletedStartMessage;
		public ProcessFlowElement SysCultureDeletedStartMessage {
			get {
				return _sysCultureDeletedStartMessage ?? (_sysCultureDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysCultureDeletedStartMessage",
					SchemaElementUId = new Guid("f0bb7779-7e4b-4b9c-b6ef-fc4612f871fc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysCultureDeletedScriptTask;
		public ProcessScriptTask SysCultureDeletedScriptTask {
			get {
				return _sysCultureDeletedScriptTask ?? (_sysCultureDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysCultureDeletedScriptTask",
					SchemaElementUId = new Guid("417b649a-0020-49ce-a0b0-7ea51e3ad63f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysCultureDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysCultureInsertedEventSubProcess;
		public ProcessFlowElement SysCultureInsertedEventSubProcess {
			get {
				return _sysCultureInsertedEventSubProcess ?? (_sysCultureInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysCultureInsertedEventSubProcess",
					SchemaElementUId = new Guid("0e047308-c85b-45a7-b520-cc9d38d85f07"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysCultureInsertedStartMessage;
		public ProcessFlowElement SysCultureInsertedStartMessage {
			get {
				return _sysCultureInsertedStartMessage ?? (_sysCultureInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysCultureInsertedStartMessage",
					SchemaElementUId = new Guid("24fa61f5-d7b8-4e24-a05f-00bae4e5930e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysCultureInsertedScriptTask;
		public ProcessScriptTask SysCultureInsertedScriptTask {
			get {
				return _sysCultureInsertedScriptTask ?? (_sysCultureInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysCultureInsertedScriptTask",
					SchemaElementUId = new Guid("09228bb8-07d0-4f76-a911-92297660ce4b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysCultureInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysCultureUpdatedEventSubProcess;
		public ProcessFlowElement SysCultureUpdatedEventSubProcess {
			get {
				return _sysCultureUpdatedEventSubProcess ?? (_sysCultureUpdatedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysCultureUpdatedEventSubProcess",
					SchemaElementUId = new Guid("be9f8091-e648-4d74-bf5a-34dcccba8e7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysCultureUpdatedStartMessage;
		public ProcessFlowElement SysCultureUpdatedStartMessage {
			get {
				return _sysCultureUpdatedStartMessage ?? (_sysCultureUpdatedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysCultureUpdatedStartMessage",
					SchemaElementUId = new Guid("d3cb8011-0958-4b27-ad4a-e2a0079e4c70"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysCultureUpdatedScriptTask;
		public ProcessScriptTask SysCultureUpdatedScriptTask {
			get {
				return _sysCultureUpdatedScriptTask ?? (_sysCultureUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysCultureUpdatedScriptTask",
					SchemaElementUId = new Guid("2a72de0b-5404-4477-a60e-7cc5520dc409"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysCultureUpdatedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysCultureUpdatingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatingEventSubProcess };
			FlowElements[SysCultureUpdatingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatingScriptTask };
			FlowElements[SysCultureUpdatingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatingStartMessage };
			FlowElements[SysCultureDeletingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletingEventSubProcess };
			FlowElements[SysCultureDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletingStartMessage };
			FlowElements[SysCultureDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletingScriptTask };
			FlowElements[SysCultureDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletedEventSubProcess };
			FlowElements[SysCultureDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletedStartMessage };
			FlowElements[SysCultureDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureDeletedScriptTask };
			FlowElements[SysCultureInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureInsertedEventSubProcess };
			FlowElements[SysCultureInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureInsertedStartMessage };
			FlowElements[SysCultureInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureInsertedScriptTask };
			FlowElements[SysCultureUpdatedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatedEventSubProcess };
			FlowElements[SysCultureUpdatedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatedStartMessage };
			FlowElements[SysCultureUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysCultureUpdatedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysCultureUpdatingEventSubProcess":
						break;
					case "SysCultureUpdatingScriptTask":
						break;
					case "SysCultureUpdatingStartMessage":
						e.Context.QueueTasks.Enqueue("SysCultureUpdatingScriptTask");
						break;
					case "SysCultureDeletingEventSubProcess":
						break;
					case "SysCultureDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("SysCultureDeletingScriptTask");
						break;
					case "SysCultureDeletingScriptTask":
						break;
					case "SysCultureDeletedEventSubProcess":
						break;
					case "SysCultureDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("SysCultureDeletedScriptTask");
						break;
					case "SysCultureDeletedScriptTask":
						break;
					case "SysCultureInsertedEventSubProcess":
						break;
					case "SysCultureInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("SysCultureInsertedScriptTask");
						break;
					case "SysCultureInsertedScriptTask":
						break;
					case "SysCultureUpdatedEventSubProcess":
						break;
					case "SysCultureUpdatedStartMessage":
						e.Context.QueueTasks.Enqueue("SysCultureUpdatedScriptTask");
						break;
					case "SysCultureUpdatedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysCultureUpdatingStartMessage");
			ActivatedEventElements.Add("SysCultureDeletingStartMessage");
			ActivatedEventElements.Add("SysCultureDeletedStartMessage");
			ActivatedEventElements.Add("SysCultureInsertedStartMessage");
			ActivatedEventElements.Add("SysCultureUpdatedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysCultureUpdatingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysCultureUpdatingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureUpdatingScriptTask";
					result = SysCultureUpdatingScriptTask.Execute(context, SysCultureUpdatingScriptTaskExecute);
					break;
				case "SysCultureUpdatingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureUpdatingStartMessage";
					result = SysCultureUpdatingStartMessage.Execute(context);
					break;
				case "SysCultureDeletingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysCultureDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureDeletingStartMessage";
					result = SysCultureDeletingStartMessage.Execute(context);
					break;
				case "SysCultureDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureDeletingScriptTask";
					result = SysCultureDeletingScriptTask.Execute(context, SysCultureDeletingScriptTaskExecute);
					break;
				case "SysCultureDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysCultureDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureDeletedStartMessage";
					result = SysCultureDeletedStartMessage.Execute(context);
					break;
				case "SysCultureDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureDeletedScriptTask";
					result = SysCultureDeletedScriptTask.Execute(context, SysCultureDeletedScriptTaskExecute);
					break;
				case "SysCultureInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysCultureInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureInsertedStartMessage";
					result = SysCultureInsertedStartMessage.Execute(context);
					break;
				case "SysCultureInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureInsertedScriptTask";
					result = SysCultureInsertedScriptTask.Execute(context, SysCultureInsertedScriptTaskExecute);
					break;
				case "SysCultureUpdatedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysCultureUpdatedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureUpdatedStartMessage";
					result = SysCultureUpdatedStartMessage.Execute(context);
					break;
				case "SysCultureUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysCultureUpdatedScriptTask";
					result = SysCultureUpdatedScriptTask.Execute(context, SysCultureUpdatedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysCultureUpdatingScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysCultureUpdating(context);
		}

		public virtual bool SysCultureDeletingScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysCultureDeleting(context);
		}

		public virtual bool SysCultureDeletedScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysCultureDeleted(context);
		}

		public virtual bool SysCultureInsertedScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysCultureInserted(context);
		}

		public virtual bool SysCultureUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysCultureUpdated(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysCultureUpdating":
							if (ActivatedEventElements.Contains("SysCultureUpdatingStartMessage")) {
							context.QueueTasks.Enqueue("SysCultureUpdatingStartMessage");
						}
						break;
					case "SysCultureDeleting":
							if (ActivatedEventElements.Contains("SysCultureDeletingStartMessage")) {
							context.QueueTasks.Enqueue("SysCultureDeletingStartMessage");
						}
						break;
					case "SysCultureDeleted":
							if (ActivatedEventElements.Contains("SysCultureDeletedStartMessage")) {
							context.QueueTasks.Enqueue("SysCultureDeletedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "SysCultureInserted":
							if (ActivatedEventElements.Contains("SysCultureInsertedStartMessage")) {
							context.QueueTasks.Enqueue("SysCultureInsertedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "SysCultureUpdated":
							if (ActivatedEventElements.Contains("SysCultureUpdatedStartMessage")) {
							context.QueueTasks.Enqueue("SysCultureUpdatedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture_TranslationEventsProcess

	/// <exclude/>
	public class SysCulture_TranslationEventsProcess : SysCulture_TranslationEventsProcess<SysCulture>
	{

		public SysCulture_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCulture_TranslationEventsProcess

	public partial class SysCulture_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SetName() {
			string code = GetLanguageCode(Entity.LanguageId);
			Entity.SetColumnValue("Name", code);
		}

		public virtual string GetLanguageCode(Guid id) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysLanguage");
			esq.AddColumn("Code");
			var entity = esq.GetEntity(UserConnection, id);
			return entity.GetTypedColumnValue<string>("Code");
		}

		public virtual void ResetSysAdminUnitCulture(Guid cultureId) {
			var primaryCultureId = (Guid)CoreSysSettings.GetValue(UserConnection, "PrimaryCulture");
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			EntitySchemaColumn sysCultureColumn = entitySchema.Columns.GetByName("SysCulture");
			Update update = new Update(UserConnection, "VwSysAdminUnit");
			update
				.Set(sysCultureColumn.ColumnValueName, Column.Parameter(primaryCultureId))
				.Where(sysCultureColumn.ColumnValueName)
					.IsEqual(Column.Parameter(cultureId));
			update.Execute();
		}

		public virtual void DeleteTranslation() {
			Update update = new Update(UserConnection, "SysTranslation")
				.Set(TranslationColumnName, Column.Parameter(string.Empty))
				.Set(VerificationColumnName, Column.Parameter(false))
				.Set(IsChangedColumnName, Column.Parameter(false));
			update.Execute();
		}

		public virtual bool OnSysCultureDeleting(ProcessExecutingContext  context) {
			CheckCanDelete(Entity.PrimaryColumnValue);
			ResetSysAdminUnitCulture(Entity.PrimaryColumnValue);
			PrepareTranslationDeletingParameters(Entity.Index);
			return true;
		}

		public virtual bool OnSysCultureUpdating(ProcessExecutingContext  context) {
			SetName();
			if (!IsActive()) {
				ResetSysAdminUnitCulture(Entity.PrimaryColumnValue);
			}
			return true;
		}

		public virtual bool IsActive() {
			if (Entity.Active) {
				return true;
			}
			IEnumerable<EntityColumnValue> changedColumnValues = Entity.GetChangedColumnValues();
			EntityColumnValue activeColumnValue = changedColumnValues.Find(columnValue => columnValue.Name.Equals("Active"));
			if (activeColumnValue == null) {
				return true;
			}
			return false;
		}

		public virtual bool OnSysCultureDeleted(ProcessExecutingContext context) {
			DeleteTranslation();
			CoreSysCulture.ResetSysCulturesCache(UserConnection);
			return true;
		}

		public virtual void PrepareTranslationDeletingParameters(int cultureIndex) {
			ISysCultureInfoProvider sysCultureInfoProvider = ClassFactory.Get<SysCultureInfoProvider>(
				new ConstructorArgument("userConnection", UserConnection));
			ISysCultureInfo sysCultureInfo = sysCultureInfoProvider.Read(cultureIndex);
			TranslationColumnName = sysCultureInfo.TranslationColumnName;
			VerificationColumnName = sysCultureInfo.VerificationColumnName;
			IsChangedColumnName = sysCultureInfo.IsChangedColumnName;
		}

		public virtual void CheckCanDelete(Guid cultureId) {
			var primaryCultureId = (Guid)CoreSysSettings.GetValue(UserConnection, "PrimaryCulture");
			if (cultureId.Equals(primaryCultureId)) {
				throw new InvalidOperationException();
			}
		}

		public virtual bool OnSysCultureInserted(ProcessExecutingContext context) {
			CoreSysCulture.ResetSysCulturesCache(UserConnection);
			NormalizeDefaultCulture();
			return true;
		}

		public virtual bool OnSysCultureUpdated(ProcessExecutingContext context) {
			CoreSysCulture.ResetSysCulturesCache(UserConnection);
			NormalizeDefaultCulture();
			return true;
		}

		public virtual void NormalizeDefaultCulture() {
			var defaultCulture = Entity.GetTypedColumnValue<bool>("Default");
			if (defaultCulture) {
				var update = new Update(UserConnection, Entity.Schema.Name)
					.Set("Default", Column.Parameter(false))
					.Where("Id").IsNotEqual(Column.Parameter(Entity.PrimaryColumnValue))
					.And("Default").IsEqual(Column.Parameter(true));
				update.Execute();
			}
		}

		#endregion

	}

	#endregion


	#region Class: SysCultureEventsProcess

	/// <exclude/>
	public class SysCultureEventsProcess : SysCulture_TranslationEventsProcess
	{

		public SysCultureEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

