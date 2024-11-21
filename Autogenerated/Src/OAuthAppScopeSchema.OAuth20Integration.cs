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

	#region Class: OAuthAppScopeSchema

	/// <exclude/>
	public class OAuthAppScopeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthAppScopeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthAppScopeSchema(OAuthAppScopeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthAppScopeSchema(OAuthAppScopeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			RealUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			Name = "OAuthAppScope";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d6994fc3-772f-4f48-9e65-62d864f72610")) == null) {
				Columns.Add(CreateScopeColumn());
			}
			if (Columns.FindByUId(new Guid("7b3cf478-bbd0-49f7-88a7-579296db059c")) == null) {
				Columns.Add(CreateOAuth20AppColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			return column;
		}

		protected virtual EntitySchemaColumn CreateScopeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("d6994fc3-772f-4f48-9e65-62d864f72610"),
				Name = @"Scope",
				CreatedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923"),
				ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923"),
				CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193")
			};
		}

		protected virtual EntitySchemaColumn CreateOAuth20AppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7b3cf478-bbd0-49f7-88a7-579296db059c"),
				Name = @"OAuth20App",
				ReferenceSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923"),
				ModifiedInSchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923"),
				CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthAppScope(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthAppScope_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthAppScopeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthAppScopeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("183ac595-fa6c-4b64-932c-7008ff739923"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppScope

	/// <summary>
	/// Scopes.
	/// </summary>
	public class OAuthAppScope : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthAppScope(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthAppScope";
		}

		public OAuthAppScope(OAuthAppScope source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Scope.
		/// </summary>
		public string Scope {
			get {
				return GetTypedColumnValue<string>("Scope");
			}
			set {
				SetColumnValue("Scope", value);
			}
		}

		/// <exclude/>
		public Guid OAuth20AppId {
			get {
				return GetTypedColumnValue<Guid>("OAuth20AppId");
			}
			set {
				SetColumnValue("OAuth20AppId", value);
				_oAuth20App = null;
			}
		}

		/// <exclude/>
		public string OAuth20AppName {
			get {
				return GetTypedColumnValue<string>("OAuth20AppName");
			}
			set {
				SetColumnValue("OAuth20AppName", value);
				if (_oAuth20App != null) {
					_oAuth20App.Name = value;
				}
			}
		}

		private OAuthApplications _oAuth20App;
		/// <summary>
		/// OAuth 2.0 application.
		/// </summary>
		public OAuthApplications OAuth20App {
			get {
				return _oAuth20App ??
					(_oAuth20App = LookupColumnEntities.GetEntity("OAuth20App") as OAuthApplications);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthAppScope_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new OAuthAppScope(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppScope_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class OAuthAppScope_OAuth20IntegrationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OAuthAppScope
	{

		public OAuthAppScope_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthAppScope_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("183ac595-fa6c-4b64-932c-7008ff739923");
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

	#region Class: OAuthAppScope_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class OAuthAppScope_OAuth20IntegrationEventsProcess : OAuthAppScope_OAuth20IntegrationEventsProcess<OAuthAppScope>
	{

		public OAuthAppScope_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthAppScope_OAuth20IntegrationEventsProcess

	public partial class OAuthAppScope_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthAppScopeEventsProcess

	/// <exclude/>
	public class OAuthAppScopeEventsProcess : OAuthAppScope_OAuth20IntegrationEventsProcess
	{

		public OAuthAppScopeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

