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
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: Activity_MarketingCampaign_BPMSoftSchema

	/// <exclude/>
	public class Activity_MarketingCampaign_BPMSoftSchema : BPMSoft.Configuration.Activity_Change_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_MarketingCampaign_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_MarketingCampaign_BPMSoftSchema(Activity_MarketingCampaign_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_MarketingCampaign_BPMSoftSchema(Activity_MarketingCampaign_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_Activity_SendDateIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("1e60c588-1264-4219-9f83-2a3e68bc54b6");
			index.Name = "IX_Activity_SendDate";
			index.CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed");
			EntitySchemaIndexColumn sendDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b8f4292f-5ae6-43ca-9685-1301b31eba68"),
				ColumnUId = new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc"),
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(sendDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("baa60952-0916-4da5-833b-bf406577892d");
			Name = "Activity_MarketingCampaign_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("00c2b73d-e1eb-4097-ab86-663735696f9b")) == null) {
				Columns.Add(CreateEventColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("00c2b73d-e1eb-4097-ab86-663735696f9b"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("baa60952-0916-4da5-833b-bf406577892d"),
				ModifiedInSchemaUId = new Guid("baa60952-0916-4da5-833b-bf406577892d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_Activity_SendDateIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_MarketingCampaign_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_MarketingCampaign_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_MarketingCampaign_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("baa60952-0916-4da5-833b-bf406577892d"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_MarketingCampaign_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_MarketingCampaign_BPMSoft : BPMSoft.Configuration.Activity_Change_BPMSoft
	{

		#region Constructors: Public

		public Activity_MarketingCampaign_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_MarketingCampaign_BPMSoft";
		}

		public Activity_MarketingCampaign_BPMSoft(Activity_MarketingCampaign_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_MarketingCampaignEventsProcess(UserConnection);
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
			return new Activity_MarketingCampaign_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class Activity_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.Activity_ChangeEventsProcess<TEntity> where TEntity : Activity_MarketingCampaign_BPMSoft
	{

		public Activity_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_MarketingCampaignEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("baa60952-0916-4da5-833b-bf406577892d");
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

	#region Class: Activity_MarketingCampaignEventsProcess

	/// <exclude/>
	public class Activity_MarketingCampaignEventsProcess : Activity_MarketingCampaignEventsProcess<Activity_MarketingCampaign_BPMSoft>
	{

		public Activity_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_MarketingCampaignEventsProcess

	public partial class Activity_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

