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

	#region Class: LinkContactToAccountSchema

	/// <exclude/>
	public class LinkContactToAccountSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public LinkContactToAccountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LinkContactToAccountSchema(LinkContactToAccountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LinkContactToAccountSchema(LinkContactToAccountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			RealUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			Name = "LinkContactToAccount";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LinkContactToAccount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LinkContactToAccount_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LinkContactToAccountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LinkContactToAccountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c1021cc-4836-4355-977e-f65c332d92be"));
		}

		#endregion

	}

	#endregion

	#region Class: LinkContactToAccount

	/// <summary>
	/// Connecting contact to account.
	/// </summary>
	public class LinkContactToAccount : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public LinkContactToAccount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LinkContactToAccount";
		}

		public LinkContactToAccount(LinkContactToAccount source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LinkContactToAccount_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LinkContactToAccountDeleted", e);
			Inserting += (s, e) => ThrowEvent("LinkContactToAccountInserting", e);
			Validating += (s, e) => ThrowEvent("LinkContactToAccountValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LinkContactToAccount(this);
		}

		#endregion

	}

	#endregion

	#region Class: LinkContactToAccount_ExchangeEventsProcess

	/// <exclude/>
	public partial class LinkContactToAccount_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : LinkContactToAccount
	{

		public LinkContactToAccount_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LinkContactToAccount_ExchangeEventsProcess";
			SchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8c1021cc-4836-4355-977e-f65c332d92be");
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

	#region Class: LinkContactToAccount_ExchangeEventsProcess

	/// <exclude/>
	public class LinkContactToAccount_ExchangeEventsProcess : LinkContactToAccount_ExchangeEventsProcess<LinkContactToAccount>
	{

		public LinkContactToAccount_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LinkContactToAccount_ExchangeEventsProcess

	public partial class LinkContactToAccount_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LinkContactToAccountEventsProcess

	/// <exclude/>
	public class LinkContactToAccountEventsProcess : LinkContactToAccount_ExchangeEventsProcess
	{

		public LinkContactToAccountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

