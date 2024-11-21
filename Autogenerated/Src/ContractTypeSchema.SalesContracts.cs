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

	#region Class: ContractTypeSchema

	/// <exclude/>
	public class ContractTypeSchema : BPMSoft.Configuration.ContractType_CoreContracts_BPMSoftSchema
	{

		#region Constructors: Public

		public ContractTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContractTypeSchema(ContractTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContractTypeSchema(ContractTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f234bed6-209d-46f8-b1ba-b0216119328c");
			Name = "ContractType";
			ParentSchemaUId = new Guid("427ad733-d7ff-43c5-a65a-c22a25e4e5df");
			ExtendParent = true;
			CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1ace4761-9b2b-4444-b3ed-a3315c1ccf1d")) == null) {
				Columns.Add(CreateIsSlaveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsSlaveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1ace4761-9b2b-4444-b3ed-a3315c1ccf1d"),
				Name = @"IsSlave",
				CreatedInSchemaUId = new Guid("f234bed6-209d-46f8-b1ba-b0216119328c"),
				ModifiedInSchemaUId = new Guid("f234bed6-209d-46f8-b1ba-b0216119328c"),
				CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContractType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContractType_SalesContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContractTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContractTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f234bed6-209d-46f8-b1ba-b0216119328c"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractType

	/// <summary>
	/// Тип договора.
	/// </summary>
	public class ContractType : BPMSoft.Configuration.ContractType_CoreContracts_BPMSoft
	{

		#region Constructors: Public

		public ContractType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContractType";
		}

		public ContractType(ContractType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Подчинённый.
		/// </summary>
		public bool IsSlave {
			get {
				return GetTypedColumnValue<bool>("IsSlave");
			}
			set {
				SetColumnValue("IsSlave", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContractType_SalesContractsEventsProcess(UserConnection);
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
			return new ContractType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContractType_SalesContractsEventsProcess

	/// <exclude/>
	public partial class ContractType_SalesContractsEventsProcess<TEntity> : BPMSoft.Configuration.ContractType_CoreContractsEventsProcess<TEntity> where TEntity : ContractType
	{

		public ContractType_SalesContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractType_SalesContractsEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f234bed6-209d-46f8-b1ba-b0216119328c");
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

	#region Class: ContractType_SalesContractsEventsProcess

	/// <exclude/>
	public class ContractType_SalesContractsEventsProcess : ContractType_SalesContractsEventsProcess<ContractType>
	{

		public ContractType_SalesContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContractType_SalesContractsEventsProcess

	public partial class ContractType_SalesContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContractTypeEventsProcess

	/// <exclude/>
	public class ContractTypeEventsProcess : ContractType_SalesContractsEventsProcess
	{

		public ContractTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

