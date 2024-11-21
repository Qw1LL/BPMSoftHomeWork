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

	#region Class: PortalColumnAccessListSchema

	/// <exclude/>
	public class PortalColumnAccessListSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PortalColumnAccessListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PortalColumnAccessListSchema(PortalColumnAccessListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PortalColumnAccessListSchema(PortalColumnAccessListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1");
			RealUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1");
			Name = "PortalColumnAccessList";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b03360a8-d50e-4cb0-a1d7-6d46d0b31bff")) == null) {
				Columns.Add(CreatePortalSchemaListColumn());
			}
			if (Columns.FindByUId(new Guid("087f5050-1d50-4639-905e-b75eea498ff8")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9ed7e3f6-ce67-41fb-8dcc-16c9c5e4d08f")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePortalSchemaListColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b03360a8-d50e-4cb0-a1d7-6d46d0b31bff"),
				Name = @"PortalSchemaList",
				ReferenceSchemaUId = new Guid("b5bda4b9-d2bf-4b39-8ba5-1883ac2583a7"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				ModifiedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("087f5050-1d50-4639-905e-b75eea498ff8"),
				Name = @"ColumnUId",
				CreatedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				ModifiedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9ed7e3f6-ce67-41fb-8dcc-16c9c5e4d08f"),
				Name = @"ColumnName",
				CreatedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				ModifiedInSchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PortalColumnAccessList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PortalColumnAccessList_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PortalColumnAccessListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PortalColumnAccessListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1"));
		}

		#endregion

	}

	#endregion

	#region Class: PortalColumnAccessList

	/// <summary>
	/// PortalColumnAccessList.
	/// </summary>
	public class PortalColumnAccessList : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PortalColumnAccessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PortalColumnAccessList";
		}

		public PortalColumnAccessList(PortalColumnAccessList source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PortalSchemaListId {
			get {
				return GetTypedColumnValue<Guid>("PortalSchemaListId");
			}
			set {
				SetColumnValue("PortalSchemaListId", value);
				_portalSchemaList = null;
			}
		}

		/// <exclude/>
		public string PortalSchemaListAccessEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("PortalSchemaListAccessEntitySchemaName");
			}
			set {
				SetColumnValue("PortalSchemaListAccessEntitySchemaName", value);
				if (_portalSchemaList != null) {
					_portalSchemaList.AccessEntitySchemaName = value;
				}
			}
		}

		private PortalSchemaAccessList _portalSchemaList;
		/// <summary>
		/// List of schema fields for portal access.
		/// </summary>
		public PortalSchemaAccessList PortalSchemaList {
			get {
				return _portalSchemaList ??
					(_portalSchemaList = LookupColumnEntities.GetEntity("PortalSchemaList") as PortalSchemaAccessList);
			}
		}

		/// <summary>
		/// Column.
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
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PortalColumnAccessList_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PortalColumnAccessListDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PortalColumnAccessList(this);
		}

		#endregion

	}

	#endregion

	#region Class: PortalColumnAccessList_NUIEventsProcess

	/// <exclude/>
	public partial class PortalColumnAccessList_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PortalColumnAccessList
	{

		public PortalColumnAccessList_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PortalColumnAccessList_NUIEventsProcess";
			SchemaUId = new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d9062f7d-b700-4b1a-972c-9864e8553bb1");
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

	#region Class: PortalColumnAccessList_NUIEventsProcess

	/// <exclude/>
	public class PortalColumnAccessList_NUIEventsProcess : PortalColumnAccessList_NUIEventsProcess<PortalColumnAccessList>
	{

		public PortalColumnAccessList_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PortalColumnAccessList_NUIEventsProcess

	public partial class PortalColumnAccessList_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PortalColumnAccessListEventsProcess

	/// <exclude/>
	public class PortalColumnAccessListEventsProcess : PortalColumnAccessList_NUIEventsProcess
	{

		public PortalColumnAccessListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

