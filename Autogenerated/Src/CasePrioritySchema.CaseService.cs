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

	#region Class: CasePrioritySchema

	/// <exclude/>
	public class CasePrioritySchema : BPMSoft.Configuration.CasePriority_Case_BPMSoftSchema
	{

		#region Constructors: Public

		public CasePrioritySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CasePrioritySchema(CasePrioritySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CasePrioritySchema(CasePrioritySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6");
			Name = "CasePriority";
			ParentSchemaUId = new Guid("e662865c-728f-40db-b3dd-15dcf46d47df");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0d251ce1-5da0-44b4-b169-1162aa218bbc")) == null) {
				Columns.Add(CreateReactionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("26375214-6c8b-4842-9606-36f9e48d675e")) == null) {
				Columns.Add(CreateReactionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("9fb74b74-75ad-44d5-b871-3e55200b60c5")) == null) {
				Columns.Add(CreateSolutionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("b33a80b9-ad34-4da6-9b30-55097e5c341a")) == null) {
				Columns.Add(CreateSolutionTimeUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReactionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0d251ce1-5da0-44b4-b169-1162aa218bbc"),
				Name = @"ReactionTimeValue",
				CreatedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				ModifiedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("26375214-6c8b-4842-9606-36f9e48d675e"),
				Name = @"ReactionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				ModifiedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9fb74b74-75ad-44d5-b871-3e55200b60c5"),
				Name = @"SolutionTimeValue",
				CreatedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				ModifiedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b33a80b9-ad34-4da6-9b30-55097e5c341a"),
				Name = @"SolutionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				ModifiedInSchemaUId = new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"),
				CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CasePriority(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CasePriority_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CasePrioritySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CasePrioritySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6"));
		}

		#endregion

	}

	#endregion

	#region Class: CasePriority

	/// <summary>
	/// Справочник - Приоритет обращения.
	/// </summary>
	public class CasePriority : BPMSoft.Configuration.CasePriority_Case_BPMSoft
	{

		#region Constructors: Public

		public CasePriority(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CasePriority";
		}

		public CasePriority(CasePriority source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Значение времени реакции.
		/// </summary>
		public int ReactionTimeValue {
			get {
				return GetTypedColumnValue<int>("ReactionTimeValue");
			}
			set {
				SetColumnValue("ReactionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid ReactionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ReactionTimeUnitId");
			}
			set {
				SetColumnValue("ReactionTimeUnitId", value);
				_reactionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ReactionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ReactionTimeUnitName");
			}
			set {
				SetColumnValue("ReactionTimeUnitName", value);
				if (_reactionTimeUnit != null) {
					_reactionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _reactionTimeUnit;
		/// <summary>
		/// Единица времени реакции.
		/// </summary>
		public TimeUnit ReactionTimeUnit {
			get {
				return _reactionTimeUnit ??
					(_reactionTimeUnit = LookupColumnEntities.GetEntity("ReactionTimeUnit") as TimeUnit);
			}
		}

		/// <summary>
		/// Значение времени разрешения.
		/// </summary>
		public int SolutionTimeValue {
			get {
				return GetTypedColumnValue<int>("SolutionTimeValue");
			}
			set {
				SetColumnValue("SolutionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid SolutionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("SolutionTimeUnitId");
			}
			set {
				SetColumnValue("SolutionTimeUnitId", value);
				_solutionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string SolutionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("SolutionTimeUnitName");
			}
			set {
				SetColumnValue("SolutionTimeUnitName", value);
				if (_solutionTimeUnit != null) {
					_solutionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _solutionTimeUnit;
		/// <summary>
		/// Единица времени разрешения.
		/// </summary>
		public TimeUnit SolutionTimeUnit {
			get {
				return _solutionTimeUnit ??
					(_solutionTimeUnit = LookupColumnEntities.GetEntity("SolutionTimeUnit") as TimeUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CasePriority_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CasePriorityDeleted", e);
			Validating += (s, e) => ThrowEvent("CasePriorityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CasePriority(this);
		}

		#endregion

	}

	#endregion

	#region Class: CasePriority_CaseServiceEventsProcess

	/// <exclude/>
	public partial class CasePriority_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.CasePriority_CaseEventsProcess<TEntity> where TEntity : CasePriority
	{

		public CasePriority_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CasePriority_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb413f04-2841-433a-9dce-6ad33096a9e6");
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

	#region Class: CasePriority_CaseServiceEventsProcess

	/// <exclude/>
	public class CasePriority_CaseServiceEventsProcess : CasePriority_CaseServiceEventsProcess<CasePriority>
	{

		public CasePriority_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CasePriority_CaseServiceEventsProcess

	public partial class CasePriority_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CasePriorityEventsProcess

	/// <exclude/>
	public class CasePriorityEventsProcess : CasePriority_CaseServiceEventsProcess
	{

		public CasePriorityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

