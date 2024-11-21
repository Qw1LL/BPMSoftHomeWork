namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Passport;
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

	#region Class: SupplyPaymentProductSchema

	/// <exclude/>
	public class SupplyPaymentProductSchema : BPMSoft.Configuration.SupplyPaymentProduct_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public SupplyPaymentProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentProductSchema(SupplyPaymentProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentProductSchema(SupplyPaymentProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ef2e2118-0cae-4216-8649-64e30759b29d");
			Name = "SupplyPaymentProduct";
			ParentSchemaUId = new Guid("5e50c5fa-41cc-4c91-a04f-9d7888236c1c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("fb295fc3-2fbd-4310-9f4f-726412c4ea00");
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
			return new SupplyPaymentProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentProduct_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef2e2118-0cae-4216-8649-64e30759b29d"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentProduct

	/// <summary>
	/// Продукты графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentProduct : BPMSoft.Configuration.SupplyPaymentProduct_Passport_BPMSoft
	{

		#region Constructors: Public

		public SupplyPaymentProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentProduct";
		}

		public SupplyPaymentProduct(SupplyPaymentProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentProduct_PRMOrderEventsProcess(UserConnection);
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
			return new SupplyPaymentProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentProduct_PRMOrderEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentProduct_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.SupplyPaymentProduct_PassportEventsProcess<TEntity> where TEntity : SupplyPaymentProduct
	{

		public SupplyPaymentProduct_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentProduct_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef2e2118-0cae-4216-8649-64e30759b29d");
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

	#region Class: SupplyPaymentProduct_PRMOrderEventsProcess

	/// <exclude/>
	public class SupplyPaymentProduct_PRMOrderEventsProcess : SupplyPaymentProduct_PRMOrderEventsProcess<SupplyPaymentProduct>
	{

		public SupplyPaymentProduct_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentProduct_PRMOrderEventsProcess

	public partial class SupplyPaymentProduct_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SupplyPaymentProductEventsProcess

	/// <exclude/>
	public class SupplyPaymentProductEventsProcess : SupplyPaymentProduct_PRMOrderEventsProcess
	{

		public SupplyPaymentProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

