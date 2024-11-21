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

	#region Class: PartnerLevelSchema

	/// <exclude/>
	public class PartnerLevelSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PartnerLevelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnerLevelSchema(PartnerLevelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnerLevelSchema(PartnerLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80");
			RealUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80");
			Name = "PartnerLevel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = true;
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreatePartnerTypeColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aa8ff8ae-3ed1-4743-8958-d1fc12040be6")) == null) {
				Columns.Add(CreateTargetScoreColumn());
			}
			if (Columns.FindByUId(new Guid("f1dbe85e-4eb5-4236-877c-1f66f6797267")) == null) {
				Columns.Add(CreateNumberColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePartnerTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f09646d-0d60-4dd4-8619-27bc3b4f9ff4"),
				Name = @"PartnerType",
				ReferenceSchemaUId = new Guid("43cadf79-8d33-4697-8344-ec24fa905332"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				ModifiedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateTargetScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("aa8ff8ae-3ed1-4743-8958-d1fc12040be6"),
				Name = @"TargetScore",
				CreatedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				ModifiedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f1dbe85e-4eb5-4236-877c-1f66f6797267"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				ModifiedInSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				CreatedInPackageId = new Guid("337d09f6-8036-46e0-94d3-30466e8b57bb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnerLevel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnerLevel_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnerLevelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnerLevelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnerLevel

	/// <summary>
	/// Уровень партнера.
	/// </summary>
	public class PartnerLevel : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PartnerLevel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnerLevel";
		}

		public PartnerLevel(PartnerLevel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PartnerTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnerTypeId");
			}
			set {
				SetColumnValue("PartnerTypeId", value);
				_partnerType = null;
			}
		}

		/// <exclude/>
		public string PartnerTypeName {
			get {
				return GetTypedColumnValue<string>("PartnerTypeName");
			}
			set {
				SetColumnValue("PartnerTypeName", value);
				if (_partnerType != null) {
					_partnerType.Name = value;
				}
			}
		}

		private PartnerType _partnerType;
		/// <summary>
		/// Тип партнера.
		/// </summary>
		public PartnerType PartnerType {
			get {
				return _partnerType ??
					(_partnerType = LookupColumnEntities.GetEntity("PartnerType") as PartnerType);
			}
		}

		/// <summary>
		/// Target score.
		/// </summary>
		public Decimal TargetScore {
			get {
				return GetTypedColumnValue<Decimal>("TargetScore");
			}
			set {
				SetColumnValue("TargetScore", value);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnerLevel_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnerLevelDeleted", e);
			Validating += (s, e) => ThrowEvent("PartnerLevelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnerLevel(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnerLevel_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnerLevel_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : PartnerLevel
	{

		public PartnerLevel_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnerLevel_PRMBaseEventsProcess";
			SchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80");
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

	#region Class: PartnerLevel_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnerLevel_PRMBaseEventsProcess : PartnerLevel_PRMBaseEventsProcess<PartnerLevel>
	{

		public PartnerLevel_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnerLevel_PRMBaseEventsProcess

	public partial class PartnerLevel_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnerLevelEventsProcess

	/// <exclude/>
	public class PartnerLevelEventsProcess : PartnerLevel_PRMBaseEventsProcess
	{

		public PartnerLevelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

