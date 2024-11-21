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
	using BPMSoft.Messaging.Common;
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

	#region Class: SysProcessElementToDo_Base_BPMSoftSchema

	/// <exclude/>
	public class SysProcessElementToDo_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessElementToDo_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessElementToDo_Base_BPMSoftSchema(SysProcessElementToDo_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessElementToDo_Base_BPMSoftSchema(SysProcessElementToDo_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f");
			RealUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f");
			Name = "SysProcessElementToDo_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("08acb43d-deb4-44d4-9714-40fc991d49dc")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("aecb7163-c838-411e-9579-455d3812e272")) == null) {
				Columns.Add(CreateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("6e1028c8-0dc6-4010-b031-ff443b851647")) == null) {
				Columns.Add(CreateContactIdColumn());
			}
			if (Columns.FindByUId(new Guid("a517ac73-8690-47d1-b71c-e8be90cb8718")) == null) {
				Columns.Add(CreateSysProcessDataIdColumn());
			}
			if (Columns.FindByUId(new Guid("6c8eb8fe-74ad-4068-b11a-1722514c567e")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("626da9c9-8a55-455f-bfa7-34f89b9a01ed")) == null) {
				Columns.Add(CreateProcessSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("eeb021c6-6754-4dbd-81a3-385b510282dd")) == null) {
				Columns.Add(CreateElementSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("8c5caca1-d0a5-4af4-b6d3-a827d758fb7e")) == null) {
				Columns.Add(CreateExecutionDataColumn());
			}
			if (Columns.FindByUId(new Guid("d6a90766-6ed8-4474-b36e-9b2b0ad80a67")) == null) {
				Columns.Add(CreateExtraDataColumn());
			}
			if (Columns.FindByUId(new Guid("0c413a55-8006-9620-5a27-f5386aef4694")) == null) {
				Columns.Add(CreateGroupTypeColumn());
			}
			if (Columns.FindByUId(new Guid("98e7c476-ce3d-2913-6fd7-2992c800ad76")) == null) {
				Columns.Add(CreateGroupIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("08acb43d-deb4-44d4-9714-40fc991d49dc"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("871be83f-6efe-49c0-92a6-06133069a602"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aecb7163-c838-411e-9579-455d3812e272"),
				Name = @"Subject",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateContactIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6e1028c8-0dc6-4010-b031-ff443b851647"),
				Name = @"ContactId",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessDataIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a517ac73-8690-47d1-b71c-e8be90cb8718"),
				Name = @"SysProcessDataId",
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6c8eb8fe-74ad-4068-b11a-1722514c567e"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("626da9c9-8a55-455f-bfa7-34f89b9a01ed"),
				Name = @"ProcessSchemaUId",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateElementSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("eeb021c6-6754-4dbd-81a3-385b510282dd"),
				Name = @"ElementSchemaUId",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateExecutionDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("8c5caca1-d0a5-4af4-b6d3-a827d758fb7e"),
				Name = @"ExecutionData",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateExtraDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("d6a90766-6ed8-4474-b36e-9b2b0ad80a67"),
				Name = @"ExtraData",
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0c413a55-8006-9620-5a27-f5386aef4694"),
				Name = @"GroupType",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("98e7c476-ce3d-2913-6fd7-2992c800ad76"),
				Name = @"GroupId",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				ModifiedInSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessElementToDo_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessElementToDo_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessElementToDo_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessElementToDo_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementToDo_Base_BPMSoft

	/// <summary>
	/// Process element to do list.
	/// </summary>
	public class SysProcessElementToDo_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessElementToDo_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessElementToDo_Base_BPMSoft";
		}

		public SysProcessElementToDo_Base_BPMSoft(SysProcessElementToDo_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Start date time.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Subject.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Owner.
		/// </summary>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
			}
		}

		/// <summary>
		/// Process identifier.
		/// </summary>
		public Guid SysProcessDataId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessDataId");
			}
			set {
				SetColumnValue("SysProcessDataId", value);
			}
		}

		/// <summary>
		/// Name of the process schema manager.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
			}
		}

		/// <summary>
		/// Process schema identifier.
		/// </summary>
		public Guid ProcessSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaUId");
			}
			set {
				SetColumnValue("ProcessSchemaUId", value);
			}
		}

		/// <summary>
		/// Schema element identifier.
		/// </summary>
		public Guid ElementSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ElementSchemaUId");
			}
			set {
				SetColumnValue("ElementSchemaUId", value);
			}
		}

		/// <summary>
		/// Group type.
		/// </summary>
		public int GroupType {
			get {
				return GetTypedColumnValue<int>("GroupType");
			}
			set {
				SetColumnValue("GroupType", value);
			}
		}

		/// <summary>
		/// Group identifier.
		/// </summary>
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessElementToDo_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessElementToDo_Base_BPMSoftDeleted", e);
			Saved += (s, e) => ThrowEvent("SysProcessElementToDo_Base_BPMSoftSaved", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessElementToDo_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementToDo_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessElementToDo_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessElementToDo_Base_BPMSoft
	{

		public SysProcessElementToDo_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessElementToDo_BaseEventsProcess";
			SchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f");
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

	#region Class: SysProcessElementToDo_BaseEventsProcess

	/// <exclude/>
	public class SysProcessElementToDo_BaseEventsProcess : SysProcessElementToDo_BaseEventsProcess<SysProcessElementToDo_Base_BPMSoft>
	{

		public SysProcessElementToDo_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

