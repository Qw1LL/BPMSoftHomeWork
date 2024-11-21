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

	#region Class: CampaignFirePeriodSchema

	/// <exclude/>
	public class CampaignFirePeriodSchema : BPMSoft.Configuration.BaseValueLookupSchema
	{

		#region Constructors: Public

		public CampaignFirePeriodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignFirePeriodSchema(CampaignFirePeriodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignFirePeriodSchema(CampaignFirePeriodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f913db0b-2734-4b46-8a7a-fbe9c6244ad9");
			RealUId = new Guid("f913db0b-2734-4b46-8a7a-fbe9c6244ad9");
			Name = "CampaignFirePeriod";
			ParentSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ef1d1d78-1c12-4a7c-8c82-0ea80dfcc2c0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignFirePeriod(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignFirePeriod_CampaignDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignFirePeriodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignFirePeriodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f913db0b-2734-4b46-8a7a-fbe9c6244ad9"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFirePeriod

	/// <summary>
	/// Период выполнения кампании.
	/// </summary>
	public class CampaignFirePeriod : BPMSoft.Configuration.BaseValueLookup
	{

		#region Constructors: Public

		public CampaignFirePeriod(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignFirePeriod";
		}

		public CampaignFirePeriod(CampaignFirePeriod source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignFirePeriod_CampaignDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignFirePeriodDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignFirePeriodValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignFirePeriod(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFirePeriod_CampaignDesignerEventsProcess

	/// <exclude/>
	public partial class CampaignFirePeriod_CampaignDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseValueLookup_BaseEventsProcess<TEntity> where TEntity : CampaignFirePeriod
	{

		public CampaignFirePeriod_CampaignDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignFirePeriod_CampaignDesignerEventsProcess";
			SchemaUId = new Guid("f913db0b-2734-4b46-8a7a-fbe9c6244ad9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f913db0b-2734-4b46-8a7a-fbe9c6244ad9");
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

	#region Class: CampaignFirePeriod_CampaignDesignerEventsProcess

	/// <exclude/>
	public class CampaignFirePeriod_CampaignDesignerEventsProcess : CampaignFirePeriod_CampaignDesignerEventsProcess<CampaignFirePeriod>
	{

		public CampaignFirePeriod_CampaignDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignFirePeriod_CampaignDesignerEventsProcess

	public partial class CampaignFirePeriod_CampaignDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignFirePeriodEventsProcess

	/// <exclude/>
	public class CampaignFirePeriodEventsProcess : CampaignFirePeriod_CampaignDesignerEventsProcess
	{

		public CampaignFirePeriodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

