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

	#region Class: CmpgnSplitDistributionSchema

	/// <exclude/>
	public class CmpgnSplitDistributionSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public CmpgnSplitDistributionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CmpgnSplitDistributionSchema(CmpgnSplitDistributionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CmpgnSplitDistributionSchema(CmpgnSplitDistributionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIdxItemParticipantIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("d4f489e7-ed9a-48dd-b25e-f369af207e9a");
			index.Name = "IdxItemParticipant";
			index.CreatedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			index.ModifiedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			index.CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			EntitySchemaIndexColumn transitionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f7b0cf38-bc46-3970-5bab-5d522332d84e"),
				ColumnUId = new Guid("3ea1f095-7b79-9ce0-3e31-a41df33e8c2a"),
				CreatedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2"),
				ModifiedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(transitionIdIndexColumn);
			EntitySchemaIndexColumn campaignParticipantIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d94ee0dd-6f6c-3178-a882-6160c73d88df"),
				ColumnUId = new Guid("178f886d-49f4-c78c-4d84-722de4b14e80"),
				CreatedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2"),
				ModifiedInSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(campaignParticipantIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8");
			RealUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8");
			Name = "CmpgnSplitDistribution";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateCampaignParticipantIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3ea1f095-7b79-9ce0-3e31-a41df33e8c2a")) == null) {
				Columns.Add(CreateTransitionIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTransitionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3ea1f095-7b79-9ce0-3e31-a41df33e8c2a"),
				Name = @"TransitionId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8"),
				ModifiedInSchemaUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignParticipantIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("178f886d-49f4-c78c-4d84-722de4b14e80"),
				Name = @"CampaignParticipantId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8"),
				ModifiedInSchemaUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIdxItemParticipantIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CmpgnSplitDistribution(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CmpgnSplitDistribution_CampaignElementsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CmpgnSplitDistributionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CmpgnSplitDistributionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8"));
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnSplitDistribution

	/// <summary>
	/// CmpgnSplitDistribution.
	/// </summary>
	public class CmpgnSplitDistribution : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CmpgnSplitDistribution(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnSplitDistribution";
		}

		public CmpgnSplitDistribution(CmpgnSplitDistribution source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TransitionId.
		/// </summary>
		/// <remarks>
		/// Defines unique transition index per campaign schema. TransitionId not equals to CampaignItemId.
		/// </remarks>
		public Guid TransitionId {
			get {
				return GetTypedColumnValue<Guid>("TransitionId");
			}
			set {
				SetColumnValue("TransitionId", value);
			}
		}

		/// <summary>
		/// CampaignParticipantId.
		/// </summary>
		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CmpgnSplitDistribution_CampaignElementsEventsProcess(UserConnection);
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
			return new CmpgnSplitDistribution(this);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnSplitDistribution_CampaignElementsEventsProcess

	/// <exclude/>
	public partial class CmpgnSplitDistribution_CampaignElementsEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : CmpgnSplitDistribution
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

		public CmpgnSplitDistribution_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CmpgnSplitDistribution_CampaignElementsEventsProcess";
			SchemaUId = new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c0a19d8c-c24c-366f-b622-3ebeee65c2a8");
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

	#region Class: CmpgnSplitDistribution_CampaignElementsEventsProcess

	/// <exclude/>
	public class CmpgnSplitDistribution_CampaignElementsEventsProcess : CmpgnSplitDistribution_CampaignElementsEventsProcess<CmpgnSplitDistribution>
	{

		public CmpgnSplitDistribution_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CmpgnSplitDistribution_CampaignElementsEventsProcess

	public partial class CmpgnSplitDistribution_CampaignElementsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CmpgnSplitDistributionEventsProcess

	/// <exclude/>
	public class CmpgnSplitDistributionEventsProcess : CmpgnSplitDistribution_CampaignElementsEventsProcess
	{

		public CmpgnSplitDistributionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

