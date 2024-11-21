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

	#region Class: MailboxContactFolderSchema

	/// <exclude/>
	public class MailboxContactFolderSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailboxContactFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxContactFolderSchema(MailboxContactFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxContactFolderSchema(MailboxContactFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			RealUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			Name = "MailboxContactFolder";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5322eb80-67de-4f34-9274-39702d3a7e4f")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("344802e0-6680-4246-9cb3-1e256159870d")) == null) {
				Columns.Add(CreateContactFolderColumn());
			}
			if (Columns.FindByUId(new Guid("1a07dacd-f599-4331-aef3-e914b1ab501e")) == null) {
				Columns.Add(CreateRemoteFolderIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5322eb80-67de-4f34-9274-39702d3a7e4f"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateContactFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("344802e0-6680-4246-9cb3-1e256159870d"),
				Name = @"ContactFolder",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateRemoteFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1a07dacd-f599-4331-aef3-e914b1ab501e"),
				Name = @"RemoteFolderId",
				CreatedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				ModifiedInSchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailboxContactFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxContactFolder_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxContactFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxContactFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxContactFolder

	/// <summary>
	/// Contact folder alignment.
	/// </summary>
	public class MailboxContactFolder : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailboxContactFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxContactFolder";
		}

		public MailboxContactFolder(MailboxContactFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		/// <exclude/>
		public Guid ContactFolderId {
			get {
				return GetTypedColumnValue<Guid>("ContactFolderId");
			}
			set {
				SetColumnValue("ContactFolderId", value);
				_contactFolder = null;
			}
		}

		/// <exclude/>
		public string ContactFolderName {
			get {
				return GetTypedColumnValue<string>("ContactFolderName");
			}
			set {
				SetColumnValue("ContactFolderName", value);
				if (_contactFolder != null) {
					_contactFolder.Name = value;
				}
			}
		}

		private ContactFolder _contactFolder;
		/// <summary>
		/// Contact folder.
		/// </summary>
		public ContactFolder ContactFolder {
			get {
				return _contactFolder ??
					(_contactFolder = LookupColumnEntities.GetEntity("ContactFolder") as ContactFolder);
			}
		}

		/// <summary>
		/// External storage folder Id.
		/// </summary>
		public string RemoteFolderId {
			get {
				return GetTypedColumnValue<string>("RemoteFolderId");
			}
			set {
				SetColumnValue("RemoteFolderId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxContactFolder_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxContactFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("MailboxContactFolderInserting", e);
			Validating += (s, e) => ThrowEvent("MailboxContactFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxContactFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxContactFolder_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailboxContactFolder_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MailboxContactFolder
	{

		public MailboxContactFolder_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxContactFolder_ExchangeEventsProcess";
			SchemaUId = new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e1466320-9fa5-4471-937a-f5a2c2f02173");
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

	#region Class: MailboxContactFolder_ExchangeEventsProcess

	/// <exclude/>
	public class MailboxContactFolder_ExchangeEventsProcess : MailboxContactFolder_ExchangeEventsProcess<MailboxContactFolder>
	{

		public MailboxContactFolder_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxContactFolder_ExchangeEventsProcess

	public partial class MailboxContactFolder_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailboxContactFolderEventsProcess

	/// <exclude/>
	public class MailboxContactFolderEventsProcess : MailboxContactFolder_ExchangeEventsProcess
	{

		public MailboxContactFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

