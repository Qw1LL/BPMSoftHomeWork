namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.PRM;
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

	#region Class: Fund_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class Fund_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Fund_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Fund_PRMBase_BPMSoftSchema(Fund_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Fund_PRMBase_BPMSoftSchema(Fund_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a734110-378e-4108-9383-726930984f2e");
			RealUId = new Guid("9a734110-378e-4108-9383-726930984f2e");
			Name = "Fund_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63");
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

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreatePartnershipColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("28c96aef-b95f-4da8-9621-0feb2a61ed83")) == null) {
				Columns.Add(CreateFundTypeColumn());
			}
			if (Columns.FindByUId(new Guid("39ce4498-d254-4474-af20-0caaacbdcbb5")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("30078a2c-c5e2-49a6-8021-a1dfd8d88654")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("eb78c0d3-7890-45af-91ba-0058c0bd2106")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("fb2c5d4f-1efc-4190-a62f-900e396966e7")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("76bc22c3-dd5e-49d4-9006-c132e499e915")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFundTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("28c96aef-b95f-4da8-9621-0feb2a61ed83"),
				Name = @"FundType",
				ReferenceSchemaUId = new Guid("b0f52d2c-d309-4fd7-8268-fc08a18244ae"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7886b405-c0cf-4555-baa4-a21197de63a0"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("39ce4498-d254-4474-af20-0caaacbdcbb5"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("30078a2c-c5e2-49a6-8021-a1dfd8d88654"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("eb78c0d3-7890-45af-91ba-0058c0bd2106"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fb2c5d4f-1efc-4190-a62f-900e396966e7"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("76bc22c3-dd5e-49d4-9006-c132e499e915"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("05891835-e36d-412b-b0c5-d500d04627aa"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				ModifiedInSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Fund_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Fund_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Fund_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Fund_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a734110-378e-4108-9383-726930984f2e"));
		}

		#endregion

	}

	#endregion

	#region Class: Fund_PRMBase_BPMSoft

	/// <summary>
	/// Фонд.
	/// </summary>
	public class Fund_PRMBase_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Fund_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Fund_PRMBase_BPMSoft";
		}

		public Fund_PRMBase_BPMSoft(Fund_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid FundTypeId {
			get {
				return GetTypedColumnValue<Guid>("FundTypeId");
			}
			set {
				SetColumnValue("FundTypeId", value);
				_fundType = null;
			}
		}

		/// <exclude/>
		public string FundTypeName {
			get {
				return GetTypedColumnValue<string>("FundTypeName");
			}
			set {
				SetColumnValue("FundTypeName", value);
				if (_fundType != null) {
					_fundType.Name = value;
				}
			}
		}

		private FundType _fundType;
		/// <summary>
		/// Показатель.
		/// </summary>
		public FundType FundType {
			get {
				return _fundType ??
					(_fundType = LookupColumnEntities.GetEntity("FundType") as FundType);
			}
		}

		/// <exclude/>
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Партнерство.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = LookupColumnEntities.GetEntity("Partnership") as Partnership);
			}
		}

		/// <summary>
		/// Доступно.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Дата начала.
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
		/// Дата завершения.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Активен.
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
		/// Описание показателя.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Показатель.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Fund_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Fund_PRMBase_BPMSoftDeleted", e);
			Saving += (s, e) => ThrowEvent("Fund_PRMBase_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Fund_PRMBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Fund_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Fund_PRMBaseEventsProcess

	/// <exclude/>
	public partial class Fund_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Fund_PRMBase_BPMSoft
	{

		public Fund_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Fund_PRMBaseEventsProcess";
			SchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a734110-378e-4108-9383-726930984f2e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _onFundSaving;
		public ProcessFlowElement OnFundSaving {
			get {
				return _onFundSaving ?? (_onFundSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OnFundSaving",
					SchemaElementUId = new Guid("70a0a1f5-ff4f-42fb-992c-c25e4d181463"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _fundSaving;
		public ProcessFlowElement FundSaving {
			get {
				return _fundSaving ?? (_fundSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "FundSaving",
					SchemaElementUId = new Guid("36a351d1-a8ab-410a-9544-45dfaa8ee242"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _fillNameFromFundType;
		public ProcessScriptTask FillNameFromFundType {
			get {
				return _fillNameFromFundType ?? (_fillNameFromFundType = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FillNameFromFundType",
					SchemaElementUId = new Guid("3989db05-2b80-43b2-9cb0-f7983e6eb0b5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = FillNameFromFundTypeExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[OnFundSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { OnFundSaving };
			FlowElements[FundSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { FundSaving };
			FlowElements[FillNameFromFundType.SchemaElementUId] = new Collection<ProcessFlowElement> { FillNameFromFundType };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "OnFundSaving":
						break;
					case "FundSaving":
						e.Context.QueueTasks.Enqueue("FillNameFromFundType");
						break;
					case "FillNameFromFundType":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("FundSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "OnFundSaving":
					context.QueueTasks.Dequeue();
					break;
				case "FundSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "FundSaving";
					result = FundSaving.Execute(context);
					break;
				case "FillNameFromFundType":
					context.QueueTasks.Dequeue();
					context.SenderName = "FillNameFromFundType";
					result = FillNameFromFundType.Execute(context, FillNameFromFundTypeExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool FillNameFromFundTypeExecute(ProcessExecutingContext context) {
			CheckFundTypeDuplicate();
			FillName(); 
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Fund_PRMBase_BPMSoftSaving":
							if (ActivatedEventElements.Contains("FundSaving")) {
							context.QueueTasks.Enqueue("FundSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Fund_PRMBaseEventsProcess

	/// <exclude/>
	public class Fund_PRMBaseEventsProcess : Fund_PRMBaseEventsProcess<Fund_PRMBase_BPMSoft>
	{

		public Fund_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Fund_PRMBaseEventsProcess

	public partial class Fund_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void FillName() {
			object fundTypeId = Entity.GetColumnValue("FundTypeId");
			if (fundTypeId == null) {
				return;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "FundType");
			esq.AddColumn("Id");
			esq.AddColumn("Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", fundTypeId));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count == 0) {
				return;
			}
			Entity.SetColumnValue("Name", collection[0].GetColumnValue("Name"));
		}

		public virtual void CheckFundTypeDuplicate() {
			object id = Entity.GetColumnValue("Id");
			object fundTypeId = Entity.GetColumnValue("FundTypeId");
			object partnershipId = Entity.GetColumnValue("PartnershipId");
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Fund");
			esq.AddColumn("Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "FundType", fundTypeId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership", partnershipId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", id));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count > 0) {
				throw new FundTypeDuplicateException(UserConnection.Workspace.ResourceStorage);
			}
		}

		#endregion

	}

	#endregion

}

