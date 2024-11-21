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

	#region Class: OAuthClientAppSchema

	/// <exclude/>
	public class OAuthClientAppSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthClientAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthClientAppSchema(OAuthClientAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthClientAppSchema(OAuthClientAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			RealUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			Name = "OAuthClientApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("16220101-22c4-40ca-a6c9-8c3c1afa75a1")) == null) {
				Columns.Add(CreateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("701b3c29-37f1-4d60-9361-c29bb15c25cb")) == null) {
				Columns.Add(CreateClientSecretColumn());
			}
			if (Columns.FindByUId(new Guid("a5c9087d-a8de-464e-9375-9aec4759eb05")) == null) {
				Columns.Add(CreateRedirectUrlColumn());
			}
			if (Columns.FindByUId(new Guid("9c9cd4e6-da72-49e5-96b2-b9c9d6450492")) == null) {
				Columns.Add(CreateApplicationUrlColumn());
			}
			if (Columns.FindByUId(new Guid("eea83bb7-ff41-4c06-a99e-c9b334f7e91d")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("c26abcd2-3719-48c1-856a-f9d28c8bfb57")) == null) {
				Columns.Add(CreateSystemUserColumn());
			}
			if (Columns.FindByUId(new Guid("5dad3c79-ebcd-40cd-ad94-b51ec88bd452")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a38174ae-0e3e-4c37-8630-4f88fac36c0c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("16220101-22c4-40ca-a6c9-8c3c1afa75a1"),
				Name = @"ClientId",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateClientSecretColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("701b3c29-37f1-4d60-9361-c29bb15c25cb"),
				Name = @"ClientSecret",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a5c9087d-a8de-464e-9375-9aec4759eb05"),
				Name = @"RedirectUrl",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateApplicationUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9c9cd4e6-da72-49e5-96b2-b9c9d6450492"),
				Name = @"ApplicationUrl",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eea83bb7-ff41-4c06-a99e-c9b334f7e91d"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSystemUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c26abcd2-3719-48c1-856a-f9d28c8bfb57"),
				Name = @"SystemUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5dad3c79-ebcd-40cd-ad94-b51ec88bd452"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthClientApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthClientApp_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthClientAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthClientAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientApp

	/// <summary>
	/// OAuth client application.
	/// </summary>
	public class OAuthClientApp : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthClientApp";
		}

		public OAuthClientApp(OAuthClientApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Client secret.
		/// </summary>
		public string ClientSecret {
			get {
				return GetTypedColumnValue<string>("ClientSecret");
			}
			set {
				SetColumnValue("ClientSecret", value);
			}
		}

		/// <summary>
		/// Redirect URL.
		/// </summary>
		public string RedirectUrl {
			get {
				return GetTypedColumnValue<string>("RedirectUrl");
			}
			set {
				SetColumnValue("RedirectUrl", value);
			}
		}

		/// <summary>
		/// Application URL.
		/// </summary>
		public string ApplicationUrl {
			get {
				return GetTypedColumnValue<string>("ApplicationUrl");
			}
			set {
				SetColumnValue("ApplicationUrl", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid SystemUserId {
			get {
				return GetTypedColumnValue<Guid>("SystemUserId");
			}
			set {
				SetColumnValue("SystemUserId", value);
				_systemUser = null;
			}
		}

		/// <exclude/>
		public string SystemUserName {
			get {
				return GetTypedColumnValue<string>("SystemUserName");
			}
			set {
				SetColumnValue("SystemUserName", value);
				if (_systemUser != null) {
					_systemUser.Name = value;
				}
			}
		}

		private SysAdminUnit _systemUser;
		/// <summary>
		/// System user.
		/// </summary>
		public SysAdminUnit SystemUser {
			get {
				return _systemUser ??
					(_systemUser = LookupColumnEntities.GetEntity("SystemUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthClientApp_OAuth20EventsProcess(UserConnection);
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
			return new OAuthClientApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthClientApp_OAuth20EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OAuthClientApp
	{

		public OAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthClientApp_OAuth20EventsProcess";
			SchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
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

	#region Class: OAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthClientApp_OAuth20EventsProcess : OAuthClientApp_OAuth20EventsProcess<OAuthClientApp>
	{

		public OAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthClientApp_OAuth20EventsProcess

	public partial class OAuthClientApp_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthClientAppEventsProcess

	/// <exclude/>
	public class OAuthClientAppEventsProcess : OAuthClientApp_OAuth20EventsProcess
	{

		public OAuthClientAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

