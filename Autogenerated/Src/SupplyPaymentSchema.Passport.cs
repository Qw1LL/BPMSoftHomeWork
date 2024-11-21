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

	#region Class: SupplyPaymentSchema

	/// <exclude/>
	[IsVirtual]
	public class SupplyPaymentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SupplyPaymentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentSchema(SupplyPaymentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentSchema(SupplyPaymentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			RealUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			Name = "SupplyPayment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f5e69141-5900-4800-93b7-6c06ca1e991d")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("dd703360-9b62-47fe-abb5-2f3ff6a57911")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("a3d987f5-d9a8-4016-b260-ee47be3c60b8")) == null) {
				Columns.Add(CreateDelayTypeColumn());
			}
			if (Columns.FindByUId(new Guid("e361f1d8-b6cb-47f5-9496-6347f6499848")) == null) {
				Columns.Add(CreateDelayColumn());
			}
			if (Columns.FindByUId(new Guid("c28a0bba-c826-48dd-8a58-0b80b4f55dee")) == null) {
				Columns.Add(CreatePercentageColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			column.CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f5e69141-5900-4800-93b7-6c06ca1e991d"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dd703360-9b62-47fe-abb5-2f3ff6a57911"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("f9876301-ffbc-4389-a53a-19413e3bd091"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDelayTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3d987f5-d9a8-4016-b260-ee47be3c60b8"),
				Name = @"DelayType",
				ReferenceSchemaUId = new Guid("180c1fb4-d61b-4aca-b6b3-e1fae4eaab1b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDelayColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e361f1d8-b6cb-47f5-9496-6347f6499848"),
				Name = @"Delay",
				CreatedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreatePercentageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c28a0bba-c826-48dd-8a58-0b80b4f55dee"),
				Name = @"Percentage",
				CreatedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				ModifiedInSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SupplyPayment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPayment_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("980a8f16-f64b-4446-8894-4637063d3818"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPayment

	/// <summary>
	/// График поставок и оплат.
	/// </summary>
	public class SupplyPayment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SupplyPayment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPayment";
		}

		public SupplyPayment(SupplyPayment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
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

		private SupplyPaymentType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public SupplyPaymentType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SupplyPaymentType);
			}
		}

		/// <exclude/>
		public Guid DelayTypeId {
			get {
				return GetTypedColumnValue<Guid>("DelayTypeId");
			}
			set {
				SetColumnValue("DelayTypeId", value);
				_delayType = null;
			}
		}

		/// <exclude/>
		public string DelayTypeName {
			get {
				return GetTypedColumnValue<string>("DelayTypeName");
			}
			set {
				SetColumnValue("DelayTypeName", value);
				if (_delayType != null) {
					_delayType.Name = value;
				}
			}
		}

		private SupplyPaymentDelay _delayType;
		/// <summary>
		/// Тип отсрочки.
		/// </summary>
		public SupplyPaymentDelay DelayType {
			get {
				return _delayType ??
					(_delayType = LookupColumnEntities.GetEntity("DelayType") as SupplyPaymentDelay);
			}
		}

		/// <summary>
		/// Отсрочка (дней).
		/// </summary>
		public int Delay {
			get {
				return GetTypedColumnValue<int>("Delay");
			}
			set {
				SetColumnValue("Delay", value);
			}
		}

		/// <summary>
		/// Доля (%).
		/// </summary>
		public Decimal Percentage {
			get {
				return GetTypedColumnValue<Decimal>("Percentage");
			}
			set {
				SetColumnValue("Percentage", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPayment_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupplyPaymentDeleted", e);
			Inserting += (s, e) => ThrowEvent("SupplyPaymentInserting", e);
			Saving += (s, e) => ThrowEvent("SupplyPaymentSaving", e);
			Validating += (s, e) => ThrowEvent("SupplyPaymentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupplyPayment(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPayment_PassportEventsProcess

	/// <exclude/>
	public partial class SupplyPayment_PassportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SupplyPayment
	{

		public SupplyPayment_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPayment_PassportEventsProcess";
			SchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool DoNotCheckCascadeCycle {
			get;
			set;
		}

		private ProcessFlowElement _onSupplyPaymentSavingEventSubProcess;
		public ProcessFlowElement OnSupplyPaymentSavingEventSubProcess {
			get {
				return _onSupplyPaymentSavingEventSubProcess ?? (_onSupplyPaymentSavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OnSupplyPaymentSavingEventSubProcess",
					SchemaElementUId = new Guid("5cf8d3ae-a936-43bc-a753-5d895895e2de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _supplyPaymentSavingStartMessage;
		public ProcessFlowElement SupplyPaymentSavingStartMessage {
			get {
				return _supplyPaymentSavingStartMessage ?? (_supplyPaymentSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SupplyPaymentSavingStartMessage",
					SchemaElementUId = new Guid("f1cc00e9-781c-437b-bd55-068f34f3a2e7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _supplyPaymentOnSavingScriptTask;
		public ProcessScriptTask SupplyPaymentOnSavingScriptTask {
			get {
				return _supplyPaymentOnSavingScriptTask ?? (_supplyPaymentOnSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SupplyPaymentOnSavingScriptTask",
					SchemaElementUId = new Guid("e5817a4b-e1d9-4a6c-8018-13b6cc4d3413"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SupplyPaymentOnSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[OnSupplyPaymentSavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { OnSupplyPaymentSavingEventSubProcess };
			FlowElements[SupplyPaymentSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentSavingStartMessage };
			FlowElements[SupplyPaymentOnSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentOnSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "OnSupplyPaymentSavingEventSubProcess":
						break;
					case "SupplyPaymentSavingStartMessage":
						e.Context.QueueTasks.Enqueue("SupplyPaymentOnSavingScriptTask");
						break;
					case "SupplyPaymentOnSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SupplyPaymentSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "OnSupplyPaymentSavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SupplyPaymentSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SupplyPaymentSavingStartMessage";
					result = SupplyPaymentSavingStartMessage.Execute(context);
					break;
				case "SupplyPaymentOnSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SupplyPaymentOnSavingScriptTask";
					result = SupplyPaymentOnSavingScriptTask.Execute(context, SupplyPaymentOnSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SupplyPaymentOnSavingScriptTaskExecute(ProcessExecutingContext context) {
			CheckCascadeCycle();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SupplyPaymentSaving":
							if (ActivatedEventElements.Contains("SupplyPaymentSavingStartMessage")) {
							context.QueueTasks.Enqueue("SupplyPaymentSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPayment_PassportEventsProcess

	/// <exclude/>
	public class SupplyPayment_PassportEventsProcess : SupplyPayment_PassportEventsProcess<SupplyPayment>
	{

		public SupplyPayment_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPayment_PassportEventsProcess

	public partial class SupplyPayment_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckCascadeCycle() {
			var passportHelper = ClassFactory.Get<BPMSoft.Configuration.Passport.OrderPassportHelper>(new ConstructorArgument("userConnection", UserConnection));
			passportHelper.ThrowIfFindCascadeCycle(Entity);
		}

		#endregion

	}

	#endregion


	#region Class: SupplyPaymentEventsProcess

	/// <exclude/>
	public class SupplyPaymentEventsProcess : SupplyPayment_PassportEventsProcess
	{

		public SupplyPaymentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

