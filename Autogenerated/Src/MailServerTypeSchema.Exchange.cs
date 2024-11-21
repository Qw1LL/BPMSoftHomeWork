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

	#region Class: MailServerTypeSchema

	/// <exclude/>
	public class MailServerTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public MailServerTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailServerTypeSchema(MailServerTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailServerTypeSchema(MailServerTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			RealUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			Name = "MailServerType";
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
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
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
			return new MailServerType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailServerType_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailServerTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailServerTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be"));
		}

		#endregion

	}

	#endregion

	#region Class: MailServerType

	/// <summary>
	/// Mail service provider type.
	/// </summary>
	public class MailServerType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public MailServerType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServerType";
		}

		public MailServerType(MailServerType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailServerType_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailServerTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("MailServerTypeInserting", e);
			Validating += (s, e) => ThrowEvent("MailServerTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailServerType(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailServerType_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailServerType_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : MailServerType
	{

		public MailServerType_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailServerType_ExchangeEventsProcess";
			SchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be");
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

	#region Class: MailServerType_ExchangeEventsProcess

	/// <exclude/>
	public class MailServerType_ExchangeEventsProcess : MailServerType_ExchangeEventsProcess<MailServerType>
	{

		public MailServerType_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailServerType_ExchangeEventsProcess

	public partial class MailServerType_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailServerTypeEventsProcess

	/// <exclude/>
	public class MailServerTypeEventsProcess : MailServerType_ExchangeEventsProcess
	{

		public MailServerTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

