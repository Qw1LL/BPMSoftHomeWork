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

	#region Class: CampaignTargetSchema

	/// <exclude/>
	public class CampaignTargetSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignTargetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignTargetSchema(CampaignTargetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignTargetSchema(CampaignTargetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIihaGX41KCSArfXeqMVcTw0d7rgIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("3d6fc53a-21f9-430a-9546-0301bccc910b");
			index.Name = "IihaGX41KCSArfXeqMVcTw0d7rg";
			index.CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			index.ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			index.CreatedInPackageId = new Guid("9a2ba413-fb27-45c1-a487-c3fec273d0a5");
			EntitySchemaIndexColumn campaignIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a00e2c05-14b7-4b5a-b48e-c092f472586d"),
				ColumnUId = new Guid("373a994c-09db-47cc-9953-57f8ba5a9fa8"),
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("9a2ba413-fb27-45c1-a487-c3fec273d0a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(campaignIdIndexColumn);
			EntitySchemaIndexColumn currentStepIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("50633eba-5dc3-470b-aa74-4836fed19cbb"),
				ColumnUId = new Guid("69e4019d-d797-4d93-ab91-ba2a63d19935"),
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("9a2ba413-fb27-45c1-a487-c3fec273d0a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(currentStepIdIndexColumn);
			EntitySchemaIndexColumn nextStepIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b1d5dede-c11d-4246-b6cf-fe49e63ce028"),
				ColumnUId = new Guid("8e52df9c-1881-4c74-8fc6-1fe051ddf153"),
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("9a2ba413-fb27-45c1-a487-c3fec273d0a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nextStepIdIndexColumn);
			EntitySchemaIndexColumn modifiedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("027172a6-510c-459e-9af1-cec214d86c4a"),
				ColumnUId = new Guid("9928edec-4272-425a-93bb-48743fee4b04"),
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("9a2ba413-fb27-45c1-a487-c3fec273d0a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(modifiedOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			RealUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			Name = "CampaignTarget";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("373a994c-09db-47cc-9953-57f8ba5a9fa8")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("b1866cfa-30c5-4016-b11e-f6a3df6d1837")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("a3d475bc-ae39-45d9-9ea2-c3e391d797b0")) == null) {
				Columns.Add(CreateCampaignTargetStatusColumn());
			}
			if (Columns.FindByUId(new Guid("55fe2b63-fa1f-4427-a2e1-8595019dcb07")) == null) {
				Columns.Add(CreateIsFromGroupColumn());
			}
			if (Columns.FindByUId(new Guid("69e4019d-d797-4d93-ab91-ba2a63d19935")) == null) {
				Columns.Add(CreateCurrentStepColumn());
			}
			if (Columns.FindByUId(new Guid("8e52df9c-1881-4c74-8fc6-1fe051ddf153")) == null) {
				Columns.Add(CreateNextStepColumn());
			}
			if (Columns.FindByUId(new Guid("477f1784-e46b-4626-a4f6-de520a1322ac")) == null) {
				Columns.Add(CreatePassedStepColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("373a994c-09db-47cc-9953-57f8ba5a9fa8"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1866cfa-30c5-4016-b11e-f6a3df6d1837"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignTargetStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3d475bc-ae39-45d9-9ea2-c3e391d797b0"),
				Name = @"CampaignTargetStatus",
				ReferenceSchemaUId = new Guid("4632eea4-8425-48a6-a698-c5088b2884f1"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"7d7ef797-cda6-4bd8-be03-bac67fbf73d7"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsFromGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("55fe2b63-fa1f-4427-a2e1-8595019dcb07"),
				Name = @"IsFromGroup",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentStepColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69e4019d-d797-4d93-ab91-ba2a63d19935"),
				Name = @"CurrentStep",
				ReferenceSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateNextStepColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e52df9c-1881-4c74-8fc6-1fe051ddf153"),
				Name = @"NextStep",
				ReferenceSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreatePassedStepColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("477f1784-e46b-4626-a4f6-de520a1322ac"),
				Name = @"PassedStep",
				ReferenceSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				ModifiedInSchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIihaGX41KCSArfXeqMVcTw0d7rgIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignTarget(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignTarget_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignTargetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignTargetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignTarget

	/// <summary>
	/// Участник кампании (предыдущая версия).
	/// </summary>
	public class CampaignTarget : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignTarget";
		}

		public CampaignTarget(CampaignTarget source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid CampaignTargetStatusId {
			get {
				return GetTypedColumnValue<Guid>("CampaignTargetStatusId");
			}
			set {
				SetColumnValue("CampaignTargetStatusId", value);
				_campaignTargetStatus = null;
			}
		}

		/// <exclude/>
		public string CampaignTargetStatusName {
			get {
				return GetTypedColumnValue<string>("CampaignTargetStatusName");
			}
			set {
				SetColumnValue("CampaignTargetStatusName", value);
				if (_campaignTargetStatus != null) {
					_campaignTargetStatus.Name = value;
				}
			}
		}

		private CampaignTargetStatus _campaignTargetStatus;
		/// <summary>
		/// Участие в кампании.
		/// </summary>
		public CampaignTargetStatus CampaignTargetStatus {
			get {
				return _campaignTargetStatus ??
					(_campaignTargetStatus = LookupColumnEntities.GetEntity("CampaignTargetStatus") as CampaignTargetStatus);
			}
		}

		/// <summary>
		/// IsFromGroup.
		/// </summary>
		public bool IsFromGroup {
			get {
				return GetTypedColumnValue<bool>("IsFromGroup");
			}
			set {
				SetColumnValue("IsFromGroup", value);
			}
		}

		/// <exclude/>
		public Guid CurrentStepId {
			get {
				return GetTypedColumnValue<Guid>("CurrentStepId");
			}
			set {
				SetColumnValue("CurrentStepId", value);
				_currentStep = null;
			}
		}

		/// <exclude/>
		public string CurrentStepTitle {
			get {
				return GetTypedColumnValue<string>("CurrentStepTitle");
			}
			set {
				SetColumnValue("CurrentStepTitle", value);
				if (_currentStep != null) {
					_currentStep.Title = value;
				}
			}
		}

		private CampaignStep _currentStep;
		/// <summary>
		/// Текущий шаг.
		/// </summary>
		public CampaignStep CurrentStep {
			get {
				return _currentStep ??
					(_currentStep = LookupColumnEntities.GetEntity("CurrentStep") as CampaignStep);
			}
		}

		/// <exclude/>
		public Guid NextStepId {
			get {
				return GetTypedColumnValue<Guid>("NextStepId");
			}
			set {
				SetColumnValue("NextStepId", value);
				_nextStep = null;
			}
		}

		/// <exclude/>
		public string NextStepTitle {
			get {
				return GetTypedColumnValue<string>("NextStepTitle");
			}
			set {
				SetColumnValue("NextStepTitle", value);
				if (_nextStep != null) {
					_nextStep.Title = value;
				}
			}
		}

		private CampaignStep _nextStep;
		/// <summary>
		/// Следующий шаг.
		/// </summary>
		public CampaignStep NextStep {
			get {
				return _nextStep ??
					(_nextStep = LookupColumnEntities.GetEntity("NextStep") as CampaignStep);
			}
		}

		/// <exclude/>
		public Guid PassedStepId {
			get {
				return GetTypedColumnValue<Guid>("PassedStepId");
			}
			set {
				SetColumnValue("PassedStepId", value);
				_passedStep = null;
			}
		}

		/// <exclude/>
		public string PassedStepTitle {
			get {
				return GetTypedColumnValue<string>("PassedStepTitle");
			}
			set {
				SetColumnValue("PassedStepTitle", value);
				if (_passedStep != null) {
					_passedStep.Title = value;
				}
			}
		}

		private CampaignStep _passedStep;
		/// <summary>
		/// Пройденный шаг.
		/// </summary>
		public CampaignStep PassedStep {
			get {
				return _passedStep ??
					(_passedStep = LookupColumnEntities.GetEntity("PassedStep") as CampaignStep);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignTarget_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignTargetDeleted", e);
			Inserted += (s, e) => ThrowEvent("CampaignTargetInserted", e);
			Validating += (s, e) => ThrowEvent("CampaignTargetValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignTarget(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignTarget_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignTarget_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignTarget
	{

		public CampaignTarget_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignTarget_CampaignsEventsProcess";
			SchemaUId = new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8643c3cf-f6be-43f4-9b93-fe14ba3b9123");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
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
					SchemaElementUId = new Guid("0a088dce-5fdb-40f4-b947-8853000b1670"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignTargetInserted;
		public ProcessFlowElement CampaignTargetInserted {
			get {
				return _campaignTargetInserted ?? (_campaignTargetInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignTargetInserted",
					SchemaElementUId = new Guid("4622b3b5-e3c1-47e4-ab4e-d5280c985008"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _campaignTargetInsertedScriptTask;
		public ProcessScriptTask CampaignTargetInsertedScriptTask {
			get {
				return _campaignTargetInsertedScriptTask ?? (_campaignTargetInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignTargetInsertedScriptTask",
					SchemaElementUId = new Guid("5afedccf-9e10-44e9-b3ee-b67388821817"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CampaignTargetInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("57aed1c6-038c-49c3-a557-3a5b73ed016e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignTargetDeleted;
		public ProcessFlowElement CampaignTargetDeleted {
			get {
				return _campaignTargetDeleted ?? (_campaignTargetDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignTargetDeleted",
					SchemaElementUId = new Guid("2765b473-9238-40af-858a-a1294fc1f185"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _campaignTargetDeletedScriptTask;
		public ProcessScriptTask CampaignTargetDeletedScriptTask {
			get {
				return _campaignTargetDeletedScriptTask ?? (_campaignTargetDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignTargetDeletedScriptTask",
					SchemaElementUId = new Guid("ba67467c-b9d4-45e6-95a7-c89720754d20"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CampaignTargetDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[CampaignTargetInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignTargetInserted };
			FlowElements[CampaignTargetInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignTargetInsertedScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[CampaignTargetDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignTargetDeleted };
			FlowElements[CampaignTargetDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignTargetDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "CampaignTargetInserted":
						e.Context.QueueTasks.Enqueue("CampaignTargetInsertedScriptTask");
						break;
					case "CampaignTargetInsertedScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "CampaignTargetDeleted":
						e.Context.QueueTasks.Enqueue("CampaignTargetDeletedScriptTask");
						break;
					case "CampaignTargetDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CampaignTargetInserted");
			ActivatedEventElements.Add("CampaignTargetDeleted");
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
				case "CampaignTargetInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignTargetInserted";
					result = CampaignTargetInserted.Execute(context);
					break;
				case "CampaignTargetInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignTargetInsertedScriptTask";
					result = CampaignTargetInsertedScriptTask.Execute(context, CampaignTargetInsertedScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "CampaignTargetDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignTargetDeleted";
					result = CampaignTargetDeleted.Execute(context);
					break;
				case "CampaignTargetDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignTargetDeletedScriptTask";
					result = CampaignTargetDeletedScriptTask.Execute(context, CampaignTargetDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CampaignTargetInsertedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateTargetTotal(1);
			return true;
		}

		public virtual bool CampaignTargetDeletedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateTargetTotal(-1);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CampaignTargetInserted":
							if (ActivatedEventElements.Contains("CampaignTargetInserted")) {
							context.QueueTasks.Enqueue("CampaignTargetInserted");
						}
						break;
					case "CampaignTargetDeleted":
							if (ActivatedEventElements.Contains("CampaignTargetDeleted")) {
							context.QueueTasks.Enqueue("CampaignTargetDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignTarget_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignTarget_CampaignsEventsProcess : CampaignTarget_CampaignsEventsProcess<CampaignTarget>
	{

		public CampaignTarget_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignTarget_CampaignsEventsProcess

	public partial class CampaignTarget_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateTargetTotal(int intCount) {
			Guid campaignId = Entity.GetTypedColumnValue<Guid>("CampaignId");
			if (campaignId == Guid.Empty) {
				return;
			}
			var update = new Update(UserConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("TargetTotal", QueryColumnExpression.Add(new QueryColumnExpression("TargetTotal"),
					Column.Parameter(intCount)))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			update.Execute();
		}

		#endregion

	}

	#endregion


	#region Class: CampaignTargetEventsProcess

	/// <exclude/>
	public class CampaignTargetEventsProcess : CampaignTarget_CampaignsEventsProcess
	{

		public CampaignTargetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

