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

	#region Class: BulkEmailSegmentSchema

	/// <exclude/>
	public class BulkEmailSegmentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailSegmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSegmentSchema(BulkEmailSegmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSegmentSchema(BulkEmailSegmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			RealUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			Name = "BulkEmailSegment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8614504a-04ba-46b2-8e02-1b369460ad9c")) == null) {
				Columns.Add(CreateSegmentColumn());
			}
			if (Columns.FindByUId(new Guid("98e16a74-ae86-4673-899c-f135ea7f6bd7")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("1238a087-0005-44e8-ae9c-63cb9edb5ddb")) == null) {
				Columns.Add(CreateStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			column.CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSegmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8614504a-04ba-46b2-8e02-1b369460ad9c"),
				Name = @"Segment",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("98e16a74-ae86-4673-899c-f135ea7f6bd7"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1238a087-0005-44e8-ae9c-63cb9edb5ddb"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				ModifiedInSchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailSegment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSegment_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSegmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSegmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSegment

	/// <summary>
	/// Сегменты  email.
	/// </summary>
	public class BulkEmailSegment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSegment";
		}

		public BulkEmailSegment(BulkEmailSegment source)
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
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Email.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
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
			var process = new BulkEmailSegment_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailSegmentDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailSegmentInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailSegmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailSegment(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSegment_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailSegment
	{

		public BulkEmailSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSegment_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a7754505-5ca6-4558-8bb4-d04b0d209c5e");
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

	#region Class: BulkEmailSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSegment_MarketingCampaignEventsProcess : BulkEmailSegment_MarketingCampaignEventsProcess<BulkEmailSegment>
	{

		public BulkEmailSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSegment_MarketingCampaignEventsProcess

	public partial class BulkEmailSegment_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailSegmentEventsProcess

	/// <exclude/>
	public class BulkEmailSegmentEventsProcess : BulkEmailSegment_MarketingCampaignEventsProcess
	{

		public BulkEmailSegmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

