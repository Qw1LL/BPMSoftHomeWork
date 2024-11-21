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

	#region Class: DCTemplateSchema

	/// <exclude/>
	public class DCTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCTemplateSchema(DCTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCTemplateSchema(DCTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe");
			RealUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe");
			Name = "DCTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c25f0000-72dc-4ce0-81f7-64beda130c36")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c25f0000-72dc-4ce0-81f7-64beda130c36"),
				Name = @"RecordId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"),
				ModifiedInSchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCTemplate_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"));
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplate

	/// <summary>
	/// Шаблон динамического контента.
	/// </summary>
	public class DCTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCTemplate";
		}

		public DCTemplate(DCTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCTemplate_DynamicContentEventsProcess(UserConnection);
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
			return new DCTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCTemplate_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCTemplate_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCTemplate
	{

		public DCTemplate_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCTemplate_DynamicContentEventsProcess";
			SchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe");
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

	#region Class: DCTemplate_DynamicContentEventsProcess

	/// <exclude/>
	public class DCTemplate_DynamicContentEventsProcess : DCTemplate_DynamicContentEventsProcess<DCTemplate>
	{

		public DCTemplate_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCTemplate_DynamicContentEventsProcess

	public partial class DCTemplate_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCTemplateEventsProcess

	/// <exclude/>
	public class DCTemplateEventsProcess : DCTemplate_DynamicContentEventsProcess
	{

		public DCTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

