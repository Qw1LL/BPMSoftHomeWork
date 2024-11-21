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

	#region Class: SysInstalledApp_Base_BPMSoftSchema

	/// <exclude/>
	public class SysInstalledApp_Base_BPMSoftSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysInstalledApp_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledApp_Base_BPMSoftSchema(SysInstalledApp_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledApp_Base_BPMSoftSchema(SysInstalledApp_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSysInstalledApp_CodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("adbee7d0-8b5a-421c-9b2e-2cbc3a14f50e");
			index.Name = "SysInstalledApp_Code";
			index.CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("24b02828-3f5f-41e4-b49b-ac9d9454e18b"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			RealUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			Name = "SysInstalledApp_Base_BPMSoft";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5420bb26-d1bc-4732-8c82-372e1e870cdc")) == null) {
				Columns.Add(CreateMaintainerColumn());
			}
			if (Columns.FindByUId(new Guid("aad2b3b4-a300-4468-bca3-ce64c6308a76")) == null) {
				Columns.Add(CreateInstallDateColumn());
			}
			if (Columns.FindByUId(new Guid("934b7730-1761-4b06-9429-dcf70712663c")) == null) {
				Columns.Add(CreateLastUpdateColumn());
			}
			if (Columns.FindByUId(new Guid("9b0af75c-6cb3-4826-9244-ce4f82f760d7")) == null) {
				Columns.Add(CreateMarketplaceLinkColumn());
			}
			if (Columns.FindByUId(new Guid("b4fcdf44-2fd7-4144-a7ac-f0499af1f29c")) == null) {
				Columns.Add(CreateHelpLinkColumn());
			}
			if (Columns.FindByUId(new Guid("9b1eb4c0-e32e-4a5d-8345-a4cd2eb79ea6")) == null) {
				Columns.Add(CreateFileLinkColumn());
			}
			if (Columns.FindByUId(new Guid("95b9bde0-84ef-4a32-93d7-a18b08cb93f9")) == null) {
				Columns.Add(CreateSupportEmailColumn());
			}
			if (Columns.FindByUId(new Guid("2b224027-2933-49e7-b508-3adbeac9f399")) == null) {
				Columns.Add(CreateOrderLinkColumn());
			}
			if (Columns.FindByUId(new Guid("9c9e5d69-f096-4e6c-833c-5296db9d68b4")) == null) {
				Columns.Add(CreateSysInstalledAppStatusColumn());
			}
			if (Columns.FindByUId(new Guid("5f10bf59-890d-51c1-9bd3-63b1c6f1fe52")) == null) {
				Columns.Add(CreateIconBackgroundColumn());
			}
			if (Columns.FindByUId(new Guid("3a8a7a50-ca12-645c-b37e-c2b941d18eec")) == null) {
				Columns.Add(CreateIconColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MediumText");
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMaintainerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5420bb26-d1bc-4732-8c82-372e1e870cdc"),
				Name = @"Maintainer",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("aad2b3b4-a300-4468-bca3-ce64c6308a76"),
				Name = @"InstallDate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateLastUpdateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("934b7730-1761-4b06-9429-dcf70712663c"),
				Name = @"LastUpdate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMarketplaceLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b0af75c-6cb3-4826-9244-ce4f82f760d7"),
				Name = @"MarketplaceLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b4fcdf44-2fd7-4144-a7ac-f0499af1f29c"),
				Name = @"HelpLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateFileLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b1eb4c0-e32e-4a5d-8345-a4cd2eb79ea6"),
				Name = @"FileLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateSupportEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("95b9bde0-84ef-4a32-93d7-a18b08cb93f9"),
				Name = @"SupportEmail",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2b224027-2933-49e7-b508-3adbeac9f399"),
				Name = @"OrderLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c9e5d69-f096-4e6c-833c-5296db9d68b4"),
				Name = @"SysInstalledAppStatus",
				ReferenceSchemaUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIconBackgroundColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5f10bf59-890d-51c1-9bd3-63b1c6f1fe52"),
				Name = @"IconBackground",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679")
			};
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("3a8a7a50-ca12-645c-b37e-c2b941d18eec"),
				Name = @"Icon",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSysInstalledApp_CodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysInstalledApp_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledApp_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledApp_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledApp_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp_Base_BPMSoft

	/// <summary>
	/// Installed application.
	/// </summary>
	public class SysInstalledApp_Base_BPMSoft : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysInstalledApp_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledApp_Base_BPMSoft";
		}

		public SysInstalledApp_Base_BPMSoft(SysInstalledApp_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Maintainer.
		/// </summary>
		public string Maintainer {
			get {
				return GetTypedColumnValue<string>("Maintainer");
			}
			set {
				SetColumnValue("Maintainer", value);
			}
		}

		/// <summary>
		/// Install date.
		/// </summary>
		public DateTime InstallDate {
			get {
				return GetTypedColumnValue<DateTime>("InstallDate");
			}
			set {
				SetColumnValue("InstallDate", value);
			}
		}

		/// <summary>
		/// Date last updated.
		/// </summary>
		public DateTime LastUpdate {
			get {
				return GetTypedColumnValue<DateTime>("LastUpdate");
			}
			set {
				SetColumnValue("LastUpdate", value);
			}
		}

		/// <summary>
		/// Marketplace link.
		/// </summary>
		public string MarketplaceLink {
			get {
				return GetTypedColumnValue<string>("MarketplaceLink");
			}
			set {
				SetColumnValue("MarketplaceLink", value);
			}
		}

		/// <summary>
		/// Help link.
		/// </summary>
		public string HelpLink {
			get {
				return GetTypedColumnValue<string>("HelpLink");
			}
			set {
				SetColumnValue("HelpLink", value);
			}
		}

		/// <summary>
		/// File link.
		/// </summary>
		public string FileLink {
			get {
				return GetTypedColumnValue<string>("FileLink");
			}
			set {
				SetColumnValue("FileLink", value);
			}
		}

		/// <summary>
		/// Support email.
		/// </summary>
		public string SupportEmail {
			get {
				return GetTypedColumnValue<string>("SupportEmail");
			}
			set {
				SetColumnValue("SupportEmail", value);
			}
		}

		/// <summary>
		/// Order link.
		/// </summary>
		public string OrderLink {
			get {
				return GetTypedColumnValue<string>("OrderLink");
			}
			set {
				SetColumnValue("OrderLink", value);
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppStatusId");
			}
			set {
				SetColumnValue("SysInstalledAppStatusId", value);
				_sysInstalledAppStatus = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppStatusName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppStatusName");
			}
			set {
				SetColumnValue("SysInstalledAppStatusName", value);
				if (_sysInstalledAppStatus != null) {
					_sysInstalledAppStatus.Name = value;
				}
			}
		}

		private SysInstalledAppStatus _sysInstalledAppStatus;
		/// <summary>
		/// Application status.
		/// </summary>
		public SysInstalledAppStatus SysInstalledAppStatus {
			get {
				return _sysInstalledAppStatus ??
					(_sysInstalledAppStatus = LookupColumnEntities.GetEntity("SysInstalledAppStatus") as SysInstalledAppStatus);
			}
		}

		/// <summary>
		/// Icon background color.
		/// </summary>
		/// <remarks>
		/// Code of the application icon background color.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledApp_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysInstalledApp_Base_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInstalledApp_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp_BaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledApp_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysInstalledApp_Base_BPMSoft
	{

		public SysInstalledApp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledApp_BaseEventsProcess";
			SchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
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

	#region Class: SysInstalledApp_BaseEventsProcess

	/// <exclude/>
	public class SysInstalledApp_BaseEventsProcess : SysInstalledApp_BaseEventsProcess<SysInstalledApp_Base_BPMSoft>
	{

		public SysInstalledApp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledApp_BaseEventsProcess

	public partial class SysInstalledApp_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

