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

	#region Class: DCTemplateBlockSchema

	/// <exclude/>
	public class DCTemplateBlockSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCTemplateBlockSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCTemplateBlockSchema(DCTemplateBlockSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCTemplateBlockSchema(DCTemplateBlockSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad");
			RealUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad");
			Name = "DCTemplateBlock";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ed0f230c-fb6f-4385-a8a7-1bddbdd7ba30")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("3f76df87-d724-42da-a347-36e84f8779e3")) == null) {
				Columns.Add(CreateDCTemplateGroupColumn());
			}
			if (Columns.FindByUId(new Guid("d42ac7e5-da6a-4bd3-8e59-af05a3a80b68")) == null) {
				Columns.Add(CreateIndexColumn());
			}
			if (Columns.FindByUId(new Guid("7f0aab39-b7da-40f6-a717-b274ea53f58d")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ed0f230c-fb6f-4385-a8a7-1bddbdd7ba30"),
				Name = @"Priority",
				CreatedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				ModifiedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateDCTemplateGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3f76df87-d724-42da-a347-36e84f8779e3"),
				Name = @"DCTemplateGroup",
				ReferenceSchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				ModifiedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d42ac7e5-da6a-4bd3-8e59-af05a3a80b68"),
				Name = @"Index",
				CreatedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				ModifiedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7f0aab39-b7da-40f6-a717-b274ea53f58d"),
				Name = @"IsDefault",
				CreatedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				ModifiedInSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				CreatedInPackageId = new Guid("748ec229-6875-456a-9dfd-63087e63e63a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCTemplateBlock(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCTemplateBlock_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCTemplateBlockSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCTemplateBlockSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"));
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplateBlock

	/// <summary>
	/// DCTemplateBlock.
	/// </summary>
	public class DCTemplateBlock : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCTemplateBlock(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCTemplateBlock";
		}

		public DCTemplateBlock(DCTemplateBlock source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Priority.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		/// <exclude/>
		public Guid DCTemplateGroupId {
			get {
				return GetTypedColumnValue<Guid>("DCTemplateGroupId");
			}
			set {
				SetColumnValue("DCTemplateGroupId", value);
				_dCTemplateGroup = null;
			}
		}

		private DCTemplateGroup _dCTemplateGroup;
		/// <summary>
		/// DCTemplateGroup.
		/// </summary>
		public DCTemplateGroup DCTemplateGroup {
			get {
				return _dCTemplateGroup ??
					(_dCTemplateGroup = LookupColumnEntities.GetEntity("DCTemplateGroup") as DCTemplateGroup);
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

		/// <summary>
		/// IsDefault.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCTemplateBlock_DynamicContentEventsProcess(UserConnection);
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
			return new DCTemplateBlock(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplateBlock_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCTemplateBlock_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCTemplateBlock
	{

		public DCTemplateBlock_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCTemplateBlock_DynamicContentEventsProcess";
			SchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad");
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

	#region Class: DCTemplateBlock_DynamicContentEventsProcess

	/// <exclude/>
	public class DCTemplateBlock_DynamicContentEventsProcess : DCTemplateBlock_DynamicContentEventsProcess<DCTemplateBlock>
	{

		public DCTemplateBlock_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCTemplateBlock_DynamicContentEventsProcess

	public partial class DCTemplateBlock_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCTemplateBlockEventsProcess

	/// <exclude/>
	public class DCTemplateBlockEventsProcess : DCTemplateBlock_DynamicContentEventsProcess
	{

		public DCTemplateBlockEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

