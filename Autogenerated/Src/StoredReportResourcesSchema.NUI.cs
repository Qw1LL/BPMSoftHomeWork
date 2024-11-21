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

	#region Class: StoredReportResourcesSchema

	/// <exclude/>
	public class StoredReportResourcesSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public StoredReportResourcesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public StoredReportResourcesSchema(StoredReportResourcesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public StoredReportResourcesSchema(StoredReportResourcesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8");
			RealUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8");
			Name = "StoredReportResources";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a83ae89b-1206-453d-b626-f37ab41fffbf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7e7f9fd9-c7c3-426f-a8b4-2bb4e7fae466")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("14b4793a-44d0-4478-9ebc-274ab295f4ec")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("985f29b9-3567-4d3f-9335-ea449542e53d")) == null) {
				Columns.Add(CreateDevExpressReportColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7e7f9fd9-c7c3-426f-a8b4-2bb4e7fae466"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
				ModifiedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("14b4793a-44d0-4478-9ebc-274ab295f4ec"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
				ModifiedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDevExpressReportColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("985f29b9-3567-4d3f-9335-ea449542e53d"),
				Name = @"DevExpressReport",
				ReferenceSchemaUId = new Guid("99c2c2c8-e600-411c-9899-bf92b99a6f38"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
				ModifiedInSchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"),
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
			return new StoredReportResources(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new StoredReportResources_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new StoredReportResourcesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new StoredReportResourcesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8"));
		}

		#endregion

	}

	#endregion

	#region Class: StoredReportResources

	/// <summary>
	/// StoredReportResources.
	/// </summary>
	public class StoredReportResources : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public StoredReportResources(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "StoredReportResources";
		}

		public StoredReportResources(StoredReportResources source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid DevExpressReportId {
			get {
				return GetTypedColumnValue<Guid>("DevExpressReportId");
			}
			set {
				SetColumnValue("DevExpressReportId", value);
				_devExpressReport = null;
			}
		}

		private StoredReport _devExpressReport;
		/// <summary>
		/// DevExpress report.
		/// </summary>
		public StoredReport DevExpressReport {
			get {
				return _devExpressReport ??
					(_devExpressReport = LookupColumnEntities.GetEntity("DevExpressReport") as StoredReport);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new StoredReportResources_NUIEventsProcess(UserConnection);
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
			return new StoredReportResources(this);
		}

		#endregion

	}

	#endregion

	#region Class: StoredReportResources_NUIEventsProcess

	/// <exclude/>
	public partial class StoredReportResources_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : StoredReportResources
	{

		public StoredReportResources_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StoredReportResources_NUIEventsProcess";
			SchemaUId = new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c4547df5-a7a1-4dd7-80f3-10b99efdaac8");
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

	#region Class: StoredReportResources_NUIEventsProcess

	/// <exclude/>
	public class StoredReportResources_NUIEventsProcess : StoredReportResources_NUIEventsProcess<StoredReportResources>
	{

		public StoredReportResources_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: StoredReportResources_NUIEventsProcess

	public partial class StoredReportResources_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: StoredReportResourcesEventsProcess

	/// <exclude/>
	public class StoredReportResourcesEventsProcess : StoredReportResources_NUIEventsProcess
	{

		public StoredReportResourcesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

