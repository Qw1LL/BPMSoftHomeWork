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

	#region Class: DCTemplateGroupSchema

	/// <exclude/>
	public class DCTemplateGroupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCTemplateGroupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCTemplateGroupSchema(DCTemplateGroupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCTemplateGroupSchema(DCTemplateGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8289356-c66c-48af-90cf-03873f27991e");
			RealUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e");
			Name = "DCTemplateGroup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5ea5cc06-6a51-4e9c-ba2c-1dd59aa90e06")) == null) {
				Columns.Add(CreateIndexColumn());
			}
			if (Columns.FindByUId(new Guid("ddb9205f-6497-43d5-b583-88a2553e09a6")) == null) {
				Columns.Add(CreateDCTemplateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5ea5cc06-6a51-4e9c-ba2c-1dd59aa90e06"),
				Name = @"Index",
				CreatedInSchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e"),
				ModifiedInSchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateDCTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ddb9205f-6497-43d5-b583-88a2553e09a6"),
				Name = @"DCTemplate",
				ReferenceSchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e"),
				ModifiedInSchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e"),
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
			return new DCTemplateGroup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCTemplateGroup_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCTemplateGroupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCTemplateGroupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8289356-c66c-48af-90cf-03873f27991e"));
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplateGroup

	/// <summary>
	/// DCTemplateGroup.
	/// </summary>
	public class DCTemplateGroup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCTemplateGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCTemplateGroup";
		}

		public DCTemplateGroup(DCTemplateGroup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new DCTemplateGroup_DynamicContentEventsProcess(UserConnection);
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
			return new DCTemplateGroup(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplateGroup_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCTemplateGroup_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCTemplateGroup
	{

		public DCTemplateGroup_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCTemplateGroup_DynamicContentEventsProcess";
			SchemaUId = new Guid("a8289356-c66c-48af-90cf-03873f27991e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a8289356-c66c-48af-90cf-03873f27991e");
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

	#region Class: DCTemplateGroup_DynamicContentEventsProcess

	/// <exclude/>
	public class DCTemplateGroup_DynamicContentEventsProcess : DCTemplateGroup_DynamicContentEventsProcess<DCTemplateGroup>
	{

		public DCTemplateGroup_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCTemplateGroup_DynamicContentEventsProcess

	public partial class DCTemplateGroup_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCTemplateGroupEventsProcess

	/// <exclude/>
	public class DCTemplateGroupEventsProcess : DCTemplateGroup_DynamicContentEventsProcess
	{

		public DCTemplateGroupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

