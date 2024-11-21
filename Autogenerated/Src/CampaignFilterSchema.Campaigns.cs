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

	#region Class: CampaignFilterSchema

	/// <exclude/>
	public class CampaignFilterSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignFilterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignFilterSchema(CampaignFilterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignFilterSchema(CampaignFilterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1");
			RealUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1");
			Name = "CampaignFilter";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b52717ed-5515-4b11-931b-8a4b7b1026f8")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("c638c75d-cf1b-4f8b-8b25-003663acfd8c")) == null) {
				Columns.Add(CreateStepTypeColumn());
			}
			if (Columns.FindByUId(new Guid("269cb8ee-66e8-4068-b216-d50b2dfead77")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("c03a5deb-4894-45ea-a669-7070cb88870c")) == null) {
				Columns.Add(CreateSearchDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b52717ed-5515-4b11-931b-8a4b7b1026f8"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				ModifiedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateStepTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c638c75d-cf1b-4f8b-8b25-003663acfd8c"),
				Name = @"StepType",
				ReferenceSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				ModifiedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("269cb8ee-66e8-4068-b216-d50b2dfead77"),
				Name = @"Priority",
				CreatedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				ModifiedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("c03a5deb-4894-45ea-a669-7070cb88870c"),
				Name = @"SearchData",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				ModifiedInSchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignFilter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignFilter_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignFilterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignFilterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFilter

	/// <summary>
	/// Фильтр кампании.
	/// </summary>
	public class CampaignFilter : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignFilter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignFilter";
		}

		public CampaignFilter(CampaignFilter source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid StepTypeId {
			get {
				return GetTypedColumnValue<Guid>("StepTypeId");
			}
			set {
				SetColumnValue("StepTypeId", value);
				_stepType = null;
			}
		}

		/// <exclude/>
		public string StepTypeName {
			get {
				return GetTypedColumnValue<string>("StepTypeName");
			}
			set {
				SetColumnValue("StepTypeName", value);
				if (_stepType != null) {
					_stepType.Name = value;
				}
			}
		}

		private CampaignStepType _stepType;
		/// <summary>
		/// Тип шага кампании.
		/// </summary>
		public CampaignStepType StepType {
			get {
				return _stepType ??
					(_stepType = LookupColumnEntities.GetEntity("StepType") as CampaignStepType);
			}
		}

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignFilter_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignFilterDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignFilterValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignFilter(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFilter_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignFilter_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignFilter
	{

		public CampaignFilter_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignFilter_CampaignsEventsProcess";
			SchemaUId = new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9244f0c0-0d7d-42a2-849d-e4f1c573f6f1");
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

	#region Class: CampaignFilter_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignFilter_CampaignsEventsProcess : CampaignFilter_CampaignsEventsProcess<CampaignFilter>
	{

		public CampaignFilter_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignFilter_CampaignsEventsProcess

	public partial class CampaignFilter_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignFilterEventsProcess

	/// <exclude/>
	public class CampaignFilterEventsProcess : CampaignFilter_CampaignsEventsProcess
	{

		public CampaignFilterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

