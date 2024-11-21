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

	#region Class: OAuthResourceInClientSchema

	/// <exclude/>
	public class OAuthResourceInClientSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthResourceInClientSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthResourceInClientSchema(OAuthResourceInClientSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthResourceInClientSchema(OAuthResourceInClientSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4");
			RealUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4");
			Name = "OAuthResourceInClient";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("903e83cd-30cb-479f-941a-d11f68fa45d8")) == null) {
				Columns.Add(CreateOAuthResourceColumn());
			}
			if (Columns.FindByUId(new Guid("64867280-a6e8-4d71-9b3d-e6b6cb0ad9ac")) == null) {
				Columns.Add(CreateOAuthClientColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuthResourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("903e83cd-30cb-479f-941a-d11f68fa45d8"),
				Name = @"OAuthResource",
				ReferenceSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4"),
				ModifiedInSchemaUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthClientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("64867280-a6e8-4d71-9b3d-e6b6cb0ad9ac"),
				Name = @"OAuthClient",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4"),
				ModifiedInSchemaUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthResourceInClient(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthResourceInClient_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthResourceInClientSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthResourceInClientSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthResourceInClient

	/// <summary>
	/// OAuth resource to client connection.
	/// </summary>
	public class OAuthResourceInClient : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthResourceInClient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthResourceInClient";
		}

		public OAuthResourceInClient(OAuthResourceInClient source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OAuthResourceId {
			get {
				return GetTypedColumnValue<Guid>("OAuthResourceId");
			}
			set {
				SetColumnValue("OAuthResourceId", value);
				_oAuthResource = null;
			}
		}

		/// <exclude/>
		public string OAuthResourceDisplayName {
			get {
				return GetTypedColumnValue<string>("OAuthResourceDisplayName");
			}
			set {
				SetColumnValue("OAuthResourceDisplayName", value);
				if (_oAuthResource != null) {
					_oAuthResource.DisplayName = value;
				}
			}
		}

		private OAuthResource _oAuthResource;
		/// <summary>
		/// OAuth resource.
		/// </summary>
		public OAuthResource OAuthResource {
			get {
				return _oAuthResource ??
					(_oAuthResource = LookupColumnEntities.GetEntity("OAuthResource") as OAuthResource);
			}
		}

		/// <exclude/>
		public Guid OAuthClientId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientId");
			}
			set {
				SetColumnValue("OAuthClientId", value);
				_oAuthClient = null;
			}
		}

		/// <exclude/>
		public string OAuthClientName {
			get {
				return GetTypedColumnValue<string>("OAuthClientName");
			}
			set {
				SetColumnValue("OAuthClientName", value);
				if (_oAuthClient != null) {
					_oAuthClient.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClient;
		/// <summary>
		/// OAuth client.
		/// </summary>
		public OAuthClientApp OAuthClient {
			get {
				return _oAuthClient ??
					(_oAuthClient = LookupColumnEntities.GetEntity("OAuthClient") as OAuthClientApp);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthResourceInClient_OAuth20EventsProcess(UserConnection);
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
			return new OAuthResourceInClient(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthResourceInClient_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthResourceInClient_OAuth20EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OAuthResourceInClient
	{

		public OAuthResourceInClient_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthResourceInClient_OAuth20EventsProcess";
			SchemaUId = new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0e7bc4ac-2f5f-45e9-aab8-3933bd52cfb4");
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

	#region Class: OAuthResourceInClient_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthResourceInClient_OAuth20EventsProcess : OAuthResourceInClient_OAuth20EventsProcess<OAuthResourceInClient>
	{

		public OAuthResourceInClient_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthResourceInClient_OAuth20EventsProcess

	public partial class OAuthResourceInClient_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthResourceInClientEventsProcess

	/// <exclude/>
	public class OAuthResourceInClientEventsProcess : OAuthResourceInClient_OAuth20EventsProcess
	{

		public OAuthResourceInClientEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

