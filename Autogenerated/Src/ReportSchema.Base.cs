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

	#region Class: ReportSchema

	/// <exclude/>
	public class ReportSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ReportSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReportSchema(ReportSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReportSchema(ReportSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425");
			RealUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425");
			Name = "Report";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6b09c38c-76d6-44ea-88fb-5739e5c6ef51")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1ec8913d-0d1e-48c3-a9ee-cebfc69cd629"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"),
				ModifiedInSchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6b09c38c-76d6-44ea-88fb-5739e5c6ef51"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"),
				ModifiedInSchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"),
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
			return new Report(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Report_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReportSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReportSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425"));
		}

		#endregion

	}

	#endregion

	#region Class: Report

	/// <summary>
	/// Report.
	/// </summary>
	public class Report : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Report(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Report";
		}

		public Report(Report source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Report_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReportDeleted", e);
			Deleting += (s, e) => ThrowEvent("ReportDeleting", e);
			Inserted += (s, e) => ThrowEvent("ReportInserted", e);
			Inserting += (s, e) => ThrowEvent("ReportInserting", e);
			Saved += (s, e) => ThrowEvent("ReportSaved", e);
			Saving += (s, e) => ThrowEvent("ReportSaving", e);
			Validating += (s, e) => ThrowEvent("ReportValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Report(this);
		}

		#endregion

	}

	#endregion

	#region Class: Report_BaseEventsProcess

	/// <exclude/>
	public partial class Report_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Report
	{

		public Report_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Report_BaseEventsProcess";
			SchemaUId = new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f1e722a-8f1b-43cb-962b-2bd20a68a425");
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

	#region Class: Report_BaseEventsProcess

	/// <exclude/>
	public class Report_BaseEventsProcess : Report_BaseEventsProcess<Report>
	{

		public Report_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Report_BaseEventsProcess

	public partial class Report_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReportEventsProcess

	/// <exclude/>
	public class ReportEventsProcess : Report_BaseEventsProcess
	{

		public ReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

