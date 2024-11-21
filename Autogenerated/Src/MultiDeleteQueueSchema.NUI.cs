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

	#region Class: MultiDeleteQueueSchema

	/// <exclude/>
	public class MultiDeleteQueueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MultiDeleteQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MultiDeleteQueueSchema(MultiDeleteQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MultiDeleteQueueSchema(MultiDeleteQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289");
			RealUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289");
			Name = "MultiDeleteQueue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ce3a2d7d-d868-4c9f-98b7-10e0dc582b15")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("a4a21a04-10a8-425b-8fce-94fc28b09b06")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("4353ea27-1c84-4dea-be3e-6aa501a3e217")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("85b2e319-aa3a-477b-b136-4bfce8f15e0d")) == null) {
				Columns.Add(CreateDenyReasonColumn());
			}
			if (Columns.FindByUId(new Guid("2fee21e4-124f-47c9-ac04-90f6a1e3f0e5")) == null) {
				Columns.Add(CreateOperationKeyColumn());
			}
			if (Columns.FindByUId(new Guid("34e77cb9-e2fa-480c-823b-da4dc431518e")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("4946e036-754a-45f5-b3c1-b25f8387b3d7")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ec22f463-b899-47bd-964f-d7fc3b496946")) == null) {
				Columns.Add(CreateIsRootColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ce3a2d7d-d868-4c9f-98b7-10e0dc582b15"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a4a21a04-10a8-425b-8fce-94fc28b09b06"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4353ea27-1c84-4dea-be3e-6aa501a3e217"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateDenyReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("85b2e319-aa3a-477b-b136-4bfce8f15e0d"),
				Name = @"DenyReason",
				ReferenceSchemaUId = new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2fee21e4-124f-47c9-ac04-90f6a1e3f0e5"),
				Name = @"OperationKey",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("34e77cb9-e2fa-480c-823b-da4dc431518e"),
				Name = @"State",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4946e036-754a-45f5-b3c1-b25f8387b3d7"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected virtual EntitySchemaColumn CreateIsRootColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ec22f463-b899-47bd-964f-d7fc3b496946"),
				Name = @"IsRoot",
				CreatedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				ModifiedInSchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"),
				CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MultiDeleteQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MultiDeleteQueue_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MultiDeleteQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MultiDeleteQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289"));
		}

		#endregion

	}

	#endregion

	#region Class: MultiDeleteQueue

	/// <summary>
	/// Errors of multi deleting.
	/// </summary>
	public class MultiDeleteQueue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MultiDeleteQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MultiDeleteQueue";
		}

		public MultiDeleteQueue(MultiDeleteQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnitId.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid DenyReasonId {
			get {
				return GetTypedColumnValue<Guid>("DenyReasonId");
			}
			set {
				SetColumnValue("DenyReasonId", value);
				_denyReason = null;
			}
		}

		/// <exclude/>
		public string DenyReasonName {
			get {
				return GetTypedColumnValue<string>("DenyReasonName");
			}
			set {
				SetColumnValue("DenyReasonName", value);
				if (_denyReason != null) {
					_denyReason.Name = value;
				}
			}
		}

		private MultiDeleteDenyReason _denyReason;
		/// <summary>
		/// DenyReason.
		/// </summary>
		public MultiDeleteDenyReason DenyReason {
			get {
				return _denyReason ??
					(_denyReason = LookupColumnEntities.GetEntity("DenyReason") as MultiDeleteDenyReason);
			}
		}

		/// <summary>
		/// OperationKey.
		/// </summary>
		public Guid OperationKey {
			get {
				return GetTypedColumnValue<Guid>("OperationKey");
			}
			set {
				SetColumnValue("OperationKey", value);
			}
		}

		/// <summary>
		/// State.
		/// </summary>
		public int State {
			get {
				return GetTypedColumnValue<int>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// IsRoot.
		/// </summary>
		public bool IsRoot {
			get {
				return GetTypedColumnValue<bool>("IsRoot");
			}
			set {
				SetColumnValue("IsRoot", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MultiDeleteQueue_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MultiDeleteQueueDeleted", e);
			Validating += (s, e) => ThrowEvent("MultiDeleteQueueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MultiDeleteQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: MultiDeleteQueue_NUIEventsProcess

	/// <exclude/>
	public partial class MultiDeleteQueue_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MultiDeleteQueue
	{

		public MultiDeleteQueue_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MultiDeleteQueue_NUIEventsProcess";
			SchemaUId = new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0269d4c2-6a9b-4e59-bc85-bd3f8a497289");
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

	#region Class: MultiDeleteQueue_NUIEventsProcess

	/// <exclude/>
	public class MultiDeleteQueue_NUIEventsProcess : MultiDeleteQueue_NUIEventsProcess<MultiDeleteQueue>
	{

		public MultiDeleteQueue_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MultiDeleteQueue_NUIEventsProcess

	public partial class MultiDeleteQueue_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MultiDeleteQueueEventsProcess

	/// <exclude/>
	public class MultiDeleteQueueEventsProcess : MultiDeleteQueue_NUIEventsProcess
	{

		public MultiDeleteQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

