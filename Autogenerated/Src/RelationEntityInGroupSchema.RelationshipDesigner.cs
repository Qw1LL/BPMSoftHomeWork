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

	#region Class: RelationEntityInGroupSchema

	/// <exclude/>
	public class RelationEntityInGroupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationEntityInGroupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationEntityInGroupSchema(RelationEntityInGroupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationEntityInGroupSchema(RelationEntityInGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f8388156-b222-43f2-9eed-59179072e372");
			RealUId = new Guid("f8388156-b222-43f2-9eed-59179072e372");
			Name = "RelationEntityInGroup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f8159316-4b37-465f-a74e-dde3f6109c1e")) == null) {
				Columns.Add(CreateRelationshipEntityColumn());
			}
			if (Columns.FindByUId(new Guid("1a7e70fe-c0a2-4524-88f2-c3db43ea3a99")) == null) {
				Columns.Add(CreateRelationshipGroupColumn());
			}
			if (Columns.FindByUId(new Guid("60d4c5a9-a5dc-48ee-bc0e-02d137ee2426")) == null) {
				Columns.Add(CreateCommentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRelationshipEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f8159316-4b37-465f-a74e-dde3f6109c1e"),
				Name = @"RelationshipEntity",
				ReferenceSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				ModifiedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationshipGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a7e70fe-c0a2-4524-88f2-c3db43ea3a99"),
				Name = @"RelationshipGroup",
				ReferenceSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				ModifiedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("60d4c5a9-a5dc-48ee-bc0e-02d137ee2426"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				ModifiedInSchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372"),
				CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationEntityInGroup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationEntityInGroup_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationEntityInGroupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationEntityInGroupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f8388156-b222-43f2-9eed-59179072e372"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationEntityInGroup

	/// <summary>
	/// Relationship entity in group.
	/// </summary>
	public class RelationEntityInGroup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationEntityInGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationEntityInGroup";
		}

		public RelationEntityInGroup(RelationEntityInGroup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RelationshipEntityId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipEntityId");
			}
			set {
				SetColumnValue("RelationshipEntityId", value);
				_relationshipEntity = null;
			}
		}

		private RelationshipEntity _relationshipEntity;
		/// <summary>
		/// Entity.
		/// </summary>
		public RelationshipEntity RelationshipEntity {
			get {
				return _relationshipEntity ??
					(_relationshipEntity = LookupColumnEntities.GetEntity("RelationshipEntity") as RelationshipEntity);
			}
		}

		/// <exclude/>
		public Guid RelationshipGroupId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipGroupId");
			}
			set {
				SetColumnValue("RelationshipGroupId", value);
				_relationshipGroup = null;
			}
		}

		private RelationshipGroup _relationshipGroup;
		/// <summary>
		/// Entity group.
		/// </summary>
		public RelationshipGroup RelationshipGroup {
			get {
				return _relationshipGroup ??
					(_relationshipGroup = LookupColumnEntities.GetEntity("RelationshipGroup") as RelationshipGroup);
			}
		}

		/// <summary>
		/// Comment.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationEntityInGroup_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationEntityInGroup(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationEntityInGroup_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationEntityInGroup_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationEntityInGroup
	{

		public RelationEntityInGroup_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationEntityInGroup_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("f8388156-b222-43f2-9eed-59179072e372");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f8388156-b222-43f2-9eed-59179072e372");
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

	#region Class: RelationEntityInGroup_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationEntityInGroup_RelationshipDesignerEventsProcess : RelationEntityInGroup_RelationshipDesignerEventsProcess<RelationEntityInGroup>
	{

		public RelationEntityInGroup_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationEntityInGroup_RelationshipDesignerEventsProcess

	public partial class RelationEntityInGroup_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationEntityInGroupEventsProcess

	/// <exclude/>
	public class RelationEntityInGroupEventsProcess : RelationEntityInGroup_RelationshipDesignerEventsProcess
	{

		public RelationEntityInGroupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

