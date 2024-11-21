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

	#region Class: FolderTypeSchema

	/// <exclude/>
	public class FolderTypeSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public FolderTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTypeSchema(FolderTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTypeSchema(FolderTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			RealUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			Name = "FolderType";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c300833-04d9-4742-99c3-f0eb9d7580e8")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6c300833-04d9-4742-99c3-f0eb9d7580e8"),
				Name = @"Order",
				CreatedInSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				ModifiedInSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderType

	/// <summary>
	/// Folder type.
	/// </summary>
	public class FolderType : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public FolderType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderType";
		}

		public FolderType(FolderType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Order.
		/// </summary>
		public int Order {
			get {
				return GetTypedColumnValue<int>("Order");
			}
			set {
				SetColumnValue("Order", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FolderTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("FolderTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("FolderTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("FolderTypeInserting", e);
			Saved += (s, e) => ThrowEvent("FolderTypeSaved", e);
			Saving += (s, e) => ThrowEvent("FolderTypeSaving", e);
			Validating += (s, e) => ThrowEvent("FolderTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FolderType(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderType_BaseEventsProcess

	/// <exclude/>
	public partial class FolderType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : FolderType
	{

		public FolderType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderType_BaseEventsProcess";
			SchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
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

	#region Class: FolderType_BaseEventsProcess

	/// <exclude/>
	public class FolderType_BaseEventsProcess : FolderType_BaseEventsProcess<FolderType>
	{

		public FolderType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderType_BaseEventsProcess

	public partial class FolderType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderTypeEventsProcess

	/// <exclude/>
	public class FolderTypeEventsProcess : FolderType_BaseEventsProcess
	{

		public FolderTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

