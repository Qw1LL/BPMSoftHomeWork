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

	#region Class: AccountFolderSchema

	/// <exclude/>
	public class AccountFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public AccountFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountFolderSchema(AccountFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountFolderSchema(AccountFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			RealUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			Name = "AccountFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountFolder

	/// <summary>
	/// Account folder.
	/// </summary>
	public class AccountFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public AccountFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountFolder";
		}

		public AccountFolder(AccountFolder source)
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

		private AccountFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public AccountFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as AccountFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountFolderInserting", e);
			Saved += (s, e) => ThrowEvent("AccountFolderSaved", e);
			Saving += (s, e) => ThrowEvent("AccountFolderSaving", e);
			Validating += (s, e) => ThrowEvent("AccountFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountFolder_BaseEventsProcess

	/// <exclude/>
	public partial class AccountFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : AccountFolder
	{

		public AccountFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountFolder_BaseEventsProcess";
			SchemaUId = new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6bd10faf-89e9-485e-8ee8-f240ba416b38");
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

	#region Class: AccountFolder_BaseEventsProcess

	/// <exclude/>
	public class AccountFolder_BaseEventsProcess : AccountFolder_BaseEventsProcess<AccountFolder>
	{

		public AccountFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountFolder_BaseEventsProcess

	public partial class AccountFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: AccountFolderEventsProcess

	/// <exclude/>
	public class AccountFolderEventsProcess : AccountFolder_BaseEventsProcess
	{

		public AccountFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

