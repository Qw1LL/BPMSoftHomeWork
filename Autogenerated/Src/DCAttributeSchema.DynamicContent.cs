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

	#region Class: DCAttributeSchema

	/// <exclude/>
	public class DCAttributeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCAttributeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCAttributeSchema(DCAttributeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCAttributeSchema(DCAttributeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3");
			RealUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3");
			Name = "DCAttribute";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("90d91345-7ade-4363-8b84-e5cd89bb0498")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("47972758-fd5e-4b1b-ad96-624e090a0999")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6107b918-1469-4e9f-9f7c-408868400250")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("6601e86c-7f32-4bde-be1f-188fa61a5c48")) == null) {
				Columns.Add(CreateIndexColumn());
			}
			if (Columns.FindByUId(new Guid("0cd32740-75c2-4827-a185-d8c49efeaf68")) == null) {
				Columns.Add(CreateDCTemplateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("90d91345-7ade-4363-8b84-e5cd89bb0498"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				ModifiedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("47972758-fd5e-4b1b-ad96-624e090a0999"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("1a91af0f-7bb9-4ea5-b999-d317ff6bf247"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				ModifiedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("6107b918-1469-4e9f-9f7c-408868400250"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				ModifiedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected virtual EntitySchemaColumn CreateIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6601e86c-7f32-4bde-be1f-188fa61a5c48"),
				Name = @"Index",
				CreatedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				ModifiedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected virtual EntitySchemaColumn CreateDCTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0cd32740-75c2-4827-a185-d8c49efeaf68"),
				Name = @"DCTemplate",
				ReferenceSchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				ModifiedInSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				CreatedInPackageId = new Guid("41c9b305-ccaa-4408-abc9-8158dd3fa84a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCAttribute(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCAttribute_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCAttributeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCAttributeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"));
		}

		#endregion

	}

	#endregion

	#region Class: DCAttribute

	/// <summary>
	/// DCAttribute.
	/// </summary>
	public class DCAttribute : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCAttribute(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCAttribute";
		}

		public DCAttribute(DCAttribute source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Caption.
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

		private DCAttributeType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public DCAttributeType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as DCAttributeType);
			}
		}

		/// <summary>
		/// Index.
		/// </summary>
		public int Index {
			get {
				return GetTypedColumnValue<int>("Index");
			}
			set {
				SetColumnValue("Index", value);
			}
		}

		/// <exclude/>
		public Guid DCTemplateId {
			get {
				return GetTypedColumnValue<Guid>("DCTemplateId");
			}
			set {
				SetColumnValue("DCTemplateId", value);
				_dCTemplate = null;
			}
		}

		private DCTemplate _dCTemplate;
		/// <summary>
		/// DCTemplate.
		/// </summary>
		public DCTemplate DCTemplate {
			get {
				return _dCTemplate ??
					(_dCTemplate = LookupColumnEntities.GetEntity("DCTemplate") as DCTemplate);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCAttribute_DynamicContentEventsProcess(UserConnection);
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
			return new DCAttribute(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCAttribute_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCAttribute_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCAttribute
	{

		public DCAttribute_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCAttribute_DynamicContentEventsProcess";
			SchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3");
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

	#region Class: DCAttribute_DynamicContentEventsProcess

	/// <exclude/>
	public class DCAttribute_DynamicContentEventsProcess : DCAttribute_DynamicContentEventsProcess<DCAttribute>
	{

		public DCAttribute_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCAttribute_DynamicContentEventsProcess

	public partial class DCAttribute_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCAttributeEventsProcess

	/// <exclude/>
	public class DCAttributeEventsProcess : DCAttribute_DynamicContentEventsProcess
	{

		public DCAttributeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

