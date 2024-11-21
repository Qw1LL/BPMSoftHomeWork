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

	#region Class: DeliveryTypeSchema

	/// <exclude/>
	public class DeliveryTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DeliveryTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeliveryTypeSchema(DeliveryTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeliveryTypeSchema(DeliveryTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc257b41-06e9-468a-9ec2-39d4fcc920aa");
			RealUId = new Guid("dc257b41-06e9-468a-9ec2-39d4fcc920aa");
			Name = "DeliveryType";
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
			return new DeliveryType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeliveryType_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeliveryTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeliveryTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc257b41-06e9-468a-9ec2-39d4fcc920aa"));
		}

		#endregion

	}

	#endregion

	#region Class: DeliveryType

	/// <summary>
	/// Тип доставки.
	/// </summary>
	public class DeliveryType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DeliveryType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeliveryType";
		}

		public DeliveryType(DeliveryType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeliveryType_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DeliveryTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("DeliveryTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DeliveryType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeliveryType_OrderEventsProcess

	/// <exclude/>
	public partial class DeliveryType_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DeliveryType
	{

		public DeliveryType_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeliveryType_OrderEventsProcess";
			SchemaUId = new Guid("dc257b41-06e9-468a-9ec2-39d4fcc920aa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dc257b41-06e9-468a-9ec2-39d4fcc920aa");
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

	#region Class: DeliveryType_OrderEventsProcess

	/// <exclude/>
	public class DeliveryType_OrderEventsProcess : DeliveryType_OrderEventsProcess<DeliveryType>
	{

		public DeliveryType_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeliveryType_OrderEventsProcess

	public partial class DeliveryType_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeliveryTypeEventsProcess

	/// <exclude/>
	public class DeliveryTypeEventsProcess : DeliveryType_OrderEventsProcess
	{

		public DeliveryTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

