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

	#region Class: LeadProductSchema

	/// <exclude/>
	public class LeadProductSchema : BPMSoft.Configuration.LeadProduct_CoreLead_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadProductSchema(LeadProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadProductSchema(LeadProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0d08779a-d162-40dd-ba72-0619421d8579");
			Name = "LeadProduct";
			ParentSchemaUId = new Guid("1f66152e-4108-49d8-9953-69045f06df88");
			ExtendParent = true;
			CreatedInPackageId = new Guid("10676561-1f93-46bf-90be-fe5cd67025e0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateLeadColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
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
			return new LeadProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadProduct_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0d08779a-d162-40dd-ba72-0619421d8579"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadProduct

	/// <summary>
	/// Продукты в лиде.
	/// </summary>
	public class LeadProduct : BPMSoft.Configuration.LeadProduct_CoreLead_BPMSoft
	{

		#region Constructors: Public

		public LeadProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadProduct";
		}

		public LeadProduct(LeadProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadProduct_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadProductDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadProduct_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadProduct_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadProduct_CoreLeadEventsProcess<TEntity> where TEntity : LeadProduct
	{

		public LeadProduct_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadProduct_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0d08779a-d162-40dd-ba72-0619421d8579");
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

	#region Class: LeadProduct_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadProduct_PRMPortalEventsProcess : LeadProduct_PRMPortalEventsProcess<LeadProduct>
	{

		public LeadProduct_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadProduct_PRMPortalEventsProcess

	public partial class LeadProduct_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadProductEventsProcess

	/// <exclude/>
	public class LeadProductEventsProcess : LeadProduct_PRMPortalEventsProcess
	{

		public LeadProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

