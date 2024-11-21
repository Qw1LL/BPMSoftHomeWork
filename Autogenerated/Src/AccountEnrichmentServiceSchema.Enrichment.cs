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

	#region Class: AccountEnrichmentServiceSchema

	/// <exclude/>
	public class AccountEnrichmentServiceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AccountEnrichmentServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountEnrichmentServiceSchema(AccountEnrichmentServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountEnrichmentServiceSchema(AccountEnrichmentServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e3cace4-952f-4168-8094-6c089b8a8957");
			RealUId = new Guid("5e3cace4-952f-4168-8094-6c089b8a8957");
			Name = "AccountEnrichmentService";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("31b5d7f7-badf-48c1-9851-9c5977a10469");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cfa42ec7-5e4e-e3ce-dcfa-7e740e1adea8")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("cfa42ec7-5e4e-e3ce-dcfa-7e740e1adea8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("5e3cace4-952f-4168-8094-6c089b8a8957"),
				ModifiedInSchemaUId = new Guid("5e3cace4-952f-4168-8094-6c089b8a8957"),
				CreatedInPackageId = new Guid("31b5d7f7-badf-48c1-9851-9c5977a10469")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountEnrichmentService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountEnrichmentService_EnrichmentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountEnrichmentServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountEnrichmentServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e3cace4-952f-4168-8094-6c089b8a8957"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountEnrichmentService

	/// <summary>
	/// Сервис обогащения контрагента.
	/// </summary>
	public class AccountEnrichmentService : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AccountEnrichmentService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountEnrichmentService";
		}

		public AccountEnrichmentService(AccountEnrichmentService source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountEnrichmentService_EnrichmentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountEnrichmentService(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountEnrichmentService_EnrichmentEventsProcess

	/// <exclude/>
	public partial class AccountEnrichmentService_EnrichmentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AccountEnrichmentService
	{

		public AccountEnrichmentService_EnrichmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountEnrichmentService_EnrichmentEventsProcess";
			SchemaUId = new Guid("5e3cace4-952f-4168-8094-6c089b8a8957");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e3cace4-952f-4168-8094-6c089b8a8957");
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

	#region Class: AccountEnrichmentService_EnrichmentEventsProcess

	/// <exclude/>
	public class AccountEnrichmentService_EnrichmentEventsProcess : AccountEnrichmentService_EnrichmentEventsProcess<AccountEnrichmentService>
	{

		public AccountEnrichmentService_EnrichmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountEnrichmentService_EnrichmentEventsProcess

	public partial class AccountEnrichmentService_EnrichmentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountEnrichmentServiceEventsProcess

	/// <exclude/>
	public class AccountEnrichmentServiceEventsProcess : AccountEnrichmentService_EnrichmentEventsProcess
	{

		public AccountEnrichmentServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

