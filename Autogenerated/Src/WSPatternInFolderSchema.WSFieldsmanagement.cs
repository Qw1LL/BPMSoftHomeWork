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

	#region Class: WSPatternInFolderSchema

	/// <exclude/>
	public class WSPatternInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public WSPatternInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSPatternInFolderSchema(WSPatternInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSPatternInFolderSchema(WSPatternInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			RealUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			Name = "WSPatternInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("13fd0d89-5d8a-4207-97e1-633bb4183511")) == null) {
				Columns.Add(CreateWSPatternColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("1543ed63-2168-48c1-af92-d9f07d2d99cb");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSPatternColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("13fd0d89-5d8a-4207-97e1-633bb4183511"),
				Name = @"WSPattern",
				ReferenceSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f"),
				ModifiedInSchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSPatternInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSPatternInFolder_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSPatternInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSPatternInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f"));
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternInFolder

	/// <summary>
	/// Правила ввода в группе.
	/// </summary>
	public class WSPatternInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public WSPatternInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSPatternInFolder";
		}

		public WSPatternInFolder(WSPatternInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid WSPatternId {
			get {
				return GetTypedColumnValue<Guid>("WSPatternId");
			}
			set {
				SetColumnValue("WSPatternId", value);
				_wSPattern = null;
			}
		}

		/// <exclude/>
		public string WSPatternWSName {
			get {
				return GetTypedColumnValue<string>("WSPatternWSName");
			}
			set {
				SetColumnValue("WSPatternWSName", value);
				if (_wSPattern != null) {
					_wSPattern.WSName = value;
				}
			}
		}

		private WSPattern _wSPattern;
		/// <summary>
		/// Правила ввода.
		/// </summary>
		public WSPattern WSPattern {
			get {
				return _wSPattern ??
					(_wSPattern = LookupColumnEntities.GetEntity("WSPattern") as WSPattern);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSPatternInFolder_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSPatternInFolderDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSPatternInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternInFolder_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSPatternInFolder_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : WSPatternInFolder
	{

		public WSPatternInFolder_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSPatternInFolder_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1fd5be0-8413-4cc7-8689-f576a4df296f");
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

	#region Class: WSPatternInFolder_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSPatternInFolder_WSFieldsmanagementEventsProcess : WSPatternInFolder_WSFieldsmanagementEventsProcess<WSPatternInFolder>
	{

		public WSPatternInFolder_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSPatternInFolder_WSFieldsmanagementEventsProcess

	public partial class WSPatternInFolder_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSPatternInFolderEventsProcess

	/// <exclude/>
	public class WSPatternInFolderEventsProcess : WSPatternInFolder_WSFieldsmanagementEventsProcess
	{

		public WSPatternInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

