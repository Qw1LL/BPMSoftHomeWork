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

	#region Class: Pricelist_ProductCatalogue_BPMSoftSchema

	/// <exclude/>
	public class Pricelist_ProductCatalogue_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public Pricelist_ProductCatalogue_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Pricelist_ProductCatalogue_BPMSoftSchema(Pricelist_ProductCatalogue_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Pricelist_ProductCatalogue_BPMSoftSchema(Pricelist_ProductCatalogue_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			RealUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			Name = "Pricelist_ProductCatalogue_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Pricelist_ProductCatalogue_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Pricelist_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Pricelist_ProductCatalogue_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Pricelist_ProductCatalogue_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("036f6f5b-838d-4187-9749-b54c8539c076"));
		}

		#endregion

	}

	#endregion

	#region Class: Pricelist_ProductCatalogue_BPMSoft

	/// <summary>
	/// Прайс-лист.
	/// </summary>
	public class Pricelist_ProductCatalogue_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Pricelist_ProductCatalogue_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Pricelist_ProductCatalogue_BPMSoft";
		}

		public Pricelist_ProductCatalogue_BPMSoft(Pricelist_ProductCatalogue_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Pricelist_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Pricelist_ProductCatalogue_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Pricelist_ProductCatalogue_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Pricelist_ProductCatalogue_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Pricelist_ProductCatalogue_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Pricelist_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class Pricelist_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Pricelist_ProductCatalogue_BPMSoft
	{

		public Pricelist_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Pricelist_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("036f6f5b-838d-4187-9749-b54c8539c076");
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

	#region Class: Pricelist_ProductCatalogueEventsProcess

	/// <exclude/>
	public class Pricelist_ProductCatalogueEventsProcess : Pricelist_ProductCatalogueEventsProcess<Pricelist_ProductCatalogue_BPMSoft>
	{

		public Pricelist_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Pricelist_ProductCatalogueEventsProcess

	public partial class Pricelist_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

