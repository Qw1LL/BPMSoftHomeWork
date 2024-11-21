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

	#region Class: EmailSendStatusSchema

	/// <exclude/>
	public class EmailSendStatusSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public EmailSendStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailSendStatusSchema(EmailSendStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailSendStatusSchema(EmailSendStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644");
			RealUId = new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644");
			Name = "EmailSendStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			return new EmailSendStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailSendStatus_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailSendStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailSendStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailSendStatus

	/// <summary>
	/// Email Status.
	/// </summary>
	public class EmailSendStatus : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public EmailSendStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailSendStatus";
		}

		public EmailSendStatus(EmailSendStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailSendStatus_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailSendStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("EmailSendStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("EmailSendStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("EmailSendStatusInserting", e);
			Saved += (s, e) => ThrowEvent("EmailSendStatusSaved", e);
			Saving += (s, e) => ThrowEvent("EmailSendStatusSaving", e);
			Validating += (s, e) => ThrowEvent("EmailSendStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailSendStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailSendStatus_BaseEventsProcess

	/// <exclude/>
	public partial class EmailSendStatus_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : EmailSendStatus
	{

		public EmailSendStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailSendStatus_BaseEventsProcess";
			SchemaUId = new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644");
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

	#region Class: EmailSendStatus_BaseEventsProcess

	/// <exclude/>
	public class EmailSendStatus_BaseEventsProcess : EmailSendStatus_BaseEventsProcess<EmailSendStatus>
	{

		public EmailSendStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailSendStatus_BaseEventsProcess

	public partial class EmailSendStatus_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailSendStatusEventsProcess

	/// <exclude/>
	public class EmailSendStatusEventsProcess : EmailSendStatus_BaseEventsProcess
	{

		public EmailSendStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

