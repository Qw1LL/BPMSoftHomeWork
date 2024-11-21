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

	#region Class: DCAttributeInBlockSchema

	/// <exclude/>
	public class DCAttributeInBlockSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCAttributeInBlockSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCAttributeInBlockSchema(DCAttributeInBlockSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCAttributeInBlockSchema(DCAttributeInBlockSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78");
			RealUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78");
			Name = "DCAttributeInBlock";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("39a5348f-04d0-4552-8184-959923b1d9ef")) == null) {
				Columns.Add(CreateDCAttributeColumn());
			}
			if (Columns.FindByUId(new Guid("defedd59-badb-48fe-9157-e1f7e55aeb68")) == null) {
				Columns.Add(CreateDCTemplateBlockColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDCAttributeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("39a5348f-04d0-4552-8184-959923b1d9ef"),
				Name = @"DCAttribute",
				ReferenceSchemaUId = new Guid("7d79cef7-2211-44e0-a70a-b5f14f7304c3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78"),
				ModifiedInSchemaUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected virtual EntitySchemaColumn CreateDCTemplateBlockColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("defedd59-badb-48fe-9157-e1f7e55aeb68"),
				Name = @"DCTemplateBlock",
				ReferenceSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78"),
				ModifiedInSchemaUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78"),
				CreatedInPackageId = new Guid("9f77887e-50a7-49c4-86e4-3ef2d36a21a8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCAttributeInBlock(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCAttributeInBlock_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCAttributeInBlockSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCAttributeInBlockSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78"));
		}

		#endregion

	}

	#endregion

	#region Class: DCAttributeInBlock

	/// <summary>
	/// DCAttributeInBlock.
	/// </summary>
	public class DCAttributeInBlock : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCAttributeInBlock(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCAttributeInBlock";
		}

		public DCAttributeInBlock(DCAttributeInBlock source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DCAttributeId {
			get {
				return GetTypedColumnValue<Guid>("DCAttributeId");
			}
			set {
				SetColumnValue("DCAttributeId", value);
				_dCAttribute = null;
			}
		}

		private DCAttribute _dCAttribute;
		/// <summary>
		/// DCAttribute.
		/// </summary>
		public DCAttribute DCAttribute {
			get {
				return _dCAttribute ??
					(_dCAttribute = LookupColumnEntities.GetEntity("DCAttribute") as DCAttribute);
			}
		}

		/// <exclude/>
		public Guid DCTemplateBlockId {
			get {
				return GetTypedColumnValue<Guid>("DCTemplateBlockId");
			}
			set {
				SetColumnValue("DCTemplateBlockId", value);
				_dCTemplateBlock = null;
			}
		}

		private DCTemplateBlock _dCTemplateBlock;
		/// <summary>
		/// DCTemplateBlock.
		/// </summary>
		public DCTemplateBlock DCTemplateBlock {
			get {
				return _dCTemplateBlock ??
					(_dCTemplateBlock = LookupColumnEntities.GetEntity("DCTemplateBlock") as DCTemplateBlock);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCAttributeInBlock_DynamicContentEventsProcess(UserConnection);
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
			return new DCAttributeInBlock(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCAttributeInBlock_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCAttributeInBlock_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCAttributeInBlock
	{

		public DCAttributeInBlock_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCAttributeInBlock_DynamicContentEventsProcess";
			SchemaUId = new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab22bcbe-a1fe-4e6c-b018-7454c04dae78");
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

	#region Class: DCAttributeInBlock_DynamicContentEventsProcess

	/// <exclude/>
	public class DCAttributeInBlock_DynamicContentEventsProcess : DCAttributeInBlock_DynamicContentEventsProcess<DCAttributeInBlock>
	{

		public DCAttributeInBlock_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCAttributeInBlock_DynamicContentEventsProcess

	public partial class DCAttributeInBlock_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCAttributeInBlockEventsProcess

	/// <exclude/>
	public class DCAttributeInBlockEventsProcess : DCAttributeInBlock_DynamicContentEventsProcess
	{

		public DCAttributeInBlockEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

