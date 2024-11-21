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

	#region Class: CaseFile_Case_BPMSoftSchema

	/// <exclude/>
	public class CaseFile_Case_BPMSoftSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CaseFile_Case_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseFile_Case_BPMSoftSchema(CaseFile_Case_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseFile_Case_BPMSoftSchema(CaseFile_Case_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			RealUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			Name = "CaseFile_Case_BPMSoft";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateCaseColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3d038238-d673-4e2d-8ca5-849583433b4c")) == null) {
				Columns.Add(CreateIsNeedToNotifyColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f414185-cc3f-472f-a6da-826581100d11"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708"),
				ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNeedToNotifyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3d038238-d673-4e2d-8ca5-849583433b4c"),
				Name = @"IsNeedToNotify",
				CreatedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708"),
				ModifiedInSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseFile_Case_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseFile_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseFile_Case_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseFile_Case_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseFile_Case_BPMSoft

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Обращения".
	/// </summary>
	public class CaseFile_Case_BPMSoft : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public CaseFile_Case_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseFile_Case_BPMSoft";
		}

		public CaseFile_Case_BPMSoft(CaseFile_Case_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращения.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <summary>
		/// IsNeedToNotify.
		/// </summary>
		public bool IsNeedToNotify {
			get {
				return GetTypedColumnValue<bool>("IsNeedToNotify");
			}
			set {
				SetColumnValue("IsNeedToNotify", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseFile_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseFile_Case_BPMSoftDeleted", e);
			Updated += (s, e) => ThrowEvent("CaseFile_Case_BPMSoftUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseFile_Case_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseFile_CaseEventsProcess

	/// <exclude/>
	public partial class CaseFile_CaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : CaseFile_Case_BPMSoft
	{

		public CaseFile_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseFile_CaseEventsProcess";
			SchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
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

	#region Class: CaseFile_CaseEventsProcess

	/// <exclude/>
	public class CaseFile_CaseEventsProcess : CaseFile_CaseEventsProcess<CaseFile_Case_BPMSoft>
	{

		public CaseFile_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseFile_CaseEventsProcess

	public partial class CaseFile_CaseEventsProcess<TEntity>
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

}

