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

	#region Class: TouchEventLogSchema

	/// <exclude/>
	public class TouchEventLogSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TouchEventLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TouchEventLogSchema(TouchEventLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TouchEventLogSchema(TouchEventLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992");
			RealUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992");
			Name = "TouchEventLog";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("db2ab788-e61e-cb38-e8fd-c773b2cc0f0a")) == null) {
				Columns.Add(CreateHasErrorsColumn());
			}
			if (Columns.FindByUId(new Guid("0447df34-49ad-c11e-c736-00df2be5cfc7")) == null) {
				Columns.Add(CreateErrorDetailsColumn());
			}
			if (Columns.FindByUId(new Guid("8e05fcec-7293-a0fb-c934-cae4e6dc309b")) == null) {
				Columns.Add(CreateTrackingColumn());
			}
			if (Columns.FindByUId(new Guid("910d29b8-cd97-09c9-2094-6cf12edbd887")) == null) {
				Columns.Add(CreateMessageTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("adf53b5a-08b4-4bac-787d-88a2485b522c")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("04caa6e1-cdd3-1bad-dfbf-64aa07a7be44")) == null) {
				Columns.Add(CreateAmountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateHasErrorsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("db2ab788-e61e-cb38-e8fd-c773b2cc0f0a"),
				Name = @"HasErrors",
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateErrorDetailsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0447df34-49ad-c11e-c736-00df2be5cfc7"),
				Name = @"ErrorDetails",
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateTrackingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e05fcec-7293-a0fb-c934-cae4e6dc309b"),
				Name = @"Tracking",
				ReferenceSchemaUId = new Guid("b8e1d2fb-7852-4843-815b-a547470f412a"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("910d29b8-cd97-09c9-2094-6cf12edbd887"),
				Name = @"MessageTypeName",
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("adf53b5a-08b4-4bac-787d-88a2485b522c"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("04caa6e1-cdd3-1bad-dfbf-64aa07a7be44"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				ModifiedInSchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TouchEventLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TouchEventLog_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TouchEventLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TouchEventLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992"));
		}

		#endregion

	}

	#endregion

	#region Class: TouchEventLog

	/// <summary>
	/// Touch event log.
	/// </summary>
	public class TouchEventLog : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TouchEventLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchEventLog";
		}

		public TouchEventLog(TouchEventLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Has errors.
		/// </summary>
		public bool HasErrors {
			get {
				return GetTypedColumnValue<bool>("HasErrors");
			}
			set {
				SetColumnValue("HasErrors", value);
			}
		}

		/// <summary>
		/// Error details.
		/// </summary>
		public string ErrorDetails {
			get {
				return GetTypedColumnValue<string>("ErrorDetails");
			}
			set {
				SetColumnValue("ErrorDetails", value);
			}
		}

		/// <exclude/>
		public Guid TrackingId {
			get {
				return GetTypedColumnValue<Guid>("TrackingId");
			}
			set {
				SetColumnValue("TrackingId", value);
				_tracking = null;
			}
		}

		/// <exclude/>
		public string TrackingName {
			get {
				return GetTypedColumnValue<string>("TrackingName");
			}
			set {
				SetColumnValue("TrackingName", value);
				if (_tracking != null) {
					_tracking.Name = value;
				}
			}
		}

		private TouchEventTracking _tracking;
		/// <summary>
		/// Tracking.
		/// </summary>
		public TouchEventTracking Tracking {
			get {
				return _tracking ??
					(_tracking = LookupColumnEntities.GetEntity("Tracking") as TouchEventTracking);
			}
		}

		/// <summary>
		/// Message type.
		/// </summary>
		public string MessageTypeName {
			get {
				return GetTypedColumnValue<string>("MessageTypeName");
			}
			set {
				SetColumnValue("MessageTypeName", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Amount.
		/// </summary>
		public int Amount {
			get {
				return GetTypedColumnValue<int>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TouchEventLog_TouchPointsEventsProcess(UserConnection);
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
			return new TouchEventLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: TouchEventLog_TouchPointsEventsProcess

	/// <exclude/>
	public partial class TouchEventLog_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TouchEventLog
	{

		public TouchEventLog_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TouchEventLog_TouchPointsEventsProcess";
			SchemaUId = new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3c867b56-1c4b-4b9c-9cb7-ed072edd0992");
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

	#region Class: TouchEventLog_TouchPointsEventsProcess

	/// <exclude/>
	public class TouchEventLog_TouchPointsEventsProcess : TouchEventLog_TouchPointsEventsProcess<TouchEventLog>
	{

		public TouchEventLog_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TouchEventLog_TouchPointsEventsProcess

	public partial class TouchEventLog_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TouchEventLogEventsProcess

	/// <exclude/>
	public class TouchEventLogEventsProcess : TouchEventLog_TouchPointsEventsProcess
	{

		public TouchEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

