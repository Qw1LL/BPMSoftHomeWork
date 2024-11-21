namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwRecentCallSchema

	/// <exclude/>
	public class VwRecentCallSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwRecentCallSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwRecentCallSchema(VwRecentCallSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwRecentCallSchema(VwRecentCallSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73");
			RealUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73");
			Name = "VwRecentCall";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66721ee9-20ab-40fe-a9a1-3b668222939d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("961b2687-014d-4bbe-a937-699060c2d7c3")) == null) {
				Columns.Add(CreateCallColumn());
			}
			if (Columns.FindByUId(new Guid("b0671192-e314-47c6-a10b-57739a46ea41")) == null) {
				Columns.Add(CreateCreatedByIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b4a29e1d-155b-46bd-b664-145f43ab9e18"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				ModifiedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				CreatedInPackageId = new Guid("66721ee9-20ab-40fe-a9a1-3b668222939d")
			};
		}

		protected virtual EntitySchemaColumn CreateCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("961b2687-014d-4bbe-a937-699060c2d7c3"),
				Name = @"Call",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				ModifiedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				CreatedInPackageId = new Guid("b6d5539c-db4d-4101-9bbb-74f699ab92cd")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedByIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b0671192-e314-47c6-a10b-57739a46ea41"),
				Name = @"CreatedById",
				CreatedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				ModifiedInSchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"),
				CreatedInPackageId = new Guid("66546323-e613-47c2-afd8-43e728c055f5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwRecentCall(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwRecentCall_CTIBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwRecentCallSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwRecentCallSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73"));
		}

		#endregion

	}

	#endregion

	#region Class: VwRecentCall

	/// <summary>
	/// Last calls.
	/// </summary>
	public class VwRecentCall : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRecentCall(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRecentCall";
		}

		public VwRecentCall(VwRecentCall source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid CallId {
			get {
				return GetTypedColumnValue<Guid>("CallId");
			}
			set {
				SetColumnValue("CallId", value);
				_call = null;
			}
		}

		/// <exclude/>
		public string CallCaption {
			get {
				return GetTypedColumnValue<string>("CallCaption");
			}
			set {
				SetColumnValue("CallCaption", value);
				if (_call != null) {
					_call.Caption = value;
				}
			}
		}

		private Call _call;
		/// <summary>
		/// Call.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = LookupColumnEntities.GetEntity("Call") as Call);
			}
		}

		/// <summary>
		/// CreatedById.
		/// </summary>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwRecentCall_CTIBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwRecentCall(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwRecentCall_CTIBaseEventsProcess

	/// <exclude/>
	public partial class VwRecentCall_CTIBaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwRecentCall
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwRecentCall_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwRecentCall_CTIBaseEventsProcess";
			SchemaUId = new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50a06370-1d10-4f4a-802f-8691d5e16e73");
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

	#region Class: VwRecentCall_CTIBaseEventsProcess

	/// <exclude/>
	public class VwRecentCall_CTIBaseEventsProcess : VwRecentCall_CTIBaseEventsProcess<VwRecentCall>
	{

		public VwRecentCall_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwRecentCall_CTIBaseEventsProcess

	public partial class VwRecentCall_CTIBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwRecentCallEventsProcess

	/// <exclude/>
	public class VwRecentCallEventsProcess : VwRecentCall_CTIBaseEventsProcess
	{

		public VwRecentCallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

