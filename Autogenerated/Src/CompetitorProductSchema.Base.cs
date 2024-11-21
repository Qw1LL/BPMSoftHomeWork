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

	#region Class: CompetitorProduct_Base_BPMSoftSchema

	/// <exclude/>
	public class CompetitorProduct_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CompetitorProduct_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompetitorProduct_Base_BPMSoftSchema(CompetitorProduct_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompetitorProduct_Base_BPMSoftSchema(CompetitorProduct_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5");
			RealUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5");
			Name = "CompetitorProduct_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("27274924-78bf-4c01-b980-a934997f4a5f")) == null) {
				Columns.Add(CreateCompetitorColumn());
			}
			if (Columns.FindByUId(new Guid("d533eb3b-aa86-413e-88f1-7ee456dda433")) == null) {
				Columns.Add(CreateWeaknessColumn());
			}
			if (Columns.FindByUId(new Guid("fa76bce1-6298-45a5-9f64-fd4d081136af")) == null) {
				Columns.Add(CreateStrengthsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCompetitorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("27274924-78bf-4c01-b980-a934997f4a5f"),
				Name = @"Competitor",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				ModifiedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3d005156-0544-4b66-b8ab-0e82042396ad"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				ModifiedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateWeaknessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d533eb3b-aa86-413e-88f1-7ee456dda433"),
				Name = @"Weakness",
				CreatedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				ModifiedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateStrengthsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fa76bce1-6298-45a5-9f64-fd4d081136af"),
				Name = @"Strengths",
				CreatedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				ModifiedInSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CompetitorProduct_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CompetitorProduct_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompetitorProduct_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompetitorProduct_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"));
		}

		#endregion

	}

	#endregion

	#region Class: CompetitorProduct_Base_BPMSoft

	/// <summary>
	/// Competitor product.
	/// </summary>
	public class CompetitorProduct_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CompetitorProduct_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompetitorProduct_Base_BPMSoft";
		}

		public CompetitorProduct_Base_BPMSoft(CompetitorProduct_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CompetitorId {
			get {
				return GetTypedColumnValue<Guid>("CompetitorId");
			}
			set {
				SetColumnValue("CompetitorId", value);
				_competitor = null;
			}
		}

		/// <exclude/>
		public string CompetitorName {
			get {
				return GetTypedColumnValue<string>("CompetitorName");
			}
			set {
				SetColumnValue("CompetitorName", value);
				if (_competitor != null) {
					_competitor.Name = value;
				}
			}
		}

		private Account _competitor;
		/// <summary>
		/// Manufacturer.
		/// </summary>
		public Account Competitor {
			get {
				return _competitor ??
					(_competitor = LookupColumnEntities.GetEntity("Competitor") as Account);
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

		/// <summary>
		/// Weaknesses.
		/// </summary>
		public string Weakness {
			get {
				return GetTypedColumnValue<string>("Weakness");
			}
			set {
				SetColumnValue("Weakness", value);
			}
		}

		/// <summary>
		/// Strengths.
		/// </summary>
		public string Strengths {
			get {
				return GetTypedColumnValue<string>("Strengths");
			}
			set {
				SetColumnValue("Strengths", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CompetitorProduct_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("CompetitorProduct_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CompetitorProduct_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CompetitorProduct_BaseEventsProcess

	/// <exclude/>
	public partial class CompetitorProduct_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CompetitorProduct_Base_BPMSoft
	{

		public CompetitorProduct_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompetitorProduct_BaseEventsProcess";
			SchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5");
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

	#region Class: CompetitorProduct_BaseEventsProcess

	/// <exclude/>
	public class CompetitorProduct_BaseEventsProcess : CompetitorProduct_BaseEventsProcess<CompetitorProduct_Base_BPMSoft>
	{

		public CompetitorProduct_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CompetitorProduct_BaseEventsProcess

	public partial class CompetitorProduct_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

