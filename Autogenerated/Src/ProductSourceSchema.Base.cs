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

	#region Class: ProductSourceSchema

	/// <exclude/>
	public class ProductSourceSchema : BPMSoft.Configuration.BaseImageLookupSchema
	{

		#region Constructors: Public

		public ProductSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductSourceSchema(ProductSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductSourceSchema(ProductSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			RealUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			Name = "ProductSource";
			ParentSchemaUId = new Guid("b4a781bd-bacd-4ba1-a16b-48c09a21f087");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductSource_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductSource

	/// <summary>
	/// Product source.
	/// </summary>
	public class ProductSource : BPMSoft.Configuration.BaseImageLookup
	{

		#region Constructors: Public

		public ProductSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductSource";
		}

		public ProductSource(ProductSource source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductSource_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductSourceDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductSourceInserting", e);
			Validating += (s, e) => ThrowEvent("ProductSourceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductSource_BaseEventsProcess

	/// <exclude/>
	public partial class ProductSource_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseImageLookup_BaseEventsProcess<TEntity> where TEntity : ProductSource
	{

		public ProductSource_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductSource_BaseEventsProcess";
			SchemaUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0");
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

	#region Class: ProductSource_BaseEventsProcess

	/// <exclude/>
	public class ProductSource_BaseEventsProcess : ProductSource_BaseEventsProcess<ProductSource>
	{

		public ProductSource_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductSource_BaseEventsProcess

	public partial class ProductSource_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductSourceEventsProcess

	/// <exclude/>
	public class ProductSourceEventsProcess : ProductSource_BaseEventsProcess
	{

		public ProductSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

