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

	#region Class: StoredReportSchema

	/// <exclude/>
	public class StoredReportSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public StoredReportSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public StoredReportSchema(StoredReportSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public StoredReportSchema(StoredReportSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38");
			RealUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38");
			Name = "StoredReport";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a83ae89b-1206-453d-b626-f37ab41fffbf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6036e07f-0608-4064-8ce6-b371b882a2f6")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("96e0a308-e5ac-49a1-80fd-e933009564c4")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("74516abd-6486-42b5-85a4-873be4a92188")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6036e07f-0608-4064-8ce6-b371b882a2f6"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				ModifiedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("96e0a308-e5ac-49a1-80fd-e933009564c4"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				ModifiedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("74516abd-6486-42b5-85a4-873be4a92188"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				ModifiedInSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new StoredReport(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new StoredReport_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new StoredReportSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new StoredReportSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"));
		}

		#endregion

	}

	#endregion

	#region Class: StoredReport

	/// <summary>
	/// StoredReport.
	/// </summary>
	public class StoredReport : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public StoredReport(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "StoredReport";
		}

		public StoredReport(StoredReport source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new StoredReport_NUIEventsProcess(UserConnection);
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
			return new StoredReport(this);
		}

		#endregion

	}

	#endregion

	#region Class: StoredReport_NUIEventsProcess

	/// <exclude/>
	public partial class StoredReport_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : StoredReport
	{

		public StoredReport_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StoredReport_NUIEventsProcess";
			SchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38");
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

	#region Class: StoredReport_NUIEventsProcess

	/// <exclude/>
	public class StoredReport_NUIEventsProcess : StoredReport_NUIEventsProcess<StoredReport>
	{

		public StoredReport_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: StoredReport_NUIEventsProcess

	public partial class StoredReport_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: StoredReportEventsProcess

	/// <exclude/>
	public class StoredReportEventsProcess : StoredReport_NUIEventsProcess
	{

		public StoredReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

