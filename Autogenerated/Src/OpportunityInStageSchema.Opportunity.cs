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

	#region Class: OpportunityInStage_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityInStage_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityInStage_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityInStage_Opportunity_BPMSoftSchema(OpportunityInStage_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityInStage_Opportunity_BPMSoftSchema(OpportunityInStage_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
			RealUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
			Name = "OpportunityInStage_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8b3946f7-ad10-4f89-883c-9a08a80cbe83")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("090840ea-21fc-49ba-9958-990f22e42bf3")) == null) {
				Columns.Add(CreateStageColumn());
			}
			if (Columns.FindByUId(new Guid("02db2511-d423-4291-bd91-c7a011bee1b0")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("1d2978bd-4450-4644-8956-bcce8aa74605")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("72d21395-9938-4445-aa6f-15b70e2ad832")) == null) {
				Columns.Add(CreateCommentsColumn());
			}
			if (Columns.FindByUId(new Guid("b804c516-0922-4455-9f55-c8f1c41e1412")) == null) {
				Columns.Add(CreateHistoricalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8b3946f7-ad10-4f89-883c-9a08a80cbe83"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("090840ea-21fc-49ba-9958-990f22e42bf3"),
				Name = @"Stage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("02db2511-d423-4291-bd91-c7a011bee1b0"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("1d2978bd-4450-4644-8956-bcce8aa74605"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ee7e9bf9-935b-45c9-9fef-bc95660facfc"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("72d21395-9938-4445-aa6f-15b70e2ad832"),
				Name = @"Comments",
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHistoricalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b804c516-0922-4455-9f55-c8f1c41e1412"),
				Name = @"Historical",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				ModifiedInSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityInStage_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityInStage_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityInStage_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityInStage_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInStage_Opportunity_BPMSoft

	/// <summary>
	/// Стадия в продаже.
	/// </summary>
	public class OpportunityInStage_Opportunity_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityInStage_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityInStage_Opportunity_BPMSoft";
		}

		public OpportunityInStage_Opportunity_BPMSoft(OpportunityInStage_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private OpportunityStage _stage;
		/// <summary>
		/// Стадия.
		/// </summary>
		public OpportunityStage Stage {
			get {
				return _stage ??
					(_stage = LookupColumnEntities.GetEntity("Stage") as OpportunityStage);
			}
		}

		/// <summary>
		/// Начало.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Завершение.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comments {
			get {
				return GetTypedColumnValue<string>("Comments");
			}
			set {
				SetColumnValue("Comments", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		/// <remarks>
		/// Признак отображения стадии в воронке (1 - не отображать).
		/// </remarks>
		public bool Historical {
			get {
				return GetTypedColumnValue<bool>("Historical");
			}
			set {
				SetColumnValue("Historical", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityInStage_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityInStage_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityInStage_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInStage_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityInStage_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityInStage_Opportunity_BPMSoft
	{

		public OpportunityInStage_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityInStage_OpportunityEventsProcess";
			SchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
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

	#region Class: OpportunityInStage_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityInStage_OpportunityEventsProcess : OpportunityInStage_OpportunityEventsProcess<OpportunityInStage_Opportunity_BPMSoft>
	{

		public OpportunityInStage_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityInStage_OpportunityEventsProcess

	public partial class OpportunityInStage_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

