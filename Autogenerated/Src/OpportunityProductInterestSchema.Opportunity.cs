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

	#region Class: OpportunityProductInterest_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityProductInterest_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityProductInterest_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityProductInterest_Opportunity_BPMSoftSchema(OpportunityProductInterest_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityProductInterest_Opportunity_BPMSoftSchema(OpportunityProductInterest_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
			RealUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
			Name = "OpportunityProductInterest_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a95a4e48-7891-4394-bebc-94a52d2c83db")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("31fb834c-0d66-4272-a002-92f7ee99dcc4")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("c8aebeb1-1cfa-40e0-9d13-9e5a833a7af8")) == null) {
				Columns.Add(CreateQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("b7a9f0bb-fc54-4767-bb31-e282f72fa1a0")) == null) {
				Columns.Add(CreateOfferDateColumn());
			}
			if (Columns.FindByUId(new Guid("0d863985-10fd-4b5d-9135-c20b1522f626")) == null) {
				Columns.Add(CreateOfferResultColumn());
			}
			if (Columns.FindByUId(new Guid("9b6e7c1d-1407-474b-925a-e50da9f36419")) == null) {
				Columns.Add(CreateCommentColumn());
			}
			if (Columns.FindByUId(new Guid("8b1b514f-1ad8-46af-a324-5a9096a066dc")) == null) {
				Columns.Add(CreatePriceColumn());
			}
			if (Columns.FindByUId(new Guid("329a1823-df3b-4846-a6fb-c5f9fc259993")) == null) {
				Columns.Add(CreateAmountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a95a4e48-7891-4394-bebc-94a52d2c83db"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("31fb834c-0d66-4272-a002-92f7ee99dcc4"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c8aebeb1-1cfa-40e0-9d13-9e5a833a7af8"),
				Name = @"Quantity",
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOfferDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("b7a9f0bb-fc54-4767-bb31-e282f72fa1a0"),
				Name = @"OfferDate",
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOfferResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0d863985-10fd-4b5d-9135-c20b1522f626"),
				Name = @"OfferResult",
				ReferenceSchemaUId = new Guid("801a201c-7040-4489-a705-5896b20d2f52"),
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9b6e7c1d-1407-474b-925a-e50da9f36419"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("8b1b514f-1ad8-46af-a324-5a9096a066dc"),
				Name = @"Price",
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("329a1823-df3b-4846-a6fb-c5f9fc259993"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				ModifiedInSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityProductInterest_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityProductInterest_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityProductInterest_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityProductInterest_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProductInterest_Opportunity_BPMSoft

	/// <summary>
	/// Продукт в продаже.
	/// </summary>
	public class OpportunityProductInterest_Opportunity_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityProductInterest_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityProductInterest_Opportunity_BPMSoft";
		}

		public OpportunityProductInterest_Opportunity_BPMSoft(OpportunityProductInterest_Opportunity_BPMSoft source)
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
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <summary>
		/// Количество.
		/// </summary>
		public Decimal Quantity {
			get {
				return GetTypedColumnValue<Decimal>("Quantity");
			}
			set {
				SetColumnValue("Quantity", value);
			}
		}

		/// <summary>
		/// Дата предложения.
		/// </summary>
		public DateTime OfferDate {
			get {
				return GetTypedColumnValue<DateTime>("OfferDate");
			}
			set {
				SetColumnValue("OfferDate", value);
			}
		}

		/// <exclude/>
		public Guid OfferResultId {
			get {
				return GetTypedColumnValue<Guid>("OfferResultId");
			}
			set {
				SetColumnValue("OfferResultId", value);
				_offerResult = null;
			}
		}

		/// <exclude/>
		public string OfferResultName {
			get {
				return GetTypedColumnValue<string>("OfferResultName");
			}
			set {
				SetColumnValue("OfferResultName", value);
				if (_offerResult != null) {
					_offerResult.Name = value;
				}
			}
		}

		private PropositionResult _offerResult;
		/// <summary>
		/// Результат предложения.
		/// </summary>
		public PropositionResult OfferResult {
			get {
				return _offerResult ??
					(_offerResult = LookupColumnEntities.GetEntity("OfferResult") as PropositionResult);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		/// <summary>
		/// Цена.
		/// </summary>
		public Decimal Price {
			get {
				return GetTypedColumnValue<Decimal>("Price");
			}
			set {
				SetColumnValue("Price", value);
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityProductInterest_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityProductInterest_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityProductInterest_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProductInterest_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityProductInterest_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityProductInterest_Opportunity_BPMSoft
	{

		public OpportunityProductInterest_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityProductInterest_OpportunityEventsProcess";
			SchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid OpportunityId {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("094878a5-9cd7-4342-8c89-cb1841a7cc22"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _calckOpportunityAmountOpportunityProductInterestSaved;
		public ProcessFlowElement CalckOpportunityAmountOpportunityProductInterestSaved {
			get {
				return _calckOpportunityAmountOpportunityProductInterestSaved ?? (_calckOpportunityAmountOpportunityProductInterestSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CalckOpportunityAmountOpportunityProductInterestSaved",
					SchemaElementUId = new Guid("64e54c47-2b33-4472-aceb-ffd60d7b815d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _calckOpportunityAmountIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent CalckOpportunityAmountIntermediateThrowMessageEvent {
			get {
				return _calckOpportunityAmountIntermediateThrowMessageEvent ?? (_calckOpportunityAmountIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "CalckOpportunityAmountIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("86602499-a7e6-40c2-8ee2-57de6f20fb48"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "OpportunityProductInterestSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _calckOpportunityAmountAfterSevedScriptTask;
		public ProcessScriptTask CalckOpportunityAmountAfterSevedScriptTask {
			get {
				return _calckOpportunityAmountAfterSevedScriptTask ?? (_calckOpportunityAmountAfterSevedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CalckOpportunityAmountAfterSevedScriptTask",
					SchemaElementUId = new Guid("7ea89087-bafe-48a8-847d-9762ed8ed734"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CalckOpportunityAmountAfterSevedScriptTaskExecute,
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
					SchemaElementUId = new Guid("bb26cd7e-54ac-4d39-a295-3cb3ee9cd070"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunityProductInterestDeletingStartMessage;
		public ProcessFlowElement OpportunityProductInterestDeletingStartMessage {
			get {
				return _opportunityProductInterestDeletingStartMessage ?? (_opportunityProductInterestDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityProductInterestDeletingStartMessage",
					SchemaElementUId = new Guid("576f1eb3-3ea5-4741-b152-930e2af4a3da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _opportunityProductInterestDeletingIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent OpportunityProductInterestDeletingIntermediateThrowMessageEvent {
			get {
				return _opportunityProductInterestDeletingIntermediateThrowMessageEvent ?? (_opportunityProductInterestDeletingIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "OpportunityProductInterestDeletingIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("3da1d3c9-a0f4-418c-9d4d-7d256022999b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "OpportunityProductInterestDeleting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _getParamsBeforDeleteScriptTask;
		public ProcessScriptTask GetParamsBeforDeleteScriptTask {
			get {
				return _getParamsBeforDeleteScriptTask ?? (_getParamsBeforDeleteScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GetParamsBeforDeleteScriptTask",
					SchemaElementUId = new Guid("87244ea0-827c-420f-8d0f-771a27aef1c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = GetParamsBeforDeleteScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("fe132501-9c48-48e9-a2c5-c591183965c6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunityProductInterestDeletedStartMessage;
		public ProcessFlowElement OpportunityProductInterestDeletedStartMessage {
			get {
				return _opportunityProductInterestDeletedStartMessage ?? (_opportunityProductInterestDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityProductInterestDeletedStartMessage",
					SchemaElementUId = new Guid("ea498719-b448-4c10-b1ee-ff9fa45d9312"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _opportunityProductInterestDeletedIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent OpportunityProductInterestDeletedIntermediateThrowMessageEvent {
			get {
				return _opportunityProductInterestDeletedIntermediateThrowMessageEvent ?? (_opportunityProductInterestDeletedIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "OpportunityProductInterestDeletedIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("ee2df171-dafc-4514-922d-8e8a1001784b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "OpportunityProductInterestDeleted",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _calckOpportunityAmountAfterDeletedScriptTask;
		public ProcessScriptTask CalckOpportunityAmountAfterDeletedScriptTask {
			get {
				return _calckOpportunityAmountAfterDeletedScriptTask ?? (_calckOpportunityAmountAfterDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CalckOpportunityAmountAfterDeletedScriptTask",
					SchemaElementUId = new Guid("cd4f967e-b9bd-4b6a-afd6-aac170daa6b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CalckOpportunityAmountAfterDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[CalckOpportunityAmountOpportunityProductInterestSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { CalckOpportunityAmountOpportunityProductInterestSaved };
			FlowElements[CalckOpportunityAmountIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { CalckOpportunityAmountIntermediateThrowMessageEvent };
			FlowElements[CalckOpportunityAmountAfterSevedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CalckOpportunityAmountAfterSevedScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[OpportunityProductInterestDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityProductInterestDeletingStartMessage };
			FlowElements[OpportunityProductInterestDeletingIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityProductInterestDeletingIntermediateThrowMessageEvent };
			FlowElements[GetParamsBeforDeleteScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GetParamsBeforDeleteScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[OpportunityProductInterestDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityProductInterestDeletedStartMessage };
			FlowElements[OpportunityProductInterestDeletedIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityProductInterestDeletedIntermediateThrowMessageEvent };
			FlowElements[CalckOpportunityAmountAfterDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CalckOpportunityAmountAfterDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "CalckOpportunityAmountOpportunityProductInterestSaved":
						e.Context.QueueTasks.Enqueue("CalckOpportunityAmountAfterSevedScriptTask");
						break;
					case "CalckOpportunityAmountIntermediateThrowMessageEvent":
						break;
					case "CalckOpportunityAmountAfterSevedScriptTask":
						e.Context.QueueTasks.Enqueue("CalckOpportunityAmountIntermediateThrowMessageEvent");
						break;
					case "EventSubProcess2":
						break;
					case "OpportunityProductInterestDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("GetParamsBeforDeleteScriptTask");
						break;
					case "OpportunityProductInterestDeletingIntermediateThrowMessageEvent":
						break;
					case "GetParamsBeforDeleteScriptTask":
						e.Context.QueueTasks.Enqueue("OpportunityProductInterestDeletingIntermediateThrowMessageEvent");
						break;
					case "EventSubProcess3":
						break;
					case "OpportunityProductInterestDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("CalckOpportunityAmountAfterDeletedScriptTask");
						break;
					case "OpportunityProductInterestDeletedIntermediateThrowMessageEvent":
						break;
					case "CalckOpportunityAmountAfterDeletedScriptTask":
						e.Context.QueueTasks.Enqueue("OpportunityProductInterestDeletedIntermediateThrowMessageEvent");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CalckOpportunityAmountOpportunityProductInterestSaved");
			ActivatedEventElements.Add("OpportunityProductInterestDeletingStartMessage");
			ActivatedEventElements.Add("OpportunityProductInterestDeletedStartMessage");
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
				case "CalckOpportunityAmountOpportunityProductInterestSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "CalckOpportunityAmountOpportunityProductInterestSaved";
					result = CalckOpportunityAmountOpportunityProductInterestSaved.Execute(context);
					break;
				case "CalckOpportunityAmountIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "OpportunityProductInterestSaved");
					result = CalckOpportunityAmountIntermediateThrowMessageEvent.Execute(context);
					break;
				case "CalckOpportunityAmountAfterSevedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CalckOpportunityAmountAfterSevedScriptTask";
					result = CalckOpportunityAmountAfterSevedScriptTask.Execute(context, CalckOpportunityAmountAfterSevedScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunityProductInterestDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityProductInterestDeletingStartMessage";
					result = OpportunityProductInterestDeletingStartMessage.Execute(context);
					break;
				case "OpportunityProductInterestDeletingIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "OpportunityProductInterestDeleting");
					result = OpportunityProductInterestDeletingIntermediateThrowMessageEvent.Execute(context);
					break;
				case "GetParamsBeforDeleteScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GetParamsBeforDeleteScriptTask";
					result = GetParamsBeforDeleteScriptTask.Execute(context, GetParamsBeforDeleteScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunityProductInterestDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityProductInterestDeletedStartMessage";
					result = OpportunityProductInterestDeletedStartMessage.Execute(context);
					break;
				case "OpportunityProductInterestDeletedIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "OpportunityProductInterestDeleted");
					result = OpportunityProductInterestDeletedIntermediateThrowMessageEvent.Execute(context);
					break;
				case "CalckOpportunityAmountAfterDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CalckOpportunityAmountAfterDeletedScriptTask";
					result = CalckOpportunityAmountAfterDeletedScriptTask.Execute(context, CalckOpportunityAmountAfterDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CalckOpportunityAmountAfterSevedScriptTaskExecute(ProcessExecutingContext context) {
			var opportunityId = Entity.GetTypedColumnValue<Guid>("OpportunityId");
			CalckOpportunityAmount(opportunityId);
			return true;
		}

		public virtual bool GetParamsBeforDeleteScriptTaskExecute(ProcessExecutingContext context) {
			OpportunityId = Entity.GetTypedColumnValue<Guid>("OpportunityId");
			return true;
		}

		public virtual bool CalckOpportunityAmountAfterDeletedScriptTaskExecute(ProcessExecutingContext context) {
			CalckOpportunityAmount(OpportunityId);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OpportunityProductInterest_Opportunity_BPMSoftSaved":
							if (ActivatedEventElements.Contains("CalckOpportunityAmountOpportunityProductInterestSaved")) {
							context.QueueTasks.Enqueue("CalckOpportunityAmountOpportunityProductInterestSaved");
						}
						break;
					case "OpportunityProductInterest_Opportunity_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("OpportunityProductInterestDeletingStartMessage")) {
							context.QueueTasks.Enqueue("OpportunityProductInterestDeletingStartMessage");
						}
						break;
					case "OpportunityProductInterest_Opportunity_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("OpportunityProductInterestDeletedStartMessage")) {
							context.QueueTasks.Enqueue("OpportunityProductInterestDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProductInterest_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityProductInterest_OpportunityEventsProcess : OpportunityProductInterest_OpportunityEventsProcess<OpportunityProductInterest_Opportunity_BPMSoft>
	{

		public OpportunityProductInterest_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

