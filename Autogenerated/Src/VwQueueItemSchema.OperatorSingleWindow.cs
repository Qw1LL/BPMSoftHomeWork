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

	#region Class: VwQueueItem_OperatorSingleWindow_BPMSoftSchema

	/// <exclude/>
	public class VwQueueItem_OperatorSingleWindow_BPMSoftSchema : BPMSoft.Configuration.QueueItemSchema
	{

		#region Constructors: Public

		public VwQueueItem_OperatorSingleWindow_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwQueueItem_OperatorSingleWindow_BPMSoftSchema(VwQueueItem_OperatorSingleWindow_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwQueueItem_OperatorSingleWindow_BPMSoftSchema(VwQueueItem_OperatorSingleWindow_BPMSoftSchema source)
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
			UId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			RealUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			Name = "VwQueueItem_OperatorSingleWindow_BPMSoft";
			ParentSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5e667a77-85ba-48fd-906c-e2f7f26b8e6d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9e6ee389-2a71-4950-bf9e-a6b18b48ec1e")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("7794b818-60e5-4cb9-99af-e7d43efc6f95")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("91cb652b-5769-4210-afe5-d7145cc4687d")) == null) {
				Columns.Add(CreateLastActivityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9e6ee389-2a71-4950-bf9e-a6b18b48ec1e"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				ModifiedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				CreatedInPackageId = new Guid("da9d27e8-fcb8-44f6-85d5-e52d7912ab44")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7794b818-60e5-4cb9-99af-e7d43efc6f95"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				ModifiedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				CreatedInPackageId = new Guid("da9d27e8-fcb8-44f6-85d5-e52d7912ab44")
			};
		}

		protected virtual EntitySchemaColumn CreateLastActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("91cb652b-5769-4210-afe5-d7145cc4687d"),
				Name = @"LastActivity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				ModifiedInSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				CreatedInPackageId = new Guid("63f413ca-9930-4bfd-b41c-141316c68227")
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
			return new VwQueueItem_OperatorSingleWindow_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwQueueItem_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwQueueItem_OperatorSingleWindow_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwQueueItem_OperatorSingleWindow_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"));
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem_OperatorSingleWindow_BPMSoft

	/// <summary>
	/// Элемент очереди единого окна (представление).
	/// </summary>
	public class VwQueueItem_OperatorSingleWindow_BPMSoft : BPMSoft.Configuration.QueueItem
	{

		#region Constructors: Public

		public VwQueueItem_OperatorSingleWindow_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwQueueItem_OperatorSingleWindow_BPMSoft";
		}

		public VwQueueItem_OperatorSingleWindow_BPMSoft(VwQueueItem_OperatorSingleWindow_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid LastActivityId {
			get {
				return GetTypedColumnValue<Guid>("LastActivityId");
			}
			set {
				SetColumnValue("LastActivityId", value);
				_lastActivity = null;
			}
		}

		/// <exclude/>
		public string LastActivityTitle {
			get {
				return GetTypedColumnValue<string>("LastActivityTitle");
			}
			set {
				SetColumnValue("LastActivityTitle", value);
				if (_lastActivity != null) {
					_lastActivity.Title = value;
				}
			}
		}

		private Activity _lastActivity;
		/// <summary>
		/// Последняя активность.
		/// </summary>
		public Activity LastActivity {
			get {
				return _lastActivity ??
					(_lastActivity = LookupColumnEntities.GetEntity("LastActivity") as Activity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwQueueItem_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwQueueItem_OperatorSingleWindow_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("VwQueueItem_OperatorSingleWindow_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwQueueItem_OperatorSingleWindow_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class VwQueueItem_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.QueueItem_OperatorSingleWindowEventsProcess<TEntity> where TEntity : VwQueueItem_OperatorSingleWindow_BPMSoft
	{

		public VwQueueItem_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwQueueItem_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
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

	#region Class: VwQueueItem_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class VwQueueItem_OperatorSingleWindowEventsProcess : VwQueueItem_OperatorSingleWindowEventsProcess<VwQueueItem_OperatorSingleWindow_BPMSoft>
	{

		public VwQueueItem_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwQueueItem_OperatorSingleWindowEventsProcess

	public partial class VwQueueItem_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

