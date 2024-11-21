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

	#region Class: ReportInFolderSchema

	/// <exclude/>
	public class ReportInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ReportInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReportInFolderSchema(ReportInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReportInFolderSchema(ReportInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82");
			RealUId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82");
			Name = "ReportInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("abc82605-51b3-49d5-8692-41d12a624d87")) == null) {
				Columns.Add(CreateReportColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("4bd1b41c-682e-496f-afb0-0b84fa7d1902");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82");
			return column;
		}

		protected virtual EntitySchemaColumn CreateReportColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("abc82605-51b3-49d5-8692-41d12a624d87"),
				Name = @"Report",
				ReferenceSchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82"),
				ModifiedInSchemaUId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReportInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReportInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReportInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReportInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82"));
		}

		#endregion

	}

	#endregion

	#region Class: ReportInFolder

	/// <summary>
	/// Report in folder.
	/// </summary>
	public class ReportInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ReportInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReportInFolder";
		}

		public ReportInFolder(ReportInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReportId {
			get {
				return GetTypedColumnValue<Guid>("ReportId");
			}
			set {
				SetColumnValue("ReportId", value);
				_report = null;
			}
		}

		/// <exclude/>
		public string ReportTitle {
			get {
				return GetTypedColumnValue<string>("ReportTitle");
			}
			set {
				SetColumnValue("ReportTitle", value);
				if (_report != null) {
					_report.Title = value;
				}
			}
		}

		private Report _report;
		/// <summary>
		/// Report.
		/// </summary>
		public Report Report {
			get {
				return _report ??
					(_report = LookupColumnEntities.GetEntity("Report") as Report);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReportInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReportInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("ReportInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("ReportInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("ReportInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("ReportInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("ReportInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("ReportInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReportInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReportInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class ReportInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ReportInFolder
	{

		public ReportInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReportInFolder_BaseEventsProcess";
			SchemaUId = new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e35de67a-ec4b-42f9-a221-4ba6b0760b82");
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

	#region Class: ReportInFolder_BaseEventsProcess

	/// <exclude/>
	public class ReportInFolder_BaseEventsProcess : ReportInFolder_BaseEventsProcess<ReportInFolder>
	{

		public ReportInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReportInFolder_BaseEventsProcess

	public partial class ReportInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReportInFolderEventsProcess

	/// <exclude/>
	public class ReportInFolderEventsProcess : ReportInFolder_BaseEventsProcess
	{

		public ReportInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

