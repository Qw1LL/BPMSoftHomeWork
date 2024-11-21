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

	#region Class: FastReportDataSourceSchema

	/// <exclude/>
	public class FastReportDataSourceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FastReportDataSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FastReportDataSourceSchema(FastReportDataSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FastReportDataSourceSchema(FastReportDataSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1");
			RealUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1");
			Name = "FastReportDataSource";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8280c0b2-8af4-45f1-8734-d547fc37d697")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("2e44c9ed-75ba-4c64-aa66-9830669a10ea")) == null) {
				Columns.Add(CreateTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("bf9497a7-6276-49f1-b7c0-121e2f8cf2b7")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("187bdef6-1563-4316-b4cd-989a554e0a9e")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8280c0b2-8af4-45f1-8734-d547fc37d697"),
				Name = @"Data",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				ModifiedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2e44c9ed-75ba-4c64-aa66-9830669a10ea"),
				Name = @"Template",
				ReferenceSchemaUId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				ModifiedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("bf9497a7-6276-49f1-b7c0-121e2f8cf2b7"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				ModifiedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("187bdef6-1563-4316-b4cd-989a554e0a9e"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				ModifiedInSchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"),
				CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FastReportDataSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FastReportDataSource_FastReportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FastReportDataSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FastReportDataSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c01d240-dae6-49b9-b997-809920e45fb1"));
		}

		#endregion

	}

	#endregion

	#region Class: FastReportDataSource

	/// <summary>
	/// FastReportDataSource.
	/// </summary>
	public class FastReportDataSource : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FastReportDataSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FastReportDataSource";
		}

		public FastReportDataSource(FastReportDataSource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Data.
		/// </summary>
		public string Data {
			get {
				return GetTypedColumnValue<string>("Data");
			}
			set {
				SetColumnValue("Data", value);
			}
		}

		/// <exclude/>
		public Guid TemplateId {
			get {
				return GetTypedColumnValue<Guid>("TemplateId");
			}
			set {
				SetColumnValue("TemplateId", value);
				_template = null;
			}
		}

		private FastReportTemplate _template;
		/// <summary>
		/// Template.
		/// </summary>
		public FastReportTemplate Template {
			get {
				return _template ??
					(_template = LookupColumnEntities.GetEntity("Template") as FastReportTemplate);
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

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		private FRDataSourceType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public FRDataSourceType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as FRDataSourceType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FastReportDataSource_FastReportEventsProcess(UserConnection);
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
			return new FastReportDataSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: FastReportDataSource_FastReportEventsProcess

	/// <exclude/>
	public partial class FastReportDataSource_FastReportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FastReportDataSource
	{

		public FastReportDataSource_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FastReportDataSource_FastReportEventsProcess";
			SchemaUId = new Guid("9c01d240-dae6-49b9-b997-809920e45fb1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9c01d240-dae6-49b9-b997-809920e45fb1");
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

	#region Class: FastReportDataSource_FastReportEventsProcess

	/// <exclude/>
	public class FastReportDataSource_FastReportEventsProcess : FastReportDataSource_FastReportEventsProcess<FastReportDataSource>
	{

		public FastReportDataSource_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FastReportDataSource_FastReportEventsProcess

	public partial class FastReportDataSource_FastReportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FastReportDataSourceEventsProcess

	/// <exclude/>
	public class FastReportDataSourceEventsProcess : FastReportDataSource_FastReportEventsProcess
	{

		public FastReportDataSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

