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

	#region Class: MkpInstalledAppNewsFolderSchema

	/// <exclude/>
	public class MkpInstalledAppNewsFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public MkpInstalledAppNewsFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MkpInstalledAppNewsFolderSchema(MkpInstalledAppNewsFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MkpInstalledAppNewsFolderSchema(MkpInstalledAppNewsFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			RealUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			Name = "MkpInstalledAppNewsFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			RightSchemaName = @"SysMkpInstAppNewsFolderRight";
			DesignLocalizationSchemaName = @"SysMkpInstAppNewsFolderLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MkpInstalledAppNewsFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MkpInstalledAppNewsFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MkpInstalledAppNewsFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90"));
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsFolder

	/// <summary>
	/// Installed app news folder.
	/// </summary>
	public class MkpInstalledAppNewsFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public MkpInstalledAppNewsFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MkpInstalledAppNewsFolder";
		}

		public MkpInstalledAppNewsFolder(MkpInstalledAppNewsFolder source)
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

		private MkpInstalledAppNewsFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public MkpInstalledAppNewsFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as MkpInstalledAppNewsFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess(UserConnection);
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
			return new MkpInstalledAppNewsFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : MkpInstalledAppNewsFolder
	{

		public MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess";
			SchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
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

	#region Class: MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess : MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess<MkpInstalledAppNewsFolder>
	{

		public MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess

	public partial class MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MkpInstalledAppNewsFolderEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsFolderEventsProcess : MkpInstalledAppNewsFolder_MkpNotificationsEventsProcess
	{

		public MkpInstalledAppNewsFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

