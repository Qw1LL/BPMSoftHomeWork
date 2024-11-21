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

	#region Class: QuickDialUserSettingsSchema

	/// <exclude/>
	public class QuickDialUserSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QuickDialUserSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickDialUserSettingsSchema(QuickDialUserSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickDialUserSettingsSchema(QuickDialUserSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291");
			RealUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291");
			Name = "QuickDialUserSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreatePhoneNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cd244883-eea7-479d-bda2-82c90d979763")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("92fe6d91-b80f-4f93-aad9-84db3586ef84")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePhoneNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("534bbf20-f1dd-4cb4-bbde-5f6a5c19f142"),
				Name = @"PhoneNumber",
				CreatedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
				ModifiedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cd244883-eea7-479d-bda2-82c90d979763"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
				ModifiedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("92fe6d91-b80f-4f93-aad9-84db3586ef84"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
				ModifiedInSchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"),
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
			return new QuickDialUserSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickDialUserSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickDialUserSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickDialUserSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickDialUserSettings

	/// <summary>
	/// Quick dial setup.
	/// </summary>
	public class QuickDialUserSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QuickDialUserSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickDialUserSettings";
		}

		public QuickDialUserSettings(QuickDialUserSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Phone number.
		/// </summary>
		public string PhoneNumber {
			get {
				return GetTypedColumnValue<string>("PhoneNumber");
			}
			set {
				SetColumnValue("PhoneNumber", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickDialUserSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QuickDialUserSettingsDeleted", e);
			Deleting += (s, e) => ThrowEvent("QuickDialUserSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("QuickDialUserSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("QuickDialUserSettingsInserting", e);
			Saving += (s, e) => ThrowEvent("QuickDialUserSettingsSaving", e);
			Validating += (s, e) => ThrowEvent("QuickDialUserSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QuickDialUserSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickDialUserSettings_BaseEventsProcess

	/// <exclude/>
	public partial class QuickDialUserSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QuickDialUserSettings
	{

		public QuickDialUserSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickDialUserSettings_BaseEventsProcess";
			SchemaUId = new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50b6b3df-1b74-4b19-b2ab-9dd3bf1c5291");
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

	#region Class: QuickDialUserSettings_BaseEventsProcess

	/// <exclude/>
	public class QuickDialUserSettings_BaseEventsProcess : QuickDialUserSettings_BaseEventsProcess<QuickDialUserSettings>
	{

		public QuickDialUserSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickDialUserSettings_BaseEventsProcess

	public partial class QuickDialUserSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickDialUserSettingsEventsProcess

	/// <exclude/>
	public class QuickDialUserSettingsEventsProcess : QuickDialUserSettings_BaseEventsProcess
	{

		public QuickDialUserSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

