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

	#region Class: SupplyPaymentDelaySchema

	/// <exclude/>
	public class SupplyPaymentDelaySchema : BPMSoft.Configuration.SupplyPaymentDelay_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public SupplyPaymentDelaySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentDelaySchema(SupplyPaymentDelaySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentDelaySchema(SupplyPaymentDelaySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("efa8b196-0719-40b7-9029-24280ec8a550");
			Name = "SupplyPaymentDelay";
			ParentSchemaUId = new Guid("180c1fb4-d61b-4aca-b6b3-e1fae4eaab1b");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
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
			return new SupplyPaymentDelay(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentDelay_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentDelaySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentDelaySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efa8b196-0719-40b7-9029-24280ec8a550"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentDelay

	/// <summary>
	/// Тип отсрочки графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentDelay : BPMSoft.Configuration.SupplyPaymentDelay_Passport_BPMSoft
	{

		#region Constructors: Public

		public SupplyPaymentDelay(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentDelay";
		}

		public SupplyPaymentDelay(SupplyPaymentDelay source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentDelay_PRMOrderEventsProcess(UserConnection);
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
			return new SupplyPaymentDelay(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentDelay_PRMOrderEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentDelay_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.SupplyPaymentDelay_PassportEventsProcess<TEntity> where TEntity : SupplyPaymentDelay
	{

		public SupplyPaymentDelay_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentDelay_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("efa8b196-0719-40b7-9029-24280ec8a550");
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

	#region Class: SupplyPaymentDelay_PRMOrderEventsProcess

	/// <exclude/>
	public class SupplyPaymentDelay_PRMOrderEventsProcess : SupplyPaymentDelay_PRMOrderEventsProcess<SupplyPaymentDelay>
	{

		public SupplyPaymentDelay_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentDelay_PRMOrderEventsProcess

	public partial class SupplyPaymentDelay_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SupplyPaymentDelayEventsProcess

	/// <exclude/>
	public class SupplyPaymentDelayEventsProcess : SupplyPaymentDelay_PRMOrderEventsProcess
	{

		public SupplyPaymentDelayEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

