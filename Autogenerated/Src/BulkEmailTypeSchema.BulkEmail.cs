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

	#region Class: BulkEmailTypeSchema

	/// <exclude/>
	public class BulkEmailTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailTypeSchema(BulkEmailTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailTypeSchema(BulkEmailTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			RealUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			Name = "BulkEmailType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4a56d91e-9b73-4cba-ba7f-efc6f4bab871")) == null) {
				Columns.Add(CreateIsSignableColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsSignableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4a56d91e-9b73-4cba-ba7f-efc6f4bab871"),
				Name = @"IsSignable",
				CreatedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"),
				ModifiedInSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"),
				CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailType_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailType

	/// <summary>
	/// Тип email.
	/// </summary>
	public class BulkEmailType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailType";
		}

		public BulkEmailType(BulkEmailType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Возможна подписка.
		/// </summary>
		public bool IsSignable {
			get {
				return GetTypedColumnValue<bool>("IsSignable");
			}
			set {
				SetColumnValue("IsSignable", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailType_BulkEmailEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailTypeInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailType(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailType_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailType_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailType
	{

		public BulkEmailType_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailType_BulkEmailEventsProcess";
			SchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f");
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

	#region Class: BulkEmailType_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailType_BulkEmailEventsProcess : BulkEmailType_BulkEmailEventsProcess<BulkEmailType>
	{

		public BulkEmailType_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailType_BulkEmailEventsProcess

	public partial class BulkEmailType_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailTypeEventsProcess

	/// <exclude/>
	public class BulkEmailTypeEventsProcess : BulkEmailType_BulkEmailEventsProcess
	{

		public BulkEmailTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

