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

	#region Class: EmailDeliveryScheduleSchema

	/// <exclude/>
	public class EmailDeliveryScheduleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EmailDeliveryScheduleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailDeliveryScheduleSchema(EmailDeliveryScheduleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailDeliveryScheduleSchema(EmailDeliveryScheduleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2");
			RealUId = new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2");
			Name = "EmailDeliverySchedule";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
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
			return new EmailDeliverySchedule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailDeliverySchedule_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailDeliveryScheduleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailDeliveryScheduleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailDeliverySchedule

	/// <summary>
	/// График доставки рассылки.
	/// </summary>
	public class EmailDeliverySchedule : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EmailDeliverySchedule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailDeliverySchedule";
		}

		public EmailDeliverySchedule(EmailDeliverySchedule source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailDeliverySchedule_BulkEmailEventsProcess(UserConnection);
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
			return new EmailDeliverySchedule(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailDeliverySchedule_BulkEmailEventsProcess

	/// <exclude/>
	public partial class EmailDeliverySchedule_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : EmailDeliverySchedule
	{

		public EmailDeliverySchedule_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailDeliverySchedule_BulkEmailEventsProcess";
			SchemaUId = new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2");
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

	#region Class: EmailDeliverySchedule_BulkEmailEventsProcess

	/// <exclude/>
	public class EmailDeliverySchedule_BulkEmailEventsProcess : EmailDeliverySchedule_BulkEmailEventsProcess<EmailDeliverySchedule>
	{

		public EmailDeliverySchedule_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailDeliverySchedule_BulkEmailEventsProcess

	public partial class EmailDeliverySchedule_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailDeliveryScheduleEventsProcess

	/// <exclude/>
	public class EmailDeliveryScheduleEventsProcess : EmailDeliverySchedule_BulkEmailEventsProcess
	{

		public EmailDeliveryScheduleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

