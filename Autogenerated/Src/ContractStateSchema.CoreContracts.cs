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

	#region Class: ContractStateSchema

	/// <exclude/>
	public class ContractStateSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ContractStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContractStateSchema(ContractStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContractStateSchema(ContractStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a");
			RealUId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a");
			Name = "ContractState";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreatePositionColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e0b5759f-de50-4deb-93a8-c96cefaa12d3"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a"),
				ModifiedInSchemaUId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a"),
				CreatedInPackageId = new Guid("e0fefcb5-b597-43d2-8e8f-93ff200453f3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContractState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContractState_CoreContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContractStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContractStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("946f79dc-1039-448b-a670-eb6658e7180a"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractState

	/// <summary>
	/// Состояние договора.
	/// </summary>
	public class ContractState : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ContractState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContractState";
		}

		public ContractState(ContractState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
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
			var process = new ContractState_CoreContractsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContractStateDeleted", e);
			Validating += (s, e) => ThrowEvent("ContractStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContractState(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContractState_CoreContractsEventsProcess

	/// <exclude/>
	public partial class ContractState_CoreContractsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ContractState
	{

		public ContractState_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractState_CoreContractsEventsProcess";
			SchemaUId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("946f79dc-1039-448b-a670-eb6658e7180a");
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

	#region Class: ContractState_CoreContractsEventsProcess

	/// <exclude/>
	public class ContractState_CoreContractsEventsProcess : ContractState_CoreContractsEventsProcess<ContractState>
	{

		public ContractState_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContractState_CoreContractsEventsProcess

	public partial class ContractState_CoreContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContractStateEventsProcess

	/// <exclude/>
	public class ContractStateEventsProcess : ContractState_CoreContractsEventsProcess
	{

		public ContractStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

