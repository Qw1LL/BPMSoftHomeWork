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

	#region Class: SiteEventTypeInFolderSchema

	/// <exclude/>
	public class SiteEventTypeInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SiteEventTypeInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeInFolderSchema(SiteEventTypeInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeInFolderSchema(SiteEventTypeInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b");
			RealUId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b");
			Name = "SiteEventTypeInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("12a0bdf6-0868-4c58-8126-114438004a00")) == null) {
				Columns.Add(CreateSiteEventTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("df38f095-58bc-43ad-afb0-02cf3b26da36");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSiteEventTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("12a0bdf6-0868-4c58-8126-114438004a00"),
				Name = @"SiteEventType",
				ReferenceSchemaUId = new Guid("e7274000-f0ef-4995-991a-37f0ace69fe3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b"),
				ModifiedInSchemaUId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventTypeInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventTypeInFolder_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeInFolder

	/// <summary>
	/// Событие сайта в папке.
	/// </summary>
	public class SiteEventTypeInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SiteEventTypeInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventTypeInFolder";
		}

		public SiteEventTypeInFolder(SiteEventTypeInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SiteEventTypeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventTypeId");
			}
			set {
				SetColumnValue("SiteEventTypeId", value);
				_siteEventType = null;
			}
		}

		/// <exclude/>
		public string SiteEventTypeName {
			get {
				return GetTypedColumnValue<string>("SiteEventTypeName");
			}
			set {
				SetColumnValue("SiteEventTypeName", value);
				if (_siteEventType != null) {
					_siteEventType.Name = value;
				}
			}
		}

		private SiteEventType _siteEventType;
		/// <summary>
		/// Site event type.
		/// </summary>
		public SiteEventType SiteEventType {
			get {
				return _siteEventType ??
					(_siteEventType = LookupColumnEntities.GetEntity("SiteEventType") as SiteEventType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventTypeInFolder_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventTypeInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventTypeInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeInFolder_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventTypeInFolder_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SiteEventTypeInFolder
	{

		public SiteEventTypeInFolder_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventTypeInFolder_EventTrackingEventsProcess";
			SchemaUId = new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d9efcb58-9392-425a-ab1d-8da4882fc08b");
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

	#region Class: SiteEventTypeInFolder_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventTypeInFolder_EventTrackingEventsProcess : SiteEventTypeInFolder_EventTrackingEventsProcess<SiteEventTypeInFolder>
	{

		public SiteEventTypeInFolder_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventTypeInFolder_EventTrackingEventsProcess

	public partial class SiteEventTypeInFolder_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventTypeInFolderEventsProcess

	/// <exclude/>
	public class SiteEventTypeInFolderEventsProcess : SiteEventTypeInFolder_EventTrackingEventsProcess
	{

		public SiteEventTypeInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

