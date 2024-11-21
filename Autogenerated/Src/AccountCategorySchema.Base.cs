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

	#region Class: AccountCategorySchema

	/// <exclude/>
	public class AccountCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountCategorySchema(AccountCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountCategorySchema(AccountCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			RealUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			Name = "AccountCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountCategory_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountCategory

	/// <summary>
	/// Category of Account.
	/// </summary>
	public class AccountCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountCategory";
		}

		public AccountCategory(AccountCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountCategory_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountCategoryDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountCategoryDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountCategoryInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountCategoryInserting", e);
			Saved += (s, e) => ThrowEvent("AccountCategorySaved", e);
			Saving += (s, e) => ThrowEvent("AccountCategorySaving", e);
			Validating += (s, e) => ThrowEvent("AccountCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountCategory_BaseEventsProcess

	/// <exclude/>
	public partial class AccountCategory_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AccountCategory
	{

		public AccountCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountCategory_BaseEventsProcess";
			SchemaUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
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

	#region Class: AccountCategory_BaseEventsProcess

	/// <exclude/>
	public class AccountCategory_BaseEventsProcess : AccountCategory_BaseEventsProcess<AccountCategory>
	{

		public AccountCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountCategory_BaseEventsProcess

	public partial class AccountCategory_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountCategoryEventsProcess

	/// <exclude/>
	public class AccountCategoryEventsProcess : AccountCategory_BaseEventsProcess
	{

		public AccountCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

