namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: PartnershipFileSchema

	/// <exclude/>
	public class PartnershipFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public PartnershipFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipFileSchema(PartnershipFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipFileSchema(PartnershipFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			RealUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			Name = "PartnershipFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreatePartnershipColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf81a8ae-1644-461c-87ad-0b3c8add8a12"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9"),
				ModifiedInSchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnershipFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipFile_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipFile

	/// <summary>
	/// Файлы партнера.
	/// </summary>
	public class PartnershipFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public PartnershipFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipFile";
		}

		public PartnershipFile(PartnershipFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Партнерства.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = LookupColumnEntities.GetEntity("Partnership") as Partnership);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipFile_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnershipFileDeleted", e);
			Updated += (s, e) => ThrowEvent("PartnershipFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnershipFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipFile_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnershipFile_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : PartnershipFile
	{

		public PartnershipFile_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipFile_PRMBaseEventsProcess";
			SchemaUId = new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("142ad4d9-aa75-4800-9877-c80640a55ed9");
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

	#region Class: PartnershipFile_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnershipFile_PRMBaseEventsProcess : PartnershipFile_PRMBaseEventsProcess<PartnershipFile>
	{

		public PartnershipFile_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipFile_PRMBaseEventsProcess

	public partial class PartnershipFile_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void OnFileSaved() {
			base.OnFileSaved();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				var url = Entity.GetTypedColumnValue<string>("Name").Trim();
				if (IsURLValid(url)) {
					LinkPreview linkPreview = new LinkPreview();
					LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
					if (linkPreviewInfo != null) {
						LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
						linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
					}
				}
			}
		}

		public override void OnFileDeleted() {
			base.OnFileDeleted();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public override void OnFileUpdated() {
			base.OnFileUpdated();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			string oldUrl = (string)Entity.GetColumnOldValue("Name");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId && IsURLValid(oldUrl)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion


	#region Class: PartnershipFileEventsProcess

	/// <exclude/>
	public class PartnershipFileEventsProcess : PartnershipFile_PRMBaseEventsProcess
	{

		public PartnershipFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

