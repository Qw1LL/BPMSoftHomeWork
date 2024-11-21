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

	#region Class: VwBulkEmailSendWaitingSchema

	/// <exclude/>
	public class VwBulkEmailSendWaitingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwBulkEmailSendWaitingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwBulkEmailSendWaitingSchema(VwBulkEmailSendWaitingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwBulkEmailSendWaitingSchema(VwBulkEmailSendWaitingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			RealUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			Name = "VwBulkEmailSendWaiting";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bb46ec86-4726-470d-b90b-4b15f3286a5f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("727e5c64-dbb4-4d54-91aa-280163fe0f21")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("80e9d3b1-ada3-42f2-af06-8df93b5168f5")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bb46ec86-4726-470d-b90b-4b15f3286a5f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("727e5c64-dbb4-4d54-91aa-280163fe0f21"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80e9d3b1-ada3-42f2-af06-8df93b5168f5"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("13cffa88-d296-4202-8bee-d023d51a8454"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				ModifiedInSchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"),
				CreatedInPackageId = new Guid("d6fec08a-2746-46b6-a96c-0a31e271957f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwBulkEmailSendWaiting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwBulkEmailSendWaiting_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwBulkEmailSendWaitingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwBulkEmailSendWaitingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905"));
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailSendWaiting

	/// <summary>
	/// Письма ожидающие отправки.
	/// </summary>
	public class VwBulkEmailSendWaiting : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwBulkEmailSendWaiting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailSendWaiting";
		}

		public VwBulkEmailSendWaiting(VwBulkEmailSendWaiting source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private BulkEmailStatus _status;
		/// <summary>
		/// Состояние email.
		/// </summary>
		public BulkEmailStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as BulkEmailStatus);
			}
		}

		/// <summary>
		/// Начало.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private BulkEmailCategory _category;
		/// <summary>
		/// Категория email.
		/// </summary>
		public BulkEmailCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as BulkEmailCategory);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwBulkEmailSendWaiting_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwBulkEmailSendWaitingDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwBulkEmailSendWaitingInserting", e);
			Validating += (s, e) => ThrowEvent("VwBulkEmailSendWaitingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwBulkEmailSendWaiting(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailSendWaiting_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwBulkEmailSendWaiting_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwBulkEmailSendWaiting
	{

		public VwBulkEmailSendWaiting_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwBulkEmailSendWaiting_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("398a77f9-4cb8-46e5-88e4-b070ceb77905");
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

	#region Class: VwBulkEmailSendWaiting_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwBulkEmailSendWaiting_MarketingCampaignEventsProcess : VwBulkEmailSendWaiting_MarketingCampaignEventsProcess<VwBulkEmailSendWaiting>
	{

		public VwBulkEmailSendWaiting_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwBulkEmailSendWaiting_MarketingCampaignEventsProcess

	public partial class VwBulkEmailSendWaiting_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwBulkEmailSendWaitingEventsProcess

	/// <exclude/>
	public class VwBulkEmailSendWaitingEventsProcess : VwBulkEmailSendWaiting_MarketingCampaignEventsProcess
	{

		public VwBulkEmailSendWaitingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

