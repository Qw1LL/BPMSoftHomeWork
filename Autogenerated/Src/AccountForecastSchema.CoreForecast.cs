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

	#region Class: AccountForecastSchema

	/// <exclude/>
	public class AccountForecastSchema : BPMSoft.Configuration.EntityInForecastCellSchema
	{

		#region Constructors: Public

		public AccountForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountForecastSchema(AccountForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountForecastSchema(AccountForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("74900c50-b7e7-452a-83d9-f98707756d6c");
			RealUId = new Guid("74900c50-b7e7-452a-83d9-f98707756d6c");
			Name = "AccountForecast";
			ParentSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("570b82b1-62e9-46b8-b98d-55c7a903e7d8")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("570b82b1-62e9-46b8-b98d-55c7a903e7d8"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("74900c50-b7e7-452a-83d9-f98707756d6c"),
				ModifiedInSchemaUId = new Guid("74900c50-b7e7-452a-83d9-f98707756d6c"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountForecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountForecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("74900c50-b7e7-452a-83d9-f98707756d6c"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountForecast

	/// <summary>
	/// Планирование по контрагенту.
	/// </summary>
	public class AccountForecast : BPMSoft.Configuration.EntityInForecastCell
	{

		#region Constructors: Public

		public AccountForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountForecast";
		}

		public AccountForecast(AccountForecast source)
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
		/// Контрагент.
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
			var process = new AccountForecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("AccountForecastInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountForecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountForecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class AccountForecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.EntityInForecastCell_CoreForecastEventsProcess<TEntity> where TEntity : AccountForecast
	{

		public AccountForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountForecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("74900c50-b7e7-452a-83d9-f98707756d6c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("74900c50-b7e7-452a-83d9-f98707756d6c");
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

	#region Class: AccountForecast_CoreForecastEventsProcess

	/// <exclude/>
	public class AccountForecast_CoreForecastEventsProcess : AccountForecast_CoreForecastEventsProcess<AccountForecast>
	{

		public AccountForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountForecast_CoreForecastEventsProcess

	public partial class AccountForecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountForecastEventsProcess

	/// <exclude/>
	public class AccountForecastEventsProcess : AccountForecast_CoreForecastEventsProcess
	{

		public AccountForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

