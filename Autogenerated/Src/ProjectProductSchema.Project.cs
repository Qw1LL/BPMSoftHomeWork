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

	#region Class: ProjectProductSchema

	/// <exclude/>
	public class ProjectProductSchema : BPMSoft.Configuration.BaseProductEntrySchema
	{

		#region Constructors: Public

		public ProjectProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectProductSchema(ProjectProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectProductSchema(ProjectProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			RealUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			Name = "ProjectProduct";
			ParentSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("888eeaa9-213e-4ec1-8efd-9c689ef5ed86")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("cd01ea82-5717-4020-9340-fb67bbb6e221")) == null) {
				Columns.Add(CreateCostColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProductColumn() {
			EntitySchemaColumn column = base.CreateProductColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCustomProductColumn() {
			EntitySchemaColumn column = base.CreateCustomProductColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDeliveryDateColumn() {
			EntitySchemaColumn column = base.CreateDeliveryDateColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateQuantityColumn() {
			EntitySchemaColumn column = base.CreateQuantityColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateUnitColumn() {
			EntitySchemaColumn column = base.CreateUnitColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryPriceColumn() {
			EntitySchemaColumn column = base.CreatePrimaryPriceColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePriceColumn() {
			EntitySchemaColumn column = base.CreatePriceColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateAmountColumn() {
			EntitySchemaColumn column = base.CreateAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryDiscountAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryDiscountAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountAmountColumn() {
			EntitySchemaColumn column = base.CreateDiscountAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountPercentColumn() {
			EntitySchemaColumn column = base.CreateDiscountPercentColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxColumn() {
			EntitySchemaColumn column = base.CreateTaxColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryTaxAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryTaxAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxAmountColumn() {
			EntitySchemaColumn column = base.CreateTaxAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryTotalAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryTotalAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateTotalAmountColumn() {
			EntitySchemaColumn column = base.CreateTotalAmountColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountTaxColumn() {
			EntitySchemaColumn column = base.CreateDiscountTaxColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("888eeaa9-213e-4ec1-8efd-9c689ef5ed86"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336"),
				ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("cd01ea82-5717-4020-9340-fb67bbb6e221"),
				Name = @"Cost",
				CreatedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336"),
				ModifiedInSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectProduct_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectProduct

	/// <summary>
	/// Продукт в проекте.
	/// </summary>
	public class ProjectProduct : BPMSoft.Configuration.BaseProductEntry
	{

		#region Constructors: Public

		public ProjectProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectProduct";
		}

		public ProjectProduct(ProjectProduct source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as Project);
			}
		}

		/// <summary>
		/// Себестоимость.
		/// </summary>
		public Decimal Cost {
			get {
				return GetTypedColumnValue<Decimal>("Cost");
			}
			set {
				SetColumnValue("Cost", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectProduct_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectProductDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectProductInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectProduct_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectProduct_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseProductEntry_ProductCatalogueEventsProcess<TEntity> where TEntity : ProjectProduct
	{

		public ProjectProduct_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectProduct_ProjectEventsProcess";
			SchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
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

	#region Class: ProjectProduct_ProjectEventsProcess

	/// <exclude/>
	public class ProjectProduct_ProjectEventsProcess : ProjectProduct_ProjectEventsProcess<ProjectProduct>
	{

		public ProjectProduct_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectProduct_ProjectEventsProcess

	public partial class ProjectProduct_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectProductEventsProcess

	/// <exclude/>
	public class ProjectProductEventsProcess : ProjectProduct_ProjectEventsProcess
	{

		public ProjectProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

