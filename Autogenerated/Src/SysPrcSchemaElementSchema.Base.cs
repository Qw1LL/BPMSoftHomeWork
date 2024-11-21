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

	#region Class: SysPrcSchemaElementSchema

	/// <exclude/>
	public class SysPrcSchemaElementSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPrcSchemaElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcSchemaElementSchema(SysPrcSchemaElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcSchemaElementSchema(SysPrcSchemaElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_ProcessUId_StartTypeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("ef51aed8-3b5e-4b97-a276-b04fb1278368");
			index.Name = "IX_ProcessUId_StartType";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn processUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c9c38ad-7b2b-6a93-3ea0-e6e7af97ce33"),
				ColumnUId = new Guid("44850550-56a0-40ba-a240-dfbbf8fbea88"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(processUIdIndexColumn);
			EntitySchemaIndexColumn startTypeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b6b6ea73-459e-3c0a-0673-46a35d3dba9c"),
				ColumnUId = new Guid("a168e298-d5fc-7534-62ee-b4442c23228f"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(startTypeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be731fb7-87ab-479b-a188-37175a60b813");
			RealUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813");
			Name = "SysPrcSchemaElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ebe891a3-aec5-486d-b3c9-d5327804e122")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("44850550-56a0-40ba-a240-dfbbf8fbea88")) == null) {
				Columns.Add(CreateProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("d1ac90a6-e0a8-4224-a013-8591a7ee68e5")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("a168e298-d5fc-7534-62ee-b4442c23228f")) == null) {
				Columns.Add(CreateStartTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ebe891a3-aec5-486d-b3c9-d5327804e122"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				ModifiedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("44850550-56a0-40ba-a240-dfbbf8fbea88"),
				Name = @"ProcessUId",
				CreatedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				ModifiedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d1ac90a6-e0a8-4224-a013-8591a7ee68e5"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				ModifiedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateStartTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a168e298-d5fc-7534-62ee-b4442c23228f"),
				Name = @"StartType",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				ModifiedInSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_ProcessUId_StartTypeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcSchemaElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcSchemaElement_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcSchemaElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcSchemaElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be731fb7-87ab-479b-a188-37175a60b813"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcSchemaElement

	/// <summary>
	/// Process elements info.
	/// </summary>
	public class SysPrcSchemaElement : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPrcSchemaElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcSchemaElement";
		}

		public SysPrcSchemaElement(SysPrcSchemaElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process element uid.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Process uId.
		/// </summary>
		public Guid ProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessUId");
			}
			set {
				SetColumnValue("ProcessUId", value);
			}
		}

		/// <summary>
		/// Element name.
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
		/// Element start type.
		/// </summary>
		public int StartType {
			get {
				return GetTypedColumnValue<int>("StartType");
			}
			set {
				SetColumnValue("StartType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcSchemaElement_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcSchemaElementDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcSchemaElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcSchemaElement_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcSchemaElement_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPrcSchemaElement
	{

		public SysPrcSchemaElement_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcSchemaElement_BaseEventsProcess";
			SchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("be731fb7-87ab-479b-a188-37175a60b813");
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

	#region Class: SysPrcSchemaElement_BaseEventsProcess

	/// <exclude/>
	public class SysPrcSchemaElement_BaseEventsProcess : SysPrcSchemaElement_BaseEventsProcess<SysPrcSchemaElement>
	{

		public SysPrcSchemaElement_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcSchemaElement_BaseEventsProcess

	public partial class SysPrcSchemaElement_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcSchemaElementEventsProcess

	/// <exclude/>
	public class SysPrcSchemaElementEventsProcess : SysPrcSchemaElement_BaseEventsProcess
	{

		public SysPrcSchemaElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

