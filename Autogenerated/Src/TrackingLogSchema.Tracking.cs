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

	#region Class: TrackingLogSchema

	/// <exclude/>
	public class TrackingLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TrackingLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TrackingLogSchema(TrackingLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TrackingLogSchema(TrackingLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9b918674-68e0-417c-921a-11e0450282e4");
			RealUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4");
			Name = "TrackingLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("874306e1-e314-437e-96bf-3f336a8aaf12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4bfe0627-14af-4959-8c5d-5b3f03074cec")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("b7522317-2eec-4ecb-835b-e36d0ca7fc07")) == null) {
				Columns.Add(CreateModuleNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4bfe0627-14af-4959-8c5d-5b3f03074cec"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4"),
				ModifiedInSchemaUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4"),
				CreatedInPackageId = new Guid("874306e1-e314-437e-96bf-3f336a8aaf12")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b7522317-2eec-4ecb-835b-e36d0ca7fc07"),
				Name = @"ModuleName",
				CreatedInSchemaUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4"),
				ModifiedInSchemaUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4"),
				CreatedInPackageId = new Guid("874306e1-e314-437e-96bf-3f336a8aaf12")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TrackingLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TrackingLog_TrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TrackingLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TrackingLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b918674-68e0-417c-921a-11e0450282e4"));
		}

		#endregion

	}

	#endregion

	#region Class: TrackingLog

	/// <summary>
	/// Журнал событий трекинга.
	/// </summary>
	public class TrackingLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TrackingLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TrackingLog";
		}

		public TrackingLog(TrackingLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Название модуля.
		/// </summary>
		public string ModuleName {
			get {
				return GetTypedColumnValue<string>("ModuleName");
			}
			set {
				SetColumnValue("ModuleName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TrackingLog_TrackingEventsProcess(UserConnection);
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
			return new TrackingLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingLog_TrackingEventsProcess

	/// <exclude/>
	public partial class TrackingLog_TrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TrackingLog
	{

		public TrackingLog_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TrackingLog_TrackingEventsProcess";
			SchemaUId = new Guid("9b918674-68e0-417c-921a-11e0450282e4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9b918674-68e0-417c-921a-11e0450282e4");
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

	#region Class: TrackingLog_TrackingEventsProcess

	/// <exclude/>
	public class TrackingLog_TrackingEventsProcess : TrackingLog_TrackingEventsProcess<TrackingLog>
	{

		public TrackingLog_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TrackingLog_TrackingEventsProcess

	public partial class TrackingLog_TrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TrackingLogEventsProcess

	/// <exclude/>
	public class TrackingLogEventsProcess : TrackingLog_TrackingEventsProcess
	{

		public TrackingLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

