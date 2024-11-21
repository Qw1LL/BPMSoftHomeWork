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

	#region Class: MkpInstalledAppNewsInFolderSchema

	/// <exclude/>
	public class MkpInstalledAppNewsInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public MkpInstalledAppNewsInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MkpInstalledAppNewsInFolderSchema(MkpInstalledAppNewsInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MkpInstalledAppNewsInFolderSchema(MkpInstalledAppNewsInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			RealUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			Name = "MkpInstalledAppNewsInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			RightSchemaName = @"SysMkpInstAppNewsInFolderRight";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0bc2be65-fd07-4978-8db0-a7b09edaf1d6")) == null) {
				Columns.Add(CreateMkpInstalledAppNewsColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("6bde85c9-8c2b-4cc7-91ee-fae875b35d90");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMkpInstalledAppNewsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0bc2be65-fd07-4978-8db0-a7b09edaf1d6"),
				Name = @"MkpInstalledAppNews",
				ReferenceSchemaUId = new Guid("0c92974f-4dbe-4990-968e-3d1fa1719a53"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40"),
				ModifiedInSchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40"),
				CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MkpInstalledAppNewsInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MkpInstalledAppNewsInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MkpInstalledAppNewsInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4359edbc-5450-4782-b0db-bec223b50c40"));
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsInFolder

	/// <summary>
	/// Installed app news in folder.
	/// </summary>
	public class MkpInstalledAppNewsInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public MkpInstalledAppNewsInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MkpInstalledAppNewsInFolder";
		}

		public MkpInstalledAppNewsInFolder(MkpInstalledAppNewsInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MkpInstalledAppNewsId {
			get {
				return GetTypedColumnValue<Guid>("MkpInstalledAppNewsId");
			}
			set {
				SetColumnValue("MkpInstalledAppNewsId", value);
				_mkpInstalledAppNews = null;
			}
		}

		private MkpInstalledAppNews _mkpInstalledAppNews;
		/// <summary>
		/// Installed app news.
		/// </summary>
		public MkpInstalledAppNews MkpInstalledAppNews {
			get {
				return _mkpInstalledAppNews ??
					(_mkpInstalledAppNews = LookupColumnEntities.GetEntity("MkpInstalledAppNews") as MkpInstalledAppNews);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess(UserConnection);
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
			return new MkpInstalledAppNewsInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : MkpInstalledAppNewsInFolder
	{

		public MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess";
			SchemaUId = new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4359edbc-5450-4782-b0db-bec223b50c40");
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

	#region Class: MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess : MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess<MkpInstalledAppNewsInFolder>
	{

		public MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess

	public partial class MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MkpInstalledAppNewsInFolderEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsInFolderEventsProcess : MkpInstalledAppNewsInFolder_MkpNotificationsEventsProcess
	{

		public MkpInstalledAppNewsInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

