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

	#region Class: SiteEventSchema

	/// <exclude/>
	public class SiteEventSchema : BPMSoft.Configuration.SiteEvent_SiteEvent_BPMSoftSchema
	{

		#region Constructors: Public

		public SiteEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventSchema(SiteEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventSchema(SiteEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIvY8DJLJ6yOkP6AquJay1kSPHJvcIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("50a6761f-fda2-4605-ac06-19506850fbba");
			index.Name = "IvY8DJLJ6yOkP6AquJay1kSPHJvc";
			index.CreatedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			index.ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			index.CreatedInPackageId = new Guid("895fb87d-7418-4883-85be-9c84b0af23bd");
			EntitySchemaIndexColumn bpmSessionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2ee219b8-918d-4bec-9c5e-8ab9e8761e8a"),
				ColumnUId = new Guid("4333c2b2-9461-4c1f-bb79-2634671b5368"),
				CreatedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2"),
				ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2"),
				CreatedInPackageId = new Guid("895fb87d-7418-4883-85be-9c84b0af23bd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(bpmSessionIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			Name = "SiteEvent";
			ParentSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("47949cd8-6780-414e-8fda-4fa996b6db3c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4333c2b2-9461-4c1f-bb79-2634671b5368")) == null) {
				Columns.Add(CreateBpmSessionIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateContactColumn() {
			EntitySchemaColumn column = base.CreateContactColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			return column;
		}

		protected override EntitySchemaColumn CreateLeadTypeColumn() {
			EntitySchemaColumn column = base.CreateLeadTypeColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateBpmSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4333c2b2-9461-4c1f-bb79-2634671b5368"),
				Name = @"BpmSessionId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2"),
				ModifiedInSchemaUId = new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2"),
				CreatedInPackageId = new Guid("47949cd8-6780-414e-8fda-4fa996b6db3c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIvY8DJLJ6yOkP6AquJay1kSPHJvcIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEvent_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEvent

	/// <summary>
	/// Событие сайта в профиле клиента.
	/// </summary>
	public class SiteEvent : BPMSoft.Configuration.SiteEvent_SiteEvent_BPMSoft
	{

		#region Constructors: Public

		public SiteEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEvent";
		}

		public SiteEvent(SiteEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// BpmSessionID.
		/// </summary>
		public Guid BpmSessionId {
			get {
				return GetTypedColumnValue<Guid>("BpmSessionId");
			}
			set {
				SetColumnValue("BpmSessionId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEvent_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEvent_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEvent_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.SiteEvent_SiteEventEventsProcess<TEntity> where TEntity : SiteEvent
	{

		public SiteEvent_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEvent_EventTrackingEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("aae17d34-795d-4103-bfd4-837fcbc766b2");
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

	#region Class: SiteEvent_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEvent_EventTrackingEventsProcess : SiteEvent_EventTrackingEventsProcess<SiteEvent>
	{

		public SiteEvent_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEvent_EventTrackingEventsProcess

	public partial class SiteEvent_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventEventsProcess

	/// <exclude/>
	public class SiteEventEventsProcess : SiteEvent_EventTrackingEventsProcess
	{

		public SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

