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

	#region Class: MailSyncPeriodSchema

	/// <exclude/>
	public class MailSyncPeriodSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public MailSyncPeriodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailSyncPeriodSchema(MailSyncPeriodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailSyncPeriodSchema(MailSyncPeriodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			RealUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			Name = "MailSyncPeriod";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("35f1cb11-2561-4729-8ddb-51fde1dc9648")) == null) {
				Columns.Add(CreateNumberColumn());
			}
			if (Columns.FindByUId(new Guid("eec3522f-31d8-473e-9469-baaf6cf58b33")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("35f1cb11-2561-4729-8ddb-51fde1dc9648"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("eec3522f-31d8-473e-9469-baaf6cf58b33"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				ModifiedInSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailSyncPeriod(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailSyncPeriod_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailSyncPeriodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailSyncPeriodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"));
		}

		#endregion

	}

	#endregion

	#region Class: MailSyncPeriod

	/// <summary>
	/// Email synchronization period.
	/// </summary>
	public class MailSyncPeriod : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public MailSyncPeriod(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailSyncPeriod";
		}

		public MailSyncPeriod(MailSyncPeriod source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Quantity.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Position in the list.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailSyncPeriod_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailSyncPeriodDeleted", e);
			Inserting += (s, e) => ThrowEvent("MailSyncPeriodInserting", e);
			Validating += (s, e) => ThrowEvent("MailSyncPeriodValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailSyncPeriod(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailSyncPeriod_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailSyncPeriod_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : MailSyncPeriod
	{

		public MailSyncPeriod_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailSyncPeriod_ExchangeEventsProcess";
			SchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5");
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

	#region Class: MailSyncPeriod_ExchangeEventsProcess

	/// <exclude/>
	public class MailSyncPeriod_ExchangeEventsProcess : MailSyncPeriod_ExchangeEventsProcess<MailSyncPeriod>
	{

		public MailSyncPeriod_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailSyncPeriod_ExchangeEventsProcess

	public partial class MailSyncPeriod_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailSyncPeriodEventsProcess

	/// <exclude/>
	public class MailSyncPeriodEventsProcess : MailSyncPeriod_ExchangeEventsProcess
	{

		public MailSyncPeriodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

