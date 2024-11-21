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

	#region Class: VwQueueSysSchemaSchema

	/// <exclude/>
	public class VwQueueSysSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwQueueSysSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwQueueSysSchemaSchema(VwQueueSysSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwQueueSysSchemaSchema(VwQueueSysSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42");
			RealUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42");
			Name = "VwQueueSysSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("00cac8a3-8d8a-4366-a160-5c2decb79ff8")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("00cac8a3-8d8a-4366-a160-5c2decb79ff8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"),
				ModifiedInSchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("277fa7cd-88a3-46ba-b579-3661759a4339"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"),
				ModifiedInSchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwQueueSysSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwQueueSysSchema_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwQueueSysSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwQueueSysSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"));
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueSysSchema

	/// <summary>
	/// Доступные типы очередей (представление).
	/// </summary>
	public class VwQueueSysSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwQueueSysSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwQueueSysSchema";
		}

		public VwQueueSysSchema(VwQueueSysSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwQueueSysSchema_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwQueueSysSchemaDeleted", e);
			Validating += (s, e) => ThrowEvent("VwQueueSysSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwQueueSysSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueSysSchema_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class VwQueueSysSchema_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwQueueSysSchema
	{

		public VwQueueSysSchema_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwQueueSysSchema_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42");
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

	#region Class: VwQueueSysSchema_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class VwQueueSysSchema_OperatorSingleWindowEventsProcess : VwQueueSysSchema_OperatorSingleWindowEventsProcess<VwQueueSysSchema>
	{

		public VwQueueSysSchema_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwQueueSysSchema_OperatorSingleWindowEventsProcess

	public partial class VwQueueSysSchema_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwQueueSysSchemaEventsProcess

	/// <exclude/>
	public class VwQueueSysSchemaEventsProcess : VwQueueSysSchema_OperatorSingleWindowEventsProcess
	{

		public VwQueueSysSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

