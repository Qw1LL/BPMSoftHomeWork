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

	#region Class: Currency_Base_BPMSoftSchema

	/// <exclude/>
	public class Currency_Base_BPMSoftSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public Currency_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Currency_Base_BPMSoftSchema(Currency_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Currency_Base_BPMSoftSchema(Currency_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			RealUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			Name = "Currency_Base_BPMSoft";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("81913c21-afcb-4a38-9164-af361a45d80f")) == null) {
				Columns.Add(CreateShortNameColumn());
			}
			if (Columns.FindByUId(new Guid("1468ee69-0ffb-496f-9d4d-e91c1656d474")) == null) {
				Columns.Add(CreateSymbolColumn());
			}
			if (Columns.FindByUId(new Guid("aa202f22-3aa0-441e-b192-5e03e7e8090d")) == null) {
				Columns.Add(CreateRecalcDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("e8667452-cecb-4735-acf7-428ea8d62e50")) == null) {
				Columns.Add(CreateDivisionColumn());
			}
			if (Columns.FindByUId(new Guid("df51504c-ae63-42e8-964d-8a30ceff0a7c")) == null) {
				Columns.Add(CreateCurrecySymbolPositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateShortNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("81913c21-afcb-4a38-9164-af361a45d80f"),
				Name = @"ShortName",
				CreatedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSymbolColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1468ee69-0ffb-496f-9d4d-e91c1656d474"),
				Name = @"Symbol",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecalcDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("aa202f22-3aa0-441e-b192-5e03e7e8090d"),
				Name = @"RecalcDirection",
				CreatedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDivisionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e8667452-cecb-4735-acf7-428ea8d62e50"),
				Name = @"Division",
				CreatedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrecySymbolPositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("df51504c-ae63-42e8-964d-8a30ceff0a7c"),
				Name = @"CurrecySymbolPosition",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				ModifiedInSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Currency_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Currency_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Currency_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Currency_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"));
		}

		#endregion

	}

	#endregion

	#region Class: Currency_Base_BPMSoft

	/// <summary>
	/// Currency.
	/// </summary>
	public class Currency_Base_BPMSoft : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public Currency_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Currency_Base_BPMSoft";
		}

		public Currency_Base_BPMSoft(Currency_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Short name.
		/// </summary>
		public string ShortName {
			get {
				return GetTypedColumnValue<string>("ShortName");
			}
			set {
				SetColumnValue("ShortName", value);
			}
		}

		/// <summary>
		/// Symbol.
		/// </summary>
		public string Symbol {
			get {
				return GetTypedColumnValue<string>("Symbol");
			}
			set {
				SetColumnValue("Symbol", value);
			}
		}

		/// <summary>
		/// Exchange rate format.
		/// </summary>
		public int RecalcDirection {
			get {
				return GetTypedColumnValue<int>("RecalcDirection");
			}
			set {
				SetColumnValue("RecalcDirection", value);
			}
		}

		/// <summary>
		/// Ratio.
		/// </summary>
		public int Division {
			get {
				return GetTypedColumnValue<int>("Division");
			}
			set {
				SetColumnValue("Division", value);
			}
		}

		/// <summary>
		/// Position of currency sign.
		/// </summary>
		public int CurrecySymbolPosition {
			get {
				return GetTypedColumnValue<int>("CurrecySymbolPosition");
			}
			set {
				SetColumnValue("CurrecySymbolPosition", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Currency_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Currency_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Currency_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Currency_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Currency_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Currency_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Currency_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Currency_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Currency_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Currency_BaseEventsProcess

	/// <exclude/>
	public partial class Currency_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : Currency_Base_BPMSoft
	{

		public Currency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Currency_BaseEventsProcess";
			SchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _currencySavingEventSubProcess;
		public ProcessFlowElement CurrencySavingEventSubProcess {
			get {
				return _currencySavingEventSubProcess ?? (_currencySavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "CurrencySavingEventSubProcess",
					SchemaElementUId = new Guid("d7405b28-4dd8-44bf-ae25-c0cc5c2dcf64"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _currencySaved;
		public ProcessFlowElement CurrencySaved {
			get {
				return _currencySaved ?? (_currencySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CurrencySaved",
					SchemaElementUId = new Guid("51c97a53-807d-4adf-aa96-5cf39648a605"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _currencySavingScriptTask;
		public ProcessScriptTask CurrencySavingScriptTask {
			get {
				return _currencySavingScriptTask ?? (_currencySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CurrencySavingScriptTask",
					SchemaElementUId = new Guid("29c3e3d3-a9c9-46b9-80ff-d849ae891091"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CurrencySavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _currencyDeletedEventSubProcess;
		public ProcessFlowElement CurrencyDeletedEventSubProcess {
			get {
				return _currencyDeletedEventSubProcess ?? (_currencyDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "CurrencyDeletedEventSubProcess",
					SchemaElementUId = new Guid("84ba92f4-eb44-4c72-8628-ae123b9ed515"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _currencyDeleted;
		public ProcessFlowElement CurrencyDeleted {
			get {
				return _currencyDeleted ?? (_currencyDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CurrencyDeleted",
					SchemaElementUId = new Guid("1ee26a11-bba1-4f28-bc80-a4e392f9c495"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _currencyDeletedScriptTask;
		public ProcessScriptTask CurrencyDeletedScriptTask {
			get {
				return _currencyDeletedScriptTask ?? (_currencyDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CurrencyDeletedScriptTask",
					SchemaElementUId = new Guid("bb4be2b3-ed2e-4cce-8aff-007db2e53dc4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CurrencyDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[CurrencySavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencySavingEventSubProcess };
			FlowElements[CurrencySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencySaved };
			FlowElements[CurrencySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencySavingScriptTask };
			FlowElements[CurrencyDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencyDeletedEventSubProcess };
			FlowElements[CurrencyDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencyDeleted };
			FlowElements[CurrencyDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencyDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "CurrencySavingEventSubProcess":
						break;
					case "CurrencySaved":
						e.Context.QueueTasks.Enqueue("CurrencySavingScriptTask");
						break;
					case "CurrencySavingScriptTask":
						break;
					case "CurrencyDeletedEventSubProcess":
						break;
					case "CurrencyDeleted":
						e.Context.QueueTasks.Enqueue("CurrencyDeletedScriptTask");
						break;
					case "CurrencyDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CurrencySaved");
			ActivatedEventElements.Add("CurrencyDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "CurrencySavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "CurrencySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencySaved";
					result = CurrencySaved.Execute(context);
					break;
				case "CurrencySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencySavingScriptTask";
					result = CurrencySavingScriptTask.Execute(context, CurrencySavingScriptTaskExecute);
					break;
				case "CurrencyDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "CurrencyDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencyDeleted";
					result = CurrencyDeleted.Execute(context);
					break;
				case "CurrencyDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencyDeletedScriptTask";
					result = CurrencyDeletedScriptTask.Execute(context, CurrencyDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CurrencySavingScriptTaskExecute(ProcessExecutingContext context) {
			ExpireCache();
			return true;
		}

		public virtual bool CurrencyDeletedScriptTaskExecute(ProcessExecutingContext context) {
			ExpireCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Currency_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("CurrencySaved")) {
							context.QueueTasks.Enqueue("CurrencySaved");
						}
						break;
					case "Currency_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("CurrencyDeleted")) {
							context.QueueTasks.Enqueue("CurrencyDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Currency_BaseEventsProcess

	/// <exclude/>
	public class Currency_BaseEventsProcess : Currency_BaseEventsProcess<Currency_Base_BPMSoft>
	{

		public Currency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

