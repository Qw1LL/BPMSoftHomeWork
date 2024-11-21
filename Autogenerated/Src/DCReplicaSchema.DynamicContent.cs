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

	#region Class: DCReplicaSchema

	/// <exclude/>
	public class DCReplicaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCReplicaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCReplicaSchema(DCReplicaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCReplicaSchema(DCReplicaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIqNSNZltkfDh0CsrVdHCX8xdEIIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("69bae18b-64b9-4923-b451-13533e8fdecc");
			index.Name = "IqNSNZltkfDh0CsrVdHCX8xdEI";
			index.CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
			index.ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
			index.CreatedInPackageId = new Guid("69e28147-db31-49df-9976-b6fb9eb762c1");
			EntitySchemaIndexColumn dCTemplateIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("26ba98ec-6171-4f8f-a5a6-ba2e67d4c784"),
				ColumnUId = new Guid("6f11e425-e00e-4638-8955-874bc42e5a5b"),
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("69e28147-db31-49df-9976-b6fb9eb762c1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dCTemplateIdIndexColumn);
			EntitySchemaIndexColumn maskIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f0e205a1-4b16-4f51-a047-7e3f5f736e1c"),
				ColumnUId = new Guid("5a2a60e6-91f0-4938-9860-e879ebeb84c2"),
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("69e28147-db31-49df-9976-b6fb9eb762c1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(maskIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
			RealUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
			Name = "DCReplica";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5a2a60e6-91f0-4938-9860-e879ebeb84c2")) == null) {
				Columns.Add(CreateMaskColumn());
			}
			if (Columns.FindByUId(new Guid("fc947ee8-0bf6-4b95-8943-3cd45fc0a916")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("6f11e425-e00e-4638-8955-874bc42e5a5b")) == null) {
				Columns.Add(CreateDCTemplateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMaskColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5a2a60e6-91f0-4938-9860-e879ebeb84c2"),
				Name = @"Mask",
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fc947ee8-0bf6-4b95-8943-3cd45fc0a916"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateDCTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f11e425-e00e-4638-8955-874bc42e5a5b"),
				Name = @"DCTemplate",
				ReferenceSchemaUId = new Guid("7f77a1f1-13a4-4e82-aac8-c23197aed3fe"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("41261559-aad1-46c1-90ef-af80f5560adc"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				ModifiedInSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				CreatedInPackageId = new Guid("4f82e5e2-fdef-4aa4-baf8-be69c75a6ead")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIqNSNZltkfDh0CsrVdHCX8xdEIIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCReplica(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCReplica_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCReplicaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCReplicaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"));
		}

		#endregion

	}

	#endregion

	#region Class: DCReplica

	/// <summary>
	/// DCReplica.
	/// </summary>
	public class DCReplica : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCReplica(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCReplica";
		}

		public DCReplica(DCReplica source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Mask.
		/// </summary>
		/// <remarks>
		/// Binary mask.
		/// </remarks>
		public int Mask {
			get {
				return GetTypedColumnValue<int>("Mask");
			}
			set {
				SetColumnValue("Mask", value);
			}
		}

		/// <summary>
		/// Content.
		/// </summary>
		/// <remarks>
		/// HTML content.
		/// </remarks>
		public string Content {
			get {
				return GetTypedColumnValue<string>("Content");
			}
			set {
				SetColumnValue("Content", value);
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

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCReplica_DynamicContentEventsProcess(UserConnection);
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
			return new DCReplica(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCReplica_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCReplica_DynamicContentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCReplica
	{

		public DCReplica_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCReplica_DynamicContentEventsProcess";
			SchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5");
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

	#region Class: DCReplica_DynamicContentEventsProcess

	/// <exclude/>
	public class DCReplica_DynamicContentEventsProcess : DCReplica_DynamicContentEventsProcess<DCReplica>
	{

		public DCReplica_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCReplica_DynamicContentEventsProcess

	public partial class DCReplica_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCReplicaEventsProcess

	/// <exclude/>
	public class DCReplicaEventsProcess : DCReplica_DynamicContentEventsProcess
	{

		public DCReplicaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

