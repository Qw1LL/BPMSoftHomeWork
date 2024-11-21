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

	#region Class: CmpgnAddObjElEntitySchema

	/// <exclude/>
	public class CmpgnAddObjElEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CmpgnAddObjElEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CmpgnAddObjElEntitySchema(CmpgnAddObjElEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CmpgnAddObjElEntitySchema(CmpgnAddObjElEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb");
			RealUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb");
			Name = "CmpgnAddObjElEntity";
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
			if (Columns.FindByUId(new Guid("4c85864c-315f-4c06-be53-c2dde63a0ab3")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("51aa7387-4ca8-41f6-bce2-52ed4186d87d")) == null) {
				Columns.Add(CreateColumnsColumn());
			}
			if (Columns.FindByUId(new Guid("3d26fa3d-a11b-4aa8-a62a-658f60ab1746")) == null) {
				Columns.Add(CreateContactColumnPathColumn());
			}
			if (Columns.FindByUId(new Guid("8f0251b7-55b5-4c7d-bd2d-73248268b5f0")) == null) {
				Columns.Add(CreateRestrictedColumnsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dca3e6e3-7988-49c5-9d9a-09be131230e4"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				ModifiedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4c85864c-315f-4c06-be53-c2dde63a0ab3"),
				Name = @"EntityName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				ModifiedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("51aa7387-4ca8-41f6-bce2-52ed4186d87d"),
				Name = @"Columns",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				ModifiedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumnPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3d26fa3d-a11b-4aa8-a62a-658f60ab1746"),
				Name = @"ContactColumnPath",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				ModifiedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateRestrictedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8f0251b7-55b5-4c7d-bd2d-73248268b5f0"),
				Name = @"RestrictedColumns",
				CreatedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
				ModifiedInSchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"),
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
			return new CmpgnAddObjElEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CmpgnAddObjElEntity_CampaignElementsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CmpgnAddObjElEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CmpgnAddObjElEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb"));
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnAddObjElEntity

	/// <summary>
	/// Настройки объектов для элемента кампании "Добавить данные".
	/// </summary>
	public class CmpgnAddObjElEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CmpgnAddObjElEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnAddObjElEntity";
		}

		public CmpgnAddObjElEntity(CmpgnAddObjElEntity source)
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
			var process = new CmpgnAddObjElEntity_CampaignElementsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("CmpgnAddObjElEntityInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CmpgnAddObjElEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnAddObjElEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public partial class CmpgnAddObjElEntity_CampaignElementsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CmpgnAddObjElEntity
	{

		public CmpgnAddObjElEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CmpgnAddObjElEntity_CampaignElementsEventsProcess";
			SchemaUId = new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("35a6bc7c-0078-42e0-a312-1b15fd2badbb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_01b90be06e74438bb9559f196ebfb1e5;
		public ProcessFlowElement EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5 {
			get {
				return _eventSubProcess3_01b90be06e74438bb9559f196ebfb1e5 ?? (_eventSubProcess3_01b90be06e74438bb9559f196ebfb1e5 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5",
					SchemaElementUId = new Guid("01b90be0-6e74-438b-b955-9f196ebfb1e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd;
		public ProcessScriptTask ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd {
			get {
				return _scriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd ?? (_scriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd",
					SchemaElementUId = new Guid("033cc5a9-6b2c-44b6-9c5f-2ab8fd081acd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acdExecute,
				});
			}
		}

		private ProcessFlowElement _startMessage3_a3a9887c584c4567b88593b40e1c362c;
		public ProcessFlowElement StartMessage3_a3a9887c584c4567b88593b40e1c362c {
			get {
				return _startMessage3_a3a9887c584c4567b88593b40e1c362c ?? (_startMessage3_a3a9887c584c4567b88593b40e1c362c = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_a3a9887c584c4567b88593b40e1c362c",
					SchemaElementUId = new Guid("a3a9887c-584c-4567-b885-93b40e1c362c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
			FlowElements[EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5 };
			FlowElements[ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd };
			FlowElements[StartMessage3_a3a9887c584c4567b88593b40e1c362c.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_a3a9887c584c4567b88593b40e1c362c };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5":
						break;
					case "ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd":
						break;
					case "StartMessage3_a3a9887c584c4567b88593b40e1c362c":
						e.Context.QueueTasks.Enqueue("ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_a3a9887c584c4567b88593b40e1c362c");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_01b90be06e74438bb9559f196ebfb1e5":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd";
					result = ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acd.Execute(context, ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acdExecute);
					break;
				case "StartMessage3_a3a9887c584c4567b88593b40e1c362c":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_a3a9887c584c4567b88593b40e1c362c";
					result = StartMessage3_a3a9887c584c4567b88593b40e1c362c.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_033cc5a96b2c44b69c5f2ab8fd081acdExecute(ProcessExecutingContext context) {
			if (Entity.ExistInDB("EntityName", Entity.EntityName)) {
				throw new Exception(UniqueConstraintMessageText.Value);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CmpgnAddObjElEntityInserting":
							if (ActivatedEventElements.Contains("StartMessage3_a3a9887c584c4567b88593b40e1c362c")) {
							context.QueueTasks.Enqueue("StartMessage3_a3a9887c584c4567b88593b40e1c362c");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnAddObjElEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public class CmpgnAddObjElEntity_CampaignElementsEventsProcess : CmpgnAddObjElEntity_CampaignElementsEventsProcess<CmpgnAddObjElEntity>
	{

		public CmpgnAddObjElEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CmpgnAddObjElEntity_CampaignElementsEventsProcess

	public partial class CmpgnAddObjElEntity_CampaignElementsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CmpgnAddObjElEntityEventsProcess

	/// <exclude/>
	public class CmpgnAddObjElEntityEventsProcess : CmpgnAddObjElEntity_CampaignElementsEventsProcess
	{

		public CmpgnAddObjElEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

