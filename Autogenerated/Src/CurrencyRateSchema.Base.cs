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
	using BPMSoft.Core.Store;
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

	#region Class: CurrencyRate_Base_BPMSoftSchema

	/// <exclude/>
	public class CurrencyRate_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CurrencyRate_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CurrencyRate_Base_BPMSoftSchema(CurrencyRate_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CurrencyRate_Base_BPMSoftSchema(CurrencyRate_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
			RealUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
			Name = "CurrencyRate_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fffa677c-647e-4b47-9a24-8fb2639fe3a4")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("b4b497ac-79b3-4db1-a75a-f80d9039f3ea")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("84ce4c1c-f001-4109-86fa-c9b36e8fd5d7")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("8484fcf9-f40d-48a1-a787-aba9e26c1fb0")) == null) {
				Columns.Add(CreateRateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("fffa677c-647e-4b47-9a24-8fb2639fe3a4"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				ModifiedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("b4b497ac-79b3-4db1-a75a-f80d9039f3ea"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				ModifiedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("84ce4c1c-f001-4109-86fa-c9b36e8fd5d7"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				ModifiedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("8484fcf9-f40d-48a1-a787-aba9e26c1fb0"),
				Name = @"Rate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				ModifiedInSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CurrencyRate_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CurrencyRate_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CurrencyRate_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CurrencyRate_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f"));
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_Base_BPMSoft

	/// <summary>
	/// Exchange rate.
	/// </summary>
	public class CurrencyRate_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CurrencyRate_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CurrencyRate_Base_BPMSoft";
		}

		public CurrencyRate_Base_BPMSoft(CurrencyRate_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Start.
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
		/// End.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Currency.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Exchange rate.
		/// </summary>
		public Decimal Rate {
			get {
				return GetTypedColumnValue<Decimal>("Rate");
			}
			set {
				SetColumnValue("Rate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CurrencyRate_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("CurrencyRate_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CurrencyRate_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_BaseEventsProcess

	/// <exclude/>
	public partial class CurrencyRate_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CurrencyRate_Base_BPMSoft
	{

		public CurrencyRate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CurrencyRate_BaseEventsProcess";
			SchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
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
					SchemaElementUId = new Guid("97f9a6e8-9ab1-4669-baf5-c2cfdb784af9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _currencyRateSaved;
		public ProcessFlowElement CurrencyRateSaved {
			get {
				return _currencyRateSaved ?? (_currencyRateSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CurrencyRateSaved",
					SchemaElementUId = new Guid("c9d96d44-f6bd-43fa-805f-a0592a93702d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("cf4c07cc-737d-4e5f-b456-8a7dc2b2e7ff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
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
					SchemaElementUId = new Guid("7a5096cb-4a71-447f-bbf1-fa4475ae3626"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _currencyRateDeleted;
		public ProcessFlowElement CurrencyRateDeleted {
			get {
				return _currencyRateDeleted ?? (_currencyRateDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CurrencyRateDeleted",
					SchemaElementUId = new Guid("498889f7-49b9-4a11-b6be-1e3949d2fa4c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("d08a5c93-c77c-4a1d-9e6e-ac3fad4405c5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[CurrencyRateSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencyRateSaved };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[CurrencyRateDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencyRateDeleted };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "CurrencyRateSaved":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
					case "EventSubProcess2":
						break;
					case "CurrencyRateDeleted":
						e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ScriptTask2":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CurrencyRateSaved");
			ActivatedEventElements.Add("CurrencyRateDeleted");
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
				case "CurrencyRateSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencyRateSaved";
					result = CurrencyRateSaved.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "CurrencyRateDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencyRateDeleted";
					result = CurrencyRateDeleted.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			ExpireCache();
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			ExpireCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CurrencyRate_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("CurrencyRateSaved")) {
							context.QueueTasks.Enqueue("CurrencyRateSaved");
						}
						break;
					case "CurrencyRate_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("CurrencyRateDeleted")) {
							context.QueueTasks.Enqueue("CurrencyRateDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_BaseEventsProcess

	/// <exclude/>
	public class CurrencyRate_BaseEventsProcess : CurrencyRate_BaseEventsProcess<CurrencyRate_Base_BPMSoft>
	{

		public CurrencyRate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

