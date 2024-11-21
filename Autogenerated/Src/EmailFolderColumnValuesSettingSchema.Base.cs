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

	#region Class: EmailFolderColumnValuesSetting_Base_BPMSoftSchema

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailFolderColumnValuesSetting_Base_BPMSoftSchema(EmailFolderColumnValuesSetting_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailFolderColumnValuesSetting_Base_BPMSoftSchema(EmailFolderColumnValuesSetting_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			RealUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			Name = "EmailFolderColumnValuesSetting_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f2ce4215-be0e-44df-b47f-fc5bef3ca659")) == null) {
				Columns.Add(CreateEmailFolderColumn());
			}
			if (Columns.FindByUId(new Guid("932d078b-454f-4cf3-909d-a3c010e7bb3a")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("d8f8a8b3-5930-4e7a-bec1-3114b6904adf")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmailFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f2ce4215-be0e-44df-b47f-fc5bef3ca659"),
				Name = @"EmailFolder",
				ReferenceSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				ModifiedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("932d078b-454f-4cf3-909d-a3c010e7bb3a"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				ModifiedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d8f8a8b3-5930-4e7a-bec1-3114b6904adf"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				ModifiedInSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailFolderColumnValuesSetting_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_Base_BPMSoft

	/// <summary>
	/// Setup of email folder field values.
	/// </summary>
	public class EmailFolderColumnValuesSetting_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailFolderColumnValuesSetting_Base_BPMSoft";
		}

		public EmailFolderColumnValuesSetting_Base_BPMSoft(EmailFolderColumnValuesSetting_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmailFolderId {
			get {
				return GetTypedColumnValue<Guid>("EmailFolderId");
			}
			set {
				SetColumnValue("EmailFolderId", value);
				_emailFolder = null;
			}
		}

		/// <exclude/>
		public string EmailFolderName {
			get {
				return GetTypedColumnValue<string>("EmailFolderName");
			}
			set {
				SetColumnValue("EmailFolderName", value);
				if (_emailFolder != null) {
					_emailFolder.Name = value;
				}
			}
		}

		private ActivityFolder _emailFolder;
		/// <summary>
		/// Email folder.
		/// </summary>
		public ActivityFolder EmailFolder {
			get {
				return _emailFolder ??
					(_emailFolder = LookupColumnEntities.GetEntity("EmailFolder") as ActivityFolder);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailFolderColumnValuesSetting_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Base_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_BaseEventsProcess

	/// <exclude/>
	public partial class EmailFolderColumnValuesSetting_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailFolderColumnValuesSetting_Base_BPMSoft
	{

		public EmailFolderColumnValuesSetting_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailFolderColumnValuesSetting_BaseEventsProcess";
			SchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
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

	#region Class: EmailFolderColumnValuesSetting_BaseEventsProcess

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_BaseEventsProcess : EmailFolderColumnValuesSetting_BaseEventsProcess<EmailFolderColumnValuesSetting_Base_BPMSoft>
	{

		public EmailFolderColumnValuesSetting_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_BaseEventsProcess

	public partial class EmailFolderColumnValuesSetting_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

