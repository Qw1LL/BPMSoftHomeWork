namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: PartnershipParameter_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class PartnershipParameter_PRMBase_BPMSoftSchema : BPMSoft.Configuration.SpecificationInObjectSchema
	{

		#region Constructors: Public

		public PartnershipParameter_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipParameter_PRMBase_BPMSoftSchema(PartnershipParameter_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipParameter_PRMBase_BPMSoftSchema(PartnershipParameter_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			RealUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			Name = "PartnershipParameter_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			ExtendParent = false;
			CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
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
			if (Columns.FindByUId(new Guid("a8b3d081-45a1-4cd1-aa0f-b129c1104cab")) == null) {
				Columns.Add(CreatePartnerParamCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("6798596b-f967-4e78-a1e3-72d6c773937c")) == null) {
				Columns.Add(CreateScoreColumn());
			}
			if (Columns.FindByUId(new Guid("f864e780-a6a7-4362-be29-4a6ff91ff769")) == null) {
				Columns.Add(CreatePartnershipParameterTypeColumn());
			}
			if (Columns.FindByUId(new Guid("ee91e889-b5bd-4e7a-9773-3dccf95db043")) == null) {
				Columns.Add(CreateParameterTypeColumn());
			}
			if (Columns.FindByUId(new Guid("becc053f-4689-4c9f-a734-d50a7b7918e1")) == null) {
				Columns.Add(CreatePartnerLevelColumn());
			}
			if (Columns.FindByUId(new Guid("fe29d48b-7375-4d8d-92fe-398d8d3e749e")) == null) {
				Columns.Add(CreateParameterValueTypeColumn());
			}
			if (Columns.FindByUId(new Guid("08549aac-10a6-4502-8f99-3a7371534355")) == null) {
				Columns.Add(CreateCurrentValueColumn());
			}
			if (Columns.FindByUId(new Guid("dd554807-4b43-4424-a13e-4d82d1e1c65c")) == null) {
				Columns.Add(CreateGuidValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateFloatValueColumn() {
			EntitySchemaColumn column = base.CreateFloatValueColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("Float3");
			column.ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			return column;
		}

		protected override EntitySchemaColumn CreateSpecificationColumn() {
			EntitySchemaColumn column = base.CreateSpecificationColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePartnerParamCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a8b3d081-45a1-4cd1-aa0f-b129c1104cab"),
				Name = @"PartnerParamCategory",
				ReferenceSchemaUId = new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6798596b-f967-4e78-a1e3-72d6c773937c"),
				Name = @"Score",
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("edf932a5-9b80-4be1-9f8c-17ff782e83c9"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnershipParameterTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f864e780-a6a7-4362-be29-4a6ff91ff769"),
				Name = @"PartnershipParameterType",
				ReferenceSchemaUId = new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateParameterTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ee91e889-b5bd-4e7a-9773-3dccf95db043"),
				Name = @"ParameterType",
				ReferenceSchemaUId = new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("becc053f-4689-4c9f-a734-d50a7b7918e1"),
				Name = @"PartnerLevel",
				ReferenceSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateParameterValueTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fe29d48b-7375-4d8d-92fe-398d8d3e749e"),
				Name = @"ParameterValueType",
				ReferenceSchemaUId = new Guid("787ae6a1-f727-4c4e-964a-c09e24083810"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("08549aac-10a6-4502-8f99-3a7371534355"),
				Name = @"CurrentValue",
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateGuidValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dd554807-4b43-4424-a13e-4d82d1e1c65c"),
				Name = @"GuidValue",
				CreatedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				ModifiedInSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"),
				CreatedInPackageId = new Guid("6f0ddd54-2f1a-468d-afb8-9805de4678f7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnershipParameter_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipParameter_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipParameter_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipParameter_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParameter_PRMBase_BPMSoft

	/// <summary>
	/// PartnershipParameter.
	/// </summary>
	public class PartnershipParameter_PRMBase_BPMSoft : BPMSoft.Configuration.SpecificationInObject
	{

		#region Constructors: Public

		public PartnershipParameter_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipParameter_PRMBase_BPMSoft";
		}

		public PartnershipParameter_PRMBase_BPMSoft(PartnershipParameter_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PartnerParamCategoryId {
			get {
				return GetTypedColumnValue<Guid>("PartnerParamCategoryId");
			}
			set {
				SetColumnValue("PartnerParamCategoryId", value);
				_partnerParamCategory = null;
			}
		}

		/// <exclude/>
		public string PartnerParamCategoryName {
			get {
				return GetTypedColumnValue<string>("PartnerParamCategoryName");
			}
			set {
				SetColumnValue("PartnerParamCategoryName", value);
				if (_partnerParamCategory != null) {
					_partnerParamCategory.Name = value;
				}
			}
		}

		private PartnerParamCategory _partnerParamCategory;
		/// <summary>
		/// Параметр.
		/// </summary>
		public PartnerParamCategory PartnerParamCategory {
			get {
				return _partnerParamCategory ??
					(_partnerParamCategory = LookupColumnEntities.GetEntity("PartnerParamCategory") as PartnerParamCategory);
			}
		}

		/// <summary>
		/// Балл.
		/// </summary>
		public int Score {
			get {
				return GetTypedColumnValue<int>("Score");
			}
			set {
				SetColumnValue("Score", value);
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

		/// <exclude/>
		public Guid PartnershipParameterTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipParameterTypeId");
			}
			set {
				SetColumnValue("PartnershipParameterTypeId", value);
				_partnershipParameterType = null;
			}
		}

		/// <exclude/>
		public string PartnershipParameterTypeName {
			get {
				return GetTypedColumnValue<string>("PartnershipParameterTypeName");
			}
			set {
				SetColumnValue("PartnershipParameterTypeName", value);
				if (_partnershipParameterType != null) {
					_partnershipParameterType.Name = value;
				}
			}
		}

		private PartnershipParamType _partnershipParameterType;
		/// <summary>
		/// Тип.
		/// </summary>
		public PartnershipParamType PartnershipParameterType {
			get {
				return _partnershipParameterType ??
					(_partnershipParameterType = LookupColumnEntities.GetEntity("PartnershipParameterType") as PartnershipParamType);
			}
		}

		/// <exclude/>
		public Guid ParameterTypeId {
			get {
				return GetTypedColumnValue<Guid>("ParameterTypeId");
			}
			set {
				SetColumnValue("ParameterTypeId", value);
				_parameterType = null;
			}
		}

		/// <exclude/>
		public string ParameterTypeName {
			get {
				return GetTypedColumnValue<string>("ParameterTypeName");
			}
			set {
				SetColumnValue("ParameterTypeName", value);
				if (_parameterType != null) {
					_parameterType.Name = value;
				}
			}
		}

		private ParameterType _parameterType;
		/// <summary>
		/// Вид.
		/// </summary>
		public ParameterType ParameterType {
			get {
				return _parameterType ??
					(_parameterType = LookupColumnEntities.GetEntity("ParameterType") as ParameterType);
			}
		}

		/// <exclude/>
		public Guid PartnerLevelId {
			get {
				return GetTypedColumnValue<Guid>("PartnerLevelId");
			}
			set {
				SetColumnValue("PartnerLevelId", value);
				_partnerLevel = null;
			}
		}

		/// <exclude/>
		public string PartnerLevelName {
			get {
				return GetTypedColumnValue<string>("PartnerLevelName");
			}
			set {
				SetColumnValue("PartnerLevelName", value);
				if (_partnerLevel != null) {
					_partnerLevel.Name = value;
				}
			}
		}

		private PartnerLevel _partnerLevel;
		/// <summary>
		/// Уровень партнера.
		/// </summary>
		public PartnerLevel PartnerLevel {
			get {
				return _partnerLevel ??
					(_partnerLevel = LookupColumnEntities.GetEntity("PartnerLevel") as PartnerLevel);
			}
		}

		/// <exclude/>
		public Guid ParameterValueTypeId {
			get {
				return GetTypedColumnValue<Guid>("ParameterValueTypeId");
			}
			set {
				SetColumnValue("ParameterValueTypeId", value);
				_parameterValueType = null;
			}
		}

		/// <exclude/>
		public string ParameterValueTypeName {
			get {
				return GetTypedColumnValue<string>("ParameterValueTypeName");
			}
			set {
				SetColumnValue("ParameterValueTypeName", value);
				if (_parameterValueType != null) {
					_parameterValueType.Name = value;
				}
			}
		}

		private SpecificationType _parameterValueType;
		/// <summary>
		/// Тип значения параметра.
		/// </summary>
		public SpecificationType ParameterValueType {
			get {
				return _parameterValueType ??
					(_parameterValueType = LookupColumnEntities.GetEntity("ParameterValueType") as SpecificationType);
			}
		}

		/// <summary>
		/// Текущее значение.
		/// </summary>
		public string CurrentValue {
			get {
				return GetTypedColumnValue<string>("CurrentValue");
			}
			set {
				SetColumnValue("CurrentValue", value);
			}
		}

		/// <summary>
		/// Значение (GUID).
		/// </summary>
		public Guid GuidValue {
			get {
				return GetTypedColumnValue<Guid>("GuidValue");
			}
			set {
				SetColumnValue("GuidValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipParameter_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftInserted", e);
			Saved += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("PartnershipParameter_PRMBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnershipParameter_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParameter_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnershipParameter_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.SpecificationInObject_SpecificationEventsProcess<TEntity> where TEntity : PartnershipParameter_PRMBase_BPMSoft
	{

		public PartnershipParameter_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipParameter_PRMBaseEventsProcess";
			SchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _partnershipParameterInsertedEventSubProcess;
		public ProcessFlowElement PartnershipParameterInsertedEventSubProcess {
			get {
				return _partnershipParameterInsertedEventSubProcess ?? (_partnershipParameterInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PartnershipParameterInsertedEventSubProcess",
					SchemaElementUId = new Guid("58b2f32b-e174-4f81-8e17-e35ee3d4bfb6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterInsertedStartMessage;
		public ProcessFlowElement PartnershipParameterInsertedStartMessage {
			get {
				return _partnershipParameterInsertedStartMessage ?? (_partnershipParameterInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PartnershipParameterInsertedStartMessage",
					SchemaElementUId = new Guid("68b36cd4-19a6-43ea-8945-e5e6f32bf77b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _partnershipParameterInsertedScriptTask;
		public ProcessScriptTask PartnershipParameterInsertedScriptTask {
			get {
				return _partnershipParameterInsertedScriptTask ?? (_partnershipParameterInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PartnershipParameterInsertedScriptTask",
					SchemaElementUId = new Guid("374fe5a3-af87-4882-9854-eae1c144b7aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PartnershipParameterInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterUpdatedEventSubProcess;
		public ProcessFlowElement PartnershipParameterUpdatedEventSubProcess {
			get {
				return _partnershipParameterUpdatedEventSubProcess ?? (_partnershipParameterUpdatedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PartnershipParameterUpdatedEventSubProcess",
					SchemaElementUId = new Guid("29dd2f7c-7523-49f8-9c5c-a62b44831cc2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterUpdated;
		public ProcessFlowElement PartnershipParameterUpdated {
			get {
				return _partnershipParameterUpdated ?? (_partnershipParameterUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PartnershipParameterUpdated",
					SchemaElementUId = new Guid("17912aea-7fe8-482c-9bc0-5a51796a8e03"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _partnershipParameterUpdatedScriptTask;
		public ProcessScriptTask PartnershipParameterUpdatedScriptTask {
			get {
				return _partnershipParameterUpdatedScriptTask ?? (_partnershipParameterUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PartnershipParameterUpdatedScriptTask",
					SchemaElementUId = new Guid("2a4528d5-a40f-4568-8073-513e97b429d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PartnershipParameterUpdatedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterSavingEventSubProcess;
		public ProcessFlowElement PartnershipParameterSavingEventSubProcess {
			get {
				return _partnershipParameterSavingEventSubProcess ?? (_partnershipParameterSavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PartnershipParameterSavingEventSubProcess",
					SchemaElementUId = new Guid("f2bcb474-79f3-444c-8bf8-0cb3d691405b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _partnershipParameterSavingScriptTask;
		public ProcessScriptTask PartnershipParameterSavingScriptTask {
			get {
				return _partnershipParameterSavingScriptTask ?? (_partnershipParameterSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PartnershipParameterSavingScriptTask",
					SchemaElementUId = new Guid("200c319d-3dde-4996-b711-56bf8298a038"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PartnershipParameterSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterSavingMessage;
		public ProcessFlowElement PartnershipParameterSavingMessage {
			get {
				return _partnershipParameterSavingMessage ?? (_partnershipParameterSavingMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PartnershipParameterSavingMessage",
					SchemaElementUId = new Guid("72398059-48ca-4df6-a168-f36531810fb0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterDeletingEventSubProcess;
		public ProcessFlowElement PartnershipParameterDeletingEventSubProcess {
			get {
				return _partnershipParameterDeletingEventSubProcess ?? (_partnershipParameterDeletingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PartnershipParameterDeletingEventSubProcess",
					SchemaElementUId = new Guid("a95eee94-4968-4e28-84e2-811399ff1f21"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _partnershipParameterDeleting;
		public ProcessFlowElement PartnershipParameterDeleting {
			get {
				return _partnershipParameterDeleting ?? (_partnershipParameterDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PartnershipParameterDeleting",
					SchemaElementUId = new Guid("4bb52952-13a4-4c2f-8c8f-b26b3ba4eef5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _partnershipParameterDeletingScriptTask;
		public ProcessScriptTask PartnershipParameterDeletingScriptTask {
			get {
				return _partnershipParameterDeletingScriptTask ?? (_partnershipParameterDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PartnershipParameterDeletingScriptTask",
					SchemaElementUId = new Guid("bac119b1-8369-42d0-aff0-ddfa09bd560e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PartnershipParameterDeletingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[PartnershipParameterInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterInsertedEventSubProcess };
			FlowElements[PartnershipParameterInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterInsertedStartMessage };
			FlowElements[PartnershipParameterInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterInsertedScriptTask };
			FlowElements[PartnershipParameterUpdatedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterUpdatedEventSubProcess };
			FlowElements[PartnershipParameterUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterUpdated };
			FlowElements[PartnershipParameterUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterUpdatedScriptTask };
			FlowElements[PartnershipParameterSavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterSavingEventSubProcess };
			FlowElements[PartnershipParameterSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterSavingScriptTask };
			FlowElements[PartnershipParameterSavingMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterSavingMessage };
			FlowElements[PartnershipParameterDeletingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterDeletingEventSubProcess };
			FlowElements[PartnershipParameterDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterDeleting };
			FlowElements[PartnershipParameterDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipParameterDeletingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "PartnershipParameterInsertedEventSubProcess":
						break;
					case "PartnershipParameterInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("PartnershipParameterInsertedScriptTask");
						break;
					case "PartnershipParameterInsertedScriptTask":
						break;
					case "PartnershipParameterUpdatedEventSubProcess":
						break;
					case "PartnershipParameterUpdated":
						e.Context.QueueTasks.Enqueue("PartnershipParameterUpdatedScriptTask");
						break;
					case "PartnershipParameterUpdatedScriptTask":
						break;
					case "PartnershipParameterSavingEventSubProcess":
						break;
					case "PartnershipParameterSavingScriptTask":
						break;
					case "PartnershipParameterSavingMessage":
						e.Context.QueueTasks.Enqueue("PartnershipParameterSavingScriptTask");
						break;
					case "PartnershipParameterDeletingEventSubProcess":
						break;
					case "PartnershipParameterDeleting":
						e.Context.QueueTasks.Enqueue("PartnershipParameterDeletingScriptTask");
						break;
					case "PartnershipParameterDeletingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PartnershipParameterInsertedStartMessage");
			ActivatedEventElements.Add("PartnershipParameterUpdated");
			ActivatedEventElements.Add("PartnershipParameterSavingMessage");
			ActivatedEventElements.Add("PartnershipParameterDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "PartnershipParameterInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PartnershipParameterInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterInsertedStartMessage";
					result = PartnershipParameterInsertedStartMessage.Execute(context);
					break;
				case "PartnershipParameterInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterInsertedScriptTask";
					result = PartnershipParameterInsertedScriptTask.Execute(context, PartnershipParameterInsertedScriptTaskExecute);
					break;
				case "PartnershipParameterUpdatedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PartnershipParameterUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterUpdated";
					result = PartnershipParameterUpdated.Execute(context);
					break;
				case "PartnershipParameterUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterUpdatedScriptTask";
					result = PartnershipParameterUpdatedScriptTask.Execute(context, PartnershipParameterUpdatedScriptTaskExecute);
					break;
				case "PartnershipParameterSavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PartnershipParameterSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterSavingScriptTask";
					result = PartnershipParameterSavingScriptTask.Execute(context, PartnershipParameterSavingScriptTaskExecute);
					break;
				case "PartnershipParameterSavingMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterSavingMessage";
					result = PartnershipParameterSavingMessage.Execute(context);
					break;
				case "PartnershipParameterDeletingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PartnershipParameterDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterDeleting";
					result = PartnershipParameterDeleting.Execute(context);
					break;
				case "PartnershipParameterDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipParameterDeletingScriptTask";
					result = PartnershipParameterDeletingScriptTask.Execute(context, PartnershipParameterDeletingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool PartnershipParameterInsertedScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				PartnershipHelper partnershipHelper
					= ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
			partnershipHelper.AddNewPartnershipParameterHistory(Entity);
			}
			return true;
		}

		public virtual bool PartnershipParameterUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				PartnershipHelper partnershipHelper
					= ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
				var changedColumns = Entity.GetChangedColumnValues().Where(cv => cv.Value != cv.OldValue);
				Guid partnershipId = Entity.GetTypedColumnValue<Guid>("PartnershipId");
				partnershipHelper.RecalculateAllScore(partnershipId);
				if (changedColumns.All(x => x.Name != "PartnerLevelId")) {
					partnershipHelper.ChangePartnershipLevel(partnershipId);
				}
				partnershipHelper.SetPartnershipScoreLeft(partnershipId);
				partnershipHelper.AddNewPartnershipParameterHistory(Entity);
			}
			return true;
		}

		public virtual bool PartnershipParameterSavingScriptTaskExecute(ProcessExecutingContext context) {
			CopyValueToCurrentValueColumn();
			return true;
		}

		public virtual bool PartnershipParameterDeletingScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				PartnershipHelper partnershipHelper
					= ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
			partnershipHelper.SetParameterHistoryEndDate(Entity);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "PartnershipParameter_PRMBase_BPMSoftInserted":
							if (ActivatedEventElements.Contains("PartnershipParameterInsertedStartMessage")) {
							context.QueueTasks.Enqueue("PartnershipParameterInsertedStartMessage");
						}
						break;
					case "PartnershipParameter_PRMBase_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("PartnershipParameterUpdated")) {
							context.QueueTasks.Enqueue("PartnershipParameterUpdated");
						}
						break;
					case "PartnershipParameter_PRMBase_BPMSoftSaving":
							if (ActivatedEventElements.Contains("PartnershipParameterSavingMessage")) {
							context.QueueTasks.Enqueue("PartnershipParameterSavingMessage");
						}
						break;
					case "PartnershipParameter_PRMBase_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("PartnershipParameterDeleting")) {
							context.QueueTasks.Enqueue("PartnershipParameterDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParameter_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnershipParameter_PRMBaseEventsProcess : PartnershipParameter_PRMBaseEventsProcess<PartnershipParameter_PRMBase_BPMSoft>
	{

		public PartnershipParameter_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

