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

	#region Class: SiteEventTypeFolderSchema

	/// <exclude/>
	public class SiteEventTypeFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SiteEventTypeFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeFolderSchema(SiteEventTypeFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeFolderSchema(SiteEventTypeFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			RealUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			Name = "SiteEventTypeFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventTypeFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventTypeFolder_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeFolder

	/// <summary>
	/// Папка события сайта.
	/// </summary>
	public class SiteEventTypeFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SiteEventTypeFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventTypeFolder";
		}

		public SiteEventTypeFolder(SiteEventTypeFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private SiteEventTypeFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public SiteEventTypeFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SiteEventTypeFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventTypeFolder_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventTypeFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventTypeFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeFolder_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventTypeFolder_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SiteEventTypeFolder
	{

		public SiteEventTypeFolder_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventTypeFolder_EventTrackingEventsProcess";
			SchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
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

	#region Class: SiteEventTypeFolder_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventTypeFolder_EventTrackingEventsProcess : SiteEventTypeFolder_EventTrackingEventsProcess<SiteEventTypeFolder>
	{

		public SiteEventTypeFolder_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventTypeFolder_EventTrackingEventsProcess

	public partial class SiteEventTypeFolder_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
		}

		#endregion

	}

	#endregion


	#region Class: SiteEventTypeFolderEventsProcess

	/// <exclude/>
	public class SiteEventTypeFolderEventsProcess : SiteEventTypeFolder_EventTrackingEventsProcess
	{

		public SiteEventTypeFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

