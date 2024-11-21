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

	#region Class: DCBlockInReplicaSchema

	/// <exclude/>
	public class DCBlockInReplicaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCBlockInReplicaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCBlockInReplicaSchema(DCBlockInReplicaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCBlockInReplicaSchema(DCBlockInReplicaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745");
			RealUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745");
			Name = "DCBlockInReplica";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f3c12c14-3efd-4e4b-8ceb-3c71017b91be")) == null) {
				Columns.Add(CreateDCTemplateBlockColumn());
			}
			if (Columns.FindByUId(new Guid("ebba7c37-53c5-4521-84f8-a9b52e20bc5e")) == null) {
				Columns.Add(CreateDCReplicaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDCTemplateBlockColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f3c12c14-3efd-4e4b-8ceb-3c71017b91be"),
				Name = @"DCTemplateBlock",
				ReferenceSchemaUId = new Guid("152c2238-d6e5-44d5-bcff-de341ff641ad"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745"),
				ModifiedInSchemaUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateDCReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ebba7c37-53c5-4521-84f8-a9b52e20bc5e"),
				Name = @"DCReplica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745"),
				ModifiedInSchemaUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745"),
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
			return new DCBlockInReplica(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCBlockInReplica_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCBlockInReplicaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCBlockInReplicaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745"));
		}

		#endregion

	}

	#endregion

	#region Class: DCBlockInReplica

	/// <summary>
	/// DCBlockInReplica.
	/// </summary>
	public class DCBlockInReplica : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCBlockInReplica(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCBlockInReplica";
		}

		public DCBlockInReplica(DCBlockInReplica source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid DCReplicaId {
			get {
				return GetTypedColumnValue<Guid>("DCReplicaId");
			}
			set {
				SetColumnValue("DCReplicaId", value);
				_dCReplica = null;
			}
		}

		/// <exclude/>
		public string DCReplicaCaption {
			get {
				return GetTypedColumnValue<string>("DCReplicaCaption");
			}
			set {
				SetColumnValue("DCReplicaCaption", value);
				if (_dCReplica != null) {
					_dCReplica.Caption = value;
				}
			}
		}

		private DCReplica _dCReplica;
		/// <summary>
		/// DCReplica.
		/// </summary>
		public DCReplica DCReplica {
			get {
				return _dCReplica ??
					(_dCReplica = LookupColumnEntities.GetEntity("DCReplica") as DCReplica);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCBlockInReplica_DynamicContentEventsProcess(UserConnection);
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
			return new DCBlockInReplica(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCBlockInReplica_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCBlockInReplica_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCBlockInReplica
	{

		public DCBlockInReplica_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCBlockInReplica_DynamicContentEventsProcess";
			SchemaUId = new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8b8f631f-a1f6-41f8-98f4-11b379431745");
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

	#region Class: DCBlockInReplica_DynamicContentEventsProcess

	/// <exclude/>
	public class DCBlockInReplica_DynamicContentEventsProcess : DCBlockInReplica_DynamicContentEventsProcess<DCBlockInReplica>
	{

		public DCBlockInReplica_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCBlockInReplica_DynamicContentEventsProcess

	public partial class DCBlockInReplica_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCBlockInReplicaEventsProcess

	/// <exclude/>
	public class DCBlockInReplicaEventsProcess : DCBlockInReplica_DynamicContentEventsProcess
	{

		public DCBlockInReplicaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

