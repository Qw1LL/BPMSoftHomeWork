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

	#region Class: SysPrcHistoryLogSchema

	/// <exclude/>
	public class SysPrcHistoryLogSchema : BPMSoft.Configuration.SysProcessLogSchema
	{

		#region Constructors: Public

		public SysPrcHistoryLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcHistoryLogSchema(SysPrcHistoryLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcHistoryLogSchema(SysPrcHistoryLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIeij8lfUHvkr86dMG56Zm1qXrHoIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("3945a332-5983-44ec-8e5c-ae306e5dd34c");
			index.Name = "Ieij8lfUHvkr86dMG56Zm1qXrHo";
			index.CreatedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			index.ModifiedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn parentIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("79dc7db1-dc75-42e2-b534-c39e24407b50"),
				ColumnUId = new Guid("1f85a957-c2b6-4aa1-afff-575ad9bd443e"),
				CreatedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				ModifiedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentIdIndexColumn);
			EntitySchemaIndexColumn completeDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3489186f-b1b6-4958-93fd-14b38a2ec58c"),
				ColumnUId = new Guid("453bcbc6-eae2-481f-b808-b7cfea46304b"),
				CreatedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				ModifiedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(completeDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			RealUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			Name = "SysPrcHistoryLog";
			ParentSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("db484552-1edf-492e-83ab-076c107943f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIeij8lfUHvkr86dMG56Zm1qXrHoIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcHistoryLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcHistoryLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcHistoryLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcHistoryLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcHistoryLog

	/// <summary>
	/// System process log history.
	/// </summary>
	public class SysPrcHistoryLog : BPMSoft.Configuration.SysProcessLog
	{

		#region Constructors: Public

		public SysPrcHistoryLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcHistoryLog";
		}

		public SysPrcHistoryLog(SysPrcHistoryLog source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcHistoryLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcHistoryLogDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcHistoryLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcHistoryLog_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcHistoryLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysProcessLog_PRMPortalEventsProcess<TEntity> where TEntity : SysPrcHistoryLog
	{

		public SysPrcHistoryLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcHistoryLog_BaseEventsProcess";
			SchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d");
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

	#region Class: SysPrcHistoryLog_BaseEventsProcess

	/// <exclude/>
	public class SysPrcHistoryLog_BaseEventsProcess : SysPrcHistoryLog_BaseEventsProcess<SysPrcHistoryLog>
	{

		public SysPrcHistoryLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcHistoryLog_BaseEventsProcess

	public partial class SysPrcHistoryLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcHistoryLogEventsProcess

	/// <exclude/>
	public class SysPrcHistoryLogEventsProcess : SysPrcHistoryLog_BaseEventsProcess
	{

		public SysPrcHistoryLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

