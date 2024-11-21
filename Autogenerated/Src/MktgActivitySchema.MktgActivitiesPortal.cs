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

	#region Class: MktgActivity_MktgActivitiesPortal_BPMSoftSchema

	/// <exclude/>
	public class MktgActivity_MktgActivitiesPortal_BPMSoftSchema : BPMSoft.Configuration.MktgActivity_CampaignPlannerNew_BPMSoftSchema
	{

		#region Constructors: Public

		public MktgActivity_MktgActivitiesPortal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivity_MktgActivitiesPortal_BPMSoftSchema(MktgActivity_MktgActivitiesPortal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivity_MktgActivitiesPortal_BPMSoftSchema(MktgActivity_MktgActivitiesPortal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("baad8067-d5a4-4d1f-99cb-5cdcf20390f9");
			Name = "MktgActivity_MktgActivitiesPortal_BPMSoft";
			ParentSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
			ExtendParent = true;
			CreatedInPackageId = new Guid("953f0566-aec2-4fe6-ac9c-5286e561cdf9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d0c704c7-e0b0-42eb-b603-555ed827cc46")) == null) {
				Columns.Add(CreateMktgActivityTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMktgActivityTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d0c704c7-e0b0-42eb-b603-555ed827cc46"),
				Name = @"MktgActivityType",
				ReferenceSchemaUId = new Guid("13f1c29e-a68f-45c8-96c4-ad29b60ee5c2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("baad8067-d5a4-4d1f-99cb-5cdcf20390f9"),
				ModifiedInSchemaUId = new Guid("baad8067-d5a4-4d1f-99cb-5cdcf20390f9"),
				CreatedInPackageId = new Guid("12438ade-fc27-4c74-b597-0ce1b90fa1ec")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MktgActivity_MktgActivitiesPortal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivity_MktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivity_MktgActivitiesPortal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivity_MktgActivitiesPortal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("baad8067-d5a4-4d1f-99cb-5cdcf20390f9"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_MktgActivitiesPortal_BPMSoft

	/// <summary>
	/// Маркетинговая активность.
	/// </summary>
	public class MktgActivity_MktgActivitiesPortal_BPMSoft : BPMSoft.Configuration.MktgActivity_CampaignPlannerNew_BPMSoft
	{

		#region Constructors: Public

		public MktgActivity_MktgActivitiesPortal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivity_MktgActivitiesPortal_BPMSoft";
		}

		public MktgActivity_MktgActivitiesPortal_BPMSoft(MktgActivity_MktgActivitiesPortal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MktgActivityTypeId {
			get {
				return GetTypedColumnValue<Guid>("MktgActivityTypeId");
			}
			set {
				SetColumnValue("MktgActivityTypeId", value);
				_mktgActivityType = null;
			}
		}

		/// <exclude/>
		public string MktgActivityTypeName {
			get {
				return GetTypedColumnValue<string>("MktgActivityTypeName");
			}
			set {
				SetColumnValue("MktgActivityTypeName", value);
				if (_mktgActivityType != null) {
					_mktgActivityType.Name = value;
				}
			}
		}

		private MktgActivityType _mktgActivityType;
		/// <summary>
		/// Тип.
		/// </summary>
		public MktgActivityType MktgActivityType {
			get {
				return _mktgActivityType ??
					(_mktgActivityType = LookupColumnEntities.GetEntity("MktgActivityType") as MktgActivityType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MktgActivity_MktgActivitiesPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivity_MktgActivitiesPortal_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("MktgActivity_MktgActivitiesPortal_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivity_MktgActivitiesPortal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_MktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class MktgActivity_MktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.MktgActivity_CampaignPlannerNewEventsProcess<TEntity> where TEntity : MktgActivity_MktgActivitiesPortal_BPMSoft
	{

		public MktgActivity_MktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivity_MktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("baad8067-d5a4-4d1f-99cb-5cdcf20390f9");
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

	#region Class: MktgActivity_MktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class MktgActivity_MktgActivitiesPortalEventsProcess : MktgActivity_MktgActivitiesPortalEventsProcess<MktgActivity_MktgActivitiesPortal_BPMSoft>
	{

		public MktgActivity_MktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivity_MktgActivitiesPortalEventsProcess

	public partial class MktgActivity_MktgActivitiesPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

