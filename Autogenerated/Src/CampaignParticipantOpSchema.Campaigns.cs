namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
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

	#region Class: CampaignParticipantOpSchema

	/// <exclude/>
	public class CampaignParticipantOpSchema : BPMSoft.Configuration.CampaignParticipantSchema
	{

		#region Constructors: Public

		public CampaignParticipantOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignParticipantOpSchema(CampaignParticipantOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignParticipantOpSchema(CampaignParticipantOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f");
			RealUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f");
			Name = "CampaignParticipantOp";
			ParentSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aaaacfa8-e963-4328-8eea-9505e11cda00")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("60266941-88a3-49b0-9402-5e0374d8f483")) == null) {
				Columns.Add(CreateIsReadyToSyncColumn());
			}
			if (Columns.FindByUId(new Guid("8b71ab42-eae2-4ec6-8eb4-fb9ea747660a")) == null) {
				Columns.Add(CreateInitialCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("3b685758-82b4-48b3-b4d7-76d8cb507607")) == null) {
				Columns.Add(CreateCampaignParticipantColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("aaaacfa8-e963-4328-8eea-9505e11cda00"),
				Name = @"SessionId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				ModifiedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067")
			};
		}

		protected virtual EntitySchemaColumn CreateIsReadyToSyncColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("60266941-88a3-49b0-9402-5e0374d8f483"),
				Name = @"IsReadyToSync",
				CreatedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				ModifiedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067")
			};
		}

		protected virtual EntitySchemaColumn CreateInitialCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8b71ab42-eae2-4ec6-8eb4-fb9ea747660a"),
				Name = @"InitialCampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				ModifiedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignParticipantColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3b685758-82b4-48b3-b4d7-76d8cb507607"),
				Name = @"CampaignParticipant",
				ReferenceSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				ModifiedInSchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignParticipantOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignParticipantOp_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignParticipantOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignParticipantOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("768ecc55-e80e-4df8-837f-085fb32e001f"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipantOp

	/// <summary>
	/// Участник кампании (транзакционный).
	/// </summary>
	public class CampaignParticipantOp : BPMSoft.Configuration.CampaignParticipant
	{

		#region Constructors: Public

		public CampaignParticipantOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignParticipantOp";
		}

		public CampaignParticipantOp(CampaignParticipantOp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SessionId.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// IsReadyToSync.
		/// </summary>
		public bool IsReadyToSync {
			get {
				return GetTypedColumnValue<bool>("IsReadyToSync");
			}
			set {
				SetColumnValue("IsReadyToSync", value);
			}
		}

		/// <exclude/>
		public Guid InitialCampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("InitialCampaignItemId");
			}
			set {
				SetColumnValue("InitialCampaignItemId", value);
				_initialCampaignItem = null;
			}
		}

		/// <exclude/>
		public string InitialCampaignItemName {
			get {
				return GetTypedColumnValue<string>("InitialCampaignItemName");
			}
			set {
				SetColumnValue("InitialCampaignItemName", value);
				if (_initialCampaignItem != null) {
					_initialCampaignItem.Name = value;
				}
			}
		}

		private CampaignItem _initialCampaignItem;
		/// <summary>
		/// Начальный шаг участника во фрагменте.
		/// </summary>
		public CampaignItem InitialCampaignItem {
			get {
				return _initialCampaignItem ??
					(_initialCampaignItem = LookupColumnEntities.GetEntity("InitialCampaignItem") as CampaignItem);
			}
		}

		/// <exclude/>
		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
				_campaignParticipant = null;
			}
		}

		private CampaignParticipant _campaignParticipant;
		/// <summary>
		/// CampaignParticipant.
		/// </summary>
		public CampaignParticipant CampaignParticipant {
			get {
				return _campaignParticipant ??
					(_campaignParticipant = LookupColumnEntities.GetEntity("CampaignParticipant") as CampaignParticipant);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignParticipantOp_CampaignsEventsProcess(UserConnection);
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
			return new CampaignParticipantOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipantOp_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignParticipantOp_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.CampaignParticipant_CampaignsEventsProcess<TEntity> where TEntity : CampaignParticipantOp
	{

		public CampaignParticipantOp_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignParticipantOp_CampaignsEventsProcess";
			SchemaUId = new Guid("768ecc55-e80e-4df8-837f-085fb32e001f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("768ecc55-e80e-4df8-837f-085fb32e001f");
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

	#region Class: CampaignParticipantOp_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignParticipantOp_CampaignsEventsProcess : CampaignParticipantOp_CampaignsEventsProcess<CampaignParticipantOp>
	{

		public CampaignParticipantOp_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignParticipantOp_CampaignsEventsProcess

	public partial class CampaignParticipantOp_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignParticipantOpEventsProcess

	/// <exclude/>
	public class CampaignParticipantOpEventsProcess : CampaignParticipantOp_CampaignsEventsProcess
	{

		public CampaignParticipantOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

