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

	#region Class: BaseAnniversarySchema

	/// <exclude/>
	[IsVirtual]
	public class BaseAnniversarySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseAnniversarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseAnniversarySchema(BaseAnniversarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseAnniversarySchema(BaseAnniversarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			RealUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			Name = "BaseAnniversary";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ce66aa7d-8443-4b5a-a7fe-a90ae4e809de")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("93c29696-307b-45f3-a799-b51670bdfcb6")) == null) {
				Columns.Add(CreateAnniversaryTypeColumn());
			}
			if (Columns.FindByUId(new Guid("fac11c8a-b9a5-4059-b704-d5d1d2b55d88")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ce66aa7d-8443-4b5a-a7fe-a90ae4e809de"),
				Name = @"Date",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAnniversaryTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("93c29696-307b-45f3-a799-b51670bdfcb6"),
				Name = @"AnniversaryType",
				ReferenceSchemaUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fac11c8a-b9a5-4059-b704-d5d1d2b55d88"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				ModifiedInSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseAnniversary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseAnniversary_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseAnniversarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseAnniversarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseAnniversary

	/// <summary>
	/// Base noteworthy event.
	/// </summary>
	public class BaseAnniversary : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseAnniversary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseAnniversary";
		}

		public BaseAnniversary(BaseAnniversary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid AnniversaryTypeId {
			get {
				return GetTypedColumnValue<Guid>("AnniversaryTypeId");
			}
			set {
				SetColumnValue("AnniversaryTypeId", value);
				_anniversaryType = null;
			}
		}

		/// <exclude/>
		public string AnniversaryTypeName {
			get {
				return GetTypedColumnValue<string>("AnniversaryTypeName");
			}
			set {
				SetColumnValue("AnniversaryTypeName", value);
				if (_anniversaryType != null) {
					_anniversaryType.Name = value;
				}
			}
		}

		private AnniversaryType _anniversaryType;
		/// <summary>
		/// Type.
		/// </summary>
		public AnniversaryType AnniversaryType {
			get {
				return _anniversaryType ??
					(_anniversaryType = LookupColumnEntities.GetEntity("AnniversaryType") as AnniversaryType);
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
			var process = new BaseAnniversary_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseAnniversaryDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseAnniversaryDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseAnniversaryInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseAnniversaryInserting", e);
			Saved += (s, e) => ThrowEvent("BaseAnniversarySaved", e);
			Saving += (s, e) => ThrowEvent("BaseAnniversarySaving", e);
			Validating += (s, e) => ThrowEvent("BaseAnniversaryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseAnniversary(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseAnniversary_BaseEventsProcess

	/// <exclude/>
	public partial class BaseAnniversary_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseAnniversary
	{

		public BaseAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseAnniversary_BaseEventsProcess";
			SchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
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

	#region Class: BaseAnniversary_BaseEventsProcess

	/// <exclude/>
	public class BaseAnniversary_BaseEventsProcess : BaseAnniversary_BaseEventsProcess<BaseAnniversary>
	{

		public BaseAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseAnniversary_BaseEventsProcess

	public partial class BaseAnniversary_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseAnniversaryEventsProcess

	/// <exclude/>
	public class BaseAnniversaryEventsProcess : BaseAnniversary_BaseEventsProcess
	{

		public BaseAnniversaryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

