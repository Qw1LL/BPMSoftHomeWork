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

	#region Class: RelationTypeSchema

	/// <exclude/>
	public class RelationTypeSchema : BPMSoft.Configuration.RelationType_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public RelationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationTypeSchema(RelationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationTypeSchema(RelationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469");
			Name = "RelationType";
			ParentSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			ExtendParent = true;
			CreatedInPackageId = new Guid("34f048e6-735a-441b-a357-784135dafc7e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("28c4f9c4-259b-4e3d-b174-fc03b0ec3b1b")) == null) {
				Columns.Add(CreateIncludeIntoContainerColumn());
			}
			if (Columns.FindByUId(new Guid("a5ae7770-8661-4a18-a8e9-51367653dded")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("60278f83-fc0f-4bbf-8609-bf5e2705e222")) == null) {
				Columns.Add(CreateRelationConnectionTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIncludeIntoContainerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("28c4f9c4-259b-4e3d-b174-fc03b0ec3b1b"),
				Name = @"IncludeIntoContainer",
				CreatedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				ModifiedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				CreatedInPackageId = new Guid("34f048e6-735a-441b-a357-784135dafc7e")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a5ae7770-8661-4a18-a8e9-51367653dded"),
				Name = @"Position",
				ReferenceSchemaUId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				ModifiedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("60278f83-fc0f-4bbf-8609-bf5e2705e222"),
				Name = @"RelationConnectionType",
				ReferenceSchemaUId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				ModifiedInSchemaUId = new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"),
				CreatedInPackageId = new Guid("ac9dec01-f305-4a8c-bd6f-7a943e292d3e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationType_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationType

	/// <summary>
	/// Relationship type.
	/// </summary>
	public class RelationType : BPMSoft.Configuration.RelationType_Base_BPMSoft
	{

		#region Constructors: Public

		public RelationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationType";
		}

		public RelationType(RelationType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Include into container.
		/// </summary>
		public bool IncludeIntoContainer {
			get {
				return GetTypedColumnValue<bool>("IncludeIntoContainer");
			}
			set {
				SetColumnValue("IncludeIntoContainer", value);
			}
		}

		/// <exclude/>
		public Guid PositionId {
			get {
				return GetTypedColumnValue<Guid>("PositionId");
			}
			set {
				SetColumnValue("PositionId", value);
				_position = null;
			}
		}

		/// <exclude/>
		public string PositionName {
			get {
				return GetTypedColumnValue<string>("PositionName");
			}
			set {
				SetColumnValue("PositionName", value);
				if (_position != null) {
					_position.Name = value;
				}
			}
		}

		private RelationTypePosition _position;
		/// <summary>
		/// Position.
		/// </summary>
		public RelationTypePosition Position {
			get {
				return _position ??
					(_position = LookupColumnEntities.GetEntity("Position") as RelationTypePosition);
			}
		}

		/// <exclude/>
		public Guid RelationConnectionTypeId {
			get {
				return GetTypedColumnValue<Guid>("RelationConnectionTypeId");
			}
			set {
				SetColumnValue("RelationConnectionTypeId", value);
				_relationConnectionType = null;
			}
		}

		/// <exclude/>
		public string RelationConnectionTypeName {
			get {
				return GetTypedColumnValue<string>("RelationConnectionTypeName");
			}
			set {
				SetColumnValue("RelationConnectionTypeName", value);
				if (_relationConnectionType != null) {
					_relationConnectionType.Name = value;
				}
			}
		}

		private RelationConnectionType _relationConnectionType;
		/// <summary>
		/// Relationship connection type.
		/// </summary>
		public RelationConnectionType RelationConnectionType {
			get {
				return _relationConnectionType ??
					(_relationConnectionType = LookupColumnEntities.GetEntity("RelationConnectionType") as RelationConnectionType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationType_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationType_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationType_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.RelationType_BaseEventsProcess<TEntity> where TEntity : RelationType
	{

		public RelationType_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationType_RelationshipDesignerEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95f58cfa-3a8a-4f60-8e82-3a59f9ffd469");
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

	#region Class: RelationType_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationType_RelationshipDesignerEventsProcess : RelationType_RelationshipDesignerEventsProcess<RelationType>
	{

		public RelationType_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationType_RelationshipDesignerEventsProcess

	public partial class RelationType_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationTypeEventsProcess

	/// <exclude/>
	public class RelationTypeEventsProcess : RelationType_RelationshipDesignerEventsProcess
	{

		public RelationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

