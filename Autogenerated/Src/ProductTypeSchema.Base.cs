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

	#region Class: ProductType_Base_BPMSoftSchema

	/// <exclude/>
	public class ProductType_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProductType_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductType_Base_BPMSoftSchema(ProductType_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductType_Base_BPMSoftSchema(ProductType_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			RealUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			Name = "ProductType_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b38bd826-cb96-46fc-8798-992420f5ef87")) == null) {
				Columns.Add(CreateIsServiceColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b38bd826-cb96-46fc-8798-992420f5ef87"),
				Name = @"IsService",
				CreatedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
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
			return new ProductType_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductType_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductType_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_Base_BPMSoft

	/// <summary>
	/// Product type.
	/// </summary>
	public class ProductType_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProductType_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductType_Base_BPMSoft";
		}

		public ProductType_Base_BPMSoft(ProductType_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Service.
		/// </summary>
		public bool IsService {
			get {
				return GetTypedColumnValue<bool>("IsService");
			}
			set {
				SetColumnValue("IsService", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductType_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("ProductType_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("ProductType_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("ProductType_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ProductType_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("ProductType_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("ProductType_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductType_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_BaseEventsProcess

	/// <exclude/>
	public partial class ProductType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProductType_Base_BPMSoft
	{

		public ProductType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductType_BaseEventsProcess";
			SchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
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

	#region Class: ProductType_BaseEventsProcess

	/// <exclude/>
	public class ProductType_BaseEventsProcess : ProductType_BaseEventsProcess<ProductType_Base_BPMSoft>
	{

		public ProductType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductType_BaseEventsProcess

	public partial class ProductType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

