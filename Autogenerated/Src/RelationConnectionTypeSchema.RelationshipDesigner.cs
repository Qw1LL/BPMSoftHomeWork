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

	#region Class: RelationConnectionTypeSchema

	/// <exclude/>
	public class RelationConnectionTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationConnectionTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationConnectionTypeSchema(RelationConnectionTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationConnectionTypeSchema(RelationConnectionTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a");
			RealUId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a");
			Name = "RelationConnectionType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a2208a9f-dd3b-4705-be11-a2a3d1e4ac5d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a"),
				ModifiedInSchemaUId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationConnectionType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationConnectionType_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationConnectionTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationConnectionTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationConnectionType

	/// <summary>
	/// Relation connection type.
	/// </summary>
	public class RelationConnectionType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationConnectionType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationConnectionType";
		}

		public RelationConnectionType(RelationConnectionType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationConnectionType_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationConnectionType(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationConnectionType_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationConnectionType_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationConnectionType
	{

		public RelationConnectionType_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationConnectionType_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("55185a82-46ef-4eb0-b4df-ce99e964637a");
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

	#region Class: RelationConnectionType_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationConnectionType_RelationshipDesignerEventsProcess : RelationConnectionType_RelationshipDesignerEventsProcess<RelationConnectionType>
	{

		public RelationConnectionType_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationConnectionType_RelationshipDesignerEventsProcess

	public partial class RelationConnectionType_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationConnectionTypeEventsProcess

	/// <exclude/>
	public class RelationConnectionTypeEventsProcess : RelationConnectionType_RelationshipDesignerEventsProcess
	{

		public RelationConnectionTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

