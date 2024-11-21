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

	#region Class: TradeMarkSchema

	/// <exclude/>
	public class TradeMarkSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TradeMarkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TradeMarkSchema(TradeMarkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TradeMarkSchema(TradeMarkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			RealUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			Name = "TradeMark";
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
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
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
			return new TradeMark(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TradeMark_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TradeMarkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TradeMarkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc"));
		}

		#endregion

	}

	#endregion

	#region Class: TradeMark

	/// <summary>
	/// Торговая марка.
	/// </summary>
	public class TradeMark : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TradeMark(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TradeMark";
		}

		public TradeMark(TradeMark source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TradeMark_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TradeMarkDeleted", e);
			Inserting += (s, e) => ThrowEvent("TradeMarkInserting", e);
			Validating += (s, e) => ThrowEvent("TradeMarkValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TradeMark(this);
		}

		#endregion

	}

	#endregion

	#region Class: TradeMark_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class TradeMark_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TradeMark
	{

		public TradeMark_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TradeMark_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc");
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

	#region Class: TradeMark_ProductCatalogueEventsProcess

	/// <exclude/>
	public class TradeMark_ProductCatalogueEventsProcess : TradeMark_ProductCatalogueEventsProcess<TradeMark>
	{

		public TradeMark_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TradeMark_ProductCatalogueEventsProcess

	public partial class TradeMark_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TradeMarkEventsProcess

	/// <exclude/>
	public class TradeMarkEventsProcess : TradeMark_ProductCatalogueEventsProcess
	{

		public TradeMarkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

