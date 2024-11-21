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

	#region Class: CampaignTypeSchema

	/// <exclude/>
	public class CampaignTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CampaignTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignTypeSchema(CampaignTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignTypeSchema(CampaignTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70");
			RealUId = new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70");
			Name = "CampaignType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("616f6b2e-6378-4a93-a6db-05b9923408d1")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("616f6b2e-6378-4a93-a6db-05b9923408d1"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70"),
				ModifiedInSchemaUId = new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70"),
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
			return new CampaignType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignType_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignType

	/// <summary>
	/// Тип кампании.
	/// </summary>
	public class CampaignType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CampaignType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignType";
		}

		public CampaignType(CampaignType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignType_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignType_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignType_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CampaignType
	{

		public CampaignType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignType_CampaignsEventsProcess";
			SchemaUId = new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c108f0cd-e885-45c8-8f15-3a0929c05a70");
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

	#region Class: CampaignType_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignType_CampaignsEventsProcess : CampaignType_CampaignsEventsProcess<CampaignType>
	{

		public CampaignType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignType_CampaignsEventsProcess

	public partial class CampaignType_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignTypeEventsProcess

	/// <exclude/>
	public class CampaignTypeEventsProcess : CampaignType_CampaignsEventsProcess
	{

		public CampaignTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

