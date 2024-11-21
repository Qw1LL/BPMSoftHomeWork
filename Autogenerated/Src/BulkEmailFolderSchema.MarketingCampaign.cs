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

	#region Class: BulkEmailFolderSchema

	/// <exclude/>
	public class BulkEmailFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public BulkEmailFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailFolderSchema(BulkEmailFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailFolderSchema(BulkEmailFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			RealUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			Name = "BulkEmailFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailFolder_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailFolder

	/// <summary>
	/// Группа раздела "Email".
	/// </summary>
	public class BulkEmailFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public BulkEmailFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailFolder";
		}

		public BulkEmailFolder(BulkEmailFolder source)
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

		private BulkEmailFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public BulkEmailFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as BulkEmailFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailFolder_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailFolder_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailFolder_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : BulkEmailFolder
	{

		public BulkEmailFolder_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailFolder_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4bad689e-dfbe-4bd8-9fbc-4ee8316331f1");
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

	#region Class: BulkEmailFolder_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailFolder_MarketingCampaignEventsProcess : BulkEmailFolder_MarketingCampaignEventsProcess<BulkEmailFolder>
	{

		public BulkEmailFolder_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailFolder_MarketingCampaignEventsProcess

	public partial class BulkEmailFolder_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: BulkEmailFolderEventsProcess

	/// <exclude/>
	public class BulkEmailFolderEventsProcess : BulkEmailFolder_MarketingCampaignEventsProcess
	{

		public BulkEmailFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

