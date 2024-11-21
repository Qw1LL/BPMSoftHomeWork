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

	#region Class: RelationEntInDiagramSchema

	/// <exclude/>
	public class RelationEntInDiagramSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationEntInDiagramSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationEntInDiagramSchema(RelationEntInDiagramSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationEntInDiagramSchema(RelationEntInDiagramSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c");
			RealUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c");
			Name = "RelationEntInDiagram";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3488344c-9f51-49f5-a775-e310a3b13970")) == null) {
				Columns.Add(CreateRelationshipDiagramColumn());
			}
			if (Columns.FindByUId(new Guid("6abe59c0-1a4b-4d4d-a834-38be03fad60c")) == null) {
				Columns.Add(CreateRelationshipEntityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRelationshipDiagramColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3488344c-9f51-49f5-a775-e310a3b13970"),
				Name = @"RelationshipDiagram",
				ReferenceSchemaUId = new Guid("76d539d4-1372-4065-8863-d63177e087b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c"),
				ModifiedInSchemaUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c"),
				CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationshipEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6abe59c0-1a4b-4d4d-a834-38be03fad60c"),
				Name = @"RelationshipEntity",
				ReferenceSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c"),
				ModifiedInSchemaUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c"),
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
			return new RelationEntInDiagram(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationEntInDiagram_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationEntInDiagramSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationEntInDiagramSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationEntInDiagram

	/// <summary>
	/// Relationship entity in diagram.
	/// </summary>
	public class RelationEntInDiagram : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationEntInDiagram(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationEntInDiagram";
		}

		public RelationEntInDiagram(RelationEntInDiagram source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RelationshipDiagramId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipDiagramId");
			}
			set {
				SetColumnValue("RelationshipDiagramId", value);
				_relationshipDiagram = null;
			}
		}

		private RelationshipDiagram _relationshipDiagram;
		/// <summary>
		/// Relationship diagram.
		/// </summary>
		public RelationshipDiagram RelationshipDiagram {
			get {
				return _relationshipDiagram ??
					(_relationshipDiagram = LookupColumnEntities.GetEntity("RelationshipDiagram") as RelationshipDiagram);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationEntInDiagram_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationEntInDiagram(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationEntInDiagram_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationEntInDiagram_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationEntInDiagram
	{

		public RelationEntInDiagram_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationEntInDiagram_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fed11d4e-4c3d-4f20-84f7-7ca0311c4f8c");
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

	#region Class: RelationEntInDiagram_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationEntInDiagram_RelationshipDesignerEventsProcess : RelationEntInDiagram_RelationshipDesignerEventsProcess<RelationEntInDiagram>
	{

		public RelationEntInDiagram_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationEntInDiagram_RelationshipDesignerEventsProcess

	public partial class RelationEntInDiagram_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationEntInDiagramEventsProcess

	/// <exclude/>
	public class RelationEntInDiagramEventsProcess : RelationEntInDiagram_RelationshipDesignerEventsProcess
	{

		public RelationEntInDiagramEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

