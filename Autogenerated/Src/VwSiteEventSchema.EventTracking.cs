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

	#region Class: VwSiteEventSchema

	/// <exclude/>
	public class VwSiteEventSchema : BPMSoft.Configuration.SiteEventSchema
	{

		#region Constructors: Public

		public VwSiteEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSiteEventSchema(VwSiteEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSiteEventSchema(VwSiteEventSchema source)
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
			UId = new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046");
			RealUId = new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046");
			Name = "VwSiteEvent";
			ParentSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("47949cd8-6780-414e-8fda-4fa996b6db3c");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("baf174ee-94ee-4ee5-914b-781e0687dcd7")) == null) {
				Columns.Add(CreateLeadColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("baf174ee-94ee-4ee5-914b-781e0687dcd7"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046"),
				ModifiedInSchemaUId = new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046"),
				CreatedInPackageId = new Guid("0b806dce-f27a-40de-a645-9f9ac66bf798")
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
			return new VwSiteEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSiteEvent_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSiteEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSiteEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSiteEvent

	/// <summary>
	/// Событие сайта в профиле клиента (представление).
	/// </summary>
	public class VwSiteEvent : BPMSoft.Configuration.SiteEvent
	{

		#region Constructors: Public

		public VwSiteEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSiteEvent";
		}

		public VwSiteEvent(VwSiteEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSiteEvent_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSiteEventDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSiteEventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSiteEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSiteEvent_EventTrackingEventsProcess

	/// <exclude/>
	public partial class VwSiteEvent_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.SiteEvent_EventTrackingEventsProcess<TEntity> where TEntity : VwSiteEvent
	{

		public VwSiteEvent_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSiteEvent_EventTrackingEventsProcess";
			SchemaUId = new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("05d5c19a-1456-4783-ba8f-69ad2cf5c046");
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

	#region Class: VwSiteEvent_EventTrackingEventsProcess

	/// <exclude/>
	public class VwSiteEvent_EventTrackingEventsProcess : VwSiteEvent_EventTrackingEventsProcess<VwSiteEvent>
	{

		public VwSiteEvent_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSiteEvent_EventTrackingEventsProcess

	public partial class VwSiteEvent_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSiteEventEventsProcess

	/// <exclude/>
	public class VwSiteEventEventsProcess : VwSiteEvent_EventTrackingEventsProcess
	{

		public VwSiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

