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

	#region Class: ChartPropertySchema

	/// <exclude/>
	public class ChartPropertySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChartPropertySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChartPropertySchema(ChartPropertySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChartPropertySchema(ChartPropertySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			RealUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			Name = "ChartProperty";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("16ad592f-9c14-4edd-87c4-65eb59564fd3")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("dd90d17d-f735-4191-9783-74720cdbd816")) == null) {
				Columns.Add(CreateChartAggregationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f13f4d9b-0463-493e-9a8b-67ba02c960b5")) == null) {
				Columns.Add(CreateChartEntityColumnColumn());
			}
			if (Columns.FindByUId(new Guid("9ab76bfc-de7a-403d-a3a5-5babd8f8f4d6")) == null) {
				Columns.Add(CreateGroupByFieldColumn());
			}
			if (Columns.FindByUId(new Guid("fbc6b8ae-1adb-464f-abb2-24072e86068c")) == null) {
				Columns.Add(CreateXAxisCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("f42b116e-b9a0-4bcd-88dc-1a07a0800901")) == null) {
				Columns.Add(CreateYAxisCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("4bc38758-6980-4a92-b5a1-16f045996237")) == null) {
				Columns.Add(CreateFilterColumn());
			}
			if (Columns.FindByUId(new Guid("d3a6ecf3-16ec-482f-ab76-ee95c329fdce")) == null) {
				Columns.Add(CreateOrderDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("6e2daddb-e9a2-4433-b35d-07ee0de0b71d")) == null) {
				Columns.Add(CreateOrderByChartPropertyColumnColumn());
			}
			if (Columns.FindByUId(new Guid("eb5d1c87-4434-4940-8fd6-c640c4b5f99a")) == null) {
				Columns.Add(CreateModuleObjAccessFieldColumn());
			}
			if (Columns.FindByUId(new Guid("37fc2cf9-c2cd-48e0-b258-2fa504d475d7")) == null) {
				Columns.Add(CreateChartSeriesKindColumn());
			}
			if (Columns.FindByUId(new Guid("c0da6e4d-11b3-4a2c-975f-fb8a1c16a21e")) == null) {
				Columns.Add(CreateGroupByTypeDateTimeColumn());
			}
			if (Columns.FindByUId(new Guid("69a2ad03-f043-4d85-8464-950e113168a5")) == null) {
				Columns.Add(CreateModuleEntityIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("16ad592f-9c14-4edd-87c4-65eb59564fd3"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateChartAggregationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dd90d17d-f735-4191-9783-74720cdbd816"),
				Name = @"ChartAggregationType",
				ReferenceSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df"),
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateChartEntityColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("f13f4d9b-0463-493e-9a8b-67ba02c960b5"),
				Name = @"ChartEntityColumn",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupByFieldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("9ab76bfc-de7a-403d-a3a5-5babd8f8f4d6"),
				Name = @"GroupByField",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateXAxisCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fbc6b8ae-1adb-464f-abb2-24072e86068c"),
				Name = @"XAxisCaption",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateYAxisCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f42b116e-b9a0-4bcd-88dc-1a07a0800901"),
				Name = @"YAxisCaption",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("4bc38758-6980-4a92-b5a1-16f045996237"),
				Name = @"Filter",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d3a6ecf3-16ec-482f-ab76-ee95c329fdce"),
				Name = @"OrderDirection",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderByChartPropertyColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6e2daddb-e9a2-4433-b35d-07ee0de0b71d"),
				Name = @"OrderByChartPropertyColumn",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleObjAccessFieldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("eb5d1c87-4434-4940-8fd6-c640c4b5f99a"),
				Name = @"ModuleObjAccessField",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateChartSeriesKindColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("37fc2cf9-c2cd-48e0-b258-2fa504d475d7"),
				Name = @"ChartSeriesKind",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupByTypeDateTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c0da6e4d-11b3-4a2c-975f-fb8a1c16a21e"),
				Name = @"GroupByTypeDateTime",
				ReferenceSchemaUId = new Guid("b79d04ab-29c1-408e-94bb-83a20081c02e"),
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("69a2ad03-f043-4d85-8464-950e113168a5"),
				Name = @"ModuleEntityId",
				CreatedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				ModifiedInSchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChartProperty(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChartProperty_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChartPropertySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChartPropertySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22"));
		}

		#endregion

	}

	#endregion

	#region Class: ChartProperty

	/// <summary>
	/// Chart.
	/// </summary>
	public class ChartProperty : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChartProperty(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChartProperty";
		}

		public ChartProperty(ChartProperty source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <exclude/>
		public Guid ChartAggregationTypeId {
			get {
				return GetTypedColumnValue<Guid>("ChartAggregationTypeId");
			}
			set {
				SetColumnValue("ChartAggregationTypeId", value);
				_chartAggregationType = null;
			}
		}

		/// <exclude/>
		public string ChartAggregationTypeName {
			get {
				return GetTypedColumnValue<string>("ChartAggregationTypeName");
			}
			set {
				SetColumnValue("ChartAggregationTypeName", value);
				if (_chartAggregationType != null) {
					_chartAggregationType.Name = value;
				}
			}
		}

		private ChartAggregationType _chartAggregationType;
		/// <summary>
		/// Display on lookup.
		/// </summary>
		public ChartAggregationType ChartAggregationType {
			get {
				return _chartAggregationType ??
					(_chartAggregationType = LookupColumnEntities.GetEntity("ChartAggregationType") as ChartAggregationType);
			}
		}

		/// <summary>
		/// X-axis label.
		/// </summary>
		public string XAxisCaption {
			get {
				return GetTypedColumnValue<string>("XAxisCaption");
			}
			set {
				SetColumnValue("XAxisCaption", value);
			}
		}

		/// <summary>
		/// Y-axis label.
		/// </summary>
		public string YAxisCaption {
			get {
				return GetTypedColumnValue<string>("YAxisCaption");
			}
			set {
				SetColumnValue("YAxisCaption", value);
			}
		}

		/// <summary>
		/// Sorting type.
		/// </summary>
		public string OrderDirection {
			get {
				return GetTypedColumnValue<string>("OrderDirection");
			}
			set {
				SetColumnValue("OrderDirection", value);
			}
		}

		/// <summary>
		/// Sort by column value.
		/// </summary>
		public string OrderByChartPropertyColumn {
			get {
				return GetTypedColumnValue<string>("OrderByChartPropertyColumn");
			}
			set {
				SetColumnValue("OrderByChartPropertyColumn", value);
			}
		}

		/// <summary>
		/// Chart type.
		/// </summary>
		public string ChartSeriesKind {
			get {
				return GetTypedColumnValue<string>("ChartSeriesKind");
			}
			set {
				SetColumnValue("ChartSeriesKind", value);
			}
		}

		/// <exclude/>
		public Guid GroupByTypeDateTimeId {
			get {
				return GetTypedColumnValue<Guid>("GroupByTypeDateTimeId");
			}
			set {
				SetColumnValue("GroupByTypeDateTimeId", value);
				_groupByTypeDateTime = null;
			}
		}

		/// <exclude/>
		public string GroupByTypeDateTimeName {
			get {
				return GetTypedColumnValue<string>("GroupByTypeDateTimeName");
			}
			set {
				SetColumnValue("GroupByTypeDateTimeName", value);
				if (_groupByTypeDateTime != null) {
					_groupByTypeDateTime.Name = value;
				}
			}
		}

		private GroupByTypeDateTime _groupByTypeDateTime;
		/// <summary>
		/// Dates grouping type.
		/// </summary>
		public GroupByTypeDateTime GroupByTypeDateTime {
			get {
				return _groupByTypeDateTime ??
					(_groupByTypeDateTime = LookupColumnEntities.GetEntity("GroupByTypeDateTime") as GroupByTypeDateTime);
			}
		}

		/// <summary>
		/// ModuleEntityId.
		/// </summary>
		public Guid ModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("ModuleEntityId");
			}
			set {
				SetColumnValue("ModuleEntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChartProperty_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChartPropertyDeleted", e);
			Deleting += (s, e) => ThrowEvent("ChartPropertyDeleting", e);
			Inserted += (s, e) => ThrowEvent("ChartPropertyInserted", e);
			Inserting += (s, e) => ThrowEvent("ChartPropertyInserting", e);
			Saved += (s, e) => ThrowEvent("ChartPropertySaved", e);
			Saving += (s, e) => ThrowEvent("ChartPropertySaving", e);
			Validating += (s, e) => ThrowEvent("ChartPropertyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChartProperty(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChartProperty_BaseEventsProcess

	/// <exclude/>
	public partial class ChartProperty_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChartProperty
	{

		public ChartProperty_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChartProperty_BaseEventsProcess";
			SchemaUId = new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cfa2a0e4-8dcc-49ab-8c7a-267dba88aa22");
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

	#region Class: ChartProperty_BaseEventsProcess

	/// <exclude/>
	public class ChartProperty_BaseEventsProcess : ChartProperty_BaseEventsProcess<ChartProperty>
	{

		public ChartProperty_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChartProperty_BaseEventsProcess

	public partial class ChartProperty_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChartPropertyEventsProcess

	/// <exclude/>
	public class ChartPropertyEventsProcess : ChartProperty_BaseEventsProcess
	{

		public ChartPropertyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

