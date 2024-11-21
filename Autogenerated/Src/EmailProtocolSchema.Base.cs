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

	#region Class: EmailProtocolSchema

	/// <exclude/>
	public class EmailProtocolSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EmailProtocolSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailProtocolSchema(EmailProtocolSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailProtocolSchema(EmailProtocolSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			RealUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			Name = "EmailProtocol";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailProtocol(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailProtocol_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailProtocolSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailProtocolSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailProtocol

	/// <summary>
	/// Connection protocol.
	/// </summary>
	public class EmailProtocol : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EmailProtocol(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailProtocol";
		}

		public EmailProtocol(EmailProtocol source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailProtocol_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailProtocolDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailProtocolInserting", e);
			Validating += (s, e) => ThrowEvent("EmailProtocolValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailProtocol(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailProtocol_BaseEventsProcess

	/// <exclude/>
	public partial class EmailProtocol_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : EmailProtocol
	{

		public EmailProtocol_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailProtocol_BaseEventsProcess";
			SchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
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

	#region Class: EmailProtocol_BaseEventsProcess

	/// <exclude/>
	public class EmailProtocol_BaseEventsProcess : EmailProtocol_BaseEventsProcess<EmailProtocol>
	{

		public EmailProtocol_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailProtocol_BaseEventsProcess

	public partial class EmailProtocol_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailProtocolEventsProcess

	/// <exclude/>
	public class EmailProtocolEventsProcess : EmailProtocol_BaseEventsProcess
	{

		public EmailProtocolEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

