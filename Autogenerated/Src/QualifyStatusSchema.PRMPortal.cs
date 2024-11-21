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

	#region Class: QualifyStatusSchema

	/// <exclude/>
	public class QualifyStatusSchema : BPMSoft.Configuration.QualifyStatus_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public QualifyStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QualifyStatusSchema(QualifyStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QualifyStatusSchema(QualifyStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6dc9d73a-8356-4a8e-8d26-93a944e3a57e");
			Name = "QualifyStatus";
			ParentSchemaUId = new Guid("22341cd1-5b33-4c40-9011-6f7693ef6e44");
			ExtendParent = true;
			CreatedInPackageId = new Guid("1bc37faf-30bf-4d4a-b067-5fd52b4ccffd");
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
			return new QualifyStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QualifyStatus_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QualifyStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QualifyStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6dc9d73a-8356-4a8e-8d26-93a944e3a57e"));
		}

		#endregion

	}

	#endregion

	#region Class: QualifyStatus

	/// <summary>
	/// QualifyStatus.
	/// </summary>
	public class QualifyStatus : BPMSoft.Configuration.QualifyStatus_Lead_BPMSoft
	{

		#region Constructors: Public

		public QualifyStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QualifyStatus";
		}

		public QualifyStatus(QualifyStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QualifyStatus_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QualifyStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("QualifyStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QualifyStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: QualifyStatus_PRMPortalEventsProcess

	/// <exclude/>
	public partial class QualifyStatus_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.QualifyStatus_LeadEventsProcess<TEntity> where TEntity : QualifyStatus
	{

		public QualifyStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QualifyStatus_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6dc9d73a-8356-4a8e-8d26-93a944e3a57e");
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

	#region Class: QualifyStatus_PRMPortalEventsProcess

	/// <exclude/>
	public class QualifyStatus_PRMPortalEventsProcess : QualifyStatus_PRMPortalEventsProcess<QualifyStatus>
	{

		public QualifyStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QualifyStatus_PRMPortalEventsProcess

	public partial class QualifyStatus_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QualifyStatusEventsProcess

	/// <exclude/>
	public class QualifyStatusEventsProcess : QualifyStatus_PRMPortalEventsProcess
	{

		public QualifyStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

