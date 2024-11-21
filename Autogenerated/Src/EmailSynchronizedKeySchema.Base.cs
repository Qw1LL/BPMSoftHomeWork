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

	#region Class: EmailSynchronizedKeySchema

	/// <exclude/>
	public class EmailSynchronizedKeySchema : BPMSoft.Configuration.BaseValueLookupSchema
	{

		#region Constructors: Public

		public EmailSynchronizedKeySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailSynchronizedKeySchema(EmailSynchronizedKeySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailSynchronizedKeySchema(EmailSynchronizedKeySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
			RealUId = new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
			Name = "EmailSynchronizedKey";
			ParentSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailSynchronizedKey(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailSynchronizedKey_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailSynchronizedKeySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailSynchronizedKeySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailSynchronizedKey

	/// <summary>
	/// Email synchronized key.
	/// </summary>
	public class EmailSynchronizedKey : BPMSoft.Configuration.BaseValueLookup
	{

		#region Constructors: Public

		public EmailSynchronizedKey(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailSynchronizedKey";
		}

		public EmailSynchronizedKey(EmailSynchronizedKey source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailSynchronizedKey_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailSynchronizedKeyDeleted", e);
			Validating += (s, e) => ThrowEvent("EmailSynchronizedKeyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailSynchronizedKey(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailSynchronizedKey_BaseEventsProcess

	/// <exclude/>
	public partial class EmailSynchronizedKey_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseValueLookup_BaseEventsProcess<TEntity> where TEntity : EmailSynchronizedKey
	{

		public EmailSynchronizedKey_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailSynchronizedKey_BaseEventsProcess";
			SchemaUId = new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("75734335-e9e3-43e5-b1f8-cb969e97037b");
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

	#region Class: EmailSynchronizedKey_BaseEventsProcess

	/// <exclude/>
	public class EmailSynchronizedKey_BaseEventsProcess : EmailSynchronizedKey_BaseEventsProcess<EmailSynchronizedKey>
	{

		public EmailSynchronizedKey_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailSynchronizedKey_BaseEventsProcess

	public partial class EmailSynchronizedKey_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailSynchronizedKeyEventsProcess

	/// <exclude/>
	public class EmailSynchronizedKeyEventsProcess : EmailSynchronizedKey_BaseEventsProcess
	{

		public EmailSynchronizedKeyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

