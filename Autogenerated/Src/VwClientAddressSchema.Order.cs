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

	#region Class: VwClientAddress_Order_BPMSoftSchema

	/// <exclude/>
	public class VwClientAddress_Order_BPMSoftSchema : BPMSoft.Configuration.BaseAddressSchema
	{

		#region Constructors: Public

		public VwClientAddress_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwClientAddress_Order_BPMSoftSchema(VwClientAddress_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwClientAddress_Order_BPMSoftSchema(VwClientAddress_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae");
			RealUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae");
			Name = "VwClientAddress_Order_BPMSoft";
			ParentSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d6ad04c1-fa0b-4adb-bfd8-17ec17775a03");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a5f61d87-12a3-430f-a59d-979a634629df")) == null) {
				Columns.Add(CreateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("eb759b1f-fd83-4635-a260-2db30a9fb673")) == null) {
				Columns.Add(CreateClientTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a5f61d87-12a3-430f-a59d-979a634629df"),
				Name = @"ClientId",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae"),
				ModifiedInSchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae"),
				CreatedInPackageId = new Guid("d6ad04c1-fa0b-4adb-bfd8-17ec17775a03")
			};
		}

		protected virtual EntitySchemaColumn CreateClientTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("eb759b1f-fd83-4635-a260-2db30a9fb673"),
				Name = @"ClientType",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae"),
				ModifiedInSchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae"),
				CreatedInPackageId = new Guid("d6ad04c1-fa0b-4adb-bfd8-17ec17775a03")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwClientAddress_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwClientAddress_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwClientAddress_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwClientAddress_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae"));
		}

		#endregion

	}

	#endregion

	#region Class: VwClientAddress_Order_BPMSoft

	/// <summary>
	/// Адрес клиента.
	/// </summary>
	public class VwClientAddress_Order_BPMSoft : BPMSoft.Configuration.BaseAddress
	{

		#region Constructors: Public

		public VwClientAddress_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwClientAddress_Order_BPMSoft";
		}

		public VwClientAddress_Order_BPMSoft(VwClientAddress_Order_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id контрагента / контакта.
		/// </summary>
		public Guid ClientId {
			get {
				return GetTypedColumnValue<Guid>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Тип клиента.
		/// </summary>
		public string ClientType {
			get {
				return GetTypedColumnValue<string>("ClientType");
			}
			set {
				SetColumnValue("ClientType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwClientAddress_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwClientAddress_Order_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("VwClientAddress_Order_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwClientAddress_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwClientAddress_OrderEventsProcess

	/// <exclude/>
	public partial class VwClientAddress_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseAddress_BaseEventsProcess<TEntity> where TEntity : VwClientAddress_Order_BPMSoft
	{

		public VwClientAddress_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwClientAddress_OrderEventsProcess";
			SchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae");
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

	#region Class: VwClientAddress_OrderEventsProcess

	/// <exclude/>
	public class VwClientAddress_OrderEventsProcess : VwClientAddress_OrderEventsProcess<VwClientAddress_Order_BPMSoft>
	{

		public VwClientAddress_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwClientAddress_OrderEventsProcess

	public partial class VwClientAddress_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

