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

	#region Class: PaymentTypeSchema

	/// <exclude/>
	public class PaymentTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PaymentTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PaymentTypeSchema(PaymentTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PaymentTypeSchema(PaymentTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d6072ff-8b5d-4fb8-83df-f07b403028e7");
			RealUId = new Guid("9d6072ff-8b5d-4fb8-83df-f07b403028e7");
			Name = "PaymentType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dc9b0a8f-3f62-409f-a803-948a13d96822");
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
			return new PaymentType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PaymentType_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PaymentTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PaymentTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d6072ff-8b5d-4fb8-83df-f07b403028e7"));
		}

		#endregion

	}

	#endregion

	#region Class: PaymentType

	/// <summary>
	/// Тип оплаты.
	/// </summary>
	public class PaymentType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PaymentType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PaymentType";
		}

		public PaymentType(PaymentType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PaymentType_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PaymentTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("PaymentTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PaymentType(this);
		}

		#endregion

	}

	#endregion

	#region Class: PaymentType_OrderEventsProcess

	/// <exclude/>
	public partial class PaymentType_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : PaymentType
	{

		public PaymentType_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PaymentType_OrderEventsProcess";
			SchemaUId = new Guid("9d6072ff-8b5d-4fb8-83df-f07b403028e7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9d6072ff-8b5d-4fb8-83df-f07b403028e7");
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

	#region Class: PaymentType_OrderEventsProcess

	/// <exclude/>
	public class PaymentType_OrderEventsProcess : PaymentType_OrderEventsProcess<PaymentType>
	{

		public PaymentType_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PaymentType_OrderEventsProcess

	public partial class PaymentType_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PaymentTypeEventsProcess

	/// <exclude/>
	public class PaymentTypeEventsProcess : PaymentType_OrderEventsProcess
	{

		public PaymentTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

