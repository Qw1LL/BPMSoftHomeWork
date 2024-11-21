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

	#region Class: OAuth20AppInFolderSchema

	/// <exclude/>
	public class OAuth20AppInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public OAuth20AppInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuth20AppInFolderSchema(OAuth20AppInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuth20AppInFolderSchema(OAuth20AppInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			RealUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			Name = "OAuth20AppInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c29dd91b-dcba-44b2-a754-2194dac05718")) == null) {
				Columns.Add(CreateOAuth20AppColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("7eefb17b-1bf7-4f52-90b5-d8b89ef8c5c2");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOAuth20AppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c29dd91b-dcba-44b2-a754-2194dac05718"),
				Name = @"OAuth20App",
				ReferenceSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788"),
				ModifiedInSchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788"),
				CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuth20AppInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuth20AppInFolder_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuth20AppInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuth20AppInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6eecf745-4373-42af-9e12-a36eca838788"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppInFolder

	/// <summary>
	/// OAuth 2.0 applications in group.
	/// </summary>
	public class OAuth20AppInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public OAuth20AppInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuth20AppInFolder";
		}

		public OAuth20AppInFolder(OAuth20AppInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// OAuth 2.0 applications.
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
			var process = new OAuth20AppInFolder_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new OAuth20AppInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppInFolder_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class OAuth20AppInFolder_OAuth20IntegrationEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : OAuth20AppInFolder
	{

		public OAuth20AppInFolder_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuth20AppInFolder_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("6eecf745-4373-42af-9e12-a36eca838788");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6eecf745-4373-42af-9e12-a36eca838788");
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

	#region Class: OAuth20AppInFolder_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class OAuth20AppInFolder_OAuth20IntegrationEventsProcess : OAuth20AppInFolder_OAuth20IntegrationEventsProcess<OAuth20AppInFolder>
	{

		public OAuth20AppInFolder_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuth20AppInFolder_OAuth20IntegrationEventsProcess

	public partial class OAuth20AppInFolder_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuth20AppInFolderEventsProcess

	/// <exclude/>
	public class OAuth20AppInFolderEventsProcess : OAuth20AppInFolder_OAuth20IntegrationEventsProcess
	{

		public OAuth20AppInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

