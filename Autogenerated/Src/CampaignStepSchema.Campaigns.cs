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

	#region Class: CampaignStepSchema

	/// <exclude/>
	public class CampaignStepSchema : BPMSoft.Configuration.DiagramElementSchema
	{

		#region Constructors: Public

		public CampaignStepSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignStepSchema(CampaignStepSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignStepSchema(CampaignStepSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f");
			RealUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f");
			Name = "CampaignStep";
			ParentSchemaUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("04330cae-abcc-4e56-9ebd-0db346d46b31")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("6408c73b-b88d-430e-90a5-ac12523903c5")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("f3b54709-35b3-43c6-b09e-44dc88c87426")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4421e9b5-6af9-43ab-a54d-f0938cc28db8"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				ModifiedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("04330cae-abcc-4e56-9ebd-0db346d46b31"),
				Name = @"RecordId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				ModifiedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6408c73b-b88d-430e-90a5-ac12523903c5"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				ModifiedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f3b54709-35b3-43c6-b09e-44dc88c87426"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				ModifiedInSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignStep(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignStep_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignStepSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignStepSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStep

	/// <summary>
	/// Шаг кампании.
	/// </summary>
	public class CampaignStep : BPMSoft.Configuration.DiagramElement
	{

		#region Constructors: Public

		public CampaignStep(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignStep";
		}

		public CampaignStep(CampaignStep source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
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

		private CampaignStepType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CampaignStepType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as CampaignStepType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignStep_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignStepDeleted", e);
			Loaded += (s, e) => ThrowEvent("CampaignStepLoaded", e);
			Saved += (s, e) => ThrowEvent("CampaignStepSaved", e);
			Saving += (s, e) => ThrowEvent("CampaignStepSaving", e);
			Validating += (s, e) => ThrowEvent("CampaignStepValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignStep(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStep_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignStep_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.DiagramElement_ProcessLibraryEventsProcess<TEntity> where TEntity : CampaignStep
	{

		public CampaignStep_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignStep_CampaignsEventsProcess";
			SchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_supportedProperties = () => {{ return "offsetX,offsetY"; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<string> _supportedProperties;
		public override string SupportedProperties {
			get {
				return (_supportedProperties ?? (_supportedProperties = () => null)).Invoke();
			}
			set {
				_supportedProperties = () => { return value; };
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("d105a583-dbbc-4e70-8a93-4138ca14e16b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignStepSaving;
		public ProcessFlowElement CampaignStepSaving {
			get {
				return _campaignStepSaving ?? (_campaignStepSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignStepSaving",
					SchemaElementUId = new Guid("f0483cd5-3d24-4ac1-ab9a-1fec1bce9ffc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _campaignStepObjSavedScriptTask;
		public ProcessScriptTask CampaignStepObjSavedScriptTask {
			get {
				return _campaignStepObjSavedScriptTask ?? (_campaignStepObjSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignStepObjSavedScriptTask",
					SchemaElementUId = new Guid("251eb785-dbc8-4eac-b98e-1c1c120cbf9a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CampaignStepObjSavedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[CampaignStepSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignStepSaving };
			FlowElements[CampaignStepObjSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignStepObjSavedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "CampaignStepSaving":
						e.Context.QueueTasks.Enqueue("CampaignStepObjSavedScriptTask");
						break;
					case "CampaignStepObjSavedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CampaignStepSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "CampaignStepSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignStepSaving";
					result = CampaignStepSaving.Execute(context);
					break;
				case "CampaignStepObjSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignStepObjSavedScriptTask";
					result = CampaignStepObjSavedScriptTask.Execute(context, CampaignStepObjSavedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CampaignStepObjSavedScriptTaskExecute(ProcessExecutingContext context) {
			return SavedMethod(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CampaignStepSaving":
							if (ActivatedEventElements.Contains("CampaignStepSaving")) {
							context.QueueTasks.Enqueue("CampaignStepSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStep_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignStep_CampaignsEventsProcess : CampaignStep_CampaignsEventsProcess<CampaignStep>
	{

		public CampaignStep_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignStep_CampaignsEventsProcess

	public partial class CampaignStep_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool SavedMethod(ProcessExecutingContext context) {
			if (!Entity.Schema.Columns.Any(column => column.Name == "RecordId")) {
				return true;
			}
			Guid oldRecordId = Entity.GetTypedOldColumnValue<Guid>("RecordId");
			Guid newRecordId = Entity.GetTypedColumnValue<Guid>("RecordId");
			if(oldRecordId == newRecordId) {
				return true;
			}
			var typeUId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if(typeUId.Equals(CampaignConsts.LendingCampaignStepTypeId)) {
				return true;
			}
			var campaignTypeSysSchemaUIdQuery = new Select(UserConnection)
				.Column("SysSchemaUId")
				.From("CampaignStepType")
				.Where("Id").IsEqual(Column.Parameter(typeUId));
			
			Guid sysSchemaUId = (campaignTypeSysSchemaUIdQuery as Select).ExecuteScalar<Guid>();
			var schema = UserConnection.EntitySchemaManager.GetInstanceByUId(sysSchemaUId);
			
			if(oldRecordId != Guid.Empty) {
				var updateOldQuery = new Update(UserConnection, schema.Name)
					.Set("CampaignId", Column.Const(null))
					.Where(schema.PrimaryColumn.Name).IsEqual(Column.Parameter(oldRecordId));
				updateOldQuery.Execute();
			}
			
			if(newRecordId != Guid.Empty) {
				var updateNewQuery = new Update(UserConnection, schema.Name)
					.Set("CampaignId", Column.Parameter(Entity.GetTypedColumnValue<Guid>("CampaignId")))
					.Where(schema.PrimaryColumn.Name).IsEqual(Column.Parameter(newRecordId));
				updateNewQuery.Execute();
			}
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: CampaignStepEventsProcess

	/// <exclude/>
	public class CampaignStepEventsProcess : CampaignStep_CampaignsEventsProcess
	{

		public CampaignStepEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

