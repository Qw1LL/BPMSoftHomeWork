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

	#region Class: AccountInFolderSchema

	/// <exclude/>
	public class AccountInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public AccountInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountInFolderSchema(AccountInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountInFolderSchema(AccountInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9");
			RealUId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9");
			Name = "AccountInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("68dae54f-3691-477e-91ce-d38e8cb3277d")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("68dae54f-3691-477e-91ce-d38e8cb3277d"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9"),
				ModifiedInSchemaUId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountInFolder

	/// <summary>
	/// Account in folder.
	/// </summary>
	public class AccountInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public AccountInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountInFolder";
		}

		public AccountInFolder(AccountInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new AccountInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("AccountInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("AccountInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("AccountInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class AccountInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : AccountInFolder
	{

		public AccountInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountInFolder_BaseEventsProcess";
			SchemaUId = new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("88c4a9e2-e539-4832-90f4-efc1779ebad9");
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

	#region Class: AccountInFolder_BaseEventsProcess

	/// <exclude/>
	public class AccountInFolder_BaseEventsProcess : AccountInFolder_BaseEventsProcess<AccountInFolder>
	{

		public AccountInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountInFolder_BaseEventsProcess

	public partial class AccountInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountInFolderEventsProcess

	/// <exclude/>
	public class AccountInFolderEventsProcess : AccountInFolder_BaseEventsProcess
	{

		public AccountInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

