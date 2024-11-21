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

	#region Class: PRMTransactionSchema

	/// <exclude/>
	public class PRMTransactionSchema : BPMSoft.Configuration.PRMTransaction_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PRMTransactionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PRMTransactionSchema(PRMTransactionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PRMTransactionSchema(PRMTransactionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("42f0c108-5b5d-4746-a0df-979fffdc183c");
			Name = "PRMTransaction";
			ParentSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0fffc5a3-cd85-4e12-bfdb-f47322f14e3d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreatePartnershipColumn();
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
			return new PRMTransaction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PRMTransaction_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PRMTransactionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PRMTransactionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42f0c108-5b5d-4746-a0df-979fffdc183c"));
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransaction

	/// <summary>
	/// Операция.
	/// </summary>
	public class PRMTransaction : BPMSoft.Configuration.PRMTransaction_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PRMTransaction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PRMTransaction";
		}

		public PRMTransaction(PRMTransaction source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PRMTransaction_PRMPortalEventsProcess(UserConnection);
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
			return new PRMTransaction(this);
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransaction_PRMPortalEventsProcess

	/// <exclude/>
	public partial class PRMTransaction_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.PRMTransaction_PRMBaseEventsProcess<TEntity> where TEntity : PRMTransaction
	{

		public PRMTransaction_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PRMTransaction_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("42f0c108-5b5d-4746-a0df-979fffdc183c");
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

	#region Class: PRMTransaction_PRMPortalEventsProcess

	/// <exclude/>
	public class PRMTransaction_PRMPortalEventsProcess : PRMTransaction_PRMPortalEventsProcess<PRMTransaction>
	{

		public PRMTransaction_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PRMTransaction_PRMPortalEventsProcess

	public partial class PRMTransaction_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PRMTransactionEventsProcess

	/// <exclude/>
	public class PRMTransactionEventsProcess : PRMTransaction_PRMPortalEventsProcess
	{

		public PRMTransactionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

