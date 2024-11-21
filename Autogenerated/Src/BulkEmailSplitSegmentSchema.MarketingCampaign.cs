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

	#region Class: BulkEmailSplitSegmentSchema

	/// <exclude/>
	public class BulkEmailSplitSegmentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailSplitSegmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSplitSegmentSchema(BulkEmailSplitSegmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSplitSegmentSchema(BulkEmailSplitSegmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af");
			RealUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af");
			Name = "BulkEmailSplitSegment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0c038939-e426-414c-8681-606b2f85a337")) == null) {
				Columns.Add(CreateSegmentColumn());
			}
			if (Columns.FindByUId(new Guid("4f4e7cf5-30a7-40d9-b073-baa2ab01d2e2")) == null) {
				Columns.Add(CreateBulkEmailSplitColumn());
			}
			if (Columns.FindByUId(new Guid("830e3ee2-840b-4dab-8907-73aff4dd060c")) == null) {
				Columns.Add(CreateStateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSegmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0c038939-e426-414c-8681-606b2f85a337"),
				Name = @"Segment",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				ModifiedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailSplitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4f4e7cf5-30a7-40d9-b073-baa2ab01d2e2"),
				Name = @"BulkEmailSplit",
				ReferenceSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				ModifiedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("830e3ee2-840b-4dab-8907-73aff4dd060c"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				ModifiedInSchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailSplitSegment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSplitSegment_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSplitSegmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSplitSegmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitSegment

	/// <summary>
	/// Сегмент Email: Сплит-теста.
	/// </summary>
	public class BulkEmailSplitSegment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailSplitSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplitSegment";
		}

		public BulkEmailSplitSegment(BulkEmailSplitSegment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SegmentId {
			get {
				return GetTypedColumnValue<Guid>("SegmentId");
			}
			set {
				SetColumnValue("SegmentId", value);
				_segment = null;
			}
		}

		/// <exclude/>
		public string SegmentName {
			get {
				return GetTypedColumnValue<string>("SegmentName");
			}
			set {
				SetColumnValue("SegmentName", value);
				if (_segment != null) {
					_segment.Name = value;
				}
			}
		}

		private ContactFolder _segment;
		/// <summary>
		/// Сегмент.
		/// </summary>
		public ContactFolder Segment {
			get {
				return _segment ??
					(_segment = LookupColumnEntities.GetEntity("Segment") as ContactFolder);
			}
		}

		/// <exclude/>
		public Guid BulkEmailSplitId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailSplitId");
			}
			set {
				SetColumnValue("BulkEmailSplitId", value);
				_bulkEmailSplit = null;
			}
		}

		/// <exclude/>
		public string BulkEmailSplitName {
			get {
				return GetTypedColumnValue<string>("BulkEmailSplitName");
			}
			set {
				SetColumnValue("BulkEmailSplitName", value);
				if (_bulkEmailSplit != null) {
					_bulkEmailSplit.Name = value;
				}
			}
		}

		private BulkEmailSplit _bulkEmailSplit;
		/// <summary>
		/// Email: Сплит-тест.
		/// </summary>
		public BulkEmailSplit BulkEmailSplit {
			get {
				return _bulkEmailSplit ??
					(_bulkEmailSplit = LookupColumnEntities.GetEntity("BulkEmailSplit") as BulkEmailSplit);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private SegmentStatus _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public SegmentStatus State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as SegmentStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailSplitSegment_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailSplitSegmentDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailSplitSegmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailSplitSegment(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSplitSegment_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailSplitSegment
	{

		public BulkEmailSplitSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSplitSegment_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("39954c7a-d9c6-4ea9-8929-ace9416393af");
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

	#region Class: BulkEmailSplitSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSplitSegment_MarketingCampaignEventsProcess : BulkEmailSplitSegment_MarketingCampaignEventsProcess<BulkEmailSplitSegment>
	{

		public BulkEmailSplitSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSplitSegment_MarketingCampaignEventsProcess

	public partial class BulkEmailSplitSegment_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailSplitSegmentEventsProcess

	/// <exclude/>
	public class BulkEmailSplitSegmentEventsProcess : BulkEmailSplitSegment_MarketingCampaignEventsProcess
	{

		public BulkEmailSplitSegmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

