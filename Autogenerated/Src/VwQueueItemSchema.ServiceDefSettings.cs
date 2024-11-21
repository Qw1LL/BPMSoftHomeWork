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

	#region Class: VwQueueItem_ServiceDefSettings_BPMSoftSchema

	/// <exclude/>
	public class VwQueueItem_ServiceDefSettings_BPMSoftSchema : BPMSoft.Configuration.VwQueueItem_OperatorSingleWindow_BPMSoftSchema
	{

		#region Constructors: Public

		public VwQueueItem_ServiceDefSettings_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwQueueItem_ServiceDefSettings_BPMSoftSchema(VwQueueItem_ServiceDefSettings_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwQueueItem_ServiceDefSettings_BPMSoftSchema(VwQueueItem_ServiceDefSettings_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIQueueItemEntityRecordIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("92e31a43-ffdc-40be-809b-d528523bace9");
			index.Name = "IQueueItemEntityRecordId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn entityRecordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2bdc98e1-62f3-48a6-9fc0-74cce71d2f69"),
				ColumnUId = new Guid("c4b1d2f2-528c-4e66-9440-67125f0707dd"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityRecordIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIQueueItemSysProcessDataIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("0341d1a1-1e56-4cc1-a0ff-e6cea07f196d");
			index.Name = "IQueueItemSysProcessDataId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn sysProcessDataIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ed385332-3853-404c-aaeb-879761c31bae"),
				ColumnUId = new Guid("96eca8e1-84f2-4c9d-8b05-8c0d852211bf"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysProcessDataIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("1412eae1-07a8-4fae-9a37-9bfa892c08c9");
			Name = "VwQueueItem_ServiceDefSettings_BPMSoft";
			ParentSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2d636655-6630-4b37-8c29-3ad78a11374d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7f5f7e2d-cdc3-4308-a308-d365aa4af661")) == null) {
				Columns.Add(CreateCaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7f5f7e2d-cdc3-4308-a308-d365aa4af661"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1412eae1-07a8-4fae-9a37-9bfa892c08c9"),
				ModifiedInSchemaUId = new Guid("1412eae1-07a8-4fae-9a37-9bfa892c08c9"),
				CreatedInPackageId = new Guid("2d636655-6630-4b37-8c29-3ad78a11374d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIQueueItemEntityRecordIdIndex());
			Indexes.Add(CreateIQueueItemSysProcessDataIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwQueueItem_ServiceDefSettings_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwQueueItem_ServiceDefSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwQueueItem_ServiceDefSettings_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwQueueItem_ServiceDefSettings_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1412eae1-07a8-4fae-9a37-9bfa892c08c9"));
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem_ServiceDefSettings_BPMSoft

	/// <summary>
	/// Элемент очереди единого окна (представление).
	/// </summary>
	public class VwQueueItem_ServiceDefSettings_BPMSoft : BPMSoft.Configuration.VwQueueItem_OperatorSingleWindow_BPMSoft
	{

		#region Constructors: Public

		public VwQueueItem_ServiceDefSettings_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwQueueItem_ServiceDefSettings_BPMSoft";
		}

		public VwQueueItem_ServiceDefSettings_BPMSoft(VwQueueItem_ServiceDefSettings_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwQueueItem_ServiceDefSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwQueueItem_ServiceDefSettings_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("VwQueueItem_ServiceDefSettings_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwQueueItem_ServiceDefSettings_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem_ServiceDefSettingsEventsProcess

	/// <exclude/>
	public partial class VwQueueItem_ServiceDefSettingsEventsProcess<TEntity> : BPMSoft.Configuration.VwQueueItem_OperatorSingleWindowEventsProcess<TEntity> where TEntity : VwQueueItem_ServiceDefSettings_BPMSoft
	{

		public VwQueueItem_ServiceDefSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwQueueItem_ServiceDefSettingsEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1412eae1-07a8-4fae-9a37-9bfa892c08c9");
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

	#region Class: VwQueueItem_ServiceDefSettingsEventsProcess

	/// <exclude/>
	public class VwQueueItem_ServiceDefSettingsEventsProcess : VwQueueItem_ServiceDefSettingsEventsProcess<VwQueueItem_ServiceDefSettings_BPMSoft>
	{

		public VwQueueItem_ServiceDefSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwQueueItem_ServiceDefSettingsEventsProcess

	public partial class VwQueueItem_ServiceDefSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

