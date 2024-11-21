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

	#region Class: ProblemPrioritySchema

	/// <exclude/>
	public class ProblemPrioritySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProblemPrioritySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProblemPrioritySchema(ProblemPrioritySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProblemPrioritySchema(ProblemPrioritySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			RealUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			Name = "ProblemPriority";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ca8b62a7-e7a2-4bd1-a717-9cb262a7e7e1")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			column.CreatedInPackageId = new Guid("09a48096-3a59-4e1d-a292-1baeb8690e32");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ca8b62a7-e7a2-4bd1-a717-9cb262a7e7e1"),
				Name = @"Priority",
				CreatedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8"),
				ModifiedInSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8"),
				CreatedInPackageId = new Guid("3c33fea4-8dbf-4aca-bdb3-74630a448d22")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProblemPriority(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProblemPriority_ProblemEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProblemPrioritySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProblemPrioritySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8"));
		}

		#endregion

	}

	#endregion

	#region Class: ProblemPriority

	/// <summary>
	/// Приоритет проблемы.
	/// </summary>
	public class ProblemPriority : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProblemPriority(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProblemPriority";
		}

		public ProblemPriority(ProblemPriority source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProblemPriority_ProblemEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProblemPriorityDeleted", e);
			Validating += (s, e) => ThrowEvent("ProblemPriorityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProblemPriority(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProblemPriority_ProblemEventsProcess

	/// <exclude/>
	public partial class ProblemPriority_ProblemEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProblemPriority
	{

		public ProblemPriority_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProblemPriority_ProblemEventsProcess";
			SchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8");
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

	#region Class: ProblemPriority_ProblemEventsProcess

	/// <exclude/>
	public class ProblemPriority_ProblemEventsProcess : ProblemPriority_ProblemEventsProcess<ProblemPriority>
	{

		public ProblemPriority_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProblemPriority_ProblemEventsProcess

	public partial class ProblemPriority_ProblemEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ProblemPriorityEventsProcess

	/// <exclude/>
	public class ProblemPriorityEventsProcess : ProblemPriority_ProblemEventsProcess
	{

		public ProblemPriorityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

