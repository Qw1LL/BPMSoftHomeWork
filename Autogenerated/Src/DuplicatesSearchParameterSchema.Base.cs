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

	#region Class: DuplicatesSearchParameterSchema

	/// <exclude/>
	public class DuplicatesSearchParameterSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DuplicatesSearchParameterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesSearchParameterSchema(DuplicatesSearchParameterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesSearchParameterSchema(DuplicatesSearchParameterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a");
			RealUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a");
			Name = "DuplicatesSearchParameter";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ed4d38f1-8201-4d23-8fdc-02b52528cf6c")) == null) {
				Columns.Add(CreatePerformSearchOnSaveColumn());
			}
			if (Columns.FindByUId(new Guid("ffd92a9f-638d-4ebf-87ac-13491fc06b6b")) == null) {
				Columns.Add(CreatePerformSheduledSearchColumn());
			}
			if (Columns.FindByUId(new Guid("1c6bfa4f-0ac6-4408-b832-ea48841f7989")) == null) {
				Columns.Add(CreateSearchTimeColumn());
			}
			if (Columns.FindByUId(new Guid("c4bd8f7c-c3be-4e95-a605-454497caf252")) == null) {
				Columns.Add(CreateSearchByModifiedOnlyColumn());
			}
			if (Columns.FindByUId(new Guid("6a56afbb-1647-403c-ba34-9e208c491d87")) == null) {
				Columns.Add(CreateSearchByAllColumn());
			}
			if (Columns.FindByUId(new Guid("f9f0e6eb-dd6e-4894-af0e-f6654c51fbb0")) == null) {
				Columns.Add(CreateDaysColumn());
			}
			if (Columns.FindByUId(new Guid("f304f0b5-31de-4d89-b3bc-e7b617e264eb")) == null) {
				Columns.Add(CreateSchemaToSearchColumn());
			}
			if (Columns.FindByUId(new Guid("9e03ae6d-244b-4439-98cc-01c71eb220a0")) == null) {
				Columns.Add(CreateSchemaToSearchNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePerformSearchOnSaveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ed4d38f1-8201-4d23-8fdc-02b52528cf6c"),
				Name = @"PerformSearchOnSave",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreatePerformSheduledSearchColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ffd92a9f-638d-4ebf-87ac-13491fc06b6b"),
				Name = @"PerformSheduledSearch",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("1c6bfa4f-0ac6-4408-b832-ea48841f7989"),
				Name = @"SearchTime",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchByModifiedOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c4bd8f7c-c3be-4e95-a605-454497caf252"),
				Name = @"SearchByModifiedOnly",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchByAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6a56afbb-1647-403c-ba34-9e208c491d87"),
				Name = @"SearchByAll",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateDaysColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f9f0e6eb-dd6e-4894-af0e-f6654c51fbb0"),
				Name = @"Days",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaToSearchColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f304f0b5-31de-4d89-b3bc-e7b617e264eb"),
				Name = @"SchemaToSearch",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaToSearchNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9e03ae6d-244b-4439-98cc-01c71eb220a0"),
				Name = @"SchemaToSearchName",
				CreatedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				ModifiedInSchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"),
				CreatedInPackageId = new Guid("8bf8ae5e-52c9-44c1-a099-364797b55805")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DuplicatesSearchParameter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesSearchParameter_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesSearchParameterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesSearchParameterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesSearchParameter

	/// <summary>
	/// Duplicates search settings.
	/// </summary>
	public class DuplicatesSearchParameter : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DuplicatesSearchParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesSearchParameter";
		}

		public DuplicatesSearchParameter(DuplicatesSearchParameter source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Search when saving record.
		/// </summary>
		public bool PerformSearchOnSave {
			get {
				return GetTypedColumnValue<bool>("PerformSearchOnSave");
			}
			set {
				SetColumnValue("PerformSearchOnSave", value);
			}
		}

		/// <summary>
		/// Scheduled search.
		/// </summary>
		public bool PerformSheduledSearch {
			get {
				return GetTypedColumnValue<bool>("PerformSheduledSearch");
			}
			set {
				SetColumnValue("PerformSheduledSearch", value);
			}
		}

		/// <summary>
		/// Search time.
		/// </summary>
		public DateTime SearchTime {
			get {
				return GetTypedColumnValue<DateTime>("SearchTime");
			}
			set {
				SetColumnValue("SearchTime", value);
			}
		}

		/// <summary>
		/// Search in modified objects only.
		/// </summary>
		public bool SearchByModifiedOnly {
			get {
				return GetTypedColumnValue<bool>("SearchByModifiedOnly");
			}
			set {
				SetColumnValue("SearchByModifiedOnly", value);
			}
		}

		/// <summary>
		/// Search in all objects.
		/// </summary>
		public bool SearchByAll {
			get {
				return GetTypedColumnValue<bool>("SearchByAll");
			}
			set {
				SetColumnValue("SearchByAll", value);
			}
		}

		/// <summary>
		/// Days.
		/// </summary>
		public int Days {
			get {
				return GetTypedColumnValue<int>("Days");
			}
			set {
				SetColumnValue("Days", value);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public Guid SchemaToSearch {
			get {
				return GetTypedColumnValue<Guid>("SchemaToSearch");
			}
			set {
				SetColumnValue("SchemaToSearch", value);
			}
		}

		/// <summary>
		/// Object name.
		/// </summary>
		public string SchemaToSearchName {
			get {
				return GetTypedColumnValue<string>("SchemaToSearchName");
			}
			set {
				SetColumnValue("SchemaToSearchName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesSearchParameter_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesSearchParameterDeleted", e);
			Deleting += (s, e) => ThrowEvent("DuplicatesSearchParameterDeleting", e);
			Inserted += (s, e) => ThrowEvent("DuplicatesSearchParameterInserted", e);
			Inserting += (s, e) => ThrowEvent("DuplicatesSearchParameterInserting", e);
			Saved += (s, e) => ThrowEvent("DuplicatesSearchParameterSaved", e);
			Saving += (s, e) => ThrowEvent("DuplicatesSearchParameterSaving", e);
			Validating += (s, e) => ThrowEvent("DuplicatesSearchParameterValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesSearchParameter(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesSearchParameter_BaseEventsProcess

	/// <exclude/>
	public partial class DuplicatesSearchParameter_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DuplicatesSearchParameter
	{

		public DuplicatesSearchParameter_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesSearchParameter_BaseEventsProcess";
			SchemaUId = new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("01bff6c2-1ae4-4430-ba9f-1f77bade9c3a");
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

	#region Class: DuplicatesSearchParameter_BaseEventsProcess

	/// <exclude/>
	public class DuplicatesSearchParameter_BaseEventsProcess : DuplicatesSearchParameter_BaseEventsProcess<DuplicatesSearchParameter>
	{

		public DuplicatesSearchParameter_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesSearchParameter_BaseEventsProcess

	public partial class DuplicatesSearchParameter_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesSearchParameterEventsProcess

	/// <exclude/>
	public class DuplicatesSearchParameterEventsProcess : DuplicatesSearchParameter_BaseEventsProcess
	{

		public DuplicatesSearchParameterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

