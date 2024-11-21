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

	#region Class: EntityConnectionSchema

	/// <exclude/>
	public class EntityConnectionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntityConnectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntityConnectionSchema(EntityConnectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntityConnectionSchema(EntityConnectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			RealUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			Name = "EntityConnection";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2d2a1d06-fa97-4bb5-b37c-6af8782f7a07")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("a79438c7-070f-4f50-b9c4-509c94770c82")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("c1ab9d0a-ff01-456b-bc0f-d11cd879b870")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			column.CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2d2a1d06-fa97-4bb5-b37c-6af8782f7a07"),
				Name = @"SysEntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a79438c7-070f-4f50-b9c4-509c94770c82"),
				Name = @"ColumnUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				CreatedInPackageId = new Guid("cba1f828-e8f7-4368-82f1-f4ebfa3f0157")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c1ab9d0a-ff01-456b-bc0f-d11cd879b870"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				ModifiedInSchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"),
				CreatedInPackageId = new Guid("766630f1-8a05-4fa8-862c-b93f376378cb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntityConnection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntityConnection_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntityConnectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntityConnectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d"));
		}

		#endregion

	}

	#endregion

	#region Class: EntityConnection

	/// <summary>
	/// System object connection.
	/// </summary>
	public class EntityConnection : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntityConnection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityConnection";
		}

		public EntityConnection(EntityConnection source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Section object.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Connection column Id.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntityConnection_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EntityConnectionDeleted", e);
			Inserting += (s, e) => ThrowEvent("EntityConnectionInserting", e);
			Validating += (s, e) => ThrowEvent("EntityConnectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntityConnection(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntityConnection_UIv2EventsProcess

	/// <exclude/>
	public partial class EntityConnection_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EntityConnection
	{

		public EntityConnection_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntityConnection_UIv2EventsProcess";
			SchemaUId = new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("187a8e9a-6f0e-465d-aeb0-9556dfa93b7d");
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

	#region Class: EntityConnection_UIv2EventsProcess

	/// <exclude/>
	public class EntityConnection_UIv2EventsProcess : EntityConnection_UIv2EventsProcess<EntityConnection>
	{

		public EntityConnection_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntityConnection_UIv2EventsProcess

	public partial class EntityConnection_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntityConnectionEventsProcess

	/// <exclude/>
	public class EntityConnectionEventsProcess : EntityConnection_UIv2EventsProcess
	{

		public EntityConnectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

