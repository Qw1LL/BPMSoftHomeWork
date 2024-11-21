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

	#region Class: SysSSPEntitySchemaAccessListSchema

	/// <exclude/>
	public class SysSSPEntitySchemaAccessListSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSSPEntitySchemaAccessListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSSPEntitySchemaAccessListSchema(SysSSPEntitySchemaAccessListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSSPEntitySchemaAccessListSchema(SysSSPEntitySchemaAccessListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			RealUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			Name = "SysSSPEntitySchemaAccessList";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8d2d0d7c-7a7d-4bb1-ba25-e10883e91a1c")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("e0aa088b-0b83-44e5-b8c8-23c8c56aa362")) == null) {
				Columns.Add(CreateIsPresetColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			column.CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8d2d0d7c-7a7d-4bb1-ba25-e10883e91a1c"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab"),
				ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab"),
				CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73")
			};
		}

		protected virtual EntitySchemaColumn CreateIsPresetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e0aa088b-0b83-44e5-b8c8-23c8c56aa362"),
				Name = @"IsPreset",
				CreatedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab"),
				ModifiedInSchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSSPEntitySchemaAccessList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSSPEntitySchemaAccessList_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSSPEntitySchemaAccessListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSSPEntitySchemaAccessListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSSPEntitySchemaAccessList

	/// <summary>
	/// List of objects available for portal users.
	/// </summary>
	public class SysSSPEntitySchemaAccessList : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSSPEntitySchemaAccessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSSPEntitySchemaAccessList";
		}

		public SysSSPEntitySchemaAccessList(SysSSPEntitySchemaAccessList source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object Id.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Preset object.
		/// </summary>
		public bool IsPreset {
			get {
				return GetTypedColumnValue<bool>("IsPreset");
			}
			set {
				SetColumnValue("IsPreset", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSSPEntitySchemaAccessListDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysSSPEntitySchemaAccessListInserting", e);
			Validating += (s, e) => ThrowEvent("SysSSPEntitySchemaAccessListValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSSPEntitySchemaAccessList(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSSPEntitySchemaAccessList_BaseEventsProcess

	/// <exclude/>
	public partial class SysSSPEntitySchemaAccessList_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSSPEntitySchemaAccessList
	{

		public SysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSSPEntitySchemaAccessList_BaseEventsProcess";
			SchemaUId = new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3f07dee2-b2d5-4a28-9a59-1ef7d6fa85ab");
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

	#region Class: SysSSPEntitySchemaAccessList_BaseEventsProcess

	/// <exclude/>
	public class SysSSPEntitySchemaAccessList_BaseEventsProcess : SysSSPEntitySchemaAccessList_BaseEventsProcess<SysSSPEntitySchemaAccessList>
	{

		public SysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSSPEntitySchemaAccessList_BaseEventsProcess

	public partial class SysSSPEntitySchemaAccessList_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSSPEntitySchemaAccessListEventsProcess

	/// <exclude/>
	public class SysSSPEntitySchemaAccessListEventsProcess : SysSSPEntitySchemaAccessList_BaseEventsProcess
	{

		public SysSSPEntitySchemaAccessListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

