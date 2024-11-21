namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Packages.Case;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: Activity_Problem_BPMSoftSchema

	/// <exclude/>
	public class Activity_Problem_BPMSoftSchema : BPMSoft.Configuration.Activity_Project_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Problem_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Problem_BPMSoftSchema(Activity_Problem_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Problem_BPMSoftSchema(Activity_Problem_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_Activity_SendDateIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("1e60c588-1264-4219-9f83-2a3e68bc54b6");
			index.Name = "IX_Activity_SendDate";
			index.CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed");
			EntitySchemaIndexColumn sendDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b8f4292f-5ae6-43ca-9685-1301b31eba68"),
				ColumnUId = new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc"),
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(sendDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("80399fd8-b80c-43a1-a2bc-7af581315403");
			Name = "Activity_Problem_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7d431f1d-e167-4639-9031-b6a87693b6dc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a25b00d4-25cc-4dcb-acce-c3af16d60e06")) == null) {
				Columns.Add(CreateProblemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProblemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a25b00d4-25cc-4dcb-acce-c3af16d60e06"),
				Name = @"Problem",
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("80399fd8-b80c-43a1-a2bc-7af581315403"),
				ModifiedInSchemaUId = new Guid("80399fd8-b80c-43a1-a2bc-7af581315403"),
				CreatedInPackageId = new Guid("7d431f1d-e167-4639-9031-b6a87693b6dc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_Activity_SendDateIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Problem_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_ProblemEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Problem_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Problem_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("80399fd8-b80c-43a1-a2bc-7af581315403"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Problem_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Problem_BPMSoft : BPMSoft.Configuration.Activity_Project_BPMSoft
	{

		#region Constructors: Public

		public Activity_Problem_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Problem_BPMSoft";
		}

		public Activity_Problem_BPMSoft(Activity_Problem_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProblemId {
			get {
				return GetTypedColumnValue<Guid>("ProblemId");
			}
			set {
				SetColumnValue("ProblemId", value);
				_problem = null;
			}
		}

		/// <exclude/>
		public string ProblemNumber {
			get {
				return GetTypedColumnValue<string>("ProblemNumber");
			}
			set {
				SetColumnValue("ProblemNumber", value);
				if (_problem != null) {
					_problem.Number = value;
				}
			}
		}

		private Problem _problem;
		/// <summary>
		/// Проблема.
		/// </summary>
		public Problem Problem {
			get {
				return _problem ??
					(_problem = LookupColumnEntities.GetEntity("Problem") as Problem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_ProblemEventsProcess(UserConnection);
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
			return new Activity_Problem_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_ProblemEventsProcess

	/// <exclude/>
	public partial class Activity_ProblemEventsProcess<TEntity> : BPMSoft.Configuration.Activity_ProjectEventsProcess<TEntity> where TEntity : Activity_Problem_BPMSoft
	{

		public Activity_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_ProblemEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("80399fd8-b80c-43a1-a2bc-7af581315403");
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

	#region Class: Activity_ProblemEventsProcess

	/// <exclude/>
	public class Activity_ProblemEventsProcess : Activity_ProblemEventsProcess<Activity_Problem_BPMSoft>
	{

		public Activity_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_ProblemEventsProcess

	public partial class Activity_ProblemEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool OnActivitySaving(ProcessExecutingContext context) {
			return base.OnActivitySaving(context);
		}

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

