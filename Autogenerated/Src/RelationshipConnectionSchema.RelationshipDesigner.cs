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

	#region Class: RelationshipConnectionSchema

	/// <exclude/>
	public class RelationshipConnectionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationshipConnectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationshipConnectionSchema(RelationshipConnectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationshipConnectionSchema(RelationshipConnectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f");
			RealUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f");
			Name = "RelationshipConnection";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6f2b4e32-7b34-45e0-a354-0c895f8097d2")) == null) {
				Columns.Add(CreateRelationshipEntityAColumn());
			}
			if (Columns.FindByUId(new Guid("04e9a7d6-cf70-427a-ae4e-6cf451f38824")) == null) {
				Columns.Add(CreateRelationshipEntityBColumn());
			}
			if (Columns.FindByUId(new Guid("51f1d8f7-7aaf-4cc5-86db-6b2a20cc6b88")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("1c2636b7-f255-4fe5-8429-f7db07b1410f")) == null) {
				Columns.Add(CreateRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("cdc7770b-8cde-4c54-a690-5593ca3adb16")) == null) {
				Columns.Add(CreateCommentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRelationshipEntityAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f2b4e32-7b34-45e0-a354-0c895f8097d2"),
				Name = @"RelationshipEntityA",
				ReferenceSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				ModifiedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationshipEntityBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("04e9a7d6-cf70-427a-ae4e-6cf451f38824"),
				Name = @"RelationshipEntityB",
				ReferenceSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				ModifiedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("51f1d8f7-7aaf-4cc5-86db-6b2a20cc6b88"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				ModifiedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1c2636b7-f255-4fe5-8429-f7db07b1410f"),
				Name = @"RelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				ModifiedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				CreatedInPackageId = new Guid("d70c770b-1ab7-4b01-9c96-cb0b33162e8e")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("cdc7770b-8cde-4c54-a690-5593ca3adb16"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				ModifiedInSchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"),
				CreatedInPackageId = new Guid("d70c770b-1ab7-4b01-9c96-cb0b33162e8e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationshipConnection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationshipConnection_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationshipConnectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationshipConnectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a498393d-86bc-4f42-b0fd-c598af83371f"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipConnection

	/// <summary>
	/// Relationship connection.
	/// </summary>
	public class RelationshipConnection : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationshipConnection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationshipConnection";
		}

		public RelationshipConnection(RelationshipConnection source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RelationshipEntityAId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipEntityAId");
			}
			set {
				SetColumnValue("RelationshipEntityAId", value);
				_relationshipEntityA = null;
			}
		}

		private RelationshipEntity _relationshipEntityA;
		/// <summary>
		/// Entity A.
		/// </summary>
		public RelationshipEntity RelationshipEntityA {
			get {
				return _relationshipEntityA ??
					(_relationshipEntityA = LookupColumnEntities.GetEntity("RelationshipEntityA") as RelationshipEntity);
			}
		}

		/// <exclude/>
		public Guid RelationshipEntityBId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipEntityBId");
			}
			set {
				SetColumnValue("RelationshipEntityBId", value);
				_relationshipEntityB = null;
			}
		}

		private RelationshipEntity _relationshipEntityB;
		/// <summary>
		/// Entity B.
		/// </summary>
		public RelationshipEntity RelationshipEntityB {
			get {
				return _relationshipEntityB ??
					(_relationshipEntityB = LookupColumnEntities.GetEntity("RelationshipEntityB") as RelationshipEntity);
			}
		}

		/// <summary>
		/// Name.
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
		public Guid RelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("RelationTypeId");
			}
			set {
				SetColumnValue("RelationTypeId", value);
				_relationType = null;
			}
		}

		/// <exclude/>
		public string RelationTypeName {
			get {
				return GetTypedColumnValue<string>("RelationTypeName");
			}
			set {
				SetColumnValue("RelationTypeName", value);
				if (_relationType != null) {
					_relationType.Name = value;
				}
			}
		}

		private RelationType _relationType;
		/// <summary>
		/// Relationship type.
		/// </summary>
		public RelationType RelationType {
			get {
				return _relationType ??
					(_relationType = LookupColumnEntities.GetEntity("RelationType") as RelationType);
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
			var process = new RelationshipConnection_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationshipConnection(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipConnection_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationshipConnection_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationshipConnection
	{

		public RelationshipConnection_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationshipConnection_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("a498393d-86bc-4f42-b0fd-c598af83371f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a498393d-86bc-4f42-b0fd-c598af83371f");
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

	#region Class: RelationshipConnection_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationshipConnection_RelationshipDesignerEventsProcess : RelationshipConnection_RelationshipDesignerEventsProcess<RelationshipConnection>
	{

		public RelationshipConnection_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationshipConnection_RelationshipDesignerEventsProcess

	public partial class RelationshipConnection_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationshipConnectionEventsProcess

	/// <exclude/>
	public class RelationshipConnectionEventsProcess : RelationshipConnection_RelationshipDesignerEventsProcess
	{

		public RelationshipConnectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

