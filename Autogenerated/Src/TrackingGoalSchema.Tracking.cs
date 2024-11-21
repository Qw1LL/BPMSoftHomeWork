namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Tracking;
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

	#region Class: TrackingGoalSchema

	/// <exclude/>
	public class TrackingGoalSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TrackingGoalSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TrackingGoalSchema(TrackingGoalSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TrackingGoalSchema(TrackingGoalSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2");
			RealUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2");
			Name = "TrackingGoal";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
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
			if (Columns.FindByUId(new Guid("cea3dc56-d68c-47cd-a66f-ca2bcc615199")) == null) {
				Columns.Add(CreateResourceColumn());
			}
			if (Columns.FindByUId(new Guid("27220bc3-89f9-434a-ace7-2c6e1d195417")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("9352a28f-75c9-4fa0-8ab1-5b0ae3dbdaf8")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
			if (Columns.FindByUId(new Guid("fdb98c4b-503d-43a6-8e2c-a0c1f9db2372")) == null) {
				Columns.Add(CreateCostColumn());
			}
			if (Columns.FindByUId(new Guid("9ba02955-534c-4242-a67a-b23fb0984aa8")) == null) {
				Columns.Add(CreateUseEventCostColumn());
			}
			if (Columns.FindByUId(new Guid("7d8f1e3e-a381-4114-875b-8ddfc1ddfc4f")) == null) {
				Columns.Add(CreateSettingsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateResourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cea3dc56-d68c-47cd-a66f-ca2bcc615199"),
				Name = @"Resource",
				ReferenceSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("75d47fdf-acae-4768-ae7a-9ed07999a072"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("27220bc3-89f9-434a-ace7-2c6e1d195417"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9352a28f-75c9-4fa0-8ab1-5b0ae3dbdaf8"),
				Name = @"IsDeleted",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("fdb98c4b-503d-43a6-8e2c-a0c1f9db2372"),
				Name = @"Cost",
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateUseEventCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9ba02955-534c-4242-a67a-b23fb0984aa8"),
				Name = @"UseEventCost",
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7d8f1e3e-a381-4114-875b-8ddfc1ddfc4f"),
				Name = @"Settings",
				CreatedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				ModifiedInSchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TrackingGoal(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TrackingGoal_TrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TrackingGoalSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TrackingGoalSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2"));
		}

		#endregion

	}

	#endregion

	#region Class: TrackingGoal

	/// <summary>
	/// Цель трекинга.
	/// </summary>
	public class TrackingGoal : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TrackingGoal(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TrackingGoal";
		}

		public TrackingGoal(TrackingGoal source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ResourceId {
			get {
				return GetTypedColumnValue<Guid>("ResourceId");
			}
			set {
				SetColumnValue("ResourceId", value);
				_resource = null;
			}
		}

		/// <exclude/>
		public string ResourceName {
			get {
				return GetTypedColumnValue<string>("ResourceName");
			}
			set {
				SetColumnValue("ResourceName", value);
				if (_resource != null) {
					_resource.Name = value;
				}
			}
		}

		private TrackingResource _resource;
		/// <summary>
		/// Источник события.
		/// </summary>
		public TrackingResource Resource {
			get {
				return _resource ??
					(_resource = LookupColumnEntities.GetEntity("Resource") as TrackingResource);
			}
		}

		/// <summary>
		/// Название цели.
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
		/// Активная.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Удалена.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <summary>
		/// Стоимость цели.
		/// </summary>
		public Decimal Cost {
			get {
				return GetTypedColumnValue<Decimal>("Cost");
			}
			set {
				SetColumnValue("Cost", value);
			}
		}

		/// <summary>
		/// Использовать стоимость события.
		/// </summary>
		public bool UseEventCost {
			get {
				return GetTypedColumnValue<bool>("UseEventCost");
			}
			set {
				SetColumnValue("UseEventCost", value);
			}
		}

		/// <summary>
		/// Настройки цели.
		/// </summary>
		public string Settings {
			get {
				return GetTypedColumnValue<string>("Settings");
			}
			set {
				SetColumnValue("Settings", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TrackingGoal_TrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("TrackingGoalInserted", e);
			Updated += (s, e) => ThrowEvent("TrackingGoalUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TrackingGoal(this);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingGoal_TrackingEventsProcess

	/// <exclude/>
	public partial class TrackingGoal_TrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TrackingGoal
	{

		public TrackingGoal_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TrackingGoal_TrackingEventsProcess";
			SchemaUId = new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0c7bad19-b28d-4a80-bd91-48f70f335be2");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2;
		public ProcessFlowElement EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2 {
			get {
				return _eventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2 ?? (_eventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2",
					SchemaElementUId = new Guid("da1c97a7-ce9e-4c40-98b4-45d5eb20d7a2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_d4e5bf157f75488e855d6740d0335fc9;
		public ProcessFlowElement StartMessage3_d4e5bf157f75488e855d6740d0335fc9 {
			get {
				return _startMessage3_d4e5bf157f75488e855d6740d0335fc9 ?? (_startMessage3_d4e5bf157f75488e855d6740d0335fc9 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_d4e5bf157f75488e855d6740d0335fc9",
					SchemaElementUId = new Guid("d4e5bf15-7f75-488e-855d-6740d0335fc9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_1e1b149b9906469f859824e76a412e81;
		public ProcessScriptTask ScriptTask3_1e1b149b9906469f859824e76a412e81 {
			get {
				return _scriptTask3_1e1b149b9906469f859824e76a412e81 ?? (_scriptTask3_1e1b149b9906469f859824e76a412e81 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_1e1b149b9906469f859824e76a412e81",
					SchemaElementUId = new Guid("1e1b149b-9906-469f-8598-24e76a412e81"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_1e1b149b9906469f859824e76a412e81Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4_b0556a398ded440890293ecc3dc40f83;
		public ProcessFlowElement EventSubProcess4_b0556a398ded440890293ecc3dc40f83 {
			get {
				return _eventSubProcess4_b0556a398ded440890293ecc3dc40f83 ?? (_eventSubProcess4_b0556a398ded440890293ecc3dc40f83 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_b0556a398ded440890293ecc3dc40f83",
					SchemaElementUId = new Guid("b0556a39-8ded-4408-9029-3ecc3dc40f83"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage4_2d60d14d120340e0945e8078403781a0;
		public ProcessFlowElement StartMessage4_2d60d14d120340e0945e8078403781a0 {
			get {
				return _startMessage4_2d60d14d120340e0945e8078403781a0 ?? (_startMessage4_2d60d14d120340e0945e8078403781a0 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage4_2d60d14d120340e0945e8078403781a0",
					SchemaElementUId = new Guid("2d60d14d-1203-40e0-945e-8078403781a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask4_fa34330391a34055804ba6717c35d755;
		public ProcessScriptTask ScriptTask4_fa34330391a34055804ba6717c35d755 {
			get {
				return _scriptTask4_fa34330391a34055804ba6717c35d755 ?? (_scriptTask4_fa34330391a34055804ba6717c35d755 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4_fa34330391a34055804ba6717c35d755",
					SchemaElementUId = new Guid("fa343303-91a3-4055-804b-a6717c35d755"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask4_fa34330391a34055804ba6717c35d755Execute,
				});
			}
		}

		private LocalizableString _dataSyncErrorMessage;
		public LocalizableString DataSyncErrorMessage {
			get {
				return _dataSyncErrorMessage ?? (_dataSyncErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DataSyncErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2 };
			FlowElements[StartMessage3_d4e5bf157f75488e855d6740d0335fc9.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_d4e5bf157f75488e855d6740d0335fc9 };
			FlowElements[ScriptTask3_1e1b149b9906469f859824e76a412e81.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_1e1b149b9906469f859824e76a412e81 };
			FlowElements[EventSubProcess4_b0556a398ded440890293ecc3dc40f83.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_b0556a398ded440890293ecc3dc40f83 };
			FlowElements[StartMessage4_2d60d14d120340e0945e8078403781a0.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage4_2d60d14d120340e0945e8078403781a0 };
			FlowElements[ScriptTask4_fa34330391a34055804ba6717c35d755.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4_fa34330391a34055804ba6717c35d755 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2":
						break;
					case "StartMessage3_d4e5bf157f75488e855d6740d0335fc9":
						e.Context.QueueTasks.Enqueue("ScriptTask3_1e1b149b9906469f859824e76a412e81");
						break;
					case "ScriptTask3_1e1b149b9906469f859824e76a412e81":
						break;
					case "EventSubProcess4_b0556a398ded440890293ecc3dc40f83":
						break;
					case "StartMessage4_2d60d14d120340e0945e8078403781a0":
						e.Context.QueueTasks.Enqueue("ScriptTask4_fa34330391a34055804ba6717c35d755");
						break;
					case "ScriptTask4_fa34330391a34055804ba6717c35d755":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_d4e5bf157f75488e855d6740d0335fc9");
			ActivatedEventElements.Add("StartMessage4_2d60d14d120340e0945e8078403781a0");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_da1c97a7ce9e4c4098b445d5eb20d7a2":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_d4e5bf157f75488e855d6740d0335fc9":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_d4e5bf157f75488e855d6740d0335fc9";
					result = StartMessage3_d4e5bf157f75488e855d6740d0335fc9.Execute(context);
					break;
				case "ScriptTask3_1e1b149b9906469f859824e76a412e81":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_1e1b149b9906469f859824e76a412e81";
					result = ScriptTask3_1e1b149b9906469f859824e76a412e81.Execute(context, ScriptTask3_1e1b149b9906469f859824e76a412e81Execute);
					break;
				case "EventSubProcess4_b0556a398ded440890293ecc3dc40f83":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage4_2d60d14d120340e0945e8078403781a0":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage4_2d60d14d120340e0945e8078403781a0";
					result = StartMessage4_2d60d14d120340e0945e8078403781a0.Execute(context);
					break;
				case "ScriptTask4_fa34330391a34055804ba6717c35d755":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask4_fa34330391a34055804ba6717c35d755";
					result = ScriptTask4_fa34330391a34055804ba6717c35d755.Execute(context, ScriptTask4_fa34330391a34055804ba6717c35d755Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_1e1b149b9906469f859824e76a412e81Execute(ProcessExecutingContext context) {
			InsertGoalToCloudTenantService();
			return true;
		}

		public virtual bool ScriptTask4_fa34330391a34055804ba6717c35d755Execute(ProcessExecutingContext context) {
			UpdateGoal();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "TrackingGoalInserted":
							if (ActivatedEventElements.Contains("StartMessage3_d4e5bf157f75488e855d6740d0335fc9")) {
							context.QueueTasks.Enqueue("StartMessage3_d4e5bf157f75488e855d6740d0335fc9");
						}
						break;
					case "TrackingGoalUpdated":
							if (ActivatedEventElements.Contains("StartMessage4_2d60d14d120340e0945e8078403781a0")) {
							context.QueueTasks.Enqueue("StartMessage4_2d60d14d120340e0945e8078403781a0");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingGoal_TrackingEventsProcess

	/// <exclude/>
	public class TrackingGoal_TrackingEventsProcess : TrackingGoal_TrackingEventsProcess<TrackingGoal>
	{

		public TrackingGoal_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: TrackingGoalEventsProcess

	/// <exclude/>
	public class TrackingGoalEventsProcess : TrackingGoal_TrackingEventsProcess
	{

		public TrackingGoalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

