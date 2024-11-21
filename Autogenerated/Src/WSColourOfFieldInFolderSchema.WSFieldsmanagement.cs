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

	#region Class: WSColourOfFieldInFolderSchema

	/// <exclude/>
	public class WSColourOfFieldInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public WSColourOfFieldInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColourOfFieldInFolderSchema(WSColourOfFieldInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColourOfFieldInFolderSchema(WSColourOfFieldInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			RealUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			Name = "WSColourOfFieldInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("77251f60-b866-4572-bc23-10c3d7d71a08")) == null) {
				Columns.Add(CreateWSColourOfFieldColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("bbe2f3ad-63a6-4f58-a73e-7d8910c1a076");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSColourOfFieldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("77251f60-b866-4572-bc23-10c3d7d71a08"),
				Name = @"WSColourOfField",
				ReferenceSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96"),
				ModifiedInSchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSColourOfFieldInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColourOfFieldInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColourOfFieldInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldInFolder

	/// <summary>
	/// Правила цветового выделения в группе.
	/// </summary>
	public class WSColourOfFieldInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public WSColourOfFieldInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfFieldInFolder";
		}

		public WSColourOfFieldInFolder(WSColourOfFieldInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid WSColourOfFieldId {
			get {
				return GetTypedColumnValue<Guid>("WSColourOfFieldId");
			}
			set {
				SetColumnValue("WSColourOfFieldId", value);
				_wSColourOfField = null;
			}
		}

		/// <exclude/>
		public string WSColourOfFieldWSName {
			get {
				return GetTypedColumnValue<string>("WSColourOfFieldWSName");
			}
			set {
				SetColumnValue("WSColourOfFieldWSName", value);
				if (_wSColourOfField != null) {
					_wSColourOfField.WSName = value;
				}
			}
		}

		private WSColourOfField _wSColourOfField;
		/// <summary>
		/// Правила цветового выделения.
		/// </summary>
		public WSColourOfField WSColourOfField {
			get {
				return _wSColourOfField ??
					(_wSColourOfField = LookupColumnEntities.GetEntity("WSColourOfField") as WSColourOfField);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColourOfFieldInFolderDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColourOfFieldInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : WSColourOfFieldInFolder
	{

		public WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5fe5cb81-e865-4ae9-a601-dcfc43e0df96");
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

	#region Class: WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess : WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess<WSColourOfFieldInFolder>
	{

		public WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess

	public partial class WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColourOfFieldInFolderEventsProcess

	/// <exclude/>
	public class WSColourOfFieldInFolderEventsProcess : WSColourOfFieldInFolder_WSFieldsmanagementEventsProcess
	{

		public WSColourOfFieldInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

