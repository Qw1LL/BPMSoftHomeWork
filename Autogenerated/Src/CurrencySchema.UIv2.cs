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

	#region Class: Currency_UIv2_BPMSoftSchema

	/// <exclude/>
	public class Currency_UIv2_BPMSoftSchema : BPMSoft.Configuration.Currency_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public Currency_UIv2_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Currency_UIv2_BPMSoftSchema(Currency_UIv2_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Currency_UIv2_BPMSoftSchema(Currency_UIv2_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e9ccd05c-37ff-4981-b149-cde79e14441e");
			Name = "Currency_UIv2_BPMSoft";
			ParentSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b13238af-3645-4799-8cf7-063a08194804")) == null) {
				Columns.Add(CreateRateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("b13238af-3645-4799-8cf7-063a08194804"),
				Name = @"Rate",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("e9ccd05c-37ff-4981-b149-cde79e14441e"),
				ModifiedInSchemaUId = new Guid("e9ccd05c-37ff-4981-b149-cde79e14441e"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Currency_UIv2_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Currency_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new Currency_UIv2_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Currency_UIv2_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9ccd05c-37ff-4981-b149-cde79e14441e"));
		}

		#endregion

	}

	#endregion

	#region Class: Currency_UIv2_BPMSoft

	/// <summary>
	/// Currency.
	/// </summary>
	public class Currency_UIv2_BPMSoft : BPMSoft.Configuration.Currency_Base_BPMSoft
	{

		#region Constructors: Public

		public Currency_UIv2_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Currency_UIv2_BPMSoft";
		}

		public Currency_UIv2_BPMSoft(Currency_UIv2_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Rate.
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
			var process = new Currency_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Saved += (s, e) => ThrowEvent("Currency_UIv2_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Currency_UIv2_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Currency_UIv2_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Currency_UIv2_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Currency_UIv2EventsProcess

	/// <exclude/>
	public partial class Currency_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.Currency_BaseEventsProcess<TEntity> where TEntity : Currency_UIv2_BPMSoft
	{

		public Currency_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Currency_UIv2EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e9ccd05c-37ff-4981-b149-cde79e14441e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Decimal CurrencyRate {
			get;
			set;
		}

		public virtual Decimal OldCurrencyRate {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("2910f140-1474-45b0-978e-b68a53f64864"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _currencySaving;
		public ProcessFlowElement CurrencySaving {
			get {
				return _currencySaving ?? (_currencySaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CurrencySaving",
					SchemaElementUId = new Guid("bc2abbd2-8988-42b1-b3d5-d237ff445474"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3;
		public ProcessScriptTask ScriptTask3 {
			get {
				return _scriptTask3 ?? (_scriptTask3 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3",
					SchemaElementUId = new Guid("33c212dd-d323-42ad-8c08-0f7e7408d894"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("3226b250-eb4b-436a-801d-980c0ffdf7d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage2;
		public ProcessFlowElement StartMessage2 {
			get {
				return _startMessage2 ?? (_startMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage2",
					SchemaElementUId = new Guid("14ffda80-4f0e-4421-88b2-5ce78d68260c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask4;
		public ProcessScriptTask ScriptTask4 {
			get {
				return _scriptTask4 ?? (_scriptTask4 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4",
					SchemaElementUId = new Guid("0887721e-8742-4ce5-b693-1229d45bc238"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask4Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[CurrencySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { CurrencySaving };
			FlowElements[ScriptTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3 };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[StartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage2 };
			FlowElements[ScriptTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3":
						break;
					case "CurrencySaving":
						e.Context.QueueTasks.Enqueue("ScriptTask3");
						break;
					case "ScriptTask3":
						break;
					case "EventSubProcess4":
						break;
					case "StartMessage2":
						e.Context.QueueTasks.Enqueue("ScriptTask4");
						break;
					case "ScriptTask4":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CurrencySaving");
			ActivatedEventElements.Add("StartMessage2");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "CurrencySaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "CurrencySaving";
					result = CurrencySaving.Execute(context);
					break;
				case "ScriptTask3":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3";
					result = ScriptTask3.Execute(context, ScriptTask3Execute);
					break;
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage2";
					result = StartMessage2.Execute(context);
					break;
				case "ScriptTask4":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask4";
					result = ScriptTask4.Execute(context, ScriptTask4Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3Execute(ProcessExecutingContext context) {
			OnCurrencySavingHandler();
			return true;
		}

		public virtual bool ScriptTask4Execute(ProcessExecutingContext context) {
			OnCurrencySavedHandler();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Currency_UIv2_BPMSoftSaving":
							if (ActivatedEventElements.Contains("CurrencySaving")) {
							context.QueueTasks.Enqueue("CurrencySaving");
						}
						break;
					case "Currency_UIv2_BPMSoftSaved":
							if (ActivatedEventElements.Contains("StartMessage2")) {
							context.QueueTasks.Enqueue("StartMessage2");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Currency_UIv2EventsProcess

	/// <exclude/>
	public class Currency_UIv2EventsProcess : Currency_UIv2EventsProcess<Currency_UIv2_BPMSoft>
	{

		public Currency_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

