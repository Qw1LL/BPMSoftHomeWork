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

	#region Class: CompletenessParameterSchema

	/// <exclude/>
	public class CompletenessParameterSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CompletenessParameterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompletenessParameterSchema(CompletenessParameterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompletenessParameterSchema(CompletenessParameterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af");
			RealUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af");
			Name = "CompletenessParameter";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cd516d07-f502-4606-ac54-c721b5fd7f2d")) == null) {
				Columns.Add(CreateCompletenessColumn());
			}
			if (Columns.FindByUId(new Guid("e045700a-4d46-4394-bf48-9c044ae2d565")) == null) {
				Columns.Add(CreateAttributeIdColumn());
			}
			if (Columns.FindByUId(new Guid("0fe2a233-d221-4849-b2b0-c6a229dc58d0")) == null) {
				Columns.Add(CreatePercentageColumn());
			}
			if (Columns.FindByUId(new Guid("0029abe7-0fe0-4eaa-aae4-bb9b84fc0e0e")) == null) {
				Columns.Add(CreateIsColumnColumn());
			}
			if (Columns.FindByUId(new Guid("9e8282cb-eecd-48be-ad1c-8306e07ddf06")) == null) {
				Columns.Add(CreateIsDetailColumn());
			}
			if (Columns.FindByUId(new Guid("90b4a00c-7d86-4be9-95da-6ac1ecd7331c")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("d681fa67-895c-43cb-958a-79db23f0a56a")) == null) {
				Columns.Add(CreateDetailEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("93aca6cc-e550-49c8-ae3c-4a04f7c23b54")) == null) {
				Columns.Add(CreateDetailColumnColumn());
			}
			if (Columns.FindByUId(new Guid("22a62cf0-73bb-46d3-bf48-7a1196f8b8d0")) == null) {
				Columns.Add(CreateMasterColumnColumn());
			}
			if (Columns.FindByUId(new Guid("120f702e-9f04-4d90-adeb-4650888893a9")) == null) {
				Columns.Add(CreateTypeColumnColumn());
			}
			if (Columns.FindByUId(new Guid("1091fbaf-5122-40b1-b2f1-832f82969070")) == null) {
				Columns.Add(CreateTypeValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCompletenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cd516d07-f502-4606-ac54-c721b5fd7f2d"),
				Name = @"Completeness",
				ReferenceSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ce1827f9-db39-4ae9-bf8d-a389242bf4b7"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateAttributeIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e045700a-4d46-4394-bf48-9c044ae2d565"),
				Name = @"AttributeId",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreatePercentageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0fe2a233-d221-4849-b2b0-c6a229dc58d0"),
				Name = @"Percentage",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0029abe7-0fe0-4eaa-aae4-bb9b84fc0e0e"),
				Name = @"IsColumn",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDetailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9e8282cb-eecd-48be-ad1c-8306e07ddf06"),
				Name = @"IsDetail",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("90b4a00c-7d86-4be9-95da-6ac1ecd7331c"),
				Name = @"ColumnName",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected virtual EntitySchemaColumn CreateDetailEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d681fa67-895c-43cb-958a-79db23f0a56a"),
				Name = @"DetailEntityName",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected virtual EntitySchemaColumn CreateDetailColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("93aca6cc-e550-49c8-ae3c-4a04f7c23b54"),
				Name = @"DetailColumn",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateMasterColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("22a62cf0-73bb-46d3-bf48-7a1196f8b8d0"),
				Name = @"MasterColumn",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("120f702e-9f04-4d90-adeb-4650888893a9"),
				Name = @"TypeColumn",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1091fbaf-5122-40b1-b2f1-832f82969070"),
				Name = @"TypeValue",
				CreatedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				ModifiedInSchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CompletenessParameter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CompletenessParameter_CompletenessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompletenessParameterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompletenessParameterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af"));
		}

		#endregion

	}

	#endregion

	#region Class: CompletenessParameter

	/// <summary>
	/// Data entry compliance parameter.
	/// </summary>
	public class CompletenessParameter : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CompletenessParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompletenessParameter";
		}

		public CompletenessParameter(CompletenessParameter source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CompletenessId {
			get {
				return GetTypedColumnValue<Guid>("CompletenessId");
			}
			set {
				SetColumnValue("CompletenessId", value);
				_completeness = null;
			}
		}

		/// <exclude/>
		public string CompletenessName {
			get {
				return GetTypedColumnValue<string>("CompletenessName");
			}
			set {
				SetColumnValue("CompletenessName", value);
				if (_completeness != null) {
					_completeness.Name = value;
				}
			}
		}

		private Completeness _completeness;
		/// <summary>
		/// Data entry compliance.
		/// </summary>
		public Completeness Completeness {
			get {
				return _completeness ??
					(_completeness = LookupColumnEntities.GetEntity("Completeness") as Completeness);
			}
		}

		/// <summary>
		/// Attribute name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Attribute Id.
		/// </summary>
		public Guid AttributeId {
			get {
				return GetTypedColumnValue<Guid>("AttributeId");
			}
			set {
				SetColumnValue("AttributeId", value);
			}
		}

		/// <summary>
		/// Data population percentage, %.
		/// </summary>
		public int Percentage {
			get {
				return GetTypedColumnValue<int>("Percentage");
			}
			set {
				SetColumnValue("Percentage", value);
			}
		}

		/// <summary>
		/// Column usage option.
		/// </summary>
		public bool IsColumn {
			get {
				return GetTypedColumnValue<bool>("IsColumn");
			}
			set {
				SetColumnValue("IsColumn", value);
			}
		}

		/// <summary>
		/// Detail usage option.
		/// </summary>
		public bool IsDetail {
			get {
				return GetTypedColumnValue<bool>("IsDetail");
			}
			set {
				SetColumnValue("IsDetail", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Object column name.
		/// </summary>
		public string DetailEntityName {
			get {
				return GetTypedColumnValue<string>("DetailEntityName");
			}
			set {
				SetColumnValue("DetailEntityName", value);
			}
		}

		/// <summary>
		/// Detail column name.
		/// </summary>
		public string DetailColumn {
			get {
				return GetTypedColumnValue<string>("DetailColumn");
			}
			set {
				SetColumnValue("DetailColumn", value);
			}
		}

		/// <summary>
		/// Detail column wizard.
		/// </summary>
		public string MasterColumn {
			get {
				return GetTypedColumnValue<string>("MasterColumn");
			}
			set {
				SetColumnValue("MasterColumn", value);
			}
		}

		/// <summary>
		/// Column name with detail type.
		/// </summary>
		public string TypeColumn {
			get {
				return GetTypedColumnValue<string>("TypeColumn");
			}
			set {
				SetColumnValue("TypeColumn", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public Guid TypeValue {
			get {
				return GetTypedColumnValue<Guid>("TypeValue");
			}
			set {
				SetColumnValue("TypeValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CompletenessParameter_CompletenessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CompletenessParameterDeleted", e);
			Validating += (s, e) => ThrowEvent("CompletenessParameterValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CompletenessParameter(this);
		}

		#endregion

	}

	#endregion

	#region Class: CompletenessParameter_CompletenessEventsProcess

	/// <exclude/>
	public partial class CompletenessParameter_CompletenessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CompletenessParameter
	{

		public CompletenessParameter_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompletenessParameter_CompletenessEventsProcess";
			SchemaUId = new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f64722b-a049-4e96-a95e-53b7f2b054af");
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

	#region Class: CompletenessParameter_CompletenessEventsProcess

	/// <exclude/>
	public class CompletenessParameter_CompletenessEventsProcess : CompletenessParameter_CompletenessEventsProcess<CompletenessParameter>
	{

		public CompletenessParameter_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CompletenessParameter_CompletenessEventsProcess

	public partial class CompletenessParameter_CompletenessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CompletenessParameterEventsProcess

	/// <exclude/>
	public class CompletenessParameterEventsProcess : CompletenessParameter_CompletenessEventsProcess
	{

		public CompletenessParameterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

