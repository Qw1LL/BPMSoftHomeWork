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

	#region Class: ExternalAccessRequestLogSchema

	/// <exclude/>
	public class ExternalAccessRequestLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ExternalAccessRequestLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessRequestLogSchema(ExternalAccessRequestLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessRequestLogSchema(ExternalAccessRequestLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c2e08627-9369-46eb-af93-915027749e26");
			RealUId = new Guid("c2e08627-9369-46eb-af93-915027749e26");
			Name = "ExternalAccessRequestLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("658b0029-7f34-4623-80d0-bdc713bd5f65")) == null) {
				Columns.Add(CreateRequestedOnColumn());
			}
			if (Columns.FindByUId(new Guid("e2c78863-9242-467f-a2fd-653923fab46b")) == null) {
				Columns.Add(CreateRequestedByColumn());
			}
			if (Columns.FindByUId(new Guid("cc2e9911-ea1c-43e5-bfd3-143afa55c062")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("46b0728b-ce25-4936-b560-9bc9fc85f504")) == null) {
				Columns.Add(CreateCustomerIdColumn());
			}
			if (Columns.FindByUId(new Guid("59970abc-492f-4fc2-908d-e6e7afb7df84")) == null) {
				Columns.Add(CreateExternalAccessIdColumn());
			}
			if (Columns.FindByUId(new Guid("0ee1f516-ac31-40dc-8fbe-078d254a2f51")) == null) {
				Columns.Add(CreateExternalAccessDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRequestedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("658b0029-7f34-4623-80d0-bdc713bd5f65"),
				Name = @"RequestedOn",
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRequestedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e2c78863-9242-467f-a2fd-653923fab46b"),
				Name = @"RequestedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cc2e9911-ea1c-43e5-bfd3-143afa55c062"),
				Name = @"Url",
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected virtual EntitySchemaColumn CreateCustomerIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("46b0728b-ce25-4936-b560-9bc9fc85f504"),
				Name = @"CustomerId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalAccessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("59970abc-492f-4fc2-908d-e6e7afb7df84"),
				Name = @"ExternalAccessId",
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalAccessDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0ee1f516-ac31-40dc-8fbe-078d254a2f51"),
				Name = @"ExternalAccessDescription",
				CreatedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				ModifiedInSchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessRequestLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessRequestLog_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessRequestLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessRequestLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c2e08627-9369-46eb-af93-915027749e26"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessRequestLog

	/// <summary>
	/// External access request log.
	/// </summary>
	public class ExternalAccessRequestLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ExternalAccessRequestLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessRequestLog";
		}

		public ExternalAccessRequestLog(ExternalAccessRequestLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime RequestedOn {
			get {
				return GetTypedColumnValue<DateTime>("RequestedOn");
			}
			set {
				SetColumnValue("RequestedOn", value);
			}
		}

		/// <exclude/>
		public Guid RequestedById {
			get {
				return GetTypedColumnValue<Guid>("RequestedById");
			}
			set {
				SetColumnValue("RequestedById", value);
				_requestedBy = null;
			}
		}

		/// <exclude/>
		public string RequestedByName {
			get {
				return GetTypedColumnValue<string>("RequestedByName");
			}
			set {
				SetColumnValue("RequestedByName", value);
				if (_requestedBy != null) {
					_requestedBy.Name = value;
				}
			}
		}

		private Contact _requestedBy;
		/// <summary>
		/// User.
		/// </summary>
		public Contact RequestedBy {
			get {
				return _requestedBy ??
					(_requestedBy = LookupColumnEntities.GetEntity("RequestedBy") as Contact);
			}
		}

		/// <summary>
		/// Site URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// Subscription.
		/// </summary>
		public string CustomerId {
			get {
				return GetTypedColumnValue<string>("CustomerId");
			}
			set {
				SetColumnValue("CustomerId", value);
			}
		}

		/// <summary>
		/// External access id.
		/// </summary>
		public Guid ExternalAccessId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessId");
			}
			set {
				SetColumnValue("ExternalAccessId", value);
			}
		}

		/// <summary>
		/// Access description.
		/// </summary>
		public string ExternalAccessDescription {
			get {
				return GetTypedColumnValue<string>("ExternalAccessDescription");
			}
			set {
				SetColumnValue("ExternalAccessDescription", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessRequestLog_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessRequestLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessRequestLog_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessRequestLog_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ExternalAccessRequestLog
	{

		public ExternalAccessRequestLog_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessRequestLog_ExternalAccessEventsProcess";
			SchemaUId = new Guid("c2e08627-9369-46eb-af93-915027749e26");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c2e08627-9369-46eb-af93-915027749e26");
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

	#region Class: ExternalAccessRequestLog_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessRequestLog_ExternalAccessEventsProcess : ExternalAccessRequestLog_ExternalAccessEventsProcess<ExternalAccessRequestLog>
	{

		public ExternalAccessRequestLog_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessRequestLog_ExternalAccessEventsProcess

	public partial class ExternalAccessRequestLog_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessRequestLogEventsProcess

	/// <exclude/>
	public class ExternalAccessRequestLogEventsProcess : ExternalAccessRequestLog_ExternalAccessEventsProcess
	{

		public ExternalAccessRequestLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

