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

	#region Class: ProblemSchema

	/// <exclude/>
	public class ProblemSchema : BPMSoft.Configuration.Problem_Problem_BPMSoftSchema
	{

		#region Constructors: Public

		public ProblemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProblemSchema(ProblemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProblemSchema(ProblemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0d9b6870-0c0e-4f0b-b0a5-857342223e2e");
			Name = "Problem";
			ParentSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4b2eb4ab-1abd-4116-abf8-c944d7d82ece");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e2139c27-ea75-4281-a489-8dff2f312395")) == null) {
				Columns.Add(CreateChangeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e2139c27-ea75-4281-a489-8dff2f312395"),
				Name = @"Change",
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0d9b6870-0c0e-4f0b-b0a5-857342223e2e"),
				ModifiedInSchemaUId = new Guid("0d9b6870-0c0e-4f0b-b0a5-857342223e2e"),
				CreatedInPackageId = new Guid("4b2eb4ab-1abd-4116-abf8-c944d7d82ece")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Problem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Problem_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProblemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProblemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0d9b6870-0c0e-4f0b-b0a5-857342223e2e"));
		}

		#endregion

	}

	#endregion

	#region Class: Problem

	/// <summary>
	/// Проблема.
	/// </summary>
	public class Problem : BPMSoft.Configuration.Problem_Problem_BPMSoft
	{

		#region Constructors: Public

		public Problem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Problem";
		}

		public Problem(Problem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ChangeId {
			get {
				return GetTypedColumnValue<Guid>("ChangeId");
			}
			set {
				SetColumnValue("ChangeId", value);
				_change = null;
			}
		}

		/// <exclude/>
		public string ChangeNumber {
			get {
				return GetTypedColumnValue<string>("ChangeNumber");
			}
			set {
				SetColumnValue("ChangeNumber", value);
				if (_change != null) {
					_change.Number = value;
				}
			}
		}

		private Change _change;
		/// <summary>
		/// Изменение.
		/// </summary>
		public Change Change {
			get {
				return _change ??
					(_change = LookupColumnEntities.GetEntity("Change") as Change);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Problem_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProblemDeleted", e);
			Validating += (s, e) => ThrowEvent("ProblemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Problem(this);
		}

		#endregion

	}

	#endregion

	#region Class: Problem_ChangeEventsProcess

	/// <exclude/>
	public partial class Problem_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.Problem_ProblemEventsProcess<TEntity> where TEntity : Problem
	{

		public Problem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Problem_ChangeEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0d9b6870-0c0e-4f0b-b0a5-857342223e2e");
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

	#region Class: Problem_ChangeEventsProcess

	/// <exclude/>
	public class Problem_ChangeEventsProcess : Problem_ChangeEventsProcess<Problem>
	{

		public Problem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Problem_ChangeEventsProcess

	public partial class Problem_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ProblemEventsProcess

	/// <exclude/>
	public class ProblemEventsProcess : Problem_ChangeEventsProcess
	{

		public ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

