namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwProcessDashboard_ActionsDashboard_BPMSoftSchema

	/// <exclude/>
	public class VwProcessDashboard_ActionsDashboard_BPMSoftSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwProcessDashboard_ActionsDashboard_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessDashboard_ActionsDashboard_BPMSoftSchema(VwProcessDashboard_ActionsDashboard_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessDashboard_ActionsDashboard_BPMSoftSchema(VwProcessDashboard_ActionsDashboard_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085");
			RealUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085");
			Name = "VwProcessDashboard_ActionsDashboard_BPMSoft";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f7f3371d-3442-40e8-84ca-d9c2f37e41cf")) == null) {
				Columns.Add(CreateProcessElementColumn());
			}
			if (Columns.FindByUId(new Guid("cf4bf9f4-8ac1-4d6b-95e0-25eedcaa5c05")) == null) {
				Columns.Add(CreateProcessDataColumn());
			}
			if (Columns.FindByUId(new Guid("6ee49b37-00b3-4940-88c3-e3df4d7888bc")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("65fb81f6-c83f-424f-be6d-dadc1ee7c1c1")) == null) {
				Columns.Add(CreateProcessNameColumn());
			}
			if (Columns.FindByUId(new Guid("7baa874f-9839-4eb2-aace-b0b627b7f833")) == null) {
				Columns.Add(CreateElementCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("76d716cb-b632-42a4-bf97-ac3b75533431")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("64a5b76a-24ba-4ba8-aee0-d44eff8c182f")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("0134e51e-7061-45ed-9e7d-e5a1a45d0e7d")) == null) {
				Columns.Add(CreateProcessElementEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("6bac1f40-4c25-4c60-8b85-8df9a2713ba7")) == null) {
				Columns.Add(CreateProcessElementEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("9e239a34-ae34-4ff8-af4c-8c4144a8f382")) == null) {
				Columns.Add(CreateProcessElementSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f7096cca-92da-45ff-98ba-43acb394db93")) == null) {
				Columns.Add(CreateCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("c796a73d-17b2-433d-bb33-86b337ba5907")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("7950eb41-b9d8-4290-b804-4963eee5d1a4")) == null) {
				Columns.Add(CreateElementOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("9d55cbd4-17b6-4838-9dd0-a14a0d3c34c3")) == null) {
				Columns.Add(CreateProcessOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("b567f361-5f18-4ed6-8c0d-65be2acd3bd8")) == null) {
				Columns.Add(CreateProcessSchemaElementUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("387f81b2-4ba1-49e0-b1c5-c0ac200fc5d8"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7f3371d-3442-40e8-84ca-d9c2f37e41cf"),
				Name = @"ProcessElement",
				ReferenceSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf4bf9f4-8ac1-4d6b-95e0-25eedcaa5c05"),
				Name = @"ProcessData",
				ReferenceSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("6ee49b37-00b3-4940-88c3-e3df4d7888bc"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("65fb81f6-c83f-424f-be6d-dadc1ee7c1c1"),
				Name = @"ProcessName",
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateElementCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7baa874f-9839-4eb2-aace-b0b627b7f833"),
				Name = @"ElementCaption",
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("76d716cb-b632-42a4-bf97-ac3b75533431"),
				Name = @"EntitySchemaUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("64a5b76a-24ba-4ba8-aee0-d44eff8c182f"),
				Name = @"EntityId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0134e51e-7061-45ed-9e7d-e5a1a45d0e7d"),
				Name = @"ProcessElementEntitySchemaUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6bac1f40-4c25-4c60-8b85-8df9a2713ba7"),
				Name = @"ProcessElementEntityId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9e239a34-ae34-4ff8-af4c-8c4144a8f382"),
				Name = @"ProcessElementSchemaUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f7096cca-92da-45ff-98ba-43acb394db93"),
				Name = @"CreatedOn",
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c796a73d-17b2-433d-bb33-86b337ba5907"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateElementOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7950eb41-b9d8-4290-b804-4963eee5d1a4"),
				Name = @"ElementOwner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9d55cbd4-17b6-4838-9dd0-a14a0d3c34c3"),
				Name = @"ProcessOwner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("2c9213ec-f319-46ab-8cbf-ebd1dc87fafa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b567f361-5f18-4ed6-8c0d-65be2acd3bd8"),
				Name = @"ProcessSchemaElementUId",
				CreatedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				ModifiedInSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"),
				CreatedInPackageId = new Guid("42566264-4d45-45d2-b4a3-2663530244b3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessDashboard_ActionsDashboard_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessDashboard_ActionsDashboardEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessDashboard_ActionsDashboard_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessDashboard_ActionsDashboard_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessDashboard_ActionsDashboard_BPMSoft

	/// <summary>
	/// The process dashboard.
	/// </summary>
	public class VwProcessDashboard_ActionsDashboard_BPMSoft : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProcessDashboard_ActionsDashboard_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessDashboard_ActionsDashboard_BPMSoft";
		}

		public VwProcessDashboard_ActionsDashboard_BPMSoft(VwProcessDashboard_ActionsDashboard_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// Process element.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = LookupColumnEntities.GetEntity("ProcessElement") as SysProcessElementData);
			}
		}

		/// <exclude/>
		public Guid ProcessDataId {
			get {
				return GetTypedColumnValue<Guid>("ProcessDataId");
			}
			set {
				SetColumnValue("ProcessDataId", value);
				_processData = null;
			}
		}

		private SysProcessData _processData;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessData ProcessData {
			get {
				return _processData ??
					(_processData = LookupColumnEntities.GetEntity("ProcessData") as SysProcessData);
			}
		}

		/// <summary>
		/// ModifiedOn.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Process name.
		/// </summary>
		public string ProcessName {
			get {
				return GetTypedColumnValue<string>("ProcessName");
			}
			set {
				SetColumnValue("ProcessName", value);
			}
		}

		/// <summary>
		/// Element caption.
		/// </summary>
		public string ElementCaption {
			get {
				return GetTypedColumnValue<string>("ElementCaption");
			}
			set {
				SetColumnValue("ElementCaption", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

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

		/// <summary>
		/// ProcessElementEntitySchemaUId.
		/// </summary>
		public Guid ProcessElementEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementEntitySchemaUId");
			}
			set {
				SetColumnValue("ProcessElementEntitySchemaUId", value);
			}
		}

		/// <summary>
		/// ProcessElementEntityId.
		/// </summary>
		public Guid ProcessElementEntityId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementEntityId");
			}
			set {
				SetColumnValue("ProcessElementEntityId", value);
			}
		}

		/// <summary>
		/// ProcessElementSchemaUId.
		/// </summary>
		public Guid ProcessElementSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementSchemaUId");
			}
			set {
				SetColumnValue("ProcessElementSchemaUId", value);
			}
		}

		/// <summary>
		/// CreatedOn.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
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
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid ElementOwnerId {
			get {
				return GetTypedColumnValue<Guid>("ElementOwnerId");
			}
			set {
				SetColumnValue("ElementOwnerId", value);
				_elementOwner = null;
			}
		}

		/// <exclude/>
		public string ElementOwnerName {
			get {
				return GetTypedColumnValue<string>("ElementOwnerName");
			}
			set {
				SetColumnValue("ElementOwnerName", value);
				if (_elementOwner != null) {
					_elementOwner.Name = value;
				}
			}
		}

		private Contact _elementOwner;
		/// <summary>
		/// Element owner.
		/// </summary>
		public Contact ElementOwner {
			get {
				return _elementOwner ??
					(_elementOwner = LookupColumnEntities.GetEntity("ElementOwner") as Contact);
			}
		}

		/// <exclude/>
		public Guid ProcessOwnerId {
			get {
				return GetTypedColumnValue<Guid>("ProcessOwnerId");
			}
			set {
				SetColumnValue("ProcessOwnerId", value);
				_processOwner = null;
			}
		}

		/// <exclude/>
		public string ProcessOwnerName {
			get {
				return GetTypedColumnValue<string>("ProcessOwnerName");
			}
			set {
				SetColumnValue("ProcessOwnerName", value);
				if (_processOwner != null) {
					_processOwner.Name = value;
				}
			}
		}

		private Contact _processOwner;
		/// <summary>
		/// Process owner.
		/// </summary>
		public Contact ProcessOwner {
			get {
				return _processOwner ??
					(_processOwner = LookupColumnEntities.GetEntity("ProcessOwner") as Contact);
			}
		}

		/// <summary>
		/// Process schema element identifier.
		/// </summary>
		public Guid ProcessSchemaElementUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaElementUId");
			}
			set {
				SetColumnValue("ProcessSchemaElementUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessDashboard_ActionsDashboardEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessDashboard_ActionsDashboard_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessDashboard_ActionsDashboardEventsProcess

	/// <exclude/>
	public partial class VwProcessDashboard_ActionsDashboardEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwProcessDashboard_ActionsDashboard_BPMSoft
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwProcessDashboard_ActionsDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessDashboard_ActionsDashboardEventsProcess";
			SchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085");
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

	#region Class: VwProcessDashboard_ActionsDashboardEventsProcess

	/// <exclude/>
	public class VwProcessDashboard_ActionsDashboardEventsProcess : VwProcessDashboard_ActionsDashboardEventsProcess<VwProcessDashboard_ActionsDashboard_BPMSoft>
	{

		public VwProcessDashboard_ActionsDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessDashboard_ActionsDashboardEventsProcess

	public partial class VwProcessDashboard_ActionsDashboardEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

