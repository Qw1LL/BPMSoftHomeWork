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

	#region Class: BulkEmailInBulkEmailSplitSchema

	/// <exclude/>
	public class BulkEmailInBulkEmailSplitSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailInBulkEmailSplitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailInBulkEmailSplitSchema(BulkEmailInBulkEmailSplitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailInBulkEmailSplitSchema(BulkEmailInBulkEmailSplitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6");
			RealUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6");
			Name = "BulkEmailInBulkEmailSplit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2b7e5767-069d-4af3-ac7a-83c9b0f332e6")) == null) {
				Columns.Add(CreateBulkEmailSplitColumn());
			}
			if (Columns.FindByUId(new Guid("16c6e519-9739-488a-9995-772417f702aa")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailSplitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2b7e5767-069d-4af3-ac7a-83c9b0f332e6"),
				Name = @"BulkEmailSplit",
				ReferenceSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6"),
				ModifiedInSchemaUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16c6e519-9739-488a-9995-772417f702aa"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6"),
				ModifiedInSchemaUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailInBulkEmailSplit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailInBulkEmailSplitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailInBulkEmailSplitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInBulkEmailSplit

	/// <summary>
	/// Рассылки в сплит-тесте.
	/// </summary>
	public class BulkEmailInBulkEmailSplit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailInBulkEmailSplit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailInBulkEmailSplit";
		}

		public BulkEmailInBulkEmailSplit(BulkEmailInBulkEmailSplit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Сплит-тест.
		/// </summary>
		public BulkEmailSplit BulkEmailSplit {
			get {
				return _bulkEmailSplit ??
					(_bulkEmailSplit = LookupColumnEntities.GetEntity("BulkEmailSplit") as BulkEmailSplit);
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
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailInBulkEmailSplitDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailInBulkEmailSplitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailInBulkEmailSplit(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailInBulkEmailSplit
	{

		public BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("46bd80f2-ffcf-4094-8d16-e08da266fcd6");
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

	#region Class: BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess : BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess<BulkEmailInBulkEmailSplit>
	{

		public BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess

	public partial class BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailInBulkEmailSplitEventsProcess

	/// <exclude/>
	public class BulkEmailInBulkEmailSplitEventsProcess : BulkEmailInBulkEmailSplit_MarketingCampaignEventsProcess
	{

		public BulkEmailInBulkEmailSplitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

