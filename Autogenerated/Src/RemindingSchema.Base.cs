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
	using BPMSoft.Core.Store;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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

	#region Class: Reminding_Base_BPMSoftSchema

	/// <exclude/>
	public class Reminding_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Reminding_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Reminding_Base_BPMSoftSchema(Reminding_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Reminding_Base_BPMSoftSchema(Reminding_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
			RealUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
			Name = "Reminding_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSubjectCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("29447fd8-0545-41f3-a9cb-e8d0a36f2a8f")) == null) {
				Columns.Add(CreateAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("401431cd-1d52-4419-a1f1-7667a3544d2c")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("afe1fb47-e911-4236-b7d7-54bd55871983")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("ce7f9708-5cbd-4316-ba39-496e33195324")) == null) {
				Columns.Add(CreateRemindTimeColumn());
			}
			if (Columns.FindByUId(new Guid("7f4c5e97-b69b-4a81-ac70-5f73d2633b13")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("051943fd-8798-43e2-bc43-cfb70fb42804")) == null) {
				Columns.Add(CreateSubjectIdColumn());
			}
			if (Columns.FindByUId(new Guid("e6fef746-fa59-400e-8769-444734b1a203")) == null) {
				Columns.Add(CreateSysEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("ee738b36-5182-42c7-9ffe-937b371f40fd")) == null) {
				Columns.Add(CreateTypeCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("a6f05909-7c06-47e6-b75e-27a23dc94154")) == null) {
				Columns.Add(CreatePopupTitleColumn());
			}
			if (Columns.FindByUId(new Guid("86f8371c-ea23-4e99-9505-d424d8b6abd3")) == null) {
				Columns.Add(CreateHashColumn());
			}
			if (Columns.FindByUId(new Guid("57a5c5da-e5bd-4e78-a212-459ecb9a3356")) == null) {
				Columns.Add(CreateIsReadColumn());
			}
			if (Columns.FindByUId(new Guid("04821e69-0db1-4ef8-a967-22239620a1e1")) == null) {
				Columns.Add(CreateNotificationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("97932595-fb5b-4eac-8639-8b1a0e523827")) == null) {
				Columns.Add(CreateLoaderColumn());
			}
			if (Columns.FindByUId(new Guid("c01085ea-f81e-461c-962b-d5df12f47e69")) == null) {
				Columns.Add(CreateSenderIdColumn());
			}
			if (Columns.FindByUId(new Guid("33e7d87a-b17f-4590-8ee4-69e19f2e82ba")) == null) {
				Columns.Add(CreateIsNeedToSendColumn());
			}
			if (Columns.FindByUId(new Guid("e09a2804-1d9d-4eae-8eb4-2a53134f337f")) == null) {
				Columns.Add(CreateAnniversaryDateColumn());
			}
			if (Columns.FindByUId(new Guid("a1f17207-ceb7-4b10-bcb8-078494f05b21")) == null) {
				Columns.Add(CreateConfigColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("29447fd8-0545-41f3-a9cb-e8d0a36f2a8f"),
				Name = @"Author",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("401431cd-1d52-4419-a1f1-7667a3544d2c"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("afe1fb47-e911-4236-b7d7-54bd55871983"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5"),
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ce7f9708-5cbd-4316-ba39-496e33195324"),
				Name = @"RemindTime",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("7f4c5e97-b69b-4a81-ac70-5f73d2633b13"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("051943fd-8798-43e2-bc43-cfb70fb42804"),
				Name = @"SubjectId",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6fef746-fa59-400e-8769-444734b1a203"),
				Name = @"SysEntitySchema",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f80d917a-4f9a-4617-b6d7-afffab1b9d57"),
				Name = @"SubjectCaption",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ee738b36-5182-42c7-9ffe-937b371f40fd"),
				Name = @"TypeCaption",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("2225ee40-8de9-4302-9125-1477122665f5")
			};
		}

		protected virtual EntitySchemaColumn CreatePopupTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a6f05909-7c06-47e6-b75e-27a23dc94154"),
				Name = @"PopupTitle",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("86f8371c-ea23-4e99-9505-d424d8b6abd3"),
				Name = @"Hash",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateIsReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("57a5c5da-e5bd-4e78-a212-459ecb9a3356"),
				Name = @"IsRead",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7")
			};
		}

		protected virtual EntitySchemaColumn CreateNotificationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("04821e69-0db1-4ef8-a967-22239620a1e1"),
				Name = @"NotificationType",
				ReferenceSchemaUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"685e7149-c015-4a4d-b4a6-2e5625a6314c"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLoaderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("97932595-fb5b-4eac-8639-8b1a0e523827"),
				Name = @"Loader",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("1b79a4cf-ffd7-42a6-b882-ae3859f2ab39")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c01085ea-f81e-461c-962b-d5df12f47e69"),
				Name = @"SenderId",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("7094e60e-83c9-4747-8d9c-40b7b1b1c58b")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNeedToSendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("33e7d87a-b17f-4590-8ee4-69e19f2e82ba"),
				Name = @"IsNeedToSend",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateAnniversaryDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("e09a2804-1d9d-4eae-8eb4-2a53134f337f"),
				Name = @"AnniversaryDate",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1f17207-ceb7-4b10-bcb8-078494f05b21"),
				Name = @"Config",
				CreatedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				ModifiedInSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Reminding_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Reminding_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Reminding_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Reminding_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37"));
		}

		#endregion

	}

	#endregion

	#region Class: Reminding_Base_BPMSoft

	/// <summary>
	/// Notification.
	/// </summary>
	public class Reminding_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Reminding_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Reminding_Base_BPMSoft";
		}

		public Reminding_Base_BPMSoft(Reminding_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = LookupColumnEntities.GetEntity("Author") as Contact);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// To.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private RemindingSource _source;
		/// <summary>
		/// Source.
		/// </summary>
		public RemindingSource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as RemindingSource);
			}
		}

		/// <summary>
		/// Time.
		/// </summary>
		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Unique caption Id.
		/// </summary>
		public Guid SubjectId {
			get {
				return GetTypedColumnValue<Guid>("SubjectId");
			}
			set {
				SetColumnValue("SubjectId", value);
			}
		}

		/// <exclude/>
		public Guid SysEntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaId");
			}
			set {
				SetColumnValue("SysEntitySchemaId", value);
				_sysEntitySchema = null;
			}
		}

		/// <exclude/>
		public string SysEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("SysEntitySchemaName");
			}
			set {
				SetColumnValue("SysEntitySchemaName", value);
				if (_sysEntitySchema != null) {
					_sysEntitySchema.Name = value;
				}
			}
		}

		private VwSysModuleEntity _sysEntitySchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwSysModuleEntity SysEntitySchema {
			get {
				return _sysEntitySchema ??
					(_sysEntitySchema = LookupColumnEntities.GetEntity("SysEntitySchema") as VwSysModuleEntity);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string SubjectCaption {
			get {
				return GetTypedColumnValue<string>("SubjectCaption");
			}
			set {
				SetColumnValue("SubjectCaption", value);
			}
		}

		/// <summary>
		/// Type name.
		/// </summary>
		public string TypeCaption {
			get {
				return GetTypedColumnValue<string>("TypeCaption");
			}
			set {
				SetColumnValue("TypeCaption", value);
			}
		}

		/// <summary>
		/// Popup title.
		/// </summary>
		public string PopupTitle {
			get {
				return GetTypedColumnValue<string>("PopupTitle");
			}
			set {
				SetColumnValue("PopupTitle", value);
			}
		}

		/// <summary>
		/// Hash code.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <summary>
		/// IsRead.
		/// </summary>
		public bool IsRead {
			get {
				return GetTypedColumnValue<bool>("IsRead");
			}
			set {
				SetColumnValue("IsRead", value);
			}
		}

		/// <exclude/>
		public Guid NotificationTypeId {
			get {
				return GetTypedColumnValue<Guid>("NotificationTypeId");
			}
			set {
				SetColumnValue("NotificationTypeId", value);
				_notificationType = null;
			}
		}

		/// <exclude/>
		public string NotificationTypeName {
			get {
				return GetTypedColumnValue<string>("NotificationTypeName");
			}
			set {
				SetColumnValue("NotificationTypeName", value);
				if (_notificationType != null) {
					_notificationType.Name = value;
				}
			}
		}

		private NotificationType _notificationType;
		/// <summary>
		/// NotificationType.
		/// </summary>
		public NotificationType NotificationType {
			get {
				return _notificationType ??
					(_notificationType = LookupColumnEntities.GetEntity("NotificationType") as NotificationType);
			}
		}

		/// <exclude/>
		public Guid LoaderId {
			get {
				return GetTypedColumnValue<Guid>("LoaderId");
			}
			set {
				SetColumnValue("LoaderId", value);
				_loader = null;
			}
		}

		/// <exclude/>
		public string LoaderName {
			get {
				return GetTypedColumnValue<string>("LoaderName");
			}
			set {
				SetColumnValue("LoaderName", value);
				if (_loader != null) {
					_loader.Name = value;
				}
			}
		}

		private VwSysModuleEntity _loader;
		/// <summary>
		/// Notification loader.
		/// </summary>
		public VwSysModuleEntity Loader {
			get {
				return _loader ??
					(_loader = LookupColumnEntities.GetEntity("Loader") as VwSysModuleEntity);
			}
		}

		/// <summary>
		/// Parent entity ID.
		/// </summary>
		public Guid SenderId {
			get {
				return GetTypedColumnValue<Guid>("SenderId");
			}
			set {
				SetColumnValue("SenderId", value);
			}
		}

		/// <summary>
		/// Message is need to send.
		/// </summary>
		public bool IsNeedToSend {
			get {
				return GetTypedColumnValue<bool>("IsNeedToSend");
			}
			set {
				SetColumnValue("IsNeedToSend", value);
			}
		}

		/// <summary>
		/// Date of anninersary.
		/// </summary>
		public DateTime AnniversaryDate {
			get {
				return GetTypedColumnValue<DateTime>("AnniversaryDate");
			}
			set {
				SetColumnValue("AnniversaryDate", value);
			}
		}

		/// <summary>
		/// Config.
		/// </summary>
		public string Config {
			get {
				return GetTypedColumnValue<string>("Config");
			}
			set {
				SetColumnValue("Config", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Reminding_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Reminding_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Reminding_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Reminding_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Reminding_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Reminding_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Reminding_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Reminding_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Reminding_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Reminding_BaseEventsProcess

	/// <exclude/>
	public partial class Reminding_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Reminding_Base_BPMSoft
	{

		public Reminding_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Reminding_BaseEventsProcess";
			SchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsNew {
			get;
			set;
		}

		public virtual bool IsRemindingForImmediateSend {
			get;
			set;
		}

		public virtual bool IsRemindingPostponed {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess;
		public ProcessFlowElement EventSubProcess {
			get {
				return _eventSubProcess ?? (_eventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess",
					SchemaElementUId = new Guid("38f6f9be-5d9c-477e-901e-68eb4f2c5ab8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _remindingSavedStartMessage;
		public ProcessFlowElement RemindingSavedStartMessage {
			get {
				return _remindingSavedStartMessage ?? (_remindingSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RemindingSavedStartMessage",
					SchemaElementUId = new Guid("7bbd26e9-038c-4382-9ee6-93fb46a5f7f1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _remindingDeletedStartMessage;
		public ProcessFlowElement RemindingDeletedStartMessage {
			get {
				return _remindingDeletedStartMessage ?? (_remindingDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RemindingDeletedStartMessage",
					SchemaElementUId = new Guid("173f83e0-ef4f-4f09-a917-61f3b3683b81"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _remindingSavedScriptTask;
		public ProcessScriptTask RemindingSavedScriptTask {
			get {
				return _remindingSavedScriptTask ?? (_remindingSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemindingSavedScriptTask",
					SchemaElementUId = new Guid("77e54843-52d8-423e-bf43-fdef747add27"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemindingSavedScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _remindingDeletedScriptTask;
		public ProcessScriptTask RemindingDeletedScriptTask {
			get {
				return _remindingDeletedScriptTask ?? (_remindingDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemindingDeletedScriptTask",
					SchemaElementUId = new Guid("828d3cfa-ce4a-4b39-997a-d7f7ae1afaa8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemindingDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _remindingInsertedScriptTask;
		public ProcessScriptTask RemindingInsertedScriptTask {
			get {
				return _remindingInsertedScriptTask ?? (_remindingInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemindingInsertedScriptTask",
					SchemaElementUId = new Guid("9cb08072-9b2c-4cfe-bbbc-ae52b90bb4f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemindingInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _remindingInsertedStartMessage;
		public ProcessFlowElement RemindingInsertedStartMessage {
			get {
				return _remindingInsertedStartMessage ?? (_remindingInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RemindingInsertedStartMessage",
					SchemaElementUId = new Guid("fc7a3594-a563-41fa-8acd-b945708aac81"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _remindingInsertingStartMessage;
		public ProcessFlowElement RemindingInsertingStartMessage {
			get {
				return _remindingInsertingStartMessage ?? (_remindingInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RemindingInsertingStartMessage",
					SchemaElementUId = new Guid("79648fc8-fb36-456c-9fb8-55aac88b4cd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _remindingInsertingScriptTask;
		public ProcessScriptTask RemindingInsertingScriptTask {
			get {
				return _remindingInsertingScriptTask ?? (_remindingInsertingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemindingInsertingScriptTask",
					SchemaElementUId = new Guid("39626b64-4c4c-4544-bb4c-50dbe21ff51d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemindingInsertingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _remindingSavingStartMessage;
		public ProcessFlowElement RemindingSavingStartMessage {
			get {
				return _remindingSavingStartMessage ?? (_remindingSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RemindingSavingStartMessage",
					SchemaElementUId = new Guid("ec01b1b6-430f-47b0-b160-192b55711db6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _remindingSavingScriptTask;
		public ProcessScriptTask RemindingSavingScriptTask {
			get {
				return _remindingSavingScriptTask ?? (_remindingSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemindingSavingScriptTask",
					SchemaElementUId = new Guid("afa34365-4752-4771-918b-bd18de0d6a41"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemindingSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess };
			FlowElements[RemindingSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingSavedStartMessage };
			FlowElements[RemindingDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingDeletedStartMessage };
			FlowElements[RemindingSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingSavedScriptTask };
			FlowElements[RemindingDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingDeletedScriptTask };
			FlowElements[RemindingInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingInsertedScriptTask };
			FlowElements[RemindingInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingInsertedStartMessage };
			FlowElements[RemindingInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingInsertingStartMessage };
			FlowElements[RemindingInsertingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingInsertingScriptTask };
			FlowElements[RemindingSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingSavingStartMessage };
			FlowElements[RemindingSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess":
						break;
					case "RemindingSavedStartMessage":
						e.Context.QueueTasks.Enqueue("RemindingSavedScriptTask");
						break;
					case "RemindingDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("RemindingDeletedScriptTask");
						break;
					case "RemindingSavedScriptTask":
						break;
					case "RemindingDeletedScriptTask":
						break;
					case "RemindingInsertedScriptTask":
						break;
					case "RemindingInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("RemindingInsertedScriptTask");
						break;
					case "RemindingInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("RemindingInsertingScriptTask");
						break;
					case "RemindingInsertingScriptTask":
						break;
					case "RemindingSavingStartMessage":
						e.Context.QueueTasks.Enqueue("RemindingSavingScriptTask");
						break;
					case "RemindingSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("RemindingSavedStartMessage");
			ActivatedEventElements.Add("RemindingDeletedStartMessage");
			ActivatedEventElements.Add("RemindingInsertedStartMessage");
			ActivatedEventElements.Add("RemindingInsertingStartMessage");
			ActivatedEventElements.Add("RemindingSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "RemindingSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingSavedStartMessage";
					result = RemindingSavedStartMessage.Execute(context);
					break;
				case "RemindingDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingDeletedStartMessage";
					result = RemindingDeletedStartMessage.Execute(context);
					break;
				case "RemindingSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingSavedScriptTask";
					result = RemindingSavedScriptTask.Execute(context, RemindingSavedScriptTaskExecute);
					break;
				case "RemindingDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingDeletedScriptTask";
					result = RemindingDeletedScriptTask.Execute(context, RemindingDeletedScriptTaskExecute);
					break;
				case "RemindingInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingInsertedScriptTask";
					result = RemindingInsertedScriptTask.Execute(context, RemindingInsertedScriptTaskExecute);
					break;
				case "RemindingInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingInsertedStartMessage";
					result = RemindingInsertedStartMessage.Execute(context);
					break;
				case "RemindingInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingInsertingStartMessage";
					result = RemindingInsertingStartMessage.Execute(context);
					break;
				case "RemindingInsertingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingInsertingScriptTask";
					result = RemindingInsertingScriptTask.Execute(context, RemindingInsertingScriptTaskExecute);
					break;
				case "RemindingSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingSavingStartMessage";
					result = RemindingSavingStartMessage.Execute(context);
					break;
				case "RemindingSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemindingSavingScriptTask";
					result = RemindingSavingScriptTask.Execute(context, RemindingSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool RemindingSavedScriptTaskExecute(ProcessExecutingContext context) {
			OnSavedHandler();
			return true;
		}

		public virtual bool RemindingDeletedScriptTaskExecute(ProcessExecutingContext context) {
			if (!Entity.IsRead) {
				PublishClientRemindingInfo("delete");
			}
			return true;
		}

		public virtual bool RemindingInsertedScriptTaskExecute(ProcessExecutingContext context) {
			OnInsertedHandle();
			return true;
		}

		public virtual bool RemindingInsertingScriptTaskExecute(ProcessExecutingContext context) {
			OnInsertingHandle();
			return true;
		}

		public virtual bool RemindingSavingScriptTaskExecute(ProcessExecutingContext context) {
			OnSavingHandler();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Reminding_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("RemindingSavedStartMessage")) {
							context.QueueTasks.Enqueue("RemindingSavedStartMessage");
						}
						break;
					case "Reminding_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("RemindingDeletedStartMessage")) {
							context.QueueTasks.Enqueue("RemindingDeletedStartMessage");
						}
						break;
					case "Reminding_Base_BPMSoftInserted":
							if (ActivatedEventElements.Contains("RemindingInsertedStartMessage")) {
							context.QueueTasks.Enqueue("RemindingInsertedStartMessage");
						}
						break;
					case "Reminding_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("RemindingInsertingStartMessage")) {
							context.QueueTasks.Enqueue("RemindingInsertingStartMessage");
						}
						break;
					case "Reminding_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("RemindingSavingStartMessage")) {
							context.QueueTasks.Enqueue("RemindingSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Reminding_BaseEventsProcess

	/// <exclude/>
	public class Reminding_BaseEventsProcess : Reminding_BaseEventsProcess<Reminding_Base_BPMSoft>
	{

		public Reminding_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Reminding_BaseEventsProcess

	public partial class Reminding_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void PublishClientRemindingInfo(string operation) {
			string notificationGroup = TryGeNotificationTypeName();
			var remindTime = Entity.GetTypedColumnValue<DateTime>("RemindTime");
			if (remindTime > UserConnection.CurrentUser.GetCurrentDateTime() && !IsRemindingPostponed) {
				return;
			}
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var sysAdminUnit = GetSysAdminUnitIdByContactId(contactId);
			var isReadOld = Entity.GetTypedOldColumnValue<bool>("IsRead");
			var message = new {
				recordId = Entity.Id,
				operation,
				notificationGroup,
				markAsRead = !isReadOld && Entity.IsRead
			};
			var simpleMessage = new SimpleMessage {
				Body = JsonConvert.SerializeObject(message),
				Id = sysAdminUnit
			};
			simpleMessage.Header.Sender = "UpdateReminding";
			var manager = MsgChannelManager.Instance;
			var channel = manager.FindItemByUId(sysAdminUnit);
			channel?.PostMessage(simpleMessage);
		}

		public virtual Guid GetSysAdminUnitIdByContactId(Guid contactId) {
			var currentUser = UserConnection.CurrentUser;
			if (currentUser.ContactId == contactId) {
				return currentUser.Id;
			}
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true,
				CanReadUncommitedData = true,
				Cache = UserConnection.ApplicationCache.WithLocalCaching("NotificationUsers"),
				CacheItemName = contactId.ToString()
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var queryFilterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId);
			esq.Filters.Add(queryFilterItem);
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.IsEmpty()) {
				return Guid.Empty;
			}
			var entity = entities.First.Value;
			return entity.GetTypedColumnValue<Guid>(esq.PrimaryQueryColumn.Name);
		}

		public virtual string GetSchemaName(ISchemaManager schemaManager, Guid entitySchemaId) {
			var schemaManagerItem = schemaManager.FindItemByUId(entitySchemaId);
			return schemaManagerItem != null ? schemaManagerItem.Name : string.Empty;
		}

		public virtual void OnInsertedHandle() {
			if (Entity.NotificationTypeId != RemindingConsts.NotificationTypeRemindingId ||
					IsRemindingForImmediateSend) {
				SendNotification();
				IsRemindingForImmediateSend = false;
			}
		}

		public virtual void OnInsertingHandle() {
			IsNew = true;
		}

		public virtual void OnSavingHandler() {
			if (Entity.NotificationTypeId == RemindingConsts.NotificationTypeRemindingId) {
				IsRemindingPostponed = GetIsRemindingPostponed();
				if (IsChangedTargetColumns()) {
					Entity.IsNeedToSend = true;
				}
				if (!IsCorrectRemindTime()) {
					Entity.IsNeedToSend = false;
					IsRemindingForImmediateSend = true;
				}
			} else if (Entity.StoringState == StoringObjectState.Changed) {
				var changedColumns = Entity.GetChangedColumnValues();
				if (changedColumns.Any(column => column.Name == "IsRead")) {
					PublishClientRemindingInfo("update");
				}
				if (IsChangedTargetColumns()) {
					IsRemindingForImmediateSend = true;
				}
			}
		}

		public virtual bool IsChangedTargetColumns() {
			IEnumerable<string> targetColumns = GetTargetColumnsForChange();
			var changedColumns = Entity.GetChangedColumnValues();
			return changedColumns.Any(column => targetColumns.Contains(column.Name));
		}

		public virtual IEnumerable<string>  GetTargetColumnsForChange() {
			return new[] {"RemindTime", "ContactId", "Description", "SubjectCaption"};
		}

		public virtual void OnSavedHandler() {
			if (IsRemindingForImmediateSend) {
				if (!Entity.IsRead) {
					PublishClientRemindingInfo("delete");
				}
				SendNotification();
				return;
			}
			if (Entity.NotificationTypeId == RemindingConsts.NotificationTypeRemindingId || !Entity.IsRead) {
				var operation = !IsCorrectRemindTime() ? "update" : "delete";
				if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
					if (IsNew) {
						return;
					}
				}
				PublishClientRemindingInfo(operation);
			}
		}

		public virtual bool IsCorrectRemindTime() {
			var currentDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
			if (Entity.RemindTime <= currentDateTime) {
				return false;
			}
			return true;
		}

		public virtual void SendNotification() {
		}

		public virtual string TryGeNotificationTypeName() {
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName("NotificationType");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.FetchFromDB(entitySchema.PrimaryColumn.Name, Entity.NotificationTypeId,
				new[] {entitySchema.PrimaryDisplayColumn.Name});
			return entity.PrimaryDisplayColumnValue;
		}

		public virtual bool GetIsRemindingPostponed() {
			DateTime currentDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
			bool oldNeedToSend = Entity.GetTypedOldColumnValue<bool>("IsNeedToSend");
			DateTime oldRemindTime = Entity.GetTypedOldColumnValue<DateTime>("RemindTime");
			DateTime newRemindTime = Entity.GetTypedColumnValue<DateTime>("RemindTime");
			bool oldRemindTimePassed = currentDateTime >= oldRemindTime && oldRemindTime != default(DateTime);
			bool remindTimeChanged = oldRemindTime != newRemindTime;
			return oldRemindTimePassed && remindTimeChanged && !oldNeedToSend;
		}

		#endregion

	}

	#endregion

}

