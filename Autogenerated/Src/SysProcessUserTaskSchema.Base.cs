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

	#region Class: SysProcessUserTaskSchema

	/// <exclude/>
	public class SysProcessUserTaskSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessUserTaskSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessUserTaskSchema(SysProcessUserTaskSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessUserTaskSchema(SysProcessUserTaskSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4");
			RealUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4");
			Name = "SysProcessUserTask";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
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

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateSysImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dca9757d-d70d-48d2-b9bc-a85adc98a857")) == null) {
				Columns.Add(CreateSysUserTaskSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("665448a6-ddbc-4be1-a35d-591d24d89c8b")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("cba9c2d9-7f00-4e13-8d4b-9e7600756311")) == null) {
				Columns.Add(CreateQuickModelEditPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("1197f3f5-40f7-4e19-b756-c5c98a7d0611")) == null) {
				Columns.Add(CreateIsQuickModelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysUserTaskSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dca9757d-d70d-48d2-b9bc-a85adc98a857"),
				Name = @"SysUserTaskSchemaUId",
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("665448a6-ddbc-4be1-a35d-591d24d89c8b"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateQuickModelEditPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cba9c2d9-7f00-4e13-8d4b-9e7600756311"),
				Name = @"QuickModelEditPageSchemaUId",
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("30e6d260-e2d2-4b16-8917-37c7da363d32")
			};
		}

		protected virtual EntitySchemaColumn CreateIsQuickModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1197f3f5-40f7-4e19-b756-c5c98a7d0611"),
				Name = @"IsQuickModel",
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("30e6d260-e2d2-4b16-8917-37c7da363d32")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9ed509d4-808b-42dd-904d-10a3df4408fb"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("30e6d260-e2d2-4b16-8917-37c7da363d32")
			};
		}

		protected virtual EntitySchemaColumn CreateSysImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("d357532d-5b37-4c1f-86ff-40beec3a4d12"),
				Name = @"SysImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				ModifiedInSchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"),
				CreatedInPackageId = new Guid("8faebbb4-6032-45a8-ace5-f8b3ded3b01d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessUserTask(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessUserTask_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessUserTaskSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessUserTaskSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTask

	/// <summary>
	/// Process user task.
	/// </summary>
	public class SysProcessUserTask : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessUserTask";
		}

		public SysProcessUserTask(SysProcessUserTask source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Identifier of user task.
		/// </summary>
		public Guid SysUserTaskSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysUserTaskSchemaUId");
			}
			set {
				SetColumnValue("SysUserTaskSchemaUId", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// UserTask page schema for QuickModel.
		/// </summary>
		public Guid QuickModelEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("QuickModelEditPageSchemaUId");
			}
			set {
				SetColumnValue("QuickModelEditPageSchemaUId", value);
			}
		}

		/// <summary>
		/// QuickModel-compatible.
		/// </summary>
		public bool IsQuickModel {
			get {
				return GetTypedColumnValue<bool>("IsQuickModel");
			}
			set {
				SetColumnValue("IsQuickModel", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid SysImageId {
			get {
				return GetTypedColumnValue<Guid>("SysImageId");
			}
			set {
				SetColumnValue("SysImageId", value);
				_sysImage = null;
			}
		}

		/// <exclude/>
		public string SysImageName {
			get {
				return GetTypedColumnValue<string>("SysImageName");
			}
			set {
				SetColumnValue("SysImageName", value);
				if (_sysImage != null) {
					_sysImage.Name = value;
				}
			}
		}

		private SysImage _sysImage;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage SysImage {
			get {
				return _sysImage ??
					(_sysImage = LookupColumnEntities.GetEntity("SysImage") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessUserTask_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessUserTaskDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessUserTaskInserting", e);
			Validating += (s, e) => ThrowEvent("SysProcessUserTaskValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessUserTask(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTask_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessUserTask_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessUserTask
	{

		public SysProcessUserTask_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessUserTask_BaseEventsProcess";
			SchemaUId = new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("48f06023-1771-45a8-9963-ba4cbb5fb5c4");
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

	#region Class: SysProcessUserTask_BaseEventsProcess

	/// <exclude/>
	public class SysProcessUserTask_BaseEventsProcess : SysProcessUserTask_BaseEventsProcess<SysProcessUserTask>
	{

		public SysProcessUserTask_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessUserTask_BaseEventsProcess

	public partial class SysProcessUserTask_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessUserTaskEventsProcess

	/// <exclude/>
	public class SysProcessUserTaskEventsProcess : SysProcessUserTask_BaseEventsProcess
	{

		public SysProcessUserTaskEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

