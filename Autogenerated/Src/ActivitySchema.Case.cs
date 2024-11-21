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

	#region Class: Activity_Case_BPMSoftSchema

	/// <exclude/>
	public class Activity_Case_BPMSoftSchema : BPMSoft.Configuration.Activity_EmailMessage_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Case_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Case_BPMSoftSchema(Activity_Case_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Case_BPMSoftSchema(Activity_Case_BPMSoftSchema source)
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
			RealUId = new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1");
			Name = "Activity_Case_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("47c4dc47-8529-4d0e-a6fa-f298bb20cd13")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("1b3d86ae-616d-49c5-b738-63b2a25c9607")) == null) {
				Columns.Add(CreateServiceProcessedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("47c4dc47-8529-4d0e-a6fa-f298bb20cd13"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1"),
				ModifiedInSchemaUId = new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceProcessedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1b3d86ae-616d-49c5-b738-63b2a25c9607"),
				Name = @"ServiceProcessed",
				CreatedInSchemaUId = new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1"),
				ModifiedInSchemaUId = new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd")
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
			return new Activity_Case_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Case_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Case_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Case_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Case_BPMSoft : BPMSoft.Configuration.Activity_EmailMessage_BPMSoft
	{

		#region Constructors: Public

		public Activity_Case_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Case_BPMSoft";
		}

		public Activity_Case_BPMSoft(Activity_Case_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <summary>
		/// Обработано процессами сервиса.
		/// </summary>
		public bool ServiceProcessed {
			get {
				return GetTypedColumnValue<bool>("ServiceProcessed");
			}
			set {
				SetColumnValue("ServiceProcessed", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_CaseEventsProcess(UserConnection);
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
			return new Activity_Case_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CaseEventsProcess

	/// <exclude/>
	public partial class Activity_CaseEventsProcess<TEntity> : BPMSoft.Configuration.Activity_EmailMessageEventsProcess<TEntity> where TEntity : Activity_Case_BPMSoft
	{

		public Activity_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_CaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("050a4134-36bf-4710-bfe7-4c3477a8e9e1");
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

	#region Class: Activity_CaseEventsProcess

	/// <exclude/>
	public class Activity_CaseEventsProcess : Activity_CaseEventsProcess<Activity_Case_BPMSoft>
	{

		public Activity_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_CaseEventsProcess

	public partial class Activity_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool DoCollectEmailParticipants() {
			return Entity.GetTypedColumnValue<Guid>("TypeId") == BPMSoft.Configuration.ActivityConsts.EmailTypeUId
			|| Entity.GetTypedColumnValue<Guid>("ActivityCategoryId") == ExchangeConsts.ActivityMeetingCategoryId;
		}

		public override bool OnActivitySaved(ProcessExecutingContext context) {
			SynchronizeParticipants();
			return base.OnActivitySaved(context);
		}

		#endregion

	}

	#endregion

}

