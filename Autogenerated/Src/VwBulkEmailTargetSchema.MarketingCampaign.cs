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

	#region Class: VwBulkEmailTargetSchema

	/// <exclude/>
	public class VwBulkEmailTargetSchema : BPMSoft.Configuration.BulkEmailTargetSchema
	{

		#region Constructors: Public

		public VwBulkEmailTargetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwBulkEmailTargetSchema(VwBulkEmailTargetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwBulkEmailTargetSchema(VwBulkEmailTargetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIXBETContactIdResponseIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("eb0d4871-38c9-4db9-995f-7a034207b9f3");
			index.Name = "IXBETContactIdResponseId";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			EntitySchemaIndexColumn contactIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("082a97bd-6875-3f7c-ff80-9f8049de0da2"),
				ColumnUId = new Guid("8b85ee02-7cd9-4f86-a938-d44f8fc1d41a"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(contactIdIndexColumn);
			EntitySchemaIndexColumn bulkEmailResponseIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("efc97fe8-19e8-ad2d-d395-3bc7ffebb9d0"),
				ColumnUId = new Guid("91b87361-603a-4602-b7dc-09b46423343e"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(bulkEmailResponseIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46217089-79d1-4b82-b167-6d2dcd287eee");
			RealUId = new Guid("46217089-79d1-4b82-b167-6d2dcd287eee");
			Name = "VwBulkEmailTarget";
			ParentSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef263e41-910f-48d5-8742-0aa2f3dad577")) == null) {
				Columns.Add(CreateReplicaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ef263e41-910f-48d5-8742-0aa2f3dad577"),
				Name = @"Replica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("46217089-79d1-4b82-b167-6d2dcd287eee"),
				ModifiedInSchemaUId = new Guid("46217089-79d1-4b82-b167-6d2dcd287eee"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIXBETContactIdResponseIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwBulkEmailTarget(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwBulkEmailTarget_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwBulkEmailTargetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwBulkEmailTargetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46217089-79d1-4b82-b167-6d2dcd287eee"));
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailTarget

	/// <summary>
	/// Расширенный отклик в Email.
	/// </summary>
	public class VwBulkEmailTarget : BPMSoft.Configuration.BulkEmailTarget
	{

		#region Constructors: Public

		public VwBulkEmailTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailTarget";
		}

		public VwBulkEmailTarget(VwBulkEmailTarget source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReplicaId {
			get {
				return GetTypedColumnValue<Guid>("ReplicaId");
			}
			set {
				SetColumnValue("ReplicaId", value);
				_replica = null;
			}
		}

		/// <exclude/>
		public string ReplicaCaption {
			get {
				return GetTypedColumnValue<string>("ReplicaCaption");
			}
			set {
				SetColumnValue("ReplicaCaption", value);
				if (_replica != null) {
					_replica.Caption = value;
				}
			}
		}

		private DCReplica _replica;
		/// <summary>
		/// Реплика динамического контента.
		/// </summary>
		public DCReplica Replica {
			get {
				return _replica ??
					(_replica = LookupColumnEntities.GetEntity("Replica") as DCReplica);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwBulkEmailTarget_MarketingCampaignEventsProcess(UserConnection);
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
			return new VwBulkEmailTarget(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwBulkEmailTarget_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BulkEmailTarget_MarketingCampaignEventsProcess<TEntity> where TEntity : VwBulkEmailTarget
	{

		public VwBulkEmailTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwBulkEmailTarget_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("46217089-79d1-4b82-b167-6d2dcd287eee");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("46217089-79d1-4b82-b167-6d2dcd287eee");
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

	#region Class: VwBulkEmailTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwBulkEmailTarget_MarketingCampaignEventsProcess : VwBulkEmailTarget_MarketingCampaignEventsProcess<VwBulkEmailTarget>
	{

		public VwBulkEmailTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwBulkEmailTarget_MarketingCampaignEventsProcess

	public partial class VwBulkEmailTarget_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwBulkEmailTargetEventsProcess

	/// <exclude/>
	public class VwBulkEmailTargetEventsProcess : VwBulkEmailTarget_MarketingCampaignEventsProcess
	{

		public VwBulkEmailTargetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

