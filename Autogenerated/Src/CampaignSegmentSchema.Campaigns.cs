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

	#region Class: CampaignSegmentSchema

	/// <exclude/>
	public class CampaignSegmentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignSegmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignSegmentSchema(CampaignSegmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignSegmentSchema(CampaignSegmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb");
			RealUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb");
			Name = "CampaignSegment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d3831d78-d224-425e-8001-3ebd5b3770dc")) == null) {
				Columns.Add(CreateSegmentColumn());
			}
			if (Columns.FindByUId(new Guid("fc3a8efc-8d97-4ec4-bfed-9090438eef83")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("10eae680-f4d1-4451-ac94-3971726390e4")) == null) {
				Columns.Add(CreateStateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSegmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d3831d78-d224-425e-8001-3ebd5b3770dc"),
				Name = @"Segment",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				ModifiedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fc3a8efc-8d97-4ec4-bfed-9090438eef83"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				ModifiedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10eae680-f4d1-4451-ac94-3971726390e4"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				ModifiedInSchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"),
				CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignSegment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignSegment_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignSegmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignSegmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7126d03d-78de-422c-8656-141ee5a3edfb"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignSegment

	/// <summary>
	/// Сегменты кампании.
	/// </summary>
	public class CampaignSegment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignSegment";
		}

		public CampaignSegment(CampaignSegment source)
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
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
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
			var process = new CampaignSegment_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignSegmentDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignSegmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignSegment(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignSegment_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignSegment_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignSegment
	{

		public CampaignSegment_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignSegment_CampaignsEventsProcess";
			SchemaUId = new Guid("7126d03d-78de-422c-8656-141ee5a3edfb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7126d03d-78de-422c-8656-141ee5a3edfb");
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

	#region Class: CampaignSegment_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignSegment_CampaignsEventsProcess : CampaignSegment_CampaignsEventsProcess<CampaignSegment>
	{

		public CampaignSegment_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignSegment_CampaignsEventsProcess

	public partial class CampaignSegment_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignSegmentEventsProcess

	/// <exclude/>
	public class CampaignSegmentEventsProcess : CampaignSegment_CampaignsEventsProcess
	{

		public CampaignSegmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

