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

	#region Class: ProblemStatusSchema

	/// <exclude/>
	public class ProblemStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProblemStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProblemStatusSchema(ProblemStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProblemStatusSchema(ProblemStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			RealUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			Name = "ProblemStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8f73370b-10be-4aa8-944b-af461bb82c47")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8f73370b-10be-4aa8-944b-af461bb82c47"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb"),
				ModifiedInSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProblemStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProblemStatus_ProblemEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProblemStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProblemStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb"));
		}

		#endregion

	}

	#endregion

	#region Class: ProblemStatus

	/// <summary>
	/// Состояние проблемы.
	/// </summary>
	public class ProblemStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProblemStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProblemStatus";
		}

		public ProblemStatus(ProblemStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProblemStatus_ProblemEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProblemStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("ProblemStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProblemStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProblemStatus_ProblemEventsProcess

	/// <exclude/>
	public partial class ProblemStatus_ProblemEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProblemStatus
	{

		public ProblemStatus_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProblemStatus_ProblemEventsProcess";
			SchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb");
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

	#region Class: ProblemStatus_ProblemEventsProcess

	/// <exclude/>
	public class ProblemStatus_ProblemEventsProcess : ProblemStatus_ProblemEventsProcess<ProblemStatus>
	{

		public ProblemStatus_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProblemStatus_ProblemEventsProcess

	public partial class ProblemStatus_ProblemEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ProblemStatusEventsProcess

	/// <exclude/>
	public class ProblemStatusEventsProcess : ProblemStatus_ProblemEventsProcess
	{

		public ProblemStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

