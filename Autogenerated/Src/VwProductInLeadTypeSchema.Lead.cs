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

	#region Class: VwProductInLeadTypeSchema

	/// <exclude/>
	public class VwProductInLeadTypeSchema : BPMSoft.Configuration.ProductInLeadTypeSchema
	{

		#region Constructors: Public

		public VwProductInLeadTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProductInLeadTypeSchema(VwProductInLeadTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProductInLeadTypeSchema(VwProductInLeadTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7");
			RealUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7");
			Name = "VwProductInLeadType";
			ParentSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("d5291c1a-2394-4f21-b24b-e7607cb2b9cf")) == null) {
				Columns.Add(CreateProductTypeInLeadTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("637345a6-9354-4561-a1f7-48702546ff5f"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7"),
				ModifiedInSchemaUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected virtual EntitySchemaColumn CreateProductTypeInLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5291c1a-2394-4f21-b24b-e7607cb2b9cf"),
				Name = @"ProductTypeInLeadType",
				ReferenceSchemaUId = new Guid("50576f45-9a5e-4df8-b7ad-76bcfe5b5073"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7"),
				ModifiedInSchemaUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProductInLeadType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProductInLeadType_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProductInLeadTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProductInLeadTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProductInLeadType

	/// <summary>
	/// Продукт в типе потребности (представление).
	/// </summary>
	public class VwProductInLeadType : BPMSoft.Configuration.ProductInLeadType
	{

		#region Constructors: Public

		public VwProductInLeadType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProductInLeadType";
		}

		public VwProductInLeadType(VwProductInLeadType source)
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

		/// <exclude/>
		public Guid ProductTypeInLeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProductTypeInLeadTypeId");
			}
			set {
				SetColumnValue("ProductTypeInLeadTypeId", value);
				_productTypeInLeadType = null;
			}
		}

		/// <exclude/>
		public string ProductTypeInLeadTypeName {
			get {
				return GetTypedColumnValue<string>("ProductTypeInLeadTypeName");
			}
			set {
				SetColumnValue("ProductTypeInLeadTypeName", value);
				if (_productTypeInLeadType != null) {
					_productTypeInLeadType.Name = value;
				}
			}
		}

		private ProductTypeInLeadType _productTypeInLeadType;
		/// <summary>
		/// Тип записи.
		/// </summary>
		public ProductTypeInLeadType ProductTypeInLeadType {
			get {
				return _productTypeInLeadType ??
					(_productTypeInLeadType = LookupColumnEntities.GetEntity("ProductTypeInLeadType") as ProductTypeInLeadType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProductInLeadType_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProductInLeadTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProductInLeadTypeInserting", e);
			Validating += (s, e) => ThrowEvent("VwProductInLeadTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProductInLeadType(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProductInLeadType_LeadEventsProcess

	/// <exclude/>
	public partial class VwProductInLeadType_LeadEventsProcess<TEntity> : BPMSoft.Configuration.ProductInLeadType_LeadEventsProcess<TEntity> where TEntity : VwProductInLeadType
	{

		public VwProductInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProductInLeadType_LeadEventsProcess";
			SchemaUId = new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af9496ac-dd52-4411-b90f-1c5270f59bd7");
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

	#region Class: VwProductInLeadType_LeadEventsProcess

	/// <exclude/>
	public class VwProductInLeadType_LeadEventsProcess : VwProductInLeadType_LeadEventsProcess<VwProductInLeadType>
	{

		public VwProductInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProductInLeadType_LeadEventsProcess

	public partial class VwProductInLeadType_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProductInLeadTypeEventsProcess

	/// <exclude/>
	public class VwProductInLeadTypeEventsProcess : VwProductInLeadType_LeadEventsProcess
	{

		public VwProductInLeadTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

