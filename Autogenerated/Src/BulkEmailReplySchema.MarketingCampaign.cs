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

	#region Class: BulkEmailReplySchema

	/// <exclude/>
	public class BulkEmailReplySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailReplySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailReplySchema(BulkEmailReplySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailReplySchema(BulkEmailReplySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a");
			RealUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a");
			Name = "BulkEmailReply";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4004ebe1-5736-a9b7-03ce-93002c9f8ac2")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("301052fe-19ee-3d5c-115e-98773632c768")) == null) {
				Columns.Add(CreateMandrillIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4004ebe1-5736-a9b7-03ce-93002c9f8ac2"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a"),
				ModifiedInSchemaUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateMandrillIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("301052fe-19ee-3d5c-115e-98773632c768"),
				Name = @"MandrillId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a"),
				ModifiedInSchemaUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailReply(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailReply_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailReplySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailReplySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e91671dc-3033-43e7-9c76-960e73a8653a"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailReply

	/// <summary>
	/// Ответ на массовую рассылку.
	/// </summary>
	public class BulkEmailReply : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailReply(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailReply";
		}

		public BulkEmailReply(BulkEmailReply source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// BulkEmail.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <summary>
		/// MandrillId.
		/// </summary>
		public Guid MandrillId {
			get {
				return GetTypedColumnValue<Guid>("MandrillId");
			}
			set {
				SetColumnValue("MandrillId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailReply_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailReply(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailReply_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailReply_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailReply
	{

		public BulkEmailReply_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailReply_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("e91671dc-3033-43e7-9c76-960e73a8653a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e91671dc-3033-43e7-9c76-960e73a8653a");
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

	#region Class: BulkEmailReply_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailReply_MarketingCampaignEventsProcess : BulkEmailReply_MarketingCampaignEventsProcess<BulkEmailReply>
	{

		public BulkEmailReply_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailReply_MarketingCampaignEventsProcess

	public partial class BulkEmailReply_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailReplyEventsProcess

	/// <exclude/>
	public class BulkEmailReplyEventsProcess : BulkEmailReply_MarketingCampaignEventsProcess
	{

		public BulkEmailReplyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

