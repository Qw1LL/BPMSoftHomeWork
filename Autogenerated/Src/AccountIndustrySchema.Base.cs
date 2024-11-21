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

	#region Class: AccountIndustrySchema

	/// <exclude/>
	public class AccountIndustrySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountIndustrySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountIndustrySchema(AccountIndustrySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountIndustrySchema(AccountIndustrySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
			RealUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
			Name = "AccountIndustry";
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

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
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
			return new AccountIndustry(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountIndustry_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountIndustrySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountIndustrySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountIndustry

	/// <summary>
	/// Industry.
	/// </summary>
	public class AccountIndustry : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountIndustry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountIndustry";
		}

		public AccountIndustry(AccountIndustry source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountIndustry_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountIndustryDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountIndustryDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountIndustryInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountIndustryInserting", e);
			Saved += (s, e) => ThrowEvent("AccountIndustrySaved", e);
			Saving += (s, e) => ThrowEvent("AccountIndustrySaving", e);
			Validating += (s, e) => ThrowEvent("AccountIndustryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountIndustry(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountIndustry_BaseEventsProcess

	/// <exclude/>
	public partial class AccountIndustry_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AccountIndustry
	{

		public AccountIndustry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountIndustry_BaseEventsProcess";
			SchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e");
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

	#region Class: AccountIndustry_BaseEventsProcess

	/// <exclude/>
	public class AccountIndustry_BaseEventsProcess : AccountIndustry_BaseEventsProcess<AccountIndustry>
	{

		public AccountIndustry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountIndustry_BaseEventsProcess

	public partial class AccountIndustry_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountIndustryEventsProcess

	/// <exclude/>
	public class AccountIndustryEventsProcess : AccountIndustry_BaseEventsProcess
	{

		public AccountIndustryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

