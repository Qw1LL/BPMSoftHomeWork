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

	#region Class: WebServiceSchema

	/// <exclude/>
	public class WebServiceSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public WebServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceSchema(WebServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceSchema(WebServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			RealUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			Name = "WebService";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ec098519-30ad-4797-a05c-29940ddf76ff")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("dc2ef24c-a56d-4a77-83b5-c1665bb0f573")) == null) {
				Columns.Add(CreateWebServiceURLColumn());
			}
			if (Columns.FindByUId(new Guid("d3050c25-45e3-4bf3-a240-f04ee03a1e69")) == null) {
				Columns.Add(CreateWSDLURLColumn());
			}
			if (Columns.FindByUId(new Guid("154dcbd8-ca40-40c7-9342-3405c93364f3")) == null) {
				Columns.Add(CreateWSDLColumn());
			}
			if (Columns.FindByUId(new Guid("1b7e8422-a667-4670-8d6c-40a8de699ca4")) == null) {
				Columns.Add(CreateTimeoutColumn());
			}
			if (Columns.FindByUId(new Guid("5c25a69e-8dab-4a68-9ca4-4bed018946c6")) == null) {
				Columns.Add(CreateHTTPAuthTypeColumn());
			}
			if (Columns.FindByUId(new Guid("5cb3ab2b-6d44-49ce-beb5-de28d3ff9511")) == null) {
				Columns.Add(CreateLoginColumn());
			}
			if (Columns.FindByUId(new Guid("c852b8a4-51e0-4a23-ab09-c8f7eea28576")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
			if (Columns.FindByUId(new Guid("d82d9b5a-2b9b-418f-8e69-354e91295674")) == null) {
				Columns.Add(CreateGenerateProxyColumn());
			}
			if (Columns.FindByUId(new Guid("79ceb317-c310-43b0-8d88-96f22e5c194e")) == null) {
				Columns.Add(CreateNamespaceColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ec098519-30ad-4797-a05c-29940ddf76ff"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateWebServiceURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dc2ef24c-a56d-4a77-83b5-c1665bb0f573"),
				Name = @"WebServiceURL",
				ReferenceSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateWSDLURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d3050c25-45e3-4bf3-a240-f04ee03a1e69"),
				Name = @"WSDLURL",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateWSDLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("154dcbd8-ca40-40c7-9342-3405c93364f3"),
				Name = @"WSDL",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeoutColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1b7e8422-a667-4670-8d6c-40a8de699ca4"),
				Name = @"Timeout",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateHTTPAuthTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c25a69e-8dab-4a68-9ca4-4bed018946c6"),
				Name = @"HTTPAuthType",
				ReferenceSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"dd994ef0-8583-458b-9180-35f0d6665351"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5cb3ab2b-6d44-49ce-beb5-de28d3ff9511"),
				Name = @"Login",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c852b8a4-51e0-4a23-ab09-c8f7eea28576"),
				Name = @"Password",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateGenerateProxyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d82d9b5a-2b9b-418f-8e69-354e91295674"),
				Name = @"GenerateProxy",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateNamespaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("79ceb317-c310-43b0-8d88-96f22e5c194e"),
				Name = @"Namespace",
				CreatedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				ModifiedInSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebService_ProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"));
		}

		#endregion

	}

	#endregion

	#region Class: WebService

	/// <summary>
	/// Web service.
	/// </summary>
	public class WebService : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public WebService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebService";
		}

		public WebService(WebService source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid WebServiceURLId {
			get {
				return GetTypedColumnValue<Guid>("WebServiceURLId");
			}
			set {
				SetColumnValue("WebServiceURLId", value);
				_webServiceURL = null;
			}
		}

		/// <exclude/>
		public string WebServiceURLURL {
			get {
				return GetTypedColumnValue<string>("WebServiceURLURL");
			}
			set {
				SetColumnValue("WebServiceURLURL", value);
				if (_webServiceURL != null) {
					_webServiceURL.URL = value;
				}
			}
		}

		private WebServiceURL _webServiceURL;
		/// <summary>
		/// Service address.
		/// </summary>
		public WebServiceURL WebServiceURL {
			get {
				return _webServiceURL ??
					(_webServiceURL = LookupColumnEntities.GetEntity("WebServiceURL") as WebServiceURL);
			}
		}

		/// <summary>
		/// Service WSDL address.
		/// </summary>
		public string WSDLURL {
			get {
				return GetTypedColumnValue<string>("WSDLURL");
			}
			set {
				SetColumnValue("WSDLURL", value);
			}
		}

		/// <summary>
		/// WSDL.
		/// </summary>
		public string WSDL {
			get {
				return GetTypedColumnValue<string>("WSDL");
			}
			set {
				SetColumnValue("WSDL", value);
			}
		}

		/// <summary>
		/// Request timeout, sec.
		/// </summary>
		public int Timeout {
			get {
				return GetTypedColumnValue<int>("Timeout");
			}
			set {
				SetColumnValue("Timeout", value);
			}
		}

		/// <exclude/>
		public Guid HTTPAuthTypeId {
			get {
				return GetTypedColumnValue<Guid>("HTTPAuthTypeId");
			}
			set {
				SetColumnValue("HTTPAuthTypeId", value);
				_hTTPAuthType = null;
			}
		}

		/// <exclude/>
		public string HTTPAuthTypeName {
			get {
				return GetTypedColumnValue<string>("HTTPAuthTypeName");
			}
			set {
				SetColumnValue("HTTPAuthTypeName", value);
				if (_hTTPAuthType != null) {
					_hTTPAuthType.Name = value;
				}
			}
		}

		private HTTPAuthType _hTTPAuthType;
		/// <summary>
		/// Authentication type.
		/// </summary>
		public HTTPAuthType HTTPAuthType {
			get {
				return _hTTPAuthType ??
					(_hTTPAuthType = LookupColumnEntities.GetEntity("HTTPAuthType") as HTTPAuthType);
			}
		}

		/// <summary>
		/// User login.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
			}
		}

		/// <summary>
		/// Generate C# proxy classes.
		/// </summary>
		public bool GenerateProxy {
			get {
				return GetTypedColumnValue<bool>("GenerateProxy");
			}
			set {
				SetColumnValue("GenerateProxy", value);
			}
		}

		/// <summary>
		/// Namespace for proxy classes.
		/// </summary>
		public string Namespace {
			get {
				return GetTypedColumnValue<string>("Namespace");
			}
			set {
				SetColumnValue("Namespace", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebService_ProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WebServiceDeleted", e);
			Inserting += (s, e) => ThrowEvent("WebServiceInserting", e);
			Validating += (s, e) => ThrowEvent("WebServiceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebService(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebService_ProcessDesignerEventsProcess

	/// <exclude/>
	public partial class WebService_ProcessDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : WebService
	{

		public WebService_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebService_ProcessDesignerEventsProcess";
			SchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34a72c74-848f-4081-86c8-87310ee15fb5");
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

	#region Class: WebService_ProcessDesignerEventsProcess

	/// <exclude/>
	public class WebService_ProcessDesignerEventsProcess : WebService_ProcessDesignerEventsProcess<WebService>
	{

		public WebService_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebService_ProcessDesignerEventsProcess

	public partial class WebService_ProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceEventsProcess

	/// <exclude/>
	public class WebServiceEventsProcess : WebService_ProcessDesignerEventsProcess
	{

		public WebServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

