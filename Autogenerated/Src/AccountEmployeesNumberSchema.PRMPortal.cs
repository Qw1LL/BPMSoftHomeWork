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

	#region Class: AccountEmployeesNumberSchema

	/// <exclude/>
	public class AccountEmployeesNumberSchema : BPMSoft.Configuration.AccountEmployeesNumber_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public AccountEmployeesNumberSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountEmployeesNumberSchema(AccountEmployeesNumberSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountEmployeesNumberSchema(AccountEmployeesNumberSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("00ca7c4d-33cf-4ac4-ba6b-44ec27c24612");
			Name = "AccountEmployeesNumber";
			ParentSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d");
			ExtendParent = true;
			CreatedInPackageId = new Guid("10676561-1f93-46bf-90be-fe5cd67025e0");
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
			return new AccountEmployeesNumber(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountEmployeesNumber_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountEmployeesNumberSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountEmployeesNumberSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("00ca7c4d-33cf-4ac4-ba6b-44ec27c24612"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountEmployeesNumber

	/// <summary>
	/// Количество сотрудников контрагента.
	/// </summary>
	public class AccountEmployeesNumber : BPMSoft.Configuration.AccountEmployeesNumber_Base_BPMSoft
	{

		#region Constructors: Public

		public AccountEmployeesNumber(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountEmployeesNumber";
		}

		public AccountEmployeesNumber(AccountEmployeesNumber source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountEmployeesNumber_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountEmployeesNumberDeleted", e);
			Validating += (s, e) => ThrowEvent("AccountEmployeesNumberValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountEmployeesNumber(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountEmployeesNumber_PRMPortalEventsProcess

	/// <exclude/>
	public partial class AccountEmployeesNumber_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.AccountEmployeesNumber_BaseEventsProcess<TEntity> where TEntity : AccountEmployeesNumber
	{

		public AccountEmployeesNumber_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountEmployeesNumber_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("00ca7c4d-33cf-4ac4-ba6b-44ec27c24612");
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

	#region Class: AccountEmployeesNumber_PRMPortalEventsProcess

	/// <exclude/>
	public class AccountEmployeesNumber_PRMPortalEventsProcess : AccountEmployeesNumber_PRMPortalEventsProcess<AccountEmployeesNumber>
	{

		public AccountEmployeesNumber_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountEmployeesNumber_PRMPortalEventsProcess

	public partial class AccountEmployeesNumber_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountEmployeesNumberEventsProcess

	/// <exclude/>
	public class AccountEmployeesNumberEventsProcess : AccountEmployeesNumber_PRMPortalEventsProcess
	{

		public AccountEmployeesNumberEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

