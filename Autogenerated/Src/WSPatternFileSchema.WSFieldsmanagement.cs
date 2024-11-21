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

	#region Class: WSPatternFileSchema

	/// <exclude/>
	public class WSPatternFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public WSPatternFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSPatternFileSchema(WSPatternFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSPatternFileSchema(WSPatternFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			RealUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			Name = "WSPatternFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("289bbe71-4820-451f-98ec-7dd46dd9fc57")) == null) {
				Columns.Add(CreateWSPatternColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSPatternColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("289bbe71-4820-451f-98ec-7dd46dd9fc57"),
				Name = @"WSPattern",
				ReferenceSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898"),
				ModifiedInSchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898"),
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
			return new WSPatternFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSPatternFile_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSPatternFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSPatternFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898"));
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternFile

	/// <summary>
	/// Файл и ссылка объекта Правила ввода.
	/// </summary>
	public class WSPatternFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public WSPatternFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSPatternFile";
		}

		public WSPatternFile(WSPatternFile source)
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
			var process = new WSPatternFile_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSPatternFileDeleted", e);
			Updated += (s, e) => ThrowEvent("WSPatternFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSPatternFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternFile_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSPatternFile_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : WSPatternFile
	{

		public WSPatternFile_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSPatternFile_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c3fdab30-57f4-42fa-ac89-4e4815dc4898");
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

	#region Class: WSPatternFile_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSPatternFile_WSFieldsmanagementEventsProcess : WSPatternFile_WSFieldsmanagementEventsProcess<WSPatternFile>
	{

		public WSPatternFile_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSPatternFile_WSFieldsmanagementEventsProcess

	public partial class WSPatternFile_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSPatternFileEventsProcess

	/// <exclude/>
	public class WSPatternFileEventsProcess : WSPatternFile_WSFieldsmanagementEventsProcess
	{

		public WSPatternFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

