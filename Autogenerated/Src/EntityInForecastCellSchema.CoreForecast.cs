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

	#region Class: EntityInForecastCellSchema

	/// <exclude/>
	[IsVirtual]
	public class EntityInForecastCellSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntityInForecastCellSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntityInForecastCellSchema(EntityInForecastCellSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntityInForecastCellSchema(EntityInForecastCellSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			RealUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			Name = "EntityInForecastCell";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateRowColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("13a9c898-7ab7-4784-9ba0-607934f8868a")) == null) {
				Columns.Add(CreatePeriodColumn());
			}
			if (Columns.FindByUId(new Guid("c74827b5-2f09-40cb-9461-d327016a4dc1")) == null) {
				Columns.Add(CreateSheetColumn());
			}
			if (Columns.FindByUId(new Guid("154f4031-1e3d-40fb-b9bb-6105f0bd369b")) == null) {
				Columns.Add(CreateIndicatorColumn());
			}
			if (Columns.FindByUId(new Guid("0a3fb99b-1aff-4b2f-a21a-4a00e81891ca")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("bc25e330-e553-424f-9893-395bd4905e23")) == null) {
				Columns.Add(CreatePrimaryAmountColumn());
			}
			if (Columns.FindByUId(new Guid("86994e3d-15be-4347-b059-33142ce79636")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("21795fb2-399d-4456-9678-1a2703ea8b74")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("4f7afe87-8872-46c7-bd31-d6a74ec15319")) == null) {
				Columns.Add(CreateForecastColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("13a9c898-7ab7-4784-9ba0-607934f8868a"),
				Name = @"Period",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSheetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c74827b5-2f09-40cb-9461-d327016a4dc1"),
				Name = @"Sheet",
				ReferenceSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateIndicatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("154f4031-1e3d-40fb-b9bb-6105f0bd369b"),
				Name = @"Indicator",
				ReferenceSchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("0a3fb99b-1aff-4b2f-a21a-4a00e81891ca"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("bc25e330-e553-424f-9893-395bd4905e23"),
				Name = @"PrimaryAmount",
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("86994e3d-15be-4347-b059-33142ce79636"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("21795fb2-399d-4456-9678-1a2703ea8b74"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateRowColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3d9e1aa4-a486-4d06-ba84-1541c00327d5"),
				Name = @"Row",
				ReferenceSchemaUId = new Guid("01fb1058-f049-48ab-96fb-cbe5989efe01"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4f7afe87-8872-46c7-bd31-d6a74ec15319"),
				Name = @"ForecastColumn",
				ReferenceSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				ModifiedInSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntityInForecastCell(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntityInForecastCell_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntityInForecastCellSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntityInForecastCellSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7"));
		}

		#endregion

	}

	#endregion

	#region Class: EntityInForecastCell

	/// <summary>
	/// Базовый объект ячейки планирования.
	/// </summary>
	public class EntityInForecastCell : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntityInForecastCell(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityInForecastCell";
		}

		public EntityInForecastCell(EntityInForecastCell source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PeriodId {
			get {
				return GetTypedColumnValue<Guid>("PeriodId");
			}
			set {
				SetColumnValue("PeriodId", value);
				_period = null;
			}
		}

		/// <exclude/>
		public string PeriodName {
			get {
				return GetTypedColumnValue<string>("PeriodName");
			}
			set {
				SetColumnValue("PeriodName", value);
				if (_period != null) {
					_period.Name = value;
				}
			}
		}

		private Period _period;
		/// <summary>
		/// Период.
		/// </summary>
		public Period Period {
			get {
				return _period ??
					(_period = LookupColumnEntities.GetEntity("Period") as Period);
			}
		}

		/// <exclude/>
		public Guid SheetId {
			get {
				return GetTypedColumnValue<Guid>("SheetId");
			}
			set {
				SetColumnValue("SheetId", value);
				_sheet = null;
			}
		}

		/// <exclude/>
		public string SheetName {
			get {
				return GetTypedColumnValue<string>("SheetName");
			}
			set {
				SetColumnValue("SheetName", value);
				if (_sheet != null) {
					_sheet.Name = value;
				}
			}
		}

		private ForecastSheet _sheet;
		/// <summary>
		/// Лист планирования.
		/// </summary>
		public ForecastSheet Sheet {
			get {
				return _sheet ??
					(_sheet = LookupColumnEntities.GetEntity("Sheet") as ForecastSheet);
			}
		}

		/// <exclude/>
		public Guid IndicatorId {
			get {
				return GetTypedColumnValue<Guid>("IndicatorId");
			}
			set {
				SetColumnValue("IndicatorId", value);
				_indicator = null;
			}
		}

		/// <exclude/>
		public string IndicatorName {
			get {
				return GetTypedColumnValue<string>("IndicatorName");
			}
			set {
				SetColumnValue("IndicatorName", value);
				if (_indicator != null) {
					_indicator.Name = value;
				}
			}
		}

		private ForecastIndicator _indicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator Indicator {
			get {
				return _indicator ??
					(_indicator = LookupColumnEntities.GetEntity("Indicator") as ForecastIndicator);
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

		/// <summary>
		/// Сумма в б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
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
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public Decimal Value {
			get {
				return GetTypedColumnValue<Decimal>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid RowId {
			get {
				return GetTypedColumnValue<Guid>("RowId");
			}
			set {
				SetColumnValue("RowId", value);
				_row = null;
			}
		}

		private ForecastRow _row;
		/// <summary>
		/// Строка.
		/// </summary>
		public ForecastRow Row {
			get {
				return _row ??
					(_row = LookupColumnEntities.GetEntity("Row") as ForecastRow);
			}
		}

		/// <exclude/>
		public Guid ForecastColumnId {
			get {
				return GetTypedColumnValue<Guid>("ForecastColumnId");
			}
			set {
				SetColumnValue("ForecastColumnId", value);
				_forecastColumn = null;
			}
		}

		/// <exclude/>
		public string ForecastColumnTitle {
			get {
				return GetTypedColumnValue<string>("ForecastColumnTitle");
			}
			set {
				SetColumnValue("ForecastColumnTitle", value);
				if (_forecastColumn != null) {
					_forecastColumn.Title = value;
				}
			}
		}

		private ForecastColumn _forecastColumn;
		/// <summary>
		/// Колонка планирования.
		/// </summary>
		public ForecastColumn ForecastColumn {
			get {
				return _forecastColumn ??
					(_forecastColumn = LookupColumnEntities.GetEntity("ForecastColumn") as ForecastColumn);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntityInForecastCell_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("EntityInForecastCellInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntityInForecastCell(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntityInForecastCell_CoreForecastEventsProcess

	/// <exclude/>
	public partial class EntityInForecastCell_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EntityInForecastCell
	{

		public EntityInForecastCell_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntityInForecastCell_CoreForecastEventsProcess";
			SchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _begoreInsertingSubProcess;
		public ProcessFlowElement BegoreInsertingSubProcess {
			get {
				return _begoreInsertingSubProcess ?? (_begoreInsertingSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BegoreInsertingSubProcess",
					SchemaElementUId = new Guid("e76578f2-02c9-4bc7-96dc-1545c51fbc14"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f;
		public ProcessFlowElement StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f {
			get {
				return _startMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f ?? (_startMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f",
					SchemaElementUId = new Guid("5f1d8c94-b8a8-4f12-b0fa-9200276f8f0f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8;
		public ProcessScriptTask ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8 {
			get {
				return _scriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8 ?? (_scriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8",
					SchemaElementUId = new Guid("b1b245f1-3a7c-49c6-a282-45ecb0dccaf8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BegoreInsertingSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BegoreInsertingSubProcess };
			FlowElements[StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f };
			FlowElements[ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BegoreInsertingSubProcess":
						break;
					case "StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f":
						e.Context.QueueTasks.Enqueue("ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8");
						break;
					case "ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BegoreInsertingSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f";
					result = StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f.Execute(context);
					break;
				case "ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8";
					result = ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8.Execute(context, ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_b1b245f13a7c49c6a28245ecb0dccaf8Execute(ProcessExecutingContext context) {
			SetForecastRow();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EntityInForecastCellInserting":
							if (ActivatedEventElements.Contains("StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f")) {
							context.QueueTasks.Enqueue("StartMessage3_5f1d8c94b8a84f12b0fa9200276f8f0f");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EntityInForecastCell_CoreForecastEventsProcess

	/// <exclude/>
	public class EntityInForecastCell_CoreForecastEventsProcess : EntityInForecastCell_CoreForecastEventsProcess<EntityInForecastCell>
	{

		public EntityInForecastCell_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: EntityInForecastCellEventsProcess

	/// <exclude/>
	public class EntityInForecastCellEventsProcess : EntityInForecastCell_CoreForecastEventsProcess
	{

		public EntityInForecastCellEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

