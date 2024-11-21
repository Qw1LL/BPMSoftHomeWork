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

	#region Class: AccountAlternativeNameSchema

	/// <exclude/>
	public class AccountAlternativeNameSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountAlternativeNameSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountAlternativeNameSchema(AccountAlternativeNameSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountAlternativeNameSchema(AccountAlternativeNameSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56");
			RealUId = new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56");
			Name = "AccountAlternativeName";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5eb0abd5-fa4c-4130-b358-feb9920ab054")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5eb0abd5-fa4c-4130-b358-feb9920ab054"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56"),
				ModifiedInSchemaUId = new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountAlternativeName(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountAlternativeName_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountAlternativeNameSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountAlternativeNameSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountAlternativeName

	/// <summary>
	/// Also Known As.
	/// </summary>
	public class AccountAlternativeName : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountAlternativeName(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountAlternativeName";
		}

		public AccountAlternativeName(AccountAlternativeName source)
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
			var process = new AccountAlternativeName_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountAlternativeNameDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountAlternativeNameDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountAlternativeNameInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountAlternativeNameInserting", e);
			Saved += (s, e) => ThrowEvent("AccountAlternativeNameSaved", e);
			Saving += (s, e) => ThrowEvent("AccountAlternativeNameSaving", e);
			Validating += (s, e) => ThrowEvent("AccountAlternativeNameValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountAlternativeName(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAlternativeName_BaseEventsProcess

	/// <exclude/>
	public partial class AccountAlternativeName_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AccountAlternativeName
	{

		public AccountAlternativeName_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountAlternativeName_BaseEventsProcess";
			SchemaUId = new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9f4fc7b4-8205-4034-995d-23aa97ff1f56");
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

	#region Class: AccountAlternativeName_BaseEventsProcess

	/// <exclude/>
	public class AccountAlternativeName_BaseEventsProcess : AccountAlternativeName_BaseEventsProcess<AccountAlternativeName>
	{

		public AccountAlternativeName_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountAlternativeName_BaseEventsProcess

	public partial class AccountAlternativeName_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountAlternativeNameEventsProcess

	/// <exclude/>
	public class AccountAlternativeNameEventsProcess : AccountAlternativeName_BaseEventsProcess
	{

		public AccountAlternativeNameEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

