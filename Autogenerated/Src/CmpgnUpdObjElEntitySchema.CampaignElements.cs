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

	#region Class: CmpgnUpdObjElEntitySchema

	/// <exclude/>
	public class CmpgnUpdObjElEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CmpgnUpdObjElEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CmpgnUpdObjElEntitySchema(CmpgnUpdObjElEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CmpgnUpdObjElEntitySchema(CmpgnUpdObjElEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248");
			RealUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248");
			Name = "CmpgnUpdObjElEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("148620fd-8549-4493-a323-f91110808ff9")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("cc3debdb-76b3-4c2e-91cb-a054b5815652")) == null) {
				Columns.Add(CreateColumnsColumn());
			}
			if (Columns.FindByUId(new Guid("2ed8c490-42aa-4eb5-8afb-57d95c543991")) == null) {
				Columns.Add(CreateContactColumnPathColumn());
			}
			if (Columns.FindByUId(new Guid("6ea67f3c-d593-4549-ab51-fb220366be12")) == null) {
				Columns.Add(CreateRestrictedColumnsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("443e473e-d9f8-4745-9094-2904919e1bdb"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				ModifiedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("148620fd-8549-4493-a323-f91110808ff9"),
				Name = @"EntityName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				ModifiedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("cc3debdb-76b3-4c2e-91cb-a054b5815652"),
				Name = @"Columns",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				ModifiedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumnPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2ed8c490-42aa-4eb5-8afb-57d95c543991"),
				Name = @"ContactColumnPath",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				ModifiedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateRestrictedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6ea67f3c-d593-4549-ab51-fb220366be12"),
				Name = @"RestrictedColumns",
				CreatedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				ModifiedInSchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CmpgnUpdObjElEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CmpgnUpdObjElEntity_CampaignElementsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CmpgnUpdObjElEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CmpgnUpdObjElEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63066f37-db22-4ccf-8af9-f12190c06248"));
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnUpdObjElEntity

	/// <summary>
	/// Настройки объектов для элемента кампании "Изменить данные".
	/// </summary>
	public class CmpgnUpdObjElEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CmpgnUpdObjElEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnUpdObjElEntity";
		}

		public CmpgnUpdObjElEntity(CmpgnUpdObjElEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Объект.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// Разрешенные колонки.
		/// </summary>
		public string Columns {
			get {
				return GetTypedColumnValue<string>("Columns");
			}
			set {
				SetColumnValue("Columns", value);
			}
		}

		/// <summary>
		/// Путь к колонке Контакт.
		/// </summary>
		public string ContactColumnPath {
			get {
				return GetTypedColumnValue<string>("ContactColumnPath");
			}
			set {
				SetColumnValue("ContactColumnPath", value);
			}
		}

		/// <summary>
		/// Запрещенные колонки.
		/// </summary>
		public string RestrictedColumns {
			get {
				return GetTypedColumnValue<string>("RestrictedColumns");
			}
			set {
				SetColumnValue("RestrictedColumns", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CmpgnUpdObjElEntity_CampaignElementsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("CmpgnUpdObjElEntityInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CmpgnUpdObjElEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnUpdObjElEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public partial class CmpgnUpdObjElEntity_CampaignElementsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CmpgnUpdObjElEntity
	{

		public CmpgnUpdObjElEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CmpgnUpdObjElEntity_CampaignElementsEventsProcess";
			SchemaUId = new Guid("63066f37-db22-4ccf-8af9-f12190c06248");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63066f37-db22-4ccf-8af9-f12190c06248");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332;
		public ProcessFlowElement EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332 {
			get {
				return _eventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332 ?? (_eventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332",
					SchemaElementUId = new Guid("2a4cdccc-6776-4770-acc1-e9f7a59f3332"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_93442f6f6c1146d49680717655e24e9a;
		public ProcessFlowElement StartMessage3_93442f6f6c1146d49680717655e24e9a {
			get {
				return _startMessage3_93442f6f6c1146d49680717655e24e9a ?? (_startMessage3_93442f6f6c1146d49680717655e24e9a = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_93442f6f6c1146d49680717655e24e9a",
					SchemaElementUId = new Guid("93442f6f-6c11-46d4-9680-717655e24e9a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_f8f0b33a33da46b3ab71455320ffb458;
		public ProcessScriptTask ScriptTask3_f8f0b33a33da46b3ab71455320ffb458 {
			get {
				return _scriptTask3_f8f0b33a33da46b3ab71455320ffb458 ?? (_scriptTask3_f8f0b33a33da46b3ab71455320ffb458 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_f8f0b33a33da46b3ab71455320ffb458",
					SchemaElementUId = new Guid("f8f0b33a-33da-46b3-ab71-455320ffb458"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_f8f0b33a33da46b3ab71455320ffb458Execute,
				});
			}
		}

		private LocalizableString _uniqueConstraintMessageText;
		public LocalizableString UniqueConstraintMessageText {
			get {
				return _uniqueConstraintMessageText ?? (_uniqueConstraintMessageText = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.UniqueConstraintMessageText.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332 };
			FlowElements[StartMessage3_93442f6f6c1146d49680717655e24e9a.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_93442f6f6c1146d49680717655e24e9a };
			FlowElements[ScriptTask3_f8f0b33a33da46b3ab71455320ffb458.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_f8f0b33a33da46b3ab71455320ffb458 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332":
						break;
					case "StartMessage3_93442f6f6c1146d49680717655e24e9a":
						e.Context.QueueTasks.Enqueue("ScriptTask3_f8f0b33a33da46b3ab71455320ffb458");
						break;
					case "ScriptTask3_f8f0b33a33da46b3ab71455320ffb458":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_93442f6f6c1146d49680717655e24e9a");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_2a4cdccc67764770acc1e9f7a59f3332":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_93442f6f6c1146d49680717655e24e9a":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_93442f6f6c1146d49680717655e24e9a";
					result = StartMessage3_93442f6f6c1146d49680717655e24e9a.Execute(context);
					break;
				case "ScriptTask3_f8f0b33a33da46b3ab71455320ffb458":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_f8f0b33a33da46b3ab71455320ffb458";
					result = ScriptTask3_f8f0b33a33da46b3ab71455320ffb458.Execute(context, ScriptTask3_f8f0b33a33da46b3ab71455320ffb458Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_f8f0b33a33da46b3ab71455320ffb458Execute(ProcessExecutingContext context) {
			if (Entity.ExistInDB("EntityName", Entity.EntityName)) {
				throw new Exception(UniqueConstraintMessageText.Value);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CmpgnUpdObjElEntityInserting":
							if (ActivatedEventElements.Contains("StartMessage3_93442f6f6c1146d49680717655e24e9a")) {
							context.QueueTasks.Enqueue("StartMessage3_93442f6f6c1146d49680717655e24e9a");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnUpdObjElEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public class CmpgnUpdObjElEntity_CampaignElementsEventsProcess : CmpgnUpdObjElEntity_CampaignElementsEventsProcess<CmpgnUpdObjElEntity>
	{

		public CmpgnUpdObjElEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CmpgnUpdObjElEntity_CampaignElementsEventsProcess

	public partial class CmpgnUpdObjElEntity_CampaignElementsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CmpgnUpdObjElEntityEventsProcess

	/// <exclude/>
	public class CmpgnUpdObjElEntityEventsProcess : CmpgnUpdObjElEntity_CampaignElementsEventsProcess
	{

		public CmpgnUpdObjElEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

