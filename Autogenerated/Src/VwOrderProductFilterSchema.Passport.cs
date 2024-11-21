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

	#region Class: VwOrderProductFilterSchema

	/// <exclude/>
	public class VwOrderProductFilterSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwOrderProductFilterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwOrderProductFilterSchema(VwOrderProductFilterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwOrderProductFilterSchema(VwOrderProductFilterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a");
			RealUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a");
			Name = "VwOrderProductFilter";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c7111923-2c4e-4eb8-bedd-d31fcb8b2024");
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
			if (Columns.FindByUId(new Guid("185c417d-51bb-41f5-9562-e0dbfcc1773b")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("dce8b022-0c27-4dd4-a4ff-a666ec9813c4")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e575698b-4d10-49d5-84c5-2a69caebd2e5"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				ModifiedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				CreatedInPackageId = new Guid("a34f2e39-35b9-4ffb-9a89-fc6974a56461")
			};
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("185c417d-51bb-41f5-9562-e0dbfcc1773b"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				ModifiedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				CreatedInPackageId = new Guid("c7111923-2c4e-4eb8-bedd-d31fcb8b2024")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dce8b022-0c27-4dd4-a4ff-a666ec9813c4"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("f9876301-ffbc-4389-a53a-19413e3bd091"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				ModifiedInSchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"),
				CreatedInPackageId = new Guid("c7111923-2c4e-4eb8-bedd-d31fcb8b2024")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwOrderProductFilter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwOrderProductFilter_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwOrderProductFilterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwOrderProductFilterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwOrderProductFilter

	/// <summary>
	/// Фильтрация продуктов в заказе.
	/// </summary>
	public class VwOrderProductFilter : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwOrderProductFilter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwOrderProductFilter";
		}

		public VwOrderProductFilter(VwOrderProductFilter source)
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
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private OrderProduct _product;
		/// <summary>
		/// Id.
		/// </summary>
		public OrderProduct Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as OrderProduct);
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

		private SupplyPaymentType _type;
		/// <summary>
		/// Тип элемента графика поставок и оплат.
		/// </summary>
		public SupplyPaymentType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SupplyPaymentType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwOrderProductFilter_PassportEventsProcess(UserConnection);
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
			return new VwOrderProductFilter(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwOrderProductFilter_PassportEventsProcess

	/// <exclude/>
	public partial class VwOrderProductFilter_PassportEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwOrderProductFilter
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

		public VwOrderProductFilter_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwOrderProductFilter_PassportEventsProcess";
			SchemaUId = new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0ef424fb-1604-477c-86e2-bd3e6309669a");
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

	#region Class: VwOrderProductFilter_PassportEventsProcess

	/// <exclude/>
	public class VwOrderProductFilter_PassportEventsProcess : VwOrderProductFilter_PassportEventsProcess<VwOrderProductFilter>
	{

		public VwOrderProductFilter_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwOrderProductFilter_PassportEventsProcess

	public partial class VwOrderProductFilter_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwOrderProductFilterEventsProcess

	/// <exclude/>
	public class VwOrderProductFilterEventsProcess : VwOrderProductFilter_PassportEventsProcess
	{

		public VwOrderProductFilterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

