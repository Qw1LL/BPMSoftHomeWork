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

	#region Class: Activity_SSP_BPMSoftSchema

	/// <exclude/>
	public class Activity_SSP_BPMSoftSchema : BPMSoft.Configuration.Activity_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_SSP_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_SSP_BPMSoftSchema(Activity_SSP_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_SSP_BPMSoftSchema(Activity_SSP_BPMSoftSchema source)
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
			RealUId = new Guid("24caec77-5b6b-4c0e-9cd8-7be9a7dc65b4");
			Name = "Activity_SSP_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6e774b28-4cf2-458d-872b-08ef49cd87a7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
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
			return new Activity_SSP_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_SSP_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_SSP_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("24caec77-5b6b-4c0e-9cd8-7be9a7dc65b4"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_SSP_BPMSoft

	/// <summary>
	/// Activity.
	/// </summary>
	public class Activity_SSP_BPMSoft : BPMSoft.Configuration.Activity_Lead_BPMSoft
	{

		#region Constructors: Public

		public Activity_SSP_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_SSP_BPMSoft";
		}

		public Activity_SSP_BPMSoft(Activity_SSP_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_SSPEventsProcess(UserConnection);
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
			return new Activity_SSP_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_SSPEventsProcess

	/// <exclude/>
	public partial class Activity_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Activity_LeadEventsProcess<TEntity> where TEntity : Activity_SSP_BPMSoft
	{

		public Activity_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("24caec77-5b6b-4c0e-9cd8-7be9a7dc65b4");
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

	#region Class: Activity_SSPEventsProcess

	/// <exclude/>
	public class Activity_SSPEventsProcess : Activity_SSPEventsProcess<Activity_SSP_BPMSoft>
	{

		public Activity_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_SSPEventsProcess

	public partial class Activity_SSPEventsProcess<TEntity>
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

