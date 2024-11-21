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

	#region Class: ActivityResultSchema

	/// <exclude/>
	public class ActivityResultSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ActivityResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityResultSchema(ActivityResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityResultSchema(ActivityResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
			RealUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
			Name = "ActivityResult";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("53fd3525-a4b3-4fe1-b1f2-2ce79128f5e4")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("28dedc44-4148-44b3-a642-5bfe30e3e8af")) == null) {
				Columns.Add(CreateBusinessProcessOnlyColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("53fd3525-a4b3-4fe1-b1f2-2ce79128f5e4"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				ModifiedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099")
			};
		}

		protected virtual EntitySchemaColumn CreateBusinessProcessOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("28dedc44-4148-44b3-a642-5bfe30e3e8af"),
				Name = @"BusinessProcessOnly",
				CreatedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				ModifiedInSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				CreatedInPackageId = new Guid("1687c2a3-d7aa-4424-abab-d22315cd0bba")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityResult_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResult

	/// <summary>
	/// Result of activity.
	/// </summary>
	public class ActivityResult : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ActivityResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityResult";
		}

		public ActivityResult(ActivityResult source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ActivityResultCategory _category;
		/// <summary>
		/// Category.
		/// </summary>
		public ActivityResultCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as ActivityResultCategory);
			}
		}

		/// <summary>
		/// Available in business process only.
		/// </summary>
		public bool BusinessProcessOnly {
			get {
				return GetTypedColumnValue<bool>("BusinessProcessOnly");
			}
			set {
				SetColumnValue("BusinessProcessOnly", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityResult_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityResultDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityResultDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityResultInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityResultInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityResultSaved", e);
			Saving += (s, e) => ThrowEvent("ActivityResultSaving", e);
			Validating += (s, e) => ThrowEvent("ActivityResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResult_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityResult_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ActivityResult
	{

		public ActivityResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityResult_BaseEventsProcess";
			SchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948");
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

	#region Class: ActivityResult_BaseEventsProcess

	/// <exclude/>
	public class ActivityResult_BaseEventsProcess : ActivityResult_BaseEventsProcess<ActivityResult>
	{

		public ActivityResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityResult_BaseEventsProcess

	public partial class ActivityResult_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityResultEventsProcess

	/// <exclude/>
	public class ActivityResultEventsProcess : ActivityResult_BaseEventsProcess
	{

		public ActivityResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

