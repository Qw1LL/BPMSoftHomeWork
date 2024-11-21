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

	#region Class: SupplyPaymentState_Passport_BPMSoftSchema

	/// <exclude/>
	public class SupplyPaymentState_Passport_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SupplyPaymentState_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentState_Passport_BPMSoftSchema(SupplyPaymentState_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentState_Passport_BPMSoftSchema(SupplyPaymentState_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("270f817e-6b26-499c-8a5a-61d02846ee36");
			RealUId = new Guid("270f817e-6b26-499c-8a5a-61d02846ee36");
			Name = "SupplyPaymentState_Passport_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
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
			return new SupplyPaymentState_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentState_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentState_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentState_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("270f817e-6b26-499c-8a5a-61d02846ee36"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentState_Passport_BPMSoft

	/// <summary>
	/// Состояние элемента графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentState_Passport_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SupplyPaymentState_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentState_Passport_BPMSoft";
		}

		public SupplyPaymentState_Passport_BPMSoft(SupplyPaymentState_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentState_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupplyPaymentState_Passport_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("SupplyPaymentState_Passport_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("SupplyPaymentState_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupplyPaymentState_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentState_PassportEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentState_PassportEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SupplyPaymentState_Passport_BPMSoft
	{

		public SupplyPaymentState_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentState_PassportEventsProcess";
			SchemaUId = new Guid("270f817e-6b26-499c-8a5a-61d02846ee36");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("270f817e-6b26-499c-8a5a-61d02846ee36");
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

	#region Class: SupplyPaymentState_PassportEventsProcess

	/// <exclude/>
	public class SupplyPaymentState_PassportEventsProcess : SupplyPaymentState_PassportEventsProcess<SupplyPaymentState_Passport_BPMSoft>
	{

		public SupplyPaymentState_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentState_PassportEventsProcess

	public partial class SupplyPaymentState_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

