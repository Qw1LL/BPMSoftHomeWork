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

	#region Class: BaseEntityInStageSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntityInStageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEntityInStageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntityInStageSchema(BaseEntityInStageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntityInStageSchema(BaseEntityInStageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d");
			RealUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d");
			Name = "BaseEntityInStage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5dfad129-a300-4625-9da3-8f9aa16968cc")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("9329871d-a406-4f91-b5f8-8e914e31b329")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("b7b10879-fd03-470d-bdcf-ec591718dc13")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("6b8a78c9-8296-425e-a642-2e2170308d5e")) == null) {
				Columns.Add(CreateHistoricalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5dfad129-a300-4625-9da3-8f9aa16968cc"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				ModifiedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9329871d-a406-4f91-b5f8-8e914e31b329"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				ModifiedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b7b10879-fd03-470d-bdcf-ec591718dc13"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				ModifiedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHistoricalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6b8a78c9-8296-425e-a642-2e2170308d5e"),
				Name = @"Historical",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				ModifiedInSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEntityInStage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntityInStage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntityInStageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntityInStageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("86cb4c67-4231-4904-be40-b9019d87311d"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInStage

	/// <summary>
	/// Base object of transition in stages.
	/// </summary>
	public class BaseEntityInStage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEntityInStage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntityInStage";
		}

		public BaseEntityInStage(BaseEntityInStage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Start.
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
		/// Due.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Historical.
		/// </summary>
		public bool Historical {
			get {
				return GetTypedColumnValue<bool>("Historical");
			}
			set {
				SetColumnValue("Historical", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntityInStage_BaseEventsProcess(UserConnection);
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
			return new BaseEntityInStage(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInStage_BaseEventsProcess

	/// <exclude/>
	public partial class BaseEntityInStage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseEntityInStage
	{

		public BaseEntityInStage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntityInStage_BaseEventsProcess";
			SchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("86cb4c67-4231-4904-be40-b9019d87311d");
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

	#region Class: BaseEntityInStage_BaseEventsProcess

	/// <exclude/>
	public class BaseEntityInStage_BaseEventsProcess : BaseEntityInStage_BaseEventsProcess<BaseEntityInStage>
	{

		public BaseEntityInStage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntityInStage_BaseEventsProcess

	public partial class BaseEntityInStage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseEntityInStageEventsProcess

	/// <exclude/>
	public class BaseEntityInStageEventsProcess : BaseEntityInStage_BaseEventsProcess
	{

		public BaseEntityInStageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

