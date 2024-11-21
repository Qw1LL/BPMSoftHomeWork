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

	#region Class: RelationshipEntitySchema

	/// <exclude/>
	public class RelationshipEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationshipEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationshipEntitySchema(RelationshipEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationshipEntitySchema(RelationshipEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368");
			RealUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368");
			Name = "RelationshipEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("38097196-e33b-4169-81c0-04714de3cead")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("5aeda5b0-aacf-48dd-9cb5-588add169d28")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("38097196-e33b-4169-81c0-04714de3cead"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				ModifiedInSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5aeda5b0-aacf-48dd-9cb5-588add169d28"),
				Name = @"SchemaUId",
				CreatedInSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				ModifiedInSchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationshipEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationshipEntity_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationshipEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationshipEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipEntity

	/// <summary>
	/// Relationship entity.
	/// </summary>
	public class RelationshipEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationshipEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationshipEntity";
		}

		public RelationshipEntity(RelationshipEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record identifier.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// SysSchema unique identifier.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationshipEntity_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationshipEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipEntity_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationshipEntity_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationshipEntity
	{

		public RelationshipEntity_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationshipEntity_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7002a84c-d69e-47ba-b44e-9b7026caa368");
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

	#region Class: RelationshipEntity_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationshipEntity_RelationshipDesignerEventsProcess : RelationshipEntity_RelationshipDesignerEventsProcess<RelationshipEntity>
	{

		public RelationshipEntity_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationshipEntity_RelationshipDesignerEventsProcess

	public partial class RelationshipEntity_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationshipEntityEventsProcess

	/// <exclude/>
	public class RelationshipEntityEventsProcess : RelationshipEntity_RelationshipDesignerEventsProcess
	{

		public RelationshipEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

