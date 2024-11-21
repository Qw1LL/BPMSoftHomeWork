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

	#region Class: SupplyPaymentType_Passport_BPMSoftSchema

	/// <exclude/>
	public class SupplyPaymentType_Passport_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SupplyPaymentType_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentType_Passport_BPMSoftSchema(SupplyPaymentType_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentType_Passport_BPMSoftSchema(SupplyPaymentType_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9876301-ffbc-4389-a53a-19413e3bd091");
			RealUId = new Guid("f9876301-ffbc-4389-a53a-19413e3bd091");
			Name = "SupplyPaymentType_Passport_BPMSoft";
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
			return new SupplyPaymentType_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentType_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentType_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentType_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9876301-ffbc-4389-a53a-19413e3bd091"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentType_Passport_BPMSoft

	/// <summary>
	/// Тип элемента графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentType_Passport_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SupplyPaymentType_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentType_Passport_BPMSoft";
		}

		public SupplyPaymentType_Passport_BPMSoft(SupplyPaymentType_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentType_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupplyPaymentType_Passport_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("SupplyPaymentType_Passport_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("SupplyPaymentType_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupplyPaymentType_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentType_PassportEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentType_PassportEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SupplyPaymentType_Passport_BPMSoft
	{

		public SupplyPaymentType_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentType_PassportEventsProcess";
			SchemaUId = new Guid("f9876301-ffbc-4389-a53a-19413e3bd091");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f9876301-ffbc-4389-a53a-19413e3bd091");
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

	#region Class: SupplyPaymentType_PassportEventsProcess

	/// <exclude/>
	public class SupplyPaymentType_PassportEventsProcess : SupplyPaymentType_PassportEventsProcess<SupplyPaymentType_Passport_BPMSoft>
	{

		public SupplyPaymentType_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentType_PassportEventsProcess

	public partial class SupplyPaymentType_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

