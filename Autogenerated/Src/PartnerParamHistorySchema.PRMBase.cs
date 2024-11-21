namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: PartnerParamHistorySchema

	/// <exclude/>
	public class PartnerParamHistorySchema : BPMSoft.Configuration.PartnershipParameterSchema
	{

		#region Constructors: Public

		public PartnerParamHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnerParamHistorySchema(PartnerParamHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnerParamHistorySchema(PartnerParamHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("488977f0-7923-47ae-ba50-d05c93101210");
			RealUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210");
			Name = "PartnerParamHistory";
			ParentSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f43a6760-9275-4070-90a5-eacccad59d8c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2a24e7e0-4ac5-4077-8160-f7e69ede3e2c")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("b2cc7804-e355-4e23-9527-91cb2c08e533")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2a24e7e0-4ac5-4077-8160-f7e69ede3e2c"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210"),
				ModifiedInSchemaUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210"),
				CreatedInPackageId = new Guid("f43a6760-9275-4070-90a5-eacccad59d8c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b2cc7804-e355-4e23-9527-91cb2c08e533"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210"),
				ModifiedInSchemaUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210"),
				CreatedInPackageId = new Guid("f43a6760-9275-4070-90a5-eacccad59d8c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnerParamHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnerParamHistory_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnerParamHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnerParamHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("488977f0-7923-47ae-ba50-d05c93101210"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnerParamHistory

	/// <summary>
	/// История параметра партнерства.
	/// </summary>
	public class PartnerParamHistory : BPMSoft.Configuration.PartnershipParameter
	{

		#region Constructors: Public

		public PartnerParamHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnerParamHistory";
		}

		public PartnerParamHistory(PartnerParamHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Начало.
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
		/// Завершение.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnerParamHistory_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnerParamHistoryDeleted", e);
			Deleting += (s, e) => ThrowEvent("PartnerParamHistoryDeleting", e);
			Validating += (s, e) => ThrowEvent("PartnerParamHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnerParamHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnerParamHistory_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnerParamHistory_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipParameter_PRMOrderEventsProcess<TEntity> where TEntity : PartnerParamHistory
	{

		public PartnerParamHistory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnerParamHistory_PRMBaseEventsProcess";
			SchemaUId = new Guid("488977f0-7923-47ae-ba50-d05c93101210");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("488977f0-7923-47ae-ba50-d05c93101210");
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

	#region Class: PartnerParamHistory_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnerParamHistory_PRMBaseEventsProcess : PartnerParamHistory_PRMBaseEventsProcess<PartnerParamHistory>
	{

		public PartnerParamHistory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnerParamHistory_PRMBaseEventsProcess

	public partial class PartnerParamHistory_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool UpdateStringValueMethod() {
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: PartnerParamHistoryEventsProcess

	/// <exclude/>
	public class PartnerParamHistoryEventsProcess : PartnerParamHistory_PRMBaseEventsProcess
	{

		public PartnerParamHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

