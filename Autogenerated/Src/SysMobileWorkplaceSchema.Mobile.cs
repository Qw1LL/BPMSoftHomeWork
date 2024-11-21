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

	#region Class: SysMobileWorkplaceSchema

	/// <exclude/>
	public class SysMobileWorkplaceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysMobileWorkplaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMobileWorkplaceSchema(SysMobileWorkplaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMobileWorkplaceSchema(SysMobileWorkplaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5");
			RealUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5");
			Name = "SysMobileWorkplace";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("590b6b4e-ffef-44c7-9f04-0c51046e124e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("87b6c9a6-4fa8-4154-bffb-0215236aceea")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("3c25c8e2-8461-ddcc-5252-986896e8b6c1")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f4b30062-ab16-4e8c-9d07-fca4c4bd2c8d"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				ModifiedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				CreatedInPackageId = new Guid("590b6b4e-ffef-44c7-9f04-0c51046e124e"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("87b6c9a6-4fa8-4154-bffb-0215236aceea"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				ModifiedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				CreatedInPackageId = new Guid("590b6b4e-ffef-44c7-9f04-0c51046e124e")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3c25c8e2-8461-ddcc-5252-986896e8b6c1"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				ModifiedInSchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"),
				CreatedInPackageId = new Guid("e2c1fb57-3e44-487f-8827-1bbe31e2294d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"000a9225-728b-4778-a951-c42439ffe024"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMobileWorkplace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMobileWorkplace_MobileEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMobileWorkplaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMobileWorkplaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMobileWorkplace

	/// <summary>
	/// Рабочее место мобильного приложения.
	/// </summary>
	public class SysMobileWorkplace : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysMobileWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMobileWorkplace";
		}

		public SysMobileWorkplace(SysMobileWorkplace source)
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
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysWorkplaceType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public SysWorkplaceType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysWorkplaceType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMobileWorkplace_MobileEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMobileWorkplaceDeleted", e);
			Validating += (s, e) => ThrowEvent("SysMobileWorkplaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMobileWorkplace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMobileWorkplace_MobileEventsProcess

	/// <exclude/>
	public partial class SysMobileWorkplace_MobileEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysMobileWorkplace
	{

		public SysMobileWorkplace_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMobileWorkplace_MobileEventsProcess";
			SchemaUId = new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5149a215-3fff-4d7e-ac0e-43816e19cce5");
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

	#region Class: SysMobileWorkplace_MobileEventsProcess

	/// <exclude/>
	public class SysMobileWorkplace_MobileEventsProcess : SysMobileWorkplace_MobileEventsProcess<SysMobileWorkplace>
	{

		public SysMobileWorkplace_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMobileWorkplace_MobileEventsProcess

	public partial class SysMobileWorkplace_MobileEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMobileWorkplaceEventsProcess

	/// <exclude/>
	public class SysMobileWorkplaceEventsProcess : SysMobileWorkplace_MobileEventsProcess
	{

		public SysMobileWorkplaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

