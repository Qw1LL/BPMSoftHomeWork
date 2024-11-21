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

	#region Class: ProductTypeInLeadTypeSchema

	/// <exclude/>
	public class ProductTypeInLeadTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProductTypeInLeadTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductTypeInLeadTypeSchema(ProductTypeInLeadTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductTypeInLeadTypeSchema(ProductTypeInLeadTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			RealUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			Name = "ProductTypeInLeadType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductTypeInLeadType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductTypeInLeadType_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductTypeInLeadTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductTypeInLeadTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductTypeInLeadType

	/// <summary>
	/// Тип записи продукта в типе потребности.
	/// </summary>
	public class ProductTypeInLeadType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProductTypeInLeadType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductTypeInLeadType";
		}

		public ProductTypeInLeadType(ProductTypeInLeadType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductTypeInLeadType_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductTypeInLeadTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductTypeInLeadTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProductTypeInLeadTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductTypeInLeadType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductTypeInLeadType_LeadEventsProcess

	/// <exclude/>
	public partial class ProductTypeInLeadType_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProductTypeInLeadType
	{

		public ProductTypeInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductTypeInLeadType_LeadEventsProcess";
			SchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073");
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

	#region Class: ProductTypeInLeadType_LeadEventsProcess

	/// <exclude/>
	public class ProductTypeInLeadType_LeadEventsProcess : ProductTypeInLeadType_LeadEventsProcess<ProductTypeInLeadType>
	{

		public ProductTypeInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductTypeInLeadType_LeadEventsProcess

	public partial class ProductTypeInLeadType_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductTypeInLeadTypeEventsProcess

	/// <exclude/>
	public class ProductTypeInLeadTypeEventsProcess : ProductTypeInLeadType_LeadEventsProcess
	{

		public ProductTypeInLeadTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

